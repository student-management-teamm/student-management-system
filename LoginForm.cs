using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentManagementWinForms.Data;

namespace StudentManagementWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ApplyModernDesign();
        }

        private void ApplyModernDesign()
        {
            ClientSize = new Size(900, 540);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Management System";

            // Separate the branding area from the login area.
            Controls.Clear();

            Panel brandPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(330, 540),
                BackColor = Color.FromArgb(20, 43, 73)
            };

            Panel loginPanel = new Panel
            {
                Location = new Point(330, 0),
                Size = new Size(570, 540),
                BackColor = Color.White
            };

            Controls.Add(loginPanel);
            Controls.Add(brandPanel);

            Label logo = new Label
            {
                Text = "SM",
                Location = new Point(42, 48),
                Size = new Size(62, 54),
                BackColor = Color.FromArgb(49, 103, 184),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label brandTitle = new Label
            {
                Text = "STUDENT\nMANAGEMENT\nSYSTEM",
                Location = new Point(42, 145),
                Size = new Size(250, 125),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 23F, FontStyle.Bold)
            };

            Label brandDescription = new Label
            {
                Text = "A simple way to manage\nstudents, classes and records.",
                Location = new Point(44, 292),
                Size = new Size(245, 60),
                ForeColor = Color.FromArgb(195, 211, 230),
                Font = new Font("Segoe UI", 11F)
            };

            Label brandFooter = new Label
            {
                Text = "ACADEMIC MANAGEMENT",
                Location = new Point(44, 485),
                Size = new Size(245, 24),
                ForeColor = Color.FromArgb(166, 190, 216),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };

            brandPanel.Controls.Add(logo);
            brandPanel.Controls.Add(brandTitle);
            brandPanel.Controls.Add(brandDescription);
            brandPanel.Controls.Add(brandFooter);

            lblTitle.Text = "Welcome back";
            lblTitle.Location = new Point(55, 92);
            lblTitle.Size = new Size(455, 42);
            lblTitle.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(28, 42, 60);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            Label subtitle = new Label
            {
                Text = "Sign in to continue to your account.",
                Location = new Point(58, 139),
                Size = new Size(440, 28),
                ForeColor = Color.FromArgb(111, 125, 143),
                Font = new Font("Segoe UI", 10.5F)
            };

            lblUsername.Text = "USERNAME";
            lblUsername.Location = new Point(58, 204);
            lblUsername.Size = new Size(440, 22);
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(65, 79, 98);

            txtUsername.Location = new Point(58, 230);
            txtUsername.Size = new Size(440, 34);
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.PlaceholderText = "Enter your username";

            lblPassword.Text = "PASSWORD";
            lblPassword.Location = new Point(58, 290);
            lblPassword.Size = new Size(440, 22);
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(65, 79, 98);

            txtPassword.Location = new Point(58, 316);
            txtPassword.Size = new Size(440, 34);
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PlaceholderText = "Enter your password";

            btnLogin.Text = "Sign in";
            btnLogin.Location = new Point(58, 382);
            btnLogin.Size = new Size(285, 46);
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(49, 103, 184);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Cursor = Cursors.Hand;

            btnCancel.Text = "Exit";
            btnCancel.Location = new Point(358, 382);
            btnCancel.Size = new Size(140, 46);
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.FromArgb(65, 79, 98);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(210, 218, 229);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Cursor = Cursors.Hand;

            Label securityNote = new Label
            {
                Text = "Your account is protected by secure sign-in.",
                Location = new Point(58, 466),
                Size = new Size(440, 24),
                ForeColor = Color.FromArgb(130, 143, 160),
                Font = new Font("Segoe UI", 9F)
            };

            loginPanel.Controls.Add(lblTitle);
            loginPanel.Controls.Add(subtitle);
            loginPanel.Controls.Add(lblUsername);
            loginPanel.Controls.Add(txtUsername);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(btnLogin);
            loginPanel.Controls.Add(btnCancel);
            loginPanel.Controls.Add(securityNote);

            AcceptButton = btnLogin;
            CancelButton = btnCancel;
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your username and password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long userId = 0;
                string authenticatedUsername = string.Empty;
                string role = string.Empty;

                using (MySqlConnection connection = Database.CreateConnection())
                {
                    connection.Open();

                    const string sql = @"
                        SELECT UserId, Username, Role
                        FROM users
                        WHERE Username = @Username
                          AND PasswordHash = SHA2(@Password, 256)
                          AND IsActive = TRUE
                        LIMIT 1;";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userId = reader.GetInt64("UserId");
                        authenticatedUsername = reader.GetString("Username");
                        role = reader.GetString("Role");
                    }
                }

                if (userId == 0)
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                UserSession.Start(userId, authenticatedUsername, role);

                Hide();

                using (Form1 mainForm = new Form1())
                {
                    mainForm.ShowDialog();
                }

                UserSession.End();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not log in:\n{ex.Message}",
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void lblTitle_Click(object? sender, EventArgs e)
        {
            // No action is required when the title is clicked.
        }
    }
}