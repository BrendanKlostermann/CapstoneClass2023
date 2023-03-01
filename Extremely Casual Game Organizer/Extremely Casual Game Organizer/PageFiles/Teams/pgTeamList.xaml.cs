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
using System.Windows.Shapes;
using LogicLayer;
using DataObjects;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for TeamList.xaml
    /// </summary>
    public partial class pgTeamList : Window
    {
        private List<TeamRoles> _teamRole = null;
        MasterManager _masterManager = null;

        public pgTeamList(MasterManager masterManager)
        {
            _masterManager = masterManager;
            InitializeComponent();
        }

        private void navLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //_member = null;
                //updateUIforLogout();
                _masterManager = new MasterManager();
                var teamList = new pgTeamList(_masterManager);
                teamList.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        //private void updateUIforLogout()
        //{
        //    tabTeamRoles.Visibility = Visibility.Hidden;
        //}

        private void frmTeamList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tabTeamRoles_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_teamRole == null)
            {
                try
                {
                    _teamRole = _masterManager.TeamRolesManager.RetrieveTeamRoles();
                    datRoles.ItemsSource = _teamRole;
                    datRoles.Columns[0].Header = "Player ID";
                    datRoles.Columns[1].Header = "Team Id";
                    datRoles.Columns[2].Header = "Position";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

    }
}
