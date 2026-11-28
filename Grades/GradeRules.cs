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

    /// <summary>Totals a student can aim for with the final exam, from passing to an A.</summary>
    public static readonly (string Label, decimal MinTotal)[] FinalScoreTargets =
    {
        ("Pass (D)", PassMark),
        ("C", 5.5m),
        ("B", 7.0m),
        ("A", 8.5m)
    };

    /// <summary>
    /// Lowest final exam score (in steps of 0.1) that gives at least <paramref name="targetTotal"/>
    /// after rounding, or null when even 10 is not enough.
    /// </summary>
    public static decimal? MinimumFinalScore(decimal attendance, decimal midterm, decimal targetTotal)
    {
        for (int step = 0; step <= 100; step++)
        {
            decimal final = step / 10m;
            if (TotalScore(attendance, midterm, final) >= targetTotal)
            {
                return final;
            }
        }
        return null;
    }

    // Academic warning thresholds (group assumption; change here if the school's rules differ).
    public const decimal WarningLevel1Gpa = 2.0m;
    public const decimal WarningLevel2Gpa = 1.0m;
    public const int WarningLevel1FailedCredits = 6;
    public const decimal WarningLevel2FailedShare = 0.5m;

    /// <summary>
    /// 0 = no warning, 1 = level 1, 2 = level 2 (serious), with the reasons in plain English.
    /// </summary>
    public static int AcademicWarningLevel(decimal gpa, int gradedCredits, int failedCredits, out string reason)
    {
        List<string> reasons = new();
        int level = 0;

        if (gradedCredits == 0)
        {
            reason = "";
            return 0;
        }

        if (gpa < WarningLevel2Gpa)
        {
            level = 2;
            reasons.Add($"GPA below {WarningLevel2Gpa.ToString("0.0", CultureInfo.InvariantCulture)}");
        }
        else if (gpa < WarningLevel1Gpa)
        {
            level = 1;
            reasons.Add($"GPA below {WarningLevel1Gpa.ToString("0.0", CultureInfo.InvariantCulture)}");
        }

        if (failedCredits >= gradedCredits * WarningLevel2FailedShare)
        {
            level = 2;
            reasons.Add($"failed at least {WarningLevel2FailedShare.ToString("0%", CultureInfo.InvariantCulture)} of graded credits");
        }
        else if (failedCredits >= WarningLevel1FailedCredits)
        {
            level = Math.Max(level, 1);
            reasons.Add($"failed {failedCredits} credits (limit {WarningLevel1FailedCredits})");
        }

        reason = string.Join("; ", reasons);
        return level;
    }
}
