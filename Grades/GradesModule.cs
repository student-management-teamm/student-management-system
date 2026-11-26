namespace StudentManagementWinForms.Grades;

public static class GradesModule
{
    /// <summary>
    /// Grades are stored in MySQL. Use InMemoryGradeRepository to test the forms without a database.
    /// </summary>
    public static IGradeRepository Repository { get; set; } = new MySqlGradeRepository();

    public static void ShowHome(IWin32Window? owner = null)
    {
        using FormGradesHome form = new();
        form.ShowDialog(owner);
    }

    public static void ShowGradeEntry(IWin32Window? owner = null)
    {
        if (!CanConnect(owner))
        {
            return;
        }

        using FormGradeEntry form = new(Repository);
        form.ShowDialog(owner);
    }

    public static void ShowStudentGrades(IWin32Window? owner = null)
    {
        if (!CanConnect(owner))
        {
            return;
        }

        using FormStudentGrades form = new(Repository);
        form.ShowDialog(owner);
    }

    private static bool CanConnect(IWin32Window? owner)
    {
        try
        {
            Repository.GetCourses();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(owner,
                "Could not load grades from the database.\n" + ex.Message +
                "\n\nCheck the STUDENT_DB_CONNECTION environment variable and run database/grades.sql.",
                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
