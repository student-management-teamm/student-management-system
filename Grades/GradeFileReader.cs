using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;

namespace StudentManagementWinForms.Grades;

/// <summary>
/// Reads the cells of a grade sheet from an Excel workbook (.xlsx, first worksheet) or a
/// CSV file. No extra library is needed: an .xlsx file is a zip of XML files.
/// </summary>
public static class GradeFileReader
{
    private static readonly XNamespace Main = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
    private static readonly XNamespace OfficeRel = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
    private static readonly XNamespace PackageRel = "http://schemas.openxmlformats.org/package/2006/relationships";

    /// <summary>Rows of cell text; row and column positions follow the file (row 0 = first row).</summary>
    public static List<string[]> ReadRows(string path)
    {
        string extension = Path.GetExtension(path).ToLowerInvariant();
        return extension switch
        {
            ".xlsx" => ReadXlsx(path),
            ".csv" or ".txt" => ReadCsv(path),
            _ => throw new NotSupportedException("Only Excel workbooks (.xlsx) and CSV files (.csv) are supported.")
        };
    }

    private static List<string[]> ReadXlsx(string path)
    {
        using FileStream stream = new(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using ZipArchive zip = new(stream, ZipArchiveMode.Read);

        List<string> sharedStrings = new();
        ZipArchiveEntry? sharedEntry = zip.GetEntry("xl/sharedStrings.xml");
        if (sharedEntry != null)
        {
            XDocument shared = Load(sharedEntry);
            foreach (XElement item in shared.Root!.Elements(Main + "si"))
            {
                sharedStrings.Add(string.Concat(item.Descendants(Main + "t").Select(t => t.Value)));
            }
        }

        XDocument sheet = Load(zip.GetEntry(FirstSheetPath(zip))
            ?? throw new InvalidDataException("The workbook has no worksheet."));

        SortedDictionary<int, Dictionary<int, string>> cells = new();
        int maxColumn = -1;
        foreach (XElement row in sheet.Descendants(Main + "row"))
        {
            int rowIndex = int.Parse((string?)row.Attribute("r") ?? "0", CultureInfo.InvariantCulture) - 1;
            int nextColumn = 0;
            foreach (XElement cell in row.Elements(Main + "c"))
            {
                string? reference = (string?)cell.Attribute("r");
                int column = reference != null ? ColumnIndex(reference) : nextColumn;
                nextColumn = column + 1;

                string type = (string?)cell.Attribute("t") ?? "n";
                string raw = (string?)cell.Element(Main + "v") ?? "";
                string text = type switch
                {
                    "s" => int.TryParse(raw, out int index) && index < sharedStrings.Count ? sharedStrings[index] : "",
                    "inlineStr" => string.Concat(cell.Descendants(Main + "t").Select(t => t.Value)),
                    "n" => NormalizeNumber(raw),
                    _ => raw
                };

                if (text.Length == 0 || rowIndex < 0)
                {
                    continue;
                }

                if (!cells.TryGetValue(rowIndex, out Dictionary<int, string>? rowCells))
                {
                    rowCells = new Dictionary<int, string>();
                    cells[rowIndex] = rowCells;
                }
                rowCells[column] = text.Trim();
                maxColumn = Math.Max(maxColumn, column);
            }
        }

        List<string[]> rows = new();
        int lastRow = cells.Count == 0 ? -1 : cells.Keys.Max();
        for (int r = 0; r <= lastRow; r++)
        {
            string[] values = new string[maxColumn + 1];
            for (int c = 0; c <= maxColumn; c++)
            {
                values[c] = cells.TryGetValue(r, out var rowCells) && rowCells.TryGetValue(c, out string? v) ? v : "";
            }
            rows.Add(values);
        }
        return rows;
    }

    private static string FirstSheetPath(ZipArchive zip)
    {
        ZipArchiveEntry? workbookEntry = zip.GetEntry("xl/workbook.xml");
        ZipArchiveEntry? relsEntry = zip.GetEntry("xl/_rels/workbook.xml.rels");
        if (workbookEntry != null && relsEntry != null)
        {
            string? relationId = (string?)Load(workbookEntry).Descendants(Main + "sheet").FirstOrDefault()?.Attribute(OfficeRel + "id");
            string? target = Load(relsEntry).Descendants(PackageRel + "Relationship")
                .FirstOrDefault(r => (string?)r.Attribute("Id") == relationId)?.Attribute("Target")?.Value;
            if (!string.IsNullOrEmpty(target))
            {
                return target.StartsWith('/') ? target.TrimStart('/') : "xl/" + target;
            }
        }
        return "xl/worksheets/sheet1.xml";
    }

    private static XDocument Load(ZipArchiveEntry entry)
    {
        using Stream stream = entry.Open();
        return XDocument.Load(stream);
    }

    private static int ColumnIndex(string reference)
    {
        int index = 0;
        foreach (char ch in reference)
        {
            if (!char.IsLetter(ch))
            {
                break;
            }
            index = index * 26 + (char.ToUpperInvariant(ch) - 'A' + 1);
        }
        return index - 1;
    }

    private static string NormalizeNumber(string raw)
    {
        // Excel stores 8.7 as 8.6999999999999993: round to 2 decimals and drop trailing zeros.
        if (double.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            return Math.Round((decimal)value, 2).ToString("0.##", CultureInfo.InvariantCulture);
        }
        return raw;
    }

    private static List<string[]> ReadCsv(string path)
    {
        string[] lines = File.ReadAllLines(path, Encoding.UTF8);
        string header = lines.FirstOrDefault(l => l.Trim().Length > 0) ?? "";
        char delimiter = new[] { ',', ';', '\t' }.OrderByDescending(d => header.Count(ch => ch == d)).First();
        return lines.Select(line => SplitCsvLine(line, delimiter)).ToList();
    }

    private static string[] SplitCsvLine(string line, char delimiter)
    {
        List<string> values = new();
        StringBuilder current = new();
        bool quoted = false;
        for (int i = 0; i < line.Length; i++)
        {
            char ch = line[i];
            if (quoted)
            {
                if (ch == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else if (ch == '"')
                {
                    quoted = false;
                }
                else
                {
                    current.Append(ch);
                }
            }
            else if (ch == '"')
            {
                quoted = true;
            }
            else if (ch == delimiter)
            {
                values.Add(current.ToString().Trim());
                current.Clear();
            }
            else
            {
                current.Append(ch);
            }
        }
        values.Add(current.ToString().Trim());
        return values.ToArray();
    }
}
