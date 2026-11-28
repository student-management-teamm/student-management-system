namespace StudentManagementWinForms.Grades;

/// <summary>
/// Part 4 extension: import attendance, midterm and final scores of one class and course from
/// the lecturer's Excel (.xlsx) or CSV grade sheet. Students are matched by student code; every
/// row is previewed and can be corrected, left out or removed before saving, and the last
/// import can be undone.
/// </summary>
public partial class FormGradeImport : Form
{
    private sealed class PreviewEntry
    {
        public ImportedScoreRow Row { get; init; } = new();
        public CourseGrade? Existing { get; set; }
        public CourseGrade? Updated { get; set; }
        public bool Include { get; set; } = true;
        public bool Duplicate { get; set; }
    }

    private sealed record ImportSnapshot(int CourseId, string Description, List<CourseGrade> Before);

    private readonly IGradeRepository repository;
    private ParsedGradeSheet? sheet;
    private readonly List<PreviewEntry> entries = new();
    private ImportSnapshot? lastImport;
    private bool loading;

    public FormGradeImport() : this(GradesModule.Repository)
    {
    }

    public FormGradeImport(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormGradeImport_Load(object? sender, EventArgs e)
    {
        loading = true;
        cboClass.DisplayMember = nameof(ClassInfo.ClassName);
        cboClass.DataSource = repository.GetClasses().ToList();
        cboCourse.DisplayMember = nameof(CourseInfo.DisplayName);
        loading = false;
        LoadCourses();
        UpdateButtons();
    }

    private ClassInfo? SelectedClass => cboClass.SelectedItem as ClassInfo;

    private CourseInfo? SelectedCourse => cboCourse.SelectedItem as CourseInfo;

    private void LoadCourses()
    {
        loading = true;
        cboCourse.DataSource = SelectedClass is ClassInfo cls
            ? repository.GetCoursesByClass(cls.ClassId).ToList()
            : new List<CourseInfo>();
        loading = false;
        BuildPreview();
    }

    private void cboClass_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!loading)
        {
            LoadCourses();
        }
    }

    private void cboCourse_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!loading)
        {
            BuildPreview();
        }
    }

    private void chkKeepEmpty_CheckedChanged(object? sender, EventArgs e)
    {
        foreach (PreviewEntry entry in entries)
        {
            Evaluate(entry);
        }
        RenderRows();
    }

    private void btnBrowse_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new()
        {
            Title = "Choose a grade sheet",
            Filter = "Grade sheets (*.xlsx;*.csv)|*.xlsx;*.csv|Excel workbook (*.xlsx)|*.xlsx|CSV file (*.csv)|*.csv"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            sheet = GradeSheetParser.Parse(GradeFileReader.ReadRows(dialog.FileName));
            lblFile.Text = Path.GetFileName(dialog.FileName);
            lblColumns.Text = "Columns found - " + sheet.DescribeColumns();
        }
        catch (IOException ex)
        {
            sheet = null;
            MessageBox.Show(this, "Could not open the file. Close it in Excel and try again.\n" + ex.Message,
                "File error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            sheet = null;
            MessageBox.Show(this, "Could not read the grade sheet.\n" + ex.Message,
                "File error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        BuildPreview();
    }

    /// <summary>Matches the file rows with the scores stored for the chosen class and course.</summary>
    private void BuildPreview()
    {
        entries.Clear();
        if (sheet != null && SelectedClass is ClassInfo cls && SelectedCourse is CourseInfo course)
        {
            Dictionary<string, CourseGrade> current = CurrentGrades(cls, course);
            HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);
            foreach (ImportedScoreRow row in sheet.Rows)
            {
                PreviewEntry entry = new()
                {
                    Row = row,
                    Existing = current.GetValueOrDefault(row.StudentCode),
                    Duplicate = !seen.Add(row.StudentCode)
                };
                Evaluate(entry);
                entries.Add(entry);
            }
        }
        RenderRows();
    }

    private Dictionary<string, CourseGrade> CurrentGrades(ClassInfo cls, CourseInfo course) =>
        repository.GetGradesByClassAndCourse(cls.ClassId, course.CourseId)
            .GroupBy(g => g.StudentCode, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

    /// <summary>Works out what saving this row would change (sets Updated, or null when nothing to save).</summary>
    private void Evaluate(PreviewEntry entry)
    {
        entry.Updated = null;
        if (entry.Row.Error.Length > 0 || entry.Duplicate || entry.Existing == null || sheet == null)
        {
            return;
        }

        CourseGrade updated = entry.Existing.Copy();
        updated.Attendance = Pick(sheet.AttendanceColumn, entry.Row.Attendance, entry.Existing.Attendance);
        updated.Midterm = Pick(sheet.MidtermColumn, entry.Row.Midterm, entry.Existing.Midterm);
        updated.Final = Pick(sheet.FinalColumn, entry.Row.Final, entry.Existing.Final);

        if (updated.Attendance != entry.Existing.Attendance || updated.Midterm != entry.Existing.Midterm
            || updated.Final != entry.Existing.Final)
        {
            entry.Updated = updated;
        }
    }

    private decimal? Pick(int column, decimal? fromFile, decimal? currentScore)
    {
        if (column < 0)
        {
            return currentScore;
        }
        return fromFile ?? (chkKeepEmpty.Checked ? currentScore : null);
    }

    private (string Text, Color Color) StatusOf(PreviewEntry entry)
    {
        if (entry.Row.Error.Length > 0)
        {
            return ("Skipped: " + entry.Row.Error, Color.Firebrick);
        }
        if (entry.Duplicate)
        {
            return ("Skipped: student appears more than once in the file", Color.Firebrick);
        }
        if (entry.Existing == null)
        {
            return ($"Skipped: not a student of {SelectedClass?.ClassName} in this course", Color.Firebrick);
        }
        if (entry.Updated == null)
        {
            return ("No change", Color.DimGray);
        }
        if (!entry.Include)
        {
            return ("Left out (tick Import to include)", Color.DimGray);
        }
        return ("Will update" + Describe(entry.Existing, entry.Updated), Color.DarkGreen);
    }

    private void RenderRows()
    {
        loading = true;
        dgvPreview.Rows.Clear();
        foreach (PreviewEntry entry in entries)
        {
            int index = dgvPreview.Rows.Add(entry.Include, entry.Row.RowNumber, entry.Row.StudentCode,
                entry.Existing?.StudentName ?? "", entry.Row.Attendance, entry.Row.Midterm, entry.Row.Final, "");
            DataGridViewRow row = dgvPreview.Rows[index];
            row.Tag = entry;
            RefreshRow(row);
        }
        loading = false;
        UpdateSummary();
    }

    private void RefreshRow(DataGridViewRow row)
    {
        if (row.Tag is not PreviewEntry entry)
        {
            return;
        }

        (string text, Color color) = StatusOf(entry);
        row.Cells[colStatus.Index].Value = text;
        row.Cells[colStatus.Index].Style.ForeColor = color;
        bool canImport = entry.Updated != null;
        row.Cells[colInclude.Index].ReadOnly = !canImport;
        row.DefaultCellStyle.ForeColor = canImport && !entry.Include ? Color.Gray : SystemColors.ControlText;
    }

    private List<CourseGrade> PendingChanges() =>
        entries.Where(e => e.Include && e.Updated != null).Select(e => e.Updated!).ToList();

    private void UpdateSummary()
    {
        if (sheet == null || SelectedClass is not ClassInfo || SelectedCourse is not CourseInfo)
        {
            lblSummary.Text = "Choose a class, a course and a file to preview the import.";
            UpdateButtons();
            return;
        }

        int toUpdate = PendingChanges().Count;
        int leftOut = entries.Count(e => !e.Include && e.Updated != null);
        int unchanged = entries.Count(e => e.Updated == null && e.Existing != null && !e.Duplicate && e.Row.Error.Length == 0);
        int skipped = entries.Count(e => e.Row.Error.Length > 0 || e.Duplicate || e.Existing == null);
        lblSummary.Text = $"Rows: {entries.Count}   To update: {toUpdate}   Left out: {leftOut}   "
            + $"No change: {unchanged}   Skipped: {skipped}";
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        btnImport.Enabled = PendingChanges().Count > 0;
        btnRemoveRow.Enabled = dgvPreview.CurrentRow != null;
        btnUndo.Enabled = lastImport != null;
    }

    private static string Describe(CourseGrade before, CourseGrade after)
    {
        List<string> parts = new();
        if (before.Attendance != after.Attendance)
        {
            parts.Add($"attendance {Show(before.Attendance)} -> {Show(after.Attendance)}");
        }
        if (before.Midterm != after.Midterm)
        {
            parts.Add($"midterm {Show(before.Midterm)} -> {Show(after.Midterm)}");
        }
        if (before.Final != after.Final)
        {
            parts.Add($"final {Show(before.Final)} -> {Show(after.Final)}");
        }
        return " (" + string.Join(", ", parts) + ")";
    }

    private static string Show(decimal? score) => score is null ? "empty" : GradeRules.FormatScore(score);

    private bool IsScoreColumn(int column) =>
        column == colAttendance.Index || column == colMidterm.Index || column == colFinal.Index;

    // ----- editing in the preview -----

    private void dgvPreview_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!IsScoreColumn(e.ColumnIndex))
        {
            return;
        }

        if (!GradeRules.TryParseScore(Convert.ToString(e.FormattedValue), out _))
        {
            dgvPreview.Rows[e.RowIndex].ErrorText = "Score must be a number from 0 to 10 (at most 2 decimals).";
            e.Cancel = true;
        }
    }

    private void dgvPreview_CellParsing(object? sender, DataGridViewCellParsingEventArgs e)
    {
        // Accept "8,5" as well as "8.5" (score columns hold decimals, not text).
        if (IsScoreColumn(e.ColumnIndex) && GradeRules.TryParseScore(Convert.ToString(e.Value), out decimal? score))
        {
            e.Value = score;
            e.ParsingApplied = true;
        }
    }

    private void dgvPreview_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        dgvPreview.Rows[e.RowIndex].ErrorText = "Score must be a number from 0 to 10 (at most 2 decimals).";
        e.ThrowException = false;
        e.Cancel = true;
    }

    private void dgvPreview_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        DataGridViewRow row = dgvPreview.Rows[e.RowIndex];
        row.ErrorText = "";
        if (!IsScoreColumn(e.ColumnIndex) || row.Tag is not PreviewEntry entry)
        {
            return;
        }

        GradeRules.TryParseScore(Convert.ToString(row.Cells[e.ColumnIndex].Value), out decimal? score);
        loading = true;
        row.Cells[e.ColumnIndex].Value = score;
        loading = false;

        if (e.ColumnIndex == colAttendance.Index)
        {
            entry.Row.Attendance = score;
        }
        else if (e.ColumnIndex == colMidterm.Index)
        {
            entry.Row.Midterm = score;
        }
        else
        {
            entry.Row.Final = score;
        }

        // A corrected score clears an earlier "invalid score" error of this row.
        entry.Row.Error = "";
        Evaluate(entry);
        RefreshRow(row);
        UpdateSummary();
    }

    private void dgvPreview_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        if (dgvPreview.CurrentCell is DataGridViewCheckBoxCell && dgvPreview.IsCurrentCellDirty)
        {
            dgvPreview.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    private void dgvPreview_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (loading || e.RowIndex < 0 || e.ColumnIndex != colInclude.Index)
        {
            return;
        }

        DataGridViewRow row = dgvPreview.Rows[e.RowIndex];
        if (row.Tag is PreviewEntry entry)
        {
            entry.Include = row.Cells[colInclude.Index].Value is true;
            RefreshRow(row);
            UpdateSummary();
        }
    }

    private void btnRemoveRow_Click(object? sender, EventArgs e)
    {
        if (dgvPreview.CurrentRow?.Tag is not PreviewEntry entry)
        {
            return;
        }

        dgvPreview.CancelEdit();
        entries.Remove(entry);
        sheet?.Rows.Remove(entry.Row);

        // The other copy of a duplicated student code may now be valid.
        HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);
        foreach (PreviewEntry other in entries)
        {
            other.Duplicate = !seen.Add(other.Row.StudentCode);
            Evaluate(other);
        }
        RenderRows();
    }

    // ----- saving and undo -----

    private void btnImport_Click(object? sender, EventArgs e)
    {
        dgvPreview.EndEdit();
        List<CourseGrade> changes = PendingChanges();
        if (SelectedCourse is not CourseInfo course || SelectedClass is not ClassInfo cls || changes.Count == 0)
        {
            return;
        }

        if (MessageBox.Show(this, $"Save the new scores of {changes.Count} student(s) for {course.DisplayName}?",
                "Import scores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        List<CourseGrade> before = entries
            .Where(en => en.Include && en.Updated != null)
            .Select(en => en.Existing!.Copy())
            .ToList();

        try
        {
            repository.SaveGrades(course.CourseId, changes);
            lastImport = new ImportSnapshot(course.CourseId, $"{cls.ClassName} - {course.DisplayName}", before);
            MessageBox.Show(this, $"Imported scores of {changes.Count} student(s).\nUse \"Undo last import\" to put the old scores back.",
                "Import scores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Could not save the scores:\n" + ex.Message, "Save error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        BuildPreview();
    }

    private void btnUndo_Click(object? sender, EventArgs e)
    {
        if (lastImport is not ImportSnapshot snapshot)
        {
            return;
        }

        if (MessageBox.Show(this, $"Put back the scores of {snapshot.Before.Count} student(s) in {snapshot.Description} "
                + "as they were before the last import?", "Undo last import",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            // Students who had no scores before get their row deleted again (all three scores empty).
            repository.SaveGrades(snapshot.CourseId, snapshot.Before);
            lastImport = null;
            MessageBox.Show(this, "The last import was undone.", "Undo last import",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Could not undo the import:\n" + ex.Message, "Undo error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        BuildPreview();
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
