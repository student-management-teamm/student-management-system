namespace StudentManagementWinForms
{
    partial class ClassForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblClasses = new Label();
            dgvClasses = new DataGridView();
            btnLoad = new Button();
            dgvStudents = new DataGridView();
            lblStudents = new Label();
            grpTeacher = new GroupBox();
            lblDepartment = new Label();
            lblSubject = new Label();
            lblTeacherName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            grpTeacher.SuspendLayout();
            SuspendLayout();
            // 
            // lblClasses
            // 
            lblClasses.AutoSize = true;
            lblClasses.Location = new Point(12, 9);
            lblClasses.Name = "lblClasses";
            lblClasses.Size = new Size(129, 15);
            lblClasses.TabIndex = 0;
            lblClasses.Text = "DANH SÁCH LỚP HỌC";
            lblClasses.Click += label1_Click;
            // 
            // dgvClasses
            // 
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.AllowUserToDeleteRows = false;
            dgvClasses.AllowUserToResizeColumns = false;
            dgvClasses.AllowUserToResizeRows = false;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.BackgroundColor = SystemColors.Window;
            dgvClasses.BorderStyle = BorderStyle.Fixed3D;
            dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasses.Location = new Point(23, 27);
            dgvClasses.MultiSelect = false;
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(417, 135);
            dgvClasses.TabIndex = 1;
            dgvClasses.CellContentClick += dgvClasses_CellContentClick;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(465, 27);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(147, 30);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Tải danh sách";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AllowUserToResizeColumns = false;
            dgvStudents.AllowUserToResizeRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = SystemColors.Window;
            dgvStudents.BorderStyle = BorderStyle.Fixed3D;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.GridColor = SystemColors.Window;
            dgvStudents.Location = new Point(23, 199);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(417, 182);
            dgvStudents.TabIndex = 5;
            // 
            // lblStudents
            // 
            lblStudents.AutoSize = true;
            lblStudents.Location = new Point(12, 181);
            lblStudents.Name = "lblStudents";
            lblStudents.Size = new Size(133, 15);
            lblStudents.TabIndex = 6;
            lblStudents.Text = "DANH SÁCH SINH VIÊN";
            lblStudents.Click += lblStudents_Click;
            // 
            // grpTeacher
            // 
            grpTeacher.Controls.Add(lblDepartment);
            grpTeacher.Controls.Add(lblSubject);
            grpTeacher.Controls.Add(lblTeacherName);
            grpTeacher.Location = new Point(446, 77);
            grpTeacher.Name = "grpTeacher";
            grpTeacher.Size = new Size(329, 304);
            grpTeacher.TabIndex = 7;
            grpTeacher.TabStop = false;
            grpTeacher.Text = "GIẢNG VIÊN PHỤ TRÁCH";
            grpTeacher.Enter += grpTeacher_Enter;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(19, 19);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(37, 15);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Khoa:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(19, 122);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(58, 15);
            lblSubject.TabIndex = 1;
            lblSubject.Text = "Môn học:";
            // 
            // lblTeacherName
            // 
            lblTeacherName.Location = new Point(19, 45);
            lblTeacherName.Name = "lblTeacherName";
            lblTeacherName.Size = new Size(66, 15);
            lblTeacherName.TabIndex = 0;
            lblTeacherName.Text = "Giảng viên:";
            // 
            // ClassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 394);
            Controls.Add(grpTeacher);
            Controls.Add(lblStudents);
            Controls.Add(dgvStudents);
            Controls.Add(btnLoad);
            Controls.Add(dgvClasses);
            Controls.Add(lblClasses);
            Name = "ClassForm";
            Text = "Quản lý lớp học";
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            grpTeacher.ResumeLayout(false);
            grpTeacher.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblClasses;
        private DataGridView dgvClasses;
        private Button btnLoad;
        private DataGridView dgvStudents;
        private Label lblStudents;
        private GroupBox grpTeacher;
        private Label lblDepartment;
        private Label lblSubject;
        private Label lblTeacherName;
    }
}