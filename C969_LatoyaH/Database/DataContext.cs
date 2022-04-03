using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_LatoyaH
{
    public static class DataContext
    {
        private const string connString = "server = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";       
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

        public static void Login(string username, string password)
        {
            try
            {
                Connect();
                var selectUser = "select * from user where username ='" + username + "'and password='" + password + "';";
                MySqlCommand comm = new MySqlCommand(selectUser, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var placeId = reader["userId"].ToString();
                        var placeusnm = reader["userName"].ToString();
                        var placepswd = reader["password"].ToString();
                        var placecreatedt = reader["createDate"];
                        var placecreateby = reader["createdBy"].ToString();
                        var placelastupdt = reader["lastUpdate"];
                        var placelastupdtby = reader["lastUpdateBy"].ToString();

                        if (placeusnm != username || placepswd != password)
                        {
                            User.UserId = 0;
                            return;
                        }
                        else
                        {
                            User.UserId = int.Parse(placeId);
                            User.UserName = placeusnm;
                            User.Password = placepswd;
                            User.CreateDate = (DateTime)placecreatedt;
                            User.CreatedBy = placecreateby;
                            User.LastUpdate = (DateTime)placelastupdt;
                            User.LastUpdateBy = placelastupdtby;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There wass an error while logging in " + ex);
            }
            Disconnect();
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

            if (!custTable.Columns.Contains("Id"))
            {
                custTable.Columns.Add("Id", typeof(string));
            }
            if (!custTable.Columns.Contains("Name"))
            {
                custTable.Columns.Add("Name", typeof(string));
            }
            if (!custTable.Columns.Contains("Address"))
            {
                custTable.Columns.Add("Address", typeof(string));
            }
            if (!custTable.Columns.Contains("Address_2"))
            {
                custTable.Columns.Add("Address_2", typeof(string));
            }
            if (!custTable.Columns.Contains("City"))
            {
                custTable.Columns.Add("City", typeof(string));
            }
            if (!custTable.Columns.Contains("Postal Code"))
            {
                custTable.Columns.Add("Postal Code", typeof(string));
            }
            if (!custTable.Columns.Contains("Country"))
            {
                custTable.Columns.Add("Country", typeof(string));
            }
            if (!custTable.Columns.Contains("Phone"))
            {
                custTable.Columns.Add("Phone", typeof(string));
            }

            try
            {

                Connect();
                var customerSelection = "select customer.customerId, customer.customerName, address.address, address.address2, city.city, address.postalCode," +
                    "country.country, address.phone from customer join address on customer.addressId = address.addressId join city on address.cityId= city.cityId join country on city.countryId = country.countryId; ";
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
            string createdBy = User.UserName;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adCustomer = "insert into customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) values " +
                    "('" + customerName + "', '" + addresId + "', '" + active + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '"
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

        public static void AddaCountry(Country country)
        {
            string countryName = country.CountryName;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.UserName;
            string lastUpate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adCountry = " insert into country(country, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + countryName + "', '" + createDate + "','" + createdBy + "', '" + lastUpate + "','" + lastUpdateBy + "');";
                MySqlCommand comm = new MySqlCommand(adCountry, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was n error adding country: " + ex);
            }
            Disconnect();
        }

        public static string GettheCountry(string countryName)
        {
            string countryId = "0";

            try
            {
                Connect();
                var gtCountry = "select countryId from country where country = '" + countryName + "';";
                MySqlCommand comm = new MySqlCommand(gtCountry, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countryId = reader["countryId"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error getting country Id: ", ex);
            }
            Disconnect();
            return countryId;
        }

        public static string GetaAddress(string address)
        {
            string addressId = "0";

            try
            {
                Connect();
                var gettAdress = "select addressId from address where address = '" + address + "';";
                MySqlCommand comm = new MySqlCommand(gettAdress, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        addressId = reader["addressId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error getting address Id: ", ex);
            }
            Disconnect();
            return addressId;
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

        public static void AddAddress(Address address)
        {
            string address1 = address.Address1;
            string address2 = address.Address2;
            int cityId = address.CityId;
            string postalCode = address.PostalCode;
            string phone = address.Phone;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.UserName;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adaAddress = " insert into address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + address1 + "','" + address2 + "','" + cityId + "','" + postalCode + "','" +phone + "', '" + createDate + "','" + createdBy + "', '" + lastUpdate + "','" + lastUpdateBy + "');";
                MySqlCommand comm = new MySqlCommand(adaAddress, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error adding the address: " + ex);
            }
            Disconnect();
        }

        public static void ActivityLogs(string username, string actResults)
        {
            DirectoryInfo rst = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string pth = rst + "\\log.txt";
            Console.WriteLine(pth);
            string logs = username + ":" + actResults + " : " + DateTime.Now.ToString();

            try
            {
                if (!File.Exists(pth))
                {
                    using (StreamWriter wrtr = File.CreateText(pth))
                    {
                        wrtr.WriteLine(logs);
                        wrtr.Close();
                    }
                }
                else
                {
                    using (StreamWriter wrtr = File.AppendText(pth))
                    {
                        wrtr.WriteLine(logs);
                        wrtr.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an issue writing logs: " + ex);
            }
            Disconnect();
                
        }

        public static void UpdateaAddress(Address address)
        {
            int addressId = address.AddressId;
            string address1 = address.Address1;
            string address2 = address.Address2;
            int cityId = address.CityId;
            string postalCode = address.PostalCode;
            string phone = address.Phone;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.UserName;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adaAddress = " update address set address = '" + address1 + "', address2 = '" + address2 + "', cityId = '" + cityId + "', postalCode= '" + postalCode + "' , phone = '" + phone + "' , lastUpdate = '" + lastUpdate + "', lastUpdateBy = '" + lastUpdateBy + "' where addressId = '" + addressId + "';";                          
                MySqlCommand comm = new MySqlCommand(adaAddress, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error updating the address: " + ex);
            }
            Disconnect();
        }

       
        public static string GettheCity(string city)
        {
            string cityId = "0";

            try
            {
                Connect();
                var gtCity = "select cityId from city where city = '" + city + "';" ;

                MySqlCommand comm = new MySqlCommand(gtCity, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cityId = reader["cityId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error getting the city ID: " + ex);
            }
            Disconnect();
            return cityId;
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
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue deleting customer: " + ex);
            }
            Disconnect();
        }

       

        public static void AddCity(City city)
        {
            string cityName = city.CityName;
            int countryId = city.CountryId;
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.UserName;
            string lastUpate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;

            try
            {
                Connect();
                var adaCity = " insert into city(city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) values('" + cityName + "','" + countryId + "', '" + createDate + "','" + createdBy + "', '" + lastUpate + "','" + lastUpdateBy + "');";
                MySqlCommand comm = new MySqlCommand(adaCity, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was n error adding a city: " + ex);
            }
            Disconnect();
        }
    }
}
