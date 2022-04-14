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
        
       
        private void spanishLogin()
        {
           

            labelUsername.Text = "Nombre de usario";
            labelPassword.Text = "Contrasena";
            lblHeader.Text = " Acme Programadora";
            btnLogin.Text = "Iniciar Sesion";
            btnClear.Text = "Clara";
            
        }



       



        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            try
            {
                if (username == "" || password == "")
                {
                    
                    if (culture == "es")
                    {
                        throw new LGOutlier("Por favor ingrese un nombre de usuario valido");

                    }
                    throw new LGOutlier("Please enter a valid username");
                }

                //lambda to confirm username exist in database
                List<User> loginUser = users.Where(user => user.UserName == username).ToList();

                if (loginUser.Count < 1)
                {
                    if (culture == "es")
                    {
                        throw new LGOutlier("La usuario no existe");

                    }
                    throw new LGOutlier("User doesn't exist");
                }



                if (loginUser[0].Password != password)
                {
                    if (culture == "es")
                    {
                        throw new LGOutlier("Por favor introduce una contrasena valida");

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

        
        private void Login_Load(object sender, EventArgs e)
        {

            culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            users = DataContext.GetUsers();
            lblError.Text = "";
            if (culture == "es")
            {
                spanishLogin();
            }
        }
    }      
}
