/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgAddTeamToTournament.xaml
    /// </summary>
    public partial class pgAddTeamToTournament : Page
    {
        TeamManager _teamManager = null;
        TournamentManager _tournamentManager= null;
        
        //I created this variable to store the sport ID
        private int _sport_id;

        // Variable to store the tournament ID
        private int _tournament_id;

        // This variable List store the teamID of team that I aer already in the tournament
        public List<int> teamToRemove = new List<int>();

        //This variable List store the all tournaments
        private List<Tournament> tournaments = null;

        //This variable List store the team of tournament
        private List<TournamentTeam> tournamentTeams = null;

        //This variable List store all teams
        List<TeamSport> _teams = null;
        private MasterManager masterManager;

        public pgAddTeamToTournament()
        {
            _teamManager = new TeamManager();
            _tournamentManager = new TournamentManager();
            List<Tournament> tournaments = new List<Tournament>();

            _sport_id = 0;
            _teams = new List<TeamSport>();
            InitializeComponent();
            getTeam();
            getTournament();
        }

        public pgAddTeamToTournament(MasterManager masterManager)
        {
            this.masterManager = masterManager;
            _teamManager = new TeamManager();
            _tournamentManager = new TournamentManager();
            List<Tournament> tournaments = new List<Tournament>();

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
                _teams = _teamManager.getTeamByTeamName(txtSearch.Text.ToString(), _sport_id);
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
            lbTournament.Items.Clear();

            foreach (TeamSport line in _teams)
            {
                if (teamToRemove.Count > 0)
                {
                    var item = teamToRemove.Find(id => id == line.TeamID);
                    if (item != 0)
                    {
                        PopulateTeamCustomControl(line, true);
                    }
                    else
                    {
                        PopulateTeamCustomControl(line, false);
                    }
                }
                else
                    {
                        PopulateTeamCustomControl(line, false);
                    }
                }

            lblTournament.Content = "Teams added : " + teamToRemove.Count;
        }

        // I created two custom controls
        // One to add a team from tournament : TeamAdd
        // the other one to remove a team from tournament: TeamRemove
        // Both located in the "CustomControls" folder
        private void PopulateTeamCustomControl(TeamSport line, bool isAdded)
        {
            //if the team is already added to the tournament
            if (isAdded == true)
            {
                var teamRemove = new CustomControls.TeamRemove(this);
                teamRemove.TeamId = line.TeamID;
                teamRemove.lblName.Content = line.Name;
                // Add result to the listbox
                lbTournament.Items.Add(teamRemove);
            }
            else
            {
                var teamAdd = new CustomControls.TeamAdd(this);
                teamAdd.TeamId = line.TeamID;
                teamAdd.lblName.Content = line.Name;
                // Add result to the listbox
                lbTeam.Items.Add(teamAdd);
            }

        }

        // Search for a team while the user is typing
        private void Blur(object sender, KeyEventArgs e)
        {
            getTeam();
        }

        // Remove all teams from tournament
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (teamToRemove.Count > 0)
            {
                foreach (int line in teamToRemove)
                {
                    removeTeamFromTournament(line);
                }
                teamToRemove.Clear();
                refresh();
            }
            else
            {
                MessageBox.Show("Oups! There's nothing to remove.");
            }
        }

        // Add all teams to the tournament
        private void btnAddAllTeam_Click(object sender, RoutedEventArgs e)
        {
            if (ddTournament.Text != "")
            {
                foreach (TeamSport line in _teams)
                {
                    var item = teamToRemove.Find(id => id == line.TeamID);
                    if (item == 0)
                    {
                        //MessageBox.Show(item.ToString());
                        teamToRemove.Add(line.TeamID);
                        addTeamFromTournament(line.TeamID);
                    }

                }
                
                refresh();
            }
            else
            {
                MessageBox.Show("Please, select a tournament!");
            }
        }

        //Get team according to the tournament selected
        private void ddTournament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _sport_id = 0;
            _tournament_id = 0;
            foreach (Tournament line in tournaments)
            {
                if(line.Name == ddTournament.SelectedItem.ToString())
                {
                    _sport_id = line.SportID;
                    _tournament_id = line.TournamentID;
                }
            }
            getTournamentTeam();
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

        // Get all teams by tournament_id
        private void getTournamentTeam()
        {
            lbTournament.Items.Clear();
            teamToRemove.Clear();

            try
            {
                tournamentTeams = _tournamentManager.GetTournamentTeamByID(_tournament_id);

                foreach (TournamentTeam line in tournamentTeams)
                {
                    teamToRemove.Add(line.TeamID);
                }
                getTeam();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read tournament team!");
            }
        }

        // Add a team to the tournament
        public void addTeamFromTournament(int team_id)
        {
            int result = 0;
            //try
            //{

                TournamentTeam tournamentTeam = new TournamentTeam()
                {
                    TournamentID = _tournament_id,
                    TeamID = team_id
                };

                result = _tournamentManager.AddTeamToTournament(tournamentTeam);
                refresh();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Cannot add the team from the tournament!");
            //}
        }

        // Remove a team from the tournament
        public void removeTeamFromTournament(int team_id)
        {
            int result = 0;
            try
            {

                TournamentTeam tournamentTeam = new TournamentTeam()
                {
                    TournamentID = _tournament_id,
                    TeamID = team_id
                };

                result = _tournamentManager.RemoveTeamToTournament(tournamentTeam);
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot remove the team from the tournament!");
            }
        }

        private void btnBackToGenerate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgGenerateTournamentGame());
        }
    }
}
