namespace StudentManagementWinForms.Grades
{
    partial class FormFinalScoreNeeded
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
            DataGridViewCellStyle scoreStyle = new DataGridViewCellStyle();
            lblClass = new Label();
            cboClass = new ComboBox();
            lblCourse = new Label();
            cboCourse = new ComboBox();
            lblHelp = new Label();
            dgvNeeded = new DataGridView();
            colStudentCode = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            colMidterm = new DataGridViewTextBoxColumn();
            colFinal = new DataGridViewTextBoxColumn();
            colPass = new DataGridViewTextBoxColumn();
            colC = new DataGridViewTextBoxColumn();
            colB = new DataGridViewTextBoxColumn();
            colA = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNeeded).BeginInit();
            SuspendLayout();
            scoreStyle.Format = "0.0#";
            scoreStyle.NullValue = "";
            scoreStyle.FormatProvider = System.Globalization.CultureInfo.InvariantCulture;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(20, 23);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(37, 15);
            lblClass.TabIndex = 0;
            lblClass.Text = "Class:";
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(70, 20);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(150, 23);
            cboClass.TabIndex = 1;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(240, 23);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 2;
            lblCourse.Text = "Course:";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(295, 20);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(340, 23);
            cboCourse.TabIndex = 3;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            // 
            // lblHelp
            // 
            lblHelp.AutoSize = true;
            lblHelp.Location = new Point(20, 55);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(400, 15);
            lblHelp.TabIndex = 4;
            lblHelp.Text = "Lowest final exam score each student needs for a pass, C, B or A.";
            lblHelp.ForeColor = Color.DimGray;
            // 
            // dgvNeeded
            // 
            dgvNeeded.AllowUserToAddRows = false;
            dgvNeeded.AllowUserToDeleteRows = false;
            dgvNeeded.AllowUserToResizeRows = false;
            dgvNeeded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNeeded.BackgroundColor = SystemColors.Window;
            dgvNeeded.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNeeded.Columns.AddRange(new DataGridViewColumn[] { colStudentCode, colStudentName, colAttendance, colMidterm, colFinal, colPass, colC, colB, colA, colNote });
            dgvNeeded.Location = new Point(20, 80);
            dgvNeeded.MultiSelect = false;
            dgvNeeded.Name = "dgvNeeded";
            dgvNeeded.ReadOnly = true;
            dgvNeeded.RowHeadersVisible = false;
            dgvNeeded.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNeeded.Size = new Size(940, 360);
            dgvNeeded.TabIndex = 5;
            // 
            // colStudentCode
            // 
            colStudentCode.HeaderText = "Student code";
            colStudentCode.Name = "colStudentCode";
            colStudentCode.ReadOnly = true;
            colStudentCode.Width = 95;
            // 
            // colStudentName
            // 
            colStudentName.HeaderText = "Full name";
            colStudentName.Name = "colStudentName";
            colStudentName.ReadOnly = true;
            colStudentName.Width = 180;
            // 
            // colAttendance
            // 
            colAttendance.HeaderText = "Attendance";
            colAttendance.Name = "colAttendance";
            colAttendance.ReadOnly = true;
            colAttendance.Width = 80;
            colAttendance.DefaultCellStyle = scoreStyle;
            colAttendance.ValueType = typeof(decimal);
            // 
            // colMidterm
            // 
            colMidterm.HeaderText = "Midterm";
            colMidterm.Name = "colMidterm";
            colMidterm.ReadOnly = true;
            colMidterm.Width = 70;
            colMidterm.DefaultCellStyle = scoreStyle;
            colMidterm.ValueType = typeof(decimal);
            // 
            // colFinal
            // 
            colFinal.HeaderText = "Final";
            colFinal.Name = "colFinal";
            colFinal.ReadOnly = true;
            colFinal.Width = 60;
            colFinal.DefaultCellStyle = scoreStyle;
            colFinal.ValueType = typeof(decimal);
            // 
            // colPass
            // 
            colPass.HeaderText = "Pass (D)";
            colPass.Name = "colPass";
            colPass.ReadOnly = true;
            colPass.Width = 90;
            // 
            // colC
            // 
            colC.HeaderText = "C";
            colC.Name = "colC";
            colC.ReadOnly = true;
            colC.Width = 90;
            // 
            // colB
            // 
            colB.HeaderText = "B";
            colB.Name = "colB";
            colB.ReadOnly = true;
            colB.Width = 90;
            // 
            // colA
            // 
            colA.HeaderText = "A";
            colA.Name = "colA";
            colA.ReadOnly = true;
            colA.Width = 90;
            // 
            // colNote
            // 
            colNote.HeaderText = "Note";
            colNote.Name = "colNote";
            colNote.ReadOnly = true;
            colNote.Width = 240;
            colNote.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(20, 455);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(300, 15);
            lblSummary.TabIndex = 6;
            lblSummary.Text = "";
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // FormFinalScoreNeeded
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 485);
            Controls.Add(lblSummary);
            Controls.Add(dgvNeeded);
            Controls.Add(lblHelp);
            Controls.Add(cboCourse);
            Controls.Add(lblCourse);
            Controls.Add(cboClass);
            Controls.Add(lblClass);
            MinimumSize = new Size(760, 380);
            Name = "FormFinalScoreNeeded";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Final Exam Score Needed";
            Load += FormFinalScoreNeeded_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNeeded).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClass;
        private ComboBox cboClass;
        private Label lblCourse;
        private ComboBox cboCourse;
        private Label lblHelp;
        private DataGridView dgvNeeded;
        private DataGridViewTextBoxColumn colStudentCode;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colAttendance;
        private DataGridViewTextBoxColumn colMidterm;
        private DataGridViewTextBoxColumn colFinal;
        private DataGridViewTextBoxColumn colPass;
        private DataGridViewTextBoxColumn colC;
        private DataGridViewTextBoxColumn colB;
        private DataGridViewTextBoxColumn colA;
        private DataGridViewTextBoxColumn colNote;
        private Label lblSummary;
    }
}
