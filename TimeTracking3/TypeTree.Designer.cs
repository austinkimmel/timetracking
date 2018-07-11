namespace TimeTracking3
{
    partial class TypeTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TTTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TTTreeView
            // 
            this.TTTreeView.Location = new System.Drawing.Point(5, 5);
            this.TTTreeView.Name = "TTTreeView";
            this.TTTreeView.Size = new System.Drawing.Size(260, 290);
            this.TTTreeView.TabIndex = 1;
            // 
            // TypeTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TTTreeView);
            this.Name = "TypeTree";
            this.Size = new System.Drawing.Size(270, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TTTreeView;
    }
}
