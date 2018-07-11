namespace TimeTracking
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbTaskList = new System.Windows.Forms.ComboBox();
            this.btnStartRecord = new System.Windows.Forms.Button();
            this.btnEndRecord = new System.Windows.Forms.Button();
            this.lblTimerDisplay = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnMaintainTasks = new System.Windows.Forms.Button();
            this.timerTask = new System.Windows.Forms.Timer(this.components);
            this.btnReportView = new System.Windows.Forms.Button();
            this.chkPomodoro = new System.Windows.Forms.CheckBox();
            this.btnPomodoroReport = new System.Windows.Forms.Button();
            this.lblPomodoroTime = new System.Windows.Forms.Label();
            this.pomodoroTimer = new System.Windows.Forms.Timer(this.components);
            this.btnInteruptions = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnMaintainType = new System.Windows.Forms.Button();
            this.btnMaintainLogs = new System.Windows.Forms.Button();
            this.btnManualTime = new System.Windows.Forms.Button();
            this.btnClearLock = new System.Windows.Forms.Button();
            this.cbTasks2 = new System.Windows.Forms.ComboBox();
            this.btnMaintainTasks2 = new System.Windows.Forms.Button();
            this.lblLastTask = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalTimeDay = new System.Windows.Forms.Label();
            this.lblTotalTimeWeek = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWorkWeek = new System.Windows.Forms.Label();
            this.lblTotalWorkWeek = new System.Windows.Forms.Label();
            this.lblTotalWorkDay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnManageNonWorking = new System.Windows.Forms.Button();
            this.chkCww = new System.Windows.Forms.CheckBox();
            this.chkHaveCww = new System.Windows.Forms.CheckBox();
            this.btnSetPresets = new System.Windows.Forms.Button();
            this.btnPreset1 = new System.Windows.Forms.Button();
            this.pnlHotButtons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblSmallTime = new System.Windows.Forms.Label();
            this.btnRecordQuick = new System.Windows.Forms.Button();
            this.btnPauseQuick = new System.Windows.Forms.Button();
            this.btnStartQuick = new System.Windows.Forms.Button();
            this.btnPreset5 = new System.Windows.Forms.Button();
            this.btnPreset4 = new System.Windows.Forms.Button();
            this.btnQuick = new System.Windows.Forms.Button();
            this.btnPreset3 = new System.Windows.Forms.Button();
            this.btnPreset2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.pnlHotButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTaskList
            // 
            this.cbTaskList.Enabled = false;
            this.cbTaskList.FormattingEnabled = true;
            this.cbTaskList.Location = new System.Drawing.Point(103, 166);
            this.cbTaskList.Name = "cbTaskList";
            this.cbTaskList.Size = new System.Drawing.Size(219, 21);
            this.cbTaskList.Sorted = true;
            this.cbTaskList.TabIndex = 0;
            this.cbTaskList.Text = "Please choose one...";
            this.cbTaskList.SelectedIndexChanged += new System.EventHandler(this.cbTaskList_SelectedIndexChanged);
            // 
            // btnStartRecord
            // 
            this.btnStartRecord.Location = new System.Drawing.Point(629, 121);
            this.btnStartRecord.Name = "btnStartRecord";
            this.btnStartRecord.Size = new System.Drawing.Size(75, 23);
            this.btnStartRecord.TabIndex = 1;
            this.btnStartRecord.Text = "Start";
            this.btnStartRecord.UseVisualStyleBackColor = true;
            this.btnStartRecord.Click += new System.EventHandler(this.btnStartRecord_Click);
            // 
            // btnEndRecord
            // 
            this.btnEndRecord.Enabled = false;
            this.btnEndRecord.Location = new System.Drawing.Point(629, 150);
            this.btnEndRecord.Name = "btnEndRecord";
            this.btnEndRecord.Size = new System.Drawing.Size(75, 23);
            this.btnEndRecord.TabIndex = 2;
            this.btnEndRecord.Text = "End";
            this.btnEndRecord.UseVisualStyleBackColor = true;
            this.btnEndRecord.Click += new System.EventHandler(this.btnEndRecord_Click);
            // 
            // lblTimerDisplay
            // 
            this.lblTimerDisplay.AutoSize = true;
            this.lblTimerDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.lblTimerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerDisplay.Location = new System.Drawing.Point(103, 293);
            this.lblTimerDisplay.Name = "lblTimerDisplay";
            this.lblTimerDisplay.Size = new System.Drawing.Size(130, 55);
            this.lblTimerDisplay.TabIndex = 3;
            this.lblTimerDisplay.Text = "Time";
            // 
            // btnCommit
            // 
            this.btnCommit.Enabled = false;
            this.btnCommit.Location = new System.Drawing.Point(629, 180);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnMaintainTasks
            // 
            this.btnMaintainTasks.Enabled = false;
            this.btnMaintainTasks.Location = new System.Drawing.Point(327, 164);
            this.btnMaintainTasks.Name = "btnMaintainTasks";
            this.btnMaintainTasks.Size = new System.Drawing.Size(102, 23);
            this.btnMaintainTasks.TabIndex = 5;
            this.btnMaintainTasks.Text = "Maintain tasks";
            this.btnMaintainTasks.UseVisualStyleBackColor = true;
            this.btnMaintainTasks.Click += new System.EventHandler(this.btnMaintainTasks_Click);
            // 
            // timerTask
            // 
            this.timerTask.Interval = 1000;
            this.timerTask.Tick += new System.EventHandler(this.timerTask_Tick);
            // 
            // btnReportView
            // 
            this.btnReportView.Location = new System.Drawing.Point(103, 527);
            this.btnReportView.Name = "btnReportView";
            this.btnReportView.Size = new System.Drawing.Size(101, 23);
            this.btnReportView.TabIndex = 7;
            this.btnReportView.Text = "View time data";
            this.btnReportView.UseVisualStyleBackColor = true;
            this.btnReportView.Click += new System.EventHandler(this.btnReportView_Click);
            // 
            // chkPomodoro
            // 
            this.chkPomodoro.AutoSize = true;
            this.chkPomodoro.Location = new System.Drawing.Point(697, 558);
            this.chkPomodoro.Name = "chkPomodoro";
            this.chkPomodoro.Size = new System.Drawing.Size(74, 17);
            this.chkPomodoro.TabIndex = 8;
            this.chkPomodoro.Text = "Pomodoro";
            this.chkPomodoro.UseVisualStyleBackColor = true;
            // 
            // btnPomodoroReport
            // 
            this.btnPomodoroReport.Location = new System.Drawing.Point(220, 527);
            this.btnPomodoroReport.Name = "btnPomodoroReport";
            this.btnPomodoroReport.Size = new System.Drawing.Size(118, 23);
            this.btnPomodoroReport.TabIndex = 9;
            this.btnPomodoroReport.Text = "View pomodoro data";
            this.btnPomodoroReport.UseVisualStyleBackColor = true;
            this.btnPomodoroReport.Click += new System.EventHandler(this.btnPomodoroReport_Click);
            // 
            // lblPomodoroTime
            // 
            this.lblPomodoroTime.AutoSize = true;
            this.lblPomodoroTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblPomodoroTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPomodoroTime.Location = new System.Drawing.Point(633, 505);
            this.lblPomodoroTime.Name = "lblPomodoroTime";
            this.lblPomodoroTime.Size = new System.Drawing.Size(138, 31);
            this.lblPomodoroTime.TabIndex = 10;
            this.lblPomodoroTime.Text = "Pomodoro";
            // 
            // pomodoroTimer
            // 
            this.pomodoroTimer.Interval = 1000;
            this.pomodoroTimer.Tick += new System.EventHandler(this.pomodoroTimer_Tick);
            // 
            // btnInteruptions
            // 
            this.btnInteruptions.Location = new System.Drawing.Point(354, 527);
            this.btnInteruptions.Name = "btnInteruptions";
            this.btnInteruptions.Size = new System.Drawing.Size(126, 23);
            this.btnInteruptions.TabIndex = 12;
            this.btnInteruptions.Text = "View interuptions data";
            this.btnInteruptions.UseVisualStyleBackColor = true;
            this.btnInteruptions.Click += new System.EventHandler(this.btnInteruptions_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(103, 123);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(219, 21);
            this.cbType.Sorted = true;
            this.cbType.TabIndex = 13;
            this.cbType.Text = "Please choose one...";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnMaintainType
            // 
            this.btnMaintainType.Location = new System.Drawing.Point(328, 121);
            this.btnMaintainType.Name = "btnMaintainType";
            this.btnMaintainType.Size = new System.Drawing.Size(101, 23);
            this.btnMaintainType.TabIndex = 14;
            this.btnMaintainType.Text = "Maintain types";
            this.btnMaintainType.UseVisualStyleBackColor = true;
            this.btnMaintainType.Click += new System.EventHandler(this.btnMaintainType_Click);
            // 
            // btnMaintainLogs
            // 
            this.btnMaintainLogs.Location = new System.Drawing.Point(605, 321);
            this.btnMaintainLogs.Name = "btnMaintainLogs";
            this.btnMaintainLogs.Size = new System.Drawing.Size(109, 23);
            this.btnMaintainLogs.TabIndex = 15;
            this.btnMaintainLogs.Text = "Maintain logs";
            this.btnMaintainLogs.UseVisualStyleBackColor = true;
            this.btnMaintainLogs.Click += new System.EventHandler(this.btnMaintainLogs_Click);
            // 
            // btnManualTime
            // 
            this.btnManualTime.Location = new System.Drawing.Point(113, 395);
            this.btnManualTime.Name = "btnManualTime";
            this.btnManualTime.Size = new System.Drawing.Size(155, 23);
            this.btnManualTime.TabIndex = 21;
            this.btnManualTime.Text = "Manual time management";
            this.btnManualTime.UseVisualStyleBackColor = true;
            this.btnManualTime.Click += new System.EventHandler(this.btnManualTime_Click);
            // 
            // btnClearLock
            // 
            this.btnClearLock.Enabled = false;
            this.btnClearLock.Location = new System.Drawing.Point(629, 210);
            this.btnClearLock.Name = "btnClearLock";
            this.btnClearLock.Size = new System.Drawing.Size(75, 23);
            this.btnClearLock.TabIndex = 22;
            this.btnClearLock.Text = "Clear";
            this.btnClearLock.UseVisualStyleBackColor = true;
            this.btnClearLock.Click += new System.EventHandler(this.btnClearLock_Click);
            // 
            // cbTasks2
            // 
            this.cbTasks2.Enabled = false;
            this.cbTasks2.FormattingEnabled = true;
            this.cbTasks2.Location = new System.Drawing.Point(103, 212);
            this.cbTasks2.Name = "cbTasks2";
            this.cbTasks2.Size = new System.Drawing.Size(219, 21);
            this.cbTasks2.Sorted = true;
            this.cbTasks2.TabIndex = 23;
            // 
            // btnMaintainTasks2
            // 
            this.btnMaintainTasks2.Enabled = false;
            this.btnMaintainTasks2.Location = new System.Drawing.Point(328, 210);
            this.btnMaintainTasks2.Name = "btnMaintainTasks2";
            this.btnMaintainTasks2.Size = new System.Drawing.Size(119, 23);
            this.btnMaintainTasks2.TabIndex = 24;
            this.btnMaintainTasks2.Text = "Maintain sub tasks";
            this.btnMaintainTasks2.UseVisualStyleBackColor = true;
            this.btnMaintainTasks2.Click += new System.EventHandler(this.btnMaintainTasks2_Click);
            // 
            // lblLastTask
            // 
            this.lblLastTask.AutoSize = true;
            this.lblLastTask.BackColor = System.Drawing.SystemColors.Control;
            this.lblLastTask.Location = new System.Drawing.Point(110, 454);
            this.lblLastTask.Name = "lblLastTask";
            this.lblLastTask.Size = new System.Drawing.Size(35, 13);
            this.lblLastTask.TabIndex = 25;
            this.lblLastTask.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(100, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Last task:";
            // 
            // lblTotalTimeDay
            // 
            this.lblTotalTimeDay.AutoSize = true;
            this.lblTotalTimeDay.Location = new System.Drawing.Point(65, 19);
            this.lblTotalTimeDay.Name = "lblTotalTimeDay";
            this.lblTotalTimeDay.Size = new System.Drawing.Size(35, 13);
            this.lblTotalTimeDay.TabIndex = 27;
            this.lblTotalTimeDay.Text = "label2";
            // 
            // lblTotalTimeWeek
            // 
            this.lblTotalTimeWeek.AutoSize = true;
            this.lblTotalTimeWeek.Location = new System.Drawing.Point(65, 35);
            this.lblTotalTimeWeek.Name = "lblTotalTimeWeek";
            this.lblTotalTimeWeek.Size = new System.Drawing.Size(35, 13);
            this.lblTotalTimeWeek.TabIndex = 28;
            this.lblTotalTimeWeek.Text = "label3";
            this.lblTotalTimeWeek.Click += new System.EventHandler(this.lblTotalTimeWeek_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lblRemaining);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblWorkWeek);
            this.groupBox1.Controls.Add(this.lblTotalWorkWeek);
            this.groupBox1.Controls.Add(this.lblTotalWorkDay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTotalTimeDay);
            this.groupBox1.Controls.Add(this.lblTotalTimeWeek);
            this.groupBox1.Location = new System.Drawing.Point(330, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 161);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time summary";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(72, 121);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(35, 13);
            this.lblRemaining.TabIndex = 36;
            this.lblRemaining.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-1, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Remaining:";
            // 
            // lblWorkWeek
            // 
            this.lblWorkWeek.AutoSize = true;
            this.lblWorkWeek.Location = new System.Drawing.Point(-1, 75);
            this.lblWorkWeek.Name = "lblWorkWeek";
            this.lblWorkWeek.Size = new System.Drawing.Size(65, 13);
            this.lblWorkWeek.TabIndex = 34;
            this.lblWorkWeek.Text = "Work week:";
            // 
            // lblTotalWorkWeek
            // 
            this.lblTotalWorkWeek.AutoSize = true;
            this.lblTotalWorkWeek.Location = new System.Drawing.Point(65, 75);
            this.lblTotalWorkWeek.Name = "lblTotalWorkWeek";
            this.lblTotalWorkWeek.Size = new System.Drawing.Size(35, 13);
            this.lblTotalWorkWeek.TabIndex = 33;
            this.lblTotalWorkWeek.Text = "label5";
            // 
            // lblTotalWorkDay
            // 
            this.lblTotalWorkDay.AutoSize = true;
            this.lblTotalWorkDay.Location = new System.Drawing.Point(65, 58);
            this.lblTotalWorkDay.Name = "lblTotalWorkDay";
            this.lblTotalWorkDay.Size = new System.Drawing.Size(35, 13);
            this.lblTotalWorkDay.TabIndex = 32;
            this.lblTotalWorkDay.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Work day:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Week:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Day:";
            // 
            // btnManageNonWorking
            // 
            this.btnManageNonWorking.Location = new System.Drawing.Point(639, 381);
            this.btnManageNonWorking.Name = "btnManageNonWorking";
            this.btnManageNonWorking.Size = new System.Drawing.Size(75, 61);
            this.btnManageNonWorking.TabIndex = 30;
            this.btnManageNonWorking.Text = "Manage NON working hours tasks";
            this.btnManageNonWorking.UseVisualStyleBackColor = true;
            this.btnManageNonWorking.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkCww
            // 
            this.chkCww.AutoSize = true;
            this.chkCww.Location = new System.Drawing.Point(357, 286);
            this.chkCww.Name = "chkCww";
            this.chkCww.Size = new System.Drawing.Size(84, 17);
            this.chkCww.TabIndex = 31;
            this.chkCww.Text = "CWW week";
            this.chkCww.UseVisualStyleBackColor = true;
            this.chkCww.Visible = false;
            this.chkCww.CheckedChanged += new System.EventHandler(this.chkCww_CheckedChanged);
            // 
            // chkHaveCww
            // 
            this.chkHaveCww.AutoSize = true;
            this.chkHaveCww.Location = new System.Drawing.Point(357, 264);
            this.chkHaveCww.Name = "chkHaveCww";
            this.chkHaveCww.Size = new System.Drawing.Size(118, 17);
            this.chkHaveCww.TabIndex = 32;
            this.chkHaveCww.Text = "On CWW schedule";
            this.chkHaveCww.UseVisualStyleBackColor = true;
            this.chkHaveCww.CheckedChanged += new System.EventHandler(this.chkHaveCww_CheckedChanged);
            // 
            // btnSetPresets
            // 
            this.btnSetPresets.Location = new System.Drawing.Point(-1, 67);
            this.btnSetPresets.Name = "btnSetPresets";
            this.btnSetPresets.Size = new System.Drawing.Size(75, 23);
            this.btnSetPresets.TabIndex = 33;
            this.btnSetPresets.Text = "Set Pre-sets";
            this.btnSetPresets.UseVisualStyleBackColor = true;
            this.btnSetPresets.Click += new System.EventHandler(this.btnSetPresets_Click);
            // 
            // btnPreset1
            // 
            this.btnPreset1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset1.Location = new System.Drawing.Point(3, 3);
            this.btnPreset1.Name = "btnPreset1";
            this.btnPreset1.Size = new System.Drawing.Size(125, 60);
            this.btnPreset1.TabIndex = 34;
            this.btnPreset1.Text = "#1";
            this.toolTip1.SetToolTip(this.btnPreset1, "Test");
            this.btnPreset1.UseVisualStyleBackColor = true;
            this.btnPreset1.Visible = false;
            this.btnPreset1.Click += new System.EventHandler(this.btnPreset1_Click);
            // 
            // pnlHotButtons
            // 
            this.pnlHotButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHotButtons.Controls.Add(this.button1);
            this.pnlHotButtons.Controls.Add(this.lblTask);
            this.pnlHotButtons.Controls.Add(this.lblSmallTime);
            this.pnlHotButtons.Controls.Add(this.btnRecordQuick);
            this.pnlHotButtons.Controls.Add(this.btnPauseQuick);
            this.pnlHotButtons.Controls.Add(this.btnStartQuick);
            this.pnlHotButtons.Controls.Add(this.btnPreset5);
            this.pnlHotButtons.Controls.Add(this.btnPreset4);
            this.pnlHotButtons.Controls.Add(this.btnQuick);
            this.pnlHotButtons.Controls.Add(this.btnPreset3);
            this.pnlHotButtons.Controls.Add(this.btnPreset2);
            this.pnlHotButtons.Controls.Add(this.btnPreset1);
            this.pnlHotButtons.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlHotButtons.Location = new System.Drawing.Point(-1, -2);
            this.pnlHotButtons.Name = "pnlHotButtons";
            this.pnlHotButtons.Size = new System.Drawing.Size(814, 66);
            this.pnlHotButtons.TabIndex = 35;
            this.pnlHotButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHotButtons_Paint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.Location = new System.Drawing.Point(782, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "m";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblTask
            // 
            this.lblTask.Location = new System.Drawing.Point(634, 27);
            this.lblTask.MaximumSize = new System.Drawing.Size(125, 20);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(124, 20);
            this.lblTask.TabIndex = 41;
            this.lblTask.Text = "Task";
            // 
            // lblSmallTime
            // 
            this.lblSmallTime.AutoSize = true;
            this.lblSmallTime.Location = new System.Drawing.Point(627, 27);
            this.lblSmallTime.Name = "lblSmallTime";
            this.lblSmallTime.Size = new System.Drawing.Size(0, 13);
            this.lblSmallTime.TabIndex = 40;
            // 
            // btnRecordQuick
            // 
            this.btnRecordQuick.Enabled = false;
            this.btnRecordQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordQuick.Location = new System.Drawing.Point(664, 2);
            this.btnRecordQuick.Name = "btnRecordQuick";
            this.btnRecordQuick.Size = new System.Drawing.Size(20, 20);
            this.btnRecordQuick.TabIndex = 39;
            this.btnRecordQuick.Text = "O";
            this.btnRecordQuick.UseVisualStyleBackColor = true;
            this.btnRecordQuick.Click += new System.EventHandler(this.btnRecordQuick_Click);
            // 
            // btnPauseQuick
            // 
            this.btnPauseQuick.Enabled = false;
            this.btnPauseQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseQuick.Location = new System.Drawing.Point(645, 2);
            this.btnPauseQuick.Name = "btnPauseQuick";
            this.btnPauseQuick.Size = new System.Drawing.Size(20, 20);
            this.btnPauseQuick.TabIndex = 37;
            this.btnPauseQuick.Text = "||";
            this.btnPauseQuick.UseVisualStyleBackColor = true;
            this.btnPauseQuick.Click += new System.EventHandler(this.btnPauseQuick_Click);
            // 
            // btnStartQuick
            // 
            this.btnStartQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartQuick.Location = new System.Drawing.Point(626, 2);
            this.btnStartQuick.Name = "btnStartQuick";
            this.btnStartQuick.Size = new System.Drawing.Size(20, 20);
            this.btnStartQuick.TabIndex = 36;
            this.btnStartQuick.Text = ">";
            this.btnStartQuick.UseVisualStyleBackColor = true;
            this.btnStartQuick.Click += new System.EventHandler(this.btnStartQuick_Click);
            // 
            // btnPreset5
            // 
            this.btnPreset5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset5.Location = new System.Drawing.Point(502, 3);
            this.btnPreset5.Name = "btnPreset5";
            this.btnPreset5.Size = new System.Drawing.Size(125, 60);
            this.btnPreset5.TabIndex = 38;
            this.btnPreset5.Text = "#5";
            this.btnPreset5.UseVisualStyleBackColor = true;
            this.btnPreset5.Visible = false;
            this.btnPreset5.Click += new System.EventHandler(this.btnPreset5_Click);
            // 
            // btnPreset4
            // 
            this.btnPreset4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset4.Location = new System.Drawing.Point(377, 3);
            this.btnPreset4.Name = "btnPreset4";
            this.btnPreset4.Size = new System.Drawing.Size(125, 60);
            this.btnPreset4.TabIndex = 37;
            this.btnPreset4.Text = "#4";
            this.btnPreset4.UseVisualStyleBackColor = true;
            this.btnPreset4.Visible = false;
            this.btnPreset4.Click += new System.EventHandler(this.btnPreset4_Click);
            // 
            // btnQuick
            // 
            this.btnQuick.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnQuick.Location = new System.Drawing.Point(764, 14);
            this.btnQuick.Name = "btnQuick";
            this.btnQuick.Size = new System.Drawing.Size(18, 23);
            this.btnQuick.TabIndex = 36;
            this.btnQuick.Text = "l";
            this.btnQuick.UseVisualStyleBackColor = true;
            this.btnQuick.Click += new System.EventHandler(this.btnQuick_Click);
            // 
            // btnPreset3
            // 
            this.btnPreset3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset3.Location = new System.Drawing.Point(252, 3);
            this.btnPreset3.Name = "btnPreset3";
            this.btnPreset3.Size = new System.Drawing.Size(125, 60);
            this.btnPreset3.TabIndex = 36;
            this.btnPreset3.Text = "#3";
            this.btnPreset3.UseVisualStyleBackColor = true;
            this.btnPreset3.Visible = false;
            this.btnPreset3.Click += new System.EventHandler(this.btnPreset3_Click);
            // 
            // btnPreset2
            // 
            this.btnPreset2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreset2.Location = new System.Drawing.Point(127, 3);
            this.btnPreset2.Name = "btnPreset2";
            this.btnPreset2.Size = new System.Drawing.Size(125, 60);
            this.btnPreset2.TabIndex = 35;
            this.btnPreset2.Text = "#2";
            this.btnPreset2.UseVisualStyleBackColor = true;
            this.btnPreset2.Visible = false;
            this.btnPreset2.Click += new System.EventHandler(this.btnPreset2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(813, 581);
            this.Controls.Add(this.lblTimerDisplay);
            this.Controls.Add(this.pnlHotButtons);
            this.Controls.Add(this.btnSetPresets);
            this.Controls.Add(this.chkHaveCww);
            this.Controls.Add(this.chkCww);
            this.Controls.Add(this.btnManageNonWorking);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLastTask);
            this.Controls.Add(this.btnMaintainTasks2);
            this.Controls.Add(this.cbTasks2);
            this.Controls.Add(this.btnClearLock);
            this.Controls.Add(this.btnManualTime);
            this.Controls.Add(this.btnMaintainLogs);
            this.Controls.Add(this.btnMaintainType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.btnInteruptions);
            this.Controls.Add(this.lblPomodoroTime);
            this.Controls.Add(this.btnPomodoroReport);
            this.Controls.Add(this.chkPomodoro);
            this.Controls.Add(this.btnReportView);
            this.Controls.Add(this.btnMaintainTasks);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnEndRecord);
            this.Controls.Add(this.btnStartRecord);
            this.Controls.Add(this.cbTaskList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Time recording";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlHotButtons.ResumeLayout(false);
            this.pnlHotButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartRecord;
        private System.Windows.Forms.Button btnEndRecord;
        private System.Windows.Forms.Label lblTimerDisplay;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnMaintainTasks;
        internal System.Windows.Forms.ComboBox cbTaskList;
        private System.Windows.Forms.Timer timerTask;
        private System.Windows.Forms.Button btnReportView;
        private System.Windows.Forms.CheckBox chkPomodoro;
        private System.Windows.Forms.Button btnPomodoroReport;
        private System.Windows.Forms.Label lblPomodoroTime;
        private System.Windows.Forms.Timer pomodoroTimer;
        private System.Windows.Forms.Button btnInteruptions;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnMaintainType;
        private System.Windows.Forms.Button btnMaintainLogs;
        private System.Windows.Forms.Button btnManualTime;
        private System.Windows.Forms.Button btnClearLock;
        internal System.Windows.Forms.ComboBox cbTasks2;
        private System.Windows.Forms.Button btnMaintainTasks2;
        private System.Windows.Forms.Label lblLastTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalTimeDay;
        private System.Windows.Forms.Label lblTotalTimeWeek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnManageNonWorking;
        private System.Windows.Forms.Label lblWorkWeek;
        private System.Windows.Forms.Label lblTotalWorkWeek;
        private System.Windows.Forms.Label lblTotalWorkDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCww;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkHaveCww;
        private System.Windows.Forms.Button btnSetPresets;
        private System.Windows.Forms.Button btnPreset1;
        private System.Windows.Forms.Panel pnlHotButtons;
        private System.Windows.Forms.Button btnPreset4;
        private System.Windows.Forms.Button btnPreset3;
        private System.Windows.Forms.Button btnPreset2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnQuick;
        private System.Windows.Forms.Button btnPreset5;
        private System.Windows.Forms.Button btnRecordQuick;
        private System.Windows.Forms.Button btnPauseQuick;
        private System.Windows.Forms.Button btnStartQuick;
        private System.Windows.Forms.Label lblSmallTime;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button button1;
    }
}

