namespace TimeTracking
{
    partial class ManualTimeForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHoursDown = new System.Windows.Forms.Button();
            this.btnHoursUp = new System.Windows.Forms.Button();
            this.btnMinutesDown = new System.Windows.Forms.Button();
            this.btnMinutesUp = new System.Windows.Forms.Button();
            this.startGrpBox = new System.Windows.Forms.GroupBox();
            this.lblStartingTime = new System.Windows.Forms.Label();
            this.endingGrpBox = new System.Windows.Forms.GroupBox();
            this.btnNow = new System.Windows.Forms.Button();
            this.lblEndingTime = new System.Windows.Forms.Label();
            this.btnHoursUp2 = new System.Windows.Forms.Button();
            this.btnMinutesUp2 = new System.Windows.Forms.Button();
            this.btnHoursDown2 = new System.Windows.Forms.Button();
            this.btnMinutesDown2 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastTask = new System.Windows.Forms.Label();
            this.btnStartDaysUp = new System.Windows.Forms.Button();
            this.btnStartDaysDown = new System.Windows.Forms.Button();
            this.btnMonthsUp = new System.Windows.Forms.Button();
            this.btnMonthsDown = new System.Windows.Forms.Button();
            this.btnStartAtLast = new System.Windows.Forms.Button();
            this.btnStartAtWorkDayStart = new System.Windows.Forms.Button();
            this.lblCurrentType = new System.Windows.Forms.Label();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.lblCurrentSubTask = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startGrpBox.SuspendLayout();
            this.endingGrpBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(336, 339);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear Time";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHoursDown
            // 
            this.btnHoursDown.Location = new System.Drawing.Point(16, 59);
            this.btnHoursDown.Name = "btnHoursDown";
            this.btnHoursDown.Size = new System.Drawing.Size(75, 23);
            this.btnHoursDown.TabIndex = 24;
            this.btnHoursDown.Text = "Hours -";
            this.btnHoursDown.UseVisualStyleBackColor = true;
            this.btnHoursDown.Click += new System.EventHandler(this.btnHoursDown_Click);
            // 
            // btnHoursUp
            // 
            this.btnHoursUp.Location = new System.Drawing.Point(16, 30);
            this.btnHoursUp.Name = "btnHoursUp";
            this.btnHoursUp.Size = new System.Drawing.Size(75, 23);
            this.btnHoursUp.TabIndex = 23;
            this.btnHoursUp.Text = "Hours +";
            this.btnHoursUp.UseVisualStyleBackColor = true;
            this.btnHoursUp.Click += new System.EventHandler(this.btnHoursUp_Click);
            // 
            // btnMinutesDown
            // 
            this.btnMinutesDown.Location = new System.Drawing.Point(97, 59);
            this.btnMinutesDown.Name = "btnMinutesDown";
            this.btnMinutesDown.Size = new System.Drawing.Size(75, 23);
            this.btnMinutesDown.TabIndex = 22;
            this.btnMinutesDown.Text = "Minutes -";
            this.btnMinutesDown.UseVisualStyleBackColor = true;
            this.btnMinutesDown.Click += new System.EventHandler(this.btnMinutesDown_Click);
            // 
            // btnMinutesUp
            // 
            this.btnMinutesUp.Location = new System.Drawing.Point(97, 30);
            this.btnMinutesUp.Name = "btnMinutesUp";
            this.btnMinutesUp.Size = new System.Drawing.Size(75, 23);
            this.btnMinutesUp.TabIndex = 21;
            this.btnMinutesUp.Text = "Minutes +";
            this.btnMinutesUp.UseVisualStyleBackColor = true;
            this.btnMinutesUp.Click += new System.EventHandler(this.btnMinutesUp_Click);
            // 
            // startGrpBox
            // 
            this.startGrpBox.Controls.Add(this.lblStartingTime);
            this.startGrpBox.Controls.Add(this.btnHoursUp);
            this.startGrpBox.Controls.Add(this.btnMinutesUp);
            this.startGrpBox.Controls.Add(this.btnHoursDown);
            this.startGrpBox.Controls.Add(this.btnMinutesDown);
            this.startGrpBox.Location = new System.Drawing.Point(143, 75);
            this.startGrpBox.Name = "startGrpBox";
            this.startGrpBox.Size = new System.Drawing.Size(357, 108);
            this.startGrpBox.TabIndex = 26;
            this.startGrpBox.TabStop = false;
            this.startGrpBox.Text = "Starting time";
            // 
            // lblStartingTime
            // 
            this.lblStartingTime.AutoSize = true;
            this.lblStartingTime.Location = new System.Drawing.Point(222, 36);
            this.lblStartingTime.Name = "lblStartingTime";
            this.lblStartingTime.Size = new System.Drawing.Size(35, 13);
            this.lblStartingTime.TabIndex = 30;
            this.lblStartingTime.Text = "label2";
            // 
            // endingGrpBox
            // 
            this.endingGrpBox.Controls.Add(this.btnNow);
            this.endingGrpBox.Controls.Add(this.lblEndingTime);
            this.endingGrpBox.Controls.Add(this.btnHoursUp2);
            this.endingGrpBox.Controls.Add(this.btnMinutesUp2);
            this.endingGrpBox.Controls.Add(this.btnHoursDown2);
            this.endingGrpBox.Controls.Add(this.btnMinutesDown2);
            this.endingGrpBox.Location = new System.Drawing.Point(143, 207);
            this.endingGrpBox.Name = "endingGrpBox";
            this.endingGrpBox.Size = new System.Drawing.Size(357, 108);
            this.endingGrpBox.TabIndex = 27;
            this.endingGrpBox.TabStop = false;
            this.endingGrpBox.Text = "Ending time";
            // 
            // btnNow
            // 
            this.btnNow.Location = new System.Drawing.Point(177, 61);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(75, 23);
            this.btnNow.TabIndex = 30;
            this.btnNow.Text = "Now";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // lblEndingTime
            // 
            this.lblEndingTime.AutoSize = true;
            this.lblEndingTime.Location = new System.Drawing.Point(216, 37);
            this.lblEndingTime.Name = "lblEndingTime";
            this.lblEndingTime.Size = new System.Drawing.Size(35, 13);
            this.lblEndingTime.TabIndex = 29;
            this.lblEndingTime.Text = "label2";
            // 
            // btnHoursUp2
            // 
            this.btnHoursUp2.Location = new System.Drawing.Point(16, 32);
            this.btnHoursUp2.Name = "btnHoursUp2";
            this.btnHoursUp2.Size = new System.Drawing.Size(75, 23);
            this.btnHoursUp2.TabIndex = 27;
            this.btnHoursUp2.Text = "Hours +";
            this.btnHoursUp2.UseVisualStyleBackColor = true;
            this.btnHoursUp2.Click += new System.EventHandler(this.btnHoursUp2_Click);
            // 
            // btnMinutesUp2
            // 
            this.btnMinutesUp2.Location = new System.Drawing.Point(97, 32);
            this.btnMinutesUp2.Name = "btnMinutesUp2";
            this.btnMinutesUp2.Size = new System.Drawing.Size(75, 23);
            this.btnMinutesUp2.TabIndex = 25;
            this.btnMinutesUp2.Text = "Minutes +";
            this.btnMinutesUp2.UseVisualStyleBackColor = true;
            this.btnMinutesUp2.Click += new System.EventHandler(this.btnMinutesUp2_Click);
            // 
            // btnHoursDown2
            // 
            this.btnHoursDown2.Location = new System.Drawing.Point(16, 61);
            this.btnHoursDown2.Name = "btnHoursDown2";
            this.btnHoursDown2.Size = new System.Drawing.Size(75, 23);
            this.btnHoursDown2.TabIndex = 28;
            this.btnHoursDown2.Text = "Hours -";
            this.btnHoursDown2.UseVisualStyleBackColor = true;
            this.btnHoursDown2.Click += new System.EventHandler(this.btnHoursDown2_Click);
            // 
            // btnMinutesDown2
            // 
            this.btnMinutesDown2.Location = new System.Drawing.Point(97, 61);
            this.btnMinutesDown2.Name = "btnMinutesDown2";
            this.btnMinutesDown2.Size = new System.Drawing.Size(75, 23);
            this.btnMinutesDown2.TabIndex = 26;
            this.btnMinutesDown2.Text = "Minutes -";
            this.btnMinutesDown2.UseVisualStyleBackColor = true;
            this.btnMinutesDown2.Click += new System.EventHandler(this.btnMinutesDown2_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(171, 386);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 20);
            this.lblTime.TabIndex = 28;
            this.lblTime.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 31);
            this.label1.TabIndex = 29;
            this.label1.Text = "Total time";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(2, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(65, 23);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Last task info:";
            // 
            // lblLastTask
            // 
            this.lblLastTask.AutoSize = true;
            this.lblLastTask.Location = new System.Drawing.Point(91, 484);
            this.lblLastTask.Name = "lblLastTask";
            this.lblLastTask.Size = new System.Drawing.Size(22, 13);
            this.lblLastTask.TabIndex = 33;
            this.lblLastTask.Text = "NA";
            // 
            // btnStartDaysUp
            // 
            this.btnStartDaysUp.Location = new System.Drawing.Point(21, 125);
            this.btnStartDaysUp.Name = "btnStartDaysUp";
            this.btnStartDaysUp.Size = new System.Drawing.Size(75, 23);
            this.btnStartDaysUp.TabIndex = 31;
            this.btnStartDaysUp.Text = "Days +";
            this.btnStartDaysUp.UseVisualStyleBackColor = true;
            this.btnStartDaysUp.Click += new System.EventHandler(this.btnStartDaysUp_Click);
            // 
            // btnStartDaysDown
            // 
            this.btnStartDaysDown.Location = new System.Drawing.Point(21, 154);
            this.btnStartDaysDown.Name = "btnStartDaysDown";
            this.btnStartDaysDown.Size = new System.Drawing.Size(75, 23);
            this.btnStartDaysDown.TabIndex = 32;
            this.btnStartDaysDown.Text = "Days -";
            this.btnStartDaysDown.UseVisualStyleBackColor = true;
            this.btnStartDaysDown.Click += new System.EventHandler(this.btnStartDaysDown_Click);
            // 
            // btnMonthsUp
            // 
            this.btnMonthsUp.Location = new System.Drawing.Point(21, 210);
            this.btnMonthsUp.Name = "btnMonthsUp";
            this.btnMonthsUp.Size = new System.Drawing.Size(75, 23);
            this.btnMonthsUp.TabIndex = 34;
            this.btnMonthsUp.Text = "Months +";
            this.btnMonthsUp.UseVisualStyleBackColor = true;
            this.btnMonthsUp.Click += new System.EventHandler(this.btnMonthsUp_Click);
            // 
            // btnMonthsDown
            // 
            this.btnMonthsDown.Location = new System.Drawing.Point(21, 237);
            this.btnMonthsDown.Name = "btnMonthsDown";
            this.btnMonthsDown.Size = new System.Drawing.Size(75, 23);
            this.btnMonthsDown.TabIndex = 35;
            this.btnMonthsDown.Text = "Months -";
            this.btnMonthsDown.UseVisualStyleBackColor = true;
            this.btnMonthsDown.Click += new System.EventHandler(this.btnMonthsDown_Click);
            // 
            // btnStartAtLast
            // 
            this.btnStartAtLast.Location = new System.Drawing.Point(311, 185);
            this.btnStartAtLast.Name = "btnStartAtLast";
            this.btnStartAtLast.Size = new System.Drawing.Size(100, 23);
            this.btnStartAtLast.TabIndex = 36;
            this.btnStartAtLast.Text = "Start @ last task";
            this.btnStartAtLast.UseVisualStyleBackColor = true;
            this.btnStartAtLast.Click += new System.EventHandler(this.btnStartAtLast_Click);
            // 
            // btnStartAtWorkDayStart
            // 
            this.btnStartAtWorkDayStart.Location = new System.Drawing.Point(418, 185);
            this.btnStartAtWorkDayStart.Name = "btnStartAtWorkDayStart";
            this.btnStartAtWorkDayStart.Size = new System.Drawing.Size(75, 23);
            this.btnStartAtWorkDayStart.TabIndex = 37;
            this.btnStartAtWorkDayStart.Text = "Start @ 8am";
            this.btnStartAtWorkDayStart.UseVisualStyleBackColor = true;
            this.btnStartAtWorkDayStart.Click += new System.EventHandler(this.btnStartAtWorkDayStart_Click);
            // 
            // lblCurrentType
            // 
            this.lblCurrentType.AutoSize = true;
            this.lblCurrentType.Location = new System.Drawing.Point(143, 16);
            this.lblCurrentType.Name = "lblCurrentType";
            this.lblCurrentType.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentType.TabIndex = 38;
            this.lblCurrentType.Text = "label3";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(143, 29);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentTask.TabIndex = 39;
            this.lblCurrentTask.Text = "label4";
            // 
            // lblCurrentSubTask
            // 
            this.lblCurrentSubTask.AutoSize = true;
            this.lblCurrentSubTask.Location = new System.Drawing.Point(143, 42);
            this.lblCurrentSubTask.Name = "lblCurrentSubTask";
            this.lblCurrentSubTask.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentSubTask.TabIndex = 40;
            this.lblCurrentSubTask.Text = "label5";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentTask);
            this.groupBox1.Controls.Add(this.lblCurrentSubTask);
            this.groupBox1.Controls.Add(this.startGrpBox);
            this.groupBox1.Controls.Add(this.endingGrpBox);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblCurrentType);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.btnStartAtWorkDayStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartAtLast);
            this.groupBox1.Controls.Add(this.btnStartDaysDown);
            this.groupBox1.Controls.Add(this.btnMonthsDown);
            this.groupBox1.Controls.Add(this.btnStartDaysUp);
            this.groupBox1.Controls.Add(this.btnMonthsUp);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 440);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current item";
            // 
            // ManualTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 574);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLastTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ManualTimeForm";
            this.Text = "Manual Time";
            this.Load += new System.EventHandler(this.ManualTimeForm_Load);
            this.startGrpBox.ResumeLayout(false);
            this.startGrpBox.PerformLayout();
            this.endingGrpBox.ResumeLayout(false);
            this.endingGrpBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHoursDown;
        private System.Windows.Forms.Button btnHoursUp;
        private System.Windows.Forms.Button btnMinutesDown;
        private System.Windows.Forms.Button btnMinutesUp;
        private System.Windows.Forms.GroupBox startGrpBox;
        private System.Windows.Forms.GroupBox endingGrpBox;
        private System.Windows.Forms.Button btnHoursUp2;
        private System.Windows.Forms.Button btnMinutesUp2;
        private System.Windows.Forms.Button btnHoursDown2;
        private System.Windows.Forms.Button btnMinutesDown2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblStartingTime;
        private System.Windows.Forms.Label lblEndingTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastTask;
        private System.Windows.Forms.Button btnStartDaysUp;
        private System.Windows.Forms.Button btnStartDaysDown;
        private System.Windows.Forms.Button btnMonthsUp;
        private System.Windows.Forms.Button btnMonthsDown;
        private System.Windows.Forms.Button btnStartAtLast;
        private System.Windows.Forms.Button btnStartAtWorkDayStart;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Label lblCurrentType;
        private System.Windows.Forms.Label lblCurrentTask;
        private System.Windows.Forms.Label lblCurrentSubTask;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}