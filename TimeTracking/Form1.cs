using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class Form1 : Form
    {
        private bool isInQuick = false;
        private bool isInSetPresetMode = false;
        private DataTable presets = null;
        private List<string> nonWorkingTasks;

        public List<string> NonWorkingHoursTasks
        {
            get
            {
                nonWorkingTasks = new List<string>();
                DataTable dt = DAL.NonWorkingTasks();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nonWorkingTasks.Add(dt.Rows[i][0].ToString());
                }
                return nonWorkingTasks;
            }
            set
            {
                nonWorkingTasks = value;
                File.WriteAllLines(Constants.nonWorkingTasksFilePath, nonWorkingTasks.ToArray());
            }
        }

        private DataTable mainDt;

        internal DataTable MainDt
        {
            get
            {
                return mainDt;
            }
            set
            {
                mainDt = value;
            }
        }

        private DataTable tasks2Dt;

        internal DataTable Tasks2Dt
        {
            get
            {
                return tasks2Dt;
            }
            set
            {
                tasks2Dt = value;
            }
        }

        private DataTable typesDt;

        internal DataTable TypesDt
        {
            get
            {
                return typesDt;
            }
            set
            {
                typesDt = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
            }
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }
        }

        public bool CommitButtonEnabled
        {
            get
            {
                return btnCommit.Enabled;
            }
            set
            {
                btnCommit.Enabled = value;
            }
        }

        public string CurrentType
        {
            get
            {
                return cbType.SelectedItem.ToString();
            }
        }

        public string CurrentTask
        {
            get
            {
                return cbTaskList.SelectedItem.ToString();
            }
        }

        public string CurrentSubTask
        {
            get
            {
                if (cbTasks2.SelectedItem != null)
                {
                    return cbTasks2.SelectedItem.ToString();
                }
                else
                {
                    return "N/A";
                }
            }
        }

        private int tick = 0;
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private int pomodoroSeconds = 60;
        private int pomodoroMinutes;
        private int pomodoroHours = 0;
        private DateTime dt;
        private DateTime startTime;
        private DateTime endTime;
        private string time = string.Empty;
        private string pomodoroTime = string.Empty;

        private List<Button> presetBtns;

        public Form1()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Utility.UnhandledException);
            InitializeComponent();
            mainDt = new DataTable();
            //InitializeDdl();
        }

        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void btnEndRecord_Click(object sender, EventArgs e)
        {
            EndTimer();
        }

        /// <summary>
        /// Pauses the timer
        /// </summary>
        private void EndTimer()
        {
            try
            {
                btnRecordQuick.Enabled = true;
                btnStartQuick.Enabled = true;
                btnPauseQuick.Enabled = false;
                btnClearLock.Enabled = true;
                chkPomodoro.Enabled = true;
                btnStartRecord.Enabled = true;
                btnEndRecord.Enabled = false;
                btnCommit.Enabled = true;
                timerTask.Stop();
                endTime = DateTime.Now;
                TimeSpan ts = new TimeSpan();
                ts = endTime - startTime;
                hours = ts.Hours;
                minutes = ts.Minutes;
                seconds = ts.Seconds;
                time = ts.ToString().Remove(ts.ToString().LastIndexOf('.'));
                lblTimerDisplay.Text = time;
                btnManualTime.Enabled = true;
                if (chkPomodoro.Checked)
                {
                    if (lblPomodoroTime.Text == "00:00:00")
                    {
                        pomodoroTimer.Stop();
                        chkPomodoro.Enabled = true;
                        if (MessageBox.Show("Accept your pomodoro point?  Be honest...", "Hooray!!!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Utility.UpdatePomodoro();
                            lblPomodoroTime.ForeColor = Color.Black;
                            ResetPomodoro();
                        }
                    }
                    else
                    {
                        this.Hide();
                        pomodoroTimer.Stop();
                        PomodoroForm pf = new PomodoroForm();
                        pf.MainForm = this;
                        pf.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Error occured in ending a time track", "Error occured on end click");
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (minutes >= 1 || hours >= 1)
            {
                if (MessageBox.Show("Click OK to commit, cancel to back out", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveTime();
                }
            }
            else
            {
                MessageBox.Show("You must commit at least 1 minute to a type / task combo");
            }
        }

        private void SaveTime()
        {
            try
            {
                EnableHotbuttons();
                string buildString = string.Empty;
                if (cbTasks2.SelectedItem != null)
                {
                    buildString = string.Format(Constants.TasksFormat2, startTime, endTime, time, cbTaskList.SelectedItem.ToString(), startTime.ToString(), cbType.SelectedItem.ToString(), cbTasks2.SelectedItem.ToString());
                }
                else
                {
                    buildString = string.Format(Constants.TasksFormat, startTime, endTime, time, cbTaskList.SelectedItem.ToString(), startTime.ToString(), cbType.SelectedItem.ToString());
                }
                StreamWriter sw = File.Exists(Constants.timeTrackFilePath) ? File.AppendText(Constants.timeTrackFilePath) : File.CreateText(Constants.timeTrackFilePath);
                if (!string.IsNullOrEmpty(buildString) && !(startTime == new DateTime()))
                {
                    //{
                    sw.WriteLine(buildString);
                    //}
                    sw.Close();
                    btnStartQuick.Enabled = true;
                    btnRecordQuick.Enabled = false;
                    btnClearLock.Enabled = false;
                    btnCommit.Enabled = false;
                    btnMaintainType.Enabled = true;
                    btnMaintainTasks.Enabled = btnMaintainTasks2.Enabled = true;
                    ResetTimerVariables();
                    cbTaskList.Enabled = cbTasks2.Enabled = true;
                    cbType.Enabled = true;
                    btnMaintainLogs.Enabled = true;
                    btnManualTime.Enabled = true;
                    startTime = new DateTime();
                    endTime = new DateTime();
                    File.Delete(Constants.timeTrackBackupFilePath);
                    File.Copy(Constants.timeTrackFilePath, Constants.timeTrackBackupFilePath);
                    SetLastTask();
                    LoadTimeSummary();
                    MessageBox.Show("Successful save");
                }
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Failed to save time data", "Failure during save");
                if (File.Exists(Constants.timeTrackBackupFilePath))
                {
                    File.Delete(Constants.timeTrackFilePath);
                    File.Copy(Constants.timeTrackBackupFilePath, Constants.timeTrackFilePath);
                }
                MessageBox.Show("Time data restored from backup");
            }
        }

        private void btnMaintainTasks_Click(object sender, EventArgs e)
        {
            this.Hide();
            TasksForm tf = new TasksForm();
            tf.MainForm = this;
            tf.MaintType = MaintenanceType.Tasks;
            tf.Show();
        }

        private void btnMaintainTasks2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TasksForm tf = new TasksForm();
            tf.MainForm = this;
            tf.MaintType = MaintenanceType.Tasks2;
            tf.Show();
        }

        public void SetDataTable()
        {
            try
            {
                typesDt = DAL.TypesData();
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Error occured in setting datatable for task or type ddl", "Error occured setting up data for tasks or types list");
            }
        }

        public void InitializeTypes()
        {
            cbType.Items.Clear();
            for (int i = 0; i < TypesDt.Rows.Count; i++)
            {
                cbType.Items.Add(string.Format("{0}", TypesDt.Rows[i][0].ToString()));
            }
        }

        public void ResetComboBoxes()
        {
            cbType.SelectedIndex = cbTaskList.SelectedIndex = cbTasks2.SelectedIndex = -1;
            cbTaskList.ResetText(); cbType.ResetText(); cbTasks2.ResetText();
            cbType.SelectedText = cbTaskList.SelectedText = cbTasks2.SelectedText = "Please select one...";
        }

        public void ResetTypesComboBox()
        {
            cbType.ResetText();
            cbType.SelectedText = "Please select one...";
            cbType.SelectedIndex = -1;
        }

        public void ResetTasksComboBox()
        {
            cbTaskList.ResetText();
            cbTaskList.SelectedText = "Please select one...";
            cbTaskList.SelectedIndex = -1;
        }

        public void ResetTasks2ComboBox()
        {
            cbTasks2.ResetText();
            cbTasks2.SelectedText = "Please select one...";
            cbTasks2.SelectedIndex = -1;
        }

        public void InitializeTasks()
        {
            cbTaskList.Items.Clear();
            for (int i = 0; i < MainDt.Rows.Count; i++)
            {
                cbTaskList.Items.Add(string.Format("{0} - {1}", MainDt.Rows[i][1].ToString(), MainDt.Rows[i][2].ToString()));
            }
        }

        private void cbTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTasks2.Items.Clear();
            ResetTasks2ComboBox();
            if (cbTaskList.SelectedIndex != -1)
            {
                Tasks2Dt = DAL.TaskData2(GetTaskId());
                InitializeTasks2();
                cbTasks2.Enabled = btnMaintainTasks2.Enabled = true;
            }
        }

        public void SetTasks2DataTable()
        {
            Tasks2Dt = DAL.TaskData2(GetTaskId());
        }

        public void SetTasksDataTable()
        {
            MainDt = DAL.TaskData(cbType.SelectedItem.ToString());
        }

        public string GetTaskId()
        {
            string[] arr = cbTaskList.SelectedItem.ToString().Split('-');
            DataRow[] item = mainDt.Select(string.Format("ID ='{0}' AND Task = '{1}'", arr[0].Trim(), arr[1].Trim()));
            return item[0][3].ToString();
        }

        public void InitializeTasks2()
        {
            cbTasks2.Items.Clear();
            for (int i = 0; i < Tasks2Dt.Rows.Count; i++)
            {
                cbTasks2.Items.Add(Tasks2Dt.Rows[i][0].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeTypes();
        }

        public void SetLastTask()
        {
            lblLastTask.Text = Utility.LastTaskInfo();
        }

        private TimeSpan TotalTime(DateTime start, DataTable time, bool includeNonWorkingTime)
        {
            return TotalTime(start, DateTime.Now, time, includeNonWorkingTime);
        }

        private TimeSpan TotalTime(DateTime start, DateTime end, DataTable time, bool includeNonWorkingTime)
        {
            string expression = string.Format("Start > '{0}' AND End < '{1}'", start.Date, end);
            if (!includeNonWorkingTime)
            {
                foreach (string str in NonWorkingHoursTasks)
                {
                    expression = string.Format("{0} AND Task NOT LIKE '%{1}%'", expression, str);
                }
            }
            DataRow[] currentDayRows = time.Select(expression);
            TimeSpan ts = new TimeSpan();
            for (int i = 0; i < currentDayRows.Length; i++)
            {
                ts = ts.Add(TimeSpan.Parse(currentDayRows[i][2].ToString()));
            }
            return ts;
        }

        public void LoadTimeSummary()
        {
            DataTable time = Utility.FetchTimeData();
            lblTotalTimeDay.Text = TotalTime(DateTime.Now.Date, time, true).ToString();

            int daysToSubtract = 0;
            daysToSubtract = Convert.ToInt32(DateTime.Now.DayOfWeek) % 7;
            lblTotalTimeWeek.Text = string.Format("{0:N2} {1}", TotalTime(DateTime.Now.AddDays(-daysToSubtract).Date, time, true).TotalHours, "hours");

            lblTotalWorkDay.Text = TotalTime(DateTime.Now.Date, time, false).ToString();

            TimeSpan tsWorkWeek = TotalTime(DateTime.Now.AddDays(-daysToSubtract).Date, time, false);
            lblTotalWorkWeek.Text = string.Format("{0:N2} {1}", tsWorkWeek.TotalHours, "hours");

            TimeSpan tsLastWeekWorkWeek = TotalTime(DateTime.Now.AddDays(-(daysToSubtract + 7)).Date, DateTime.Now.AddDays(-daysToSubtract).Date, time, false);
            int lastWeeksInitialHours = 40;
            if (chkHaveCww.Checked)
            {
                lastWeeksInitialHours = chkCww.Checked ? 44 : 36;
            }

            double hoursOwed = lastWeeksInitialHours - (tsLastWeekWorkWeek.TotalHours == 0 ? 40 : tsLastWeekWorkWeek.TotalHours);
            //lblOwed.Text = string.Format("{0:N2} {1}", hoursOwed, "hours");

            int initialHours = 40;
            if (chkHaveCww.Checked)
            {
                initialHours = chkCww.Checked ? 36 : 44;
            }
            lblRemaining.Text = string.Format("{0:N2} {1}", initialHours - tsWorkWeek.TotalHours, "hours");//((initialHours + hoursOwed) - tsWorkWeek.TotalHours), "hours");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DAL.ReadStateData();
                chkHaveCww.Checked = dt.Rows[0][0].ToString() == "1" ? true : false;
                chkCww.Checked = dt.Rows[0][1].ToString() == "1" ? true : false;
            }
            catch { }
            try
            {
                BuildPresets();

                presets = Utility.FetchPresets();

                string presetBtnId;
                Button btnPreset;
                for (int x = 0; x < presets.Rows.Count; x++)
                {
                    presetBtnId = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(x + 1) / 5)).ToString() + (((x % 5) + 1) == 0 ? 1.ToString() : ((x % 5) + 1).ToString());

                    presetBtns.ElementAt(x).Text = presets.Rows[x][1].ToString() + ", " + presets.Rows[x][2].ToString();
                    this.toolTip1.SetToolTip(this.presetBtns.ElementAt(x), FormatToolTip(presets.Rows[x]));
                }

                this.toolTip1.SetToolTip(this.btnPreset1, FormatToolTip(presets.Rows[0]));
                btnPreset1.Text = presets.Rows[0][1].ToString() + ", " + presets.Rows[0][2].ToString();

                this.toolTip1.SetToolTip(this.btnPreset2, FormatToolTip(presets.Rows[1]));
                btnPreset2.Text = presets.Rows[1][1].ToString() + ", " + presets.Rows[1][2].ToString();

                this.toolTip1.SetToolTip(this.btnPreset3, FormatToolTip(presets.Rows[2]));
                btnPreset3.Text = presets.Rows[2][1].ToString() + ", " + presets.Rows[2][2].ToString();

                this.toolTip1.SetToolTip(this.btnPreset4, FormatToolTip(presets.Rows[3]));
                btnPreset4.Text = presets.Rows[3][1].ToString() + ", " + presets.Rows[3][2].ToString();

                this.toolTip1.SetToolTip(this.btnPreset5, FormatToolTip(presets.Rows[4]));
                btnPreset5.Text = presets.Rows[4][1].ToString() + ", " + presets.Rows[4][2].ToString();
            }
            catch { }

            bool existing;
            Utility.CheckFileExistsCreateIfNot(Constants.nonWorkingTasksFilePath, out existing);
            LoadTimeSummary();

            SetLastTask();

            if (!Directory.Exists(Constants.appDirectory))
            {
                Directory.CreateDirectory(Constants.appDirectory);
            }

            Utility.CheckFileExistsCreateIfNot(Constants.tasksFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.pomodoroFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.exceptionsFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.interuptionReasonsFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.interuptionsFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.pomodoroFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.timeTrackFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.typesFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.tasks2FilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.stateFilePath, out existing);
            Utility.CheckFileExistsCreateIfNot(Constants.presetsFilePath, out existing);

            int.TryParse(ConfigurationManager.AppSettings.Get("PomodoroTime"), out pomodoroMinutes);
            if (pomodoroMinutes == 0)
            {
                pomodoroMinutes = 24;
            }
            else
            {
                pomodoroMinutes -= 1;
                pomodoroHours = pomodoroMinutes / 60;
                if ((pomodoroMinutes % 60) > 0)
                {
                    pomodoroMinutes = (pomodoroMinutes % 60);
                }
                else
                {
                    pomodoroMinutes = 0;
                }
            }
            SetDataTable();
            InitializeTypes();
        }

        private void timerTask_Tick(object sender, EventArgs e)
        {
            seconds += 1;

            if (minutes < 1)
            {
                minutes = 00;
                if (hours < 1)
                {
                    hours = 00;
                }
            }

            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }

            if (minutes == 60)
            {
                minutes = 0;
                hours += 1;
            }

            if (seconds % 20 == 0)
            {
                //tick gets off by a bit over time (losing time) this ensures that it is updating properly (every 20 seconds readjusting)
                TimeSpan ts = DateTime.Now - startTime;
                hours = ts.Hours; minutes = ts.Minutes; seconds = ts.Seconds;
            }

            UpdateTimerLabel();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
        }

        public void UpdateTimerLabel()
        {
            dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);
            time = dt.ToString("HH:mm:ss");
            lblTimerDisplay.Text = time;
        }

        public void EnableTaskAndTypeButtons()
        {
            btnMaintainType.Enabled = true;
            btnMaintainTasks.Enabled = true;
        }

        public void ResetTimerVariables()
        {
            seconds = 0; minutes = 0; hours = 0;
            lblTimerDisplay.Text = "Time";
        }

        private bool TimeIsInDefaultState()
        {
            return seconds == 0 && hours == 0 && minutes == 0;
        }

        private void btnReportView_Click(object sender, EventArgs e)
        {
            //ReportForm rf = new ReportForm();
            //rf.MainForm = this;
            //this.Hide();
            //rf.Show();
        }

        private void pomodoroTimer_Tick(object sender, EventArgs e)
        {
            if (tick == 2)
            {
                tick = 1;
            }
            else
            {
                tick = 2;
            }

            pomodoroSeconds -= 1;

            if (pomodoroSeconds < 0)
            {
                if (pomodoroMinutes != 0)
                {
                    pomodoroMinutes -= 1;
                    pomodoroSeconds = 59;
                }
                else if (pomodoroHours > 0)
                {
                    pomodoroMinutes = 59;
                    pomodoroSeconds = 59;
                    pomodoroHours -= 1;
                }
                else if (pomodoroMinutes == 0 && pomodoroSeconds < 0)
                {
                    pomodoroSeconds = 0;
                    int moddedTick = tick % 2;
                    lblPomodoroTime.ForeColor = moddedTick == 1 ? Color.Red : Color.Black;
                }
            }

            dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, pomodoroHours, pomodoroMinutes, pomodoroSeconds);
            pomodoroTime = dt.ToString("HH:mm:ss");
            lblPomodoroTime.Text = pomodoroTime;
        }

        private void btnClearPomodoro_Click(object sender, EventArgs e)
        {
        }

        public void StartTimers()
        {
            pomodoroTimer.Start();
            timerTask.Start();
            btnEndRecord.Enabled = true;
            btnStartRecord.Enabled = false;
            btnManualTime.Enabled = false;
            btnClearLock.Enabled = false;
            btnCommit.Enabled = false;
            chkPomodoro.Enabled = false;
        }

        private void btnPomodoroReport_Click(object sender, EventArgs e)
        {
            //PomodoroReport pd = new PomodoroReport();
            //pd.MainForm = this;
            //this.Hide();
            //pd.Show();
        }

        public void ResetPomodoro()
        {
            pomodoroHours = 0; pomodoroMinutes = 24; pomodoroSeconds = 60;
            lblPomodoroTime.Text = "Pomodoro";
            chkPomodoro.Enabled = true;
        }

        private void btnInteruptions_Click(object sender, EventArgs e)
        {
            //InteruptionsReport ir = new InteruptionsReport();
            //ir.MainForm = this;
            //this.Hide();
            //ir.Show();
        }

        private void btnMaintainType_Click(object sender, EventArgs e)
        {
            TasksForm tf = new TasksForm();
            tf.MainForm = this;
            tf.MaintType = MaintenanceType.Types;
            this.Hide();
            tf.Show();
        }

        private void btnMaintainLogs_Click(object sender, EventArgs e)
        {
            LogMaintenanceForm lmf = new LogMaintenanceForm();
            lmf.MainForm = this;
            this.Hide();
            lmf.Show();
        }

        private void FlipTimerChangeButtonsState()
        {
            btnManualTime.Enabled = !btnManualTime.Enabled;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetTimerVariables();
        }

        private void btnManualTime_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex != -1 && cbTaskList.SelectedIndex != -1)
            {
                cbTaskList.Enabled = false;
                cbType.Enabled = false;
                cbTasks2.Enabled = false;
                btnMaintainTasks2.Enabled = false;
                btnMaintainTasks.Enabled = false;
                btnMaintainType.Enabled = false;
                btnMaintainLogs.Enabled = false;
                btnClearLock.Enabled = true;
                if (this.StartTime == new DateTime())
                {
                    this.StartTime = DateTime.Now.AddMinutes(-1);
                    this.EndTime = DateTime.Now;
                }
                ManualTimeForm mtf = new ManualTimeForm();
                mtf.MainForm = this;
                mtf.Time = time;
                this.Hide();
                mtf.Show();
            }
            else
            {
                MessageBox.Show("You must first select a task and type to log time against");
            }
        }

        private void btnClearLock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear your current time log against selected type and task", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ClearLock();
            }
        }

        public void ClearLock()
        {
            startTime = new DateTime();
            endTime = new DateTime();
            cbTaskList.Enabled = true; cbType.Enabled = true;
            ResetTimerVariables();
            EnableTaskAndTypeButtons();
            btnCommit.Enabled = false; btnStartRecord.Enabled = true; btnEndRecord.Enabled = false;
            btnClearLock.Enabled = false; btnManualTime.Enabled = true;
            btnMaintainTasks2.Enabled = cbTasks2.Enabled = true;
            btnMaintainLogs.Enabled = true;
            ResetPomodoro();
            EnableHotbuttons();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTasksComboBox();
            ResetTasks2ComboBox();
            if (cbType.SelectedItem != null)
            {
                mainDt = DAL.TaskData(cbType.SelectedItem.ToString());
                InitializeTasks();
            }
            cbTaskList.Enabled = btnMaintainTasks.Enabled = true;
        }

        public void SetTasksToDefault()
        {
            cbTaskList.Items.Clear();
            cbTaskList.Enabled = false;
            btnMaintainTasks.Enabled = false;
        }

        public void SetTasks2ToDefault()
        {
            cbTasks2.Items.Clear();
            cbTasks2.Enabled = false;
            cbTasks2.Enabled = false;
        }

        private void lblTotalTimeWeek_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NonWorkingHoursTasks nwt = new NonWorkingHoursTasks();
            nwt.MainForm = this;
            nwt.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void chkCww_CheckedChanged(object sender, EventArgs e)
        {
            LoadTimeSummary();
            Utility.DeleteFile(Constants.stateFilePath);
            string buildString = string.Empty;
            if (chkHaveCww.Checked)
            {
                Utility.WriteToFile(Constants.stateFilePath, chkCww.Checked ? "1|1" : "1|0");
            }
        }

        private void chkHaveCww_CheckedChanged(object sender, EventArgs e)
        {
            chkCww.Visible = chkHaveCww.Checked;
            chkCww.Checked = chkHaveCww.Checked;
            if (chkHaveCww.Checked)
            {
                Utility.DeleteFile(Constants.stateFilePath);
                Utility.WriteToFile(Constants.stateFilePath, "1|0");
            }
            else
            {
                LoadTimeSummary();
                Utility.DeleteFile(Constants.stateFilePath);
                Utility.WriteToFile(Constants.stateFilePath, "0|0");
            }
        }

        private void btnSetPresets_Click(object sender, EventArgs e)
        {
            if (!isInSetPresetMode)
            {
                HotButtonsModeOn();
                RemoveClickEvent(btnPreset1);
                RemoveClickEvent(btnPreset2);
                RemoveClickEvent(btnPreset3);
                RemoveClickEvent(btnPreset4);
                RemoveClickEvent(btnPreset5);
                btnPreset1.Click += new EventHandler(SetPreset);
                btnPreset2.Click += new EventHandler(SetPreset);
                btnPreset3.Click += new EventHandler(SetPreset);
                btnPreset4.Click += new EventHandler(SetPreset);
                btnPreset5.Click += new EventHandler(SetPreset);
                isInSetPresetMode = true;
                foreach (Button btn in presetBtns)
                {
                    RemoveClickEvent(btn);
                    btn.Click += new EventHandler(SetPreset);
                }
            }
            else
            {
                HotButtonsModeOff();
                RemoveClickEvent(btnPreset1);
                RemoveClickEvent(btnPreset2);
                RemoveClickEvent(btnPreset3);
                RemoveClickEvent(btnPreset4);
                RemoveClickEvent(btnPreset5);
                btnPreset1.Click += new EventHandler(btnPreset1_Click);
                btnPreset2.Click += new EventHandler(btnPreset2_Click);
                btnPreset3.Click += new EventHandler(btnPreset3_Click);
                btnPreset4.Click += new EventHandler(btnPreset4_Click);
                btnPreset5.Click += new EventHandler(btnPreset5_Click);
                foreach (Button btn in presetBtns)
                {
                    RemoveClickEvent(btn);
                    btn.Click += new EventHandler(btnPreset_Click);
                }
                isInSetPresetMode = false;
            }
        }

        private void StartPresetRecording(int presetNum)
        {
            int rowIndex = presetNum - 1;
            if (presets.Rows.Count >= presetNum)
            {
                endTime = DateTime.Now;
                if (!string.IsNullOrEmpty(time))
                {
                    SaveTime();
                }

                //DisableHotbuttons();
                cbType.SelectedItem = presets.Rows[rowIndex][1].ToString();
                cbTaskList.SelectedItem = presets.Rows[rowIndex][2].ToString();
                if (!string.IsNullOrEmpty(presets.Rows[rowIndex][3].ToString()))
                {
                    cbTasks2.SelectedItem = presets.Rows[rowIndex][3].ToString();
                }
                btnStartRecord_Click(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("First assign this hot button a type & task");
            }
        }

        private void SetPreset(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex != -1 && cbTaskList.SelectedIndex != -1)
            {
                Button btn = sender as Button;
                //int curNum = 1;
                //int.TryParse(btn.Name.Substring(btn.Name.LastIndexOf('t') + 1), out curNum);

                string id = btn.Name.Substring("present".Length - 1, (btn.Name.Length - "present".Length) + 1);
                int preset = (int.Parse(id.Substring(0, 1)) - 1) * 5;
                preset = preset + (int.Parse(id.Substring(1, 1)));

                btn.Text = string.Format("{0}, {1}", cbType.SelectedItem.ToString(), cbTaskList.SelectedItem.ToString());
                Utility.UpdatePresets(preset, cbType.SelectedItem.ToString(), cbTaskList.SelectedItem.ToString(), cbTasks2.SelectedItem == null ? string.Empty : cbTasks2.SelectedItem.ToString());
                presets = Utility.FetchPresets();
                this.toolTip1.SetToolTip(btn, FormatToolTip(presets.Rows[preset - 1]));
            }
            else
            {
                MessageBox.Show("You must first select a type and task");
            }
        }

        private void RemoveClickEvent(Button b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void HotButtonsModeOn()
        {
            btnStartRecord.Enabled = false;
            btnEndRecord.Enabled = false;
            btnCommit.Enabled = false;
            btnClearLock.Enabled = false;
            chkCww.Enabled = false;
            chkHaveCww.Enabled = false;
            btnManualTime.Enabled = false;
            btnInteruptions.Enabled = false;
            btnPomodoroReport.Enabled = false;
            btnReportView.Enabled = false;
            btnMaintainLogs.Enabled = false;
            btnManageNonWorking.Enabled = false;
            chkPomodoro.Enabled = false;
            pnlHotButtons.BackColor = Color.Red;
        }

        private void HotButtonsModeOff()
        {
            ClearLock();
            btnManageNonWorking.Enabled = true;
            btnReportView.Enabled = true;
            btnPomodoroReport.Enabled = true;
            btnInteruptions.Enabled = true;
            btnMaintainLogs.Enabled = true;
            chkHaveCww.Enabled = true;
            if (chkHaveCww.Enabled)
            {
                chkCww.Enabled = true;
            }
            chkPomodoro.Enabled = true;
            pnlHotButtons.BackColor = DefaultBackColor;
        }

        private void btnPreset_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string id = btn.Name.Substring("present".Length - 1, (btn.Name.Length - "present".Length) + 1);
            int preset = (int.Parse(id.Substring(0, 1)) - 1) * 5;
            preset = preset + (int.Parse(id.Substring(1, 1)));
            StartPresetRecording(preset);
        }

        private void btnPreset1_Click(object sender, EventArgs e)
        {
            StartPresetRecording(1);
        }

        private void btnPreset2_Click(object sender, EventArgs e)
        {
            StartPresetRecording(2);
        }

        private void btnPreset3_Click(object sender, EventArgs e)
        {
            StartPresetRecording(3);
        }

        private void btnPreset4_Click(object sender, EventArgs e)
        {
            StartPresetRecording(4);
        }

        private void btnPreset5_Click(object sender, EventArgs e)
        {
            StartPresetRecording(5);
        }

        private void DisableHotbuttons()
        {
            btnPreset1.Enabled = false;
            btnPreset2.Enabled = false;
            btnPreset3.Enabled = false;
            btnPreset4.Enabled = false;
            btnSetPresets.Enabled = false;
        }

        private void EnableHotbuttons()
        {
            btnPreset1.Enabled = true;
            btnPreset2.Enabled = true;
            btnPreset3.Enabled = true;
            btnPreset4.Enabled = true;
            btnSetPresets.Enabled = true;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            if (!isInQuick)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.pnlHotButtons.BorderStyle = BorderStyle.FixedSingle;
                this.TopMost = true;
                isInQuick = true;
                this.Height = 40;
                this.Top = Screen.AllScreens.Last().WorkingArea.Bottom - this.Height;
                this.Left = Screen.AllScreens.Last().WorkingArea.Left;
                btnPreset1.Height = 20;
                btnPreset2.Height = 20;
                btnPreset3.Height = 20;
                btnPreset4.Height = 20;
                btnPreset5.Height = 20;
                btnSetPresets.Visible = false;
                lblTimerDisplay.Location = new Point(685, 2);
                lblTimerDisplay.Font = new Font("Microsoft Sans Serif", 8);
            }
            else
            {
                this.TopMost = false;
                isInQuick = false;
                this.Height = 623;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
                this.pnlHotButtons.BorderStyle = BorderStyle.None;
                this.Top = 200;
                btnPreset1.Height = 60;
                btnPreset2.Height = 60;
                btnPreset3.Height = 60;
                btnPreset4.Height = 60;
                btnPreset5.Height = 60;
                btnSetPresets.Visible = true;
                lblTimerDisplay.Location = new Point(103, 293);
                lblTimerDisplay.Font = new Font("Microsoft Sans Serif", 36);
            }
        }

        /// <summary>
        ///   Starts the timer
        /// </summary>
        private void StartTimer()
        {
            if (cbTaskList.SelectedIndex != -1 && cbType.SelectedIndex != -1)
            {
                chkPomodoro.Enabled = false;
                cbTaskList.Enabled = false;
                cbType.Enabled = false;
                btnEndRecord.Enabled = true;
                btnCommit.Enabled = false;
                btnMaintainTasks.Enabled = false;
                btnMaintainType.Enabled = false;
                btnMaintainTasks2.Enabled = false;
                btnMaintainLogs.Enabled = false;
                cbTasks2.Enabled = false;
                btnStartQuick.Enabled = false;
                btnRecordQuick.Enabled = false;
                btnPauseQuick.Enabled = true;
                timerTask.Start();
                startTime = startTime == new DateTime() ? DateTime.Now : DateTime.Now.AddHours(-hours).AddMinutes(-minutes).AddSeconds(-seconds);
                btnStartRecord.Enabled = false;
                //DisableHotbuttons();
                lblTask.Text = string.Format("{0}, {1}, {2}", cbTaskList.SelectedItem, cbType.SelectedItem, cbTasks2.SelectedItem);
                if (chkPomodoro.Checked)
                {
                    pomodoroTimer.Start();
                    chkPomodoro.Enabled = false;
                }
                if (btnManualTime.Enabled == true)
                {
                    btnManualTime.Enabled = false;
                }
                btnClearLock.Enabled = false;
            }
            else
            {
                MessageBox.Show("You must first select a task and type to log time against");
            }
        }

        private void btnStartQuick_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void btnPauseQuick_Click(object sender, EventArgs e)
        {
            EndTimer();
        }

        private void btnRecordQuick_Click(object sender, EventArgs e)
        {
            SaveTime();
        }

        /// <summary>
        ///   Formats the value from the present datarow into a tool tip
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string FormatToolTip(DataRow dr)
        {
            string toolTip = dr[1].ToString() + ", " + dr[2].ToString();

            // Add the sub task if there is one
            toolTip = (!string.IsNullOrEmpty(dr[3].ToString())) ? toolTip + ", " + dr[3].ToString() : toolTip;

            return toolTip;
        }

        private void BuildPresets()
        {
            int rows = 2;
            int cols = 5;
            int height = 20;
            int width = 125;

            //Button[][] presetBtns =
            presetBtns = new List<Button>();
            for (int y = 1; y <= rows; y++)
            {
                for (int x = 1; x <= cols; x++)
                {
                    presetBtns.Add(new Button() { Name = "preset" + y.ToString() + x.ToString(), Height = height, Width = width, Location = new Point((x - 1) * width, (y - 1) * height + 2) });
                }
            }

            foreach (Button btn in presetBtns)
            {
                this.pnlHotButtons.Controls.Add(btn);
                btn.Click += new EventHandler(btnPreset_Click);
            }
        }

        private void pnlHotButtons_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}