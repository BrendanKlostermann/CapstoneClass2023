    /// <summary>
    /// Brendan Klostermann
    /// Created: 2023/02/06
    /// 
    /// Code for the User Details page.
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class pgUserDetails : Page
    {
        int _member_id;
        public pgUserDetails(int mem) //using int instead of member object until admins can log in and manager members
        {
            _member_id = mem;
            InitializeComponent();
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// when the Delete button is selected it will bring up the page to confirm the 
        /// deactivation of the members account.
        /// 
        /// </summary>
        /// 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var confirmDeactivation = new pgConfirmDeactivate(_member_id, new MasterManager());
            NavigationService.Navigate(confirmDeactivation);
        }
    }
}
