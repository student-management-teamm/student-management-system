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
}
