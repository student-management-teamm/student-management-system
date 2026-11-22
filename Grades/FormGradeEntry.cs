using System.Globalization;

namespace StudentManagementWinForms.Grades;

public partial class FormGradeEntry : Form
{
    private readonly IGradeRepository repository;
    private bool loading;
    private bool hasUnsavedChanges;
    private int currentCourseIndex = -1;

    public FormGradeEntry() : this(GradesModule.Repository)
    {
    }

    public FormGradeEntry(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormGradeEntry_Load(object? sender, EventArgs e)
    {
        lblRule.Text = string.Format(CultureInfo.InvariantCulture,
            "Total = Attendance x {0:0%} + Midterm x {1:0%} + Final x {2:0%}. Pass mark: {3:0.0}. Scores: 0-10, empty = not graded yet.",
            GradeRules.AttendanceWeight, GradeRules.MidtermWeight, GradeRules.FinalWeight, GradeRules.PassMark);

        loading = true;
        cboCourse.DisplayMember = nameof(CourseInfo.DisplayName);
        cboCourse.DataSource = repository.GetCourses().ToList();
        loading = false;

        if (cboCourse.Items.Count > 0)
        {
            cboCourse.SelectedIndex = 0;
            LoadGrades();
        }
    }

    private CourseInfo? SelectedCourse => cboCourse.SelectedItem as CourseInfo;

    private void LoadGrades()
    {
        CourseInfo? course = SelectedCourse;
        dgvGrades.Rows.Clear();
        if (course == null)
        {
            return;
        }

        currentCourseIndex = cboCourse.SelectedIndex;
        lblCredits.Text = $"Credits: {course.Credits}";

        int no = 1;
        foreach (CourseGrade grade in repository.GetGradesByCourse(course.CourseId))
        {
            int rowIndex = dgvGrades.Rows.Add();
            DataGridViewRow row = dgvGrades.Rows[rowIndex];
            row.Tag = grade.Copy();
            row.Cells[colNo.Index].Value = no++;
            row.Cells[colStudentCode.Index].Value = grade.StudentCode;
            row.Cells[colStudentName.Index].Value = grade.StudentName;
            row.Cells[colAttendance.Index].Value = GradeRules.FormatScore(grade.Attendance);
            row.Cells[colMidterm.Index].Value = GradeRules.FormatScore(grade.Midterm);
            row.Cells[colFinal.Index].Value = GradeRules.FormatScore(grade.Final);
            RefreshComputedCells(row);
        }

        hasUnsavedChanges = false;
        UpdateSummary();
    }

    private bool IsScoreColumn(int columnIndex) =>
        columnIndex == colAttendance.Index || columnIndex == colMidterm.Index || columnIndex == colFinal.Index;

    private void RefreshComputedCells(DataGridViewRow row)
    {
        if (row.Tag is not CourseGrade grade)
        {
            return;
        }

        row.Cells[colTotal.Index].Value = GradeRules.FormatScore(grade.TotalScore);
        row.Cells[colLetter.Index].Value = grade.LetterGrade;
        row.Cells[colResult.Index].Value = grade.Result;

        Color color = grade.TotalScore is decimal total && !GradeRules.IsPassed(total)
            ? Color.Firebrick
            : SystemColors.ControlText;
        row.Cells[colResult.Index].Style.ForeColor = color;
    }

    private void UpdateSummary()
    {
        List<CourseGrade> grades = dgvGrades.Rows.Cast<DataGridViewRow>()
            .Select(r => r.Tag).OfType<CourseGrade>().ToList();
        List<decimal> totals = grades.Where(g => g.TotalScore.HasValue).Select(g => g.TotalScore!.Value).ToList();
        int passed = totals.Count(GradeRules.IsPassed);
        string average = totals.Count == 0 ? "-" : Math.Round(totals.Average(), 2).ToString("0.00", CultureInfo.InvariantCulture);

        lblSummary.Text = $"Students: {grades.Count}   Graded: {totals.Count}   Passed: {passed}"
            + $"   Failed: {totals.Count - passed}   Average total: {average}"
            + (hasUnsavedChanges ? "   (unsaved changes)" : "");
    }

    private void dgvGrades_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (!IsScoreColumn(e.ColumnIndex))
        {
            return;
        }

        if (!GradeRules.TryParseScore(Convert.ToString(e.FormattedValue), out _))
        {
            dgvGrades.Rows[e.RowIndex].ErrorText = "Score must be a number from 0 to 10 (at most 2 decimals).";
            e.Cancel = true;
        }
    }

    private void dgvGrades_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        DataGridViewRow row = dgvGrades.Rows[e.RowIndex];
        row.ErrorText = "";
        if (!IsScoreColumn(e.ColumnIndex) || row.Tag is not CourseGrade grade)
        {
            return;
        }

        GradeRules.TryParseScore(Convert.ToString(row.Cells[e.ColumnIndex].Value), out decimal? score);
        row.Cells[e.ColumnIndex].Value = GradeRules.FormatScore(score);

        if (e.ColumnIndex == colAttendance.Index)
        {
            grade.Attendance = score;
        }
        else if (e.ColumnIndex == colMidterm.Index)
        {
            grade.Midterm = score;
        }
        else
        {
            grade.Final = score;
        }

        RefreshComputedCells(row);
        hasUnsavedChanges = true;
        UpdateSummary();
    }

    private bool SaveGrades()
    {
        CourseInfo? course = SelectedCourse;
        if (course == null)
        {
            return false;
        }

        if (!dgvGrades.EndEdit())
        {
            MessageBox.Show("Please fix the invalid score before saving.", "Invalid score",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        List<CourseGrade> grades = dgvGrades.Rows.Cast<DataGridViewRow>()
            .Select(r => r.Tag).OfType<CourseGrade>().ToList();

        try
        {
            repository.SaveGrades(course.CourseId, grades);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not save grades:\n" + ex.Message, "Save error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        hasUnsavedChanges = false;
        UpdateSummary();
        return true;
    }

    private bool ConfirmLeave()
    {
        dgvGrades.EndEdit();
        if (!hasUnsavedChanges)
        {
            return true;
        }

        DialogResult answer = MessageBox.Show("Save changes to the current course before leaving?",
            "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        return answer switch
        {
            DialogResult.Yes => SaveGrades(),
            DialogResult.No => true,
            _ => false
        };
    }

    private void cboCourse_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (loading || cboCourse.SelectedIndex == currentCourseIndex)
        {
            return;
        }

        if (!ConfirmLeave())
        {
            loading = true;
            cboCourse.SelectedIndex = currentCourseIndex;
            loading = false;
            return;
        }

        LoadGrades();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (SaveGrades())
        {
            MessageBox.Show("Grades saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnReload_Click(object? sender, EventArgs e)
    {
        dgvGrades.CancelEdit();
        if (hasUnsavedChanges &&
            MessageBox.Show("Discard unsaved changes and reload?", "Reload",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        LoadGrades();
    }

    private void FormGradeEntry_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!ConfirmLeave())
        {
            e.Cancel = true;
        }
    }
}
