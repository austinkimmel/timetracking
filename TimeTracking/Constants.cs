using System;

namespace TimeTracking
{
    public static class Constants
    {
        public static readonly string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static readonly string stateFilePath = string.Format(@"{0}\TimeTracking\State.txt", myDocuments);
        public static readonly string appDirectory = string.Format(@"{0}\TimeTracking", myDocuments);
        public static readonly string timeTrackFilePath = string.Format(@"{0}\TimeTracking\TimeTrack.txt", myDocuments);
        public static readonly string timeTrackInProgressFilePath = string.Format(@"{0}\TimeTracking\TimeTrackInProgress.txt", myDocuments);
        public static readonly string timeTrackBackupFilePath = string.Format(@"{0}\TimeTracking\TimeBackupTrack.txt", myDocuments);
        public static readonly string pomodoroFilePath = string.Format(@"{0}\TimeTracking\Pomodoro.txt", myDocuments);
        public static readonly string pomodoroBackupFilePath = string.Format(@"{0}\TimeTracking\PomodoroBackup.txt", myDocuments);
        public static readonly string interuptionsFilePath = string.Format(@"{0}\TimeTracking\Interuptions.txt", myDocuments);
        public static readonly string interuptionsBackupFilePath = string.Format(@"{0}\TimeTracking\InteruptionsBackup.txt", myDocuments);
        public static readonly string interuptionReasonsFilePath = string.Format(@"{0}\TimeTracking\InteruptionReasons.txt", myDocuments);
        public static readonly string interuptionReasonsBackupFilePath = string.Format(@"{0}\TimeTracking\InteruptionReasonsBackup.txt", myDocuments);
        public static readonly string tasksFilePath = string.Format(@"{0}\TimeTracking\Tasks.txt", myDocuments);
        public static readonly string tasksInProgressFilePath = string.Format(@"{0}\TimeTracking\TasksInProgress.txt", myDocuments);
        public static readonly string tasksBackup = string.Format(@"{0}\TimeTracking\TasksBackup.txt", myDocuments);
        public static readonly string tasks2FilePath = string.Format(@"{0}\TimeTracking\Tasks2.txt", myDocuments);
        public static readonly string tasks2InProgressFilePath = string.Format(@"{0}\TimeTracking\TasksInProgress2.txt", myDocuments);
        public static readonly string tasks2Backup = string.Format(@"{0}\TimeTracking\TasksBackup2.txt", myDocuments);
        public static readonly string typesFilePath = string.Format(@"{0}\TimeTracking\Types.txt", myDocuments);
        public static readonly string typesInProgressFilePath = string.Format(@"{0}\TimeTracking\TypesInProgress.txt", myDocuments);
        public static readonly string typesBackupFilePath = string.Format(@"{0}\TimeTracking\TypesBackup.txt", myDocuments);
        public static readonly string exceptionsFilePath = string.Format(@"{0}\TimeTracking\Exceptions.txt", myDocuments);
        public static readonly string nonWorkingTasksFilePath = string.Format(@"{0}\TimeTracking\NonWorkingTasks.txt", myDocuments);
        public static readonly string presetsFilePath = string.Format(@"{0}\TimeTracking\presets.txt", myDocuments);
        public static readonly string developer = "david.bobrowski@dowcorning.com";
        public static readonly string TasksFormat = "{0}|{1}|{2}|{3}|{4}|{5}";
        public static readonly string TasksFormat2 = "{0}|{1}|{2}|{3}|{4}|{5}|{6}";
        public static readonly string PresetsFormat = "{0}|{1}|{2}|{3}";
    }
}