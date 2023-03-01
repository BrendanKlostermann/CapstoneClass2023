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

namespace Extremely_Casual_Game_Organizer.Administrator
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>

    /// Code Contains necessary code for Admin_010 as well as UI Design elements for player profile.
    public partial class ResetPassword : Page
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        // WPF window styling
        // Can be edited or deleted
        // Goal is to round borders of profile picture
        public System.Windows.Media.Brush BorderBrush { get; set; }

        private void btnResetAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult =
            MessageBox.Show("Are you sure you want to reset this members password?",
                "Reset Password",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.Yes);

            if (dialogResult == MessageBoxResult.Yes)
            {

                MessageBox.Show("Member's password has been changed to default. " +
                    "Member will need to choose new password on next login.",
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
