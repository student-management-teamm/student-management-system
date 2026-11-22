using System.Globalization;

namespace StudentManagementWinForms.Grades;

public partial class FormStudentGrades : Form
{
    private readonly IGradeRepository repository;

    public FormStudentGrades() : this(GradesModule.Repository)
    {
    }

    public FormStudentGrades(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormStudentGrades_Load(object? sender, EventArgs e)
    {
        cboStudent.DisplayMember = nameof(StudentInfo.DisplayName);
        cboStudent.DataSource = repository.GetStudents().ToList();
        LoadTranscript();
    }

    private void cboStudent_SelectedIndexChanged(object? sender, EventArgs e)
    {
        LoadTranscript();
    }

    private void LoadTranscript()
    {
        dgvTranscript.Rows.Clear();
        if (cboStudent.SelectedItem is not StudentInfo student)
        {
            return;
        }

        List<CourseGrade> grades = repository.GetGradesByStudent(student.StudentId).ToList();
        foreach (CourseGrade grade in grades)
        {
            int rowIndex = dgvTranscript.Rows.Add(
                grade.CourseCode,
                grade.CourseName,
                grade.Credits,
                GradeRules.FormatScore(grade.Attendance),
                GradeRules.FormatScore(grade.Midterm),
                GradeRules.FormatScore(grade.Final),
                GradeRules.FormatScore(grade.TotalScore),
                grade.LetterGrade,
                grade.HasAllScores ? grade.GradePoint.ToString("0.0", CultureInfo.InvariantCulture) : "",
                grade.Result);

            if (grade.TotalScore is decimal total && !GradeRules.IsPassed(total))
            {
                dgvTranscript.Rows[rowIndex].Cells[colResult.Index].Style.ForeColor = Color.Firebrick;
            }
        }

        bool anyGraded = grades.Any(g => g.HasAllScores);
        decimal gpa = GradeRules.Gpa(grades);
        int attempted = grades.Where(g => g.HasAllScores).Sum(g => g.Credits);
        int earned = GradeRules.EarnedCredits(grades);

        lblGpa.Text = anyGraded ? "GPA (4-point scale): " + gpa.ToString("0.00", CultureInfo.InvariantCulture) : "GPA (4-point scale): -";
        lblClassification.Text = anyGraded ? $"Classification: {GradeRules.Classification(gpa)}" : "Classification: -";
        lblCredits.Text = $"Credits graded: {attempted}   Credits earned: {earned}";
    }
}
