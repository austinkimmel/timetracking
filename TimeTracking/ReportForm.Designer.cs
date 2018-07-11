namespace TimeTracking
{
    partial class ReportForm
    {
        ///// <summary>
        ///// Required designer variable.
        ///// </summary>
        //private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //#region Windows Form Designer generated code

        ///// <summary>
        ///// Required method for Designer support - do not modify
        ///// the contents of this method with the code editor.
        ///// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        //    this.ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //    this.ReportsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //    this.btnBack = new System.Windows.Forms.Button();
        //    this.btnFetch = new System.Windows.Forms.Button();
        //    this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
        //    this.cbTypes = new System.Windows.Forms.ComboBox();
        //    this.cbTasks = new System.Windows.Forms.ComboBox();
        //    this.pickerFrom = new System.Windows.Forms.DateTimePicker();
        //    this.pickerTo = new System.Windows.Forms.DateTimePicker();
        //    this.label1 = new System.Windows.Forms.Label();
        //    this.InteruptionsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //    ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.ReportsDataBindingSource)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.InteruptionsDataBindingSource)).BeginInit();
        //    this.SuspendLayout();
        //    // 
        //    // btnBack
        //    // 
        //    this.btnBack.Location = new System.Drawing.Point(12, 12);
        //    this.btnBack.Name = "btnBack";
        //    this.btnBack.Size = new System.Drawing.Size(75, 23);
        //    this.btnBack.TabIndex = 3;
        //    this.btnBack.Text = "<< BACK";
        //    this.btnBack.UseVisualStyleBackColor = true;
        //    this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
        //    // 
        //    // btnFetch
        //    // 
        //    this.btnFetch.Location = new System.Drawing.Point(215, 673);
        //    this.btnFetch.Name = "btnFetch";
        //    this.btnFetch.Size = new System.Drawing.Size(75, 23);
        //    this.btnFetch.TabIndex = 6;
        //    this.btnFetch.Text = "Fetch data";
        //    this.btnFetch.UseVisualStyleBackColor = true;
        //    this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
        //    // 
        //    // reportViewer1
        //    // 
        //    reportDataSource1.Name = "DataSet1";
        //    reportDataSource1.Value = this.ReportBindingSource;
        //    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
        //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "TimeTracking.Report7.rdlc";
        //    this.reportViewer1.Location = new System.Drawing.Point(12, 55);
        //    this.reportViewer1.Name = "reportViewer1";
        //    this.reportViewer1.Size = new System.Drawing.Size(1346, 543);
        //    this.reportViewer1.TabIndex = 7;
        //    this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
        //    // 
        //    // cbTypes
        //    // 
        //    this.cbTypes.FormattingEnabled = true;
        //    this.cbTypes.Location = new System.Drawing.Point(276, 604);
        //    this.cbTypes.Name = "cbTypes";
        //    this.cbTypes.Size = new System.Drawing.Size(226, 21);
        //    this.cbTypes.Sorted = true;
        //    this.cbTypes.TabIndex = 8;
        //    this.cbTypes.Text = "Please select one";
        //    this.cbTypes.SelectedIndexChanged += new System.EventHandler(this.cbTypes_SelectedIndexChanged);
        //    // 
        //    // cbTasks
        //    // 
        //    this.cbTasks.FormattingEnabled = true;
        //    this.cbTasks.Location = new System.Drawing.Point(276, 630);
        //    this.cbTasks.Name = "cbTasks";
        //    this.cbTasks.Size = new System.Drawing.Size(226, 21);
        //    this.cbTasks.Sorted = true;
        //    this.cbTasks.TabIndex = 9;
        //    this.cbTasks.Text = "Please select one";
        //    // 
        //    // pickerFrom
        //    // 
        //    this.pickerFrom.Location = new System.Drawing.Point(28, 604);
        //    this.pickerFrom.Name = "pickerFrom";
        //    this.pickerFrom.Size = new System.Drawing.Size(200, 20);
        //    this.pickerFrom.TabIndex = 10;
        //    this.pickerFrom.Value = new System.DateTime(2012, 7, 20, 0, 0, 0, 0);
        //    // 
        //    // pickerTo
        //    // 
        //    this.pickerTo.Location = new System.Drawing.Point(28, 630);
        //    this.pickerTo.Name = "pickerTo";
        //    this.pickerTo.Size = new System.Drawing.Size(200, 20);
        //    this.pickerTo.TabIndex = 11;
        //    this.pickerTo.Value = new System.DateTime(2012, 7, 20, 0, 0, 0, 0);
        //    // 
        //    // label1
        //    // 
        //    this.label1.AutoSize = true;
        //    this.label1.Location = new System.Drawing.Point(137, 653);
        //    this.label1.Name = "label1";
        //    this.label1.Size = new System.Drawing.Size(91, 13);
        //    this.label1.TabIndex = 12;
        //    this.label1.Text = "Through 11:59pm";
        //    // 
        //    // InteruptionsDataBindingSource
        //    // 
        //    this.InteruptionsDataBindingSource.DataMember = "Data";
        //    this.InteruptionsDataBindingSource.DataSource = typeof(TimeTracking.InteruptionsData);
        //    // 
        //    // ReportForm
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.AutoScroll = true;
        //    this.ClientSize = new System.Drawing.Size(1362, 706);
        //    this.ControlBox = false;
        //    this.Controls.Add(this.label1);
        //    this.Controls.Add(this.pickerTo);
        //    this.Controls.Add(this.pickerFrom);
        //    this.Controls.Add(this.cbTasks);
        //    this.Controls.Add(this.cbTypes);
        //    this.Controls.Add(this.reportViewer1);
        //    this.Controls.Add(this.btnFetch);
        //    this.Controls.Add(this.btnBack);
        //    this.Name = "ReportForm";
        //    this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        //    this.Text = "Time report";
        //    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //    this.Load += new System.EventHandler(this.ReportForm_Load);
        //    ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.ReportsDataBindingSource)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.InteruptionsDataBindingSource)).EndInit();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

        //#endregion

        //private System.Windows.Forms.Button btnBack;
        //private System.Windows.Forms.Button btnFetch;
        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        //private System.Windows.Forms.BindingSource ReportsDataBindingSource;
        //private System.Windows.Forms.BindingSource ReportBindingSource;
        //private System.Windows.Forms.BindingSource InteruptionsDataBindingSource;
        //private System.Windows.Forms.ComboBox cbTypes;
        //private System.Windows.Forms.ComboBox cbTasks;
        //private System.Windows.Forms.DateTimePicker pickerFrom;
        //private System.Windows.Forms.DateTimePicker pickerTo;
        //private System.Windows.Forms.Label label1;
    }
}