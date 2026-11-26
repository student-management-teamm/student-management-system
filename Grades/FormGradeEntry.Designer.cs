namespace StudentManagementWinForms.Grades
{
    partial class FormGradeEntry
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
            lblClass = new Label();
            cboClass = new ComboBox();
            lblCourse = new Label();
            cboCourse = new ComboBox();
            lblCredits = new Label();
            lblRule = new Label();
            dgvGrades = new DataGridView();
            colNo = new DataGridViewTextBoxColumn();
            colStudentCode = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            colMidterm = new DataGridViewTextBoxColumn();
            colFinal = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colLetter = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnSave = new Button();
            btnReload = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).BeginInit();
            SuspendLayout();
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(20, 23);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(37, 15);
            lblClass.TabIndex = 8;
            lblClass.Text = "Class:";
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(70, 20);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(150, 23);
            cboClass.TabIndex = 9;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(240, 23);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 0;
            lblCourse.Text = "Course:";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(295, 20);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(340, 23);
            cboCourse.TabIndex = 1;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.Location = new Point(655, 23);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(50, 15);
            lblCredits.TabIndex = 2;
            lblCredits.Text = "Credits: -";
            // 
            // lblRule
            // 
            lblRule.AutoSize = true;
            lblRule.ForeColor = Color.DimGray;
            lblRule.Location = new Point(20, 55);
            lblRule.Name = "lblRule";
            lblRule.Size = new Size(100, 15);
            lblRule.TabIndex = 3;
            lblRule.Text = "Grade rule";
            // 
            // dgvGrades
            // 
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.AllowUserToResizeRows = false;
            dgvGrades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGrades.BackgroundColor = SystemColors.Window;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Columns.AddRange(new DataGridViewColumn[] { colNo, colStudentCode, colStudentName, colAttendance, colMidterm, colFinal, colTotal, colLetter, colResult });
            dgvGrades.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvGrades.Location = new Point(20, 80);
            dgvGrades.MultiSelect = false;
            dgvGrades.Name = "dgvGrades";
            dgvGrades.RowHeadersWidth = 30;
            dgvGrades.Size = new Size(820, 330);
            dgvGrades.TabIndex = 4;
            dgvGrades.CellEndEdit += dgvGrades_CellEndEdit;
            dgvGrades.CellValidating += dgvGrades_CellValidating;
            // 
            // colNo
            // 
            colNo.HeaderText = "No.";
            colNo.Name = "colNo";
            colNo.Width = 45;
            colNo.ReadOnly = true;
            colNo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colStudentCode
            // 
            colStudentCode.HeaderText = "Student code";
            colStudentCode.Name = "colStudentCode";
            colStudentCode.Width = 100;
            colStudentCode.ReadOnly = true;
            colStudentCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colStudentName
            // 
            colStudentName.HeaderText = "Full name";
            colStudentName.Name = "colStudentName";
            colStudentName.Width = 180;
            colStudentName.ReadOnly = true;
            colStudentName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttendance
            // 
            colAttendance.HeaderText = "Attendance (10%)";
            colAttendance.Name = "colAttendance";
            colAttendance.Width = 95;
            colAttendance.ReadOnly = false;
            colAttendance.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colMidterm
            // 
            colMidterm.HeaderText = "Midterm (30%)";
            colMidterm.Name = "colMidterm";
            colMidterm.Width = 90;
            colMidterm.ReadOnly = false;
            colMidterm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colFinal
            // 
            colFinal.HeaderText = "Final (60%)";
            colFinal.Name = "colFinal";
            colFinal.Width = 85;
            colFinal.ReadOnly = false;
            colFinal.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.Width = 65;
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
            // colResult
            // 
            colResult.HeaderText = "Result";
            colResult.Name = "colResult";
            colResult.Width = 90;
            colResult.ReadOnly = true;
            colResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(20, 426);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(60, 15);
            lblSummary.TabIndex = 5;
            lblSummary.Text = "Students: 0";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(640, 418);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReload.Location = new Point(745, 418);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(95, 30);
            btnReload.TabIndex = 7;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // FormGradeEntry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 462);
            Controls.Add(btnReload);
            Controls.Add(btnSave);
            Controls.Add(lblSummary);
            Controls.Add(dgvGrades);
            Controls.Add(lblRule);
            Controls.Add(lblCredits);
            Controls.Add(cboCourse);
            Controls.Add(lblCourse);
            Controls.Add(cboClass);
            Controls.Add(lblClass);
            MinimumSize = new Size(700, 400);
            Name = "FormGradeEntry";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter Grades by Class and Course";
            FormClosing += FormGradeEntry_FormClosing;
            Load += FormGradeEntry_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGrades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClass;
        private ComboBox cboClass;
        private Label lblCourse;
        private ComboBox cboCourse;
        private Label lblCredits;
        private Label lblRule;
        private DataGridView dgvGrades;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colStudentCode;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colAttendance;
        private DataGridViewTextBoxColumn colMidterm;
        private DataGridViewTextBoxColumn colFinal;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colLetter;
        private DataGridViewTextBoxColumn colResult;
        private Label lblSummary;
        private Button btnSave;
        private Button btnReload;
    }
}
