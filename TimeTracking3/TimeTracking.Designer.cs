namespace TimeTracking3
{
    partial class TimeTracking
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
            this.components = new System.ComponentModel.Container();
            this.TTTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuallyAddTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromSharePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportActualsToSharePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hellpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedTask = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.chkStartAfterLast = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectPrevious = new System.Windows.Forms.Button();
            this.btnRecordStartTask = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalTaskTime = new System.Windows.Forms.Label();
            this.lblPreviousTask = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.txtEstimatedTaskTime = new System.Windows.Forms.TextBox();
            this.btnUpdateEstimate = new System.Windows.Forms.Button();
            this.btnShowReports = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPreviousStart = new System.Windows.Forms.Label();
            this.lblPreviousEnd = new System.Windows.Forms.Label();
            this.btnModifyTime = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TTTreeView
            // 
            this.TTTreeView.Location = new System.Drawing.Point(12, 85);
            this.TTTreeView.Name = "TTTreeView";
            this.TTTreeView.Size = new System.Drawing.Size(260, 290);
            this.TTTreeView.TabIndex = 0;
            this.TTTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TTTreeView_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintainToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(646, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.migrateDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Visible = false;
            // 
            // migrateDataToolStripMenuItem
            // 
            this.migrateDataToolStripMenuItem.Name = "migrateDataToolStripMenuItem";
            this.migrateDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.migrateDataToolStripMenuItem.Text = "Migrate Data";
            this.migrateDataToolStripMenuItem.Click += new System.EventHandler(this.migrateDataToolStripMenuItem_Click);
            // 
            // maintainToolStripMenuItem
            // 
            this.maintainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typesToolStripMenuItem,
            this.manuallyAddTimeToolStripMenuItem,
            this.importFromSharePointToolStripMenuItem,
            this.exportActualsToSharePointToolStripMenuItem});
            this.maintainToolStripMenuItem.Name = "maintainToolStripMenuItem";
            this.maintainToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.maintainToolStripMenuItem.Text = "Maintain";
            // 
            // typesToolStripMenuItem
            // 
            this.typesToolStripMenuItem.Name = "typesToolStripMenuItem";
            this.typesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.typesToolStripMenuItem.Text = "Types";
            this.typesToolStripMenuItem.Click += new System.EventHandler(this.typesToolStripMenuItem_Click);
            // 
            // manuallyAddTimeToolStripMenuItem
            // 
            this.manuallyAddTimeToolStripMenuItem.Name = "manuallyAddTimeToolStripMenuItem";
            this.manuallyAddTimeToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.manuallyAddTimeToolStripMenuItem.Text = "Manually Add Time";
            this.manuallyAddTimeToolStripMenuItem.Click += new System.EventHandler(this.manuallyAddTimeToolStripMenuItem_Click);
            // 
            // importFromSharePointToolStripMenuItem
            // 
            this.importFromSharePointToolStripMenuItem.Name = "importFromSharePointToolStripMenuItem";
            this.importFromSharePointToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.importFromSharePointToolStripMenuItem.Text = "Import From SharePoint";
            this.importFromSharePointToolStripMenuItem.Click += new System.EventHandler(this.importFromSharePointToolStripMenuItem_Click);
            // 
            // exportActualsToSharePointToolStripMenuItem
            // 
            this.exportActualsToSharePointToolStripMenuItem.Name = "exportActualsToSharePointToolStripMenuItem";
            this.exportActualsToSharePointToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exportActualsToSharePointToolStripMenuItem.Text = "Export Actuals to SharePoint";
            this.exportActualsToSharePointToolStripMenuItem.Click += new System.EventHandler(this.exportActualsToSharePointToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateNotesToolStripMenuItem,
            this.hellpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // updateNotesToolStripMenuItem
            // 
            this.updateNotesToolStripMenuItem.Name = "updateNotesToolStripMenuItem";
            this.updateNotesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateNotesToolStripMenuItem.Text = "Update Notes";
            this.updateNotesToolStripMenuItem.Click += new System.EventHandler(this.updateNotesToolStripMenuItem_Click);
            // 
            // hellpToolStripMenuItem
            // 
            this.hellpToolStripMenuItem.Name = "hellpToolStripMenuItem";
            this.hellpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hellpToolStripMenuItem.Text = "Help";
            this.hellpToolStripMenuItem.Click += new System.EventHandler(this.hellpToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task";
            // 
            // lblSelectedTask
            // 
            this.lblSelectedTask.AutoSize = true;
            this.lblSelectedTask.Location = new System.Drawing.Point(154, 24);
            this.lblSelectedTask.Name = "lblSelectedTask";
            this.lblSelectedTask.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedTask.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(285, 48);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(50, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(337, 48);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(50, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(444, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(393, 48);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(50, 23);
            this.btnRecord.TabIndex = 7;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // chkStartAfterLast
            // 
            this.chkStartAfterLast.AutoSize = true;
            this.chkStartAfterLast.Location = new System.Drawing.Point(285, 78);
            this.chkStartAfterLast.Name = "chkStartAfterLast";
            this.chkStartAfterLast.Size = new System.Drawing.Size(114, 17);
            this.chkStartAfterLast.TabIndex = 8;
            this.chkStartAfterLast.Text = "Start after last task";
            this.chkStartAfterLast.UseVisualStyleBackColor = true;
            this.chkStartAfterLast.CheckedChanged += new System.EventHandler(this.chkStartAfterLast_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current Task:";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTask.Location = new System.Drawing.Point(285, 115);
            this.lblCurrentTask.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(0, 15);
            this.lblCurrentTask.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Previous Task:";
            // 
            // btnSelectPrevious
            // 
            this.btnSelectPrevious.Location = new System.Drawing.Point(572, 254);
            this.btnSelectPrevious.Name = "btnSelectPrevious";
            this.btnSelectPrevious.Size = new System.Drawing.Size(63, 34);
            this.btnSelectPrevious.TabIndex = 12;
            this.btnSelectPrevious.Text = "Select Previous";
            this.btnSelectPrevious.UseVisualStyleBackColor = true;
            this.btnSelectPrevious.Click += new System.EventHandler(this.btnSelectPrevious_Click);
            // 
            // btnRecordStartTask
            // 
            this.btnRecordStartTask.Location = new System.Drawing.Point(12, 19);
            this.btnRecordStartTask.Name = "btnRecordStartTask";
            this.btnRecordStartTask.Size = new System.Drawing.Size(101, 23);
            this.btnRecordStartTask.TabIndex = 13;
            this.btnRecordStartTask.Text = "Record/Start";
            this.btnRecordStartTask.UseVisualStyleBackColor = true;
            this.btnRecordStartTask.Click += new System.EventHandler(this.btnRecordStartTask_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(350, 155);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 20);
            this.lblTime.TabIndex = 14;
            this.lblTime.Text = "00:00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Hours";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Estimated Hours";
            // 
            // lblTotalTaskTime
            // 
            this.lblTotalTaskTime.AutoSize = true;
            this.lblTotalTaskTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTaskTime.Location = new System.Drawing.Point(14, 61);
            this.lblTotalTaskTime.Name = "lblTotalTaskTime";
            this.lblTotalTaskTime.Size = new System.Drawing.Size(57, 13);
            this.lblTotalTaskTime.TabIndex = 17;
            this.lblTotalTaskTime.Text = "00:00:00";
            // 
            // lblPreviousTask
            // 
            this.lblPreviousTask.Location = new System.Drawing.Point(288, 292);
            this.lblPreviousTask.Name = "lblPreviousTask";
            this.lblPreviousTask.Size = new System.Drawing.Size(340, 38);
            this.lblPreviousTask.TabIndex = 19;
            this.lblPreviousTask.Text = "label2";
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtEstimatedTaskTime
            // 
            this.txtEstimatedTaskTime.Location = new System.Drawing.Point(192, 63);
            this.txtEstimatedTaskTime.Name = "txtEstimatedTaskTime";
            this.txtEstimatedTaskTime.Size = new System.Drawing.Size(80, 20);
            this.txtEstimatedTaskTime.TabIndex = 20;
            // 
            // btnUpdateEstimate
            // 
            this.btnUpdateEstimate.Location = new System.Drawing.Point(82, 56);
            this.btnUpdateEstimate.Name = "btnUpdateEstimate";
            this.btnUpdateEstimate.Size = new System.Drawing.Size(104, 23);
            this.btnUpdateEstimate.TabIndex = 21;
            this.btnUpdateEstimate.Text = "Update Estimate";
            this.btnUpdateEstimate.UseVisualStyleBackColor = true;
            this.btnUpdateEstimate.Click += new System.EventHandler(this.btnUpdateEstimate_Click);
            // 
            // btnShowReports
            // 
            this.btnShowReports.Location = new System.Drawing.Point(578, 155);
            this.btnShowReports.Name = "btnShowReports";
            this.btnShowReports.Size = new System.Drawing.Size(57, 36);
            this.btnShowReports.TabIndex = 22;
            this.btnShowReports.Text = "Show Reports\r\n";
            this.btnShowReports.UseVisualStyleBackColor = true;
            this.btnShowReports.Click += new System.EventHandler(this.btnShowReports_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Start Time";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "End Time";
            // 
            // lblPreviousStart
            // 
            this.lblPreviousStart.AutoSize = true;
            this.lblPreviousStart.Location = new System.Drawing.Point(288, 340);
            this.lblPreviousStart.Name = "lblPreviousStart";
            this.lblPreviousStart.Size = new System.Drawing.Size(55, 13);
            this.lblPreviousStart.TabIndex = 31;
            this.lblPreviousStart.Text = "Start Time";
            // 
            // lblPreviousEnd
            // 
            this.lblPreviousEnd.AutoSize = true;
            this.lblPreviousEnd.Location = new System.Drawing.Point(436, 340);
            this.lblPreviousEnd.Name = "lblPreviousEnd";
            this.lblPreviousEnd.Size = new System.Drawing.Size(55, 13);
            this.lblPreviousEnd.TabIndex = 32;
            this.lblPreviousEnd.Text = "Start Time";
            // 
            // btnModifyTime
            // 
            this.btnModifyTime.Location = new System.Drawing.Point(500, 48);
            this.btnModifyTime.Name = "btnModifyTime";
            this.btnModifyTime.Size = new System.Drawing.Size(75, 23);
            this.btnModifyTime.TabIndex = 33;
            this.btnModifyTime.Text = "Modify Time";
            this.btnModifyTime.UseVisualStyleBackColor = true;
            this.btnModifyTime.Click += new System.EventHandler(this.btnModifyTime_Click);
            // 
            // TimeTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 387);
            this.Controls.Add(this.btnModifyTime);
            this.Controls.Add(this.lblPreviousEnd);
            this.Controls.Add(this.lblPreviousStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowReports);
            this.Controls.Add(this.btnUpdateEstimate);
            this.Controls.Add(this.txtEstimatedTaskTime);
            this.Controls.Add(this.lblPreviousTask);
            this.Controls.Add(this.lblTotalTaskTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnRecordStartTask);
            this.Controls.Add(this.btnSelectPrevious);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCurrentTask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkStartAfterLast);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSelectedTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TTTreeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimeTracking";
            this.Text = "Start";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TTTreeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrateDataToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedTask;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.CheckBox chkStartAfterLast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectPrevious;
        private System.Windows.Forms.Button btnRecordStartTask;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalTaskTime;
        private System.Windows.Forms.Label lblPreviousTask;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.TextBox txtEstimatedTaskTime;
        private System.Windows.Forms.Button btnUpdateEstimate;
        private System.Windows.Forms.Button btnShowReports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPreviousStart;
        private System.Windows.Forms.Label lblPreviousEnd;
        private System.Windows.Forms.ToolStripMenuItem maintainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typesToolStripMenuItem;
        private System.Windows.Forms.Button btnModifyTime;
        private System.Windows.Forms.ToolStripMenuItem importFromSharePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportActualsToSharePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuallyAddTimeToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolStripMenuItem hellpToolStripMenuItem;
    }
}

