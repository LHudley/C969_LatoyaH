using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH.Db_formshelper
{
    class DatabaseHelpers
    {
        public static int AddNewCustomer(string customerName, int addressId, string user)
        {
            
            try
            {
                DateTime currentTm = DateTime.Now;
                var addingCust = new Customer(customerName, addressId, 1, currentTm, user, currentTm, user);

                string sql = "server = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";
                MySqlConnection con = new MySqlConnection(sql);
                MySqlDataAdapter sda = new MySqlDataAdapter($"insert into 'customer' values ({addingCust.CustomerId}, '{addingCust.CustomerName}', " +
                    $"{addingCust.AddressId}, {addingCust.Active},{addingCust.CreateDate},{addingCust.CreatedBy},{addingCust.LastUpdate}," +
                    $"{addingCust.LastUpdateBy}", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
