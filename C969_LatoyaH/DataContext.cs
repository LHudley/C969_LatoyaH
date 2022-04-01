using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public static class DataContext
    {
        private const string server = "localhost";
        private const string port = "3306"; 
        private const string username = "sqlUser"; 
        private const string password = "Passw0rd!";
        private const string database = "client_schedule";
        private const string connString = "server =" + server +";"+ "port = " + port + ";" + " username =" + username + ";" +
            "password = " + password + ";" +"database =" +database+ ";" ;
        private static MySqlConnection mysqlcon = new MySqlConnection(connString);

        public static void Connect()
        {
            if(mysqlcon.State != System.Data.ConnectionState.Open)
            {
                mysqlcon.Open();
            }
            return;
        }
        public static void Disconnect()
        {
            if (mysqlcon.State != System.Data.ConnectionState.Closed)
            {
                mysqlcon.Close();
            }
            return;
        }
        public static string GetaCustomer(string name)
        {
            string customerId = null;

            try
            {
                Connect();
                var customerSelection = "Select customerId from custoer where customerName = '" + name + "';";

                MySqlCommand comm = new MySqlCommand(customerSelection, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerId = reader["cutomerId"].ToString();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem getting customerId: " + ex);
            }

            Disconnect();
            return customerId;
        }
        public static DataTable GetCustomers()
        {
            DataTable custTable = new DataTable();

            try
            {

                Connect();
                var customerSelection = "select customer.customerId, customer.customerName, address.address, address.address2, city.city, address.postalCode," +
                    "country.country, address.phone, from customer join address on customer.addressId = address.addressId join city on " +
                    "address.cityId= city.cityId join country on city.countryId = country.countryId; ";
                MySqlCommand comm = new MySqlCommand(customerSelection, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        custTable.Rows.Add(reader["customerId"], reader["customerName"], reader["address"], reader["address2"], reader["city"],
                            reader["postalCode"], reader["country"], reader["phone"]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was trouble getting appointments: " + ex);
            }
            Disconnect();
            return custTable;
        }
        public static void AddaCustomer(Customer customer)
        {
            string customerName = customer.CustomerName;
            int addresId = customer.AddressId;
            int active = customer.Active;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createBy = User.UserName;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adCustomer = "insert into customer(customerName, addressId, active, createDate, createBy, lastUpdate, lastUpdateBy) values " +
                    "('" + customerName + "', '" + addresId + "', '" + active + "', '" + createDate + "', '" + createBy + "', '" + lastUpdate + "', '"
                    + lastUpdateBy + "');";
                MySqlCommand comm = new MySqlCommand(adCustomer, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();


            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error adding the customer: " + ex);
            }

        }
        public static void UpdateaCustomer(Customer customer)
        {
            int customerId = customer.CustomerId;
            string customerName = customer.CustomerName;
            int addressId = customer.AddressId;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var updateCustomer = "update customer set customerName = '" + customerName + "', addressId = '" + addressId + "', lastUpdate = '" + lastUpdate + "', lastUpdateBy = '" + lastUpdateBy + "' where customerId = '" + customerId + "';";
                MySqlCommand comm = new MySqlCommand(updateCustomer, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue updating the customer: " + ex);
            }
            Disconnect();
        }
        public static void DeleteaCustomer(int customerId)
        {
            try
            {
                Connect();
                var deleteCust = "delete from customer where customerId = '" + customerId + "';";
                MySqlCommand comm = new MySqlCommand(deleteCust, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an issue deleting customer: " + ex);
            }
        }
    }
}
