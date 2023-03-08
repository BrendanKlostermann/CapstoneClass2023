///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Page for resetting user passwords
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
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
using LogicLayer;
using DataObjects;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    public partial class pgResetPassword : Page
    {
        MasterManager _masterManager = null;
        Member _member = null;
        string _currentPassword = "";
        bool _providedLogin = false;

        public pgResetPassword(MasterManager masterManager, Member member, string currentPW)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Called when user signs in for the first time. First time login should have provided login be true.
            /// </summary>
            _masterManager = masterManager;
            _member = member;
            _currentPassword = currentPW;
            _providedLogin = true;

            InitializeComponent();
        }
        
        public pgResetPassword(MasterManager masterManager)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Called when user just clicks on reset password without providing login info first. Provided Login should be false
            /// </summary>
            _masterManager = masterManager;
            _providedLogin = false;

            InitializeComponent();

        }

        private void pgResetPassword_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Page Loaded Event
            /// </summary>
            if (_providedLogin)
            {
                try
                {
                    // Load text box data if info is provided
                    txtEmail.Text = _member.Email.ToString();
                    txtCurrentPW.Password = _currentPassword.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Save click event and entry validation before password reset is processed.
            /// </summary>
            if (txtNewPW.Password == txtCurrentPW.Password)
            {
                MessageBox.Show("Current password and new password cannot be the same. \n\nPlease try again");
                txtConfirmPW.Password = "";
                txtNewPW.Password = "";
                txtNewPW.Focus();
                return;
            }
            else if (txtNewPW.Password != txtConfirmPW.Password)
            {
                MessageBox.Show("New password fields do not match. \n\nPlease try again");
                txtConfirmPW.Focus();
                txtNewPW.Focus();
                return;
            }
            else if (txtEmail.Text == "" || txtEmail.Text == null)
            {
                MessageBox.Show("Please provide a valid email");
                txtEmail.Focus();
                return;
            }
            else if (txtConfirmPW.Password == "" || txtConfirmPW.Password == null)
            {
                MessageBox.Show("You need to enter a confirm password");
                txtConfirmPW.Focus();
                return;
            }
            else if (txtCurrentPW.Password == "" || txtCurrentPW.Password == null)
            {
                MessageBox.Show("You must enter a current password");
                txtCurrentPW.Focus();
                return;
            }
            else if (txtNewPW.Password == "" || txtNewPW.Password == null)
            {
                MessageBox.Show("You must enter a new password");
                txtNewPW.Focus();
                return;
            }
            else
            {
                try
                {
                    _member = _masterManager.MemberManager.RetrieveMemberByEmail(txtEmail.Text);

                    if (_member.Email != txtEmail.Text)
                    {
                        MessageBox.Show("Invalid Email and Password Combination");
                        txtEmail.Focus();
                        txtCurrentPW.Password = "";
                        return;
                    }
                    else
                    {
                        bool result = _masterManager.MemberManager.EditMemberPassword(_member.MemberID, txtCurrentPW.Password, txtNewPW.Password);

                        if (result)
                        {
                            MessageBox.Show("Password Reset Successful!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Passord Reset Has Failed!");
                            return;
                        }
                    }
                }
                catch (ApplicationException)
                {
                    MessageBox.Show("Inavlid Email and Password Combination");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Cancel click event
            /// </summary>
            var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    this.NavigationService.GoBack();
                    break;
            }
        }
    }
}
