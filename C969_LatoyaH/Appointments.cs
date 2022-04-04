using System;
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
        public delegate string Added(string title, DateTime start, DateTime end);
        public delegate string Updated(int id, string title, DateTime start, DateTime end);


        public Appointments(int userId)
        {
            InitializeComponent();
            ShowAppointments(userId);
            ApptNotification();
        }

        public void ShowAppointments(int userId)
        {
            rdBtnDy.Checked = true;

            dataGridViewAppt.DataSource = null;
            var apptTbl = DataContext.GtAptDy(User.UserId);
            var apptSource = new BindingSource();
            dataGridViewAppt.DataSource = apptSource;

            comboBxType.DataSource = new object[]
            {
                "Presentation",
                "Scrum",
                "Status Update",
                "Brain Storming",
                "Informational"

            };
            var custTbl = DataContext.GetCustomers();
            var custLs = (from DataRow row in custTbl.Rows select row["Name"]).ToList();
            comboBoxCustomer.DataSource = custLs;
            DateTime now = DateTime.Now;
            startdateTimePicker1.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            enddateTimePicker2.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);



        }

        public void ApptNotification()
        {
            if (DataContext.AlertAferFifteenMin(User.UserId) == true)
            {
                MessageBox.Show("Alert!", "Your appointment starts in 15 minutes", MessageBoxButtons.OK);
            }
        }


        private void rdBtnMnth_CheckedChanged(object sender, EventArgs e)
        {
            var apptTbl = DataContext.GtAptByMth(User.UserId);
            var apptSource = new BindingSource();
            apptSource.DataSource = apptTbl;
            dataGridViewAppt.DataSource = apptSource;
        }

        private void rdBtnWk_CheckedChanged(object sender, EventArgs e)
        {
            var apptTbl = DataContext.GtAptByWk(User.UserId);
            var apptSource = new BindingSource();
            apptSource.DataSource = apptTbl;
            dataGridViewAppt.DataSource = apptSource;
        }

        private void rdBtnDy_CheckedChanged(object sender, EventArgs e)
        {
            var apptTbl = DataContext.GtAptDy(User.UserId);
            var apptSource = new BindingSource();
            apptSource.DataSource = apptTbl;
            dataGridViewAppt.DataSource = apptSource;
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            ToolTip ttp = new ToolTip();

            if (string.IsNullOrWhiteSpace(txtTitle.Text)) { ttp.Show("Please add title", txtTitle); return; }
            if (string.IsNullOrWhiteSpace(comboBxType.Text)) { ttp.Show("Please choose a type", comboBxType); return; }
            if (string.IsNullOrWhiteSpace(comboBoxCustomer.Text)) { ttp.Show("Please choose customer", comboBoxCustomer); return; }
            if (startdateTimePicker1.Value > enddateTimePicker2.Value) { ttp.Show("Start time must come before end", startdateTimePicker1); return; }
            if (startdateTimePicker1.Value.Hour < 8 || startdateTimePicker1.Value.Hour >= 17) { MessageBox.Show("Start time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            if (enddateTimePicker2.Value.Hour < 8 || enddateTimePicker2.Value.Hour > 17) { MessageBox.Show("End time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            else
            {
                DateTime start = startdateTimePicker1.Value;
                DateTime end = enddateTimePicker2.Value;

                if (DataContext.ApptOverlapping(User.UserId, start, end))
                {
                    MessageBox.Show("Please choose another appointment time", " Appointment overlaps", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    string customerName = comboBoxCustomer.Text;
                    int.TryParse(DataContext.GetaCustomer(customerName), out int customerId);
                    Appointment appt = new Appointment();
                    appt.Title = txtTitle.Text;
                    appt.CustomerId = customerId;
                    appt.UserId = User.UserId;
                    appt.Type = comboBxType.Text;
                    appt.Start = start;
                    appt.End = end;
                    DataContext.GetaAppointment(appt);
                    DataContext.ActivityLogs(User.UserName, "You added an appointment y Id: " + appt.AppointmentId);

                    //Lambda to confirm appts
                    Added x = (title, startTm, endTm) => { return title + " is scheduled " + Environment.NewLine + " It start at: " + startTm + Environment.NewLine + " It ends at: " + endTm; };
                    string successful = x.Invoke(appt.Title, appt.Start, appt.End);
                    MessageBox.Show(successful);

                    if (rdBtnDy.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnDy.Checked = true;
                    }
                    if (rdBtnWk.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnWk.Checked = true;
                    }
                    if (rdBtnMnth.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnMnth.Checked = true;
                    }

                }
            }

        }

        private void btnUpdtApp_Click(object sender, EventArgs e)
        {
            ToolTip ttp = new ToolTip();

            if (string.IsNullOrWhiteSpace(txtTitle.Text)) { ttp.Show("Please add title", txtTitle); return; }
            if (string.IsNullOrWhiteSpace(comboBxType.Text)) { ttp.Show("Please choose a type", comboBxType); return; }
            if (string.IsNullOrWhiteSpace(comboBoxCustomer.Text)) { ttp.Show("Please choose customer", comboBoxCustomer); return; }
            if (startdateTimePicker1.Value > enddateTimePicker2.Value) { ttp.Show("Start time must come before end", startdateTimePicker1); return; }
            if (startdateTimePicker1.Value.Hour < 8 || startdateTimePicker1.Value.Hour >= 17) { MessageBox.Show("Start time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            if (enddateTimePicker2.Value.Hour < 8 || enddateTimePicker2.Value.Hour > 17) { MessageBox.Show("End time within business hours are between 8am - 5pm", "You are ouside hours", MessageBoxButtons.OK); return; }
            else
            {
                DateTime start = startdateTimePicker1.Value;
                DateTime end = enddateTimePicker2.Value;

                if (DataContext.ApptOverlapping(User.UserId, start, end))
                {
                    MessageBox.Show("Please choose another appointment time", " Appointment overlaps", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    string customerName = comboBoxCustomer.Text;
                    int.TryParse(DataContext.GetaCustomer(customerName), out int customerId);
                    var getApptId = dataGridViewAppt.CurrentRow.Cells[0].Value;
                    Appointment appt = new Appointment();
                    appt.AppointmentId = int.Parse((string)getApptId);
                    appt.Title = txtTitle.Text;
                    appt.CustomerId = customerId;
                    appt.UserId = User.UserId;
                    appt.Type = comboBxType.Text;
                    appt.Start = start;
                    appt.End = end;
                    DataContext.EditaAppointment(appt);
                    DataContext.ActivityLogs(User.UserName, "You editted an appointment Id: " + getApptId);

                    //Lambda to confirm editted appts
                    Updated x = (id, title, startTm, endTm) => { return "Appointment Id: "+id+ " is editted " + Environment.NewLine + " The title is: " + title + Environment.NewLine + " It begins at: " + startTm + Environment.NewLine + " It ends at: " +endTm; };
                    string edsuccessful = x.Invoke(appt.AppointmentId, appt.Title, appt.Start, appt.End);
                    MessageBox.Show(edsuccessful);

                    if (rdBtnDy.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnDy.Checked = true;
                    }
                    if (rdBtnWk.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnWk.Checked = true;
                    }
                    if (rdBtnMnth.Checked == true)
                    {
                        ShowAppointments(User.UserId);
                        rdBtnMnth.Checked = true;
                    }

                }
            }


        }

        private void btnDlApp_Click(object sender, EventArgs e)
        {
            var confirmmed = MessageBox.Show("Want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmmed == DialogResult.Yes)
            {
                int gtApptId = int.Parse(dataGridViewAppt.CurrentRow.Cells[0].Value.ToString());
                DataContext.DeleteAppt(gtApptId); 
                DataContext.ActivityLogs(User.UserName, "You deleted appointment with Id: " + gtApptId);
            }
            if (rdBtnDy.Checked == true)
            {
                ShowAppointments(User.UserId);
                rdBtnDy.Checked = true;
            }
            if (rdBtnWk.Checked == true)
            {
                ShowAppointments(User.UserId);
                rdBtnWk.Checked = true;
            }
            if (rdBtnMnth.Checked == true)
            {
                ShowAppointments(User.UserId);
                rdBtnMnth.Checked = true;
            }


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
    }
}
