namespace StudentManagementWinForms.Grades
{
    partial class FormStudentGrades
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
            lblStudent = new Label();
            cboStudent = new ComboBox();
            dgvTranscript = new DataGridView();
            colCourseCode = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colCredits = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            colMidterm = new DataGridViewTextBoxColumn();
            colFinal = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colLetter = new DataGridViewTextBoxColumn();
            colGradePoint = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            lblGpa = new Label();
            lblClassification = new Label();
            lblCredits = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).BeginInit();
            SuspendLayout();
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(20, 23);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(51, 15);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Student:";
            // 
            // cboStudent
            // 
            cboStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new Point(85, 20);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new Size(320, 23);
            cboStudent.TabIndex = 1;
            cboStudent.SelectedIndexChanged += cboStudent_SelectedIndexChanged;
            // 
            // dgvTranscript
            // 
            dgvTranscript.AllowUserToAddRows = false;
            dgvTranscript.AllowUserToDeleteRows = false;
            dgvTranscript.AllowUserToResizeRows = false;
            dgvTranscript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTranscript.BackgroundColor = SystemColors.Window;
            dgvTranscript.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTranscript.Columns.AddRange(new DataGridViewColumn[] { colCourseCode, colCourseName, colCredits, colAttendance, colMidterm, colFinal, colTotal, colLetter, colGradePoint, colResult });
            dgvTranscript.Location = new Point(20, 60);
            dgvTranscript.MultiSelect = false;
            dgvTranscript.Name = "dgvTranscript";
            dgvTranscript.ReadOnly = true;
            dgvTranscript.RowHeadersVisible = false;
            dgvTranscript.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTranscript.Size = new Size(860, 300);
            dgvTranscript.TabIndex = 2;
            // 
            // colCourseCode
            // 
            colCourseCode.HeaderText = "Course code";
            colCourseCode.Name = "colCourseCode";
            colCourseCode.Width = 90;
            colCourseCode.ReadOnly = true;
            colCourseCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCourseName
            // 
            colCourseName.HeaderText = "Course name";
            colCourseName.Name = "colCourseName";
            colCourseName.Width = 180;
            colCourseName.ReadOnly = true;
            colCourseName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCredits
            // 
            colCredits.HeaderText = "Credits";
            colCredits.Name = "colCredits";
            colCredits.Width = 60;
            colCredits.ReadOnly = true;
            colCredits.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttendance
            // 
            colAttendance.HeaderText = "Attendance";
            colAttendance.Name = "colAttendance";
            colAttendance.Width = 90;
            colAttendance.ReadOnly = true;
            colAttendance.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colMidterm
            // 
            colMidterm.HeaderText = "Midterm";
            colMidterm.Name = "colMidterm";
            colMidterm.Width = 70;
            colMidterm.ReadOnly = true;
            colMidterm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colFinal
            // 
            colFinal.HeaderText = "Final";
            colFinal.Name = "colFinal";
            colFinal.Width = 60;
            colFinal.ReadOnly = true;
            colFinal.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.Width = 60;
            colTotal.ReadOnly = true;
            colTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colLetter
            // 
            colLetter.HeaderText = "Letter";
            colLetter.Name = "colLetter";
            colLetter.Width = 55;
            colLetter.ReadOnly = true;
            colLetter.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colGradePoint
            // 
            colGradePoint.HeaderText = "Point (4)";
            colGradePoint.Name = "colGradePoint";
            colGradePoint.Width = 70;
            colGradePoint.ReadOnly = true;
            colGradePoint.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colResult
            // 
            colResult.HeaderText = "Result";
            colResult.Name = "colResult";
            colResult.Width = 85;
            colResult.ReadOnly = true;
            colResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // lblGpa
            // 
            lblGpa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblGpa.AutoSize = true;
            lblGpa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGpa.Location = new Point(20, 375);
            lblGpa.Name = "lblGpa";
            lblGpa.Size = new Size(150, 19);
            lblGpa.TabIndex = 3;
            lblGpa.Text = "GPA (4-point scale): -";
            // 
            // lblClassification
            // 
            lblClassification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblClassification.AutoSize = true;
            lblClassification.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClassification.Location = new Point(300, 375);
            lblClassification.Name = "lblClassification";
            lblClassification.Size = new Size(120, 19);
            lblClassification.TabIndex = 4;
            lblClassification.Text = "Classification: -";
            // 
            // lblCredits
            // 
            lblCredits.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCredits.AutoSize = true;
            lblCredits.Location = new Point(20, 403);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(150, 15);
            lblCredits.TabIndex = 5;
            lblCredits.Text = "Credits graded: 0   Credits earned: 0";
            // 
            // FormStudentGrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 435);
            Controls.Add(lblCredits);
            Controls.Add(lblClassification);
            Controls.Add(lblGpa);
            Controls.Add(dgvTranscript);
            Controls.Add(cboStudent);
            Controls.Add(lblStudent);
            MinimumSize = new Size(700, 350);
            Name = "FormStudentGrades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Transcript and GPA";
            Load += FormStudentGrades_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudent;
        private ComboBox cboStudent;
        private DataGridView dgvTranscript;
        private DataGridViewTextBoxColumn colCourseCode;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colCredits;
        private DataGridViewTextBoxColumn colAttendance;
        private DataGridViewTextBoxColumn colMidterm;
        private DataGridViewTextBoxColumn colFinal;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colLetter;
        private DataGridViewTextBoxColumn colGradePoint;
        private DataGridViewTextBoxColumn colResult;
        private Label lblGpa;
        private Label lblClassification;
        private Label lblCredits;
    }
}
