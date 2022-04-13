using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class Appointments : Form
    {
        
        private DateTime selDate;
        private bool mthSel = true;
        private Form MainControl;
        public Appointments(Form main)
        {
            InitializeComponent();
            MainControl = main;
            selDate = DateTime.Now;
        }


        private void rdBtnMnth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnMnth.Checked == true) { mthSel = true; updateMth(); }
        }

        private void rdBtnWk_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnWk.Checked == true) { mthSel = false; updateWk(); }


        }


        private void btnAddApp_Click(object sender, EventArgs e)
        {
            var addApptForm = new AddAppointmentt(this);
            addApptForm.Show();
            dataGridViewAppt.ClearSelection();
            Hide();
;          



        }

        //Click calendar after making changes to view updated appointment ///////////
        private void btnUpdtApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAppt.SelectedRows.Count < 1) { throw new ApplicationException("Please select an appointment "); }
                var selRow = dataGridViewAppt.SelectedRows[0];
                int selApptId = Convert.ToInt32(selRow.Cells[0].Value);
                var eFrm = new AddAppointmentt(this, selApptId);
                eFrm.Show();
                dataGridViewAppt.ClearSelection();
                Hide();
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK);
            }
           
            

        }
        public void selectionUpdt()
        {
            if (mthSel)
            {

                updateMth();
            }
            else
            {
                updateWk();
            }
        }

        private void updateWk()
        {
            DateTime startWk = gtStartofWk(selDate);
            DateTime endWk = gtEndofWk(selDate);
            dataGridViewAppt.DataSource = gtApptInTm(startWk, endWk);

        }

        private DateTime gtEndofWk(DateTime date)
        {
            return gtStartofWk(date).AddDays(7).AddMilliseconds(-1);
        }
            

        private DateTime gtStartofWk(DateTime date)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var dif = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (dif < 0) { dif = dif + 7; }
            return date.AddDays(-dif).Date;
        }

        private BindingList<Appointment> gtApptInTm(DateTime startTime, DateTime endTime)
        {

            return new BindingList<Appointment>(MainForm.ApptLt.Where(appt => appt.Start >= startTime && appt.End <= endTime).ToList());
        }

        private DateTime gtEndofMth(DateTime date)
        {
            return gtStartofMth(date).AddMonths(1).AddMilliseconds(-1);
        }

        private DateTime gtStartofMth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
           
        }
        

        private BindingList<Appointment> gtCustomerId(int id)
        {
            return new BindingList<Appointment>(MainForm.ApptLt.Where(appt => appt.CustomerId == id).ToList());
        }

        private void updateMth()
        {


            DateTime startOfMth = gtStartofMth(selDate);
            DateTime endOfMth = gtEndofMth(selDate);
            dataGridViewAppt.DataSource = gtApptInTm(startOfMth, endOfMth);
        }

        private void btnDlApp_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewAppt.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("Select appointment to delete");
                }
                DialogResult confm = MessageBox.Show("Sure you want to delete? ", "Confirm delete", MessageBoxButtons.YesNo);
                if(confm == DialogResult.Yes)
                {
                    var selRow = dataGridViewAppt.SelectedRows[0];
                    int selApptId = Convert.ToInt32(selRow.Cells[0].Value);
                    Appointment selAppt = MainForm.ApptLt.Where(appt => appt.AppointmentId == selApptId).Single();
                    DataContext.DeleteAppt(selAppt);
                    selectionUpdt();
                    
                }
                else
                {
                    dataGridViewAppt.ClearSelection();
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Delete issues", MessageBoxButtons.OK);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "There was an issue deleting", MessageBoxButtons.OK);
            }

        }

      

        private void Appointments_Load(object sender, EventArgs e)
        {
            dataGridViewAppt.DataSource = gtApptInTm(new DateTime(selDate.Year, selDate.Month, selDate.Day), new DateTime(selDate.Year, selDate.Month, selDate.Day + 1));
        }

        private void Appointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainControl.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selDate = monthCalendar1.SelectionStart;
            if(rdBtnMnth.Checked == true) { updateMth(); }
            else { updateWk(); }
        }

        private void btnRecords_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
