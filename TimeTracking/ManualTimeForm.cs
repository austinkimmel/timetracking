using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class ManualTimeForm : Form
    {
        public Form1 MainForm { get; set; }

        public string Time
        {
            get
            {
                return lblTime.Text;
            }
            set
            {
                lblTime.Text = value;
            }
        }

        private List<DateTime> lastTaskStartAndEnd;
        private bool okWithTimeLessThanStart;

        public ManualTimeForm()
        {
            InitializeComponent();
        }

        private void btnHoursUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddHours(1);
            UpdateTime();
        }

        private void ManualTimeForm_Load(object sender, EventArgs e)
        {
            lblCurrentType.Text = MainForm.CurrentType;
            lblCurrentTask.Text = MainForm.CurrentTask;
            lblCurrentSubTask.Text = MainForm.CurrentSubTask;
            okWithTimeLessThanStart = false;
            lastTaskStartAndEnd = Utility.LastTaskStartAndEnd();
            RefreshTimerLabels();
            UpdateTime();
            SetState();
            lblLastTask.Text = Utility.LastTaskInfo();
        }

        private void btnMinutesUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddMinutes(1);
            UpdateTime();
        }

        private void btnMinutesDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddMinutes(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddMinutes(-1);
                UpdateTime();
            }
        }

        private bool OkToPerform(DateTime bottomRange, DateTime topRange)
        {
            bool okToPerform = false;
            if (lastTaskStartAndEnd.Count > 0)
            {
                if (bottomRange < lastTaskStartAndEnd[1])
                {
                    if (okWithTimeLessThanStart)
                    {
                        okToPerform = true;
                    }
                    else
                    {
                        if (MessageBox.Show("You are about to change your start time to less than the last tasks end time", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            okToPerform = true;
                            okWithTimeLessThanStart = true;
                        }
                    }
                }
                else
                {
                    okToPerform = true;
                }
            }
            else
            {
                okToPerform = true;
            }
            return okToPerform;
        }

        private void btnHoursDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddHours(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddHours(-1);
                UpdateTime();
            }
        }

        private void RefreshTimerLabels()
        {
            lblEndingTime.Text = MainForm.EndTime.ToString();
            lblStartingTime.Text = MainForm.StartTime.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the time?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Time = "Time";
                MainForm.ResetTimerVariables();
                lblEndingTime.Text = "N/A";
                lblStartingTime.Text = "N/A";
                btnMinutesUp.Enabled = false; btnMinutesUp2.Enabled = false;
                btnHoursUp.Enabled = false; btnHoursUp2.Enabled = false;
                btnHoursDown.Enabled = false; btnMinutesDown.Enabled = false;
                btnHoursDown2.Enabled = false; btnMinutesDown2.Enabled = false;
                btnStartDaysUp.Enabled = false; btnStartDaysDown.Enabled = false;
                btnMonthsUp.Enabled = false; btnMonthsDown.Enabled = false;
                btnNow.Enabled = false; btnStartAtLast.Enabled = false;
                btnStartAtWorkDayStart.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnHoursUp2_Click(object sender, EventArgs e)
        {
            MainForm.EndTime = MainForm.EndTime.AddHours(1);
            UpdateTime();
        }

        private void btnHoursDown2_Click(object sender, EventArgs e)
        {
            MainForm.EndTime = MainForm.EndTime.AddHours(-1);
            UpdateTime();
        }

        private void btnMinutesDown2_Click(object sender, EventArgs e)
        {
            MainForm.EndTime = MainForm.EndTime.AddMinutes(-1);
            UpdateTime();
        }

        private string Difference()
        {
            TimeSpan ts = MainForm.EndTime - MainForm.StartTime;
            MainForm.Hours = ts.Hours; MainForm.Minutes = ts.Minutes;
            MainForm.Seconds = ts.Seconds;
            string temp = string.Empty;
            if (ts.ToString().Contains('.'))
            {
                temp = ts.ToString().Remove(ts.ToString().LastIndexOf('.'));
            }
            else
            {
                temp = ts.ToString();
            }
            return temp;
        }

        private void SetState()
        {
            btnHoursDown2.Enabled = MainForm.EndTime.AddHours(-1) > MainForm.StartTime;
            btnMinutesDown2.Enabled = MainForm.EndTime.AddMinutes(-1) > MainForm.StartTime; //MainForm.EndTime.Minute - 1 > MainForm.StartTime.Minute || MainForm.EndTime.Hour - 1 >= MainForm.StartTime.Hour;
            btnHoursUp.Enabled = MainForm.StartTime.AddHours(1) < MainForm.EndTime;
            btnMinutesUp.Enabled = MainForm.StartTime.AddMinutes(1) < MainForm.EndTime;//MainForm.StartTime.Minute + 1 < MainForm.EndTime.Minute || MainForm.StartTime.Hour + 1 <= MainForm.EndTime.Hour;
            btnHoursUp2.Enabled = MainForm.EndTime.AddHours(1) < DateTime.Now;
            btnMinutesUp2.Enabled = MainForm.EndTime.AddMinutes(1) < DateTime.Now;
            btnMonthsUp.Enabled = MainForm.EndTime.AddMonths(1) < DateTime.Now;
            btnStartDaysUp.Enabled = MainForm.EndTime.AddDays(1) < DateTime.Now;
        }

        private void btnMinutesUp2_Click(object sender, EventArgs e)
        {
            MainForm.EndTime = MainForm.EndTime.AddMinutes(1);
            UpdateTime();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm.SetLastTask();
            MainForm.UpdateTimerLabel();
            if (this.Time == "Time")
            {
                MainForm.ClearLock();
            }
            else
            {
                MainForm.CommitButtonEnabled = true;
            }
            this.Close();
            MainForm.Show();
        }

        private void UpdateTime()
        {
            MainForm.UpdateTimerLabel();
            this.Time = Difference();
            RefreshTimerLabels();
            SetState();
        }

        private void btnStartDaysUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddDays(1);
            MainForm.EndTime = MainForm.EndTime.AddDays(1);
            UpdateTime();
        }

        private void btnStartDaysDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddDays(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddDays(-1);
                MainForm.EndTime = MainForm.EndTime.AddDays(-1);
                UpdateTime();
            }
        }

        private void btnMonthsUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddMonths(1);
            MainForm.EndTime = MainForm.EndTime.AddMonths(1);
            UpdateTime();
        }

        private void btnMonthsDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddMonths(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddMonths(-1);
                MainForm.EndTime = MainForm.EndTime.AddMonths(-1);
                UpdateTime();
            }
        }

        private void btnStartAtLast_Click(object sender, EventArgs e)
        {
            List<DateTime> startAndEnd = lastTaskStartAndEnd;
            if (startAndEnd.Count > 0)
            {
                MainForm.StartTime = startAndEnd[1].AddSeconds(1);
                MainForm.EndTime = startAndEnd[1].AddSeconds(1).AddMinutes(1);
                UpdateTime();
            }
            else
            {
                MessageBox.Show("No last task found");
            }
        }

        private void btnStartAtWorkDayStart_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.Date.AddHours(8), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.Date.AddHours(8);
                MainForm.EndTime = MainForm.EndTime.Date.AddHours(8).AddMinutes(1);
                UpdateTime();
            }
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            MainForm.EndTime = DateTime.Now;
            UpdateTime();
        }
    }
}