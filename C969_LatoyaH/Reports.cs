using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            ShowReports();
        }
        public void ShowReports()
        {
            var usTbl = DataContext.GetaUser();
            var usLt = (from DataRow row in usTbl.Rows select row["UserName"]).ToList();
            comBxUser.DataSource = usLt;
        }

        private void rdBtnType_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            var rpt = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                List<string> typLt = DataContext.GetMonthlyAppt(User.UserId, i);
                rpt.AppendLine(Environment.NewLine + DateTimeFormatInfo.CurrentInfo.GetMonthName(i));

                foreach (var tp in typLt)
                {
                    rpt.AppendLine(tp + Environment.NewLine);
                }
            }
            richTextBox1.Text = rpt.ToString();
        }

        private void rdBtnUser_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            var rpt = new StringBuilder();
            string user = comBxUser.Text;
            int userId = int.Parse(DataContext.GetaUserId(user));
            List<Appointment> appoint = DataContext.GetUserAppt(userId);

            foreach ( var appoints in appoint)
            {
                
                rpt.AppendLine(appoints.Title + Environment.NewLine + "  "+ appoints.Start + Environment.NewLine + "  " +appoints.End + Environment.NewLine);
            }
            richTextBox1.Text = rpt.ToString();
        }

        private void rdBtnCustomer_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            var rpt = new StringBuilder();
            
            List<string> appointCtLt = DataContext.GetApptCtCustomer();

            foreach (var customer in appointCtLt)
            {

                rpt.AppendLine(customer + Environment.NewLine);
            }
            richTextBox1.Text = rpt.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int currentUser = User.UserId;
            this.Hide();
            Appointments schedule = new Appointments();
            schedule.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentUser = User.UserId;
            this.Hide();
            CustomerRecords custRecord = new CustomerRecords(currentUser);
            custRecord.ShowDialog();
            this.Close();
        }
    }
}
