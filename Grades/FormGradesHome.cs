namespace StudentManagementWinForms.Grades;

public partial class FormGradesHome : Form
{
    public FormGradesHome()
    {
        InitializeComponent();
    }

    private void btnGradeEntry_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowGradeEntry(this);
    }

    private void btnStudentGrades_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowStudentGrades(this);
    }

    private void btnGradeFilter_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowGradeFilter(this);
    }

    private void btnGradeImport_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowGradeImport(this);
    }

    private void btnFinalNeeded_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowFinalScoreNeeded(this);
    }

    private void btnAcademicWarning_Click(object? sender, EventArgs e)
    {
        GradesModule.ShowAcademicWarning(this);
    }
}
