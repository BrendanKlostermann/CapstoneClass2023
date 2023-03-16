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
    /// This custom control remove a team to the tournament
    /// </summary>
    public partial class TeamRemove : UserControl
    {
        pgAddTeamToTournament _pgAddTeamToTournament;
        private int _teamID = 0;
        public TeamRemove()
        {
            InitializeComponent();
        }
        public TeamRemove(pgAddTeamToTournament pgAddTeamToTournament)
        {
            _pgAddTeamToTournament = pgAddTeamToTournament;
            InitializeComponent();
        }

        public int TeamId
        {
            get
            {
                return _teamID;
            }
            set
            {
                _teamID = value;
            }
        }

        // Call the remove method of _pgAddTeamToTournament
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_pgAddTeamToTournament != null)
            {
                _pgAddTeamToTournament.teamToRemove.Remove(TeamId);
                _pgAddTeamToTournament.removeTeamFromTournament(TeamId);
            }
        }
    }
}
