using DowCorning.Applications.TimeTracking;
using System;
using System.Windows.Forms;
using TimeTracking;

namespace TimeTracking3
{
    public partial class ManualTimeForm : Form
    {
        public Form1 MainForm { get; set; }

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
                if (this.info.CurrentTask.EndTime == DateTime.MinValue)
                {
                    this.info.CurrentTask.EndTime = this.Info.CurrentTask.StartTime.AddSeconds(this.Info.CurrentTask.Seconds).AddMinutes(this.Info.CurrentTask.Minutes).AddHours(this.Info.CurrentTask.Hours);
                }
            }
        }

        /// <summary>
        /// Gets or sets the time label
        /// </summary>
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

        private bool okWithTimeLessThanStart;

        /// <summary>
        /// Intializes a new form
        /// </summary>
        public ManualTimeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Moves the start time up an hour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHoursUp_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.StartTime = this.Info.CurrentTask.StartTime.AddHours(1);
            this.Info.CurrentTask.Hours--;
            UpdateTime();
        }

        /// <summary>
        /// Load the page and display the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualTimeForm_Load(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = this.Info.CurrentTask.StartTime.AddSeconds(this.Info.CurrentTask.Seconds).AddMinutes(this.Info.CurrentTask.Minutes).AddHours(this.Info.CurrentTask.Hours);
            lblCurrentType.Text = this.Info.CurrentTask.DisplayName;

            okWithTimeLessThanStart = false;
            RefreshTimerLabels();
            UpdateTime();
            SetState();
            if (!string.IsNullOrEmpty(this.Info.PreviousTask.DisplayName))
            {
                this.lblPreviousStart.Text = this.Info.PreviousTask.StartTime.ToString();
                this.lblPreviousEnd.Text = this.Info.PreviousTask.EndTime.ToString();
                this.lblPreviousTask.Text = this.Info.PreviousTask.DisplayName;
            }
        }

        /// <summary>
        /// Goes forward a minute on the start time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinutesUp_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.StartTime = this.Info.CurrentTask.StartTime.AddMinutes(1);

            if (this.Info.CurrentTask.Minutes - 1 != -1)
            {
                this.Info.CurrentTask.Minutes--;
            }
            else
            {
                this.Info.CurrentTask.Minutes = 59;
                this.Info.CurrentTask.Hours--;
            }
            UpdateTime();
        }

        /// <summary>
        /// Goes back a minute on the start time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinutesDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(this.Info.CurrentTask.StartTime.AddMinutes(-1), this.Info.CurrentTask.StartTime))
            {
                this.Info.CurrentTask.StartTime = this.Info.CurrentTask.StartTime.AddMinutes(-1);
                if (this.Info.CurrentTask.Minutes + 1 != 60)
                {
                    this.Info.CurrentTask.Minutes++;
                }
                else
                {
                    this.Info.CurrentTask.Minutes = 0;
                    this.Info.CurrentTask.Hours++;
                }
                UpdateTime();
            }
        }

        /// <summary>
        /// Checks if the user want the start time to be prior to the previous task end time
        /// </summary>
        /// <param name="bottomRange"></param>
        /// <param name="topRange"></param>
        /// <returns></returns>
        private bool OkToPerform(DateTime bottomRange, DateTime topRange)
        {
            bool okToPerform = false;

            if (bottomRange < this.Info.PreviousTask.EndTime)
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

            return okToPerform;
        }

        /// <summary>
        /// Moves the start time back an hour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHoursDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(this.Info.CurrentTask.StartTime.AddHours(-1), this.Info.CurrentTask.StartTime))
            {
                this.Info.CurrentTask.StartTime = this.Info.CurrentTask.StartTime.AddHours(-1);
                this.Info.CurrentTask.Hours++;
                UpdateTime();
            }
        }

        /// <summary>
        /// Displays the start and end time of the current task
        /// </summary>
        private void RefreshTimerLabels()
        {
            lblEndingTime.Text = this.Info.CurrentTask.StartTime.AddSeconds(this.Info.CurrentTask.Seconds).AddMinutes(this.Info.CurrentTask.Minutes).AddHours(this.Info.CurrentTask.Hours).ToString();
            lblStartingTime.Text = this.Info.CurrentTask.StartTime.ToString();
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Addes an hour to the end time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHoursUp2_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = this.Info.CurrentTask.EndTime.AddHours(1);
            this.Info.CurrentTask.Hours++;
            UpdateTime();
        }

        /// <summary>
        /// Takse a hour away from the end time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHoursDown2_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = this.Info.CurrentTask.EndTime.AddHours(-1);
            this.Info.CurrentTask.Hours--;
            UpdateTime();
        }

        /// <summary>
        /// Takes a minute away from the ending time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinutesDown2_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = this.Info.CurrentTask.EndTime.AddMinutes(-1);

            if (this.Info.CurrentTask.Minutes - 1 != -1)
            {
                this.Info.CurrentTask.Minutes--;
            }
            else
            {
                this.Info.CurrentTask.Minutes = 59;
                this.Info.CurrentTask.Hours--;
            }
            UpdateTime();
        }

        /// <summary>
        /// Enables/disables the buttons based on the current task time
        /// </summary>
        private void SetState()
        {
            btnHoursDown2.Enabled = this.Info.CurrentTask.EndTime.AddHours(-1) > this.Info.CurrentTask.StartTime;
            btnMinutesDown2.Enabled = this.Info.CurrentTask.EndTime.AddMinutes(-1) > this.Info.CurrentTask.StartTime;
            btnHoursUp.Enabled = this.Info.CurrentTask.StartTime.AddHours(1) < this.Info.CurrentTask.EndTime;
            btnMinutesUp.Enabled = this.Info.CurrentTask.StartTime.AddMinutes(1) < this.Info.CurrentTask.EndTime;
        }

        /// <summary>
        /// Adds a minute to the end time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinutesUp2_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = this.Info.CurrentTask.EndTime.AddMinutes(1);

            if (this.Info.CurrentTask.Minutes + 1 != 60)
            {
                this.Info.CurrentTask.Minutes++;
            }
            else
            {
                this.Info.CurrentTask.Minutes = 0;
                this.Info.CurrentTask.Hours++;
            }
            UpdateTime();
        }

        /// <summary>
        /// Update the timetracking screen with the modified data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            TimeTracking tt = new TimeTracking();
            tt.Info = this.Info;
            tt.UpdateTimerLabel();
            tt.SetTask();
            tt.State = TimeTrackingState.paused;
            tt.Show();
        }

        /// <summary>
        /// Update the time display
        /// </summary>
        private void UpdateTime()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Info.CurrentTask.Hours, Info.CurrentTask.Minutes, Info.CurrentTask.Seconds);
            this.Time = dt.ToString("HH:mm:ss");
            RefreshTimerLabels();
            SetState();
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartDaysUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddDays(1);
            MainForm.EndTime = MainForm.EndTime.AddDays(1);
            UpdateTime();
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartDaysDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddDays(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddDays(-1);
                MainForm.EndTime = MainForm.EndTime.AddDays(-1);
                UpdateTime();
            }
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonthsUp_Click(object sender, EventArgs e)
        {
            MainForm.StartTime = MainForm.StartTime.AddMonths(1);
            MainForm.EndTime = MainForm.EndTime.AddMonths(1);
            UpdateTime();
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonthsDown_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.AddMonths(-1), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.AddMonths(-1);
                MainForm.EndTime = MainForm.EndTime.AddMonths(-1);
                UpdateTime();
            }
        }

        /// <summary>
        /// Stars the current task at the end of the previous task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartAtLast_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Info.PreviousTask.DisplayName))
            {
                this.Info.CurrentTask.StartTime = this.Info.PreviousTask.EndTime.AddSeconds(1);
                this.Info.CurrentTask.EndTime = this.Info.PreviousTask.EndTime.AddSeconds(1).AddMinutes(1);
                this.Info.CurrentTask.Minutes = 1;
                this.Info.CurrentTask.Seconds = 0;
                this.Info.CurrentTask.Hours = 0;
                UpdateTime();
            }
            else
            {
                MessageBox.Show("No last task found");
            }
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartAtWorkDayStart_Click(object sender, EventArgs e)
        {
            if (OkToPerform(MainForm.StartTime.Date.AddHours(8), MainForm.StartTime))
            {
                MainForm.StartTime = MainForm.StartTime.Date.AddHours(8);
                MainForm.EndTime = MainForm.EndTime.Date.AddHours(8).AddMinutes(1);
                UpdateTime();
            }
        }

        /// <summary>
        /// Sets the end time at the current time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNow_Click(object sender, EventArgs e)
        {
            this.Info.CurrentTask.EndTime = DateTime.Now;
            TimeSpan difference = this.Info.CurrentTask.EndTime.Subtract(this.Info.CurrentTask.StartTime);
            this.Info.CurrentTask.Seconds = difference.Seconds;
            this.Info.CurrentTask.Minutes = difference.Minutes;
            this.Info.CurrentTask.Hours = difference.Hours + (difference.Days * 24);
            UpdateTime();
        }
    }
}