/// <summary>
/// Heritier Otiom
/// Created: 02/18/2023
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
    /// Interaction logic for pgGenerateTournamentGame.xaml
    /// </summary>
    public partial class pgGenerateTournamentGame : Page
    {
        TeamManager _teamManager = null;
        TournamentManager _tournamentManager = null;
        private int _memberID = 100000;


        //I created this variable to store the sport ID
        private int _sport_id;

        // Variable to store the tournament ID
        private int _tournament_id;

        // This variable List store the teamID of team that I aer already in the tournament
        private List<int> teamsOfTheTournament = new List<int>();
        private List<TeamSport> teamsToGenerate = new List<TeamSport>();
        private List<int> teamAdded = new List<int>();

        //This variable List store the all tournaments
        private List<Tournament> tournaments = null;

        //This variable List store the team of tournament
        private List<TournamentTeam> tournamentTeams = null;
        private List<TournamentTeamGame> tournamentTeamGame = null;

        //This variable List store all teams
        List<TeamSport> _teams = null;
        private MasterManager masterManager;
        PageControl _pageControl = null;

        public pgGenerateTournamentGame()
        {
            _teamManager = new TeamManager();
            _tournamentManager = new TournamentManager();
            List<Tournament> tournaments = new List<Tournament>();

            _pageControl = new PageControl();

            _sport_id = 0;
            _teams = new List<TeamSport>();
            InitializeComponent();
            getTeam();
            getTournament();
        }

        public pgGenerateTournamentGame(MasterManager masterManager)
        {
            this.masterManager = masterManager;
            _teamManager = new TeamManager();
            _tournamentManager = new TournamentManager();
            List<Tournament> tournaments = new List<Tournament>();

            _pageControl = new PageControl();

            _sport_id = 0;
            _teams = new List<TeamSport>();
            InitializeComponent();
            getTeam();
            getTournament();
        }

        //Get all teams
        private void getTeam()
        {
            try
            {
                _teams = _teamManager.getTeamByTeamName("", _sport_id);
                // Remove all items from the list of team
                lbTeam.Items.Clear();

                // If there's a team
                if (_teams.Count > 0)
                {
                    refresh();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot read team! " + e.Message);
            }
        }

        // Refresh the listboxes after each communication with the database
        public void refresh()
        {
            // Clear the listboxes
            lbTeam.Items.Clear();

            foreach (TeamSport line in _teams)
            {
                if (teamsOfTheTournament.Count > 0)
                {
                    var item = teamsOfTheTournament.Find(id => id == line.TeamID);
                    if (item != 0)
                    {
                        PopulateTeamCustomControl(line);
                    }
                }
            }
        }

        // I created two custom controls
        // One to add a team from tournament : TeamAdd
        // the other one to remove a team from tournament: TeamRemove
        // Both located in the "CustomControls" folder
        private void PopulateTeamCustomControl(TeamSport line)
        {
            //if the team is already added to the tournament
            var team = new CustomControls.Team();
            team.lblName.Content = line.Name;
            // Add result to the listbox
            lbTeam.Items.Add(team);
        }

        //Get team according to the tournament selected
        private void ddTournament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _sport_id = 0;
            _tournament_id = 0;
            int memberID = 0;
            Member _member = _pageControl.GetSignedInMember();

            foreach (Tournament line in tournaments)
            {
                if (line.Name == ddTournament.SelectedItem.ToString())
                {
                    _sport_id = line.SportID;
                    _tournament_id = line.TournamentID;
                    memberID = line.MemberID;
                }
            }
            if (_member != null)
            {
                if (_member.MemberID == memberID)
                {
                    btnDeleteAllGames.Visibility = Visibility.Visible;
                    btnGenerate.Visibility = Visibility.Visible;
                    btnSave.Visibility = Visibility.Visible;
                    btnOpenTournamentPage.Visibility = Visibility.Visible;
                }
                else
                {
                    btnDeleteAllGames.Visibility = Visibility.Hidden;
                    btnGenerate.Visibility = Visibility.Hidden;
                    btnSave.Visibility = Visibility.Hidden;
                    btnOpenTournamentPage.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                btnDeleteAllGames.Visibility = Visibility.Hidden;
                btnGenerate.Visibility = Visibility.Hidden;
                btnSave.Visibility = Visibility.Hidden;
                btnOpenTournamentPage.Visibility = Visibility.Hidden;
            }

            getTournamentTeam();
            getTournamentGames();
        }

        private void getTournamentGames()
        {

            try
            {
                tournamentTeamGame = _tournamentManager.SelectTournamentTeamAndGame(_tournament_id);
                foreach (TournamentTeamGame line in tournamentTeamGame)
                {
                    //MessageBox.Show("gameID = " + line.GameID+ " --- teamID = " + line.TeamID);
                    saveTeam(line.TeamID);
                    //teamsOfTheTournament.Add(line.TeamID);
                }
                generateGames();
                //getTeamGame();
            }
            catch (Exception)
            {
                MessageBox.Show("This tournament has no game!");
            }
        }

        // Get all teams by tournament_id
        private void getTournamentTeam()
        {
            lbTournament.Items.Clear();
            teamsToGenerate.Clear();
            teamsOfTheTournament.Clear();

            try
            {
                tournamentTeams = _tournamentManager.GetTournamentTeamByID(_tournament_id);

                foreach (TournamentTeam line in tournamentTeams)
                {
                    teamsOfTheTournament.Add(line.TeamID);
                }
                getTeam();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read tournament team!");
            }

            lblNbreOfTeam.Content = "Number of Teams: " + teamsOfTheTournament.Count;
        }

        // Get all tournaments
        private void getTournament()
        {
            ddTournament.Items.Clear();
            try
            {
                tournaments = _tournamentManager.GetTournaments();
                ddTournament.Items.Add("");

                foreach (Tournament line in tournaments)
                {
                    ddTournament.Items.Add(line.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read tournaments!");
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            lbTeam.Items.Clear();
            if (teamsOfTheTournament.Count > 1) initializeGenerateGames();
            else if (teamsOfTheTournament.Count == 1) MessageBox.Show("Oups! You cannot generate game with only one team!");
            else MessageBox.Show("Oups! You cannot generate games without teams!");
        }

        private void initializeGenerateGames()
        {

            lbTournament.Items.Clear();
            teamsToGenerate.Clear();

            int numberOfGames = teamsOfTheTournament.Count / 2;
            List<int> teamIDAdded = new List<int>();

            bool keep = true;

            //for integers

            int rInt = 0;

            while (keep == true)
            {

                Random r = new Random();
                rInt = r.Next(0, teamsOfTheTournament.Count);

                // if that team is already been added
                var item = teamIDAdded.IndexOf(rInt);

                // If it's not there
                if (item == -1)
                {
                    //MessageBox.Show("Ezate");
                    int team_id = teamsOfTheTournament[rInt];
                    teamIDAdded.Add(rInt);
                    lbTeam.Items.Remove(team_id);
                    saveTeam(team_id);
                }
                //else
                //{
                //    MessageBox.Show("Eza deja");
                //}

                //MessageBox.Show("teamsToGenerate = " + teamsToGenerate.Count);
                //MessageBox.Show("teamIDAdded = " + teamIDAdded.Count.ToString());
                if (teamsToGenerate.Count == teamsOfTheTournament.Count) keep = false;
            }
            generateGames();
            MessageBox.Show("Generated Games successful!");
        }

        private void saveTeam(int team_id)
        {
            var item = _teams.FindIndex(b => b.TeamID == team_id);
            //MessageBox.Show("is the team here there = " + item);
            try
            {
                // if the team selected is still in the tournament team list and
                // if it's not -1
                if (item <= _teams.Count && item >= 0)
                {
                    teamsToGenerate.Add(_teams[item]);
                    //MessageBox.Show("teams Name = " + _teams[item].Name);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Index out of bounds" + ex);
            }

        }
        private void generateGames()
        {
            int nbreOfTeam = 1;
            string team_1 = "";
            string team_2 = "";


            if (teamsToGenerate.Count > 0)
            {
                foreach (TeamSport line in teamsToGenerate)
                {

                    //MessageBox.Show("nbreOfTeam = " + nbreOfTeam);
                    if (nbreOfTeam == 1)
                    {
                        team_1 = line.Name;
                        //MessageBox.Show("team_1 = " + team_1);
                    }
                    else if (nbreOfTeam == 2)
                    {
                        team_2 = line.Name;
                        //MessageBox.Show("team_2 = " + team_2);

                        //Mettre
                        var game = new CustomControls.Game();
                        game.lblTeam_1.Text = team_1;
                        game.lblTeam_2.Text = team_2;
                        lbTournament.Items.Add(game);
                        nbreOfTeam = 0;
                    }

                    nbreOfTeam++;

                }

                cleanTeams(teamsToGenerate[teamsToGenerate.Count - 1]);
            }

        }

        private void cleanTeams(TeamSport teamNotAdded)
        {
            // Clear the listboxes
            lbTeam.Items.Clear();

            if (teamsToGenerate.Count % 2 != 0)
            {
                TeamSport line = new TeamSport()
                {
                    Name = teamNotAdded.Name
                };
                PopulateTeamCustomControl(line);
            }
        }

        private void btnGenerate_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (lbTournament.Items.Count < 1)
            {
                MessageBox.Show("You have to generate game first");
                return;
            }

            int rowAffected = 0;
            int result = deleteAllgames();
            //MessageBox.Show("result = " + result);

            lbTournament.Items.Clear();

            int nbreOfTeam = 1;
            string team_1 = "";
            string team_2 = "";
            int team_1_id = 0;
            int team_2_id = 0;

            if (teamsToGenerate.Count > 0)
            {

                //int result = _tournamentManager.deleteTournamentGameGenerated(_tournament_id);
                ////MessageBox.Show("delete = " + result);
                if (result > 0)
                {
                    foreach (TeamSport line in teamsToGenerate)
                    {

                        //MessageBox.Show("nbreOfTeam = " + nbreOfTeam);
                        if (nbreOfTeam == 1)
                        {
                            team_1 = line.Name;
                            team_1_id = line.TeamID;
                            //MessageBox.Show("team_1 = " + team_1);
                        }
                        else if (nbreOfTeam == 2)
                        {

                            team_2 = line.Name;
                            team_2_id = line.TeamID;
                            //MessageBox.Show("team_2 = " + team_2);


                            //Mettre
                            var game = new CustomControls.Game();
                            game.lblTeam_1.Text = team_1;
                            game.lblTeam_2.Text = team_2;
                            lbTournament.Items.Add(game);
                            nbreOfTeam = 0;

                            // Creating the TournamentGenerateGames object to deal with in the database
                            TournamentGenerateGames tournamentGames = new TournamentGenerateGames()
                            {
                                TournamentID = _tournament_id,
                                TeamID_1 = team_1_id,
                                TeamID_2 = team_2_id,
                                MemberID = _memberID,
                                Content = team_1 + " vs " + team_2,
                                IsAGroup = true
                            };

                            rowAffected = _tournamentManager.InsertTournamentGame(tournamentGames);
                            //MessageBox.Show("rowAffected = "+ rowAffected);
                        }

                        nbreOfTeam++;
                    }

                    cleanTeams(teamsToGenerate[teamsToGenerate.Count - 1]);

                }

                if (rowAffected > 0) MessageBox.Show("Saved successfully!");
            }

        }

        private void btnOpenTournamentPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgAddTeamToTournament());
        }

        private void btnDeleteAllGames_Click(object sender, RoutedEventArgs e)
        {
            if (lbTournament.Items.Count > 0)
            {
                int result = deleteAllgames();
                if (result > 0)
                {
                    lbTournament.Items.Clear();
                    MessageBox.Show("Delete successfully!");
                }

                getTournamentTeam();
            }
            else
            {
                MessageBox.Show("There's no games to delete!");
            }
        }

        private int deleteAllgames()
        {
            int result = _tournamentManager.deleteTournamentGameGenerated(_tournament_id);
            return result;
        }
    }
}
