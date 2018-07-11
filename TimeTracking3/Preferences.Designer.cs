namespace TimeTracking3
{
    partial class Preferences
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
            this.label1 = new System.Windows.Forms.Label();
            this.chbRoundTimes = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.RoundTimesGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblActualTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRoundTime = new System.Windows.Forms.Label();
            this.roundedTimeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RoundTimeComboBox = new System.Windows.Forms.ComboBox();
            this.RoundTimesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show Rounded Times in Report:\r\n";
            this.roundedTimeToolTip.SetToolTip(this.label1, "This will cause an additional line to appear on the report screen that displays t" +
        "he time rounded to a particular hour fraction\r\n");
            // 
            // chbRoundTimes
            // 
            this.chbRoundTimes.AutoSize = true;
            this.chbRoundTimes.Location = new System.Drawing.Point(180, 12);
            this.chbRoundTimes.Name = "chbRoundTimes";
            this.chbRoundTimes.Size = new System.Drawing.Size(44, 17);
            this.chbRoundTimes.TabIndex = 1;
            this.chbRoundTimes.Text = "Yes";
            this.chbRoundTimes.UseVisualStyleBackColor = true;
            this.chbRoundTimes.CheckedChanged += new System.EventHandler(this.chbRoundTimes_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RoundTimesGroupBox
            // 
            this.RoundTimesGroupBox.Controls.Add(this.RoundTimeComboBox);
            this.RoundTimesGroupBox.Controls.Add(this.lblRoundTime);
            this.RoundTimesGroupBox.Controls.Add(this.label4);
            this.RoundTimesGroupBox.Controls.Add(this.lblActualTime);
            this.RoundTimesGroupBox.Controls.Add(this.label3);
            this.RoundTimesGroupBox.Controls.Add(this.label2);
            this.RoundTimesGroupBox.Location = new System.Drawing.Point(16, 29);
            this.RoundTimesGroupBox.Name = "RoundTimesGroupBox";
            this.RoundTimesGroupBox.Size = new System.Drawing.Size(299, 72);
            this.RoundTimesGroupBox.TabIndex = 9;
            this.RoundTimesGroupBox.TabStop = false;
            this.RoundTimesGroupBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "=";
            // 
            // lblActualTime
            // 
            this.lblActualTime.AutoSize = true;
            this.lblActualTime.Location = new System.Drawing.Point(87, 44);
            this.lblActualTime.Name = "lblActualTime";
            this.lblActualTime.Size = new System.Drawing.Size(43, 13);
            this.lblActualTime.TabIndex = 11;
            this.lblActualTime.Text = "1:38:25";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Example:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Round times to the nearest:";
            // 
            // lblRoundTime
            // 
            this.lblRoundTime.AutoSize = true;
            this.lblRoundTime.Location = new System.Drawing.Point(149, 47);
            this.lblRoundTime.Name = "lblRoundTime";
            this.lblRoundTime.Size = new System.Drawing.Size(0, 13);
            this.lblRoundTime.TabIndex = 13;
            // 
            // RoundTimeComboBox
            // 
            this.RoundTimeComboBox.FormattingEnabled = true;
            this.RoundTimeComboBox.Items.AddRange(new object[] {
            "0.5",
            "0.25",
            "0.2",
            "0.1",
            "0.05",
            "0.025",
            "0.01"});
            this.RoundTimeComboBox.Location = new System.Drawing.Point(150, 21);
            this.RoundTimeComboBox.Name = "RoundTimeComboBox";
            this.RoundTimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.RoundTimeComboBox.TabIndex = 14;
            this.RoundTimeComboBox.SelectedIndexChanged += new System.EventHandler(this.RoundTimeComboBox_SelectedIndexChanged);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 404);
            this.Controls.Add(this.RoundTimesGroupBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbRoundTimes);
            this.Controls.Add(this.label1);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.RoundTimesGroupBox.ResumeLayout(false);
            this.RoundTimesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbRoundTimes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox RoundTimesGroupBox;
        private System.Windows.Forms.Label lblRoundTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblActualTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip roundedTimeToolTip;
        private System.Windows.Forms.ComboBox RoundTimeComboBox;
    }
}