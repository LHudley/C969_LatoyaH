using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public static class DataContext
    {
        public const string connString = "server = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";       
        private static MySqlConnection mysqlcon = new MySqlConnection(connString);
        private static Dictionary<int, Hashtable> app = new Dictionary<int, Hashtable>();
        private static int userId;
        private static string userName;

        public static void Connect()
        {
            if (mysqlcon.State != System.Data.ConnectionState.Open)
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

        public static List<KeyValuePair<string, object>> apSearch(int id)
        {
            var list = new List<KeyValuePair<string, object>>();
            Connect();
            var query = $"select * from appointment where appointmentId = {id}";
            MySqlCommand comm = new MySqlCommand(query, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    list.Add(new KeyValuePair<string, object>("appointmentId", reader[0]));
                    list.Add(new KeyValuePair<string, object>("customerId", reader[1]));
                    list.Add(new KeyValuePair<string, object>("title", reader[3]));
                    list.Add(new KeyValuePair<string, object>("location", reader[5]));
                    list.Add(new KeyValuePair<string, object>("type", reader[7]));
                    list.Add(new KeyValuePair<string, object>("start", reader[9]));
                    list.Add(new KeyValuePair<string, object>("end", reader[10]));
                    reader.Close();

                }
                else
                {

                    MessageBox.Show("There was no appointment found");
                    return null;

                }
                return list;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("There was an error: " + ex);
                return null;
            }


        }

        public static int GetUserId()
        {
            return userId;
        }

        public static DataTable GetaUser()
        {
            DataTable usTble = new DataTable();
            if (!usTble.Columns.Contains("Id")) 
            { 
                usTble.Columns.Add("Id", typeof(string));
            }
            if (!usTble.Columns.Contains("UserName")) 
            {
                usTble.Columns.Add("UserName", typeof(string)); 
            }

            try
            {
                Connect();
                var getUsr = "select * from user;";
                MySqlCommand comm = new MySqlCommand(getUsr, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usTble.Rows.Add(reader["userId"], reader["userName"]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an issue getting a user: " + ex);
            }
            Disconnect();
            return usTble;


        }

        public static string tzConv(string dateTime)
        {
            DateTime utcDtTm = DateTime.Parse(dateTime.ToString());
            DateTime localDtTm = utcDtTm.ToLocalTime();
            return localDtTm.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void SetApp(Dictionary<int, Hashtable> appts)
        {
            app = appts;
        }

        public static DataTable GtAptDy(int userId)
        {
            DataTable apptTbl = new DataTable();

            if (!apptTbl.Columns.Contains("Id"))
            {
                apptTbl.Columns.Add("Id", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Title"))
            {
                apptTbl.Columns.Add("Title", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Customer"))
            {
                apptTbl.Columns.Add("Customer", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Type"))
            {
                apptTbl.Columns.Add("Type", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Start"))
            {
                apptTbl.Columns.Add("Start", typeof(string));
            }
            if (!apptTbl.Columns.Contains("End"))
            {
                apptTbl.Columns.Add("End", typeof(string));
            }


            try
            {
                Connect();
                var getApptt = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId ='" + userId + "' and date(start) = utc_date()";
                MySqlCommand comm = new MySqlCommand(getApptt, mysqlcon);
                Console.WriteLine(comm.CommandText);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        apptTbl.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime(), Convert.ToDateTime(reader["end"]).ToLocalTime());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue getting appointments: " + ex);
            }
            Disconnect();
            return apptTbl;
        }

        public static DataTable GtAptByWk(int userId)
        {
            DataTable apptTbl = new DataTable();
           
            if (!apptTbl.Columns.Contains("Id"))
            {
                apptTbl.Columns.Add("Id", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Title"))
            {
                apptTbl.Columns.Add("Title", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Customer"))
            {
                apptTbl.Columns.Add("Customer", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Type"))
            {
                apptTbl.Columns.Add("Type", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Start"))
            {
                apptTbl.Columns.Add("Start", typeof(string));
            }
            if (!apptTbl.Columns.Contains("End"))
            {
                apptTbl.Columns.Add("End", typeof(string));
            }


            try
            {
                Connect();
                var getApptt = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId ='" + userId + "' and yearweek(start) = yearweek(current_date)";
                MySqlCommand comm = new MySqlCommand(getApptt, mysqlcon);
                Console.WriteLine(comm.CommandText);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        apptTbl.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime(), Convert.ToDateTime(reader["end"]).ToLocalTime());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue getting weekly appointments: " + ex);
            }
            Disconnect();
            return apptTbl;
        }

        public static DataTable GtAptByMth(int userId)
        {
            DataTable apptTbl = new DataTable();
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (!apptTbl.Columns.Contains("Id"))
            {
                apptTbl.Columns.Add("Id", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Title"))
            {
                apptTbl.Columns.Add("Title", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Customer"))
            {
                apptTbl.Columns.Add("Customer", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Type"))
            {
                apptTbl.Columns.Add("Type", typeof(string));
            }
            if (!apptTbl.Columns.Contains("Start"))
            {
                apptTbl.Columns.Add("Start", typeof(string));
            }
            if (!apptTbl.Columns.Contains("End"))
            {
                apptTbl.Columns.Add("End", typeof(string));
            }


            try
            {
                Connect();
                var getApptt = "select appointment.appointmentId, appointment.title, customer.customerName, appointment.type, appointment.start, appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userId + "' and month(start) = " + month + " and year(start) = '"+year+";" ;
                MySqlCommand comm = new MySqlCommand(getApptt, mysqlcon);
                Console.WriteLine(comm.CommandText);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        apptTbl.Rows.Add(reader["appointmentId"], reader["title"], reader["customerName"], reader["type"], Convert.ToDateTime(reader["start"]).ToLocalTime(), Convert.ToDateTime(reader["end"]).ToLocalTime());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an issue getting monthly appointments: " + ex);
            }
            Disconnect();
            return apptTbl;

        }

        public static bool AlertAferFifteenMin(int userId)
        {
            try
            {
                Connect();
                var getAptt = "select appointment.appointmentId,appointment.title,appointment.type, customer.customerName,appointment.start,appointment.end from appointment join customer on appointment.customerId = customer.customerId where userId = '" + userId + "' and start between utc_timestamp() and (utc_timestamp()+ interval 15 minute);";
                MySqlCommand comm = new MySqlCommand(getAptt, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows) { reader.Close();return true; }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error geting alert for fifteen minute appointments: " + ex);
            }
            Disconnect();
            return false;
        }

        public static List<string> GetMonthlyAppt(int userId, int month)
        {
            List<string> apptTpLst = new List<string>();
            try
            {
                Connect();
                var gettAptTyp = "select type, count(type) from appointment where userId = '" + userId + "' and month(start) = '" + month + "';";
                MySqlCommand comm = new MySqlCommand(gettAptTyp, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    string typeCt = reader["type"].ToString() + ":" + reader["count(type)"].ToString();
                    apptTpLst.Add(typeCt);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error gettig an output monthly appointment" + ex);
            }
            Disconnect();
            return apptTpLst;
        }

        public static bool ApptOverlapping(int userId, DateTime start, DateTime end)
        {
            string stTm = start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string edTm = end.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");

            try
            {
                Connect();
                var getAptt = "select appointment.appointmentId,appointment.title,appointment.type, customer.customerName,appointment.start,appointment.end from appointment join customer on appointment.customerId = customer.customerId where start <= '" + edTm + "' and end >= '"+stTm+ "' and userId = '"+userId+"';";
                MySqlCommand comm = new MySqlCommand(getAptt, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows) { reader.Close(); return true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue, please check overlapping appointments: " + ex);
            }
            Disconnect();
            return false;
        }

        public static List<string> GetApptCtCustomer()
        {
            List<string> apptCustLst = new List<string>();
            try
            {
                Connect();
                var gettAptCust = "select customer.customerName as customer, count(appointment.appointmentId) as count from appointment join customer on appointment.customerId = customer.customerId group by customer.customerName;";
                MySqlCommand comm = new MySqlCommand(gettAptCust, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    string customer = reader["customer"].ToString() + ":" + reader["count"].ToString();
                    apptCustLst.Add(customer);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error gettig an appointment" + ex);
            }
            Disconnect();
            return apptCustLst;
        }

        public static void GetaAppointment(Appointment appt)
        {
            int customerId = appt.CustomerId;
            int userId = User.UserId;
            string title = appt.Title;
            string description = appt.Description;
            string location = appt.Location;
            string contact = appt.Contact;
            string type = appt.Type;
            string url = appt.Url;
            string start = appt.Start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string end = appt.End.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createDate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string createdBy = User.UserName;
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;
            try
            {
                var adAppts = "insert into appointment(customerId, userId, title, description, location, contact, type, url, start,end,createDate,createdBy,lastUpdate,lastUpdateBy) values('" + customerId + "','" + userId + "', '" + title + "','" + description + "','" + location + "','" + contact + "','" + type + "','" + url + "','" + start + "','" + end + "','" + createDate + "','" + createdBy + "','" + lastUpdate + "','" + lastUpdateBy + "');";
                MySqlCommand comm = new MySqlCommand(adAppts, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue adding appointment: " + ex);
            }
            Disconnect();
        }

        public static List<Appointment> GetUserAppt(int userId)
        {
            List<Appointment> aptss = new List<Appointment>();
            try
            {

                Connect();
                var gettAptTyp = "select title, start, end from appointment where userId = '" + userId + "';";
                MySqlCommand comm = new MySqlCommand(gettAptTyp, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    aptss.Add(new Appointment()
                    {

                        Title = reader["title"].ToString(),
                        Start = Convert.ToDateTime(reader["start"]).ToLocalTime(),
                        End = Convert.ToDateTime(reader["end"]).ToLocalTime()
                    });
                   
                   
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("There was an error gettig a user appointment" + ex);
            }
            Disconnect();
            return aptss;
        }

        public static string GetaUserId(string userName)
        {
            string userId = "0";

            try
            {
                Connect();
                var gttUser = "select userId from user where userName = '" + userName + "';";
                MySqlCommand comm = new MySqlCommand(gttUser, mysqlcon);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userId = reader["userId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error getting user Id: ", ex);
            }
            Disconnect();
            return userId;
        }

        public static string GetaCustomer(string name)
        {
            string customerId = null;

            try
            {
                Connect();
                var customerSelection = "Select customerId from customer where customerName = '" + name + "';";

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

        public static void EditaAppointment(Appointment appt)
        {
            int appointmentId = appt.AppointmentId;
            int customerId = appt.CustomerId;
            int userId = User.UserId;
            string title = appt.Title;
            string description = appt.Description;
            string location = appt.Location;
            string contact = appt.Contact;
            string type = appt.Type;
            string url = appt.Url;
            string start = appt.Start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string end = appt.End.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdate = DateTime.Now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss");
            string lastUpdateBy = User.UserName;
            try
            {
                var updateaptt = "update appointment set customerId = '" + customerId + "',userId = '" + userId + "',title ='" + title + "',description = '" + description + "',location = '" + location + "',contact = '" + contact + "',type = '" + type + "',url = '" + url + "',start = '" + start + "',end = '" + end + "',lastUpdate = '" + lastUpdate + "',lastUpdateBy = '" + lastUpdateBy + "' where appointmentId ='" + appointmentId + "';"; 
                MySqlCommand comm = new MySqlCommand(updateaptt, mysqlcon);
                Console.WriteLine(comm.CommandText);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue adding appointment: " + ex);
            }
            Disconnect();
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

        public static void DeleteAppt(IDictionary<string, object> dictionary)
        {
            try
            {
                Connect();
                var dlAppt = $"delete from appointment where apointmentId = '{ dictionary["appointmentId"]}'";
                MySqlCommand comm = new MySqlCommand(dlAppt, mysqlcon);
                MySqlTransaction trans = mysqlcon.BeginTransaction();
                comm.CommandText = dlAppt;
                comm.Connection = mysqlcon;
                comm.Transaction= trans;
                comm.ExecuteNonQuery();
                trans.Commit();
                mysqlcon.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an issue deleting appointment: " + ex);
            }
            Disconnect();
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
