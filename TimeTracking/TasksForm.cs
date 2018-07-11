using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class TasksForm : Form
    {
        private Form1 mainForm;

        internal Form1 MainForm
        {
            get
            {
                return mainForm;
            }
            set
            {
                mainForm = value;
            }
        }

        private MaintenanceType maintType;

        internal MaintenanceType MaintType
        {
            get
            {
                return maintType;
            }
            set
            {
                maintType = value;
                if (maintType == MaintenanceType.Tasks)
                {
                    Path = Constants.tasksFilePath;
                    InProgressPath = Constants.tasksInProgressFilePath;
                    BackupPath = Constants.tasksBackup;
                    dgTaskList.DataSource = MainForm.MainDt;
                    dgTaskList.Columns[2].Width = 350;

                    dgTaskList.Sort(dgTaskList.Columns[1], ListSortDirection.Ascending);
                    dgTaskList.Columns["FindById"].Visible = false;
                }
                else if (maintType == MaintenanceType.Types)
                {
                    Path = Constants.typesFilePath;
                    InProgressPath = Constants.typesInProgressFilePath;
                    BackupPath = Constants.typesBackupFilePath;
                    dgTaskList.DataSource = MainForm.TypesDt;
                    dgTaskList.Columns[0].Width = 200;
                }
                else
                {
                    Path = Constants.tasks2FilePath;
                    InProgressPath = Constants.tasks2InProgressFilePath;
                    BackupPath = Constants.tasks2Backup;
                    dgTaskList.DataSource = MainForm.Tasks2Dt;
                    dgTaskList.Columns[0].Width = 400;
                    dgTaskList.Columns["FindById"].Visible = false;
                    dgTaskList.Columns["Task2Id"].Visible = false;
                }
            }
        }

        internal string Path { get; set; }

        internal string InProgressPath { get; set; }

        internal string BackupPath { get; set; }

        private string idOfTask = string.Empty;

        private DataTable dt = new DataTable();

        public TasksForm()
        {
            InitializeComponent();
        }

        public TasksForm(string idOfTask)
        {
            InitializeComponent();
            this.idOfTask = idOfTask;
        }

        private void dgTaskList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCommitChanges_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> items = new List<string>();
                //Utility.CheckFileExistsCreateIfNot(InProgressPath);
                using (StreamWriter sw = File.CreateText(InProgressPath))
                {
                    DataTable tasks = DAL.TasksDataTableStructure();
                    tasks = MaintType == MaintenanceType.Tasks ? DAL.TaskData() : DAL.TaskData2();
                    for (int i = 0; i < dgTaskList.Rows.Count - 1; i++)
                    {
                        if (MaintType == MaintenanceType.Tasks)
                        {
                            DataTable currentItem = DAL.TasksDataTableStructure();
                            DataRow[] drs = tasks.Select(string.Format("FindById = '{0}'", dgTaskList.Rows[i].Cells[3].Value));
                            //items.Add(string.Format("{0}|{1}|{2}", dgTaskList.Rows[i].Cells[0].Value, dgTaskList.Rows[i].Cells[1].Value, dgTaskList.Rows[i].Cells[2].Value));
                            if (drs.Count() > 0)
                            {
                                drs[0][0] = dgTaskList.Rows[i].Cells[0].Value;
                                drs[0][1] = dgTaskList.Rows[i].Cells[1].Value;
                                drs[0][2] = dgTaskList.Rows[i].Cells[2].Value;
                                //DAL.TaskData().Select(string.Format("FindById = '{0}'", "Task DESC", dgTaskList.Rows[i].Cells[3].Value)).CopyToDataTable(tasks, LoadOption.OverwriteChanges);
                            }
                            else
                            {
                                //new item they are adding
                                DataRow[] sortingDrs = DAL.TaskData().Select("");
                                int lastIdUsed = 0;
                                for (int j = 0; j < sortingDrs.Length; j++)
                                {
                                    lastIdUsed = Convert.ToInt32(sortingDrs[j][3]) > lastIdUsed ? Convert.ToInt32(sortingDrs[j][3]) : lastIdUsed;
                                }
                                DataRow dr = tasks.NewRow();
                                dr[0] = dgTaskList.Rows[i].Cells[0].Value;
                                dr[1] = dgTaskList.Rows[i].Cells[1].Value;
                                dr[2] = dgTaskList.Rows[i].Cells[2].Value;
                                dr[3] = lastIdUsed + 1;
                                tasks.Rows.Add(dr);
                            }
                        }
                        else if (MaintType == MaintenanceType.Tasks2)
                        {
                            if (string.IsNullOrEmpty(idOfTask))
                            {
                                idOfTask = MainForm.GetTaskId();
                            }
                            DataTable currentItem = DAL.TasksDataTable2Structure();
                            currentItem = DAL.TaskData2();
                            DataRow[] drs = tasks.Select(string.Format("FindById = '{0}' AND Task2Id = '{1}'", idOfTask, dgTaskList.Rows[i].Cells[2].Value));
                            if (drs.Count() > 0)
                            {
                                drs[0][0] = dgTaskList.Rows[i].Cells[0].Value;
                                drs[0][1] = dgTaskList.Rows[i].Cells[1].Value;
                                drs[0][2] = dgTaskList.Rows[i].Cells[2].Value;
                                //DAL.TaskData2().Select(string.Format("FindById = '{0}' AND Task2Id = '{1}'", idOfTask, dgTaskList.Rows[i].Cells[2].Value)).CopyToDataTable(tasks, LoadOption.);
                            }
                            else
                            {
                                int lastIdUsed = 0;
                                try
                                {
                                    lastIdUsed = Convert.ToInt32(tasks.Select("", "Task2Id DESC")[0][2]);
                                }
                                catch { }
                                DataRow dr = tasks.NewRow();
                                dr[0] = dgTaskList.Rows[i].Cells[0].Value;
                                dr[1] = idOfTask;
                                dr[2] = lastIdUsed + 1;
                                tasks.Rows.Add(dr);
                            }
                            //MainForm.Tasks2Dt.AcceptChanges();
                            tasks.AcceptChanges();
                        }
                        else
                        {
                            items.Add(string.Format("{0}", dgTaskList.Rows[i].Cells[0].Value));
                        }
                    }

                    if (MaintType == MaintenanceType.Tasks2)
                    {
                        DataTable dt = mainForm.Tasks2Dt.GetChanges(DataRowState.Deleted);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow[] curDr = tasks.Select(string.Format("Task = '{0}' AND FindById = '{1}' AND Task2Id = '{2}'",
                                    dt.Rows[j][0, DataRowVersion.Original], dt.Rows[j][1, DataRowVersion.Original], dt.Rows[j][2, DataRowVersion.Original]));
                                tasks.Rows.Remove(curDr[0]);
                            }
                        }
                        tasks.AcceptChanges();
                        for (int i = 0; i < tasks.Rows.Count; i++)
                        {
                            items.Add(string.Format("{0}|{1}|{2}", tasks.Rows[i][0], tasks.Rows[i][1], tasks.Rows[i][2]));
                        }
                    }
                    else if (MaintType == MaintenanceType.Tasks)
                    {
                        DataTable dt = mainForm.MainDt.GetChanges(DataRowState.Deleted);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow[] curDr = tasks.Select(string.Format("Type = '{0}' AND ID = '{1}' AND Task = '{2}' AND FindById = '{3}'", dt.Rows[j][0, DataRowVersion.Original], dt.Rows[j][1, DataRowVersion.Original],
                                    dt.Rows[j][2, DataRowVersion.Original], dt.Rows[j][3, DataRowVersion.Original]));
                                tasks.Rows.Remove(curDr[0]);
                            }
                        }
                        tasks.AcceptChanges();
                        for (int i = 0; i < tasks.Rows.Count; i++)
                        {
                            items.Add(string.Format("{0}|{1}|{2}|{3}", tasks.Rows[i][0], tasks.Rows[i][1], tasks.Rows[i][2], tasks.Rows[i][3]));
                        }
                    }
                }
                File.WriteAllLines(InProgressPath, items.ToArray());
                //sw.Close();
                File.Replace(InProgressPath, Path, BackupPath);
                MessageBox.Show("Successful update");
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Error commiting changes for tasks / types", "Error committing changes");
                File.Replace(BackupPath, Path, BackupPath);
                MessageBox.Show("Restored from backup");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm.SetDataTable();
            switch (MaintType)
            {
                case MaintenanceType.Types:
                    MainForm.ResetComboBoxes();
                    MainForm.InitializeTypes();
                    break;

                case MaintenanceType.Tasks:
                    MainForm.ResetTasksComboBox();
                    MainForm.ResetTasks2ComboBox();
                    MainForm.SetTasksDataTable();
                    MainForm.InitializeTasks();
                    break;

                case MaintenanceType.Tasks2:
                    MainForm.ResetTasks2ComboBox();
                    MainForm.SetTasks2DataTable();
                    MainForm.InitializeTasks2();
                    break;
            }
            MainForm.Show();
            this.Close();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
        }
    }
}