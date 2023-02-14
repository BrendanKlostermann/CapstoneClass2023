/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// .cs file attached to ConfirmDeactivate.
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
/// 
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
using LogicLayer;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for ConfirmDeactivate.xaml
    /// </summary>
    public partial class pgConfirmDeactivate : Page
    {
        int _member_id;


        public pgConfirmDeactivate(int mem)
        {
            _member_id = mem;
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberManager memberManager = new MemberManager();
                int count = memberManager.EditUserToInactive(_member_id);
                if (count == 1)
                {
                    MessageBox.Show("Account is deactivated");
                    //Logout User here???
                    this.NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Account was not deactivated");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("An error occured" + "\n\n" + ex.InnerException.Message);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
