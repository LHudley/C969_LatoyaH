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
using C969_LatoyaH.Db_formshelper;

namespace C969_LatoyaH
{
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {
            InitializeComponent();
            GetTime();
            
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            RecordsdataGridView1.DataSource = GetCustomerRecords();
            
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
        

        private void btnRcAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtCusAdd.Text;
            string address1 = txtCusAdd.Text;
            string address2 = txtCusAdd2.Text;
            string postalCode = txtCusZip.Text;
            string phone = txtCusPhone.Text;
            string city = txtCusCity.Text;
            string country = txtCusCountry.Text;
            int customerId, addressId;

            customerId = DatabaseHelpers.AddNewCustomer(customerName, addressId, user);

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
            Schedule schedule = new Schedule();
            schedule.ShowDialog();
            this.Close();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            CustomerRecords custRecords = new CustomerRecords();
            custRecords.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.ShowDialog();
            this.Close();
        }
    }
}
