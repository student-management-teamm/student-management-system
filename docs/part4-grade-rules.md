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

## Not done yet (depends on other parts)

- Database tables for courses, enrolments and grades (part 2). Until then the forms use
  `InMemoryGradeRepository` with sample data; a MySQL repository will implement `IGradeRepository`.
- Opening the grade forms from the main menu (part 3): call `GradesModule.ShowHome(this)`.
- Restricting lecturers to their own classes (part 1).
