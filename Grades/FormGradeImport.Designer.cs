namespace StudentManagementWinForms.Grades
{
    partial class FormGradeImport
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
            btnBrowse = new Button();
            lblFile = new Label();
            lblColumns = new Label();
            chkKeepEmpty = new CheckBox();
            dgvPreview = new DataGridView();
            colRow = new DataGridViewTextBoxColumn();
            colStudentCode = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            colMidterm = new DataGridViewTextBoxColumn();
            colFinal = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnImport = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
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
            // btnBrowse
            // 
            btnBrowse.Location = new Point(20, 54);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(110, 27);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Choose file...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(140, 60);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(200, 15);
            lblFile.TabIndex = 5;
            lblFile.Text = "No file chosen (Excel .xlsx or CSV).";
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new Point(20, 92);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(300, 15);
            lblColumns.TabIndex = 6;
            lblColumns.Text = "";
            lblColumns.ForeColor = Color.DimGray;
            // 
            // chkKeepEmpty
            // 
            chkKeepEmpty.AutoSize = true;
            chkKeepEmpty.Checked = true;
            chkKeepEmpty.CheckState = CheckState.Checked;
            chkKeepEmpty.Location = new Point(20, 115);
            chkKeepEmpty.Name = "chkKeepEmpty";
            chkKeepEmpty.Size = new Size(330, 19);
            chkKeepEmpty.TabIndex = 7;
            chkKeepEmpty.Text = "Empty cells in the file keep the current score";
            chkKeepEmpty.UseVisualStyleBackColor = true;
            chkKeepEmpty.CheckedChanged += chkKeepEmpty_CheckedChanged;
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.AllowUserToResizeRows = false;
            dgvPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPreview.BackgroundColor = SystemColors.Window;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Columns.AddRange(new DataGridViewColumn[] { colRow, colStudentCode, colStudentName, colAttendance, colMidterm, colFinal, colStatus });
            dgvPreview.Location = new Point(20, 142);
            dgvPreview.MultiSelect = false;
            dgvPreview.Name = "dgvPreview";
            dgvPreview.ReadOnly = true;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreview.Size = new Size(860, 300);
            dgvPreview.TabIndex = 8;
            // 
            // colRow
            // 
            colRow.HeaderText = "Row";
            colRow.Name = "colRow";
            colRow.ReadOnly = true;
            colRow.Width = 45;
            colRow.ValueType = typeof(int);
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
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 300;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(20, 460);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(300, 15);
            lblSummary.TabIndex = 9;
            lblSummary.Text = "Choose a class, a course and a file to preview the import.";
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImport.Location = new Point(660, 453);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(115, 30);
            btnImport.TabIndex = 10;
            btnImport.Text = "Import scores";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(785, 453);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(95, 30);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormGradeImport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 495);
            Controls.Add(btnClose);
            Controls.Add(btnImport);
            Controls.Add(lblSummary);
            Controls.Add(dgvPreview);
            Controls.Add(chkKeepEmpty);
            Controls.Add(lblColumns);
            Controls.Add(lblFile);
            Controls.Add(btnBrowse);
            Controls.Add(cboCourse);
            Controls.Add(lblCourse);
            Controls.Add(cboClass);
            Controls.Add(lblClass);
            MinimumSize = new Size(760, 400);
            Name = "FormGradeImport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import Grades from Excel or CSV";
            Load += FormGradeImport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClass;
        private ComboBox cboClass;
        private Label lblCourse;
        private ComboBox cboCourse;
        private Button btnBrowse;
        private Label lblFile;
        private Label lblColumns;
        private CheckBox chkKeepEmpty;
        private DataGridView dgvPreview;
        private DataGridViewTextBoxColumn colRow;
        private DataGridViewTextBoxColumn colStudentCode;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colAttendance;
        private DataGridViewTextBoxColumn colMidterm;
        private DataGridViewTextBoxColumn colFinal;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblSummary;
        private Button btnImport;
        private Button btnClose;
    }
}
