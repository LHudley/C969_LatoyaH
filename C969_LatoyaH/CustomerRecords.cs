using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace C969_LatoyaH
{
    public partial class CustomerRecords : Form
    {

        public CustomerRecords(int userId)
        {
            InitializeComponent();
            GetTime();
            ShowCustomers();
            
        }

       public void ShowCustomers()
        {
            var custTable = DataContext.GetCustomers();
            var custSource = new BindingSource();
            custSource.DataSource = custTable;
            RecordsdataGridView1.DataSource = null;
            RecordsdataGridView1.DataSource = custSource;
        }
        public static DataTable GetCustomerRecords()
        {
           
                DataTable dtCustomer = new DataTable();          
                string connRecords = ConfigurationManager.ConnectionStrings["C969_LatoyaH.Properties.Settings.client_scheduleConnectionString"].ConnectionString;               
                using (MySqlConnection con = new MySqlConnection(connRecords))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select customer.customerId, customer.customerName, address.address, address.address2, " +
                        "address.postalCode, address.phone,city.city,country.country from customer join address on customer.addressId=address.addressId" +
                        " join city on address.cityId=city.cityId join country on city.countryId=country.countryId;", con))
                    {
                        con.Open();
                        MySqlDataReader rd = cmd.ExecuteReader();
                        dtCustomer.Load(rd);

                    
                    }
                }
                return dtCustomer;
           


        }
        private void GetTime()
        {

            labelTime.Text = $"Logged in on {DateTime.Now.ToUniversalTime()}";

        }
        
        //public static int AddCust(string customerName, int addressId, string user)
        //{
        //    try
        //    {
        //        DateTime currentTm = DateTime.Now;
        //        var addingCust = new Customer(customerName, addressId, 1, currentTm, user, currentTm, user);
        //        string sql = "server = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";
        //        MySqlConnection con = new MySqlConnection(sql);
        //        MySqlDataAdapter sda = new MySqlDataAdapter($"insert into 'customer' values ({addingCust.CustomerId}, '{addingCust.CustomerName}', " +
        //            $"" + $"{addingCust.AddressId}, {addingCust.Active},{addingCust.CreateDate},{addingCust.CreatedBy},{addingCust.LastUpdate}," +
        //            $"{addingCust.LastUpdateBy}", con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);

        //        CustomerRecords.AllCustomers.Add(addingCust);
        //        return addingCust.CustomerId;

        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("MySql Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

        private void btnRcAdd_Click(object sender, EventArgs e)
        {

            ToolTip ttip = new ToolTip();

            if (string.IsNullOrWhiteSpace(custNmFd.Text))
            {
                ttip.Show("Customer name is required ", custNmFd);
                return;
            }
            if (string.IsNullOrWhiteSpace(cstAdFd.Text))
            {
                ttip.Show("Address is required", cstAdFd);
                return;
            }
            if (string.IsNullOrWhiteSpace(custCtFd.Text))
            {
                ttip.Show("City is required ", custCtFd);
                return;
            }
            if (string.IsNullOrWhiteSpace(cstCountryFd.Text))
            {
                ttip.Show("Country is required", cstCountryFd);
                return;
            }

            else
            {

            }

        }

        private void btnRcUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnRcDelete_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// //////////////////////////Navigation to other forms///////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppt_Click(object sender, EventArgs e)
        {
            int currentUser = User.UserId;
            this.Hide();
            Schedule schedule = new Schedule();
            schedule.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports report = new Reports();
            report.ShowDialog();
            this.Close();
        }

        //private void RecordsdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    getApptDb();
        //}
        //public void getApptDb()
        //{
        //    string apptCommunication = $"Select appointment.appointmentId, customer.customerName, customer.customerId, appointment.title," +
        //        $"appointment.descrption, appointment.location,appointment.contact, appointment.start, appointment.end, appointment.type," +
        //        $"appointment.url FROM appointment Inner Join customer on appointment.customerId = customer.customerId Inner Join 'user' on " +
        //        $"appoinment.userId = 'user'.userId Where customer.customerId = '{RecordsdataGridView1.CurrentRow.Cells[0].Value}'";

        //}
    }
}
