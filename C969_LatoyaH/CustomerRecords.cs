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
        public CustomerRecords()
        {
            InitializeComponent();
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            RecordsdataGridView1.DataSource = GetCustomerRecords();
        }
        private DataTable GetCustomerRecords()
        {
            DataTable dtCustomer = new DataTable();
            string connRecords= ConfigurationManager.ConnectionStrings["C969_LatoyaH.Properties.Settings.client_scheduleConnectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connRecords))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select * from customer", con))
                {
                    con.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    dtCustomer.Load(rd);
                }
            }
                return dtCustomer;
        }

        private void btnRcAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnRcUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnRcDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
