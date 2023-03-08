/// <summary>
/// Garion Opiola
/// Created: 2023/01/31
/// 
/// .cs file attached to pgTeamList.
/// 
/// This page will allow team members and coachs to view team list and roles.
/// 
/// </summary>
using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles;
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Made by Garion Opiola
    /// Date: 01/31/2023
    /// Interaction logic for pgTeamList.xaml
    /// </summary>
    public partial class pgTeamList : Page
    {
        private TeamRolesManager _teamRoleManager = new TeamRolesManager();
        private List<TeamRoles> _teamRole = null;

        public pgTeamList()
        {
            InitializeComponent();
        }

        private void frmTeamRoles_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Made by Garion Opiola
            /// Date: 01/31/2023
            /// Loads teamRoles list
            /// </summary>
            if (_teamRole == null)
            {
                try
                {
                    _teamRole = _teamRoleManager.RetrieveTeamRoles();
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
