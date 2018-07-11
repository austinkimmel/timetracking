using System.Data;

namespace DowCorning.Applications.TimeTracking
{
    public class TimeTrackInfo
    {
        private DataTable types;

        private DataTable tasks;

        private DataTable subTasks;

        private TaskInfo currentTask;

        private TaskInfo selectedTask;

        private TaskInfo previousTask;

        public DataTable Types
        {
            get
            {
                if (types == null)
                {
                    types = Data.TypeList();
                }
                return types;
            }
        }

        public DataTable Tasks
        {
            get
            {
                if (tasks == null)
                {
                    tasks = Data.TaskList();
                }
                return tasks;
            }
        }

        public DataTable SubTask
        {
            get
            {
                if (subTasks == null)
                {
                    subTasks = Data.SubTaskList();
                }
                return subTasks;
            }
        }

        public TaskInfo CurrentTask
        {
            get
            {
                return currentTask;
            }
            set
            {
                currentTask = value;
            }
        }

        public TaskInfo SelectedTask
        {
            get
            {
                if (selectedTask == null)
                {
                    selectedTask = new TaskInfo();
                }
                return selectedTask;
            }
            set
            {
                selectedTask = value;
            }
        }

        public TaskInfo PreviousTask
        {
            get
            {
                if (previousTask == null)
                {
                    previousTask = Data.Sel_Previous_Task();
                }
                return previousTask;
            }
            set
            {
                previousTask = value;
            }
        }

        public void ResetData()
        {
            this.types = null;
            this.tasks = null;
            this.subTasks = null;
        }

        public int Seconds { get; set; }

        public int Minutes { get; set; }

        public int Hours { get; set; }

        public bool RecordTime()
        {
            bool success = false;

            return success;
        }
    }

    public enum TaskType
    {
        Type,
        Task,
        SubTask
    }
}