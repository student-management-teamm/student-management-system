using System.Globalization;

namespace StudentManagementWinForms.Grades;

/// <summary>
/// Part 4 extension: for students who have attendance and midterm scores but no final exam
/// score yet, shows the lowest final score they need to pass, or to reach C, B or A.
/// </summary>
public partial class FormFinalScoreNeeded : Form
{
    private readonly IGradeRepository repository;
    private bool loading;

    public FormFinalScoreNeeded() : this(GradesModule.Repository)
    {
    }

    public FormFinalScoreNeeded(IGradeRepository repository)
    {
        this.repository = repository;
        InitializeComponent();
    }

    private void FormFinalScoreNeeded_Load(object? sender, EventArgs e)
    {
        lblHelp.Text = string.Format(CultureInfo.InvariantCulture,
            "Lowest final exam score (steps of 0.1) each student needs. Total = Attendance x {0:0%} + Midterm x {1:0%} + Final x {2:0%}, rounded to 0.1.",
            GradeRules.AttendanceWeight, GradeRules.MidtermWeight, GradeRules.FinalWeight);

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
        List<CourseInfo> courses = SelectedClass is ClassInfo cls
            ? repository.GetCoursesByClass(cls.ClassId).ToList()
            : new List<CourseInfo>();
        cboCourse.DataSource = courses;
        loading = false;
        LoadNeeded();
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
            LoadNeeded();
        }
    }

    private void LoadNeeded()
    {
        dgvNeeded.Rows.Clear();
        if (SelectedClass is not ClassInfo cls || SelectedCourse is not CourseInfo course)
        {
            lblSummary.Text = "";
            return;
        }

        DataGridViewColumn[] targetColumns = { colPass, colC, colB, colA };
        int waiting = 0, alreadyGraded = 0, missingScores = 0, cannotPass = 0;

        foreach (CourseGrade grade in repository.GetGradesByClassAndCourse(cls.ClassId, course.CourseId))
        {
            int index = dgvNeeded.Rows.Add(grade.StudentCode, grade.StudentName,
                grade.Attendance, grade.Midterm, grade.Final);
            DataGridViewRow row = dgvNeeded.Rows[index];

            if (grade.HasAllScores)
            {
                alreadyGraded++;
                row.Cells[colNote.Index].Value = $"Final already entered: total {GradeRules.FormatScore(grade.TotalScore)}, {grade.LetterGrade}";
                row.DefaultCellStyle.ForeColor = Color.DimGray;
                continue;
            }

            if (grade.Attendance is not decimal attendance || grade.Midterm is not decimal midterm)
            {
                missingScores++;
                row.Cells[colNote.Index].Value = "Attendance or midterm score missing";
                row.DefaultCellStyle.ForeColor = Color.DimGray;
                continue;
            }

            waiting++;
            for (int i = 0; i < GradeRules.FinalScoreTargets.Length; i++)
            {
                decimal? needed = GradeRules.MinimumFinalScore(attendance, midterm, GradeRules.FinalScoreTargets[i].MinTotal);
                DataGridViewCell cell = row.Cells[targetColumns[i].Index];
                cell.Value = needed is decimal value ? value.ToString("0.0", CultureInfo.InvariantCulture) : "Not possible";
                cell.Style.ForeColor = needed is null ? Color.Firebrick
                    : needed > 8m ? Color.DarkOrange
                    : Color.DarkGreen;
            }

            decimal? toPass = GradeRules.MinimumFinalScore(attendance, midterm, GradeRules.PassMark);
            if (toPass is null)
            {
                cannotPass++;
                row.Cells[colNote.Index].Value = "Cannot pass even with 10 in the final exam";
                row.Cells[colNote.Index].Style.ForeColor = Color.Firebrick;
            }
            else if (toPass == 0m)
            {
                row.Cells[colNote.Index].Value = "Passes with any final score";
            }
            else if (toPass > 8m)
            {
                row.Cells[colNote.Index].Value = "At risk: needs a high final score to pass";
                row.Cells[colNote.Index].Style.ForeColor = Color.DarkOrange;
            }
        }

        lblSummary.Text = $"Waiting for the final exam: {waiting}   Cannot pass: {cannotPass}   "
            + $"Final already entered: {alreadyGraded}   Missing attendance or midterm: {missingScores}";
    }
}
