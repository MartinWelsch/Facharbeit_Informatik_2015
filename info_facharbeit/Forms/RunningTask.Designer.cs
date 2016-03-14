namespace info_facharbeit {
    partial class RunningTask {
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
            this.labelHappiness = new System.Windows.Forms.Label();
            this.buttonFinalize = new System.Windows.Forms.Button();
            this.backgroundWorkerStatisticUpdater = new System.ComponentModel.BackgroundWorker();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNotInChoice = new System.Windows.Forms.Label();
            this.labelUnassigned = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewStudentsPerChoice = new System.Windows.Forms.DataGridView();
            this.choice_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.students_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentsPerChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHappiness
            // 
            this.labelHappiness.AutoSize = true;
            this.labelHappiness.Location = new System.Drawing.Point(13, 44);
            this.labelHappiness.MinimumSize = new System.Drawing.Size(300, 0);
            this.labelHappiness.Name = "labelHappiness";
            this.labelHappiness.Size = new System.Drawing.Size(300, 13);
            this.labelHappiness.TabIndex = 0;
            this.labelHappiness.Text = "%";
            this.labelHappiness.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonFinalize
            // 
            this.buttonFinalize.Location = new System.Drawing.Point(255, 296);
            this.buttonFinalize.Name = "buttonFinalize";
            this.buttonFinalize.Size = new System.Drawing.Size(75, 23);
            this.buttonFinalize.TabIndex = 1;
            this.buttonFinalize.Text = "finalize";
            this.buttonFinalize.UseVisualStyleBackColor = true;
            this.buttonFinalize.Click += new System.EventHandler(this.buttonFinalize_Click);
            // 
            // backgroundWorkerStatisticUpdater
            // 
            this.backgroundWorkerStatisticUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStatisticUpdater_DoWork);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(255, 296);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewStudentsPerChoice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelNotInChoice);
            this.panel1.Controls.Add(this.labelUnassigned);
            this.panel1.Controls.Add(this.labelHappiness);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 278);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "not in any choosen course:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "unassigned:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "global happiness:";
            // 
            // labelNotInChoice
            // 
            this.labelNotInChoice.AutoSize = true;
            this.labelNotInChoice.Location = new System.Drawing.Point(13, 57);
            this.labelNotInChoice.MinimumSize = new System.Drawing.Size(300, 0);
            this.labelNotInChoice.Name = "labelNotInChoice";
            this.labelNotInChoice.Size = new System.Drawing.Size(300, 13);
            this.labelNotInChoice.TabIndex = 2;
            this.labelNotInChoice.Text = "0";
            this.labelNotInChoice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelUnassigned
            // 
            this.labelUnassigned.AutoSize = true;
            this.labelUnassigned.Location = new System.Drawing.Point(13, 70);
            this.labelUnassigned.MinimumSize = new System.Drawing.Size(300, 0);
            this.labelUnassigned.Name = "labelUnassigned";
            this.labelUnassigned.Size = new System.Drawing.Size(300, 13);
            this.labelUnassigned.TabIndex = 1;
            this.labelUnassigned.Text = "0";
            this.labelUnassigned.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(174, 296);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Visible = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.FileName = "list.csv";
            this.saveFileDialogExport.Filter = "All files|*.*";
            this.saveFileDialogExport.InitialDirectory = "%desktop%";
            this.saveFileDialogExport.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogExport_FileOk);
            // 
            // dataGridViewStudentsPerChoice
            // 
            this.dataGridViewStudentsPerChoice.AllowUserToAddRows = false;
            this.dataGridViewStudentsPerChoice.AllowUserToDeleteRows = false;
            this.dataGridViewStudentsPerChoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentsPerChoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.choice_index,
            this.students_in});
            this.dataGridViewStudentsPerChoice.Location = new System.Drawing.Point(0, 105);
            this.dataGridViewStudentsPerChoice.Name = "dataGridViewStudentsPerChoice";
            this.dataGridViewStudentsPerChoice.ReadOnly = true;
            this.dataGridViewStudentsPerChoice.Size = new System.Drawing.Size(315, 170);
            this.dataGridViewStudentsPerChoice.TabIndex = 6;
            // 
            // choice_index
            // 
            this.choice_index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.choice_index.DataPropertyName = "choice_index";
            this.choice_index.HeaderText = "Choice index";
            this.choice_index.Name = "choice_index";
            this.choice_index.ReadOnly = true;
            // 
            // students_in
            // 
            this.students_in.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.students_in.DataPropertyName = "students_in";
            this.students_in.HeaderText = "Students";
            this.students_in.Name = "students_in";
            this.students_in.ReadOnly = true;
            // 
            // RunningTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 331);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonFinalize);
            this.Name = "RunningTask";
            this.Text = "RunningTask";
            this.Load += new System.EventHandler(this.RunningTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentsPerChoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHappiness;
        private System.Windows.Forms.Button buttonFinalize;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStatisticUpdater;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNotInChoice;
        private System.Windows.Forms.Label labelUnassigned;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.DataGridView dataGridViewStudentsPerChoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn choice_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn students_in;
    }
}