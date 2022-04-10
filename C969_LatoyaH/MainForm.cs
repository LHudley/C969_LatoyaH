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
    public partial class MainForm : Form
    {
        public static BindingList<Appointment> ApptLt = new BindingList<Appointment>();
        public static BindingList<Customer> CustLt = new BindingList<Customer>();
        public static User LgdUsr;
        public static Dictionary<int, Address> addDict = new Dictionary<int, Address>();
        public static Dictionary<int,City> cityDict = new Dictionary<int, City>();
        public static Dictionary<int, Country> countryDict = new Dictionary<int, Country>();



        public MainForm(User user)
        {
            InitializeComponent();
            LgdUsr = user;
        }

        private void btnAppt_Click(object sender, EventArgs e)
        {
            var sched = new Appointments(this);
            sched.Show();
            Hide();

        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            var custRecords = new CustomerRecords(this);
            custRecords.Show();
            Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            var custReports = new Reports(this);
            custReports.Show();
            Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataContext.GetCustomers();
            DataContext.GetaAddress();
            DataContext.GettheCity();
            DataContext.GettheCountry();
            DataContext.GetaAppointment();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var appointmentInFifteen = ApptLt.Where(appt =>
            {


                var now = DateTime.Now;
                var alertForFifteen = new TimeSpan(0, 15, 0);
                var remainingTime = appt.Start - now;
                if (remainingTime > new TimeSpan(0, 0, 0) && remainingTime <= alertForFifteen) { return true; }
                return false;

            });
            if(appointmentInFifteen.Count() > 0) { var appointments = appointmentInFifteen.First();
                MessageBox.Show($"Alert, you have an appointment with customer {CustLt.Where(cust => cust.CustomerId == appointments.CustomerId).Single().CustomerName} at {appointments.Start.ToString("h:mm tt")}", "Later Appointment", MessageBoxButtons.OK);
            }
        }
    }
}
