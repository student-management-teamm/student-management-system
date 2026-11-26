using System.Globalization;

namespace StudentManagementWinForms.Grades;

/// <summary>
/// Part 4 extension: search and filter all grades by class, course, result, letter grade,
/// total score range and student code or name.
/// </summary>
public partial class FormGradeFilter : Form
{
    private const string AllClasses = "(All classes)";
    private const string AllOption = "(All)";

    private readonly IGradeRepository repository;
    private List<CourseGrade> allGrades = new();
    private bool loading;

    public FormGradeFilter() : this(GradesModule.Repository)
    {
    }

    public FormGradeFilter(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormGradeFilter_Load(object? sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        allGrades = repository.GetAllGrades().ToList();

        loading = true;
        string? previousClass = cboClass.SelectedItem as string;
        cboClass.Items.Clear();
        cboClass.Items.Add(AllClasses);
        foreach (string className in allGrades.Select(g => g.ClassName).Distinct().OrderBy(n => n))
        {
            cboClass.Items.Add(className);
        }
        cboClass.SelectedItem = previousClass != null && cboClass.Items.Contains(previousClass) ? previousClass : AllClasses;

        if (cboResult.Items.Count == 0)
        {
            cboResult.Items.AddRange(new object[] { AllOption, "Passed", "Failed", "Not graded" });
            cboResult.SelectedIndex = 0;
            cboLetter.Items.Add(AllOption);
            cboLetter.Items.AddRange(new object[] { "A", "B+", "B", "C+", "C", "D+", "D", "F" });
            cboLetter.SelectedIndex = 0;
        }
        loading = false;

        FillCourses();
        ApplyFilter();
    }

    private string? SelectedClassName =>
        cboClass.SelectedItem is string name && name != AllClasses ? name : null;

    private void FillCourses()
    {
        int previousCourseId = (cboCourse.SelectedItem as CourseInfo)?.CourseId ?? 0;
        string? className = SelectedClassName;

        List<CourseInfo> courses = allGrades
            .Where(g => className == null || g.ClassName == className)
            .GroupBy(g => g.CourseId)
            .Select(group => new CourseInfo
            {
                CourseId = group.Key,
                CourseCode = group.First().CourseCode,
                CourseName = group.First().CourseName,
                Credits = group.First().Credits
            })
            .OrderBy(c => c.CourseCode)
            .ToList();
        courses.Insert(0, new CourseInfo { CourseId = 0, CourseCode = AllOption, CourseName = "all courses" });

        loading = true;
        cboCourse.DisplayMember = nameof(CourseInfo.DisplayName);
        cboCourse.DataSource = courses;
        CourseInfo? previous = courses.FirstOrDefault(c => c.CourseId == previousCourseId);
        cboCourse.SelectedItem = previous ?? courses[0];
        loading = false;
    }

    private IEnumerable<CourseGrade> FilteredGrades()
    {
        string? className = SelectedClassName;
        int courseId = (cboCourse.SelectedItem as CourseInfo)?.CourseId ?? 0;
        string result = cboResult.SelectedItem as string ?? AllOption;
        string letter = cboLetter.SelectedItem as string ?? AllOption;
        string search = txtSearch.Text.Trim();
        decimal minTotal = nudMinTotal.Value;
        decimal maxTotal = nudMaxTotal.Value;
        bool rangeActive = minTotal > GradeRules.MinScore || maxTotal < GradeRules.MaxScore;

        return allGrades.Where(g =>
            (className == null || g.ClassName == className) &&
            (courseId == 0 || g.CourseId == courseId) &&
            (result == AllOption || g.Result == result) &&
            (letter == AllOption || g.LetterGrade == letter) &&
            (!rangeActive || g.TotalScore is decimal total && total >= minTotal && total <= maxTotal) &&
            (search.Length == 0 ||
             g.StudentCode.Contains(search, StringComparison.OrdinalIgnoreCase) ||
             g.StudentName.Contains(search, StringComparison.OrdinalIgnoreCase)));
    }

    private void ApplyFilter()
    {
        if (loading)
        {
            return;
        }

        List<CourseGrade> rows = FilteredGrades().ToList();

        dgvGrades.SuspendLayout();
        dgvGrades.Rows.Clear();
        foreach (CourseGrade grade in rows)
        {
            int rowIndex = dgvGrades.Rows.Add(
                grade.ClassName,
                grade.StudentCode,
                grade.StudentName,
                grade.CourseCode,
                grade.CourseName,
                grade.Credits,
                grade.Attendance,
                grade.Midterm,
                grade.Final,
                grade.TotalScore,
                grade.LetterGrade,
                grade.Result);

            if (grade.TotalScore is decimal total && !GradeRules.IsPassed(total))
            {
                dgvGrades.Rows[rowIndex].Cells[colResult.Index].Style.ForeColor = Color.Firebrick;
            }
        }
        dgvGrades.ResumeLayout();

        List<decimal> totals = rows.Where(g => g.TotalScore.HasValue).Select(g => g.TotalScore!.Value).ToList();
        int passed = totals.Count(GradeRules.IsPassed);
        string passRate = totals.Count == 0 ? "-" : (100m * passed / totals.Count).ToString("0.0", CultureInfo.InvariantCulture) + "%";
        string average = totals.Count == 0 ? "-" : Math.Round(totals.Average(), 2).ToString("0.00", CultureInfo.InvariantCulture);

        lblSummary.Text = $"Rows: {rows.Count}   Graded: {totals.Count}   Passed: {passed}   Failed: {totals.Count - passed}"
            + $"   Not graded: {rows.Count - totals.Count}   Pass rate: {passRate}   Average total: {average}";
    }

    private void cboClass_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (loading)
        {
            return;
        }

        FillCourses();
        ApplyFilter();
    }

    private void Filter_Changed(object? sender, EventArgs e)
    {
        ApplyFilter();
    }

    private void TotalRange_Changed(object? sender, EventArgs e)
    {
        if (nudMinTotal.Value > nudMaxTotal.Value)
        {
            if (sender == nudMinTotal)
            {
                nudMaxTotal.Value = nudMinTotal.Value;
            }
            else
            {
                nudMinTotal.Value = nudMaxTotal.Value;
            }
        }

        ApplyFilter();
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        loading = true;
        cboClass.SelectedItem = AllClasses;
        cboResult.SelectedIndex = 0;
        cboLetter.SelectedIndex = 0;
        txtSearch.Text = "";
        nudMinTotal.Value = GradeRules.MinScore;
        nudMaxTotal.Value = GradeRules.MaxScore;
        loading = false;

        FillCourses();
        loading = true;
        cboCourse.SelectedIndex = 0;
        loading = false;
        ApplyFilter();
    }

    private void btnReload_Click(object? sender, EventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not reload grades:\n" + ex.Message, "Database error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
