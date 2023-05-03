using DataObjects;
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

namespace Extremely_Casual_Game_Organizer.PageFiles.Tournaments
{
    /// <summary>
    /// Interaction logic for pgAddGame.xaml
    /// </summary>
    public partial class pgAddGame : Page
    {
        GameRosterManager grm = new GameRosterManager();
        TournamentManager tm = new TournamentManager();
        TeamManager teammanager = new TeamManager();
        MasterManager _masterManager = new MasterManager();
        PageControl _pageControl = new PageControl();
        int _tournamentID;

        public pgAddGame(int tournamentID)
        {
            InitializeComponent();
            DateTimer.Value = DateTime.Now;
            _tournamentID = tournamentID;

            List<TournamentTeam> _teamList = tm.GetTournamentTeamByID(tournamentID);
            List<string> teamNameList = new List<string>();
            foreach (TournamentTeam team in _teamList)
            {
                Team teamName = teammanager.RetrieveTeamByTeamID(team.TeamID);
                ComboBoxItem cmbItemTeam1 = new ComboBoxItem();
                cmbItemTeam1.Content = teamName.TeamName;
                cmbItemTeam1.DataContext = teamName.TeamID;
                cmbTeam1.Items.Add(cmbItemTeam1);

                ComboBoxItem cmbItemTeam2 = new ComboBoxItem();
                cmbItemTeam2.Content = teamName.TeamName;
                cmbItemTeam2.DataContext = teamName.TeamID;
                cmbTeam2.Items.Add(cmbItemTeam2);

            }


        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbTeam1.SelectedIndex == -1 || cmbTeam2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a team.");
                }
                else if (cmbTeam1.Text == cmbTeam2.Text)
                {
                    MessageBox.Show("Please select two different teams.");
                }
                else if (cmbTeam1.Text != cmbTeam2.Text)
                {
                    // Get Team ID's from selected indexes
                    int selectedTeam1 = (int)((ComboBoxItem)cmbTeam1.SelectedItem).DataContext;
                    int selectedTeam2 = (int)((ComboBoxItem)cmbTeam2.SelectedItem).DataContext;

                    // Get Team Members for Selected Teams
                    var team1Roster = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(selectedTeam1);
                    var team2Roster = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(selectedTeam2);

                    /* Game newGame = new Game()
                    {
                        VenueID = (int)((ComboBoxItem)cmbVenue.SelectedItem).DataContext,
                        DateAndTime = (DateTime)DateTimer.Value,
                        SportID = teammanager.RetrieveTeamByTeamID(selectedTeam1).SportID,
                    };

                    int createGame = _masterManager.GameManager.AddGame(newGame, _pageControl.GetSignedInMember().MemberID);


                    List<GameRoster> team1RosterList = new List<GameRoster>();
                    foreach (var member in team1Roster)
                    {
                        GameRoster addMember = new GameRoster();
                        addMember.MemberID = member.MemberID;
                        addMember.TeamID = member.TeamID;
                        addMember.GameID = createGame;
                        addMember.Description = member.Description;
                        team1RosterList.Add(addMember);
                    }

                    List<GameRoster> team2RosterList = new List<GameRoster>();
                    foreach (var member in team2Roster)
                    {
                        GameRoster addMember = new GameRoster();
                        addMember.MemberID = member.MemberID;
                        addMember.TeamID = member.TeamID;
                        addMember.GameID = createGame;
                        addMember.Description = member.Description;
                        team2RosterList.Add(addMember);
                    }

                    // Add to Game Roster table
                    if (team1RosterList.Count > 0 && team2RosterList.Count > 0)
                    {
                        _masterManager.GameRosterManager.AddGameRosterMembers(team1RosterList);
                        _masterManager.GameRosterManager.AddGameRosterMembers(team2RosterList);

                    } */

                    TournamentGenerateGames tgg = new TournamentGenerateGames
                    {
                        TournamentID = _tournamentID,
                        TeamID_1 = selectedTeam1,
                        TeamID_2 = selectedTeam2,
                        MemberID = _pageControl.GetSignedInMember().MemberID,
                        Content = "",
                        IsAGroup = false,
                        DateAndTime = (DateTime)DateTimer.Value
                    };
                    tm.InsertTournamentGame(tgg);
                }
                MessageBox.Show("Game has been added.");
                _pageControl.LoadPage(new pgViewTournament(_tournamentID));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
            
        }
    }
}
