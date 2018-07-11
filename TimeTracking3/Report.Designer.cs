namespace TimeTracking3
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.TTTreeView = new System.Windows.Forms.TreeView();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.allTaskReport = new System.Windows.Forms.RadioButton();
            this.selectedTaskReport = new System.Windows.Forms.RadioButton();
            this.btnPreviousWeek = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.timeTrackGridView = new System.Windows.Forms.DataGridView();
            this.lblSelectedTask = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.TypeResultsGridView = new System.Windows.Forms.DataGridView();
            this.TaskResultsGridView = new System.Windows.Forms.DataGridView();
            this.SubTaskResultsGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.TypeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UpdateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeResultsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskResultsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTaskResultsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TTTreeView
            // 
            this.TTTreeView.Location = new System.Drawing.Point(12, 12);
            this.TTTreeView.Name = "TTTreeView";
            this.TTTreeView.Size = new System.Drawing.Size(260, 261);
            this.TTTreeView.TabIndex = 1;
            this.TTTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TTTreeView_AfterSelect);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(12, 433);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateReport.TabIndex = 34;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // allTaskReport
            // 
            this.allTaskReport.AutoSize = true;
            this.allTaskReport.Checked = true;
            this.allTaskReport.Location = new System.Drawing.Point(15, 385);
            this.allTaskReport.Name = "allTaskReport";
            this.allTaskReport.Size = new System.Drawing.Size(63, 17);
            this.allTaskReport.TabIndex = 33;
            this.allTaskReport.TabStop = true;
            this.allTaskReport.Text = "All Taks";
            this.allTaskReport.UseVisualStyleBackColor = true;
            this.allTaskReport.CheckedChanged += new System.EventHandler(this.allTaskReport_CheckedChanged);
            // 
            // selectedTaskReport
            // 
            this.selectedTaskReport.AutoSize = true;
            this.selectedTaskReport.Location = new System.Drawing.Point(15, 410);
            this.selectedTaskReport.Name = "selectedTaskReport";
            this.selectedTaskReport.Size = new System.Drawing.Size(94, 17);
            this.selectedTaskReport.TabIndex = 32;
            this.selectedTaskReport.Text = "Selected Task";
            this.selectedTaskReport.UseVisualStyleBackColor = true;
            this.selectedTaskReport.CheckedChanged += new System.EventHandler(this.selectedTaskReport_CheckedChanged);
            // 
            // btnPreviousWeek
            // 
            this.btnPreviousWeek.Location = new System.Drawing.Point(12, 305);
            this.btnPreviousWeek.Name = "btnPreviousWeek";
            this.btnPreviousWeek.Size = new System.Drawing.Size(120, 23);
            this.btnPreviousWeek.TabIndex = 31;
            this.btnPreviousWeek.Text = "Previous Work Week";
            this.btnPreviousWeek.UseVisualStyleBackColor = true;
            this.btnPreviousWeek.Click += new System.EventHandler(this.btnPreviousWeek_Click);
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(12, 359);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(120, 20);
            this.endDate.TabIndex = 30;
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(12, 335);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(120, 20);
            this.startDate.TabIndex = 29;
            // 
            // timeTrackGridView
            // 
            this.timeTrackGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timeTrackGridView.Location = new System.Drawing.Point(279, 13);
            this.timeTrackGridView.Name = "timeTrackGridView";
            this.timeTrackGridView.Size = new System.Drawing.Size(917, 260);
            this.timeTrackGridView.TabIndex = 35;
            this.timeTrackGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.timeTrackGridView_CellEndEdit);
            this.timeTrackGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.timeTrackGridView_UserDeletingRow);
            // 
            // lblSelectedTask
            // 
            this.lblSelectedTask.AutoSize = true;
            this.lblSelectedTask.Location = new System.Drawing.Point(49, 289);
            this.lblSelectedTask.Name = "lblSelectedTask";
            this.lblSelectedTask.Size = new System.Drawing.Size(41, 13);
            this.lblSelectedTask.TabIndex = 37;
            this.lblSelectedTask.Text = "lblTask";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Task";
            // 
            // dayComboBox
            // 
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Location = new System.Drawing.Point(279, 278);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(121, 21);
            this.dayComboBox.TabIndex = 38;
            this.dayComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TypeResultsGridView
            // 
            this.TypeResultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TypeResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TypeResultsGridView.Location = new System.Drawing.Point(138, 323);
            this.TypeResultsGridView.Name = "TypeResultsGridView";
            this.TypeResultsGridView.Size = new System.Drawing.Size(532, 150);
            this.TypeResultsGridView.TabIndex = 39;
            // 
            // TaskResultsGridView
            // 
            this.TaskResultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaskResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskResultsGridView.Location = new System.Drawing.Point(137, 490);
            this.TaskResultsGridView.Name = "TaskResultsGridView";
            this.TaskResultsGridView.Size = new System.Drawing.Size(533, 150);
            this.TaskResultsGridView.TabIndex = 40;
            // 
            // SubTaskResultsGridView
            // 
            this.SubTaskResultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SubTaskResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubTaskResultsGridView.Location = new System.Drawing.Point(137, 661);
            this.SubTaskResultsGridView.Name = "SubTaskResultsGridView";
            this.SubTaskResultsGridView.Size = new System.Drawing.Size(533, 150);
            this.SubTaskResultsGridView.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Type Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Task Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 643);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Sub Task Results";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(1094, 278);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(102, 23);
            this.btnExportToExcel.TabIndex = 45;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // TypeChart
            // 
            chartArea3.Name = "ChartArea1";
            this.TypeChart.ChartAreas.Add(chartArea3);
            this.TypeChart.Location = new System.Drawing.Point(676, 323);
            this.TypeChart.Name = "TypeChart";
            this.TypeChart.Size = new System.Drawing.Size(520, 150);
            this.TypeChart.TabIndex = 46;
            this.TypeChart.Text = "chart1";
            this.TypeChart.Click += new System.EventHandler(this.TypeChart_Click);
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.AutoSize = true;
            this.UpdateLabel.Location = new System.Drawing.Point(407, 280);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(0, 13);
            this.UpdateLabel.TabIndex = 47;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 827);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.TypeChart);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SubTaskResultsGridView);
            this.Controls.Add(this.TaskResultsGridView);
            this.Controls.Add(this.TypeResultsGridView);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.lblSelectedTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTrackGridView);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.allTaskReport);
            this.Controls.Add(this.selectedTaskReport);
            this.Controls.Add(this.btnPreviousWeek);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.TTTreeView);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeResultsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskResultsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTaskResultsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TTTreeView;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.RadioButton allTaskReport;
        private System.Windows.Forms.RadioButton selectedTaskReport;
        private System.Windows.Forms.Button btnPreviousWeek;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DataGridView timeTrackGridView;
        private System.Windows.Forms.Label lblSelectedTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.DataGridView TypeResultsGridView;
        private System.Windows.Forms.DataGridView TaskResultsGridView;
        private System.Windows.Forms.DataGridView SubTaskResultsGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DataVisualization.Charting.Chart TypeChart;
        private System.Windows.Forms.Label UpdateLabel;
    }
}