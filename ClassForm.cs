using MySql.Data.MySqlClient;
using StudentManagementWinForms.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagementWinForms
{
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();

            lblTeacherName.AutoSize = false;
            lblTeacherName.Size = new Size(280, 150);
            lblTeacherName.TextAlign = ContentAlignment.TopLeft;

            lblSubject.AutoSize = false;
            lblSubject.Size = new Size(280, 180);
            lblSubject.TextAlign = ContentAlignment.TopLeft;

            lblTeacherName.BringToFront();
            lblSubject.BringToFront();

            // Tránh đăng ký sự kiện nhiều lần nếu form được khởi tạo lại.
            dgvClasses.CellClick -= dgvClasses_CellClick;
            dgvClasses.CellClick += dgvClasses_CellClick;

            btnLoad.Click -= btnLoad_Click;
            btnLoad.Click += btnLoad_Click;

            LoadClasses();
        }

        private void LoadClasses()
        {
            try
            {
                using MySqlConnection connection = Database.CreateConnection();
                connection.Open();

                string query = @"
                    SELECT
                        C.ClassID,
                        C.ClassName AS `Tên lớp`,
                        COUNT(S.StudentID) AS `Sĩ số`
                    FROM Classes C
                    LEFT JOIN Students S ON C.ClassID = S.ClassID
                    GROUP BY C.ClassID, C.ClassName
                    ORDER BY C.ClassName;";

                using MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, connection);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvClasses.DataSource = table;

                if (dgvClasses.Columns.Contains("ClassID"))
                {
                    dgvClasses.Columns["ClassID"].Visible = false;
                }

                dgvStudents.DataSource = null;

                lblTeacherName.Text = "Giảng viên: Chưa chọn lớp";
                lblSubject.Text = "Môn học: Chưa chọn lớp";
                lblDepartment.Text = "Khoa: Chưa chọn lớp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách lớp: " + ex.Message,
                    "Lỗi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStudents(int classID)
        {
            try
            {
                using MySqlConnection connection = Database.CreateConnection();
                connection.Open();

                string query = @"
                    SELECT
                        StudentCode AS `Mã sinh viên`,
                        LastName AS `Họ đệm`,
                        FirstName AS `Tên`,
                        DATE_FORMAT(DateOfBirth, '%d/%m/%Y') AS `Ngày sinh`
                    FROM Students
                    WHERE ClassID = @ClassID
                    ORDER BY StudentCode;";

                using MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.Add("@ClassID", MySqlDbType.Int32).Value =
                    classID;

                using MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvStudents.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách sinh viên: " + ex.Message,
                    "Lỗi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadTeacherInfo(int classID)
        {
            try
            {
                using MySqlConnection connection = Database.CreateConnection();
                connection.Open();

                string query = @"
                    SELECT
                        D.DepartmentName,
                        L.LecturerID,
                        L.LastName,
                        L.FirstName,
                        S.SubjectName
                    FROM Classes C
                    LEFT JOIN Departments D
                        ON C.DepartmentID = D.DepartmentID
                    LEFT JOIN ClassSubjects CS
                        ON C.ClassID = CS.ClassID
                    LEFT JOIN Lecturers L
                        ON CS.LecturerID = L.LecturerID
                    LEFT JOIN Subjects S
                        ON CS.SubjectID = S.SubjectID
                    WHERE C.ClassID = @ClassID
                    ORDER BY S.SubjectName;";

                using MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.Add("@ClassID", MySqlDbType.Int32).Value =
                    classID;

                using MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    lblTeacherName.Text = "Giảng viên: Chưa có dữ liệu";
                    lblSubject.Text = "Môn học: Chưa có dữ liệu";
                    lblDepartment.Text = "Khoa: Chưa có dữ liệu";
                    return;
                }

                HashSet<int> lecturerIDs = new HashSet<int>();
                HashSet<string> subjectNames =
                    new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                StringBuilder teachers = new StringBuilder();
                StringBuilder subjects = new StringBuilder();

                foreach (DataRow row in table.Rows)
                {
                    // Gom giảng viên, tránh lặp tên nếu một người dạy nhiều môn.
                    if (row["LecturerID"] != DBNull.Value)
                    {
                        int lecturerID = Convert.ToInt32(row["LecturerID"]);

                        if (lecturerIDs.Add(lecturerID))
                        {
                            string lastName =
                                row["LastName"] == DBNull.Value
                                    ? ""
                                    : row["LastName"].ToString();

                            string firstName =
                                row["FirstName"] == DBNull.Value
                                    ? ""
                                    : row["FirstName"].ToString();

                            string teacher =
                                (lastName + " " + firstName).Trim();

                            if (!string.IsNullOrWhiteSpace(teacher))
                            {
                                if (teachers.Length > 0)
                                    teachers.Append(", ");

                                teachers.Append(teacher);
                            }
                        }
                    }

                    // Gom môn học, tránh lặp tên môn.
                    if (row["SubjectName"] != DBNull.Value)
                    {
                        string subject = row["SubjectName"].ToString();

                        if (!string.IsNullOrWhiteSpace(subject) &&
                            subjectNames.Add(subject))
                        {
                            if (subjects.Length > 0)
                                subjects.Append(", ");

                            subjects.Append(subject);
                        }
                    }
                }

                lblTeacherName.Text = teachers.Length > 0
                    ? "Giảng viên phụ trách: " + teachers
                    : "Giảng viên: Chưa phân công";

                lblSubject.Text = subjects.Length > 0
                    ? "Môn học: " + subjects
                    : "Môn học: Chưa có dữ liệu";

                string departmentName =
                    table.Rows[0]["DepartmentName"] == DBNull.Value
                        ? ""
                        : table.Rows[0]["DepartmentName"].ToString();

                lblDepartment.Text = !string.IsNullOrWhiteSpace(departmentName)
                    ? "Khoa: " + departmentName
                    : "Khoa: Chưa có dữ liệu";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải thông tin giảng viên: " + ex.Message,
                    "Lỗi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvClasses_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvClasses.Columns.Contains("ClassID"))
                return;

            object value =
                dgvClasses.Rows[e.RowIndex].Cells["ClassID"].Value;

            if (value == null || value == DBNull.Value)
                return;

            int classID = Convert.ToInt32(value);

            LoadStudents(classID);
            LoadTeacherInfo(classID);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadClasses();
        }

        private void dgvClasses_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Để trống nếu không sử dụng sự kiện này.
        }

        private void grpTeacher_Enter(object sender, EventArgs e)
        {
            // Để trống nếu không sử dụng sự kiện này.
        }

        private void lblStudents_Click(object sender, EventArgs e)
        {
            // Để trống nếu không sử dụng sự kiện này.
        }
    }
}