namespace StudentManagementWinForms.Grades;

/// <summary>
/// Part 4 extension: import attendance, midterm and final scores of one class and course from
/// the lecturer's Excel (.xlsx) or CSV grade sheet. Students are matched by student code and
/// every row is previewed before anything is saved.
/// </summary>
public partial class FormGradeImport : Form
{
    private const string StatusUpdate = "Will update";
    private const string StatusNoChange = "No change";

    private readonly IGradeRepository repository;
    private ParsedGradeSheet? sheet;
    private readonly List<CourseGrade> pendingChanges = new();
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
        BuildPreview();
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

    /// <summary>Compares the file with the scores stored for the chosen class and course.</summary>
    private void BuildPreview()
    {
        dgvPreview.Rows.Clear();
        pendingChanges.Clear();

        if (sheet == null || SelectedClass is not ClassInfo cls || SelectedCourse is not CourseInfo course)
        {
            btnImport.Enabled = false;
            lblSummary.Text = "Choose a class, a course and a file to preview the import.";
            return;
        }

        Dictionary<string, CourseGrade> current = repository
            .GetGradesByClassAndCourse(cls.ClassId, course.CourseId)
            .GroupBy(g => g.StudentCode, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

        HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);
        int unchanged = 0, skipped = 0;

        foreach (ImportedScoreRow row in sheet.Rows)
        {
            string status;
            string name = "";
            Color color = SystemColors.ControlText;

            if (row.Error.Length > 0)
            {
                status = "Skipped: " + row.Error;
                color = Color.Firebrick;
                skipped++;
            }
            else if (!seen.Add(row.StudentCode))
            {
                status = "Skipped: student appears more than once in the file";
                color = Color.Firebrick;
                skipped++;
            }
            else if (!current.TryGetValue(row.StudentCode, out CourseGrade? existing))
            {
                status = $"Skipped: not a student of {cls.ClassName} in this course";
                color = Color.Firebrick;
                skipped++;
            }
            else
            {
                name = existing.StudentName;
                CourseGrade updated = existing.Copy();
                updated.Attendance = Pick(sheet.AttendanceColumn, row.Attendance, existing.Attendance);
                updated.Midterm = Pick(sheet.MidtermColumn, row.Midterm, existing.Midterm);
                updated.Final = Pick(sheet.FinalColumn, row.Final, existing.Final);

                if (updated.Attendance == existing.Attendance && updated.Midterm == existing.Midterm
                    && updated.Final == existing.Final)
                {
                    status = StatusNoChange;
                    color = Color.DimGray;
                    unchanged++;
                }
                else
                {
                    status = StatusUpdate + Describe(existing, updated);
                    color = Color.DarkGreen;
                    pendingChanges.Add(updated);
                }
            }

            int index = dgvPreview.Rows.Add(row.RowNumber, row.StudentCode, name,
                row.Attendance, row.Midterm, row.Final, status);
            dgvPreview.Rows[index].Cells[colStatus.Index].Style.ForeColor = color;
        }

        int missing = current.Keys.Count(code => !seen.Contains(code));
        lblSummary.Text = $"Rows in file: {sheet.Rows.Count}   To update: {pendingChanges.Count}   "
            + $"No change: {unchanged}   Skipped: {skipped}   Students of the class not in the file: {missing}";
        btnImport.Enabled = pendingChanges.Count > 0;
    }

    private decimal? Pick(int column, decimal? fromFile, decimal? currentScore)
    {
        if (column < 0)
        {
            return currentScore;
        }
        return fromFile ?? (chkKeepEmpty.Checked ? currentScore : null);
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

    private void btnImport_Click(object? sender, EventArgs e)
    {
        if (SelectedCourse is not CourseInfo course || pendingChanges.Count == 0)
        {
            return;
        }

        if (MessageBox.Show(this, $"Save the new scores of {pendingChanges.Count} student(s) for {course.DisplayName}?",
                "Import scores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            int saved = pendingChanges.Count;
            repository.SaveGrades(course.CourseId, pendingChanges.ToList());
            MessageBox.Show(this, $"Imported scores of {saved} student(s).", "Import scores",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Could not save the scores:\n" + ex.Message, "Save error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        BuildPreview();
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
