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
        Member _member = null;
        public EditUserProfile(Member mem)
        {
            _member = mem;
            InitializeComponent();
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            var confirmDeactivation = new ConfirmDeactivate(_member);
            // Open page for confirm delete passing in member object and returning int.
            NavigationService.Navigate(new ConfirmDeactivate(_member));
        }
    }
}
