using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            findLanguage();
        }

        private MySqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }


        private void findLanguage()
        {
            switch (CultureInfo.CurrentCulture.ThreeLetterISOLanguageName)
            {
                case "fre":
                    frenchLogin();
                    break;
                default:
                    englishLogin();
                    break;

            }
        }

        private void englishLogin()
        {
            labelUsername.Text = "Username";
            labelPassword.Text = "Password";
            btnLogin.Text = "Login";
        }

        private void frenchLogin()
        {

            labelUsername.Text = "Nom D' Utilisateur";
            labelPassword.Text = "Le Mot De Passe";
            btnLogin.Text = "Connexion";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textUsername.Text.Trim().Length < 1)
            {
                MessageBox.Show("Username is empty");
            }

            if (textPassword.Text.Trim().Length < 1)
            {
                MessageBox.Show("Password is empty");
            }
            DbApp.GetConnection();
            try
            {
                string sql = "Select exist (Select * from user where username='userName' AND password='password')";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                object textUsername = null;
                cmd.Parameters.AddWithValue("@userName", textUsername); ;
            }
            catch
            {

            }

        }

      
        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }
    }
}
