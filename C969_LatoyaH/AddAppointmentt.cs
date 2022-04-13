using MySql.Data.MySqlClient;
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
    public partial class AddAppointmentt : Form
    {
        private Appointments ApFrm;
        private int selApptId = -1;

        public AddAppointmentt(Appointments aForm, int appointmentId)
        {
            InitializeComponent();
            ApFrm = aForm;
            selApptId = appointmentId;

        }
        public AddAppointmentt(Appointments aForm)
        {
            InitializeComponent();
            ApFrm = aForm;

        }
        private void AddAppointmentt_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> cusDictionary = MainForm.CustLt.ToDictionary(list => list.CustomerId, list => list.CustomerName);
            comboBox1.DataSource = new BindingSource(cusDictionary, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedItem = null;
            comboBox2.DataSource = new[] {"Presentation",
                       "Scrum",
                       "Consultation"
            };
            comboBox2.SelectedItem = null;
            if (selApptId >= 0)
            {
                Appointment appointment = MainForm.ApptLt.Where(appt => appt.AppointmentId == selApptId).Single();
                textBox2.Text = appointment.AppointmentId.ToString();
                comboBox1.Text = cusDictionary[appointment.CustomerId];
                comboBox2.Text = appointment.Type;
                dateTimePicker1.Value = appointment.Start;
                dateTimePicker2.Value = appointment.End;

            }
            else
            {
                DateTime now = DateTime.Now;
                dateTimePicker1.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
                dateTimePicker2.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);

            }




        }


        //adding / edit appointments
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                TimeSpan openBusiness = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0).TimeOfDay;
                TimeSpan closedBusiness = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0).TimeOfDay;
                
                int selCustId = Convert.ToInt32(comboBox1.SelectedValue);
                string selType = comboBox2.SelectedValue.ToString();
                DateTime selStart = dateTimePicker1.Value;
                DateTime selEnd = dateTimePicker2.Value;
                bool ovrlap = false;

                foreach (var appt in MainForm.ApptLt)
                {
                    if (appt.Start <= selStart && appt.End > selStart && (!(selApptId >= 0)))
                    {
                        ovrlap = true;
                    }
                    if (selStart <= appt.Start && selEnd > appt.Start && (!(selApptId >= 0)))
                    {
                        ovrlap = true;
                    }
                }
                if (selCustId < 1) { MessageBox.Show("Please choose a customer"); }
                if (selStart > selEnd) { MessageBox.Show("End time should NOT be before start time."); }
                if ((selStart.TimeOfDay < openBusiness) || (selStart.TimeOfDay > closedBusiness) || (selEnd.TimeOfDay < openBusiness) || (selEnd.TimeOfDay > closedBusiness)) { throw new ApplicationException("Please schedule during office hours 8am - 5pm"); }
                if (ovrlap) { MessageBox.Show("Warning! Appointments are overlapping"); }
                if (selApptId >= 0) 
                { 
                    Appointment appointment = MainForm.ApptLt.Where(appt => appt.AppointmentId == selApptId).Single(); 
                    
                    DataContext.EditaAppointment(appointment, selCustId, selType, selStart, selEnd); 
                }
                else { DataContext.AddanAppointment(selCustId,  selType, selStart, selEnd); }
                Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an appointment type", "Directions", MessageBoxButtons.OK);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Directions", MessageBoxButtons.OK);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK);
            }
        




           
        }

        //cancel appointment
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
           

        }

       
        private void AddAppointmentt_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApFrm.selectionUpdt();
            ApFrm.Show();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
