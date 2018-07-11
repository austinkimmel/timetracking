namespace TimeTracking
{
    partial class PomodoroForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPhone = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBoss = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.cbCustomReasons = new System.Windows.Forms.ComboBox();
            this.btnMeeting = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddReason = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnClearCustomReasons = new System.Windows.Forms.Button();
            this.btnCustomReasonsEdt = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What was the reason for you stopping?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPhone
            // 
            this.btnPhone.Location = new System.Drawing.Point(15, 89);
            this.btnPhone.Name = "btnPhone";
            this.btnPhone.Size = new System.Drawing.Size(75, 23);
            this.btnPhone.TabIndex = 2;
            this.btnPhone.Text = "Phone call";
            this.btnPhone.UseVisualStyleBackColor = true;
            this.btnPhone.Click += new System.EventHandler(this.btnPhone_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Team member";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBoss
            // 
            this.btnBoss.Location = new System.Drawing.Point(117, 89);
            this.btnBoss.Name = "btnBoss";
            this.btnBoss.Size = new System.Drawing.Size(75, 23);
            this.btnBoss.TabIndex = 4;
            this.btnBoss.Text = "Manager";
            this.btnBoss.UseVisualStyleBackColor = true;
            this.btnBoss.Click += new System.EventHandler(this.btnBoss_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(15, 129);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnOther
            // 
            this.btnOther.Location = new System.Drawing.Point(142, 216);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(75, 23);
            this.btnOther.TabIndex = 6;
            this.btnOther.Text = "Other";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // cbCustomReasons
            // 
            this.cbCustomReasons.FormattingEnabled = true;
            this.cbCustomReasons.Location = new System.Drawing.Point(15, 218);
            this.cbCustomReasons.Name = "cbCustomReasons";
            this.cbCustomReasons.Size = new System.Drawing.Size(121, 21);
            this.cbCustomReasons.TabIndex = 7;
            this.cbCustomReasons.Text = "Select one...";
            this.cbCustomReasons.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnMeeting
            // 
            this.btnMeeting.Location = new System.Drawing.Point(117, 129);
            this.btnMeeting.Name = "btnMeeting";
            this.btnMeeting.Size = new System.Drawing.Size(75, 23);
            this.btnMeeting.TabIndex = 8;
            this.btnMeeting.Text = "Meeting";
            this.btnMeeting.UseVisualStyleBackColor = true;
            this.btnMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddReason
            // 
            this.btnAddReason.Location = new System.Drawing.Point(356, 319);
            this.btnAddReason.Name = "btnAddReason";
            this.btnAddReason.Size = new System.Drawing.Size(75, 23);
            this.btnAddReason.TabIndex = 10;
            this.btnAddReason.Text = "Add reason";
            this.btnAddReason.UseVisualStyleBackColor = true;
            this.btnAddReason.Click += new System.EventHandler(this.btnAddReason_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(183, 319);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(167, 20);
            this.txtReason.TabIndex = 11;
            // 
            // btnClearCustomReasons
            // 
            this.btnClearCustomReasons.Location = new System.Drawing.Point(104, 373);
            this.btnClearCustomReasons.Name = "btnClearCustomReasons";
            this.btnClearCustomReasons.Size = new System.Drawing.Size(132, 23);
            this.btnClearCustomReasons.TabIndex = 12;
            this.btnClearCustomReasons.Text = "Clear custom reasons";
            this.btnClearCustomReasons.UseVisualStyleBackColor = true;
            this.btnClearCustomReasons.Click += new System.EventHandler(this.btnClearCustomReasons_Click);
            // 
            // btnCustomReasonsEdt
            // 
            this.btnCustomReasonsEdt.Location = new System.Drawing.Point(242, 373);
            this.btnCustomReasonsEdt.Name = "btnCustomReasonsEdt";
            this.btnCustomReasonsEdt.Size = new System.Drawing.Size(132, 23);
            this.btnCustomReasonsEdt.TabIndex = 13;
            this.btnCustomReasonsEdt.Text = "Edit custom reasons";
            this.btnCustomReasonsEdt.UseVisualStyleBackColor = true;
            this.btnCustomReasonsEdt.Click += new System.EventHandler(this.btnCustomReasonsEdt_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(380, 373);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh reasons";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PomodoroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 408);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCustomReasonsEdt);
            this.Controls.Add(this.btnClearCustomReasons);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnAddReason);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMeeting);
            this.Controls.Add(this.cbCustomReasons);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnBoss);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPhone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "PomodoroForm";
            this.Text = "Log a reason";
            this.Load += new System.EventHandler(this.PomodoroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPhone;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBoss;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.ComboBox cbCustomReasons;
        private System.Windows.Forms.Button btnMeeting;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnClearCustomReasons;
        private System.Windows.Forms.Button btnCustomReasonsEdt;
        private System.Windows.Forms.Button btnRefresh;
    }
}