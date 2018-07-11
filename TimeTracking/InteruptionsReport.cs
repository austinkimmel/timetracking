using System.Windows.Forms;

namespace TimeTracking
{
    public partial class InteruptionsReport : Form
    {
        //public Form1 MainForm { get; set; }
        //public InteruptionsReport()
        //{
        //    InitializeComponent();
        //}

        //private void InteruptionsReport_Load(object sender, EventArgs e)
        //{
        //    this.reportViewer1.RefreshReport();
        //}

        //private void btnFetch_Click(object sender, EventArgs e)
        //{
        //    DataTable mainDt = new DataTable();
        //    mainDt.Columns.Add("Date", typeof(DateTime));
        //    mainDt.Columns.Add("Reason");
        //    InteruptionsData id = new InteruptionsData();
        //    using (StreamReader sr = File.OpenText(Constants.interuptionsFilePath))
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

        //    SelectionRange selectedRange = calInteruptions.SelectionRange;
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
        //            id.Data.Add(new Interuption(Utility.ParsedDate(selection[i][0].ToString()), selection[i][1].ToString(), Utility.ParsedTime(selection[i][0].ToString())));
        //        }
        //        InteruptionsDataBindingSource.DataSource = id.Data;
        //        reportViewer1.Refresh();
        //        reportViewer1.RefreshReport();
        //    }
        //}

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    this.MainForm.Show();
        //}
    }
}