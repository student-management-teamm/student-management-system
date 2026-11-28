namespace StudentManagementWinForms.Grades
{
    partial class FormAcademicWarning
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
            lblLevel = new Label();
            cboLevel = new ComboBox();
            btnReload = new Button();
            lblRule = new Label();
            dgvWarnings = new DataGridView();
            colClass = new DataGridViewTextBoxColumn();
            colStudentCode = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colGraded = new DataGridViewTextBoxColumn();
            colFailed = new DataGridViewTextBoxColumn();
            colGpa = new DataGridViewTextBoxColumn();
            colClassification = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWarnings).BeginInit();
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
            cboClass.SelectedIndexChanged += Filter_Changed;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(240, 23);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(38, 15);
            lblLevel.TabIndex = 2;
            lblLevel.Text = "Show:";
            // 
            // cboLevel
            // 
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(285, 20);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(200, 23);
            cboLevel.TabIndex = 3;
            cboLevel.SelectedIndexChanged += Filter_Changed;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(505, 18);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(95, 27);
            btnReload.TabIndex = 4;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // lblRule
            // 
            lblRule.AutoSize = true;
            lblRule.Location = new Point(20, 55);
            lblRule.Name = "lblRule";
            lblRule.Size = new Size(400, 15);
            lblRule.TabIndex = 5;
            lblRule.Text = "";
            lblRule.ForeColor = Color.DimGray;
            // 
            // dgvWarnings
            // 
            dgvWarnings.AllowUserToAddRows = false;
            dgvWarnings.AllowUserToDeleteRows = false;
            dgvWarnings.AllowUserToResizeRows = false;
            dgvWarnings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvWarnings.BackgroundColor = SystemColors.Window;
            dgvWarnings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarnings.Columns.AddRange(new DataGridViewColumn[] { colClass, colStudentCode, colStudentName, colGraded, colFailed, colGpa, colClassification, colLevel, colReason });
            dgvWarnings.Location = new Point(20, 80);
            dgvWarnings.MultiSelect = false;
            dgvWarnings.Name = "dgvWarnings";
            dgvWarnings.ReadOnly = true;
            dgvWarnings.RowHeadersVisible = false;
            dgvWarnings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarnings.Size = new Size(960, 360);
            dgvWarnings.TabIndex = 6;
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
            colStudentName.Width = 180;
            // 
            // colGraded
            // 
            colGraded.HeaderText = "Credits graded";
            colGraded.Name = "colGraded";
            colGraded.ReadOnly = true;
            colGraded.Width = 70;
            colGraded.ValueType = typeof(int);
            // 
            // colFailed
            // 
            colFailed.HeaderText = "Credits failed";
            colFailed.Name = "colFailed";
            colFailed.ReadOnly = true;
            colFailed.Width = 70;
            colFailed.ValueType = typeof(int);
            // 
            // colGpa
            // 
            colGpa.HeaderText = "GPA";
            colGpa.Name = "colGpa";
            colGpa.ReadOnly = true;
            colGpa.Width = 55;
            colGpa.DefaultCellStyle = scoreStyle;
            colGpa.ValueType = typeof(decimal);
            // 
            // colClassification
            // 
            colClassification.HeaderText = "Classification";
            colClassification.Name = "colClassification";
            colClassification.ReadOnly = true;
            colClassification.Width = 95;
            // 
            // colLevel
            // 
            colLevel.HeaderText = "Warning";
            colLevel.Name = "colLevel";
            colLevel.ReadOnly = true;
            colLevel.Width = 80;
            // 
            // colReason
            // 
            colReason.HeaderText = "Reason";
            colReason.Name = "colReason";
            colReason.ReadOnly = true;
            colReason.Width = 260;
            colReason.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(20, 455);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(300, 15);
            lblSummary.TabIndex = 7;
            lblSummary.Text = "";
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // FormAcademicWarning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 485);
            Controls.Add(lblSummary);
            Controls.Add(dgvWarnings);
            Controls.Add(lblRule);
            Controls.Add(btnReload);
            Controls.Add(cboLevel);
            Controls.Add(lblLevel);
            Controls.Add(cboClass);
            Controls.Add(lblClass);
            MinimumSize = new Size(760, 380);
            Name = "FormAcademicWarning";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Academic Warnings";
            Load += FormAcademicWarning_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWarnings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClass;
        private ComboBox cboClass;
        private Label lblLevel;
        private ComboBox cboLevel;
        private Button btnReload;
        private Label lblRule;
        private DataGridView dgvWarnings;
        private DataGridViewTextBoxColumn colClass;
        private DataGridViewTextBoxColumn colStudentCode;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colGraded;
        private DataGridViewTextBoxColumn colFailed;
        private DataGridViewTextBoxColumn colGpa;
        private DataGridViewTextBoxColumn colClassification;
        private DataGridViewTextBoxColumn colLevel;
        private DataGridViewTextBoxColumn colReason;
        private Label lblSummary;
    }
}
