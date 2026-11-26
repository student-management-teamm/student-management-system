namespace StudentManagementWinForms.Grades;

public interface IGradeRepository
{
    IReadOnlyList<ClassInfo> GetClasses();
    IReadOnlyList<CourseInfo> GetCourses();
    IReadOnlyList<CourseInfo> GetCoursesByClass(int classId);
    IReadOnlyList<StudentInfo> GetStudents();
    IReadOnlyList<CourseGrade> GetGradesByCourse(int courseId);
    IReadOnlyList<CourseGrade> GetGradesByClassAndCourse(int classId, int courseId);
    IReadOnlyList<CourseGrade> GetGradesByStudent(int studentId);

    /// <summary>Every student in every course of their class (graded or not), for filtering.</summary>
    IReadOnlyList<CourseGrade> GetAllGrades();

    void SaveGrades(int courseId, IEnumerable<CourseGrade> grades);
}
