using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class LogMaintenanceForm : Form
    {
        public Form1 MainForm { get; set; }

        public LogMaintenanceForm()
        {
            InitializeComponent();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to clear log, cancel to back out", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(Constants.timeTrackFilePath);
                fi.Delete();
            }
        }

        private void btnClearPomodoro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to clear log, cancel to back out", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(Constants.pomodoroFilePath);
                fi.Delete();
            }
        }

        private void btnClearInteruptions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to clear log, cancel to back out", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(Constants.interuptionsFilePath);
                fi.Delete();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm.SetDataTable();
            MainForm.ResetComboBoxes();
            MainForm.InitializeTypes();
            MainForm.Show();
        }

        private void btnUpdateTimeLog_Click(object sender, EventArgs e)
        {
            DataTable tasksOrTypesDt = new DataTable();
            if (cbTaskList.SelectedIndex == -1 && cbTypeList.SelectedIndex == -1)
            {
                MessageBox.Show("you must select a task, type, or both");
            }
            else
            {
                DataTable dt = Utility.FetchTimeData();
                if (cbTaskList.SelectedIndex != -1)
                {
                    UpdateTasksOrTypes(MaintenanceType.Tasks, dt, ref tasksOrTypesDt);
                    if (chkUpdateTaskName.Checked && tasksOrTypesDt.Rows.Count > 0)
                    {
                        UpdateTasksOrTypesFile(Constants.tasksInProgressFilePath, Constants.tasksFilePath, Constants.tasksBackup, MaintenanceType.Tasks, tasksOrTypesDt);
                    }
                }
                if (cbTypeList.SelectedIndex != -1)
                {
                    UpdateTasksOrTypes(MaintenanceType.Types, dt, ref tasksOrTypesDt);
                    if (chkUpdateType.Checked)
                    {
                        UpdateTasksOrTypesFile(Constants.typesInProgressFilePath, Constants.typesFilePath, Constants.typesBackupFilePath, MaintenanceType.Types, tasksOrTypesDt);
                    }
                }
                RefreshDropDownLists();
            }
        }

        private void cbTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LogMaintenanceForm_Load(object sender, EventArgs e)
        {
            RefreshDropDownLists();
        }

        private void RefreshDropDownLists()
        {
            cbTaskList.Items.Clear();
            cbTypeList.Items.Clear();
            MainForm.SetDataTable();
            foreach (DataRow dr in DAL.TaskData().Rows)
            {
                cbTaskList.Items.Add(string.Format("{0} - {1}", dr[1], dr[2]));
            }
            foreach (DataRow dr in MainForm.TypesDt.Rows)
            {
                cbTypeList.Items.Add(dr[0]);
            }
            cbTypeList.SelectedIndex = cbTaskList.SelectedIndex = -1;
            cbTaskList.ResetText(); cbTypeList.ResetText();
            cbTypeList.SelectedText = cbTaskList.SelectedText = "Please select one";
        }

        private void UpdateTasksOrTypes(MaintenanceType type, DataTable dt, ref DataTable tasksOrTypesDt)
        {
            tasksOrTypesDt = type == MaintenanceType.Tasks ? DAL.TaskData() : MainForm.TypesDt;
            bool typesFound = false;
            bool tasksFound = false;
            DataRow[] drSelection;
            if (type == MaintenanceType.Tasks)
            {
                string task = cbTaskList.SelectedItem.ToString().Substring(cbTaskList.SelectedItem.ToString().IndexOf('-') + 2);
                string id = cbTaskList.SelectedItem.ToString().Remove(cbTaskList.SelectedItem.ToString().IndexOf('-') - 1);
                drSelection = tasksOrTypesDt.Select(string.Format("Task = '{0}' AND ID = '{1}'", task, id));
                foreach (DataRow dr in drSelection)
                {
                    dr[1] = txtReplaceTaskId.Text; dr[2] = txtReplaceTaskName.Text;
                }
                UpdateTasks(ref dt, out tasksFound);
            }
            else
            {
                drSelection = tasksOrTypesDt.Select(string.Format("Type = '{0}'", cbTypeList.SelectedItem));
                foreach (DataRow dr in drSelection)
                {
                    dr[0] = txtReplaceType.Text;
                }
                UpdateTypes(ref dt, out typesFound);
            }
            if (typesFound || tasksFound)
            {
                Update(ref dt);
            }
            else
            {
                MessageBox.Show("Based on your entry, no tasks or types were found in the time log for updating");
            }
        }

        private void UpdateTasks(ref DataTable dt, out bool tasksFound)
        {
            tasksFound = true;
            DataRow[] drSelection = dt.Select(string.Format("Task = '{0}'", cbTaskList.SelectedItem));
            if (drSelection.Length > 0)
            {
                if (MessageBox.Show(string.Format("Found {0} examples of task '{1}'{2}Replace with {3} - {4}?", drSelection.Length, drSelection.FirstOrDefault()[3], Environment.NewLine, txtReplaceTaskId.Text, txtReplaceTaskName.Text),
                    "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataRow dr in drSelection)
                    {
                        dr[3] = string.Format("{0} - {1}", txtReplaceTaskId.Text, txtReplaceTaskName.Text);
                    }
                }
            }
            else
            {
                tasksFound = false;
            }
        }

        private void UpdateTypes(ref DataTable dt, out bool typesFound)
        {
            typesFound = true;
            DataRow[] drSelection = dt.Select(string.Format("Type = '{0}'", cbTypeList.SelectedItem));
            if (drSelection.Length > 0)
            {
                if (MessageBox.Show(string.Format("Found {0} examples of type '{1}'{2}Replace with {3}?", drSelection.Length, drSelection.FirstOrDefault()[6], Environment.NewLine, txtReplaceType.Text),
                    "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataRow dr in drSelection)
                    {
                        dr[5] = txtReplaceType.Text;
                    }
                }
            }
            else
            {
                typesFound = false;
            }
        }

        private void Update(ref DataTable dt)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(Constants.timeTrackInProgressFilePath))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                        {
                            sw.WriteLine(string.Format(Constants.TasksFormat2, dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6]));
                        }
                        else
                        {
                            sw.WriteLine(string.Format(Constants.TasksFormat, dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5]));
                        }
                    }
                    sw.Close();
                }
                File.Replace(Constants.timeTrackInProgressFilePath, Constants.timeTrackFilePath, Constants.timeTrackBackupFilePath);
                MessageBox.Show("Successfully updated time log");
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Unable to update time log", "Failure in updating time log");
                File.Replace(Constants.timeTrackBackupFilePath, Constants.timeTrackFilePath, Constants.timeTrackBackupFilePath);
                MessageBox.Show("Time log restored from backup");
            }
        }

        private void UpdateTasksOrTypesFile(string source, string dest, string backup, MaintenanceType type, DataTable dt)
        {
            try
            {
                StreamWriter sw = File.CreateText(source);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (type == MaintenanceType.Tasks)
                    {
                        sw.WriteLine(string.Format("{0}|{1}|{2}|{3}", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]));
                    }
                    else
                    {
                        sw.WriteLine(string.Format("{0}", dt.Rows[i][0]));
                    }
                }
                sw.Close();
                File.Replace(source, dest, backup);
                MessageBox.Show(string.Format("Successfully updated names {0}", type == MaintenanceType.Types ? "type(s)" : "task(s)"));
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Failure updating types or tasks", "Failure updating types or tasks");
                if (type == MaintenanceType.Types)
                {
                    File.Replace(Constants.typesBackupFilePath, Constants.typesFilePath, Constants.typesBackupFilePath);
                    MessageBox.Show("Types restored from backup");
                }
                else
                {
                    File.Replace(Constants.tasksBackup, Constants.tasksFilePath, Constants.tasksBackup);
                    MessageBox.Show("Tasks restored from backup");
                }
            }
        }
    }
}