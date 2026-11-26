using MySql.Data.MySqlClient;
using StudentManagementWinForms.Data;

namespace StudentManagementWinForms.Grades;

/// <summary>
/// Reads and writes grades in the MySQL database (tables students, subjects,
/// classsubjects and grades - see database/grades.sql).
/// </summary>
public class MySqlGradeRepository : IGradeRepository
{
    public IReadOnlyList<CourseInfo> GetCourses()
    {
        const string sql = @"
            SELECT sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits
            FROM subjects sub
            WHERE EXISTS (SELECT 1 FROM classsubjects cs WHERE cs.SubjectID = sub.SubjectID)
            ORDER BY EXISTS (SELECT 1 FROM grades g WHERE g.SubjectID = sub.SubjectID) DESC, sub.SubjectCode;";

        List<CourseInfo> courses = new();
        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            courses.Add(new CourseInfo
            {
                CourseId = reader.GetInt32("SubjectID"),
                CourseCode = reader.GetString("SubjectCode"),
                CourseName = reader.GetString("SubjectName"),
                Credits = reader.GetInt32("Credits")
            });
        }
        return courses;
    }

    public IReadOnlyList<ClassInfo> GetClasses()
    {
        const string sql = @"
            SELECT c.ClassID, c.ClassName
            FROM classes c
            WHERE EXISTS (SELECT 1 FROM classsubjects cs WHERE cs.ClassID = c.ClassID)
            ORDER BY c.ClassName;";

        List<ClassInfo> classes = new();
        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            classes.Add(new ClassInfo
            {
                ClassId = reader.GetInt32("ClassID"),
                ClassName = reader.GetString("ClassName")
            });
        }
        return classes;
    }

    public IReadOnlyList<CourseInfo> GetCoursesByClass(int classId)
    {
        const string sql = @"
            SELECT sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits
            FROM classsubjects cs
            JOIN subjects sub ON sub.SubjectID = cs.SubjectID
            WHERE cs.ClassID = @classId
            ORDER BY sub.SubjectCode;";

        List<CourseInfo> courses = new();
        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@classId", classId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            courses.Add(new CourseInfo
            {
                CourseId = reader.GetInt32("SubjectID"),
                CourseCode = reader.GetString("SubjectCode"),
                CourseName = reader.GetString("SubjectName"),
                Credits = reader.GetInt32("Credits")
            });
        }
        return courses;
    }

    public IReadOnlyList<StudentInfo> GetStudents()
    {
        const string sql = @"
            SELECT StudentID, StudentCode, CONCAT(LastName, ' ', FirstName) AS FullName
            FROM students
            ORDER BY StudentID;";

        List<StudentInfo> students = new();
        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            students.Add(new StudentInfo
            {
                StudentId = reader.GetInt32("StudentID"),
                StudentCode = reader.GetString("StudentCode"),
                FullName = reader.GetString("FullName")
            });
        }
        return students;
    }

    /// <summary>All students of the classes that study the course, with their scores (if any).</summary>
    public IReadOnlyList<CourseGrade> GetGradesByCourse(int courseId)
    {
        const string sql = @"
            SELECT s.StudentID, s.StudentCode, CONCAT(s.LastName, ' ', s.FirstName) AS FullName,
                   IFNULL(c.ClassName, '') AS ClassName,
                   sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits,
                   g.AttendanceScore, g.MidtermScore, g.FinalScore
            FROM subjects sub
            JOIN students s
              ON s.ClassID IN (SELECT cs.ClassID FROM classsubjects cs WHERE cs.SubjectID = sub.SubjectID)
              OR EXISTS (SELECT 1 FROM grades x WHERE x.SubjectID = sub.SubjectID AND x.StudentID = s.StudentID)
            LEFT JOIN grades g ON g.SubjectID = sub.SubjectID AND g.StudentID = s.StudentID
            LEFT JOIN classes c ON c.ClassID = s.ClassID
            WHERE sub.SubjectID = @courseId
            ORDER BY s.StudentID;";

        return ReadGrades(sql, "@courseId", courseId);
    }

    /// <summary>
    /// Students of one class in one course. Students from other classes who have scores in the
    /// course (for example retaking it) are listed too when their own class does not study it.
    /// </summary>
    public IReadOnlyList<CourseGrade> GetGradesByClassAndCourse(int classId, int courseId)
    {
        const string sql = @"
            SELECT s.StudentID, s.StudentCode, CONCAT(s.LastName, ' ', s.FirstName) AS FullName,
                   IFNULL(c.ClassName, '') AS ClassName,
                   sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits,
                   g.AttendanceScore, g.MidtermScore, g.FinalScore
            FROM subjects sub
            JOIN students s
              ON s.ClassID = @classId
              OR (EXISTS (SELECT 1 FROM grades x WHERE x.SubjectID = sub.SubjectID AND x.StudentID = s.StudentID)
                  AND NOT EXISTS (SELECT 1 FROM classsubjects y WHERE y.SubjectID = sub.SubjectID AND y.ClassID = s.ClassID))
            LEFT JOIN grades g ON g.SubjectID = sub.SubjectID AND g.StudentID = s.StudentID
            LEFT JOIN classes c ON c.ClassID = s.ClassID
            WHERE sub.SubjectID = @courseId
            ORDER BY s.ClassID = @classId DESC, s.StudentID;";

        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@classId", classId);
        command.Parameters.AddWithValue("@courseId", courseId);
        return ReadGrades(command);
    }

    public IReadOnlyList<CourseGrade> GetAllGrades()
    {
        const string sql = @"
            SELECT s.StudentID, s.StudentCode, CONCAT(s.LastName, ' ', s.FirstName) AS FullName,
                   IFNULL(c.ClassName, '') AS ClassName,
                   sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits,
                   g.AttendanceScore, g.MidtermScore, g.FinalScore
            FROM students s
            JOIN subjects sub
              ON sub.SubjectID IN (SELECT cs.SubjectID FROM classsubjects cs WHERE cs.ClassID = s.ClassID)
              OR EXISTS (SELECT 1 FROM grades x WHERE x.SubjectID = sub.SubjectID AND x.StudentID = s.StudentID)
            LEFT JOIN grades g ON g.SubjectID = sub.SubjectID AND g.StudentID = s.StudentID
            LEFT JOIN classes c ON c.ClassID = s.ClassID
            ORDER BY c.ClassName, s.StudentID, sub.SubjectCode;";

        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        return ReadGrades(command);
    }

    /// <summary>All courses of the student's class plus any other course the student has scores in.</summary>
    public IReadOnlyList<CourseGrade> GetGradesByStudent(int studentId)
    {
        const string sql = @"
            SELECT s.StudentID, s.StudentCode, CONCAT(s.LastName, ' ', s.FirstName) AS FullName,
                   IFNULL(c.ClassName, '') AS ClassName,
                   sub.SubjectID, sub.SubjectCode, sub.SubjectName, IFNULL(sub.Credits, 0) AS Credits,
                   g.AttendanceScore, g.MidtermScore, g.FinalScore
            FROM students s
            JOIN subjects sub
              ON sub.SubjectID IN (SELECT cs.SubjectID FROM classsubjects cs WHERE cs.ClassID = s.ClassID)
              OR EXISTS (SELECT 1 FROM grades x WHERE x.SubjectID = sub.SubjectID AND x.StudentID = s.StudentID)
            LEFT JOIN grades g ON g.SubjectID = sub.SubjectID AND g.StudentID = s.StudentID
            LEFT JOIN classes c ON c.ClassID = s.ClassID
            WHERE s.StudentID = @studentId
            ORDER BY sub.SubjectCode;";

        return ReadGrades(sql, "@studentId", studentId);
    }

    public void SaveGrades(int courseId, IEnumerable<CourseGrade> grades)
    {
        const string upsertSql = @"
            INSERT INTO grades (StudentID, SubjectID, AttendanceScore, MidtermScore, FinalScore)
            VALUES (@studentId, @courseId, @attendance, @midterm, @final)
            ON DUPLICATE KEY UPDATE
                AttendanceScore = VALUES(AttendanceScore),
                MidtermScore = VALUES(MidtermScore),
                FinalScore = VALUES(FinalScore);";
        const string deleteSql = "DELETE FROM grades WHERE StudentID = @studentId AND SubjectID = @courseId;";

        using MySqlConnection connection = Open();
        using MySqlTransaction transaction = connection.BeginTransaction();
        foreach (CourseGrade grade in grades)
        {
            if (grade.Attendance is decimal a && !GradeRules.IsValidScore(a) ||
                grade.Midterm is decimal m && !GradeRules.IsValidScore(m) ||
                grade.Final is decimal f && !GradeRules.IsValidScore(f))
            {
                throw new ArgumentException($"Invalid score for student {grade.StudentCode}.");
            }

            bool empty = grade.Attendance == null && grade.Midterm == null && grade.Final == null;
            using MySqlCommand command = new(empty ? deleteSql : upsertSql, connection, transaction);
            command.Parameters.AddWithValue("@studentId", grade.StudentId);
            command.Parameters.AddWithValue("@courseId", courseId);
            if (!empty)
            {
                command.Parameters.AddWithValue("@attendance", (object?)grade.Attendance ?? DBNull.Value);
                command.Parameters.AddWithValue("@midterm", (object?)grade.Midterm ?? DBNull.Value);
                command.Parameters.AddWithValue("@final", (object?)grade.Final ?? DBNull.Value);
            }
            command.ExecuteNonQuery();
        }
        transaction.Commit();
    }

    private static MySqlConnection Open()
    {
        MySqlConnection connection = Database.CreateConnection();
        connection.Open();
        return connection;
    }

    private static List<CourseGrade> ReadGrades(string sql, string parameterName, int value)
    {
        using MySqlConnection connection = Open();
        using MySqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue(parameterName, value);
        return ReadGrades(command);
    }

    private static List<CourseGrade> ReadGrades(MySqlCommand command)
    {
        List<CourseGrade> grades = new();
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            grades.Add(new CourseGrade
            {
                StudentId = reader.GetInt32("StudentID"),
                StudentCode = reader.GetString("StudentCode"),
                StudentName = reader.GetString("FullName"),
                ClassName = reader.GetString("ClassName"),
                CourseId = reader.GetInt32("SubjectID"),
                CourseCode = reader.GetString("SubjectCode"),
                CourseName = reader.GetString("SubjectName"),
                Credits = reader.GetInt32("Credits"),
                Attendance = ReadScore(reader, "AttendanceScore"),
                Midterm = ReadScore(reader, "MidtermScore"),
                Final = ReadScore(reader, "FinalScore")
            });
        }
        return grades;
    }

    private static decimal? ReadScore(MySqlDataReader reader, string column)
    {
        int ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? null : reader.GetDecimal(ordinal);
    }
}
