using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class NonWorkingHoursTasks : Form
    {
        public Form1 MainForm
        {
            get;
            set;
        }

        public NonWorkingHoursTasks()
        {
            InitializeComponent();
        }

        private void NonWorkingHoursTasks_Load(object sender, EventArgs e)
        {
            DataTable dt = DAL.TaskData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chkListNonWorkingTasks.Items.Add(string.Format("{0} - {1}", dt.Rows[i][1], dt.Rows[i][2]));
            }
            foreach (string item in MainForm.NonWorkingHoursTasks)
            {
                int itemNum = chkListNonWorkingTasks.FindString(item);
                if (itemNum != -1)
                {
                    chkListNonWorkingTasks.SetItemChecked(itemNum, true);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm.LoadTimeSummary();
            MainForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nonWorkingItems = new List<string>();
                foreach (string item in chkListNonWorkingTasks.CheckedItems)
                {
                    nonWorkingItems.Add(item);
                }
                MainForm.NonWorkingHoursTasks = nonWorkingItems;
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure in updating non working tasks");
                throw ex;
            }
        }
    }
}