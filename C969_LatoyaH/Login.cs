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
       
        private string culture;
        private List<User> users;
        
        public Login()
        {
            InitializeComponent();
          
           
        }
        private void Login_Load_1(object sender, EventArgs e)
        {

            culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            users = DataContext.GetUsers();
            lblError.Text = "";
            if (culture == "fr-FR")
            {
                frenchLogin();
            }
        }
        private void frenchLogin()
        {
           

            labelUsername.Text = "Nom D' Utilisateur";
            labelPassword.Text = "Le Mot De Passe";
            lblHeader.Text = "Acme Planification";
            btnLogin.Text = "Connexion";
            btnClear.Text = "klir";
            
        }



       



        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            try
            {
                if (username == "" || password == "")
                {
                    
                    if (culture == "fr-FR")
                    {
                        throw new LGOutlier("Veuillez entrer un nom d’utilisateur valide");

                    }
                    throw new LGOutlier("Please enter a valid username");
                }

                //lambda to confirm username exist in database
                List<User> loginUser = users.Where(user => user.UserName == username).ToList();

                if (loginUser.Count < 1)
                {
                    if (culture == "fr-FR")
                    {
                        throw new LGOutlier("L’utilisateur n’existe pas");

                    }
                    throw new LGOutlier("User doesn't exist");
                }



                if (loginUser[0].Password != password)
                {
                    if (culture == "fr-FR")
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
            catch (LGOutlier error)
            {
                lblError.Text = error.Message;

            }


        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }

       
    }      
}
