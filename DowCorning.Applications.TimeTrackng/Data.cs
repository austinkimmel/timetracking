using System;
using System.Data;
using System.Data.SqlServerCe;
using TimeTracking;

namespace DowCorning.Applications.TimeTracking
{
    /// <summary>
    /// Preforms all of the actions that are directed against the database
    /// </summary>
    public static class Data
    {
        public static string ConString = string.Format(@"Data Source={0}\TimeTracking.sdf;password=", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        /// <summary>
        /// Copies over the data from the flat files into the database
        /// </summary>
        static public void MigrateData()
        {
            FillType();
            FillTask();
            FillSubTasks();
        }

        /// <summary>
        ///  Fills the type table from the type flat file
        /// </summary>
        static public void FillType()
        {
            using (SqlCeConnection con = new SqlCeConnection(ConString))
            {
                con.Open();
                SqlCeCommand comm;

                // Get the current max id for tasks
                comm = new SqlCeCommand("Select max(type_id) + 1 from type", con);
                int startingTypeId;
                int.TryParse(comm.ExecuteScalar().ToString(), out startingTypeId);

                DataTable types = DAL.TypesData();

                //string ins = "Insert Into Type values ('{0}','{1}',null) ";
                string ins = "Insert Into Type (type_name) values ('{0}') ";
                string checkTypeExists = "Select 1 From Type where type_name = '{0}'";
                string insQuery = string.Empty;
                for (int x = 1; x < types.Rows.Count; x++)
                {
                    string type_name = types.Rows[x][0].ToString();

                    // Insert the task if it doesn't exist
                    comm = new SqlCeCommand(string.Format(checkTypeExists, type_name), con);
                    if (comm.ExecuteScalar() == null)
                    {
                        //insQuery = string.Format(ins, startingTypeId, type_name);
                        insQuery = string.Format(ins, type_name);
                        comm = new SqlCeCommand(insQuery, con);
                        comm.ExecuteNonQuery();
                        startingTypeId++;
                    }
                }

                con.Close();
            }
        }

        /// <summary>
        ///  Fills the Task table from the current task flat file
        /// </summary>
        static public void FillTask()
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand("Select * from Type", con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable dsData = new DataTable("Type");
            sqlda.Fill(dsData);

            // Get the current max id for tasks
            comm = new SqlCeCommand("Select max(task_id) + 1 from task", con);
            int startingTaskId;
            int.TryParse(comm.ExecuteScalar().ToString(), out startingTaskId);

            comm = new SqlCeCommand("Select max(link_id) + 1 from task_link", con);
            int startingTaskLinkId;
            int.TryParse(comm.ExecuteScalar().ToString(), out startingTaskLinkId);

            string task;
            string insTask = "Insert Into Task (task_name) Values('{0}')";
            string insTaskLink = "Insert Into Task_Link (type_id, task_id) Values('{0}','{1}')";
            string insQuery = string.Empty;
            string checkTaskExists = "Select 1 From Task where task_name = '{0}'";
            string checkTaskLinkExists = "Select 1 From Task_link where type_id = '{0}' and task_id = '{1}'";
            string selTaskId = "Select task_id from Task where task_name = '{0}'";
            DataTable tasks;
            for (int x = 0; x < dsData.Rows.Count; x++)
            {
                tasks = DAL.TaskData(dsData.Rows[x][1].ToString());
                for (int j = 0; j < tasks.Rows.Count; j++)
                {
                    // Get the task name
                    task = tasks.Rows[j][1].ToString();
                    if (!string.IsNullOrEmpty(tasks.Rows[j][2].ToString()))
                    {
                        task += " - " + tasks.Rows[j][2].ToString();
                    }

                    // Insert the task if it doesn't exist
                    comm = new SqlCeCommand(string.Format(checkTaskExists, task), con);
                    if (comm.ExecuteScalar() == null)
                    {
                        //insQuery = string.Format(insTask, startingTaskId, task);
                        insQuery = string.Format(insTask, task);
                        comm = new SqlCeCommand(insQuery, con);
                        comm.ExecuteNonQuery();
                        startingTaskId++;
                    }

                    // Get the task id
                    comm = new SqlCeCommand(string.Format(selTaskId, task), con);
                    int taskId;
                    int.TryParse(comm.ExecuteScalar().ToString(), out taskId);

                    // Insert the task_link if it doesn't exist
                    comm = new SqlCeCommand(string.Format(checkTaskLinkExists, dsData.Rows[x][0].ToString(), taskId), con);
                    if (comm.ExecuteScalar() == null)
                    {
                        insQuery = string.Format(insTaskLink, dsData.Rows[x][0].ToString(), taskId);
                        comm = new SqlCeCommand(insQuery, con);
                        comm.ExecuteNonQuery();
                        startingTaskLinkId++;
                    }
                }
            }

            con.Close();
        }

        /// <summary>
        /// Migrateds the sub tasks from the old time keeping flat files
        /// </summary>
        static public void FillSubTasks()
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand("Select * from Type", con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable dsData = new DataTable("Type");
            sqlda.Fill(dsData);

            DataTable tasks;
            DataTable subTasks;
            string selTaskId = @"SELECT task_id
                                from task
                                where task_name = '{0}'";
            string selTaskLinkId = @"SELECT link_id
                                    from task_link
                                    where type_id = '{0}' and task_id = '{1}'";
            string selSubTaskId = @"Select sub_task_id
                                    from sub_task
                                    where sub_task_name = '{0}'";
            string insSubTask = @"INSERT INTO Sub_Task
                                (sub_task_name)
                                Values('{0}')";
            string insSubTaskLink = @"INSERT INTO Sub_Task_Link
                                    (link_id, sub_task_id, estimated_time)
                                    VALUES('{0}','{1}', 0)";
            string checkSubTaskExists = "Select 1 From sub_Task where sub_task_name = '{0}'";
            string checkSubTaskLinkExists = "Select 1 From sub_Task_link where link_id = '{0}' and sub_task_id = '{1}'";
            string tasks_name;
            string subTask_name;
            string insQuery;
            int task_id;
            int task_link_id;
            string type_name;
            int type_id;
            int sub_task_id;
            for (int x = 0; x < dsData.Rows.Count; x++)
            {
                type_id = int.Parse(dsData.Rows[x][0].ToString());

                tasks = DAL.TaskData(dsData.Rows[x][1].ToString());
                for (int y = 0; y < tasks.Rows.Count; y++)
                {
                    tasks_name = tasks.Rows[y][1].ToString();
                    if (!string.IsNullOrEmpty(tasks.Rows[y][2].ToString()))
                    {
                        tasks_name += " - " + tasks.Rows[y][2].ToString();
                    }

                    // Get the task_id
                    comm = new SqlCeCommand(string.Format(selTaskId, tasks_name), con);
                    if (int.TryParse(comm.ExecuteScalar().ToString(), out task_id))
                    {
                        // get the task_link_id
                        comm = new SqlCeCommand(string.Format(selTaskLinkId, type_id, task_id), con);
                        if (int.TryParse(comm.ExecuteScalar().ToString(), out task_link_id))
                        {
                            subTasks = DAL.TaskData2(tasks.Rows[y][3].ToString());
                            
                            // Loop through the subTasks
                            for (int i = 0; i < subTasks.Rows.Count; i++)
                            {
                                subTask_name = subTasks.Rows[i][0].ToString();

                                // Insert the sub task if it doesn't exist
                                comm = new SqlCeCommand(string.Format(checkSubTaskExists, subTask_name), con);
                                if (comm.ExecuteScalar() == null)
                                {
                                    insQuery = string.Format(insSubTask, subTask_name);
                                    comm = new SqlCeCommand(insQuery, con);
                                    comm.ExecuteNonQuery();
                                }

                                // get the sub_task_id
                                comm = new SqlCeCommand(string.Format(selSubTaskId, subTask_name), con);
                                if (int.TryParse(comm.ExecuteScalar().ToString(), out sub_task_id))
                                {
                                    // Insert the sub_task_link if it doesn't exist
                                    comm = new SqlCeCommand(string.Format(checkSubTaskLinkExists, task_link_id, sub_task_id), con);
                                    if (comm.ExecuteScalar() == null)
                                    {
                                        insQuery = string.Format(insSubTaskLink, task_link_id, sub_task_id);
                                        comm = new SqlCeCommand(insQuery, con);
                                        comm.ExecuteScalar();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Selects all of the types from the database
        /// </summary>
        /// <returns>All of the types</returns>
        static public DataTable TypeList()
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand("Select * from Type order by type_name", con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable typeList = new DataTable("Type");
            sqlda.Fill(typeList);

            con.Close();

            return typeList;
        }

        /// <summary>
        ///  Gets a list of the tasks associated to the Types
        /// </summary>
        /// <returns>All of the tasks</returns>
        static public DataTable TaskList()
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand(@"select t.type_id, ta.task_id, ta.task_name, l.estimated_time, l.link_id, l.sharepoint_id
                                      from type t
                                      inner join task_link l on t.type_id = l.type_id
                                      inner join task ta on l.task_id = ta.task_id
                                      order by t.type_id, ta.task_name", con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable taskList = new DataTable("TaskList");
            sqlda.Fill(taskList);

            con.Close();

            return taskList;
        }

        /// <summary>
        /// Gets all of the sub tasks
        /// </summary>
        /// <returns>All of the sub tasks</returns>
        static public DataTable SubTaskList()
        {
            string selSubTasks = @"SELECT t.type_id, ta.task_id, ta.task_name, l.estimated_time, l.link_id, st.sub_task_id, st.sub_task_name, sl.sub_link_id, sl.estimated_time, sl.sharepoint_id
                                     FROM            Type AS t INNER JOIN
                                     Task_Link AS l ON t.type_id = l.type_id INNER JOIN
                                     Task AS ta ON l.task_id = ta.task_id INNER JOIN
                                     Sub_Task_Link AS sl ON sl.link_id = l.link_id INNER JOIN
                                     Sub_Task AS st ON st.sub_task_id = sl.sub_task_id
                                     ORDER BY t.type_id, ta.task_name, st.sub_task_name";
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand(selSubTasks, con);

            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable subTaskList = new DataTable("SubTaskList");
            sqlda.Fill(subTaskList);

            con.Close();

            return subTaskList;
        }

        /// <summary>
        /// Adds a new type
        /// </summary>
        /// <param name="type_name"> Name of type</param>
        /// <returns> Any errors or if type already exists</returns>
        static public string Ins_Type(string type_name)
        {
            return Ins_Type(type_name, -1);
        }

        /// <summary>
        /// Adds a new type
        /// </summary>
        /// <param name="type_name"> Name of type</param>
        /// <param name="sharePoint_id">Id of sharepoint item</param>
        /// <returns> Any errors or if type already exists</returns>
        static public string Ins_Type(string type_name, int sharePoint_id)
        {
            string error = string.Empty;

            string exists_string = string.Format(@"SELECT        type_id, type_name, estimated_time
                                                   FROM            Type
                                                    WHERE        (UPPER(type_name) = UPPER('{0}'))", type_name);

            DataTable dt = Fill_DataTable(exists_string);

            if (dt.Rows.Count == 0)
            {
                string ins_string = string.Format(@"INSERT INTO Type
                                    (type_name, sharepoint_id)
                                    VALUES('{0}','{1}')", type_name, sharePoint_id);

                Execute_Scalar(ins_string);
            }
            else
            {
                error = "Type already exists";
            }

            return error;
        }

        /// <summary>
        /// Deletes a type and all of the time tracking entries for that type
        /// </summary>
        /// <param name="type_id">ID of the type</param>
        /// <returns>Any errors</returns>
        static public string Del_Type(string type_id)
        {
            string error = string.Empty;

            string del_string = string.Format(@"DELETE FROM Type
                                                WHERE        (type_id = '{0}')", type_id);
            var results = Execute_Scalar(del_string);
            if (results != null)
            {
                error = results.ToString();
            }

            // Delete the time tracking records
            string del_time_track = string.Format(@"Delete time_track
                                                    where type_id = '{0}'
                                                    and task_id = '-1'
                                                    and sub_task_id = '-1'", type_id);
            results = Execute_Scalar(del_time_track);
            if (results != null)
            {
                error = results.ToString();
            }

            return error;
        }

        /// <summary>
        /// Inserts a task that is created normally
        /// </summary>
        /// <param name="type_id">Type task is under</param>
        /// <param name="task_id">Id of the task</param>
        /// <param name="task_name">Name of the task</param>
        /// <returns>Any errors</returns>
        static public string Ins_Task(string type_id, string task_id, string task_name)
        {  
            return Ins_Task(type_id, task_id, task_name, -1);
        }

        /// <summary>
        /// Inserts a task that is created from importating data from estimateion list
        /// </summary>
        /// <param name="type_id">Type task is under</param>
        /// <param name="task_id">Id of the task</param>
        /// <param name="task_name">Name of the task</param>
        /// <param name="sharepoint_id">Sharepoint id from the estimation list</param>
        /// <returns>Any errors</returns>
        static public string Ins_Task(string type_id, string task_id, string task_name, int sharepoint_id)
        {
            string error = string.Empty;

            // New task if task_id is empty
            if (string.IsNullOrEmpty(task_id))
            {
                string exists_string = string.Format(@"SELECT        task_id
                                                   FROM            Task
                                                    WHERE        (UPPER(task_name) = UPPER('{0}'))", task_name);
                DataTable dt = Fill_DataTable(exists_string);

                if (dt.Rows.Count != 0)
                {
                    task_id = dt.Rows[0]["task_id"].ToString();
                }
                else
                {
                    string ins_string = string.Format(@"INSERT INTO Task
                                                    (task_name)
                                                    VALUES('{0}');", task_name);
                    var ins_results = Execute_Scalar(ins_string);
                    if (ins_results == null)
                    {
                        string sel_string = string.Format(@"
                                                    select task_id
                                                    from task
                                                    where task_name = '{0}';", task_name);

                        DataTable dtTask_id = Fill_DataTable(sel_string);
                        if (dtTask_id.Rows.Count == 1)
                        {
                            task_id = dtTask_id.Rows[0]["task_id"].ToString();
                        }
                    }
                    else
                    {
                        return "error inserting new task: " + ins_results.ToString();
                    }
                }
            }

            error = Ins_Task_Link(type_id, task_id, sharepoint_id);

            return error;
        }

        /// <summary>
        /// Checks to see if a task link exists, and if it doesn't it adds it to the database
        /// </summary>
        /// <param name="type_id">Id of the type</param>
        /// <param name="task_id">Id of the task</param>
        /// <param name="sharepoint_id">Estimation list id</param>
        /// <returns>Any errors</returns>
        static public string Ins_Task_Link(string type_id, string task_id, int sharepoint_id)
        {
            string error = string.Empty;

            // Check to make sure that the task doesn't already belong to the type
            string sel_task_link = string.Format(@"select link_id
                                                    from Task_Link
                                                    where type_id = '{0}' and task_id = '{1}'", type_id, task_id);
            if (Execute_Scalar(sel_task_link) == null)
            {
                // Add the task link
                string ins_task_link = sharepoint_id == -1 ?
                    string.Format(@"INSERT INTO Task_Link
                        (type_id, task_id)
                        VALUES('{0}','{1}')", type_id, task_id) :
                     string.Format(@"INSERT INTO Task_Link
                        (type_id, task_id, sharepoint_id)
                        VALUES('{0}','{1}', '{2}')", type_id, task_id, sharepoint_id);

                var results = Execute_Scalar(ins_task_link);
                if (results != null)
                {
                    error = results.ToString();
                }
            }

            return error;
        }

        /// <summary>
        /// Inserts a new sub task normally
        /// </summary>
        /// <param name="link_id">Id of link from type to task</param>
        /// <param name="sub_task_id">Id of sub task</param>
        /// <param name="sub_task_name">Name of sub task</param>
        /// <returns>Any errors</returns>
        static public string Ins_New_Sub_Task(string link_id, string sub_task_id, string sub_task_name)
        {
            return Ins_New_Sub_Task(link_id, sub_task_id, sub_task_name, -1);
        }

        /// <summary>
        /// Inserts a new sub task, called directly when sub task is added from estimation list
        /// </summary>
        /// <param name="link_id">Id of link from type to task</param>
        /// <param name="sub_task_id">Id of sub task</param>
        /// <param name="sub_task_name">Name of sub task</param>
        /// <param name="sharepoint_id">Id from estimation list</param>
        /// <returns>Any errors</returns>
        static public string Ins_New_Sub_Task(string link_id, string sub_task_id, string sub_task_name, int sharepoint_id)
        {
            string error = string.Empty;
            DataTable dtTask_id;
            // Check to see if the sub task is under another task
            string sel_string = string.Format(@"                             SELECT        sub_task_id
                              FROM            sub_task
                              WHERE        sub_task_name = '{0}';", sub_task_name);

            // Check to see if they are adding a new sub task compared to one that is available
            if (string.IsNullOrEmpty(sub_task_id))
            {
                dtTask_id = Fill_DataTable(sel_string);
                if (dtTask_id.Rows.Count > 0)
                {
                    sub_task_id = dtTask_id.Rows[0]["sub_task_id"].ToString();
                }
            }

            // New task if task_id is empty
            if (string.IsNullOrEmpty(sub_task_id))
            {
                string ins_string = string.Format(@"INSERT INTO Sub_Task
                         (sub_task_name)
                        VALUES        ('{0}');", sub_task_name);

                var results1 = Execute_Scalar(ins_string);
                if (results1 == null)
                {
                    dtTask_id = Fill_DataTable(sel_string);
                    if (dtTask_id.Rows.Count == 1)
                    {
                        sub_task_id = dtTask_id.Rows[0]["sub_task_id"].ToString();
                    }
                }
                else
                {
                    return "error inserting new sub task: " + results1.ToString();
                }
            }

            error = Ins_Sub_Task_Link(link_id, sub_task_id, sharepoint_id);

            return error;
        }

        /// <summary>
        /// Inserts the linkage from task to subtask
        /// </summary>
        /// <param name="link_id">Id of type to task</param>
        /// <param name="sub_task_id">Id of sub task</param>
        /// <param name="sharepoint_id">Id from estimation list</param>
        /// <returns>Any errors</returns>
        static public string Ins_Sub_Task_Link(string link_id, string sub_task_id, int sharepoint_id)
        {
            string error = string.Empty;

            if (!string.IsNullOrEmpty(sub_task_id))
            {
                // Check to make sure that the task doesn't already belong to the type
                string sel_sub_task_link = string.Format(@"select sub_link_id
                                                    from sub_Task_Link
                                                    where link_id = '{0}' and sub_task_id = '{1}'", link_id, sub_task_id);
                if (Execute_Scalar(sel_sub_task_link) == null)
                {
                    // Add the task link
                    string ins_sub_task_link = sharepoint_id == -1 ?
                        string.Format(@"INSERT INTO sub_Task_Link
                            (link_id, sub_task_id)
                            VALUES('{0}','{1}')", link_id, sub_task_id) :
                        string.Format(@"INSERT INTO sub_Task_Link
                            (link_id, sub_task_id, sharepoint_id)
                            VALUES('{0}','{1}', '{2}')", link_id, sub_task_id, sharepoint_id);

                    var results = Execute_Scalar(ins_sub_task_link);

                    if (results != null)
                    {
                        error = results.ToString();
                    }
                }
            }

            return error;
        }

        /// <summary>
        /// Deletes the link of a sub task to a task.  It will remove the sub task if it doesn't
        /// have any links to other tasks.
        /// </summary>
        /// <param name="sub_task_id">Id of sub task</param>
        /// <param name="sub_link_id">Id of link from sub task to task</param>
        /// <param name="type_id">Id of type</param>
        /// <param name="task_id">Id of task</param>
        /// <returns>Any errors</returns>
        static public string Del_Sub_Task(string sub_task_id, string sub_link_id, string type_id, string task_id)
        {
            string error = string.Empty;

            // Delete the sub task link
            string del_sub_task = string.Format(@"Delete sub_task_link
                                                   where sub_link_id = '{0}'", sub_link_id);
            var results = Execute_Scalar(del_sub_task);
            if (results != null)
            {
                error = results.ToString();
                return error;
            }

            // Check to see if any other tasks are linked to that sub task
            string sel_sub_task = string.Format(@"Select sub_link_id
                                                   from sub_task_link
                                                   where sub_task_id = '{0}'", sub_task_id);
            DataTable dtSubTasks = Fill_DataTable(sel_sub_task);
            if (dtSubTasks.Rows.Count == 0)
            {
                del_sub_task = string.Format(@"Delete sub_task
                                                   where sub_task_id = '{0}'", sub_task_id);

                results = Execute_Scalar(del_sub_task);
                if (results != null)
                {
                    error = results.ToString();
                }
            }

            // Delete the time tracking records
            string del_time_track = string.Format(@"Delete time_track
                                                    where type_id = '{0}'
                                                    and task_id = '{1}'
                                                    and sub_task_id = '{2}'", type_id, task_id, sub_task_id);
            results = Execute_Scalar(del_time_track);
            if (results != null)
            {
                error = results.ToString();
            }

            return error;
        }

        /// <summary>
        /// Deletes task and links from type to task.  It will delete all of the sub task links and 
        /// any sub task that doesn't belong to any other tasks
        /// </summary>
        /// <param name="task_id">Id of task</param>
        /// <param name="link_id">Id of link from type to task</param>
        /// <param name="type_id">Id of type</param>
        /// <returns>Any errors</returns>
        static public string Del_Task(string task_id, string link_id, string type_id)
        {
            string error = string.Empty;

            // First delete the sub tasks if this is the only task that has that
            string del_sub_task = string.Format(@"DELETE           Sub_Task
                                                WHERE        (sub_task_id IN
                                                             (SELECT        sub_task_id
                                                               FROM            sub_task_link
                                                               WHERE        (sub_task_id IN
                                                                                             (SELECT        sub_task_id
                                                                                               FROM            sub_task_link AS sub_task_link_1
                                                                                               WHERE        (link_id = '{0}')))
                                                               GROUP BY sub_task_id
                                                               HAVING         (COUNT(*) = 1)))", link_id);
            var results = Execute_Scalar(del_sub_task);
            if (results != null)
            {
                error = results.ToString();
                return error;
            }

            // Now remove the sub task link
            del_sub_task = string.Format(@"DELETE           Sub_Task_Link
                                           WHERE link_id = '{0}'", link_id);
            results = Execute_Scalar(del_sub_task);
            if (results != null)
            {
                error = results.ToString();
                return error;
            }

            // Next delete the task if this is the only type that has that task
            string del_task = string.Format(@"  Delete task
                                                where (task_id in
                                                (SELECT        task_id
                                                FROM            Task_Link
                                                WHERE        (task_id = '{0}')
                                                GROUP BY task_id
                                                HAVING        (COUNT(*) = 1)))", task_id);

            results = Execute_Scalar(del_task);
            if (results != null)
            {
                error = results.ToString();
                return error;
            }

            // Now remove the task link
            del_task = string.Format(@"DELETE           Task_Link
                                           WHERE link_id = '{0}'", link_id);
            results = Execute_Scalar(del_task);
            if (results != null)
            {
                error = results.ToString();
                return error;
            }

            // Delete the time tracking records
            string del_time_track = string.Format(@"Delete time_track
                                                    where type_id = '{0}'
                                                    and task_id = '{1}'", type_id, task_id);
            results = Execute_Scalar(del_time_track);
            if (results != null)
            {
                error = results.ToString();
            }

            return error;
        }

        static public bool Ins_Time_Track_Manual(string type_id, string task_id, string sub_task_id, DateTime start_time, int hours, int minutes)
        {
            string ins_string = @"INSERT INTO Time_Track
                                    (type_id, task_id, sub_task_id, start_time, end_time,hours,minutes,seconds)
                                    VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','0')";

            object results = Execute_Scalar(string.Format(ins_string, type_id, task_id, sub_task_id, start_time, start_time, hours, minutes));

            return results == null;
        }

        /// <summary>
        /// Records a time tracking record
        /// </summary>
        /// <param name="type_id">Id of type</param>
        /// <param name="task_id">Id of task</param>
        /// <param name="sub_task_id">Id of sub task</param>
        /// <param name="start_time">Starting time</param>
        /// <param name="end_time">Ending time</param>
        /// <returns>If the records was succesfully saved</returns>
        static public bool Ins_Time_Track(string type_id, string task_id, string sub_task_id, DateTime start_time, DateTime end_time)
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;
            TimeSpan total_time = end_time - start_time;

            string ins_string = @"INSERT INTO Time_Track
                                    (type_id, task_id, sub_task_id, start_time, end_time,hours,minutes,seconds)
                                    VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";

            comm = new SqlCeCommand(string.Format(ins_string, type_id, task_id, sub_task_id, start_time, end_time, total_time.Hours, total_time.Minutes, total_time.Seconds), con);

            try
            {
                object results = comm.ExecuteScalar();
            }
            catch (System.InvalidOperationException exp)
            {
                return false;
            }

            return true;
        }       

        /// <summary>
        ///  Gets the time spent on a type, task, or subtask
        /// </summary>
        /// <param name="type_id"> Id of the type</param>
        /// <param name="task_id"> Id of the task</param>
        /// <param name="sub_task_id"> Id of the subtask</param>
        /// <param name="taskType">If it is a type, task, or subtask</param>
        /// <returns> Time spent</returns>
        static public TimeSpan Sel_Overall_Time(string type_id, string task_id, string sub_task_id, TaskType taskType)
        {
            TimeSpan overall_time;// = new TimeSpan();

            string sel_overall_time = string.Format(@"SELECT SUM(hours) as hours,SUM(minutes) as minutes,SUM(seconds) as seconds
                                                        FROM Time_Track
                                                        WHERE (type_id = '{0}')", type_id);
            if (taskType != TaskType.Type)
            {
                sel_overall_time = string.Format("{0} AND (task_id = '{1}')", sel_overall_time, task_id);

                if (taskType == TaskType.SubTask)
                {
                    sel_overall_time = string.Format("{0} AND (sub_task_id = '{1}')", sel_overall_time, sub_task_id);
                }
            }

            DataTable dt = Fill_DataTable(sel_overall_time);
            int hours = 0; //Int32.Parse(dt.Rows[0]["hours"].ToString());
            int minutes = 0;// = Int32.Parse(dt.Rows[0]["minutes"].ToString());
            int seconds = 0;// = Int32.Parse(dt.Rows[0]["seconds"].ToString());
            Int32.TryParse(dt.Rows[0]["hours"].ToString(), out hours);
            Int32.TryParse(dt.Rows[0]["minutes"].ToString(), out minutes);
            Int32.TryParse(dt.Rows[0]["seconds"].ToString(), out seconds);

            overall_time = new TimeSpan(hours, minutes, seconds);

            return overall_time;
        }

        /// <summary>
        /// Inserts estimated time for types
        /// </summary>
        /// <param name="typeId">Id of the type</param>
        /// <param name="newTime">Estimated time</param>
        static public void Ins_Type_Estimate(string typeId, TimeSpan newTime)
        {  
            string ins_type_estimate = string.Format(
                                        @"Update type
                                         Set estimated_time = '{0}'
                                         WHERE type_id = {1}",
                                         newTime, typeId);
            Execute_Scalar(ins_type_estimate);
        }

        /// <summary>
        ///  Updates estimated time for tasks and sub tasks
        /// </summary>
        /// <param name="parentId">Id of type of link</param>
        /// <param name="childId">Id of task or sub task</param>
        /// <param name="taskType">If a task or sub task is being updated</param>
        /// <param name="newTime">Estimated time</param>
        static public void Ins_Estimate(string parentId, string childId, TaskType taskType, TimeSpan newTime)
        {
            string ins_estimate = string.Format(
                                    @"Update {0}
                                      Set estimated_time = '{1}'
                                      WHERE {2} = {3}
                                      AND {4} = {5}",
                                                    taskType == TaskType.Task ? "task_link" : "sub_task_link",
                                                    newTime,
                                                    taskType == TaskType.Task ? "type_id" : "link_id",
                                                    parentId,
                                                    taskType == TaskType.Task ? "task_id" : "sub_task_id",
                                                    childId);
            Execute_Scalar(ins_estimate);
        }

        /// <summary>
        /// Selects estimated time for types
        /// </summary>
        /// <param name="typeId">Id of the type</param>
        /// <returns>Estimated time</returns>
        static public TimeSpan Sel_Type_Estimate(string typeId)
        {
            TimeSpan estimate = new TimeSpan();

            string sel_type_estimate = string.Format(@"Select estimated_time
                                                       from type
                                                        where type_id = {0}", typeId);

            TimeSpan.TryParse(Execute_Scalar(sel_type_estimate).ToString(), out estimate);
            return estimate;
        }

        /// <summary>
        /// Selects the estimated time for task or sub task
        /// </summary>
        /// <param name="parentId">Id of type of link</param>
        /// <param name="childId">Id of task or sub task</param>
        /// <param name="taskType">If a task or sub task is being selected</param>
        /// <returns>Estimated time</returns>
        static public TimeSpan Sel_Estimate(string parentId, string childId, TaskType taskType)
        {
            TimeSpan estimate = new TimeSpan();

            string sel_estimate = string.Format(
                        @"SELECT estimated_time
                         FROM {0}
                         WHERE {1} = {2}
                         AND {3} = {4}",
                                        taskType == TaskType.Task ? "task_link" : "sub_task_link",
                                        taskType == TaskType.Task ? "type_id" : "link_id",
                                        parentId,
                                        taskType == TaskType.Task ? "task_id" : "sub_task_id",
                                        childId);

            TimeSpan.TryParse(Execute_Scalar(sel_estimate).ToString(), out estimate);
            return estimate;
        }

        /// <summary>
        ///  Gets the task link id
        /// </summary>
        /// <param name="type_id"> Selected type</param>
        /// <param name="task_id"> Selected task</param>
        /// <returns>Link id of type to task</returns>
        static public string Sel_Task_Link_Id(string type_id, string task_id)
        {
            string link_id = "-1";

            string sel_task_link_id = string.Format(@"SELECT link_id
                                                    FROM Task_Link
                                                    WHERE type_id = {0}
                                                    AND task_id = {1}", type_id, task_id);
            object linkId = Execute_Scalar(sel_task_link_id);
            if (linkId != null)
            {
                link_id = linkId.ToString();
            }

            return link_id;
        }

        /// <summary>
        /// Selects the previously recorded entry
        /// </summary>
        /// <returns>Task info of the previously recorded entry</returns>
        static public TaskInfo Sel_Previous_Task()
        {
            TaskInfo previousTask = new TaskInfo();

            string sel_previous_task = @"SELECT        type_id, task_id, sub_task_id, start_time, end_time, time_track_id,  hours, minutes, seconds
                                        FROM            Time_Track
                                        WHERE        (time_track_id IN
                                                                     (SELECT        MAX(time_track_id) AS Expr1
                                                                       FROM            Time_Track AS Time_Track_1))";
            DataTable dt = Fill_DataTable(sel_previous_task);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                DateTime outTime;
                int outTimeInt;

                previousTask.Type_Id = dr["type_id"].ToString();
                previousTask.Task_Id = dr["task_id"].ToString();
                previousTask.Sub_Task_Id = dr["sub_task_id"].ToString();
                DateTime.TryParse(dr["start_time"].ToString(), out outTime);
                previousTask.StartTime = outTime;
                DateTime.TryParse(dr["end_time"].ToString(), out outTime);
                previousTask.EndTime = outTime;
                int.TryParse(dr["hours"].ToString(), out outTimeInt);
                previousTask.Hours = outTimeInt;
                int.TryParse(dr["minutes"].ToString(), out outTimeInt);
                previousTask.Minutes = outTimeInt;
                int.TryParse(dr["seconds"].ToString(), out outTimeInt);
                previousTask.Seconds = outTimeInt;

                // Now get the names
                if (previousTask.Sub_Task_Id != "-1")
                {
                    previousTask.DisplayName = string.Format("{0} --> {1} --> {2}", Sel_Type_Name(previousTask.Type_Id), Sel_Task_Name(previousTask.Task_Id), Sel_Sub_Task_Name(previousTask.Sub_Task_Id));
                    previousTask.TaskType = TaskType.SubTask;
                }
                else if (previousTask.Task_Id != "-1")
                {
                    previousTask.DisplayName = string.Format("{0} --> {1}", Sel_Type_Name(previousTask.Type_Id), Sel_Task_Name(previousTask.Task_Id));
                    previousTask.TaskType = TaskType.Task;
                }
                else
                {
                    previousTask.DisplayName = Sel_Type_Name(previousTask.Type_Id);
                    previousTask.TaskType = TaskType.Type;
                }
            }

            return previousTask;
        }

        /// <summary>
        /// Selects the sub task id from name
        /// </summary>
        /// <param name="sub_task_name">Sub task name</param>
        /// <returns>Sub task id</returns>
        static public string Sel_Sub_Task_Id(string sub_task_name)
        {
            string sel_sub_task_name = string.Format("select sub_task_id from sub_task where sub_task_name = '{0}'", sub_task_name);
            object subTaskId = Execute_Scalar(sel_sub_task_name);
            return subTaskId != null ? subTaskId.ToString() : string.Empty;
        }

        /// <summary>
        /// Selects the sub task name from id
        /// </summary>
        /// <param name="sub_task_id">Sub task id</param>
        /// <returns>Sub task name</returns>
        static public string Sel_Sub_Task_Name(string sub_task_id)
        {
            string sel_sub_task_name = string.Format("select sub_task_name from sub_task where sub_task_id = {0}", sub_task_id);

            return Execute_Scalar(sel_sub_task_name).ToString();
        }

        /// <summary>
        /// Selects the task id from name
        /// </summary>
        /// <param name="task_name">Name of task</param>
        /// <returns>Id of task</returns>
        static public string Sel_Task_Id(string task_name)
        {
            string sel_task_id = string.Format("select task_id from task where task_name = '{0}'", task_name);
            object taskId = Execute_Scalar(sel_task_id);
            return taskId != null ? taskId.ToString() : string.Empty;
        }

        /// <summary>
        /// Selects the task name from id
        /// </summary>
        /// <param name="task_id">Id of task</param>
        /// <returns>Name of task</returns>
        static public string Sel_Task_Name(string task_id)
        {
            string sel_task_name = string.Format("select task_name from task where task_id = {0}", task_id);

            return Execute_Scalar(sel_task_name).ToString();
        }

        /// <summary>
        /// Selects the type id from name
        /// </summary>
        /// <param name="type_name">Name of type</param>
        /// <returns>Id of the type</returns>
        static public string Sel_Type_ID(string type_name)
        {
            string sel_type_id = string.Format("select type_id from type where type_name = '{0}'", type_name);
            object typeID = Execute_Scalar(sel_type_id);
            return typeID != null ? typeID.ToString() : string.Empty;
        }

        /// <summary>
        /// Selects the type name from id
        /// </summary>
        /// <param name="type_id">Id of the type</param>
        /// <returns>Name of type</returns>
        static public string Sel_Type_Name(string type_id)
        {
            string sel_type_name = string.Format("select type_name from type where type_id = {0}", type_id);

            return Execute_Scalar(sel_type_name).ToString();
        }

        /// <summary>
        /// Selects the time tracking data used in the report
        /// </summary>
        /// <param name="startDate">Starting date of report</param>
        /// <param name="endDate">End data of report</param>
        /// <param name="selectedTask">Task that is selected to create the report on</param>
        /// <returns>Time tracking info for the report</returns>
        static public DataTable Sel_Time_Track(DateTime startDate, DateTime endDate, TaskInfo selectedTask = null)
        {
            string sel_time_track = string.Empty;

            if (selectedTask == null)
            {
                sel_time_track = string.Format(@"SELECT        t.type_name, ta.task_name, sb.sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id INNER JOIN
                                                                             Sub_Task AS sb ON tt.sub_task_id = sb.sub_task_id
                                                    WHERE        (tt.start_time > '{0}') AND (tt.end_time < '{1}')
                                                    UNION
                                                    SELECT        t.type_name, ta.task_name, '' AS sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds, tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id
                                                    WHERE        (tt.sub_task_id = - 1) AND (tt.start_time > '{0}') AND (tt.end_time < '{1}')
                                                    UNION
                                                    SELECT        t.type_name, '' AS task_name, '' AS sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id
                                                    WHERE        (tt.sub_task_id = - 1) AND (tt.task_id = - 1) AND (tt.start_time > '{0}') AND (tt.end_time < '{1}')
                                                    ORDER BY tt.start_time", startDate, endDate);
            }
            else
            {
                switch (selectedTask.TaskType)
                {
                    case TaskType.Type:
                        sel_time_track = string.Format(@"SELECT        t.type_name, ta.task_name, sb.sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id INNER JOIN
                                                                             Sub_Task AS sb ON tt.sub_task_id = sb.sub_task_id
                                                    WHERE        (tt.start_time > '{0}') AND (tt.end_time < '{1}') AND t.type_id = '{2}'
                                                    UNION
                                                    SELECT        t.type_name, ta.task_name, '' AS sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id
                                                    WHERE        (tt.sub_task_id = - 1) AND (tt.start_time > '{0}') AND (tt.end_time < '{1}') AND t.type_id = '{2}'
                                                    UNION
                                                    SELECT        t.type_name, '' AS task_name, '' AS sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id
                                                    WHERE        (tt.sub_task_id = - 1) AND (tt.task_id = - 1) AND (tt.start_time > '{0}') AND (tt.end_time < '{1}')  AND t.type_id = '{2}'
                                                    ORDER BY tt.start_time", startDate, endDate, selectedTask.Type_Id);
                        break;

                    case TaskType.Task:
                        sel_time_track = string.Format(@"SELECT        t.type_name, ta.task_name, sb.sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id INNER JOIN
                                                                             Sub_Task AS sb ON tt.sub_task_id = sb.sub_task_id
                                                    WHERE        (tt.start_time > '{0}') AND (tt.end_time < '{1}') AND t.type_id = '{2}' AND ta.task_id = '{3}'
                                                    UNION
                                                    SELECT        t.type_name, ta.task_name, '' AS sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id
                                                    WHERE        (tt.sub_task_id = - 1) AND (tt.start_time > '{0}') AND (tt.end_time < '{1}') AND t.type_id = '{2}' AND ta.task_id = '{3}'
                                                    ", startDate, endDate, selectedTask.Type_Id, selectedTask.Task_Id);
                        break;

                    case TaskType.SubTask:
                        sel_time_track = string.Format(@"SELECT        t.type_name, ta.task_name, sb.sub_task_name, tt.start_time, tt.end_time, tt.hours, tt.minutes, tt.seconds,tt.type_id, tt.task_id, tt.sub_task_id, tt.time_track_id
                                                    FROM            Time_Track AS tt INNER JOIN
                                                                             Type AS t ON tt.type_id = t.type_id INNER JOIN
                                                                             Task AS ta ON tt.task_id = ta.task_id INNER JOIN
                                                                             Sub_Task AS sb ON tt.sub_task_id = sb.sub_task_id
                                                    WHERE        (tt.start_time > '{0}') AND (tt.end_time < '{1}') AND t.type_id = '{2}' AND ta.task_id = '{3}' AND sb.sub_task_id = '{4}'",
                                                    startDate, endDate, selectedTask.Type_Id, selectedTask.Task_Id, selectedTask.Sub_Task_Id);
                        break;
                }
            }

            return Fill_DataTable(sel_time_track);
        }

        /// <summary>
        /// Selects all tasks that don't belong to the type
        /// </summary>
        /// <param name="type_id">Id of the type</param>
        /// <returns>Available tasks</returns>
        static public DataTable Sel_Available_Tasks(string type_id)
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            string query = string.Format(@"SELECT DISTINCT Task.task_id, Task.task_name
                                            FROM Task_Link INNER JOIN
                                            Task ON Task_Link.task_id = Task.task_id
                                            WHERE (Task.task_id NOT IN
                                                (SELECT task_id
                                                 FROM Task_Link AS Task_Link_1
                                                 WHERE (type_id = '{0}')))", type_id);

            comm = new SqlCeCommand(query, con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable taskList = new DataTable("Task");
            sqlda.Fill(taskList);

            con.Close();

            return taskList;
        }

        /// <summary>
        /// Selects all sub tasks that are associated to the task for other types, but not
        /// associated to the selected type/task
        /// </summary>
        /// <param name="type_id">Id of the selected type</param>
        /// <param name="task_id">Id of the selected task</param>
        /// <returns>All sub tasks that are available to pick from</returns>
        static public DataTable Sel_Available_Sub_Tasks(string type_id, string task_id)
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            string query = string.Format(@"SELECT DISTINCT Sub_Task.sub_task_id, Sub_Task.sub_task_name
                                        FROM            Sub_Task_Link INNER JOIN
                                                                 Task_Link ON Sub_Task_Link.link_id = Task_Link.link_id INNER JOIN
                                                                 Sub_Task ON Sub_Task_Link.sub_task_id = Sub_Task.sub_task_id
                                        WHERE        (Task_Link.task_id = '{1}') AND (Sub_Task.sub_task_id NOT IN
                                                                                 (SELECT        Sub_Task_1.sub_task_id
                                           FROM            Sub_Task_Link AS Sub_Task_Link_1 INNER JOIN
                                                                     Task_Link AS Task_Link_1 ON Sub_Task_Link_1.link_id = Task_Link_1.link_id INNER JOIN
                                                                     Sub_Task AS Sub_Task_1 ON Sub_Task_Link_1.sub_task_id = Sub_Task_1.sub_task_id
                                           WHERE        (Task_Link_1.type_id = '{0}') AND (Task_Link_1.task_id = '{1}')))", type_id, task_id);

            comm = new SqlCeCommand(query, con);
            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable subTaskList = new DataTable("Task");
            sqlda.Fill(subTaskList);

            con.Close();

            return subTaskList;
        }

        /// <summary>
        /// Updates a preference
        /// </summary>
        /// <param name="key">Key to be updated</param>
        /// <param name="value">Value of the key</param>
        /// <returns>Any errors</returns>
        static public string Upd_Preference(string key, string value)
        {
            string error = string.Empty;
            object results;

            // Check to see if a key exists for the preference
            if (string.IsNullOrEmpty(Sel_Preference(key)))
            {
                string ins_string = string.Format(@"Insert INTO Preferences
                                                        ([key], value)
                                                        VALUES('{0}','{1}')", key, value);
                results = Execute_Scalar(ins_string);
            }
            else
            {
                string upd_string = string.Format(@"Update Preferences
                                                    set value = '{0}'
                                                    where [key] = '{1}'", key, value);
                results = Execute_Scalar(upd_string);
            }

            if (results != null)
            {
                error = results.ToString();
            }

            return error;
        }

        /// <summary>
        /// Updates a time tracking record
        /// </summary>
        /// <param name="time_track_id">Time track id</param>
        /// <param name="updateType">Hours, minutes, seconds</param>
        /// <param name="updateValue">New value</param>
        /// <returns>If the records was succesfully updated</returns>
        static public bool Upd_Time_Track(string time_track_id, string updateValue, string updateType)
        {
            object results;

            string ins_string = @"UPDATE Time_Track
                                  SET {0} = '{1}'
                                  WHERE time_track_id = '{2}'";

            results = Execute_Scalar(string.Format(ins_string, updateType, updateValue, time_track_id));

            return results == null;
        }

        /// <summary>
        /// Removes a time tracking record
        /// </summary>
        /// <param name="time_track_id">Time track id</param>
        /// <returns>If the record was succesfully removed</returns>
        static public bool Del_Time_Track(string time_track_id)
        {
            object results;

            string del_string = @"DELETE Time_Track
                                  WHERE time_track_id = '{0}'";

            results = Execute_Scalar(string.Format(del_string, time_track_id));

            return results == null;                
        }

        /// <summary>
        /// Selects the values of the preference from the key
        /// </summary>
        /// <param name="key">Preference key</param>
        /// <returns>Preference value</returns>
        static public string Sel_Preference(string key)
        {
            string value = string.Empty;

            string sel_string = string.Format("Select value From Preferences where [key] = '{0}'", key);

            var results = Execute_Scalar(sel_string);

            if (results != null)
            {
                value = results.ToString();
            }

            return value;
        }

        /// <summary>
        /// Checks if the database exists.  If it doesn't it is created
        /// </summary>
        /// <returns>If the database now exists</returns>
        static public bool DatabaseExists()
        {
            bool exits = false;

            string databasePath = string.Format(@"{0}\TimeTracking.sdf", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            if (!System.IO.File.Exists(databasePath))
            {
                try
                {
                    Console.WriteLine("Just entered to create Sync DB");

                    SqlCeConnection con = new SqlCeConnection(ConString);
                    SqlCeEngine en = new SqlCeEngine(ConString);
                    en.CreateDatabase();

                    string script;

                    con.Open();
                    SqlCeCommand comm;

                    // Create sub task
                    script = @"CREATE TABLE [Sub_Task] (
                                  [sub_task_name] nvarchar(100) NULL
                                , [sub_task_id] int IDENTITY (0,1) NOT NULL
                                );";
                    comm = new SqlCeCommand(script, con);
                    object results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Sub_Task] ADD CONSTRAINT [PK__Sub_Task__000000000000008D] PRIMARY KEY ([sub_task_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Sub_Task__0000000000000088] ON [Sub_Task] ([sub_task_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    // Create task
                    script = @"CREATE TABLE [Task] (
                          [task_id] int IDENTITY (0,1) NOT NULL
                        , [task_name] nvarchar(100) NOT NULL
                        );";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Task] ADD CONSTRAINT [PK_Task] PRIMARY KEY ([task_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Task__00000000000001A5] ON [Task] ([task_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    // Create type
                    script = @"CREATE TABLE [Type] (
                          [type_id] int IDENTITY (0,1) NOT NULL
                        , [type_name] nvarchar(100) NOT NULL
                        , [estimated_time] nvarchar(11) NULL
                        );";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Type] ADD CONSTRAINT [PK_Type] PRIMARY KEY ([type_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Type__0000000000000186] ON [Type] ([type_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    // Create sub_task_link
                    script = @"CREATE TABLE [Sub_Task_Link] (
                          [link_id] int NOT NULL
                        , [estimated_time] nvarchar(11) NULL
                        , [sub_link_id] int IDENTITY (0,1) NOT NULL
                        , [sub_task_id] int NOT NULL
                        );";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Sub_Task_Link] ADD CONSTRAINT [PK__Sub_Task_Link__000000000000007C] PRIMARY KEY ([sub_link_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Sub_Task_Link__0000000000000072] ON [Sub_Task_Link] ([sub_link_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    // Create task_link
                    script = @"CREATE TABLE [Task_Link] (
                          [link_id] int IDENTITY (0,1) NOT NULL
                        , [type_id] int NOT NULL
                        , [task_id] int NOT NULL
                        , [estimated_time] nvarchar(11) NULL
                        );";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Task_Link] ADD CONSTRAINT [PK_Task_Link] PRIMARY KEY ([link_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Task_Link__00000000000001DD] ON [Task_Link] ([link_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    // Create time_track
                    script = @"CREATE TABLE [Time_Track] (
                          [type_id] int NOT NULL
                        , [task_id] int NULL
                        , [sub_task_id] int NULL
                        , [start_time] datetime NULL
                        , [end_time] datetime NULL
                        , [time_track_id] bigint IDENTITY (0,1) NOT NULL
                        , [hours] int NULL
                        , [minutes] int NULL
                        , [seconds] int NULL
                        );";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "ALTER TABLE [Time_Track] ADD CONSTRAINT [PK__Time_Track__00000000000000A2] PRIMARY KEY ([time_track_id]);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    script = "CREATE UNIQUE INDEX [UQ__Time_Track__000000000000009D] ON [Time_Track] ([time_track_id] ASC);";
                    comm = new SqlCeCommand(script, con);
                    results = comm.ExecuteScalar();

                    con.Close();

                    exits = true;

                    exits = Check1_2_Update();

                    // add the preference table
                    exits = Check1_3_Update();
                }
                catch (Exception exp)
                {                     
                    exits = false;
                }
            }
            else
            {
                // check if they have the id columns added in 1.2
                exits = Check1_2_Update();

                // check if the preference table exists from 1.3
                exits = Check1_3_Update();
            }

            return exits;
        }

        /// <summary>
        /// Add the sharepoint id columns if they don't already exist
        /// </summary>
        /// <returns>If the columns exist and there was no errors</returns>
        private static bool Check1_2_Update()
        {
            bool exists = true;
            try
            {
                // check if they have the id columns added in 1.2
                string script = "Select * from {0}";
                string alterScript = @"Alter Table {0}
                              Add Column sharePoint_id Integer";

                DataTable results = Fill_DataTable(string.Format(script, "Type"), 1);
                if (!results.Columns.Contains("sharePoint_id"))
                {
                    Execute_Scalar(string.Format(alterScript, "Type"));
                }

                results = Fill_DataTable(string.Format(script, "Task_Link"), 1);
                if (!results.Columns.Contains("sharePoint_id"))
                {
                    Execute_Scalar(string.Format(alterScript, "Task_Link"));
                }

                results = Fill_DataTable(string.Format(script, "Sub_Task_Link"), 1);
                if (!results.Columns.Contains("sharePoint_id"))
                {
                    Execute_Scalar(string.Format(alterScript, "Sub_Task_Link"));
                }
            }
            catch
            {
                exists = false;
            }

            return exists;
        }

        /// <summary>
        /// Add the preference table if it doesn't already exist
        /// </summary>
        /// <returns>If the 1_3 update exists in the database</returns>
        private static bool Check1_3_Update()
        {
            bool exists = true;

            try
            {
                string script = @"SELECT        COUNT(*)
                FROM            information_schema.tables
                WHERE        table_name = 'Preferences'";

                int count = int.Parse(Execute_Scalar(script).ToString());

                if (count == 0)
                {
                    script = @"CREATE TABLE [Preferences] (
                              [key] nvarchar(100) NOT NULL
                            , [value] nvarchar(100) NULL
                            );";
                    if (Execute_Scalar(script) != null)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                exists = false;
            }

            return exists;
        }

        /// <summary>
        /// Executes a scalar query
        /// </summary>
        /// <param name="query">Query sql</param>
        /// <returns>Results of scalar query</returns>
        private static object Execute_Scalar(string query)
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand(query, con);

            object results = comm.ExecuteScalar();

            con.Close();

            return results;
        }

        /// <summary>
        /// Executes a query to fill a datatable
        /// </summary>
        /// <param name="query">Query sql</param>
        /// <returns>Datatable of results</returns>
        private static DataTable Fill_DataTable(string query)
        {
            return Fill_DataTable(query, -1);
        }

        /// <summary>
        /// Executes a query to fill a datatable and return a particular
        /// amount of rows.  If the rows is not greater than 0, then
        /// all of the rows are returned
        /// </summary>
        /// <param name="query">Query sql</param>
        /// <param name="rows">How many rows to return</param>
        /// <returns>Datatable of results</returns>
        private static DataTable Fill_DataTable(string query, int rows)
        {
            SqlCeConnection con = new SqlCeConnection(ConString);
            con.Open();
            SqlCeCommand comm;

            comm = new SqlCeCommand(query, con);

            SqlCeDataAdapter sqlda = new SqlCeDataAdapter(comm);

            DataTable dt = new DataTable();
            if (rows > 0)
            {
                sqlda.Fill(0, rows, dt);
            }
            else
            {
                sqlda.Fill(dt);
            }

            con.Close();

            return dt;
        }
    }
}