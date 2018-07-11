using System.Windows.Forms;

namespace TimeTracking
{
    public partial class PomodoroReport : Form
    {
        //public Form1 MainForm { get; set; }
        //public PomodoroReport()
        //{
        //    InitializeComponent();
        //}

        //private void PomodoroReport_Load(object sender, EventArgs e)
        //{
        //    this.reportViewer1.RefreshReport();
        //}

        //private void btnFetch_Click(object sender, EventArgs e)
        //{
        //    DataTable mainDt = new DataTable();
        //    mainDt.Columns.Add("Date", typeof(DateTime));
        //    mainDt.Columns.Add("Pomorodo");
        //    PomodoroData pd = new PomodoroData();
        //    using (StreamReader sr = File.OpenText(Constants.pomodoroFilePath))
        //    {
        //        string input = string.Empty;
        //        while ((input = sr.ReadLine()) != null)
        //        {
        //            string[] arr = input.Split('|');
        //            DataRow dr = mainDt.NewRow();
        //            dr[0] = arr[0];
        //            dr[1] = arr[1];
        //            mainDt.Rows.Add(dr);
        //        }
        //    }

        //    SelectionRange selectedRange = calPomodoro.SelectionRange;
        //    DateTime endDate = selectedRange.End;
        //    endDate = selectedRange.End.AddDays(1);
        //    DataRow[] selection = mainDt.Select(string.Format("Date >= '{0}' AND Date <= '{1}'", selectedRange.Start, endDate));
        //    if (selection.Length == 0)
        //    {
        //        MessageBox.Show("Sorry no data found for your provided range set");
        //    }
        //    else
        //    {
        //        for (int i = 0; i < selection.Length; i++)
        //        {
        //            pd.Data.Add(new Pomodoro(Utility.ParsedDate(selection[i][0].ToString()), int.Parse(selection[i][1].ToString())));
        //        }
        //        PomodoroBindingSource.DataSource = pd.Data;
        //        reportViewer1.Refresh();
        //        reportViewer1.RefreshReport();
        //    }
        //}

        //private void calPomodoro_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //}

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    this.MainForm.Show();
        //}
    }
}