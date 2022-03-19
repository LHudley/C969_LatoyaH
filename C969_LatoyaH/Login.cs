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
        string loginError;
        string loginSuccess;
        public Login()
        {
            InitializeComponent();
            findLanguage();
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
            lblHeader.Text = "Acme Scheduling";
            btnLogin.Text = "Login";
            loginError = "Incorrect Username or Password";
            loginSuccess = "Username and Password are successfull!";
        }

        private void frenchLogin()
        {

            labelUsername.Text = "Nom D' Utilisateur";
            labelPassword.Text = "Le Mot De Passe";
            lblHeader.Text = "Acme Planification";
            btnLogin.Text = "Connexion";
            btnClear.Text = "klir";
            loginError = "nom d'utilisateur et mot de passe incorrects";
            loginSuccess = "le nom d'utilisateur et le mot de passe sont reussis!";
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

            try
            {
                string sql = "server = localhost; port=3306; username = sqlUser; password=Passw0rd!; database = client_schedule";
                MySqlConnection con = new MySqlConnection(sql);
                MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from user where username= '"+textUsername.Text+"' and password='"+textPassword.Text+"'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString()== "1")
                {
                    MessageBox.Show(loginSuccess, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    Appointments appt = new Appointments();
                    appt.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(loginError, "alter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

      
        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }
    }
}
