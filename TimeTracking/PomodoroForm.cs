using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class PomodoroForm : Form
    {
        public Form1 MainForm { get; set; }

        public PomodoroForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, "Email"));
            MainForm.ResetPomodoro();
            this.Close();
            MainForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.StartTimers();
            this.Close();
            MainForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAddReason_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbCustomReasons.Items.Contains(txtReason.Text))
                {
                    Utility.WriteToFile(Constants.interuptionReasonsFilePath, txtReason.Text);
                    RefreshCustomReasonsList();
                    MessageBox.Show("Successfully added reason");
                }
                else
                {
                    MessageBox.Show(string.Format("You already have '{0}' in the list of available reasons", txtReason.Text));
                }
            }
            catch
            {
                MessageBox.Show("Failed to write reason");
            }
        }

        private void PomodoroForm_Load(object sender, EventArgs e)
        {
            //Utility.CheckFileExistsCreateIfNot(Constants.interuptionsFilePath);
            // Utility.CheckFileExistsCreateIfNot(Constants.interuptionReasonsFilePath);

            RefreshCustomReasonsList();
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            if (cbCustomReasons.SelectedIndex == -1)
            {
                MessageBox.Show("First select a reason from the list");
            }
            else
            {
                Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, cbCustomReasons.SelectedItem));
                MainForm.ResetPomodoro();
                cbCustomReasons.Refresh();
                this.Close();
                MainForm.Show();
            }
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, "Meeting"));
            MainForm.ResetPomodoro();
            this.Close();
            MainForm.Show();
        }

        private void btnBoss_Click(object sender, EventArgs e)
        {
            Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, "Manager"));
            MainForm.ResetPomodoro();
            this.Close();
            MainForm.Show();
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, "Phone"));
            MainForm.ResetPomodoro();
            this.Close();
            MainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utility.WriteToFile(Constants.interuptionsFilePath, string.Format("{0}|{1}", DateTime.Now, "Team member"));
            MainForm.ResetPomodoro();
            this.Close();
            MainForm.Show();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("You will not receive a Pomodoro point until the full {0} minute(s) has expired" + System.Environment.NewLine +
                "Pomodoro practice indicates you should review your work with the remaining time" + System.Environment.NewLine + System.Environment.NewLine +
                "Click OK to accept point loss", ConfigurationManager.AppSettings["PomodoroTime"]), "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                MainForm.ResetPomodoro();
                this.Close();
                MainForm.Show();
            }
        }

        private void RefreshCustomReasonsList()
        {
            cbCustomReasons.Items.Clear();
            bool existing;
            Utility.CheckFileExistsCreateIfNot(Constants.interuptionReasonsFilePath, out existing);
            try
            {
                if (existing)
                {
                    StreamReader sr = File.OpenText(Constants.interuptionReasonsFilePath);
                    string input = string.Empty;
                    while ((input = sr.ReadLine()) != null)
                    {
                        cbCustomReasons.Items.Add(input);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to refresh");
            }
        }

        private void btnClearCustomReasons_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to clear log, cancel to back out", "Are you sure?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(Constants.interuptionReasonsFilePath);
                fi.Delete();
            }
            cbCustomReasons.SelectedValue = "Select one...";
            cbCustomReasons.Items.Clear();
        }

        private void btnCustomReasonsEdt_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Constants.interuptionReasonsFilePath);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCustomReasonsList();
        }
    }
}