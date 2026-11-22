namespace StudentManagementWinForms.Grades;

public class InMemoryGradeRepository : IGradeRepository
{
    private readonly List<StudentInfo> students = new()
    {
        new StudentInfo { StudentId = 1, StudentCode = "SV001", FullName = "Nguyễn Văn An" },
        new StudentInfo { StudentId = 2, StudentCode = "SV002", FullName = "Trần Thị Bình" },
        new StudentInfo { StudentId = 3, StudentCode = "SV003", FullName = "Lê Minh Châu" },
        new StudentInfo { StudentId = 4, StudentCode = "SV004", FullName = "Phạm Quốc Dũng" },
        new StudentInfo { StudentId = 5, StudentCode = "SV005", FullName = "Hoàng Thu Hà" }
    };

    private readonly List<CourseInfo> courses = new()
    {
        new CourseInfo { CourseId = 1, CourseCode = "IT101", CourseName = "C# Programming", Credits = 3 },
        new CourseInfo { CourseId = 2, CourseCode = "IT102", CourseName = "Database Systems", Credits = 3 },
        new CourseInfo { CourseId = 3, CourseCode = "IT103", CourseName = "Software Engineering", Credits = 2 }
    };

    private readonly Dictionary<(int StudentId, int CourseId), (decimal? Attendance, decimal? Midterm, decimal? Final)> scores = new()
    {
        [(1, 1)] = (10m, 8m, 9m),
        [(2, 1)] = (9m, 7m, 6.5m),
        [(3, 1)] = (8m, 5m, 3m),
        [(4, 1)] = (10m, 9m, 8.5m),
        [(1, 2)] = (9m, 7.5m, 8m),
        [(2, 2)] = (10m, 6m, 5m),
        [(5, 2)] = (8m, null, null),
        [(1, 3)] = (10m, 8m, 7m),
        [(4, 3)] = (7m, 4m, 2m)
    };

    public IReadOnlyList<CourseInfo> GetCourses() => courses.ToList();

    public IReadOnlyList<StudentInfo> GetStudents() => students.ToList();

    public IReadOnlyList<CourseGrade> GetGradesByCourse(int courseId)
    {
        CourseInfo course = courses.First(c => c.CourseId == courseId);
        return students.Select(s => Build(s, course)).ToList();
    }

    public IReadOnlyList<CourseGrade> GetGradesByStudent(int studentId)
    {
        StudentInfo student = students.First(s => s.StudentId == studentId);
        return courses.Select(c => Build(student, c)).ToList();
    }

    public void SaveGrades(int courseId, IEnumerable<CourseGrade> grades)
    {
        foreach (CourseGrade grade in grades)
        {
            if (grade.Attendance is decimal a && !GradeRules.IsValidScore(a) ||
                grade.Midterm is decimal m && !GradeRules.IsValidScore(m) ||
                grade.Final is decimal f && !GradeRules.IsValidScore(f))
            {
                throw new ArgumentException($"Invalid score for student {grade.StudentCode}.");
            }

            scores[(grade.StudentId, courseId)] = (grade.Attendance, grade.Midterm, grade.Final);
        }
    }

    private CourseGrade Build(StudentInfo student, CourseInfo course)
    {
        scores.TryGetValue((student.StudentId, course.CourseId), out var score);
        return new CourseGrade
        {
            StudentId = student.StudentId,
            StudentCode = student.StudentCode,
            StudentName = student.FullName,
            CourseId = course.CourseId,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            Credits = course.Credits,
            Attendance = score.Attendance,
            Midterm = score.Midterm,
            Final = score.Final
        };
    }
}
