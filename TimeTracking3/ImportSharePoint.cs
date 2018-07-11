using DowCorning.Applications.EstimationListUtilities;
using DowCorning.Applications.TimeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeTracking3
{
    public partial class ImportSharePoint : Form
    {
        private ProjectComponentFormControl SelectedProject;
        private List<ProjectComponentFormControl> Phases;
        private List<ProjectComponentFormControl> Tasks;

        public ImportSharePoint()
        {
            InitializeComponent();

            this.ProjectsDropDown.DataSource = SharePointData.allProjects.OrderBy(x => x).ToList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.groupBox.Controls.Clear();

            int top = 20;

            string projectTitle = (string)this.ProjectsDropDown.SelectedValue;

            System.Collections.ObjectModel.Collection<ProjectComponent> projectAndPhases = new System.Collections.ObjectModel.Collection<ProjectComponent>();

            if (projectTitle.Trim().Length == 0)
            {
                MessageBox.Show("You must supply a Project Title");
            }
            else
            {
                Project myProject = Project.ProjectByTitle(projectTitle);
                projectAndPhases.Add(myProject);
                Phases = new List<ProjectComponentFormControl>();
                Tasks = new List<ProjectComponentFormControl>();

                SelectedProject = new ProjectComponentFormControl(myProject.Id, myProject.Title, myProject.EstimatedHours, 10, top, "", SharePointActionMode.Import);

                this.groupBox.Controls.Add(SelectedProject.Include);
                this.groupBox.Controls.Add(SelectedProject.Title);
                this.groupBox.Controls.Add(SelectedProject.EstimatedHours);

                top += 22;

                // Add the phases
                this.SelectedProject.Children = new List<ProjectComponentFormControl>();
                foreach (Phase phase in myProject.Children)
                {
                    ProjectComponentFormControl phaseComponet = new ProjectComponentFormControl(phase.Id, phase.Title, phase.EstimatedHours, 20, top, myProject.Title, SharePointActionMode.Import);
                    this.SelectedProject.Children.Add(phaseComponet);
                    //Phases.Add(phaseComponet);

                    this.groupBox.Controls.Add(phaseComponet.Include);
                    this.groupBox.Controls.Add(phaseComponet.Title);
                    this.groupBox.Controls.Add(phaseComponet.EstimatedHours);

                    top += 22;

                    projectAndPhases.Add(phase);

                    // Add the tasks
                    this.SelectedProject.Children[this.SelectedProject.Children.Count - 1].Children = new List<ProjectComponentFormControl>();
                    foreach (DowCorning.Applications.EstimationListUtilities.Task task in phase.Children)
                    {
                        ProjectComponentFormControl taskComponent = new ProjectComponentFormControl(task.Id, task.Title, task.EstimatedHours, 30, top, phase.Title, SharePointActionMode.Import);
                        this.SelectedProject.Children[this.SelectedProject.Children.Count - 1].Children.Add(taskComponent);
                        //Phases.Add(taskComponent);

                        this.groupBox.Controls.Add(taskComponent.Include);
                        this.groupBox.Controls.Add(taskComponent.Title);
                        this.groupBox.Controls.Add(taskComponent.EstimatedHours);

                        top += 22;
                    }
                }
            }
        }

        private void groupBox_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Import the sharepoint data into the time tracking database
        /// </summary>
        /// <param name="sender">Import button</param>
        /// <param name="e">Any event arguments</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Insert the type if it is selected
            string error, typeId = string.Empty;
            if (this.SelectedProject.Include.Checked)
            {
                error = Data.Ins_Type(this.SelectedProject.Title.Text, this.SelectedProject.Id);
                typeId = Data.Sel_Type_ID(this.SelectedProject.Title.Text);
                int projectEstimatedHours = 0;
                if (int.TryParse(Math.Ceiling(double.Parse(this.SelectedProject.EstimatedHours.Text)).ToString(), out projectEstimatedHours))
                {
                    Data.Ins_Type_Estimate(typeId, new TimeSpan(projectEstimatedHours, 0, 0));
                }
            }
            else
            {
                // Check if the type already exists
                typeId = Data.Sel_Type_ID(this.SelectedProject.Title.Text); 
            }

            //If the type isn't in the database, don't insert anything else
            if (!string.IsNullOrEmpty(typeId))
            {

                // Insert the phases
                int phaseIndex = 0;
                foreach (ProjectComponentFormControl phase in this.SelectedProject.Children)
                {
                    string taskId, taskLinkId;
                    if (phase.Include.Checked)
                    {
                        error = Data.Ins_Task(typeId, "", phase.Title.Text, phase.Id);
                        taskId = Data.Sel_Task_Id(phase.Title.Text);


                        int phaseEstimatedHours = 0;
                        if (int.TryParse(Math.Ceiling(double.Parse(phase.EstimatedHours.Text)).ToString(), out phaseEstimatedHours))
                        {
                            Data.Ins_Estimate(typeId, taskId, TaskType.Task, new TimeSpan(phaseEstimatedHours, 0, 0));
                        }
                    }
                    else
                    {
                        taskId = Data.Sel_Task_Id(phase.Title.Text);
                    }

                    // Get the task link so that we have it for any sub tasks that are being added
                    taskLinkId = Data.Sel_Task_Link_Id(typeId, taskId);


                    // Insert the tasks
                    foreach (ProjectComponentFormControl task in this.SelectedProject.Children[phaseIndex].Children)
                    {
                        if (task.Include.Checked)
                        {
                            if (string.IsNullOrEmpty(taskId) || string.IsNullOrEmpty(taskLinkId) || taskLinkId == "-1")
                            {
                                MessageBox.Show(string.Format("Phase doesn't exit for {0}, please select it", phase.Title.Text));
                                return;
                            }
                            error = Data.Ins_New_Sub_Task(taskLinkId, "", task.Title.Text, task.Id);

                            string subTaskId = Data.Sel_Sub_Task_Id(task.Title.Text);
                            int taskEstimatedHours = 0;
                            if (int.TryParse(Math.Ceiling(double.Parse(task.EstimatedHours.Text)).ToString(), out taskEstimatedHours))
                            {
                                Data.Ins_Estimate(taskLinkId, subTaskId, TaskType.SubTask, new TimeSpan(taskEstimatedHours, 0, 0));
                            }
                        }
                    }
                    phaseIndex++;

                }
            }
            else
            {
                MessageBox.Show("Type doesn't exist, please select it");
                return;
            }
            MessageBox.Show("Share point data was imported");
            this.RefereshMain();
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