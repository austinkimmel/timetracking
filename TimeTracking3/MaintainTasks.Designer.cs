namespace TimeTracking3
{
    partial class MaintainTasks
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TypesListBox = new System.Windows.Forms.ListBox();
            this.btnNewType = new System.Windows.Forms.Button();
            this.txtNewType = new System.Windows.Forms.TextBox();
            this.chbDeleteTasksSubTasks = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.AvailableTasksListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentTasksListBox = new System.Windows.Forms.ListBox();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AvailableTaskSubTaskListBox = new System.Windows.Forms.ListBox();
            this.lblAvailableTasksSubTasks = new System.Windows.Forms.Label();
            this.btnAddSubTask = new System.Windows.Forms.Button();
            this.AvailableSubTasksListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentSubTasksListBox = new System.Windows.Forms.ListBox();
            this.btnDeleteSubTask = new System.Windows.Forms.Button();
            this.btnNewSubTask = new System.Windows.Forms.Button();
            this.txtNewSubTask = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypesListBox);
            this.groupBox1.Controls.Add(this.btnNewType);
            this.groupBox1.Controls.Add(this.txtNewType);
            this.groupBox1.Controls.Add(this.chbDeleteTasksSubTasks);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 461);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Types";
            // 
            // TypesListBox
            // 
            this.TypesListBox.FormattingEnabled = true;
            this.TypesListBox.Location = new System.Drawing.Point(6, 41);
            this.TypesListBox.Name = "TypesListBox";
            this.TypesListBox.Size = new System.Drawing.Size(250, 407);
            this.TypesListBox.TabIndex = 11;
            this.TypesListBox.SelectedIndexChanged += new System.EventHandler(this.TypesListBox_SelectedIndexChanged);
            // 
            // btnNewType
            // 
            this.btnNewType.Location = new System.Drawing.Point(262, 12);
            this.btnNewType.Name = "btnNewType";
            this.btnNewType.Size = new System.Drawing.Size(75, 23);
            this.btnNewType.TabIndex = 10;
            this.btnNewType.Text = "Add Type";
            this.btnNewType.UseVisualStyleBackColor = true;
            this.btnNewType.Click += new System.EventHandler(this.btnNewType_Click);
            // 
            // txtNewType
            // 
            this.txtNewType.Location = new System.Drawing.Point(6, 14);
            this.txtNewType.Name = "txtNewType";
            this.txtNewType.Size = new System.Drawing.Size(250, 20);
            this.txtNewType.TabIndex = 9;
            // 
            // chbDeleteTasksSubTasks
            // 
            this.chbDeleteTasksSubTasks.Enabled = false;
            this.chbDeleteTasksSubTasks.Location = new System.Drawing.Point(258, 382);
            this.chbDeleteTasksSubTasks.Name = "chbDeleteTasksSubTasks";
            this.chbDeleteTasksSubTasks.Size = new System.Drawing.Size(104, 63);
            this.chbDeleteTasksSubTasks.TabIndex = 8;
            this.chbDeleteTasksSubTasks.Text = "Delete Tasks/Sub Tasks not used in other Types?";
            this.chbDeleteTasksSubTasks.UseVisualStyleBackColor = true;
            this.chbDeleteTasksSubTasks.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(262, 353);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete Type";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.btnAddTask);
            this.groupBox2.Controls.Add(this.AvailableTasksListBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CurrentTasksListBox);
            this.groupBox2.Controls.Add(this.btnNewTask);
            this.groupBox2.Controls.Add(this.txtNewTask);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.btnDeleteTask);
            this.groupBox2.Location = new System.Drawing.Point(377, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 461);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tasks";
            // 
            // checkBox3
            // 
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(266, 337);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 63);
            this.checkBox3.TabIndex = 19;
            this.checkBox3.Text = "Add All Subtasks";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(266, 269);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 18;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // AvailableTasksListBox
            // 
            this.AvailableTasksListBox.FormattingEnabled = true;
            this.AvailableTasksListBox.Location = new System.Drawing.Point(10, 266);
            this.AvailableTasksListBox.Name = "AvailableTasksListBox";
            this.AvailableTasksListBox.Size = new System.Drawing.Size(250, 173);
            this.AvailableTasksListBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Available Tasks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Tasks";
            // 
            // CurrentTasksListBox
            // 
            this.CurrentTasksListBox.FormattingEnabled = true;
            this.CurrentTasksListBox.Location = new System.Drawing.Point(6, 67);
            this.CurrentTasksListBox.Name = "CurrentTasksListBox";
            this.CurrentTasksListBox.Size = new System.Drawing.Size(250, 173);
            this.CurrentTasksListBox.TabIndex = 11;
            this.CurrentTasksListBox.SelectedIndexChanged += new System.EventHandler(this.CurrentTasksListBox_SelectedIndexChanged);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(262, 17);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(75, 23);
            this.btnNewTask.TabIndex = 10;
            this.btnNewTask.Text = "New Task";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // txtNewTask
            // 
            this.txtNewTask.Location = new System.Drawing.Point(6, 14);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(250, 20);
            this.txtNewTask.TabIndex = 9;
            // 
            // checkBox2
            // 
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(262, 181);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 63);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Delete Sub Tasks not used in other Tasks?";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(262, 152);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AvailableTaskSubTaskListBox);
            this.groupBox3.Controls.Add(this.lblAvailableTasksSubTasks);
            this.groupBox3.Controls.Add(this.btnAddSubTask);
            this.groupBox3.Controls.Add(this.AvailableSubTasksListBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.CurrentSubTasksListBox);
            this.groupBox3.Controls.Add(this.btnDeleteSubTask);
            this.groupBox3.Controls.Add(this.btnNewSubTask);
            this.groupBox3.Controls.Add(this.txtNewSubTask);
            this.groupBox3.Location = new System.Drawing.Point(745, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 461);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sub Tasks";
            // 
            // AvailableTaskSubTaskListBox
            // 
            this.AvailableTaskSubTaskListBox.FormattingEnabled = true;
            this.AvailableTaskSubTaskListBox.Location = new System.Drawing.Point(6, 334);
            this.AvailableTaskSubTaskListBox.Name = "AvailableTaskSubTaskListBox";
            this.AvailableTaskSubTaskListBox.Size = new System.Drawing.Size(250, 121);
            this.AvailableTaskSubTaskListBox.TabIndex = 28;
            this.AvailableTaskSubTaskListBox.Visible = false;
            // 
            // lblAvailableTasksSubTasks
            // 
            this.lblAvailableTasksSubTasks.AutoSize = true;
            this.lblAvailableTasksSubTasks.Location = new System.Drawing.Point(7, 318);
            this.lblAvailableTasksSubTasks.Name = "lblAvailableTasksSubTasks";
            this.lblAvailableTasksSubTasks.Size = new System.Drawing.Size(131, 13);
            this.lblAvailableTasksSubTasks.TabIndex = 27;
            this.lblAvailableTasksSubTasks.Text = "Available Task Sub Tasks";
            this.lblAvailableTasksSubTasks.Visible = false;
            // 
            // btnAddSubTask
            // 
            this.btnAddSubTask.Location = new System.Drawing.Point(262, 194);
            this.btnAddSubTask.Name = "btnAddSubTask";
            this.btnAddSubTask.Size = new System.Drawing.Size(89, 23);
            this.btnAddSubTask.TabIndex = 26;
            this.btnAddSubTask.Text = "Add Subtask";
            this.btnAddSubTask.UseVisualStyleBackColor = true;
            this.btnAddSubTask.Click += new System.EventHandler(this.btnAddSubTask_Click);
            // 
            // AvailableSubTasksListBox
            // 
            this.AvailableSubTasksListBox.FormattingEnabled = true;
            this.AvailableSubTasksListBox.Location = new System.Drawing.Point(6, 194);
            this.AvailableSubTasksListBox.Name = "AvailableSubTasksListBox";
            this.AvailableSubTasksListBox.Size = new System.Drawing.Size(250, 121);
            this.AvailableSubTasksListBox.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Available Sub Tasks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Current Sub Tasks";
            // 
            // CurrentSubTasksListBox
            // 
            this.CurrentSubTasksListBox.FormattingEnabled = true;
            this.CurrentSubTasksListBox.Location = new System.Drawing.Point(6, 67);
            this.CurrentSubTasksListBox.Name = "CurrentSubTasksListBox";
            this.CurrentSubTasksListBox.Size = new System.Drawing.Size(250, 108);
            this.CurrentSubTasksListBox.TabIndex = 21;
            // 
            // btnDeleteSubTask
            // 
            this.btnDeleteSubTask.Location = new System.Drawing.Point(262, 67);
            this.btnDeleteSubTask.Name = "btnDeleteSubTask";
            this.btnDeleteSubTask.Size = new System.Drawing.Size(92, 23);
            this.btnDeleteSubTask.TabIndex = 19;
            this.btnDeleteSubTask.Text = "Delete Subtask";
            this.btnDeleteSubTask.UseVisualStyleBackColor = true;
            this.btnDeleteSubTask.Click += new System.EventHandler(this.btnDeleteSubTask_Click);
            // 
            // btnNewSubTask
            // 
            this.btnNewSubTask.Location = new System.Drawing.Point(262, 14);
            this.btnNewSubTask.Name = "btnNewSubTask";
            this.btnNewSubTask.Size = new System.Drawing.Size(95, 23);
            this.btnNewSubTask.TabIndex = 10;
            this.btnNewSubTask.Text = "New Subtask";
            this.btnNewSubTask.UseVisualStyleBackColor = true;
            this.btnNewSubTask.Click += new System.EventHandler(this.btnNewSubTask_Click);
            // 
            // txtNewSubTask
            // 
            this.txtNewSubTask.Location = new System.Drawing.Point(6, 14);
            this.txtNewSubTask.Name = "txtNewSubTask";
            this.txtNewSubTask.Size = new System.Drawing.Size(250, 20);
            this.txtNewSubTask.TabIndex = 9;
            // 
            // MaintainTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 485);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MaintainTasks";
            this.Text = "MaintainTasks";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox TypesListBox;
        private System.Windows.Forms.Button btnNewType;
        private System.Windows.Forms.TextBox txtNewType;
        private System.Windows.Forms.CheckBox chbDeleteTasksSubTasks;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CurrentTasksListBox;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNewSubTask;
        private System.Windows.Forms.TextBox txtNewSubTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListBox AvailableTasksListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddSubTask;
        private System.Windows.Forms.ListBox AvailableSubTasksListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox CurrentSubTasksListBox;
        private System.Windows.Forms.Button btnDeleteSubTask;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox AvailableTaskSubTaskListBox;
        private System.Windows.Forms.Label lblAvailableTasksSubTasks;
    }
}