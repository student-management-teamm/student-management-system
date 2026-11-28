using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentManagementWinForms.Data;

namespace StudentManagementWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection connection = Database.CreateConnection();
                connection.Open();

                using MySqlCommand command =
                    new("SELECT COUNT(*) FROM students;", connection);

                object? result = command.ExecuteScalar();

                MessageBox.Show(
                    $"Kết nối SQL Server thành công!\nSố sinh viên hiện có: {result}",
                    "Database connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không kết nối được SQL Server:\n{ex.Message}",
                    "Database connection error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            btnClasses = new Button();
            btnGrades = new Button();
            SuspendLayout();
            // 
            // btnClasses
            // 
            btnClasses.Location = new Point(21, 12);
            btnClasses.Name = "btnClasses";
            btnClasses.Size = new Size(121, 23);
            btnClasses.TabIndex = 0;
            btnClasses.Text = "Quản lý lớp";
            btnClasses.UseVisualStyleBackColor = true;
            btnClasses.Click += btnClasses_Click;
            // 
            // btnGrades
            // 
            btnGrades.Location = new Point(158, 12);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(121, 23);
            btnGrades.TabIndex = 1;
            btnGrades.Text = "Manage Grades";
            btnGrades.UseVisualStyleBackColor = true;
            btnGrades.Click += btnGrades_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(718, 316);
            Controls.Add(btnClasses);
            Controls.Add(btnGrades);
            Name = "Form1";
            ResumeLayout(false);

        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassForm classForm = new ClassForm();
            classForm.ShowDialog();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            Grades.GradesModule.ShowHome(this);
        }
    }
}
