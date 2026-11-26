namespace StudentManagementWinForms.Grades
{
    partial class FormGradeFilter
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
            lblResult = new Label();
            cboResult = new ComboBox();
            lblLetter = new Label();
            cboLetter = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblTotal = new Label();
            nudMinTotal = new NumericUpDown();
            lblTo = new Label();
            nudMaxTotal = new NumericUpDown();
            btnClear = new Button();
            btnReload = new Button();
            dgvGrades = new DataGridView();
            colClass = new DataGridViewTextBoxColumn();
            colStudentCode = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colCourseCode = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colCredits = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            colMidterm = new DataGridViewTextBoxColumn();
            colFinal = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colLetter = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)nudMinTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).BeginInit();
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
            cboClass.Location = new Point(65, 20);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(140, 23);
            cboClass.TabIndex = 1;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(225, 23);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 2;
            lblCourse.Text = "Course:";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(280, 20);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(330, 23);
            cboCourse.TabIndex = 3;
            cboCourse.SelectedIndexChanged += Filter_Changed;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(630, 23);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(42, 15);
            lblResult.TabIndex = 4;
            lblResult.Text = "Result:";
            // 
            // cboResult
            // 
            cboResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResult.FormattingEnabled = true;
            cboResult.Location = new Point(680, 20);
            cboResult.Name = "cboResult";
            cboResult.Size = new Size(110, 23);
            cboResult.TabIndex = 5;
            cboResult.SelectedIndexChanged += Filter_Changed;
            // 
            // lblLetter
            // 
            lblLetter.AutoSize = true;
            lblLetter.Location = new Point(810, 23);
            lblLetter.Name = "lblLetter";
            lblLetter.Size = new Size(40, 15);
            lblLetter.TabIndex = 6;
            lblLetter.Text = "Letter:";
            // 
            // cboLetter
            // 
            cboLetter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLetter.FormattingEnabled = true;
            cboLetter.Location = new Point(860, 20);
            cboLetter.Name = "cboLetter";
            cboLetter.Size = new Size(70, 23);
            cboLetter.TabIndex = 7;
            cboLetter.SelectedIndexChanged += Filter_Changed;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 59);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(75, 56);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Student code or name";
            txtSearch.Size = new Size(240, 23);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += Filter_Changed;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(335, 59);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(63, 15);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Total from:";
            // 
            // nudMinTotal
            // 
            nudMinTotal.DecimalPlaces = 1;
            nudMinTotal.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudMinTotal.Location = new Point(405, 56);
            nudMinTotal.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMinTotal.Name = "nudMinTotal";
            nudMinTotal.Size = new Size(60, 23);
            nudMinTotal.TabIndex = 11;
            nudMinTotal.Value = new decimal(new int[] { 0, 0, 0, 0 });
            nudMinTotal.ValueChanged += TotalRange_Changed;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(472, 59);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(16, 15);
            lblTo.TabIndex = 12;
            lblTo.Text = "to";
            // 
            // nudMaxTotal
            // 
            nudMaxTotal.DecimalPlaces = 1;
            nudMaxTotal.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudMaxTotal.Location = new Point(495, 56);
            nudMaxTotal.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMaxTotal.Name = "nudMaxTotal";
            nudMaxTotal.Size = new Size(60, 23);
            nudMaxTotal.TabIndex = 13;
            nudMaxTotal.Value = new decimal(new int[] { 10, 0, 0, 0 });
            nudMaxTotal.ValueChanged += TotalRange_Changed;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(580, 54);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(95, 27);
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear filters";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(685, 54);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(95, 27);
            btnReload.TabIndex = 15;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // dgvGrades
            // 
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.AllowUserToResizeRows = false;
            dgvGrades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGrades.BackgroundColor = SystemColors.Window;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Columns.AddRange(new DataGridViewColumn[] { colClass, colStudentCode, colStudentName, colCourseCode, colCourseName, colCredits, colAttendance, colMidterm, colFinal, colTotal, colLetter, colResult });
            dgvGrades.Location = new Point(20, 92);
            dgvGrades.MultiSelect = false;
            dgvGrades.Name = "dgvGrades";
            dgvGrades.ReadOnly = true;
            dgvGrades.RowHeadersVisible = false;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.Size = new Size(1150, 420);
            dgvGrades.TabIndex = 16;
            // 
            // colClass
            // 
            colClass.HeaderText = "Class";
            colClass.Name = "colClass";
            colClass.ReadOnly = true;
            colClass.Width = 90;
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
            colStudentName.Width = 170;
            // 
            // colCourseCode
            // 
            colCourseCode.HeaderText = "Course code";
            colCourseCode.Name = "colCourseCode";
            colCourseCode.ReadOnly = true;
            colCourseCode.Width = 85;
            // 
            // colCourseName
            // 
            colCourseName.HeaderText = "Course name";
            colCourseName.Name = "colCourseName";
            colCourseName.ReadOnly = true;
            colCourseName.Width = 220;
            // 
            // colCredits
            // 
            colCredits.HeaderText = "Credits";
            colCredits.Name = "colCredits";
            colCredits.ReadOnly = true;
            colCredits.Width = 60;
            colCredits.ValueType = typeof(int);
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
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 60;
            colTotal.DefaultCellStyle = scoreStyle;
            colTotal.ValueType = typeof(decimal);
            // 
            // colLetter
            // 
            colLetter.HeaderText = "Letter";
            colLetter.Name = "colLetter";
            colLetter.ReadOnly = true;
            colLetter.Width = 55;
            // 
            // colResult
            // 
            colResult.HeaderText = "Result";
            colResult.Name = "colResult";
            colResult.ReadOnly = true;
            colResult.Width = 85;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(20, 525);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(60, 15);
            lblSummary.TabIndex = 17;
            lblSummary.Text = "Rows: 0";
            // 
            // FormGradeFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 552);
            Controls.Add(lblSummary);
            Controls.Add(dgvGrades);
            Controls.Add(btnReload);
            Controls.Add(btnClear);
            Controls.Add(nudMaxTotal);
            Controls.Add(lblTo);
            Controls.Add(nudMinTotal);
            Controls.Add(lblTotal);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(cboLetter);
            Controls.Add(lblLetter);
            Controls.Add(cboResult);
            Controls.Add(lblResult);
            Controls.Add(cboCourse);
            Controls.Add(lblCourse);
            Controls.Add(cboClass);
            Controls.Add(lblClass);
            MinimumSize = new Size(960, 400);
            Name = "FormGradeFilter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filter and Search Grades";
            Load += FormGradeFilter_Load;
            ((System.ComponentModel.ISupportInitialize)nudMinTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClass;
        private ComboBox cboClass;
        private Label lblCourse;
        private ComboBox cboCourse;
        private Label lblResult;
        private ComboBox cboResult;
        private Label lblLetter;
        private ComboBox cboLetter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblTotal;
        private NumericUpDown nudMinTotal;
        private Label lblTo;
        private NumericUpDown nudMaxTotal;
        private Button btnClear;
        private Button btnReload;
        private DataGridView dgvGrades;
        private DataGridViewTextBoxColumn colClass;
        private DataGridViewTextBoxColumn colStudentCode;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colCourseCode;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colCredits;
        private DataGridViewTextBoxColumn colAttendance;
        private DataGridViewTextBoxColumn colMidterm;
        private DataGridViewTextBoxColumn colFinal;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colLetter;
        private DataGridViewTextBoxColumn colResult;
        private Label lblSummary;
    }
}
