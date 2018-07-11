namespace TimeTracking3
{
    partial class ManualAddTime
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
            this.TTTreeView = new System.Windows.Forms.TreeView();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.HoursInput = new System.Windows.Forms.TextBox();
            this.MinutesInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddTimeButton = new System.Windows.Forms.Button();
            this.lblSelectedTask = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TTTreeView
            // 
            this.TTTreeView.Location = new System.Drawing.Point(12, 12);
            this.TTTreeView.Name = "TTTreeView";
            this.TTTreeView.Size = new System.Drawing.Size(260, 261);
            this.TTTreeView.TabIndex = 2;
            this.TTTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TTTreeView_AfterSelect);
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(378, 42);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(120, 20);
            this.startDate.TabIndex = 30;
            // 
            // HoursInput
            // 
            this.HoursInput.Location = new System.Drawing.Point(378, 68);
            this.HoursInput.Name = "HoursInput";
            this.HoursInput.Size = new System.Drawing.Size(120, 20);
            this.HoursInput.TabIndex = 31;
            // 
            // MinutesInput
            // 
            this.MinutesInput.Location = new System.Drawing.Point(378, 94);
            this.MinutesInput.Name = "MinutesInput";
            this.MinutesInput.Size = new System.Drawing.Size(120, 20);
            this.MinutesInput.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Selected Task:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Hours:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Minutes:";
            // 
            // AddTimeButton
            // 
            this.AddTimeButton.Location = new System.Drawing.Point(282, 130);
            this.AddTimeButton.Name = "AddTimeButton";
            this.AddTimeButton.Size = new System.Drawing.Size(75, 23);
            this.AddTimeButton.TabIndex = 37;
            this.AddTimeButton.Text = "Add";
            this.AddTimeButton.UseVisualStyleBackColor = true;
            this.AddTimeButton.Click += new System.EventHandler(this.AddTimeButton_Click);
            // 
            // lblSelectedTask
            // 
            this.lblSelectedTask.AutoSize = true;
            this.lblSelectedTask.Location = new System.Drawing.Point(378, 13);
            this.lblSelectedTask.Name = "lblSelectedTask";
            this.lblSelectedTask.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedTask.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total Time:";
            // 
            // TotalTimeLabel
            // 
            this.TotalTimeLabel.AutoSize = true;
            this.TotalTimeLabel.Location = new System.Drawing.Point(345, 260);
            this.TotalTimeLabel.Name = "TotalTimeLabel";
            this.TotalTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.TotalTimeLabel.TabIndex = 40;
            // 
            // ManualAddTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 287);
            this.Controls.Add(this.TotalTimeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSelectedTask);
            this.Controls.Add(this.AddTimeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinutesInput);
            this.Controls.Add(this.HoursInput);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.TTTreeView);
            this.Name = "ManualAddTime";
            this.Text = "ManualTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TTTreeView;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox HoursInput;
        private System.Windows.Forms.TextBox MinutesInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddTimeButton;
        private System.Windows.Forms.Label lblSelectedTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TotalTimeLabel;
    }
}