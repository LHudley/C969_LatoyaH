using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class Appointments : Form
    {
        //public delegate string Added(string title, DateTime start, DateTime end);
        //public delegate string Updated(int id, string title, DateTime start, DateTime end);
        DataTable dt = new DataTable();
        DateTime cTm;
        public int custIsNm;

        public Appointments()
        {
            InitializeComponent();
            cTm = DateTime.Now;
            monthCalendar1.AddBoldedDate(cTm);
            dataGridViewAppt.DataSource = gtCalender(rdBtnWk.Checked);
            ApptNotification(dataGridViewAppt);
        }

        public static Array gtCalender(bool vWeek)
        {
           
                MySqlConnection conn = new MySqlConnection(DataContext.connString);
                conn.Open();
                string getCal = $"Select customerId, type, start, end, appointmentId, userId from appointment where userId = '{DataContext.GetUserId()}'";
                MySqlCommand comm = new MySqlCommand(getCal, conn);
                MySqlDataReader reader = comm.ExecuteReader();
                Dictionary<int, Hashtable> app = new Dictionary<int, Hashtable>();
                while(reader.Read())
                    {
                    Hashtable appts = new Hashtable();
                    appts.Add("customerId", reader[0]);
                    appts.Add("type", reader[1]);

                    appts.Add("start", reader[2]);

                    appts.Add("end", reader[3]);

                    appts.Add("userId", reader[5]);

                    app.Add(Convert.ToInt32(reader[4]), appts);


                }
                reader.Close();
                foreach(var a in app.Values)
                {
                    getCal = $"selet userName from user where userId = '{a["userId"]}'";
                    comm = new MySqlCommand(getCal, conn);
                    reader = comm.ExecuteReader();
                    reader.Read();
                    a.Add("userName", reader[0]);
                    reader.Close();
                }
                foreach (var a in app.Values)
                {
                    getCal = $"selet customerName from customer where customerId = '{a["customerId"]}'";
                    comm = new MySqlCommand(getCal, conn);
                    reader = comm.ExecuteReader();
                    reader.Read();
                    a.Add("customerName", reader[0]);
                    reader.Close();
                }

                Dictionary<int, Hashtable> wkAppt = new Dictionary<int, Hashtable>();
                foreach (var a in app)
                {
                    DateTime stTime = DateTime.Parse(a.Value["start"].ToString());
                    DateTime endTime = DateTime.Parse(a.Value["end"].ToString());
                    DateTime today = DateTime.UtcNow;
                    if (vWeek)
                    {
                        DateTime sun = today.AddDays(-(int)today.DayOfWeek);
                        DateTime sat = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Saturday);

                        if (stTime >= sun && endTime < sat) { wkAppt.Add(a.Key, a.Value); }
                    }
                    else
                    {
                        DateTime fDMth = new DateTime(today.Year, today.Month, 1);
                        DateTime lTMth = fDMth.AddMonths(1).AddDays(-1); 
                        if(stTime >= fDMth && endTime < lTMth) { wkAppt.Add(a.Key, a.Value); }

                    }
                }
            DataContext.SetApp(app);
            var appArr = from row in wkAppt select new { Id = row.Key, Type = row.Value, StartTime = DataContext.tzConv(row.Value["start"].ToString()), EndTime = DataContext.tzConv(row.Value["end"].ToString()), Customer = row.Value["customerName"] };
            conn.Close();
            return appArr.ToArray();


            
        }

        public void ShowAppointments(string c)
        {

            using (MySqlConnection conn = new MySqlConnection(DataContext.connString))
            {
                MySqlCommand comm = new MySqlCommand(c, conn);
                conn.Open();
                MySqlDataAdapter adpt = new MySqlDataAdapter(comm);
                adpt.Fill(dt);
                conn.Close();
            }
        //    rdBtnDy.Checked = true;

        //    dataGridViewAppt.DataSource = null;
        //    var apptTbl = DataContext.GtAptDy(User.UserId);
        //    var apptSource = new BindingSource();
        //    dataGridViewAppt.DataSource = apptSource;


        //    comboBxType.DataSource = new object[]
        //    {
        //        "Presentation",
        //        "Scrum",
        //        "Status Update",
        //        "Brain Storming",
        //        "Informational"

        //    };
        //    var custTbl = DataContext.GetCustomers();
        //    var custLs = (from DataRow row in custTbl.Rows select row["Name"]).ToList();
        //    comboBoxCustomer.DataSource = custLs;
        //    DateTime now = DateTime.Now;
        //    startdateTimePicker1.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
        //    enddateTimePicker2.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);



        }
        private void showWk()
        {
            monthCalendar1.RemoveAllBoldedDates();
            dt.Clear();
            int d = (int)cTm.DayOfWeek;
            string startDt = cTm.AddDays(-d).ToString("yyyy-MM-dd HH:mm:ss");
            DateTime tempDt = Convert.ToDateTime(startDt);
            for(int i = 0; i < 7; i++) { monthCalendar1.AddBoldedDate(tempDt.AddDays(i)); }
            monthCalendar1.UpdateBoldedDates();
            string endDt = cTm.AddDays(7 - d).ToString("yyyy-MM-dd HH:mm:ss");
            ShowAppointments($"select * from appointment where (start between'" + startDt + "' and '" + endDt + " ')");
            dataGridViewAppt.DataSource = dt;
        }

        public static void ApptNotification(DataGridView calendar)
        {
            foreach(DataGridViewRow row in calendar.Rows)
            {
                DateTime now = DateTime.UtcNow;
                DateTime start = DateTime.Parse(row.Cells[2].Value.ToString()).ToUniversalTime();
                TimeSpan tmSpan = now - start;
                if(tmSpan.TotalMinutes >= -15 && tmSpan.TotalMinutes < 1)
                {
                    MessageBox.Show($"Meeting with {row.Cells[4].Value} at {row.Cells[2].Value}");
                }
            }

        //    if(DataContext.AlertAferFifteenMin(User.UserId) == true)
        //    {
        //        MessageBox.Show("Alert!", "Your appointment starts in 15 minutes", MessageBoxButtons.OK);
        //    }
        }
        private void showMoth()
        {
            monthCalendar1.RemoveAllBoldedDates();
            dt.Clear();
            int month = cTm.Month;
            int year = cTm.Year;
            int day = 1;
            int date = 0;
            string startDt = year.ToString() + "-" + month.ToString() + "-" + day.ToString();
            DateTime tempDt = Convert.ToDateTime(startDt);
            switch (month) { case 1: case 3: case 5: case 7: case 8: case 10: date = 31; break;
                case 4: case 6: case 9: case 11: date = 30; break;
                default: date = 29; break; }
            for (int i = 0; i < date; i++) { monthCalendar1.AddBoldedDate(tempDt.AddDays(i)); }
            monthCalendar1.UpdateBoldedDates();
            string endDt = year.ToString() + "-" + month.ToString() + "-" + date.ToString();
            ShowAppointments($"select * from appointment where (start between'" + startDt + "' and '" + endDt + " ')");
            dataGridViewAppt.DataSource = dt;
        }


        //private void rdBtnMnth_CheckedChanged(object sender, EventArgs e)
        //{
        //    var apptTbl = DataContext.GtAptByMth(User.UserId);
        //    var apptSource = new BindingSource();
        //    apptSource.DataSource = apptTbl;
        //    dataGridViewAppt.DataSource = apptSource;
        //    dataGridViewAppt.Columns["Id"].Visible = false;

        //}

        //private void rdBtnWk_CheckedChanged(object sender, EventArgs e)
        //{
        //    var apptTbl = DataContext.GtAptByWk(User.UserId);
        //    var apptSource = new BindingSource();
        //    apptSource.DataSource = apptTbl;
        //    dataGridViewAppt.DataSource = apptSource;
        //    dataGridViewAppt.Columns["Id"].Visible = false;

        //}

        //private void rdBtnDy_CheckedChanged(object sender, EventArgs e)
        //{
        //    var apptTbl = DataContext.GtAptDy(User.UserId);
        //    var apptSource = new BindingSource();
        //    apptSource.DataSource = apptTbl;
        //    dataGridViewAppt.DataSource = apptSource;
        //    dataGridViewAppt.Columns["Id"].Visible = false;

        //}

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            Hide();
            AddAppointmentt aa = new AddAppointmentt();
            aa.Closed += (c, args) => this.Close();
            aa.ShowDialog();

            //ToolTip ttp = new ToolTip();

            //if (string.IsNullOrWhiteSpace(txtTitle.Text)) { ttp.Show("Please add title", txtTitle); return; }
            //if (string.IsNullOrWhiteSpace(comboBxType.Text)) { ttp.Show("Please choose a type", comboBxType); return; }
            //if (string.IsNullOrWhiteSpace(comboBoxCustomer.Text)) { ttp.Show("Please choose customer", comboBoxCustomer); return; }
            //if (startdateTimePicker1.Value > enddateTimePicker2.Value) { ttp.Show("Start time must come before end", startdateTimePicker1); return; }
            //if (startdateTimePicker1.Value.Hour < 8 || startdateTimePicker1.Value.Hour >= 17) { MessageBox.Show("Start time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            //if (enddateTimePicker2.Value.Hour < 8 || enddateTimePicker2.Value.Hour > 17) { MessageBox.Show("End time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            //else
            //{
            //    DateTime start = startdateTimePicker1.Value;
            //    DateTime end = enddateTimePicker2.Value;

            //    if (DataContext.ApptOverlapping(User.UserId, start, end))
            //    {
            //        MessageBox.Show("Please choose another appointment time", " Appointment overlaps", MessageBoxButtons.OK);
            //        return;
            //    }
            //    else
            //    {
            //        string customerName = comboBoxCustomer.Text;
            //        int.TryParse(DataContext.GetaCustomer(customerName), out int customerId);
            //        Appointment appt = new Appointment();
            //        appt.Title = txtTitle.Text;
            //        appt.CustomerId = customerId;
            //        appt.UserId = User.UserId;
            //        appt.Type = comboBxType.Text;
            //        appt.Start = start;
            //        appt.End = end;
            //        DataContext.GetaAppointment(appt);
            //        DataContext.ActivityLogs(User.UserName, "You added an appointment y Id: " + appt.AppointmentId);

            //        //Lambda to confirm appts
            //        Added x = (title, startTm, endTm) => { return title + " is scheduled " + Environment.NewLine + " It start at: " + startTm + Environment.NewLine + " It ends at: " + endTm; };
            //        string successful = x.Invoke(appt.Title, appt.Start, appt.End);
            //        MessageBox.Show(successful);

            //        if (rdBtnDy.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnDy.Checked = true;
            //        }
            //        if (rdBtnWk.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnWk.Checked = true;
            //        }
            //        if (rdBtnMnth.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnMnth.Checked = true;
            //        }

            //    }
            //}

        }

        private void btnUpdtApp_Click(object sender, EventArgs e)
        {
            Hide();
            UpdtAppointments ua = new UpdtAppointments();
            ua.Closed += (c, args) => this.Close();
            ua.ShowDialog();

            //ToolTip ttp = new ToolTip();

            //if (string.IsNullOrWhiteSpace(txtTitle.Text)) { ttp.Show("Please add title", txtTitle); return; }
            //if (string.IsNullOrWhiteSpace(comboBxType.Text)) { ttp.Show("Please choose a type", comboBxType); return; }
            //if (string.IsNullOrWhiteSpace(comboBoxCustomer.Text)) { ttp.Show("Please choose customer", comboBoxCustomer); return; }
            //if (startdateTimePicker1.Value > enddateTimePicker2.Value) { ttp.Show("Start time must come before end", startdateTimePicker1); return; }
            //if (startdateTimePicker1.Value.Hour < 8 || startdateTimePicker1.Value.Hour >= 17) { MessageBox.Show("Start time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            //if (enddateTimePicker2.Value.Hour < 8 || enddateTimePicker2.Value.Hour > 17) { MessageBox.Show("End time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            //else
            //{
            //    DateTime start = startdateTimePicker1.Value;
            //    DateTime end = enddateTimePicker2.Value;

            //    if (DataContext.ApptOverlapping(User.UserId, start, end))
            //    {
            //        MessageBox.Show("Please choose another appointment time", " Appointment overlaps", MessageBoxButtons.OK);
            //        return;
            //    }
            //    else
            //    {
            //        string customerName = comboBoxCustomer.Text;
            //        int.TryParse(DataContext.GetaCustomer(customerName), out int customerId);
            //        var getApptId = dataGridViewAppt.CurrentRow.Cells[0].Value;
            //        Appointment appt = new Appointment();
            //        appt.AppointmentId = int.Parse((string)getApptId);
            //        appt.Title = txtTitle.Text;
            //        appt.CustomerId = customerId;
            //        appt.UserId = User.UserId;
            //        appt.Type = comboBxType.Text;
            //        appt.Start = start;
            //        appt.End = end;
            //        DataContext.EditaAppointment(appt);
            //        DataContext.ActivityLogs(User.UserName, "You editted an appointment Id: " + getApptId);

            //        //Lambda to confirm editted appts
            //        Updated x = (id, title, startTm, endTm) => { return "Appointment Id: "+id+ " is editted " + Environment.NewLine + " The title is: " + title + Environment.NewLine + " It begins at: " + startTm + Environment.NewLine + " It ends at: " +endTm; };
            //        string edsuccessful = x.Invoke(appt.AppointmentId, appt.Title, appt.Start, appt.End);
            //        MessageBox.Show(edsuccessful);

            //        if (rdBtnDy.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnDy.Checked = true;
            //        }
            //        if (rdBtnWk.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnWk.Checked = true;
            //        }
            //        if (rdBtnMnth.Checked == true)
            //        {
            //            ShowAppointments(User.UserId);
            //            rdBtnMnth.Checked = true;
            //        }

            //    }
            //}


        }

        private void btnDlApp_Click(object sender, EventArgs e)
        {


            Hide();
            DeleteAppointments dta = new DeleteAppointments();
            dta.Closed += (c, args) => this.Close();
            dta.ShowDialog();
            //var confirmmed = MessageBox.Show("Want to delete?", "Confirm", MessageBoxButtons.YesNo);
            //if (confirmmed == DialogResult.Yes)
            //{
            //    int gtApptId = int.Parse(dataGridViewAppt.CurrentRow.Cells[0].Value.ToString());
            //    DataContext.DeleteAppt(gtApptId); 
            //    DataContext.ActivityLogs(User.UserName, "You deleted appointment with Id: " + gtApptId);
            //}
            //if (rdBtnDy.Checked == true)
            //{
            //    ShowAppointments(User.UserId);
            //    rdBtnDy.Checked = true;
            //}
            //if (rdBtnWk.Checked == true)
            //{
            //    ShowAppointments(User.UserId);
            //    rdBtnWk.Checked = true;
            //}
            //if (rdBtnMnth.Checked == true)
            //{
            //    ShowAppointments(User.UserId);
            //    rdBtnMnth.Checked = true;
            //}


        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            int currentUser = User.UserId;
            CustomerRecords rcrds = new CustomerRecords(currentUser);
            rcrds.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports report = new Reports();
            report.ShowDialog();
            this.Close();
        }

        private void rdBtnMnth_CheckedChanged(object sender, EventArgs e)
        {
            showMoth();
        }

        private void rdBtnWk_CheckedChanged(object sender, EventArgs e)
        {
            showWk();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            cTm = e.Start;
            if (rdBtnMnth.Checked) { showMoth(); } else {showWk();}
        }
    }
}
