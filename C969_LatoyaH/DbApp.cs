using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    class DbApp
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void LoginCreds(string username, string password)
        {
            

            try
            {
              
                string sqlLogin = "Select * from user where userName='"+username+"' AND password='"+password+"'";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sqlLogin, con);
                MySqlDataReader rd = cmd.ExecuteReader();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("MySql Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public static void AddUser(User user)
        //{
        //       // string sql = "Select exist (Select * from user where username='userName' AND password='password')";
        //    //string sql = "Insert into client-schedule values (Null, @userName)";
        //    //MySqlConnection con = GetConnection();
        //    //MySqlCommand cmd = new MySqlCommand(sql, con);
        //    //cmd.CommandType = CommandType.Text;
        //    //cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = user.UserName;


        //}
    }
}
