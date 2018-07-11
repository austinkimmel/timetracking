using System;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DowCorning.Applications.TimeTracking
{
    [Serializable]
    public class TaskInfo : ICloneable
    {
        private TaskType? taskType;

        public string Name { get; set; }

        public int Seconds { get; set; }

        public int Minutes { get; set; }

        public int Hours { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TaskType TaskType
        {
            get
            {
                return taskType.Value;
            }
            set
            {
                switch (value)
                {
                    case TaskType.Type:
                        this.Task_Id = "-1";
                        this.Sub_Task_Id = "-1";
                        break;

                    case TaskType.Task:
                        this.Sub_Task_Id = "-1";
                        break;

                    case TaskType.SubTask:
                        this.Link_Id = Data.Sel_Task_Link_Id(this.Type_Id, this.Task_Id);
                        break;
                }

                taskType = value;
            }
        }

        public string Type_Id { get; set; }

        public string Task_Id { get; set; }

        public string Sub_Task_Id { get; set; }

        public string Link_Id { get; set; }

        public string Type_Name { get; set; }

        public string Task_Name { get; set; }

        public string Sub_Task_Name { get; set; }

        public TimeSpan OverallTotal { get; set; }

        public TimeSpan EstimateTotal { get; set; }

        public TimeSpan TaskTotal { get; set; }

        public string DisplayName { get; set; }

        public string SharePointId { get; set; }

        public string RoundedTime { get; set; }

        public bool RecordTime()
        {
            this.StartTime = this.EndTime.AddHours(-Hours).AddMinutes(-Minutes).AddSeconds(-Seconds); 
            bool status = Data.Ins_Time_Track(this.Type_Id, this.Task_Id, this.Sub_Task_Id, this.StartTime, this.EndTime);
            GetTime();
            return status;
        }
        
        public bool RecordTime(bool manual)
        { 
            bool status = Data.Ins_Time_Track_Manual(this.Type_Id, this.Task_Id, this.Sub_Task_Id, this.StartTime, this.Hours, this.Minutes);
            GetTime();
            return status;
        }

        /// <summary>
        /// Gets the overall time and the estimated time
        /// </summary>
        public void GetTime()
        {
            // Get overall time
            this.OverallTotal = Data.Sel_Overall_Time(this.Type_Id, this.Task_Id, this.Sub_Task_Id, this.TaskType);

            // Get estimated time
            this.GetEstimate();
        }

        private void GetEstimate()
        {
            switch (this.TaskType)
            {
                case TaskType.Type:
                    this.EstimateTotal = Data.Sel_Type_Estimate(this.Type_Id);
                    break;

                case TaskType.Task:
                    this.EstimateTotal = Data.Sel_Estimate(this.Type_Id, this.Task_Id, this.TaskType);
                    break;

                case TaskType.SubTask:
                    this.EstimateTotal = Data.Sel_Estimate(this.Link_Id, this.Sub_Task_Id, this.TaskType);
                    break;
            }
        }

        public void GetPreviousTask()
        {
        }

        public void UpdateEstimatedTime(TimeSpan newEstimate)
        {
            switch (this.TaskType)
            {
                case TaskType.Type:
                    Data.Ins_Type_Estimate(this.Type_Id, newEstimate);
                    break;

                case TaskType.Task:
                    Data.Ins_Estimate(this.Type_Id, this.Task_Id, this.TaskType, newEstimate);
                    break;

                case TaskType.SubTask:
                    Data.Ins_Estimate(this.Link_Id, this.Sub_Task_Id, this.TaskType, newEstimate);
                    break;
            }

            this.GetEstimate();
        }

        public object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
}