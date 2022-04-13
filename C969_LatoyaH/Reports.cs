using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class Reports : Form
    {
        private Form MainControl;
        private List<User> userLt;
        public Reports(Form form)
        {
            InitializeComponent();
            MainControl = form;

        }
       

        private void rdBtnType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnType.Checked)
            {
                //richTextBox1.Text = string.Empty;
                var rpt = new StringBuilder();
                rpt.AppendLine("Number of Appointment types by month: (Previous, Current, Next)");
                rpt.AppendLine();
                DateTime curMoth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime prevMoth = curMoth.AddMonths(-1);
                DateTime nextMoth = curMoth.AddMonths(2).AddMilliseconds(-1);
                var mthLsts = MainForm.ApptLt.OrderBy(app => app.Start).Where(app => app.Start >= prevMoth && app.Start <= nextMoth).GroupBy(app => app.Start.ToString("MMMM yyyy"));
                foreach (var mthLstts in mthLsts)
                {
                    rpt.AppendLine($"{mthLstts.Key}:");
                    var typeList = mthLstts.GroupBy(app => app.Type);
                    foreach (var l in typeList)
                    {
                        rpt.AppendLine($"\t{l.Key}: {l.Count()}");
                    }
                    rpt.AppendLine();
                }
                richTextBox1.Text = rpt.ToString();
              
            }
        }

        private void rdBtnUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnUser.Checked)
            {
                var rpt = new StringBuilder();
                rpt.AppendLine("Customer with an Appointment this week");
                rpt.AppendLine("--------------------");
                var stWk = SearchBegWk(DateTime.Now);
                var edWk = SearchEndWk(DateTime.Now);
                var lsApptWk = MainForm.ApptLt.Where(app => app.Start >= stWk && app.Start <= edWk).GroupBy(app => app.CustomerId);

                foreach (var app in lsApptWk)
                {
                    rpt.AppendLine($"Name: \t{MainForm.CustLt.Where(cust => cust.CustomerId == app.Key).Single().CustomerName}");
                    rpt.AppendLine($"Phone: \t{MainForm.addDict[app.Key].Phone}");
                    rpt.AppendLine("----------------");



                }
                richTextBox1.Text = rpt.ToString();
            }

        }


        private DateTime SearchBegWk(DateTime date)
        {
            var cul = Thread.CurrentThread.CurrentCulture;
            var diff = date.DayOfWeek - cul.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0) { diff = diff + 7; }
            return date.AddDays(-diff).Date;
        }

        private DateTime SearchEndWk(DateTime date)
        {
            return SearchBegWk(date).AddDays(7).AddMilliseconds(-1);
        }

       






        private void Reports_Load(object sender, EventArgs e)
        {
            userLt = DataContext.GetUsers();
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainControl.Show();

        }

        private void rdBtnCustomer_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rdBtnCustomer.Checked)
            {
                var rpt = new StringBuilder();
                rpt.AppendLine("Scheduled a Consulation: (Current Month)");
                rpt.AppendLine();
                DateTime begMoth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endMoth = begMoth.AddMonths(1).AddMilliseconds(-1);
                var consLsts = MainForm.ApptLt.Where(app => app.Start >= begMoth && app.Start <= endMoth).GroupBy(app => app.UserId);

//.OrderBy(app => app.Start).Where(app => app.Start >= begMoth && app.Start <= endMoth).GroupBy(app => app.UserId);

                foreach (var consLstts in consLsts)
                {
                    rpt.AppendLine($"{userLt.Where(u => u.UserId == consLstts.Key).Single().UserName} Scheduled");
                    foreach (var ap in consLstts.OrderBy(ap => ap.Start))
                    {
                        rpt.AppendLine($"{MainForm.CustLt.Where(cust => cust.CustomerId == ap.CustomerId).Single().CustomerName} - \t{ap.Start.ToString("dddd M/d/yyyy h:mm tt")}");
                    }
                    rpt.AppendLine();
                }
                richTextBox1.Text = rpt.ToString();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
