namespace StudentManagementWinForms.Grades;

public static class GradesModule
{
    public static IGradeRepository Repository { get; set; } = new InMemoryGradeRepository();

    public static void ShowHome(IWin32Window? owner = null)
    {
        using FormGradesHome form = new();
        form.ShowDialog(owner);
    }

    public static void ShowGradeEntry(IWin32Window? owner = null)
    {
        using FormGradeEntry form = new(Repository);
        form.ShowDialog(owner);
    }

    public static void ShowStudentGrades(IWin32Window? owner = null)
    {
        using FormStudentGrades form = new(Repository);
        form.ShowDialog(owner);
    }
}
