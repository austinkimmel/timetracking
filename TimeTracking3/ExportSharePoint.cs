using DowCorning.Applications.EstimationListUtilities;
using DowCorning.Applications.TimeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TimeTracking3
{
    /// <summary> This form is used to export the actual data back to the estimation share point list </summary>
    /// <remarks> <p><b>Database References:</b><BR/> List any databases referenced by your class,
    /// include a list of tables referenced through execution of any SQL Statements, and list all
    /// stored procedures executed.</p>
    /// <b>Dependencies:</b><BR/>
    /// <p><b>Instructions for Use:</b><BR/>
    /// <example> <code></code> </example>
    /// </p><b>Additional Information:</b><BR/>
    /// <p><b>Change Log:</b><BR/>
    /// <table style="font-size:smaller">
    /// <tr><th align="left">DATE:</th><th align="left">DEVELOPER:</th><th align="left">COMMENT:</th></tr>
    /// <tr><td>28JAN2016</td><td>ASKIMMEL</td><td>Original version</td></tr>
    /// </table></p>
    /// </remarks>
    public partial class ExportSharePoint : Form
    {
        /// <summary>
        /// Instance of time track info
        /// </summary>
        private TimeTrackInfo info;

        /// <summary>
        /// Instance of the project component form control for the selected project
        /// </summary>
        private ProjectComponentFormControl SelectedProject;

        /// <summary>
        /// Default constructor.  Loades the drop down list of all of the projects
        /// </summary>
        public ExportSharePoint()
        {
            InitializeComponent();

            this.ProjectsDropDown.DataSource = this.Info.Types;
            this.ProjectsDropDown.DisplayMember = "type_name";
            this.ProjectsDropDown.ValueMember = "type_id";
        }

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

        /// <summary>
        /// Exports the actual time data back to the estimation sharepoint list
        /// </summary>
        /// <param name="sender">Export button</param>
        /// <param name="e">Any event arguments</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.SelectedProject.Include.Checked)
            {
                this.SelectedProject.UpdateActualWork();
            }
            int phaseIndex = 0;

            foreach (ProjectComponentFormControl phase in this.SelectedProject.Children)
            {
                if (phase.Include.Checked)
                {
                    phase.UpdateActualWork();
                }

                foreach (ProjectComponentFormControl task in this.SelectedProject.Children[phaseIndex].Children)
                {
                    if (task.Include.Checked)
                    {
                        task.UpdateActualWork();
                    }
                }
                phaseIndex++;
            }

            MessageBox.Show("Actual hours exported to sharepoint list");
        }

        /// <summary>
        /// Populates the form with the different phases and tasks associated to the project selected.
        /// </summary>
        /// <param name="sender">Select button</param>
        /// <param name="e">Any event arguments</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.groupBox.Controls.Clear();

            int top = 20;

            string typeId = this.ProjectsDropDown.SelectedValue.ToString();

            System.Collections.ObjectModel.Collection<ProjectComponent> projectAndPhases = new System.Collections.ObjectModel.Collection<ProjectComponent>();

            if (string.IsNullOrEmpty(typeId))
            {
                MessageBox.Show("You must supply a Project Title");
            }
            else
            {
                DataRow[] typeRow = this.Info.Types.Select("type_id = " + typeId);
                TaskInfo selectedType = new TaskInfo()
                {
                    TaskType = TaskType.Type,
                    Type_Id = typeRow[0]["type_id"].ToString(),
                    Type_Name = typeRow[0]["type_name"].ToString(),
                    SharePointId = typeRow[0]["SharePoint_Id"].ToString()
                };
                selectedType.GetTime();

                int sharepointId;
                if (!int.TryParse(selectedType.SharePointId, out sharepointId))
                {
                    sharepointId = -1;
                }
                SelectedProject = new ProjectComponentFormControl(sharepointId, selectedType.Type_Name, selectedType.OverallTotal.TotalHours, 10, top, "", SharePointActionMode.Export);

                this.groupBox.Controls.Add(SelectedProject.Include);
                this.groupBox.Controls.Add(SelectedProject.Title);
                this.groupBox.Controls.Add(SelectedProject.EstimatedHours);

                top += 22;

                // Add the phases
                this.SelectedProject.Children = new List<ProjectComponentFormControl>();
                DataRow[] taskRows = this.Info.Tasks.Select("type_id = " + typeId);
                foreach (DataRow taskDR in taskRows)
                {
                    TaskInfo task = new TaskInfo()
                    {
                        TaskType = TaskType.Task,
                        Type_Id = selectedType.Type_Id,
                        Task_Id = taskDR["task_id"].ToString(),
                        Task_Name = taskDR["task_name"].ToString(),
                        Link_Id = taskDR["link_id"].ToString(),
                        SharePointId = taskDR["sharePoint_id"].ToString()
                    };
                    task.GetTime();

                    ProjectComponentFormControl phaseComponet = new ProjectComponentFormControl(int.Parse(string.IsNullOrEmpty(task.SharePointId) ? "-1" : task.SharePointId), task.Task_Name, task.OverallTotal.TotalHours, 20, top, selectedType.Name, SharePointActionMode.Export);
                    this.SelectedProject.Children.Add(phaseComponet);

                    this.groupBox.Controls.Add(phaseComponet.Include);
                    this.groupBox.Controls.Add(phaseComponet.Title);
                    this.groupBox.Controls.Add(phaseComponet.EstimatedHours);

                    top += 22;

                    this.SelectedProject.Children[this.SelectedProject.Children.Count - 1].Children = new List<ProjectComponentFormControl>();

                    // Add the tasks
                    DataRow[] subTaskRows = this.Info.SubTask.Select("link_id = " + task.Link_Id);
                    foreach (DataRow subTaskDR in subTaskRows)
                    {
                        TaskInfo subTask = new TaskInfo()
                        {
                            Type_Id = selectedType.Type_Id,
                            Task_Id = task.Task_Id,
                            Link_Id = task.Link_Id,
                            Sub_Task_Name = subTaskDR["sub_task_name"].ToString(),
                            SharePointId = subTaskDR["sharePoint_id"].ToString(),
                            Sub_Task_Id = subTaskDR["sub_task_id"].ToString(),
                            TaskType = TaskType.SubTask
                        };
                        subTask.GetTime();

                        ProjectComponentFormControl taskComponent = new ProjectComponentFormControl(int.Parse(string.IsNullOrEmpty(subTask.SharePointId) ? "-1" : subTask.SharePointId), subTask.Sub_Task_Name, subTask.OverallTotal.TotalHours, 30, top, task.Name, SharePointActionMode.Export);
                        this.SelectedProject.Children[this.SelectedProject.Children.Count - 1].Children.Add(taskComponent);

                        this.groupBox.Controls.Add(taskComponent.Include);
                        this.groupBox.Controls.Add(taskComponent.Title);
                        this.groupBox.Controls.Add(taskComponent.EstimatedHours);

                        top += 22;
                    }
                }
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
    }
}