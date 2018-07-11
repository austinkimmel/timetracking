using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracking2
{
    public partial class TimeTracking : Form
    {
        public TimeTracking()
        {
            InitializeComponent();

            string sqlCon = @"Data Source=C:\tfs\DeveloperUtilities\VsNet\ASKIMMEL\TimeTracking\TimeTracking2\TimeTrack.sdf;Password=";

            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            con.Database[0].ToString();

        }
    }
}
