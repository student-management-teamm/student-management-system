namespace StudentManagementWinForms.Grades;

public class StudentInfo
{
    public int StudentId { get; set; }
    public string StudentCode { get; set; } = "";
    public string FullName { get; set; } = "";

    public string DisplayName => $"{StudentCode} - {FullName}";
}

public class CourseInfo
{
    public int CourseId { get; set; }
    public string CourseCode { get; set; } = "";
    public string CourseName { get; set; } = "";
    public int Credits { get; set; }

    public string DisplayName => $"{CourseCode} - {CourseName}";
}

public class CourseGrade
{
    public int StudentId { get; set; }
    public string StudentCode { get; set; } = "";
    public string StudentName { get; set; } = "";
    public int CourseId { get; set; }
    public string CourseCode { get; set; } = "";
    public string CourseName { get; set; } = "";
    public int Credits { get; set; }
    public decimal? Attendance { get; set; }
    public decimal? Midterm { get; set; }
    public decimal? Final { get; set; }

    public bool HasAllScores => Attendance.HasValue && Midterm.HasValue && Final.HasValue;

    public decimal? TotalScore =>
        HasAllScores ? GradeRules.TotalScore(Attendance!.Value, Midterm!.Value, Final!.Value) : null;

    public string LetterGrade => TotalScore is decimal total ? GradeRules.LetterGrade(total) : "";

    public decimal GradePoint => LetterGrade.Length == 0 ? 0m : GradeRules.GradePoint(LetterGrade);

    public string Result => TotalScore is decimal total
        ? (GradeRules.IsPassed(total) ? "Passed" : "Failed")
        : "Not graded";

    public CourseGrade Copy() => (CourseGrade)MemberwiseClone();
}
