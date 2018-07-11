using DowCorning.Applications.TimeTracking;
using System;
using System.Data;
using System.Windows.Forms;

namespace TimeTracking3
{
    public partial class TimeTracking : Form
    {
        private TimeTrackInfo info;

        private TimeTrackingState state = TimeTrackingState.paused;

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

        public TimeTrackingState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                UpdateState();
            }
        }

        public TimeTracking()
        {
            InitializeComponent();

            //if (!System.Diagnostics.EventLog.SourceExists("TimeTracking"))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource("TimeTracking", "TimeTrackingLog");
            //}
            //else
            //{
            //    System.Diagnostics.EventLog.WriteEntry("TimeTracking", "Error", System.Diagnostics.EventLogEntryType.Error);
            //    System.Diagnostics.EventLog.WriteEntry("TimeTracking", "Testing");
            //}


            if (Data.DatabaseExists())
            {
                this.State = TimeTrackingState.stopped;
                this.SetTreeview();
                this.Width = 666;
                this.UpdatePrevious();
            }
            else
            {
                MessageBox.Show("Error with database, please contact developer");
            }
        }

        public void RefreshData()
        {
            this.Info.ResetData();
            this.TTTreeView.Nodes.Clear();
            this.SetTreeview();
        }

        /// <summary>
        /// Sets the current task label
        /// </summary>
        public void SetTask()
        {
            this.lblCurrentTask.Text = this.Info.CurrentTask.DisplayName;
        }

        private void UpdatePrevious()
        {
            if (this.Info.PreviousTask != null && !string.IsNullOrEmpty(this.Info.PreviousTask.DisplayName))
            {
                this.lblPreviousStart.Text = this.Info.PreviousTask.StartTime.ToString();
                this.lblPreviousEnd.Text = this.Info.PreviousTask.EndTime.ToString();
                this.lblPreviousTask.Text = this.Info.PreviousTask.DisplayName;
            }
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

        /// <summary>
        ///  Copies the flat file data into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void migrateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.MigrateData();
        }

        protected void TypeNode_Expand(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.lblCurrentTask.Text = e.Node.Text;
        }

        protected void TypeNode_Selected(object sender, TreeViewEventArgs e)
        {
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
                UpdateTotalTimeLabel();
                this.txtEstimatedTaskTime.Text = this.Info.SelectedTask.EstimateTotal.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Info.CurrentTask.Seconds += 1;

            if (Info.CurrentTask.Minutes < 1)
            {
                Info.CurrentTask.Minutes = 00;
                if (Info.CurrentTask.Hours < 1)
                {
                    Info.CurrentTask.Hours = 00;
                }
            }

            if (Info.CurrentTask.Seconds == 60)
            {
                Info.CurrentTask.Seconds = 0;
                Info.CurrentTask.Minutes += 1;
            }

            if (Info.CurrentTask.Minutes == 60)
            {
                Info.CurrentTask.Minutes = 0;
                Info.CurrentTask.Hours += 1;
            }

            if (Info.CurrentTask.Seconds % 20 == 0)
            {
                //tick gets off by a bit over time (losing time) this ensures that it is updating properly (every 20 Info.CurrentTask.Seconds readjusting)
                TimeSpan ts = DateTime.Now - Info.CurrentTask.StartTime;
                Info.CurrentTask.Hours = ts.Hours;
                Info.CurrentTask.Minutes = ts.Minutes;
                Info.CurrentTask.Seconds = ts.Seconds;
            }

            UpdateTimerLabel();
        }

        public void UpdateTimerLabel()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Info.CurrentTask.Hours, Info.CurrentTask.Minutes, Info.CurrentTask.Seconds);
            string time = dt.ToString("HH:mm:ss");
            lblTime.Text = time;
        }

        public void ResetTimerLabel()
        {
            lblTime.Text = "00:00:00";
        }

        public void UpdateTotalTimeLabel()
        {
            string time = this.Info.SelectedTask.OverallTotal.ToString();
            this.lblTotalTaskTime.Text = time;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Check to see if the task is new or was paused and restarted
            if (Info.CurrentTask == null || string.IsNullOrEmpty(this.Info.CurrentTask.Name))
            {
                Info.CurrentTask = Info.SelectedTask.Clone() as TaskInfo;
                Info.CurrentTask.StartTime = new DateTime();
                Info.CurrentTask.EndTime = new DateTime();
                Info.CurrentTask.Hours = 0;
                Info.CurrentTask.Minutes = 0;
                Info.CurrentTask.Seconds = 0;

                this.lblCurrentTask.Text = this.lblSelectedTask.Text;
                if (this.chkStartAfterLast.Checked)
                {
                    this.Info.PreviousTask = Data.Sel_Previous_Task();
                    this.Info.CurrentTask.StartTime = this.Info.PreviousTask.EndTime;
                    TimeSpan elapsedTime = DateTime.Now - this.Info.CurrentTask.StartTime;
                    this.Info.CurrentTask.Hours = elapsedTime.Hours;
                    this.Info.CurrentTask.Minutes = elapsedTime.Minutes;
                    this.Info.CurrentTask.Seconds = elapsedTime.Seconds;
                }
                else
                {
                    Info.CurrentTask.StartTime = DateTime.Now;
                }
            }
            else
            {
                Info.CurrentTask.StartTime = DateTime.Now.AddHours(-Info.CurrentTask.Hours).AddMinutes(-Info.CurrentTask.Minutes).AddSeconds(-Info.CurrentTask.Seconds);
            }

            //this.UpdateTotalTimeLabel();
            this.State = TimeTrackingState.running;
        }

        private void UpdateState()
        {
            switch (this.State)
            {
                case TimeTrackingState.paused:
                    this.tmrClock.Enabled = false;
                    this.btnClear.Enabled = true;
                    this.btnPause.Enabled = false;
                    this.btnRecord.Enabled = true;
                    this.btnStart.Enabled = true;
                    this.chkStartAfterLast.Enabled = false;
                    this.btnRecordStartTask.Enabled = true;
                    this.btnModifyTime.Enabled = true;
                    break;

                case TimeTrackingState.running:
                    this.tmrClock.Enabled = true;
                    this.btnClear.Enabled = false;
                    this.btnPause.Enabled = true;
                    this.btnRecord.Enabled = false;
                    this.btnStart.Enabled = false;
                    this.chkStartAfterLast.Enabled = false;
                    this.btnRecordStartTask.Enabled = true;
                    this.btnModifyTime.Enabled = false;
                    break;

                case TimeTrackingState.stopped:
                    this.tmrClock.Enabled = false;
                    this.btnClear.Enabled = false;
                    this.btnPause.Enabled = false;
                    this.btnRecord.Enabled = false;
                    this.btnStart.Enabled = true;
                    this.chkStartAfterLast.Enabled = true;
                    this.btnRecordStartTask.Enabled = false;
                    this.btnModifyTime.Enabled = false;
                    break;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.State = TimeTrackingState.paused;
            this.Info.CurrentTask.EndTime = DateTime.Now;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.RecordTime();
            this.Info.SelectedTask.GetTime();
            UpdateTotalTimeLabel();
            this.Info.PreviousTask = this.Info.CurrentTask;
            this.Info.CurrentTask = null;
            this.lblCurrentTask.Text = "";
            this.ResetTimerLabel();
            this.State = TimeTrackingState.stopped;
            this.UpdatePrevious();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.State = TimeTrackingState.stopped;
            this.Info.CurrentTask = null;
            this.lblCurrentTask.Text = "";
            this.ResetTimerLabel();
        }

        private void chkStartAfterLast_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnUpdateEstimate_Click(object sender, EventArgs e)
        {
            TimeSpan estimatedTime;
            if (TimeSpan.TryParse(this.txtEstimatedTaskTime.Text, out estimatedTime))
            {
                this.Info.SelectedTask.UpdateEstimatedTime(estimatedTime);
                EstimatedTimeMsgBox();
            }
        }

        private void EstimatedTimeMsgBox()
        {
            MessageBox.Show("Estimated Time Updated");
        }

        private void btnShowReports_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //this.allTaskReport.Checked = false;
        }

        private void btnShowReports_Click_1(object sender, EventArgs e)
        {
            //if (this.Width == 666)
            //{
            //    this.Width = 910;
            //}
            //else
            //{
            //    this.Width = 666;
            //}
            Report rf = new Report();
            // this.Hide();
            rf.Show();
        }

        private void allTaskReport_CheckedChanged(object sender, EventArgs e)
        {
            //this.selectedTaskReport.Checked = false;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnRecordStartTask_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = DateTime.Now;
            this.Info.CurrentTask.RecordTime();
            this.Info.SelectedTask.GetTime();
            UpdateTotalTimeLabel();
            this.Info.PreviousTask = this.Info.CurrentTask.Clone() as TaskInfo;
            this.Info.CurrentTask = null;
            this.lblCurrentTask.Text = "";
            this.ResetTimerLabel();
            this.State = TimeTrackingState.stopped;
            this.UpdatePrevious();

            Info.CurrentTask = Info.SelectedTask.Clone() as TaskInfo;
            Info.CurrentTask.StartTime = DateTime.Now;
            Info.CurrentTask.EndTime = new DateTime();
            Info.CurrentTask.Hours = 0;
            Info.CurrentTask.Minutes = 0;
            Info.CurrentTask.Seconds = 0;
            this.State = TimeTrackingState.running;
            this.lblCurrentTask.Text = this.lblSelectedTask.Text;
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintainTasks maintainTasks = new MaintainTasks();
            maintainTasks.Show();
        }

        private void btnModifyTime_Click(object sender, EventArgs e)
        {
            ManualTimeForm manualTimeForm = new ManualTimeForm();
            manualTimeForm.Info = this.Info;
            this.Hide();
            manualTimeForm.Show();
        }

        private void btnSelectPrevious_Click(object sender, EventArgs e)
        {
            this.Info.SelectedTask = Info.PreviousTask.Clone() as TaskInfo;
            this.lblSelectedTask.Text = this.Info.SelectedTask.DisplayName;
            Info.SelectedTask.GetTime();
            UpdateTotalTimeLabel();
            this.txtEstimatedTaskTime.Text = this.Info.SelectedTask.EstimateTotal.ToString();
        }

        private void importFromSharePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportSharePoint importSharePoint = new ImportSharePoint();
            importSharePoint.Show();
        }

        private void exportActualsToSharePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSharePoint exportSharePoint = new ExportSharePoint();
            exportSharePoint.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences preferences = new Preferences();
            preferences.Show();
        }

        private void updateNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"1.2 - Added the ability to pull data from the sharepoint estimation list and load it back in

1.3 - Fixed issue of not being able to delete Tasks

1.4 - Added in option to manually add time
      Now able to update/delete entries from the report screen");
        }

        /// <summary>
        /// Opens up the form to manually add time
        /// </summary>
        /// <param name="sender">Manually Add Time menu option</param>
        /// <param name="e">Any event arguments</param>
        private void manuallyAddTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualAddTime manualAddTime = new ManualAddTime();
            manualAddTime.Show();
        }

        private void hellpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Time Tracking Help.docx"); 
        }
    }

    public enum TimeTrackingState
    {
        running,
        paused,
        stopped
    }
}