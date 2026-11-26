using System.Globalization;

namespace StudentManagementWinForms.Grades;

/// <summary>
/// Part 4 extension: lists students whose results call for an academic warning
/// (low GPA or too many failed credits), level 2 being the more serious one.
/// </summary>
public partial class FormAcademicWarning : Form
{
    private const string AllClasses = "(All classes)";
    private const string ShowWarnings = "Students with a warning";
    private const string ShowLevel2 = "Level 2 only";
    private const string ShowLevel1 = "Level 1 only";
    private const string ShowAll = "All students";

    private sealed record StudentResult(string ClassName, string StudentCode, string StudentName,
        int GradedCredits, int FailedCredits, decimal Gpa, int Level, string Reason);

    private readonly IGradeRepository repository;
    private List<StudentResult> results = new();
    private bool loading;

    public FormAcademicWarning() : this(GradesModule.Repository)
    {
    }

    public FormAcademicWarning(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormAcademicWarning_Load(object? sender, EventArgs e)
    {
        lblRule.Text = string.Format(CultureInfo.InvariantCulture,
            "Level 2: GPA below {0:0.0} or failed at least {1:0%} of graded credits.   Level 1: GPA below {2:0.0} or failed {3} credits or more.",
            GradeRules.WarningLevel2Gpa, GradeRules.WarningLevel2FailedShare, GradeRules.WarningLevel1Gpa,
            GradeRules.WarningLevel1FailedCredits);

        loading = true;
        cboLevel.Items.AddRange(new object[] { ShowWarnings, ShowLevel2, ShowLevel1, ShowAll });
        cboLevel.SelectedIndex = 0;
        loading = false;
        LoadData();
    }

    private void LoadData()
    {
        results = repository.GetAllGrades()
            .GroupBy(g => g.StudentId)
            .Select(group =>
            {
                List<CourseGrade> grades = group.ToList();
                List<CourseGrade> graded = grades.Where(g => g.HasAllScores).ToList();
                int gradedCredits = graded.Sum(g => g.Credits);
                int failedCredits = graded.Where(g => !GradeRules.IsPassed(g.TotalScore!.Value)).Sum(g => g.Credits);
                decimal gpa = GradeRules.Gpa(graded);
                int level = GradeRules.AcademicWarningLevel(gpa, gradedCredits, failedCredits, out string reason);
                CourseGrade first = grades[0];
                return new StudentResult(first.ClassName, first.StudentCode, first.StudentName,
                    gradedCredits, failedCredits, gpa, level, reason);
            })
            .Where(r => r.GradedCredits > 0)
            .OrderByDescending(r => r.Level).ThenBy(r => r.Gpa).ThenBy(r => r.StudentCode)
            .ToList();

        loading = true;
        string? previous = cboClass.SelectedItem as string;
        cboClass.Items.Clear();
        cboClass.Items.Add(AllClasses);
        foreach (string className in results.Select(r => r.ClassName).Distinct().OrderBy(n => n))
        {
            cboClass.Items.Add(className);
        }
        cboClass.SelectedItem = previous != null && cboClass.Items.Contains(previous) ? previous : AllClasses;
        loading = false;

        ShowResults();
    }

    private void ShowResults()
    {
        string className = cboClass.SelectedItem as string ?? AllClasses;
        string show = cboLevel.SelectedItem as string ?? ShowWarnings;

        List<StudentResult> inClass = results
            .Where(r => className == AllClasses || r.ClassName == className)
            .ToList();
        List<StudentResult> rows = inClass.Where(r => show switch
        {
            ShowLevel2 => r.Level == 2,
            ShowLevel1 => r.Level == 1,
            ShowAll => true,
            _ => r.Level > 0
        }).ToList();

        dgvWarnings.Rows.Clear();
        foreach (StudentResult r in rows)
        {
            int index = dgvWarnings.Rows.Add(r.ClassName, r.StudentCode, r.StudentName, r.GradedCredits,
                r.FailedCredits, r.Gpa, GradeRules.Classification(r.Gpa),
                r.Level == 0 ? "None" : $"Level {r.Level}", r.Reason);

            if (r.Level == 2)
            {
                dgvWarnings.Rows[index].DefaultCellStyle.BackColor = Color.MistyRose;
            }
            else if (r.Level == 1)
            {
                dgvWarnings.Rows[index].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
        }

        lblSummary.Text = $"Students with grades: {inClass.Count}   Level 2: {inClass.Count(r => r.Level == 2)}   "
            + $"Level 1: {inClass.Count(r => r.Level == 1)}   No warning: {inClass.Count(r => r.Level == 0)}";
    }

    private void Filter_Changed(object? sender, EventArgs e)
    {
        if (!loading)
        {
            ShowResults();
        }
    }

    private void btnReload_Click(object? sender, EventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Could not reload grades:\n" + ex.Message, "Database error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
