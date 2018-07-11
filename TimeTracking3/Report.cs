using DowCorning.Applications.TimeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TimeTracking3
{
    public partial class Report : Form
    {
        private TimeTrackInfo info;

        private DowCorning.Applications.TimeTracking.Preferences preferences = new DowCorning.Applications.TimeTracking.Preferences();

        /// <summary>
        ///  Gets all of the TimeTrackInfo
        /// </summary>
        public TimeTrackInfo Info
        {
            get
            {
                if (info == null)
                {
                    info = new TimeTrackInfo();
                }
                return info;
            }
            set
            {
                info = value;
            }
        }

        public DataTable TimeTrackData
        {
            get;
            set;
        }

        /** Results **/
        private List<TaskInfo> typeResults;

        public List<TaskInfo> TypeResults
        {
            get
            {
                if (typeResults == null)
                {
                    typeResults = new List<TaskInfo>();
                }
                return typeResults;
            }
            set
            {
                typeResults = value;
            }
        }

        private List<TaskInfo> taskResults;

        public List<TaskInfo> TaskResults
        {
            get
            {
                if (taskResults == null)
                {
                    taskResults = new List<TaskInfo>();
                }
                return taskResults;
            }
            set
            {
                taskResults = value;
            }
        }

        private List<TaskInfo> subTaskResults;

        public List<TaskInfo> SubTaskResults
        {
            get
            {
                if (subTaskResults == null)
                {
                    subTaskResults = new List<TaskInfo>();
                }
                return subTaskResults;
            }
            set
            {
                subTaskResults = value;
            }
        }

        /** Summaries **/
        private Dictionary<int, TaskInfo> typeSummary;

        public Dictionary<int, TaskInfo> TypeSummary
        {
            get
            {
                if (typeSummary == null)
                {
                    typeSummary = new Dictionary<int, TaskInfo>();
                }
                return typeSummary;
            }
            set
            {
                typeSummary = value;
            }
        }

        private Dictionary<int, TaskInfo> taskSummary;

        public Dictionary<int, TaskInfo> TaskSummary
        {
            get
            {
                if (taskSummary == null)
                {
                    taskSummary = new Dictionary<int, TaskInfo>();
                }
                return taskSummary;
            }
            set
            {
                taskSummary = value;
            }
        }

        private Dictionary<int, TaskInfo> subTaskSummary;

        public Dictionary<int, TaskInfo> SubTaskSummary
        {
            get
            {
                if (subTaskSummary == null)
                {
                    subTaskSummary = new Dictionary<int, TaskInfo>();
                }
                return subTaskSummary;
            }
            set
            {
                subTaskSummary = value;
            }
        }

        public Report()
        {
            InitializeComponent();
            this.SetTreeview();
        }

        /// <summary>
        ///  Creates the tree view
        /// </summary>
        private void SetTreeview()
        {
            // Loop through the types
            for (int i = 0; i < Info.Types.Rows.Count; i++)
            {
                TTTreeView.Nodes.Add(Info.Types.Rows[i]["type_id"].ToString(), Info.Types.Rows[i]["type_name"].ToString());

                // Loop through each task for the type
                DataRow[] task = Info.Tasks.Select("type_id = " + Info.Types.Rows[i]["type_id"]);
                foreach (DataRow dr in task)
                {
                    TTTreeView.Nodes[i].Nodes.Add(dr["task_id"].ToString(), dr["task_name"].ToString());

                    // Loop through each subtask for the task
                    DataRow[] subTask = Info.SubTask.Select("link_id = " + dr["link_id"].ToString());
                    int leaf = TTTreeView.Nodes[i].Nodes.Count;
                    foreach (DataRow subTaskRow in subTask)
                    {
                        TTTreeView.Nodes[i].Nodes[leaf - 1].Nodes.Add(subTaskRow["sub_task_id"].ToString(), subTaskRow["sub_task_name"].ToString());
                    }
                }
            }
        }

        private void TTTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e != null)
            {
                // Determine what type of node it is
                if (e.Node.Parent != null)
                {
                    if (e.Node.Parent.Parent != null)
                    {
                        //Info.CurrentTask.taskType = TaskType.SubType;
                        Info.SelectedTask.Type_Id = e.Node.Parent.Parent.Name;
                        Info.SelectedTask.Task_Id = e.Node.Parent.Name;
                        Info.SelectedTask.Sub_Task_Id = e.Node.Name;
                        Info.SelectedTask.TaskType = TaskType.SubTask;

                        this.lblSelectedTask.Text = string.Format("{0} --> {1} --> {2}", e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text);
                    }
                    else
                    {
                        //Info.CurrentTask.taskType = TaskType.Task;
                        Info.SelectedTask.TaskType = TaskType.Task;
                        Info.SelectedTask.Type_Id = e.Node.Parent.Name;
                        Info.SelectedTask.Task_Id = e.Node.Name;
                        this.lblSelectedTask.Text = string.Format("{0} --> {1}", e.Node.Parent.Text, e.Node.Text);
                    }
                }
                else
                {
                    //Info.CurrentTask.taskType = TaskType.Type;
                    this.lblSelectedTask.Text = e.Node.Text;
                    Info.SelectedTask.TaskType = TaskType.Type;
                    Info.SelectedTask.Type_Id = e.Node.Name;
                }
                Info.SelectedTask.Name = e.Node.Text;
                Info.SelectedTask.GetTime();
                Info.SelectedTask.DisplayName = this.lblSelectedTask.Text;
            }
        }

        private void selectedTaskReport_CheckedChanged(object sender, EventArgs e)
        {
            //this.allTaskReport.Checked = false;
        }

        private void allTaskReport_CheckedChanged(object sender, EventArgs e)
        {
            //this.selectedTaskReport.Checked = false;
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            DateTime previousWeekStart = startingDate.AddDays(-7);
            DateTime previousWeekEnd = startingDate.AddDays(-3);
            startDate.Value = previousWeekStart;
            endDate.Value = previousWeekEnd;

            //DateTime mondayOfLastWeek = DateTime.Now.Add(
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            typeResults = new List<TaskInfo>();
            taskResults = new List<TaskInfo>();
            subTaskResults = new List<TaskInfo>();
            DateTime startDate = this.startDate.Value.Date;
            DateTime endDate = this.endDate.Value.Date.AddDays(1);
            this.TimeTrackData = Data.Sel_Time_Track(startDate, endDate, this.selectedTaskReport.Checked ? this.Info.SelectedTask : null);

            DataTable dt = this.TimeTrackData.Copy();
            dt.Columns.Remove("type_id");
            dt.Columns.Remove("task_id");
            dt.Columns.Remove("sub_task_id");
            this.timeTrackGridView.DataSource = dt;
            this.timeTrackGridView.Columns[this.timeTrackGridView.Columns.Count - 1].Visible = false;
            this.timeTrackGridView.Columns["type_name"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.timeTrackGridView.Columns["type_name"].ReadOnly = true;
            this.timeTrackGridView.Columns["task_name"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.timeTrackGridView.Columns["task_name"].ReadOnly = true;
            this.timeTrackGridView.Columns["sub_task_name"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.timeTrackGridView.Columns["sub_task_name"].ReadOnly = true;
            this.timeTrackGridView.Columns["start_time"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.timeTrackGridView.Columns["start_time"].ReadOnly = true;
            this.timeTrackGridView.Columns["end_time"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.timeTrackGridView.Columns["end_time"].ReadOnly = true;

            List<String> days = new List<String>();
            DateTime day = new DateTime();
            TaskInfo ti;
            days.Add("All Days");
            foreach (DataRow dr in this.TimeTrackData.AsEnumerable())
            {
                ti = GetTaskInfoFromDataRow(dr);
                switch (ti.TaskType)
                {
                    case TaskType.Type:
                        this.TypeResults.Add(ti);
                        break;

                    case TaskType.Task:
                        this.TypeResults.Add(ti);
                        this.TaskResults.Add(ti);
                        break;

                    case TaskType.SubTask:
                        this.TypeResults.Add(ti);
                        this.TaskResults.Add(ti);
                        this.SubTaskResults.Add(ti);
                        break;
                }

                if (DateTime.TryParse(dr["start_time"].ToString(), out day))
                {
                    if (!days.Contains(day.Date.ToShortDateString()))
                    {
                        days.Add(day.Date.ToShortDateString());
                    }
                }
            }
            this.dayComboBox.DataSource = days;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = this.TimeTrackData.Select("Where
            if (!string.IsNullOrEmpty(this.dayComboBox.SelectedValue.ToString()))
            {
                DataTable dt;
                string selectedDate = dayComboBox.SelectedValue.ToString();
                typeSummary = new Dictionary<int, TaskInfo>();
                taskSummary = new Dictionary<int, TaskInfo>();
                subTaskSummary = new Dictionary<int, TaskInfo>();

                if (dayComboBox.SelectedValue.ToString() != "All Days")
                {
                    var results = from DataRow row in this.TimeTrackData.Rows
                                  where (DateTime.Parse(row["start_time"].ToString()).Date == DateTime.Parse(this.dayComboBox.SelectedValue.ToString()).Date
                                      //&& DateTime.Parse(row["start_time"].ToString()).Date <= DateTime.Parse(this.dayComboBox.SelectedValue.ToString()).Date.AddDays(1)
                                  )

                                  select row;

                    dt = results.CopyToDataTable();
                }
                else
                {
                    dt = this.TimeTrackData.Copy();
                }

                foreach (TaskInfo ti in TypeResults)
                {
                    int key;
                    if (selectedDate == "All Days" || selectedDate == ti.StartTime.Date.ToShortDateString())
                    {
                        if (TypeSummary.Any(type => type.Value.Type_Id == ti.Type_Id))
                        {
                            key = TypeSummary.FirstOrDefault(type => type.Value.Type_Id == ti.Type_Id).Key;
                            TypeSummary[key].Hours += ti.Hours;
                            TypeSummary[key].Minutes += ti.Minutes;
                            TypeSummary[key].Seconds += ti.Seconds;
                            if (TypeSummary[key].Seconds >= 60)
                            {
                                TypeSummary[key].Minutes += 1;
                                TypeSummary[key].Seconds -= 60;
                            }
                            if (TypeSummary[key].Minutes >= 60)
                            {
                                TypeSummary[key].Hours += 1;
                                TypeSummary[key].Minutes -= 60;
                            }
                        }
                        else
                        {
                            key = TypeSummary.Count;
                            TaskInfo newTi = ti.Clone() as TaskInfo;
                            TypeSummary.Add(key, newTi);
                        }
                    }
                }

                foreach (TaskInfo ti in TaskResults)
                {
                    int key;
                    if (selectedDate == "All Days" || selectedDate == ti.StartTime.Date.ToShortDateString())
                    {
                        if (TaskSummary.Any(type => type.Value.Type_Id == ti.Type_Id && type.Value.Task_Id == ti.Task_Id))
                        {
                            key = TaskSummary.FirstOrDefault(type => type.Value.Type_Id == ti.Type_Id && type.Value.Task_Id == ti.Task_Id).Key;
                            TaskSummary[key].Hours += ti.Hours;
                            TaskSummary[key].Minutes += ti.Minutes;
                            TaskSummary[key].Seconds += ti.Seconds;
                            if (TaskSummary[key].Seconds >= 60)
                            {
                                TaskSummary[key].Minutes += 1;
                                TaskSummary[key].Seconds -= 60;
                            }
                            if (TaskSummary[key].Minutes >= 60)
                            {
                                TaskSummary[key].Hours += 1;
                                TaskSummary[key].Minutes -= 60;
                            }
                        }
                        else
                        {
                            key = TaskSummary.Count;
                            TaskInfo newTi = ti.Clone() as TaskInfo;
                            TaskSummary.Add(key, newTi);
                        }
                    }
                }

                foreach (TaskInfo ti in SubTaskResults)
                {
                    int key;
                    if (selectedDate == "All Days" || selectedDate == ti.StartTime.Date.ToShortDateString())
                    {
                        if (SubTaskSummary.Any(type => type.Value.Type_Id == ti.Type_Id && type.Value.Task_Id == ti.Task_Id && type.Value.Sub_Task_Id == ti.Sub_Task_Id))
                        {
                            key = SubTaskSummary.FirstOrDefault(type => type.Value.Type_Id == ti.Type_Id && type.Value.Task_Id == ti.Task_Id && type.Value.Sub_Task_Id == ti.Sub_Task_Id).Key;
                            SubTaskSummary[key].Hours += ti.Hours;
                            SubTaskSummary[key].Minutes += ti.Minutes;
                            SubTaskSummary[key].Seconds += ti.Seconds;
                            if (SubTaskSummary[key].Seconds >= 60)
                            {
                                SubTaskSummary[key].Minutes += 1;
                                SubTaskSummary[key].Seconds -= 60;
                            }
                            if (SubTaskSummary[key].Minutes >= 60)
                            {
                                SubTaskSummary[key].Hours += 1;
                                SubTaskSummary[key].Minutes -= 60;
                            }
                        }
                        else
                        {
                            key = SubTaskSummary.Count;
                            TaskInfo newTi = ti.Clone() as TaskInfo;
                            SubTaskSummary.Add(key, newTi);
                        }
                    }
                }

                TypeResultsGridView.DataSource = SummaryToDataTable(TypeSummary, TaskType.Type);
                TaskResultsGridView.DataSource = SummaryToDataTable(TaskSummary, TaskType.Task);
                SubTaskResultsGridView.DataSource = SummaryToDataTable(SubTaskSummary, TaskType.SubTask);

                Series series = new Series()
                {
                    Name = "Test",
                    Color = System.Drawing.Color.Gray,
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Bar
                };

                //series.Points.AddXY("1/2/14", 10);
                //SummaryToSeries(this.TypeChart, selectedDate, TypeSummary, TaskType.Type);

                //this.TypeChart.ser
                //dt.Rows.Add(results);
            }
        }

        private void SummaryToSeries(Chart chart, string selectedDate, Dictionary<int, TaskInfo> summary, TaskType taskType)
        {


            if (!string.IsNullOrEmpty(this.preferences.RoundTimeAmount))
            {
                //dt.Columns.Add("Rounded Time");
            }

            for (int i = 0; i < summary.Count; i++)
            {
                Series itemSeries = new Series();  

                switch (taskType)
                {
                    case TaskType.Type:
                        itemSeries.Name = summary[i].Type_Name;
                        break;

                    case TaskType.Task:
                        itemSeries.Name = string.Format("{0} --> {1}", summary[i].Type_Name, summary[i].Task_Name);
                        break;

                    case TaskType.SubTask:
                        itemSeries.Name = string.Format("{0} --> {1} --> {2}", summary[i].Type_Name, summary[i].Task_Name, summary[i].Sub_Task_Name);
                        break;
                }

                string time = string.Format("{0}:{1}:{2}", summary[i].Hours.ToString().PadLeft(2, '0'), summary[i].Minutes.ToString().PadLeft(2, '0'), summary[i].Seconds.ToString().PadLeft(2, '0'));

                itemSeries.Points.AddXY(selectedDate, summary[i].Hours * 60 + summary[i].Minutes);

                if (!string.IsNullOrEmpty(this.preferences.RoundTimeAmount))
                {
                     this.preferences.GetRoundedTime(time);
                }
                chart.Series.Add(itemSeries);
                chart.Legends.Add(new Legend(itemSeries.Name) { MaximumAutoSize = 20 });
                //summarySeries.Add(itemSeries);

                
            }

            chart.ChartAreas[0].Position.Width = 90;
            //return summarySeries;
        }

        private TaskInfo GetTaskInfoFromDataRow(DataRow dr)
        {
            TaskInfo ti = new TaskInfo();
            int outInt = 0;

            ti.Type_Id = dr["type_id"].ToString();
            ti.Task_Id = dr["task_id"].ToString();
            ti.Sub_Task_Id = dr["sub_task_id"].ToString();
            ti.StartTime = DateTime.Parse(dr["start_time"].ToString());
            ti.EndTime = DateTime.Parse(dr["end_time"].ToString());
            ti.Type_Name = dr["type_name"].ToString();
            ti.Task_Name = dr["task_name"].ToString();
            ti.Sub_Task_Name = dr["sub_task_name"].ToString();

            if (int.TryParse(dr["hours"].ToString(), out outInt))
            {
                ti.Hours = outInt;
            }

            if (int.TryParse(dr["minutes"].ToString(), out outInt))
            {
                ti.Minutes = outInt;
            }

            if (int.TryParse(dr["seconds"].ToString(), out outInt))
            {
                ti.Seconds = outInt;
            }

            if (ti.Task_Id == "-1" && ti.Sub_Task_Id == "-1")
            {
                ti.TaskType = TaskType.Type;
                ti.DisplayName = dr["type_name"].ToString();
            }
            else if (ti.Sub_Task_Id == "-1")
            {
                ti.TaskType = TaskType.Task;
            }
            else
            {
                ti.TaskType = TaskType.SubTask;
            }

            return ti;
        }

        private DataTable SummaryToDataTable(Dictionary<int, TaskInfo> summary, TaskType taskType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Time Spent");

            if (!string.IsNullOrEmpty(this.preferences.RoundTimeAmount))
            {
                dt.Columns.Add("Rounded Time");
            }

            for (int i = 0; i < summary.Count; i++)
            {
                DataRow dr = dt.NewRow();

                switch (taskType)
                {
                    case TaskType.Type:
                        dr["Name"] = summary[i].Type_Name;
                        break;

                    case TaskType.Task:
                        dr["Name"] = string.Format("{0} --> {1}", summary[i].Type_Name, summary[i].Task_Name);
                        break;

                    case TaskType.SubTask:
                        dr["Name"] = string.Format("{0} --> {1} --> {2}", summary[i].Type_Name, summary[i].Task_Name, summary[i].Sub_Task_Name);
                        break;
                }

                string time = string.Format("{0}:{1}:{2}", summary[i].Hours.ToString().PadLeft(2, '0'), summary[i].Minutes.ToString().PadLeft(2, '0'), summary[i].Seconds.ToString().PadLeft(2, '0'));

                dr["Time Spent"] = time;

                if (!string.IsNullOrEmpty(this.preferences.RoundTimeAmount))
                {
                    dr["Rounded Time"] = this.preferences.GetRoundedTime(time);
                }

                dt.Rows.Add(dr);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "Name";
            dt = dv.ToTable();

            return dt;
        }

        private void copyAlltoClipboard()
        {
            timeTrackGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            timeTrackGridView.SelectAll();
            DataObject dataObj = timeTrackGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //xlexcel.Quit();
        }

        private void TypeChart_Click(object sender, EventArgs e)
        {
            if (this.TypeChart.Top != 0)
            {
                this.TypeChart.Height = this.Size.Height;
                this.TypeChart.Width = this.Size.Width;
                this.TypeChart.Top = 0;
                this.TypeChart.Left = 0;
                foreach (Series series in this.TypeChart.Series)
                {
                    series.SmartLabelStyle.Enabled = false;
                    series.Label = series.Name;
                    series.LabelAngle = 90;
                }
                foreach (Legend legend in this.TypeChart.Legends)
                {
                    //legend
                }
            }
            else
            {
                this.TypeChart.Height = 150;
                this.TypeChart.Width = 520;
                this.TypeChart.Top = 323;
                this.TypeChart.Left = 676;
                foreach (Series series in this.TypeChart.Series)
                {
                    series.Label = "";
                }
            }
        }

        /// <summary>
        /// Handles the updating of the hours/minutes/seconds of a record
        /// </summary>
        /// <param name="sender">Time track grid view</param>
        /// <param name="e">Cell that is editted</param>
        private void timeTrackGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int changedValue;

            if (int.TryParse(this.timeTrackGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out changedValue))
            {
                if (changedValue > 0)
                {
                    string changedType = this.timeTrackGridView.Columns[e.ColumnIndex].Name;
                    string timeTrackId = this.timeTrackGridView.Rows[e.RowIndex].Cells["time_track_id"].Value.ToString();
                    if (Data.Upd_Time_Track(timeTrackId, changedValue.ToString(), changedType))
                    {
                        this.UpdateLabel.Text = "Value sucessfully changed";
                    }
                    else
                    {
                        this.UpdateLabel.Text = "Error updating value";
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a positive value");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value");
            }
        }

        /// <summary>
        /// Handles the deletion of a row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeTrackGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string timeTrackId = e.Row.Cells["time_track_id"].Value.ToString();
            if (Data.Del_Time_Track(timeTrackId))
            {
                MessageBox.Show("Record was successfully deleted");
            }
            else
            {
                MessageBox.Show("Error deleting record");
            }
        }
    }
}