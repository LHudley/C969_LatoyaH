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

        private string lgLang;
        private List<User> users;
        public Login()
        {
            InitializeComponent();

        }


        
        private void Login_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo lgLang = new System.Globalization.CultureInfo("fr-FR");
            System.Threading.Thread.CurrentThread.CurrentCulture = lgLang;
           
             //lgLang = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
            users = DataContext.GetUsers();
            if (lgLang == "fr-FR") { frenchLogin(); }
        }

        private void frenchLogin()
        {

            labelUsername.Text = "Nom D' Utilisateur";
            labelPassword.Text = "Le Mot De Passe";
            lblHeader.Text = "Acme Planification";
            btnLogin.Text = "Connexion";
            btnClear.Text = "klir";
            //loginError = "nom d'utilisateur et mot de passe incorrects";
            // loginAttempt = "le nom d'utilisateur et le mot de passe sont reussis!";
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            try
            {
                if (username == "" || password == "")
                {
                    if (lgLang == "fre")
                    {
                        throw new LGOutlier("Veuillez entrer un nom d’utilisateur valide");

                    }
                    throw new LGOutlier("Please enter a valid username");
                }
                List<User> loginUser = users.Where(user => user.UserName == username).ToList();

                if (loginUser.Count < 1)
                {
                    if (lgLang == "fre")
                    {
                        throw new LGOutlier("L’utilisateur n’existe pas");

                    }
                    throw new LGOutlier("User doesn't exist");
                }



                if (loginUser[0].Password != password)
                {
                    if (lgLang == "fre")
                    {
                        throw new LGOutlier("Veuillez saisir un mot de passe valide");

                    }
                    throw new LGOutlier("Please enter a valid password");

                }
                ActivityLogss.lgActv(loginUser[0]);

                var mainfrm = new MainForm(loginUser[0]);
                mainfrm.Show();
                Hide();




            }
            catch (LGOutlier ex)
            {
                MessageBox.Show("Cant log in " + ex);

            }


        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }

    }      
}
