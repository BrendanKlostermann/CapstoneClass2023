using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Extremely_Casual_Game_Organizer.PageFiles;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// /// Garion Opiola
    /// Created: 2023/03/19
    /// Interaction logic for pgDeactivateTeam.xaml
    /// </summary>
    public partial class pgDeactivateTeam : Page
    {
        PageControl _pgControl = null;
        TeamManager _teamManager = null;
        private Member _member = null;

        public pgDeactivateTeam()
        {
            _teamManager = new TeamManager();
            _pgControl = new PageControl();
            _member = new Member();
            InitializeComponent();
        }

        private void datTeamList_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// /// Garion Opiola
            /// Created: 2023/03/19
            /// loads data to list
            /// </summary>
            try
            {
                loadTeamList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void loadTeamList()
        {
            /// <summary>
            /// /// Garion Opiola
            /// Created: 2023/03/19
            /// Loads team list for deactivation
            /// </summary>
            _member = _pgControl.GetSignedInMember();
            List<TeamMemberAndSport> _teamByMemberId = _teamManager.getTeamByMemberID(_member.MemberID);
            datTeamList.ItemsSource = _teamByMemberId;
            datTeamList.Columns[0].Visibility = Visibility.Hidden;
            datTeamList.Columns[1].Header = "Team Name";
            datTeamList.Columns[1].Width = 130;
            datTeamList.Columns[2].Width = 130;
            datTeamList.Columns[3].Width = 130;
            datTeamList.Columns[4].Visibility = Visibility.Hidden;
            datTeamList.Columns[5].Width = 130;
            datTeamList.Columns[5].Header = "Sport Name";
            datTeamList.Columns[6].Width = 130;
            datTeamList.Columns[7].Width = 125;
        }

        private void btnDeactivateTeam_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// /// Garion Opiola
            /// Created: 2023/03/19
            /// button logic to deactivate team
            /// </summary>
            if (datTeamList.SelectedItems.Count != 0)
            {
                TeamMemberAndSport selectedTeam = (TeamMemberAndSport)datTeamList.SelectedItem;
                Team removeTeam = new Team();
                removeTeam.TeamID = selectedTeam.TeamID;
                removeTeam.MemberID = _pgControl.GetSignedInMember().MemberID;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to deactivate this team?", "Deactivate Team", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _teamManager.RemoveOwnTeam(removeTeam.TeamID, removeTeam.MemberID);
                    loadTeamList();
                }
                else
                {
                    MessageBox.Show("An Error has ocuuered");
                    return;
                }
            }
            else
            {
                MessageBox.Show("You must select a Team");
                return;
            }
        }
    }
}

