using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentManagementWinForms.Data;

namespace WinFormsApp1
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
                    $"Kết nối MySQL thành công!\nSố sinh viên hiện có: {result}",
                    "Database connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không kết nối được MySQL:\n{ex.Message}",
                    "Database connection error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}