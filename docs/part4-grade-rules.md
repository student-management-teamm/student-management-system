# Part 4 - Grades and GPA: business rules

These rules are implemented in `Grades/GradeRules.cs`. The weights and the grade scale
below are the group's working assumptions; confirm them with the lecturer and change the
constants in `GradeRules.cs` if they differ.

## Score input

- Each course has three component scores: attendance, midterm and final exam.
- Every score is on a 0-10 scale with at most two decimals (for example 7.25).
- An empty score means "not graded yet"; the total is only calculated when all three scores exist.

## Total score (10-point scale)

Total = Attendance x 10% + Midterm x 30% + Final x 60%, rounded to one decimal
(half away from zero).

## Letter grade and grade point (4-point scale)

| Total (10-point) | Letter | Grade point |
| --- | --- | --- |
| 8.5 - 10.0 | A | 4.0 |
| 8.0 - 8.4 | B+ | 3.5 |
| 7.0 - 7.9 | B | 3.0 |
| 6.5 - 6.9 | C+ | 2.5 |
| 5.5 - 6.4 | C | 2.0 |
| 5.0 - 5.4 | D+ | 1.5 |
| 4.0 - 4.9 | D | 1.0 |
| below 4.0 | F | 0.0 |

A course is passed when the total is at least 4.0.

## GPA and classification

- GPA = sum(grade point x credits) / sum(credits), over all courses that have a total score
  (failed courses count with 0 points). Rounded to two decimals.
- Credits earned = credits of passed courses.

| GPA (4-point) | Classification |
| --- | --- |
| 3.60 - 4.00 | Excellent |
| 3.20 - 3.59 | Very good |
| 2.50 - 3.19 | Good |
| 2.00 - 2.49 | Average |
| 1.00 - 1.99 | Weak |
| below 1.00 | Poor |

## Worked examples (sample data)

| Student | Course | Attendance | Midterm | Final | Total | Letter | Result |
| --- | --- | --- | --- | --- | --- | --- | --- |
| SV001 | IT101 (3 credits) | 10 | 8 | 9 | 8.8 | A | Passed |
| SV001 | IT102 (3 credits) | 9 | 7.5 | 8 | 8.0 | B+ | Passed |
| SV001 | IT103 (2 credits) | 10 | 8 | 7 | 7.6 | B | Passed |
| SV003 | IT101 (3 credits) | 8 | 5 | 3 | 4.1 | D | Passed |
| SV004 | IT103 (2 credits) | 7 | 4 | 2 | 3.1 | F | Failed |

SV001: GPA = (4.0 x 3 + 3.5 x 3 + 3.0 x 2) / 8 = 28.5 / 8 = 3.5625 -> 3.56, classification "Very good".
(IT102: 9 x 0.1 + 7.5 x 0.3 + 8 x 0.6 = 7.95, rounded to 8.0.)

## Forms

- **Grade Management** (main menu button "Manage Grades"): home screen of part 4.
- **Enter Grades by Class and Course**: pick a class, then one of its courses; enter attendance,
  midterm and final scores for every student of the class. Total, letter grade and result are
  calculated as you type; Save writes to the `grades` table.
- **Student Transcript and GPA**: all courses of one student with GPA and classification.
- **Filter and Search Grades** (extension): filter all grades by class, course, result
  (passed / failed / not graded), letter grade, total score range and student code or name.
  Shows pass rate and average total of the filtered rows.
- **Import Grades from Excel or CSV** (extension): pick a class and course, choose the lecturer's
  grade sheet (.xlsx or .csv). The student code and score columns are found by their headings
  ("Ma sinh vien"/"MSSV"/"Student code", "CC1"/"Attendance", "GK"/"Midterm", "THI1"/"Final"),
  students are matched by student code, and every row is previewed (will update / no change /
  skipped with the reason) before saving. By default an empty cell keeps the current score.
  In the preview the scores can be corrected (0-10, "8,5" or "8.5"), a row can be left out with
  the Import tick box or removed with Remove row, and Undo last import puts back the scores
  that were stored before the last import.
- **Final Exam Score Needed** (extension): for students with attendance and midterm scores but no
  final score yet, the lowest final score (steps of 0.1) needed to pass, or to reach C, B or A.
  "Not possible" when even 10 is not enough; students needing more than 8 to pass are marked
  "at risk".
- **Academic Warnings** (extension): GPA, graded and failed credits of every student, with a
  warning level (thresholds in `GradeRules.cs`, group assumption):

| Level | Condition |
| --- | --- |
| Level 2 (serious) | GPA below 1.0, or failed credits are at least 50% of graded credits |
| Level 1 | GPA below 2.0, or 6 or more failed credits |

## Not done yet (depends on other parts)

- Restricting lecturers to their own classes (part 1).

## Database

Grades are stored in MySQL in the `grades` table (one row per student and course:
`AttendanceScore`, `MidtermScore`, `FinalScore`, NULL = not graded yet). The module reads
students from `students`, courses from `subjects`, and which class studies which course from
`classsubjects`.

`database/grades.sql` creates the `grades` table, adds the course DCIT09 "Lập trình .NET (C#)"
(3 credits) for class DCIT.15 and loads the class's attendance and midterm scores (real grade
sheet, final exam not taken yet). It also loads SAMPLE scores (made up, for testing and the demo)
for every student in every other course of their class. Run it after
`database/student_management_group.sql`:

```
mysql -u root -p --default-character-set=utf8mb4 < database/grades.sql
```
