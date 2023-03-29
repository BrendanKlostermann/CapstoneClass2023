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

namespace Extremely_Casual_Game_Organizer.CustomControls
{
    /// <summary>
    /// Heritier Otiom
    /// 03/01/2023
    /// 
    /// this custom control created to assign TeamSport objects to its labels
    /// </summary>
    public partial class TeamSport : UserControl
    {
        private DataObjects.TeamSport teamSport;
        private MasterManager masterManager;
        PageControl _pageControl = null;

        public TeamSport()
        {
            InitializeComponent();
        }

        public TeamSport(DataObjects.TeamSport line, MasterManager masterManager)
        {
            _pageControl = new PageControl();
            InitializeComponent();
            teamSport = line;
            this.masterManager = masterManager;
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgTeamMemberScreen(teamSport.TeamID, masterManager), _pageControl.GetCurrentPage());
        }
    }
}
