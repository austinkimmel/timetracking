using System.Windows.Forms;

namespace TimeTracking
{
    public partial class ReportForm : Form
    {
        //public DataTable dt;
        //public DataSet ds = new DataSet("Report");

        //internal Form1 MainForm { get; set; }
        //public ReportForm()
        //{
        //    InitializeComponent();
        //}

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    MainForm.Show();
        //    this.Close();
        //}

        //private void btnFetch_Click(object sender, EventArgs e)
        //{
        //    string expression = string.Empty;
        //    string sort = string.Empty;
        //    bool validateTasks = false;
        //    bool validateTypes = false;
        //    bool canAddByType = false;
        //    bool canAddByTask = false;
        //    dt = Utility.FetchTimeData();

        //    //SelectionRange sr = calReporting.SelectionRange;
        //    DateTime endDate = pickerTo.Value.AddHours(23).AddMinutes(59).AddSeconds(59);//sr.End;
        //    expression = "Start > '{0}' AND End < '{1}'";
        //    sort = "Start ASC";
        //    if (cbTasks.SelectedIndex != -1)
        //    {
        //        expression += string.Format("AND Task = '{0}'", cbTasks.Text);
        //        validateTasks = true;
        //    }
        //    if (cbTypes.SelectedIndex != -1)
        //    {
        //        expression += string.Format("AND Type = '{0}'", cbTypes.Text);
        //        validateTypes = true;
        //    }

        //    DataRow[] selection = dt.Select(string.Format(expression, pickerFrom.Value, endDate), sort);
        //    if (selection.Length == 0)
        //    {
        //        MessageBox.Show("Sorry no data found for your provided range set");
        //    }
        //    else
        //    {
        //        ReportsData rpd = new ReportsData();
        //        for (int i = 0; i < selection.Length; i++)
        //        {
        //            DataRow temp = selection[i];
        //            string start = Utility.ParsedDate(temp[0].ToString());
        //            if (rpd.Data.Where(x => x.Day == start).Count() == 0)
        //            {
        //                expression = "StartString LIKE '%{0}%'";
        //                sort = "Start ASC";
        //                DataRow[] particularDateSelection = dt.Select(string.Format(expression, start), sort);
        //                List<Report> reports = new List<Report>();
        //                for (int j = 0; j < particularDateSelection.Length; j++)
        //                {
        //                    DataRow temp2 = particularDateSelection[j];
        //                    if (validateTypes && (temp2[5].ToString() == cbTypes.Text))
        //                    {
        //                        canAddByType = true;
        //                    }

        //                    if (validateTasks && (temp2[3].ToString() == cbTasks.Text))
        //                    {
        //                        canAddByTask = true;
        //                    }

        //                    bool shouldAdd = false;
        //                    if (!validateTasks && !validateTypes)
        //                    {
        //                        shouldAdd = true;
        //                    }
        //                    else if(validateTypes && canAddByType)
        //                    {
        //                        if (validateTasks && canAddByTask)
        //                        {
        //                            shouldAdd = true;
        //                        }
        //                        else if (validateTasks && !canAddByTask)
        //                        {
        //                            shouldAdd = false;
        //                        }
        //                        else
        //                        {
        //                            shouldAdd = true;
        //                        }
        //                    }
        //                    else if (validateTasks && canAddByTask)
        //                    {
        //                        shouldAdd = true;
        //                    }
        //                    else
        //                    {
        //                        shouldAdd = false;
        //                    }

        //                    if (shouldAdd)
        //                    {
        //                        reports.Add(new Report(start, ParsedTime(temp2[0].ToString()), ParsedTime(temp2[1].ToString()), UpconvertTime(temp2[2].ToString()),
        //                            temp2[3].ToString(), UpconvertTime(temp2[2].ToString()), temp2[5].ToString(), !string.IsNullOrEmpty(temp2[6].ToString()) ? temp2[6].ToString() : "N/A"));
        //                    }
        //                    canAddByTask = canAddByType = false;
        //                }
        //                foreach (Report item in reports)
        //                {
        //                    rpd.Data.Add(item);
        //                }
        //                //rpd.reportsData.Add(new Report(temp[0].ToString(), temp[1].ToString(), temp[2].ToString(), temp[3].ToString()));
        //            }
        //        }
        //        ReportBindingSource.DataSource = rpd.Data;
        //        PrintReportData();
        //    }
        //    ResetDdls();
        //}

        //private void ResetDdls()
        //{
        //    cbTasks.SelectedIndex = cbTypes.SelectedIndex = -1;
        //    cbTasks.ResetText(); cbTypes.ResetText();
        //    cbTypes.SelectedText = cbTasks.SelectedText = "Please select one";
        //}

        //private void PrintReportData()
        //{
        //    reportViewer1.Refresh();
        //    reportViewer1.RefreshReport();

        //}

        //private void ReportForm_Load(object sender, EventArgs e)
        //{
        //    this.reportViewer1.RefreshReport();

        //    foreach (DataRow dr in MainForm.TypesDt.Rows)
        //    {
        //        cbTypes.Items.Add(dr[0]);
        //    }

        //    //TODO: set to today but 12 (mod by 24)
        //    pickerFrom.Value = pickerTo.Value = DateTime.Today;
        //}

        //private int UpconvertTime(string time)
        //{
        //    string seconds = time.Substring(time.LastIndexOf(":") + 1);
        //    string minutes = time.Substring(time.IndexOf(":") + 1, 2);
        //    string hours = time.Substring(time.IndexOf(":") - 2, 2);
        //    return (int.Parse(hours) * 60) + (int.Parse(minutes)) + (int.Parse(seconds) > 30 ? 1 : 0);
        //}

        //private string ParsedTime(string dateString)
        //{
        //    string temp = dateString.Substring(dateString.IndexOf(':') - 2);
        //    temp = temp.Remove(temp.LastIndexOf(':'), 3);
        //    return temp;
        //}

        //private void reportViewer1_Load(object sender, EventArgs e)
        //{
        //}

        //private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cbTasks.Items.Clear();
        //    if (cbTypes.SelectedItem != null)
        //    {
        //        MainForm.MainDt = DAL.TaskData(cbTypes.SelectedItem.ToString());
        //        foreach (DataRow dr in MainForm.MainDt.Rows)
        //        {
        //            cbTasks.Items.Add(string.Format("{0} - {1}", dr[1], dr[2]));
        //        }
        //    }
        //}
    }
}