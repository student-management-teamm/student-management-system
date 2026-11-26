using System.Globalization;
using System.Text;

namespace StudentManagementWinForms.Grades;

public class ImportedScoreRow
{
    public int RowNumber { get; set; }
    public string StudentCode { get; set; } = "";
    public decimal? Attendance { get; set; }
    public decimal? Midterm { get; set; }
    public decimal? Final { get; set; }
    public string Error { get; set; } = "";
}

public class ParsedGradeSheet
{
    public int StudentCodeColumn { get; set; } = -1;
    public int AttendanceColumn { get; set; } = -1;
    public int MidtermColumn { get; set; } = -1;
    public int FinalColumn { get; set; } = -1;
    public List<ImportedScoreRow> Rows { get; } = new();

    public string DescribeColumns()
    {
        static string Name(int column) => column < 0 ? "not found" : ColumnLetter(column);
        return $"Student code: {Name(StudentCodeColumn)}   Attendance: {Name(AttendanceColumn)}   "
            + $"Midterm: {Name(MidtermColumn)}   Final: {Name(FinalColumn)}";
    }

    public static string ColumnLetter(int column)
    {
        string letters = "";
        for (int n = column + 1; n > 0; n = (n - 1) / 26)
        {
            letters = (char)('A' + (n - 1) % 26) + letters;
        }
        return letters;
    }
}

/// <summary>
/// Finds the student code and score columns of a grade sheet by their headings (Vietnamese or
/// English, for example "Ma sinh vien", "CC1", "GK", "THI1" or "Student code", "Attendance",
/// "Midterm", "Final") and reads one row per student below the headings.
/// </summary>
public static class GradeSheetParser
{
    private static readonly string[] StudentCodeHeadings = { "ma sinh vien", "ma sv", "mssv", "student code", "student id", "code" };
    private static readonly string[] AttendanceHeadings = { "cc1", "cc", "chuyen can", "diem chuyen can", "attendance" };
    private static readonly string[] MidtermHeadings = { "gk", "gk1", "giua ky", "diem giua ky", "midterm" };
    private static readonly string[] FinalHeadings = { "thi1", "thi", "cuoi ky", "diem thi", "final", "final exam" };

    private const int HeaderSearchRows = 15;

    public static ParsedGradeSheet Parse(List<string[]> rows)
    {
        ParsedGradeSheet sheet = new();
        int lastHeaderRow = -1;

        for (int r = 0; r < Math.Min(rows.Count, HeaderSearchRows); r++)
        {
            for (int c = 0; c < rows[r].Length; c++)
            {
                string heading = Normalize(rows[r][c]);
                if (heading.Length == 0)
                {
                    continue;
                }

                if (sheet.StudentCodeColumn < 0 && StudentCodeHeadings.Contains(heading))
                {
                    sheet.StudentCodeColumn = c;
                    lastHeaderRow = Math.Max(lastHeaderRow, r);
                }
                else if (sheet.AttendanceColumn < 0 && AttendanceHeadings.Contains(heading))
                {
                    sheet.AttendanceColumn = c;
                    lastHeaderRow = Math.Max(lastHeaderRow, r);
                }
                else if (sheet.MidtermColumn < 0 && MidtermHeadings.Contains(heading))
                {
                    sheet.MidtermColumn = c;
                    lastHeaderRow = Math.Max(lastHeaderRow, r);
                }
                else if (sheet.FinalColumn < 0 && FinalHeadings.Contains(heading))
                {
                    sheet.FinalColumn = c;
                    lastHeaderRow = Math.Max(lastHeaderRow, r);
                }
            }
        }

        if (sheet.StudentCodeColumn < 0)
        {
            throw new InvalidDataException("Could not find the student code column. "
                + "Expected a heading such as \"Ma sinh vien\", \"MSSV\" or \"Student code\".");
        }

        if (sheet.AttendanceColumn < 0 && sheet.MidtermColumn < 0 && sheet.FinalColumn < 0)
        {
            throw new InvalidDataException("Could not find any score column. "
                + "Expected headings such as \"CC1\", \"GK\", \"THI1\" or \"Attendance\", \"Midterm\", \"Final\".");
        }

        for (int r = lastHeaderRow + 1; r < rows.Count; r++)
        {
            string code = Cell(rows[r], sheet.StudentCodeColumn);
            if (code.Length == 0 || !code.Any(char.IsDigit))
            {
                continue;
            }

            ImportedScoreRow row = new() { RowNumber = r + 1, StudentCode = code };
            List<string> errors = new();
            row.Attendance = ReadScore(rows[r], sheet.AttendanceColumn, "attendance", errors);
            row.Midterm = ReadScore(rows[r], sheet.MidtermColumn, "midterm", errors);
            row.Final = ReadScore(rows[r], sheet.FinalColumn, "final", errors);
            row.Error = string.Join("; ", errors);
            sheet.Rows.Add(row);
        }

        return sheet;
    }

    private static decimal? ReadScore(string[] row, int column, string name, List<string> errors)
    {
        string text = Cell(row, column);
        if (!GradeRules.TryParseScore(text, out decimal? score))
        {
            errors.Add($"invalid {name} score \"{text}\"");
            return null;
        }
        return score;
    }

    private static string Cell(string[] row, int column) =>
        column >= 0 && column < row.Length ? row[column].Trim() : "";

    /// <summary>Lower case, no Vietnamese accents, single spaces: "Mã sinh viên" -> "ma sinh vien".</summary>
    public static string Normalize(string text)
    {
        string decomposed = text.Trim().ToLowerInvariant().Replace('đ', 'd').Normalize(NormalizationForm.FormD);
        StringBuilder builder = new();
        foreach (char ch in decomposed)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(char.IsWhiteSpace(ch) ? ' ' : ch);
            }
        }
        return string.Join(' ', builder.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }
}
