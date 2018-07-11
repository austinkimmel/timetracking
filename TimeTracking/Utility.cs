using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeTracking
{
    public enum MaintenanceType
    {
        Tasks, Types, Tasks2
    }

    public static class Utility
    {
        public static string ParsedDate(string inDate)
        {
            return inDate.Remove(inDate.IndexOf(' '));
        }

        public static string ParsedTime(string inData)
        {
            return inData.Substring(inData.IndexOf(':') - 2);
        }

        public static void UpdatePomodoro()
        {
            WriteToFile(Constants.pomodoroFilePath, string.Format("{0}|{1}", ParsedDate(DateTime.Now.ToString()), "1"));
        }

        public static void WriteToFile(string path, string stringToWrite)
        {
            try
            {
                StreamWriter sw = File.Exists(path) ? File.AppendText(path) : File.CreateText(path);
                byte[] dateAsByteArr = Encoding.Default.GetBytes(stringToWrite);
                sw.WriteLine(stringToWrite);
                sw.Close();
            }
            catch (Exception ex)
            {
                Utility.LogEventWithEmailPrompt(ex, "Error saving", "Error saving data");
            }
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static void CheckFileExistsCreateIfNot(string path, out bool existing)
        {
            existing = true;
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                existing = false;
                FileStream fs = fi.Create();
                fs.Close();
            }
        }

        public static void LogEventWithEmailPrompt(Exception ex, string customErrorMessage, string messageBoxMessage)
        {
            ExceptionManager.LogEvent(ex, customErrorMessage, MessageBox.Show(string.Format("{0}, send error text to developer?", messageBoxMessage), "", MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.Yes ? true : false);
        }

        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogEventWithEmailPrompt((Exception)e.ExceptionObject, "An unhandled exception has occured", "Unhandled error has occured");
        }

        public static DataTable FetchTimeData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Start", typeof(DateTime));
            dt.Columns.Add("End", typeof(DateTime));
            dt.Columns.Add("Time");
            dt.Columns.Add("Task");
            dt.Columns.Add("StartString");
            dt.Columns.Add("Type");
            dt.Columns.Add("SubTask");

            bool existing;
            CheckFileExistsCreateIfNot(Constants.timeTrackFilePath, out existing);

            if (existing)
            {
                using (StreamReader streamReader = File.OpenText(Constants.timeTrackFilePath))
                {
                    string input = string.Empty;
                    while ((input = streamReader.ReadLine()) != null)
                    {
                        string[] arr = input.Split('|');
                        DataRow dr = dt.NewRow();
                        dr[0] = arr[0];
                        dr[1] = arr[1];
                        dr[2] = arr[2];
                        dr[3] = arr[3];
                        dr[4] = arr[0];
                        dr[5] = arr[5];
                        if (arr.Length == 7)
                        {
                            dr[6] = arr[6];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        public static string LastTaskInfo()
        {
            DataTable dt = Utility.FetchTimeData();
            string returnString = "N/A";
            if (dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select("", "End DESC");
                returnString = string.Format("Type: {0}{4} Task: {1}{4} Subtask: {5}{4} Start: {2}{4} End: {3}", drs[0][5], drs[0][3],
                    drs[0][0], drs[0][1], Environment.NewLine, drs[0][6]);
            }
            return returnString;
        }

        public static DataTable FetchPresets()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PresetNumber");
            dt.Columns.Add("Type");
            dt.Columns.Add("Task");
            dt.Columns.Add("Subtask");

            using (StreamReader streamReader = File.OpenText(Constants.presetsFilePath))
            {
                string input = string.Empty;
                while ((input = streamReader.ReadLine()) != null)
                {
                    string[] arr = input.Split('|');
                    DataRow dr = dt.NewRow();
                    dr[0] = arr[0];
                    dr[1] = arr[1];
                    dr[2] = arr[2];
                    dr[3] = arr[3];
                    dt.Rows.Add(dr);
                }
            }
            dt.DefaultView.Sort = "PresetNumber ASC";
            dt = dt.DefaultView.ToTable();
            return dt;
        }

        public static void UpdatePresets(int presetNum, string type, string task, string thirdLevelTask)
        {
            DataTable dt = FetchPresets();
            if (dt.Rows.Count > 0)
            {
                //remove row being added
                DataRow[] curRow = dt.Select(string.Format((presetNum - 1) < 10 ? "PresetNumber = '0{0}'" : "PresetNumber = '{0}'", presetNum - 1));
                if (curRow.Count() > 0)
                {
                    dt.Rows.Remove(curRow[0]);
                }
            }
            DataRow newRow = dt.NewRow();
            newRow[0] = (presetNum - 1) < 10 ? "0" + (presetNum - 1).ToString() : (presetNum - 1).ToString();
            newRow[1] = type;
            newRow[2] = task;
            newRow[3] = thirdLevelTask;
            dt.Rows.Add(newRow);

            bool exists;
            DeleteFile(Constants.presetsFilePath);
            CheckFileExistsCreateIfNot(Constants.presetsFilePath, out exists);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteToFile(Constants.presetsFilePath, string.Format(Constants.PresetsFormat, dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]));
            }
        }

        public static List<DateTime> LastTaskStartAndEnd()
        {
            List<DateTime> startAndEnd = new List<DateTime>();
            DataTable dt = FetchTimeData();
            if (dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select("", "End DESC");
                startAndEnd.Add((DateTime)drs[0][0]);
                startAndEnd.Add((DateTime)drs[0][1]);
            }
            return startAndEnd;
        }
    }
}