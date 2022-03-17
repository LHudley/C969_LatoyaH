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
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (textUsername.Text.Trim().Length < 1)
            {
                MessageBox.Show("Username is empty");
            }

            if (textPassword.Text.Trim().Length < 1)
            {
                MessageBox.Show("Password is empty");
            }

            DbApp.LoginCreds(username, password);

            this.Hide();

            Appointments appt = new Appointments();
            appt.ShowDialog();
            this.Close();
           

        }

      
        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }
    }
}
