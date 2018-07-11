using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DowCorning.Applications.TimeTracking;

namespace TimeTracking3
{
    public partial class ManualAddTime : Form
    {
        private TimeTrackInfo info;
        
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
        
        public ManualAddTime()
        {
            InitializeComponent();
            this.SetTreeview();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                this.TotalTimeLabel.Text = this.Info.SelectedTask.OverallTotal.ToString();
            }
        }

        /// <summary>
        /// Refreshes the main window
        /// </summary>
        private void RefereshMain()
        {
            if (System.Windows.Forms.Application.OpenForms["TimeTracking"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["TimeTracking"] as TimeTracking).RefreshData();
            }
        }

        /// <summary>
        /// Adds the time to the database
        /// </summary>
        /// <param name="sender">Add Time Button</param>
        /// <param name="e">Any event arguments</param>
        private void AddTimeButton_Click(object sender, EventArgs e)
        {
            int hours, minutes;
            
            // Set the text to 0 if there is no values
            if (string.IsNullOrEmpty(this.HoursInput.Text))
            {
                this.HoursInput.Text = "0";
            }

            if(string.IsNullOrEmpty(this.MinutesInput.Text))
            {
                this.MinutesInput.Text = "0";
            }


            if(int.TryParse(this.HoursInput.Text, out hours) && int.TryParse(this.MinutesInput.Text, out minutes))
            {
                if (minutes >= 0 && hours >= 0)
                {
                    if (minutes < 60)
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParse(this.startDate.Text, out selectedDate))
                        {
                            this.Info.SelectedTask.StartTime = this.Info.SelectedTask.EndTime = selectedDate.AddSeconds(1);
                            this.Info.SelectedTask.Hours = hours;
                            this.Info.SelectedTask.Minutes = minutes;
                            if (this.Info.SelectedTask.RecordTime(true))
                            {
                                MessageBox.Show("Time successfully added");
                                this.TotalTimeLabel.Text = this.Info.SelectedTask.OverallTotal.ToString();
                                this.RefereshMain();
                            }
                            else
                            {
                                MessageBox.Show("Error occured while saving time");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid date");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Minutes cannont be greater than 59");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a time that is not negative");
                }
                
            }
            else
            {
                MessageBox.Show("Please enter a valid amount for hours and/or minutes");
            }
        }

    }
}
