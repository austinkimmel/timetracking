namespace TimeTracking
{
    partial class LogMaintenanceForm
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
            this.btnClearPomodoro = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnClearInteruptions = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdateTimeLog = new System.Windows.Forms.Button();
            this.txtReplaceTaskName = new System.Windows.Forms.TextBox();
            this.txtReplaceTaskId = new System.Windows.Forms.TextBox();
            this.cbTaskList = new System.Windows.Forms.ComboBox();
            this.chkUpdateTaskName = new System.Windows.Forms.CheckBox();
            this.chkUpdateType = new System.Windows.Forms.CheckBox();
            this.cbTypeList = new System.Windows.Forms.ComboBox();
            this.txtReplaceType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClearPomodoro
            // 
            this.btnClearPomodoro.Location = new System.Drawing.Point(130, 354);
            this.btnClearPomodoro.Name = "btnClearPomodoro";
            this.btnClearPomodoro.Size = new System.Drawing.Size(109, 23);
            this.btnClearPomodoro.TabIndex = 13;
            this.btnClearPomodoro.Text = "Clear pomodoro log";
            this.btnClearPomodoro.UseVisualStyleBackColor = true;
            this.btnClearPomodoro.Click += new System.EventHandler(this.btnClearPomodoro_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(44, 354);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 23);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "Clear time log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnClearInteruptions
            // 
            this.btnClearInteruptions.Location = new System.Drawing.Point(247, 354);
            this.btnClearInteruptions.Name = "btnClearInteruptions";
            this.btnClearInteruptions.Size = new System.Drawing.Size(119, 23);
            this.btnClearInteruptions.TabIndex = 14;
            this.btnClearInteruptions.Text = "Clear interuptions log";
            this.btnClearInteruptions.UseVisualStyleBackColor = true;
            this.btnClearInteruptions.Click += new System.EventHandler(this.btnClearInteruptions_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "<< BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUpdateTimeLog
            // 
            this.btnUpdateTimeLog.Location = new System.Drawing.Point(129, 229);
            this.btnUpdateTimeLog.Name = "btnUpdateTimeLog";
            this.btnUpdateTimeLog.Size = new System.Drawing.Size(134, 23);
            this.btnUpdateTimeLog.TabIndex = 21;
            this.btnUpdateTimeLog.Text = "Update time log tasks";
            this.btnUpdateTimeLog.UseVisualStyleBackColor = true;
            this.btnUpdateTimeLog.Click += new System.EventHandler(this.btnUpdateTimeLog_Click);
            // 
            // txtReplaceTaskName
            // 
            this.txtReplaceTaskName.Location = new System.Drawing.Point(117, 105);
            this.txtReplaceTaskName.Name = "txtReplaceTaskName";
            this.txtReplaceTaskName.Size = new System.Drawing.Size(169, 20);
            this.txtReplaceTaskName.TabIndex = 20;
            this.txtReplaceTaskName.Text = "Replacement task name";
            // 
            // txtReplaceTaskId
            // 
            this.txtReplaceTaskId.Location = new System.Drawing.Point(117, 79);
            this.txtReplaceTaskId.Name = "txtReplaceTaskId";
            this.txtReplaceTaskId.Size = new System.Drawing.Size(169, 20);
            this.txtReplaceTaskId.TabIndex = 19;
            this.txtReplaceTaskId.Text = "Replacement task ID";
            // 
            // cbTaskList
            // 
            this.cbTaskList.FormattingEnabled = true;
            this.cbTaskList.Location = new System.Drawing.Point(118, 52);
            this.cbTaskList.Name = "cbTaskList";
            this.cbTaskList.Size = new System.Drawing.Size(169, 21);
            this.cbTaskList.TabIndex = 50;
            this.cbTaskList.Text = "Please select one";
            this.cbTaskList.SelectedIndexChanged += new System.EventHandler(this.cbTaskList_SelectedIndexChanged);
            // 
            // chkUpdateTaskName
            // 
            this.chkUpdateTaskName.AutoSize = true;
            this.chkUpdateTaskName.Checked = true;
            this.chkUpdateTaskName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateTaskName.Location = new System.Drawing.Point(294, 52);
            this.chkUpdateTaskName.Name = "chkUpdateTaskName";
            this.chkUpdateTaskName.Size = new System.Drawing.Size(113, 17);
            this.chkUpdateTaskName.TabIndex = 22;
            this.chkUpdateTaskName.Text = "Update task name";
            this.chkUpdateTaskName.UseVisualStyleBackColor = true;
            // 
            // chkUpdateType
            // 
            this.chkUpdateType.AutoSize = true;
            this.chkUpdateType.Checked = true;
            this.chkUpdateType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateType.Location = new System.Drawing.Point(293, 161);
            this.chkUpdateType.Name = "chkUpdateType";
            this.chkUpdateType.Size = new System.Drawing.Size(113, 17);
            this.chkUpdateType.TabIndex = 27;
            this.chkUpdateType.Text = "Update type name";
            this.chkUpdateType.UseVisualStyleBackColor = true;
            // 
            // cbTypeList
            // 
            this.cbTypeList.FormattingEnabled = true;
            this.cbTypeList.Location = new System.Drawing.Point(117, 161);
            this.cbTypeList.Name = "cbTypeList";
            this.cbTypeList.Size = new System.Drawing.Size(169, 21);
            this.cbTypeList.TabIndex = 24;
            this.cbTypeList.Text = "Please select one";
            // 
            // txtReplaceType
            // 
            this.txtReplaceType.Location = new System.Drawing.Point(116, 188);
            this.txtReplaceType.Name = "txtReplaceType";
            this.txtReplaceType.Size = new System.Drawing.Size(169, 20);
            this.txtReplaceType.TabIndex = 23;
            this.txtReplaceType.Text = "Replacement type name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Type";
            // 
            // LogMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 389);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkUpdateType);
            this.Controls.Add(this.cbTypeList);
            this.Controls.Add(this.txtReplaceType);
            this.Controls.Add(this.chkUpdateTaskName);
            this.Controls.Add(this.cbTaskList);
            this.Controls.Add(this.txtReplaceTaskId);
            this.Controls.Add(this.txtReplaceTaskName);
            this.Controls.Add(this.btnUpdateTimeLog);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClearInteruptions);
            this.Controls.Add(this.btnClearPomodoro);
            this.Controls.Add(this.btnClearLog);
            this.Name = "LogMaintenanceForm";
            this.Text = "Maintain logs";
            this.Load += new System.EventHandler(this.LogMaintenanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearPomodoro;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnClearInteruptions;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUpdateTimeLog;
        private System.Windows.Forms.TextBox txtReplaceTaskName;
        private System.Windows.Forms.TextBox txtReplaceTaskId;
        private System.Windows.Forms.ComboBox cbTaskList;
        private System.Windows.Forms.CheckBox chkUpdateTaskName;
        private System.Windows.Forms.CheckBox chkUpdateType;
        private System.Windows.Forms.ComboBox cbTypeList;
        private System.Windows.Forms.TextBox txtReplaceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}