using System.Globalization;

namespace StudentManagementWinForms.Grades;

public static class GradeRules
{
    public const decimal AttendanceWeight = 0.1m;
    public const decimal MidtermWeight = 0.3m;
    public const decimal FinalWeight = 0.6m;
    public const decimal MinScore = 0m;
    public const decimal MaxScore = 10m;
    public const decimal PassMark = 4.0m;

    public static bool IsValidScore(decimal score) => score >= MinScore && score <= MaxScore;

    public static bool TryParseScore(string? text, out decimal? score)
    {
        score = null;
        string value = (text ?? "").Trim();
        if (value.Length == 0)
        {
            return true;
        }

        value = value.Replace(',', '.');
        if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal parsed))
        {
            return false;
        }

        if (!IsValidScore(parsed) || decimal.Round(parsed, 2) != parsed)
        {
            return false;
        }

        score = parsed;
        return true;
    }

    public static string FormatScore(decimal? score) =>
        score is decimal value ? value.ToString("0.0#", CultureInfo.InvariantCulture) : "";

    public static decimal TotalScore(decimal attendance, decimal midterm, decimal final)
    {
        if (!IsValidScore(attendance) || !IsValidScore(midterm) || !IsValidScore(final))
        {
            throw new ArgumentOutOfRangeException(nameof(final), "Scores must be between 0 and 10.");
        }

        decimal total = attendance * AttendanceWeight + midterm * MidtermWeight + final * FinalWeight;
        return Math.Round(total, 1, MidpointRounding.AwayFromZero);
    }

    public static string LetterGrade(decimal totalScore) => totalScore switch
    {
        >= 8.5m => "A",
        >= 8.0m => "B+",
        >= 7.0m => "B",
        >= 6.5m => "C+",
        >= 5.5m => "C",
        >= 5.0m => "D+",
        >= 4.0m => "D",
        _ => "F"
    };

    public static decimal GradePoint(string letterGrade) => letterGrade switch
    {
        "A" => 4.0m,
        "B+" => 3.5m,
        "B" => 3.0m,
        "C+" => 2.5m,
        "C" => 2.0m,
        "D+" => 1.5m,
        "D" => 1.0m,
        _ => 0m
    };

    public static bool IsPassed(decimal totalScore) => totalScore >= PassMark;

    public static decimal Gpa(IEnumerable<CourseGrade> grades)
    {
        List<CourseGrade> graded = grades.Where(g => g.HasAllScores && g.Credits > 0).ToList();
        int credits = graded.Sum(g => g.Credits);
        if (credits == 0)
        {
            return 0m;
        }

        decimal points = graded.Sum(g => g.GradePoint * g.Credits);
        return Math.Round(points / credits, 2, MidpointRounding.AwayFromZero);
    }

    public static int EarnedCredits(IEnumerable<CourseGrade> grades) =>
        grades.Where(g => g.TotalScore is decimal total && IsPassed(total)).Sum(g => g.Credits);

    public static string Classification(decimal gpa) => gpa switch
    {
        >= 3.6m => "Excellent",
        >= 3.2m => "Very good",
        >= 2.5m => "Good",
        >= 2.0m => "Average",
        >= 1.0m => "Weak",
        _ => "Poor"
    };
}
