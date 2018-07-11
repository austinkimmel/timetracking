using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DowCorning.Applications.TimeTracking;

namespace TimeTracking3
{
    public partial class TypeTree : UserControl
    {
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
            }
        }
        
        public TypeTree()
        {
            InitializeComponent();
            this.SetTreeview();
        }

        /// <summary>
        ///  Creates the tree view
        /// </summary>
        private void SetTreeview()
        {
            // Loop through the types
            for (int i = 0; i < Info.Types.Rows.Count; i++)
            {
                TTTreeView.Nodes.Add(Info.Types.Rows[i]["type_id"].ToString(), Info.Types.Rows[i]["type_name"].ToString());

                // Loop through each task for the type
                DataRow[] task = Info.Tasks.Select("type_id = " + Info.Types.Rows[i]["type_id"]);
                foreach (DataRow dr in task)
                {
                    TTTreeView.Nodes[i].Nodes.Add(dr["task_id"].ToString(), dr["task_name"].ToString());

                    // Loop through each subtask for the task
                    DataRow[] subTask = Info.SubTask.Select("link_id = " + dr["link_id"].ToString());
                    int leaf = TTTreeView.Nodes[i].Nodes.Count;
                    foreach (DataRow subTaskRow in subTask)
                    {
                        TTTreeView.Nodes[i].Nodes[leaf - 1].Nodes.Add(subTaskRow["sub_task_id"].ToString(), subTaskRow["sub_task_name"].ToString());
                    }
                }
            }
        }
    }
}
