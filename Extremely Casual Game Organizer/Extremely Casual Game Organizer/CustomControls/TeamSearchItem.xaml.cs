using Extremely_Casual_Game_Organizer.PageFiles;
using Extremely_Casual_Game_Organizer.PageFiles.Teams.Utility;
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

namespace Extremely_Casual_Game_Organizer.CustomControls
{
    /// <summary>
    /// Interaction logic for TeamSearchItem.xaml
    /// </summary>
    public partial class TeamSearchItem : UserControl
    {
        private DataObjects.TeamSport _teamSport;
        private MasterManager _masterManager;
        PageControl _pageControl = null;

        public TeamSearchItem()
        {
            InitializeComponent();
        }
        public TeamSearchItem(DataObjects.TeamSport line, MasterManager masterManager)
        {
            _pageControl = new PageControl();
            InitializeComponent();
            _teamSport = line;
            this._masterManager = masterManager;
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            winTeamSearch teamSearch = new winTeamSearch(_masterManager);
            teamSearch.ReturnSelectedTeam(_teamSport.TeamID);
        }
    }
}
