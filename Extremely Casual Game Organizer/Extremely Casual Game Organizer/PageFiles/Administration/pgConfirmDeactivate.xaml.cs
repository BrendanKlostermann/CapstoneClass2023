/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// This page is to confirm the deletion of a Members account.
/// 
/// .cs file attached to ConfirmDeactivate.
/// </summary>
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
        MasterManager _masterManager = null;

        public pgConfirmDeactivate(int mem, MasterManager masterManager)
        {
            _masterManager = masterManager;
            _member_id = mem;
            InitializeComponent();
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// This method will run the EditUserToInactive method from the MemberManager class
        /// in turn deactivating the members account.
        /// </summary>
        /// 
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = _masterManager.MemberManager.EditUserToInactive(_member_id);
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

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// If the user decided to select cancel on the confirmation screen it will close
        /// the page and not deactivate the members account.
        /// </summary>
        /// 
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
