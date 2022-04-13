using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public static class DataContext
    {
        public const string connString = "server = 127.0.0.1; port=3306; username = root; password=Passw0rd!; database = client_schedule";
        private static MySqlConnection mysqlcon = new MySqlConnection(connString);
       

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



        public static void GetaAppointment()
        {
            string qy = $"select * from appointment where userId= {MainForm.LgdUsr.UserId}";
            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int appointmentId = Convert.ToInt32(reader[0]);
                int customerId = Convert.ToInt32(reader[1]);
                int userId = Convert.ToInt32(reader[2]); ;
                
                string type = reader[7].ToString();
                DateTime start = Convert.ToDateTime(reader[9]).ToLocalTime();
                DateTime end = Convert.ToDateTime(reader[10]).ToLocalTime();
                DateTime createDate = Convert.ToDateTime(reader[11]).ToLocalTime();

                string createdBy = reader[12].ToString();
                DateTime lastUpdate = Convert.ToDateTime(reader[13]).ToLocalTime();

                string lastUpdateBy = reader[14].ToString();
                

                MainForm.ApptLt.Add(new Appointment(appointmentId, customerId, userId, type, start, end,createDate, createdBy,lastUpdate, lastUpdateBy));
            }
            Disconnect();

        }

        public static void GettheCountry()
        {

            string qy = "select * from country";
            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int countryId = Convert.ToInt32(reader[0]);

                string country = reader[1].ToString();



                DateTime createDate = Convert.ToDateTime(reader[2]).ToLocalTime();
                string createdBy = reader[3].ToString();

                DateTime lastUpdate = Convert.ToDateTime(reader[4]).ToLocalTime();
                string lastUpdateBy = reader[5].ToString();





                MainForm.countryDict.Add(countryId, new Country(countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            Disconnect();
        }

        public static void GettheCity()
        {
            string qy = "select * from city";
            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cityId = Convert.ToInt32(reader[0]);

                string city = reader[1].ToString();
                int countryId = Convert.ToInt32(reader[2]); ;

                

                DateTime createDate = Convert.ToDateTime(reader[3]).ToLocalTime();
                string createdBy = reader[4].ToString();

                DateTime lastUpdate = Convert.ToDateTime(reader[5]).ToLocalTime();
                string lastUpdateBy = reader[6].ToString();





                MainForm.cityDict.Add(cityId, new City(cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            Disconnect();
        }

       

        public static void GetaAddress()
        {
            string qy = $"select * from address";
            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int addressId = Convert.ToInt32(reader[0]);
                
                string address1 = reader[1].ToString();
                string address2 = reader[2].ToString();
                int cityId = Convert.ToInt32(reader[3]); ;

                string postalCode = reader[4].ToString();
                string phone = reader[5].ToString();
               
                DateTime createDate = Convert.ToDateTime(reader[6]).ToLocalTime();
                string createdBy = reader[7].ToString();

                DateTime lastUpdate = Convert.ToDateTime(reader[8]).ToLocalTime();
                string lastUpdateBy = reader[9].ToString();



              

                MainForm.addDict.Add(addressId, new Address(addressId, address1, address2, cityId, postalCode,phone, createDate, createdBy,lastUpdate, lastUpdateBy));
            }
            Disconnect();
        }

        public static void GetCustomers()
        {
            string qy = "select * from customer";
            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int customerId = Convert.ToInt32(reader[0]);
                
                string customerName = reader[1].ToString();
                int addressId = Convert.ToInt32(reader[2]);
                int active = Convert.ToInt32(reader[3]);
                DateTime createDate = Convert.ToDateTime(reader[4]).ToLocalTime();
                string createdBy = reader[5].ToString();
                DateTime lastUpdate = Convert.ToDateTime(reader[6]).ToLocalTime();
                string lastUpdateBy = reader[7].ToString();

                MainForm.CustLt.Add(new Customer(customerId, customerName, addressId,  active,  createDate, createdBy, lastUpdate,
             lastUpdateBy));
            }
            Disconnect();
        }

        public static List<User> GetUsers()
        {
            List<User> userLst = new List<User>();
            string qy = "select * from user";

            Connect();
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader[0]);
                string userName = reader[1].ToString();
                string password = reader[2].ToString();
                int active = Convert.ToInt32(reader[3]);
                DateTime createDate = Convert.ToDateTime(reader[4]).ToLocalTime();
                string createdBy = reader[5].ToString();
                DateTime lastUpdate = Convert.ToDateTime(reader[6]).ToLocalTime();
                string lastUpdateBy = reader[7].ToString();
                userLst.Add(new User(userId, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            Disconnect();
            return userLst;


        }

        public static int AddAddress(string address1, string address2, int cityId,string postalCode, string phone, string userName)
        {
            DateTime now = DateTime.Now;
            var adaaddmt = new Address(address1, address2, cityId, postalCode, phone, now,userName,  now, userName);
            Connect();
            string qy = $"insert into address values ({adaaddmt.AddressId}, '{adaaddmt.Address1}', '{adaaddmt.Address2}',{adaaddmt.CityId}, '{adaaddmt.PostalCode}','{adaaddmt.Phone}' , '{adaaddmt.CreateDate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}','{adaaddmt.CreatedBy}','{adaaddmt.LastUpdate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}',  '{adaaddmt.LastUpdateBy}')";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();

            MainForm.addDict.Add(adaaddmt.AddressId, adaaddmt);
            return adaaddmt.AddressId;
        }
        public static void UpdateaAddress(Address address, string address1, string address2,int cityId,string postalCode,string phone, string user )
        {
            DateTime now = DateTime.Now;
            string nwStg = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            Connect();
            string qy = $"update address set address ='{address1}', address2 = '{address2}',cityId = {cityId}, postalCode ='{postalCode}',phone = '{phone}',lastUpdate = '{nwStg}',lastUpdateBy = '{user}' where addressId = {address.AddressId};";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();
            MainForm.addDict[address.AddressId] = new Address(address.AddressId, address1, address2, cityId, postalCode, phone, address.CreateDate, address.CreatedBy,now,user);
        }

        public static void DeleteAppt(Appointment selAppt)
        {
            Connect();
            string qy = $"delete from appointment where appointmentId = {selAppt.AppointmentId};";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();
            MainForm.ApptLt.Remove(selAppt);
        }

        public static void EditaAppointment(Appointment appointment, int customerId, string type, DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            string nwStg = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            Connect();
            string qy = $"update appointment set customerId ={customerId}, userId ={MainForm.LgdUsr.UserId}, type ='{type}', start ='{start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', end ='{end.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdate = '{nwStg}', lastUpdateBy ='{MainForm.LgdUsr.UserName}' where appointmentId ={appointment.AppointmentId}; ";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();

            Appointment updtAppt = new Appointment(appointment.AppointmentId, customerId, MainForm.LgdUsr.UserId, type, start,end, appointment.CreateDate,appointment.CreatedBy,  now, MainForm.LgdUsr.UserName);
            int idxAppt = MainForm.ApptLt.IndexOf(appointment);
            MainForm.ApptLt.RemoveAt(idxAppt);
            MainForm.ApptLt.Insert(idxAppt, updtAppt);

           
        }

        public static void UpdateaCustomer(Customer customer, string customerName, string user)
        {
            DateTime now = DateTime.Now;
            string nwStg = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            Connect();
            string qy = $"update customer set customerName = '{customerName}', lastUpdate ='{nwStg}',lastUpdateBy = '{user}' where customerId = {customer.CustomerId}; ";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();

            Customer updtCust = new Customer(customer.CustomerId, customerName, customer.AddressId, customer.Active, customer.CreateDate,  customer.CreatedBy,now,user);
            int idxCust = MainForm.CustLt.IndexOf(customer);
            MainForm.CustLt.RemoveAt(idxCust);
            MainForm.CustLt.Insert(idxCust, updtCust);
        }

        public static void AddanAppointment(int customerId,string type, DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            var adapptmt = new Appointment(customerId, MainForm.LgdUsr.UserId, type, start, end, now, MainForm.LgdUsr.UserName, now, MainForm.LgdUsr.UserName);
            Connect();
            string qy = $"INSERT INTO appointment VALUES ({adapptmt.AppointmentId}, {adapptmt.CustomerId}, {adapptmt.UserId},'not needed','not needed', 'not needed', 'not needed', '{adapptmt.Type}', 'not needed', '{adapptmt.Start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adapptmt.End.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adapptmt.CreateDate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adapptmt.CreatedBy}', '{adapptmt.LastUpdate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adapptmt.LastUpdateBy}')";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();

            MainForm.ApptLt.Add(adapptmt);
           
        }

        public static void DeleteaCustomer(Customer customer)
        {
            
            Connect();
            string deleteCust = $"delete from customer where customerId = {customer.CustomerId};";
            MySqlCommand comm = new MySqlCommand(deleteCust, mysqlcon);
            Console.WriteLine(comm.CommandText);
            comm.ExecuteNonQuery();
            MainForm.CustLt.Remove(customer);
            deletedAddress(customer.AddressId);
            
            
        }

        private static void deletedAddress(int addressId)
        {
            Connect();
            string qy = $"delete from address where addressId= {addressId};";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();
            MainForm.addDict.Remove(addressId);


        }
        public static int AddaCustomer(string customerName, int addressId, string user)
        {
            DateTime now = DateTime.Now;
            var adCustomer = new Customer(customerName, addressId, 1, now, user, now, user);

            Connect();
            string qy = $"insert into customer values({adCustomer.CustomerId}, '{adCustomer.CustomerName}', {adCustomer.AddressId}, {adCustomer.Active}, '{adCustomer.CreateDate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adCustomer.CreatedBy}', '{adCustomer.LastUpdate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{adCustomer.LastUpdateBy}')";
            MySqlCommand comm = new MySqlCommand(qy, mysqlcon);
            comm.ExecuteNonQuery();
            Disconnect();
            MainForm.CustLt.Add(adCustomer);
            return adCustomer.CustomerId;


            
           

        }
    }
}


