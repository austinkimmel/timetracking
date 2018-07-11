using System;
using System.Windows.Forms;

namespace TimeTracking3
{
    public partial class Preferences : Form
    {
        private DowCorning.Applications.TimeTracking.Preferences preferencesInstance;

        public Preferences()
        {
            InitializeComponent();
            this.SetUpRoundedTime();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool roundTime = this.chbRoundTimes.Checked;
            string roundTimeAmount = this.RoundTimeComboBox.SelectedText;
            if (!roundTime)
            {
                roundTimeAmount = string.Empty;
            }

            this.preferencesInstance.Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Hide or show the round times group box if the user want to round
        /// the times in the report or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbRoundTimes_CheckedChanged(object sender, EventArgs e)
        {
            this.RoundTimesGroupBox.Visible = this.chbRoundTimes.Checked;
        }

        private void RoundTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.preferencesInstance.RoundTimeAmount = this.RoundTimeComboBox.SelectedItem.ToString();
            this.preferencesInstance.RoundTime = this.preferencesInstance.GetRoundedTime(this.preferencesInstance.ActualTime);
            this.lblRoundTime.Text = this.preferencesInstance.RoundTime;
        }

        /// <summary>
        /// Sets up the rounded time preference controls
        /// </summary>
        private void SetUpRoundedTime()
        {
            this.preferencesInstance = new DowCorning.Applications.TimeTracking.Preferences()
            {
                ActualTime = this.lblActualTime.Text
            };

            this.preferencesInstance.RoundTime = this.preferencesInstance.GetRoundedTime(this.preferencesInstance.ActualTime);
            if (!string.IsNullOrEmpty(this.preferencesInstance.RoundTime))
            {
                this.chbRoundTimes.Checked = true;
                this.RoundTimeComboBox.SelectedItem = this.preferencesInstance.RoundTimeAmount;
                this.lblRoundTime.Text = this.preferencesInstance.RoundTime;
            }
        }
    }
}