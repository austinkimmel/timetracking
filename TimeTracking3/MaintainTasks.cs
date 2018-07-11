using DowCorning.Applications.TimeTracking;
using System;
using System.Data;
using System.Windows.Forms;

namespace TimeTracking3
{
    public partial class MaintainTasks : Form
    {
        private TimeTrackInfo info;

        public MaintainTasks()
        {
            InitializeComponent();
            this.TypesListBox_Bind();
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
        /// Adds a new sub task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedTask = (DataRowView)this.CurrentTasksListBox.SelectedItem;
            if (selectedTask != null)
            {
                string task_id = selectedTask["task_id"].ToString();
                DataRowView selectedType = (DataRowView)this.TypesListBox.SelectedItem;
                string type_id = selectedType["type_id"].ToString();
                string link_id = selectedTask["link_id"].ToString();
                DataRowView selectedSubTask = (DataRowView)this.AvailableSubTasksListBox.SelectedItem;
                string sub_task_id = selectedSubTask["sub_task_id"].ToString();
                if (!string.IsNullOrEmpty(sub_task_id))
                {
                    string error = Data.Ins_New_Sub_Task(link_id, sub_task_id, "");
                    if (string.IsNullOrEmpty(error))
                    {
                        //MessageBox.Show("Sub Task was added for task");
                        this.info = info = new TimeTrackInfo();
                        this.TypesListBox_Bind();
                        this.TypesListBox.ClearSelected();
                        this.TypesListBox.SelectedValue = type_id;
                        this.CurrentTasksListBox.SelectedValue = task_id;
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Adds an available task to a type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedTask = (DataRowView)this.AvailableTasksListBox.SelectedItem;
            if (selectedTask != null)
            {
                string task_id = selectedTask["task_id"].ToString();
                DataRowView selectedType = (DataRowView)this.TypesListBox.SelectedItem;
                string type_id = selectedType["type_id"].ToString();

                if (!string.IsNullOrEmpty(task_id) && !string.IsNullOrEmpty(type_id))
                {
                    string error = Data.Ins_Task(type_id, task_id, "");
                    if (string.IsNullOrEmpty(error))
                    {
                        //MessageBox.Show("Task was added for type");
                        this.info = info = new TimeTrackInfo();
                        this.TypesListBox_Bind();
                        this.TypesListBox.ClearSelected();
                        this.TypesListBox.SelectedValue = selectedType.Row[0];
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRowView selectedType = (DataRowView)this.TypesListBox.SelectedItem;
            string error = string.Empty;
            string type_id = selectedType["type_id"].ToString();
            if (!string.IsNullOrEmpty(type_id))
            {
                DialogResult results = MessageBox.Show("Are you sure you want to delete the type?", "Delete Type", MessageBoxButtons.YesNo);
                if (results == System.Windows.Forms.DialogResult.Yes)
                {
                    // First delete the tasks, which will also delete the sub tasks
                    for (int x = 0; x < this.CurrentTasksListBox.Items.Count; x++)
                    {
                        DataRowView task = (DataRowView)this.CurrentTasksListBox.Items[x];
                        string task_id = task["task_id"].ToString();
                        string link_id = task["link_id"].ToString();
                        error = Data.Del_Task(task_id, link_id, type_id);
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show(error);
                            return;
                        }
                    }

                    error = Data.Del_Type(type_id);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Type was deleted");
                        this.info = null;
                        this.TypesListBox_Bind();
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a sub task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSubTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedSubTask = (DataRowView)this.CurrentSubTasksListBox.SelectedItem;
            if (selectedSubTask != null)
            {
                // Get the values from the selected row
                string task_id = selectedSubTask["task_id"].ToString();
                string type_id = selectedSubTask["type_id"].ToString();
                string sub_task_id = selectedSubTask["sub_task_id"].ToString();
                string sub_link_id = selectedSubTask["sub_link_id"].ToString();

                // Check to make sure that they are not null
                if (!string.IsNullOrEmpty(task_id) && !string.IsNullOrEmpty(type_id) &&
                    !string.IsNullOrEmpty(sub_task_id) && !string.IsNullOrEmpty(sub_link_id))
                {
                    string error = Data.Del_Sub_Task(sub_task_id, sub_link_id, type_id, task_id);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Sub Tasks is Deleted");
                        this.info = info = new TimeTrackInfo();
                        this.TypesListBox_Bind();
                        this.TypesListBox.ClearSelected();
                        this.TypesListBox.SelectedValue = type_id;
                        this.CurrentTasksListBox.SelectedValue = task_id;
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedTask = (DataRowView)this.CurrentTasksListBox.SelectedItem;
            if (selectedTask != null)
            {
                // Get the values from the selected row
                string task_id = selectedTask["task_id"].ToString();
                string type_id = selectedTask["type_id"].ToString();
                string link_id = selectedTask["link_id"].ToString();

                // Check to make sure that they are not null
                if (!string.IsNullOrEmpty(task_id) && !string.IsNullOrEmpty(type_id) && !string.IsNullOrEmpty(link_id))
                {
                    string error = Data.Del_Task(task_id, link_id, type_id);
                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Tasks is Deleted");
                        this.info = info = new TimeTrackInfo();
                        this.TypesListBox_Bind();
                        this.TypesListBox.ClearSelected();
                        this.TypesListBox.SelectedValue = type_id;
                        //this.CurrentTasksListBox.SelectedValue = task_id;
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new sub task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewSubTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedTask = (DataRowView)this.CurrentTasksListBox.SelectedItem;
            if (selectedTask != null)
            {
                string task_id = selectedTask["task_id"].ToString();
                DataRowView selectedType = (DataRowView)this.TypesListBox.SelectedItem;
                string type_id = selectedType["type_id"].ToString();
                string link_id = selectedTask["link_id"].ToString();
                if (!string.IsNullOrEmpty(link_id))
                {
                    if (!string.IsNullOrEmpty(this.txtNewSubTask.Text))
                    {
                        string error = Data.Ins_New_Sub_Task(link_id, "", txtNewSubTask.Text);
                        if (string.IsNullOrEmpty(error))
                        {
                            //MessageBox.Show("Sub Task was added for task");
                            this.info = info = new TimeTrackInfo();
                            this.txtNewSubTask.Clear();
                            this.TypesListBox_Bind();
                            this.TypesListBox.ClearSelected();
                            this.TypesListBox.SelectedValue = type_id;
                            this.CurrentTasksListBox.SelectedValue = task_id;
                            this.RefereshMain();
                        }
                        else
                        {
                            MessageBox.Show(error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewTask_Click(object sender, EventArgs e)
        {
            DataRowView selectedType = (DataRowView)this.TypesListBox.SelectedItem;
            if (selectedType != null)
            {
                string type_id = selectedType["type_id"].ToString();

                if (!string.IsNullOrEmpty(type_id) && !string.IsNullOrEmpty(this.txtNewTask.Text))
                {
                    string error = Data.Ins_Task(type_id, "", this.txtNewTask.Text);
                    if (string.IsNullOrEmpty(error))
                    {
                        //MessageBox.Show("Task was added for type");
                        this.info = info = new TimeTrackInfo();
                        this.txtNewTask.Clear();
                        this.TypesListBox_Bind();
                        this.TypesListBox.ClearSelected();
                        this.TypesListBox.SelectedValue = selectedType.Row[0];
                        this.RefereshMain();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewType_Click(object sender, EventArgs e)
        {
            string newType = this.txtNewType.Text;

            if (!string.IsNullOrEmpty(newType))
            {
                string error = Data.Ins_Type(newType);
                if (string.IsNullOrEmpty(error))
                {
                    //MessageBox.Show("Type was added");
                    this.info = null;
                    this.txtNewType.Clear();
                    this.TypesListBox_Bind();
                    this.RefereshMain();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a type");
            }
        }

        /// <summary>
        /// Referesh the sub tasks lists when the selected task changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentTasksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = ((DataRowView)this.CurrentTasksListBox.SelectedItem);
            if (selectedRow != null)
            {
                string type_id = selectedRow["type_id"].ToString();
                string task_id = selectedRow["task_id"].ToString();
                string link_id = selectedRow["link_id"].ToString();
                DataRow[] currentSubTasks = this.Info.SubTask.Select("link_id = " + link_id, "sub_task_name ASC");
                if (currentSubTasks.Length > 0)
                {
                    this.CurrentSubTasksListBox.DataSource = currentSubTasks.CopyToDataTable();
                    this.CurrentSubTasksListBox.DisplayMember = "sub_task_name";
                    this.CurrentSubTasksListBox.ValueMember = "sub_task_id";
                }
                else
                {
                    this.CurrentSubTasksListBox.DataSource = null;
                }

                DataTable availableSubTasks = Data.Sel_Available_Sub_Tasks(type_id, task_id);
                if (availableSubTasks.Rows.Count > 0)
                {
                    availableSubTasks.DefaultView.Sort = "sub_task_name ASC";
                    this.AvailableSubTasksListBox.DataSource = availableSubTasks;
                    this.AvailableSubTasksListBox.DisplayMember = "sub_task_name";
                    this.AvailableSubTasksListBox.ValueMember = "sub_task_id";
                }
                else
                {
                    this.AvailableSubTasksListBox.DataSource = null;
                }
            }
            else
            {
                this.CurrentTasksListBox.DataSource = null;
                this.CurrentSubTasksListBox.DataSource = null;
                this.AvailableSubTasksListBox.DataSource = null;
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

        private void TypesListBox_Bind()
        {
            this.TypesListBox.DataSource = this.Info.Types;
            this.TypesListBox.DisplayMember = "type_name";
            this.TypesListBox.ValueMember = "type_id";
        }

        private void TypesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TypesListBox.SelectedItem != null)
            {
                string value = ((DataRowView)this.TypesListBox.SelectedItem)[0].ToString();
                DataRow[] currentTasks = this.Info.Tasks.Select("type_id = " + value, "task_name ASC");
                if (currentTasks.Length > 0)
                {
                    this.CurrentTasksListBox.DataSource = currentTasks.CopyToDataTable();
                    this.CurrentTasksListBox.DisplayMember = "task_name";
                    this.CurrentTasksListBox.ValueMember = "task_id";
                }
                else
                {
                    this.CurrentTasksListBox.DataSource = null;
                }

                DataTable availableTasks = Data.Sel_Available_Tasks(value);
                if (availableTasks.Rows.Count > 0)
                {
                    availableTasks.DefaultView.Sort = "task_name ASC";

                    this.AvailableTasksListBox.DataSource = availableTasks;
                    this.AvailableTasksListBox.DisplayMember = "task_name";
                    this.AvailableTasksListBox.ValueMember = "task_id";
                }
                else
                {
                    this.AvailableTasksListBox.DataSource = null;
                }
            }
        }
    }
}