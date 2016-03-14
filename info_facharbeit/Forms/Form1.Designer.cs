namespace info_facharbeit {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialogImporter = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCourses = new System.Windows.Forms.TabPage();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.CoursesDataGridId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursesDataGridColoumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursesDataGridColoumnMinStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursesDataGridColoumnMaxStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAppendCourse = new System.Windows.Forms.Button();
            this.tabPageStudents = new System.Windows.Forms.TabPage();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.StudentDataGridColoumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentDataGridColoumnChoice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentDataGridColoumnChoice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentDataGridColoumnChoice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsDataGridChoices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsDataGridId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAppendStudent = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.tabPageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogImporter
            // 
            this.openFileDialogImporter.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImporter_FileOk);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            resources.ApplyResources(this.fIleToolStripMenuItem, "fIleToolStripMenuItem");
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageCourses);
            this.tabControl1.Controls.Add(this.tabPageStudents);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPageCourses
            // 
            this.tabPageCourses.Controls.Add(this.dataGridViewCourses);
            this.tabPageCourses.Controls.Add(this.buttonAppendCourse);
            resources.ApplyResources(this.tabPageCourses, "tabPageCourses");
            this.tabPageCourses.Name = "tabPageCourses";
            this.tabPageCourses.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewCourses, "dataGridViewCourses");
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoursesDataGridId,
            this.CoursesDataGridColoumnName,
            this.CoursesDataGridColoumnMinStudents,
            this.CoursesDataGridColoumnMaxStudents});
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.RowHeadersVisible = false;
            this.dataGridViewCourses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCourses.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CoursesDataGridId
            // 
            this.CoursesDataGridId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CoursesDataGridId.DataPropertyName = "Id";
            resources.ApplyResources(this.CoursesDataGridId, "CoursesDataGridId");
            this.CoursesDataGridId.Name = "CoursesDataGridId";
            this.CoursesDataGridId.ReadOnly = true;
            // 
            // CoursesDataGridColoumnName
            // 
            this.CoursesDataGridColoumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CoursesDataGridColoumnName.DataPropertyName = "Name";
            resources.ApplyResources(this.CoursesDataGridColoumnName, "CoursesDataGridColoumnName");
            this.CoursesDataGridColoumnName.Name = "CoursesDataGridColoumnName";
            this.CoursesDataGridColoumnName.ReadOnly = true;
            // 
            // CoursesDataGridColoumnMinStudents
            // 
            this.CoursesDataGridColoumnMinStudents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CoursesDataGridColoumnMinStudents.DataPropertyName = "MinStudents";
            resources.ApplyResources(this.CoursesDataGridColoumnMinStudents, "CoursesDataGridColoumnMinStudents");
            this.CoursesDataGridColoumnMinStudents.Name = "CoursesDataGridColoumnMinStudents";
            this.CoursesDataGridColoumnMinStudents.ReadOnly = true;
            // 
            // CoursesDataGridColoumnMaxStudents
            // 
            this.CoursesDataGridColoumnMaxStudents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CoursesDataGridColoumnMaxStudents.DataPropertyName = "MaxStudents";
            resources.ApplyResources(this.CoursesDataGridColoumnMaxStudents, "CoursesDataGridColoumnMaxStudents");
            this.CoursesDataGridColoumnMaxStudents.Name = "CoursesDataGridColoumnMaxStudents";
            this.CoursesDataGridColoumnMaxStudents.ReadOnly = true;
            // 
            // buttonAppendCourse
            // 
            resources.ApplyResources(this.buttonAppendCourse, "buttonAppendCourse");
            this.buttonAppendCourse.Name = "buttonAppendCourse";
            this.buttonAppendCourse.UseVisualStyleBackColor = true;
            this.buttonAppendCourse.Click += new System.EventHandler(this.buttonAppendCourse_Click);
            // 
            // tabPageStudents
            // 
            this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
            this.tabPageStudents.Controls.Add(this.buttonAppendStudent);
            resources.ApplyResources(this.tabPageStudents, "tabPageStudents");
            this.tabPageStudents.Name = "tabPageStudents";
            this.tabPageStudents.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewStudents, "dataGridViewStudents");
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentDataGridColoumnName,
            this.StudentDataGridColoumnChoice1,
            this.StudentDataGridColoumnChoice2,
            this.StudentDataGridColoumnChoice3,
            this.StudentsDataGridChoices,
            this.StudentsDataGridId});
            this.dataGridViewStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowHeadersVisible = false;
            this.dataGridViewStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewStudents.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StudentDataGridColoumnName
            // 
            this.StudentDataGridColoumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentDataGridColoumnName.DataPropertyName = "Name";
            resources.ApplyResources(this.StudentDataGridColoumnName, "StudentDataGridColoumnName");
            this.StudentDataGridColoumnName.Name = "StudentDataGridColoumnName";
            this.StudentDataGridColoumnName.ReadOnly = true;
            // 
            // StudentDataGridColoumnChoice1
            // 
            this.StudentDataGridColoumnChoice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StudentDataGridColoumnChoice1.DataPropertyName = "Choice1";
            resources.ApplyResources(this.StudentDataGridColoumnChoice1, "StudentDataGridColoumnChoice1");
            this.StudentDataGridColoumnChoice1.Name = "StudentDataGridColoumnChoice1";
            this.StudentDataGridColoumnChoice1.ReadOnly = true;
            // 
            // StudentDataGridColoumnChoice2
            // 
            this.StudentDataGridColoumnChoice2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StudentDataGridColoumnChoice2.DataPropertyName = "Choice2";
            resources.ApplyResources(this.StudentDataGridColoumnChoice2, "StudentDataGridColoumnChoice2");
            this.StudentDataGridColoumnChoice2.Name = "StudentDataGridColoumnChoice2";
            this.StudentDataGridColoumnChoice2.ReadOnly = true;
            // 
            // StudentDataGridColoumnChoice3
            // 
            this.StudentDataGridColoumnChoice3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StudentDataGridColoumnChoice3.DataPropertyName = "Choice3";
            resources.ApplyResources(this.StudentDataGridColoumnChoice3, "StudentDataGridColoumnChoice3");
            this.StudentDataGridColoumnChoice3.Name = "StudentDataGridColoumnChoice3";
            this.StudentDataGridColoumnChoice3.ReadOnly = true;
            // 
            // StudentsDataGridChoices
            // 
            this.StudentsDataGridChoices.DataPropertyName = "Choices";
            resources.ApplyResources(this.StudentsDataGridChoices, "StudentsDataGridChoices");
            this.StudentsDataGridChoices.Name = "StudentsDataGridChoices";
            this.StudentsDataGridChoices.ReadOnly = true;
            // 
            // StudentsDataGridId
            // 
            this.StudentsDataGridId.DataPropertyName = "Id";
            resources.ApplyResources(this.StudentsDataGridId, "StudentsDataGridId");
            this.StudentsDataGridId.Name = "StudentsDataGridId";
            this.StudentsDataGridId.ReadOnly = true;
            // 
            // buttonAppendStudent
            // 
            resources.ApplyResources(this.buttonAppendStudent, "buttonAppendStudent");
            this.buttonAppendStudent.Name = "buttonAppendStudent";
            this.buttonAppendStudent.UseVisualStyleBackColor = true;
            this.buttonAppendStudent.Click += new System.EventHandler(this.buttonAppendStudent_Click);
            // 
            // buttonRun
            // 
            resources.ApplyResources(this.buttonRun, "buttonRun");
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.tabPageStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogImporter;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCourses;
        private System.Windows.Forms.TabPage tabPageStudents;
        private System.Windows.Forms.Button buttonAppendCourse;
        private System.Windows.Forms.Button buttonAppendStudent;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentDataGridColoumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentDataGridColoumnChoice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentDataGridColoumnChoice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentDataGridColoumnChoice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentsDataGridChoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentsDataGridId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursesDataGridId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursesDataGridColoumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursesDataGridColoumnMinStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursesDataGridColoumnMaxStudents;
        private System.Windows.Forms.Button buttonRun;
    }
}

