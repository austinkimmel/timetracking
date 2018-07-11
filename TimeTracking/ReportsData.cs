using System.Collections.Generic;

namespace TimeTracking
{
    public class ReportsData
    {
        public int TotalTimeSpent { get; set; }

        public List<Report> Data { get; set; }

        public ReportsData()
        {
            this.Data = new List<Report>();
        }
    }

    public class Report
    {
        public string Day { get; set; }

        public string Type { get; set; }

        public int Time { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Task { get; set; }

        public string SubTask { get; set; }

        public int TotalTimeSpent { get; set; }

        public Report(string day, string start, string end, int time, string task, int totalTimeSpent, string type, string subTask)
        {
            this.Start = start; this.End = end;
            this.Time = time; this.Task = task;
            this.Day = day; this.TotalTimeSpent = totalTimeSpent;
            this.Type = type; this.SubTask = subTask;
        }
    }

    public class PomodoroData
    {
        public List<Pomodoro> Data { get; set; }

        public PomodoroData()
        {
            this.Data = new List<Pomodoro>();
        }
    }

    public class Pomodoro
    {
        public string Date { get; set; }

        public int Pomodoros { get; set; }

        public Pomodoro(string date, int count)
        {
            this.Date = date; this.Pomodoros = count;
        }
    }

    public class InteruptionsData
    {
        public List<Interuption> Data { get; set; }

        public InteruptionsData()
        {
            this.Data = new List<Interuption>();
        }
    }

    public class Interuption
    {
        public string Date { get; set; }

        public string Reason { get; set; }

        public string Time { get; set; }

        public Interuption(string date, string reason, string time)
        {
            this.Date = date; this.Reason = reason; this.Time = time;
        }
    }
}