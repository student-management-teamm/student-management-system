namespace StudentManagementWinForms.Grades;

public interface IGradeRepository
{
    IReadOnlyList<CourseInfo> GetCourses();
    IReadOnlyList<StudentInfo> GetStudents();
    IReadOnlyList<CourseGrade> GetGradesByCourse(int courseId);
    IReadOnlyList<CourseGrade> GetGradesByStudent(int studentId);
    void SaveGrades(int courseId, IEnumerable<CourseGrade> grades);
}
