/// <summary>
/// Anthoney Hale
/// Created: 2023/02/10
/// page for login
/// </summary>
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataObjects;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgLogIn.xaml
    /// 
    /// </summary>
    public partial class pgLogIn : Page
    {
        private Member _member = null;
        public pgLogIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// update UI info 
        /// </summary>
        private void updateUIforMember()
        {
            string rolesList = "";

            for (int i = 0; i < _member.Roles.Count; i++)
            {
                rolesList += " " + _member.Roles[i];
                if (i == _member.Roles.Count - 2)
                {
                    if (_member.Roles.Count > 2)
                    {
                        rolesList += ",";
                    }
                    rolesList += " and ";
                }
                else if (i < _member.Roles.Count - 2)
                {
                    rolesList += ",";
                }
            }

        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// update UI for logging out
        /// </summary>
        private void updateUIforLogOut()
        {
            txtEmail.Focus();

            txtEmail.Text = "";
            txtPassword.Password = "";
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;

            txtEmail.Focus();
        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/02/10
        /// button for logging in
        /// </summary>
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnSignIn.Content == "Log Out")
            {
                _member = null;
                btnSignIn.Content = "Login";
                updateUIforLogOut();
                return;
            }



            var email = txtEmail.Text;
            var password = txtPassword.Password;

            if (email.Length < 6)
            {
                MessageBox.Show("Please enter your email address");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("Please enter password");
                txtPassword.Password = "";
                txtPassword.Focus();
                return;
            }

            var memberManager = new MemberManager();


            try
            {
                _member = memberManager.LoginMember(email, password);
                MessageBox.Show("Hello, " + _member.FirstName + "\n\n" +
                    "You are logged in");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
