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
    /// Interaction logic for EditUserProfile.xaml
    /// </summary>
    public partial class EditUserProfile : Page
    {
        int _member_id;
        public EditUserProfile(int mem) //using an int instead of member object until member is able to log in
        {
            _member_id = mem;
            InitializeComponent();
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            var confirmDeactivation = new pgConfirmDeactivate(_member_id);
            NavigationService.Navigate(confirmDeactivation);
        }
    }
}
