using System.Data;
using System.IO;

namespace TimeTracking
{
    public static class DAL
    {
        public static DataTable TaskData()
        {
            return TaskData(string.Empty);
        }

        public static DataTable TasksDataTableStructure()
        {
            DataTable mainDt = new DataTable();
            mainDt.Columns.Add("Type");
            mainDt.Columns.Add("ID");
            mainDt.Columns.Add("Task");
            mainDt.Columns.Add("FindById");
            return mainDt;
        }

        public static DataTable StateDataTableStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HasCww");
            dt.Columns.Add("IsCww");
            return dt;
        }

        public static DataTable TasksDataTable2Structure()
        {
            DataTable mainDt = new DataTable();
            mainDt.Columns.Add("Task");
            mainDt.Columns.Add("FindById");
            mainDt.Columns.Add("Task2Id");
            return mainDt;
        }

        public static DataTable NonWorkingTasksTableStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Task");
            return dt;
        }

        public static DataTable TaskData(string typeId)
        {
            DataTable mainDt = TasksDataTableStructure();
            StreamReader sr = File.OpenText(Constants.tasksFilePath);
            string input = string.Empty;
            while ((input = sr.ReadLine()) != null)
            {
                string[] arr = input.Split('|');
                DataRow dr = mainDt.NewRow();
                dr["Type"] = arr[0];
                dr["ID"] = arr[1];
                dr["Task"] = arr[2];
                dr["FindById"] = arr[3];
                mainDt.Rows.Add(dr);
            }
            sr.Close();
            DataTable returnDt = TasksDataTableStructure();
            mainDt.Select(string.Format("Type LIKE '%{0}%'", typeId), "Task DESC").CopyToDataTable(returnDt, LoadOption.OverwriteChanges);
            return typeId == string.Empty ? mainDt : returnDt;
        }

        public static DataTable ReadStateData()
        {
            DataTable dt = StateDataTableStructure();
            StreamReader sr = File.OpenText(Constants.stateFilePath);
            string input = string.Empty;
            while ((input = sr.ReadLine()) != null)
            {
                string[] arr = input.Split('|');
                DataRow dr = dt.NewRow();
                dr["HasCww"] = arr[0];
                dr["IsCww"] = arr[1];
                dt.Rows.Add(dr);
            }
            sr.Close();
            return dt;
        }

        public static DataTable NonWorkingTasks()
        {
            DataTable dt = NonWorkingTasksTableStructure();
            StreamReader sr = File.OpenText(Constants.nonWorkingTasksFilePath);
            string input = string.Empty;
            while ((input = sr.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                dr["Task"] = input;
                dt.Rows.Add(dr);
            }
            sr.Close();
            return dt;
        }

        public static DataTable TaskData2(string taskId)
        {
            DataTable dt = TasksDataTable2Structure();
            StreamReader sr = File.OpenText(Constants.tasks2FilePath);
            string input = string.Empty;
            while ((input = sr.ReadLine()) != null)
            {
                string[] arr = input.Split('|');
                DataRow dr = dt.NewRow();
                dr["Task"] = arr[0];
                dr["FindById"] = arr[1];
                dr["Task2Id"] = arr[2];
                dt.Rows.Add(dr);
            }
            sr.Close();
            DataTable returnDt = TasksDataTable2Structure();
            dt.Select(string.Format("FindById = '{0}'", taskId)).CopyToDataTable(returnDt, LoadOption.OverwriteChanges);
            return taskId == string.Empty ? dt : returnDt;
        }

        public static DataTable TaskData2()
        {
            return TaskData2(string.Empty);
        }

        public static DataTable TypesData()
        {
            DataTable typesDt = new DataTable();
            typesDt.Columns.Add("Type");
            StreamReader sr2 = File.OpenText(Constants.typesFilePath);
            string input = string.Empty;
            while ((input = sr2.ReadLine()) != null)
            {
                string[] arr = input.Split('|');
                DataRow dr = typesDt.NewRow();
                dr["Type"] = arr[0];
                typesDt.Rows.Add(dr);
            }
            sr2.Close();
            return typesDt;
        }
    }
}