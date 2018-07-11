using System;

namespace DowCorning.Applications.TimeTracking
{
    public class Preferences
    {
        private string roundTime;
        private string roundTimeAmount;
        private string actualTime;

        /// <summary>
        /// The Actual time rounded to the Round Time Amount
        /// </summary>
        public String RoundTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.roundTime))
                {
                    this.roundTime = GetRoundedTime(this.actualTime);
                }
                return this.roundTime;
            }
            set
            {
                this.roundTime = value;
            }
        }

        /// <summary>
        /// What the time should be rounded to
        /// </summary>
        public String RoundTimeAmount
        {
            get
            {
                if (string.IsNullOrEmpty(this.roundTimeAmount))
                {
                    this.roundTimeAmount = SelectRoundTimeAmount();
                }

                return this.roundTimeAmount;
            }
            set
            {
                this.roundTimeAmount = value;
            }
        }

        /// <summary>
        /// Actual time prior to rounding
        /// </summary>
        public string ActualTime
        {
            get
            {
                return this.actualTime;
            }
            set
            {
                this.actualTime = value;
            }
        }

        /// <summary>
        /// Gets the rounded time
        /// </summary>
        /// <param name="actualTime">Actual time</param>
        /// <returns>Rounded time</returns>
        public string GetRoundedTime(string actualTime)
        {
            if (string.IsNullOrEmpty(this.RoundTimeAmount))
            {
                return "";
            }
            DateTime roundTime = new DateTime();
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            string[] timeParts = actualTime.Split(':');
            if (timeParts.Length == 3)
            {
                hours = int.Parse(timeParts[0]);
                minutes = int.Parse(timeParts[1]);
                seconds = int.Parse(timeParts[2]);
            }
            else if (timeParts.Length == 2)
            {
                minutes = int.Parse(timeParts[0]);
                seconds = int.Parse(timeParts[1]);
            }
            else
            {
                seconds = int.Parse(timeParts[0]);
            }

            double minutesToRound = 60 * double.Parse(this.RoundTimeAmount);

            //Check to see if it is over 24 hours
            //if (int.Parse(actualTime.Split(':')[0]) > 23)
            //{
            //    DateTime.TryParse(actualTime, out roundTime);
            //}
            //else
            //{
            //}

            double newMinutes = (Math.Round((minutes + Math.Round(seconds / 60.0)) / minutesToRound) * minutesToRound) / 60;
            return (hours + newMinutes).ToString();
        }

        /// <summary>
        /// Saves the preferences
        /// </summary>
        /// <returns>Any errors that occured</returns>
        public string Save()
        {
            string error = string.Empty;

            error = Data.Upd_Preference("round_time_amount", this.RoundTimeAmount);

            return error;
        }

        /// <summary>
        /// Selects the round time amount
        /// </summary>
        /// <returns></returns>
        public string SelectRoundTimeAmount()
        {
            string error = string.Empty;

            return Data.Sel_Preference("round_time_amount");
        }
    }
}