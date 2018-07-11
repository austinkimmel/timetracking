namespace TimeTracking3
{
    partial class ImportSharePoint
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
            this.ProjectsDropDown = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectsDropDown
            // 
            this.ProjectsDropDown.FormattingEnabled = true;
            this.ProjectsDropDown.Location = new System.Drawing.Point(13, 13);
            this.ProjectsDropDown.Name = "ProjectsDropDown";
            this.ProjectsDropDown.Size = new System.Drawing.Size(479, 21);
            this.ProjectsDropDown.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(509, 13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox
            // 
            this.groupBox.AutoSize = true;
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.Location = new System.Drawing.Point(13, 42);
            this.groupBox.MinimumSize = new System.Drawing.Size(650, 20);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(650, 20);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "SharePointData";
            this.groupBox.Enter += new System.EventHandler(this.groupBox_Enter);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(597, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ImportSharePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(684, 162);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.ProjectsDropDown);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "ImportSharePoint";
            this.Text = "ImportSharePoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProjectsDropDown;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnImport;
    }
}