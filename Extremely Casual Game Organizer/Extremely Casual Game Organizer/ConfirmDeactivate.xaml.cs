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
    public partial class ConfirmDeactivate : Page
    {
        Member member = null;


        public ConfirmDeactivate(Member mem)
        {
            member = mem;
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            MemberManager memberManager = new MemberManager();
            int count = memberManager.EditUserToInactive(member.member_id);
            if(count == 1)
            {
                //Logout User here???
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Account was not deactivated");
            }
        }  
    }
}
