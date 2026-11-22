namespace StudentManagementWinForms.Grades
{
    partial class FormGradesHome
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnGradeEntry = new Button();
            btnStudentGrades = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Grade Management";
            // 
            // btnGradeEntry
            // 
            btnGradeEntry.Location = new Point(24, 70);
            btnGradeEntry.Name = "btnGradeEntry";
            btnGradeEntry.Size = new Size(300, 40);
            btnGradeEntry.TabIndex = 1;
            btnGradeEntry.Text = "Enter grades by course";
            btnGradeEntry.UseVisualStyleBackColor = true;
            btnGradeEntry.Click += btnGradeEntry_Click;
            // 
            // btnStudentGrades
            // 
            btnStudentGrades.Location = new Point(24, 122);
            btnStudentGrades.Name = "btnStudentGrades";
            btnStudentGrades.Size = new Size(300, 40);
            btnStudentGrades.TabIndex = 2;
            btnStudentGrades.Text = "View student transcript and GPA";
            btnStudentGrades.UseVisualStyleBackColor = true;
            btnStudentGrades.Click += btnStudentGrades_Click;
            // 
            // FormGradesHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 190);
            Controls.Add(btnStudentGrades);
            Controls.Add(btnGradeEntry);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormGradesHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grade Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnGradeEntry;
        private Button btnStudentGrades;
    }
}
