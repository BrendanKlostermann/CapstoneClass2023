//Page for Viewing a Tournament
//Nick Vroom 3/7/2023


using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for pgViewTournament.xaml
    /// </summary>
    public partial class pgViewTournament : Page
    {
        PageControl _pageControl = new PageControl();
        Button _addGameToTournament = null;
        TournamentManager tm = new TournamentManager();
        TeamManager teammanager = new TeamManager();
        SportManager sm = new SportManager();
        Tournament tournament = new Tournament();
        GameManager gm = new GameManager();
        GameRosterManager grm = new GameRosterManager();
        int _tournamentID;

        public pgViewTournament(int tournamentID)
        {
            InitializeComponent();
			tournament = tm.RetrieveTournamentByTournamentID(tournamentID);
            txtTournamentName.Text = tournament.Name;
            txtTournamentDescription.Text = tournament.Description;
            _tournamentID = tournamentID;

            //logic for if gender = 0, 1, or null
            // 0 is mens, 1 is womens, null means unisex
            if (tournament.Gender == true)
            {
                txtTournamentSportGender.Text = "Men's " + sm.RetrieveSportBySportID(tournament.SportID);
            }
            else if (tournament.Gender == false)
            {
                txtTournamentSportGender.Text = "Women's " + sm.RetrieveSportBySportID(tournament.SportID);
            }
            else if (tournament.Gender.HasValue == false)
            {
                txtTournamentSportGender.Text = "" + sm.RetrieveSportBySportID(tournament.SportID);
            }


            // random populated items for the Teams ListView
            List<string> myList = new List<string>();
            List<string> upcomingGames = new List<string>();
            List<int> teamIDList = new List<int>();
            List<int> gameIDList = new List<int>();
            List<int> gameTeamIDList = new List<int>();
            List<TournamentTeam> _teamList = tm.GetTournamentTeamByID(tournamentID);
            List<TournamentTeamGame> tournamentTeamGameList = tm.SelectTournamentTeamAndGame(tournamentID);

            foreach (TournamentTeam team in _teamList)
            {
                int teamID = team.TeamID;
                teamIDList.Add(teamID);
            }
            foreach (TournamentTeamGame game in tournamentTeamGameList)
            {
                gameIDList.Add(game.GameID);
            }

            // Get a list of the tournament team games
            //var gameList = tournamentTeamGameList;
            //int team1 = 0;
            //int team2 = 0;

            //var 

            HashSet < Tuple<int, int> > addedPairs = new HashSet<Tuple<int, int>>();
			
            foreach (TournamentTeamGame game in tournamentTeamGameList)
            {
                gameTeamIDList.Clear();
                List<GameRoster> gameRosterList = new List<GameRoster>();
                DataRow dr = gm.ViewGameDetails(game.GameID);
                string dateOfGame = Convert.ToDateTime(dr[4]).ToShortDateString();
                string timeOfGame = Convert.ToDateTime(dr[4]).ToShortTimeString();
                Console.WriteLine(dateOfGame + " at " + timeOfGame);
                gameRosterList = grm.RetrieveGameRoster(game.GameID);
                foreach (GameRoster gameRosters in gameRosterList)
                {
                    if (!gameTeamIDList.Contains(gameRosters.TeamID))
                    {
                        gameTeamIDList.Add(gameRosters.TeamID);
                    }
                }
				
                for (int i = 0; i < gameTeamIDList.Count - 1; i++)
                {
                    for (int j = i + 1; j < gameTeamIDList.Count; j++)
                    {
                        int team1ID = gameTeamIDList[i];
                        int team2ID = gameTeamIDList[j];
                        if (team1ID < team2ID)
                        {
                            Tuple<int, int> teamPair = new Tuple<int, int>(team1ID, game.GameID);

                            if (!addedPairs.Contains(teamPair))
                            {
                                addedPairs.Add(teamPair);
                                upcomingGames.Add(teammanager.RetrieveTeamByTeamID(team1ID).TeamName + " vs. " +
                                    teammanager.RetrieveTeamByTeamID(team2ID).TeamName + " at " + dateOfGame + " at " + timeOfGame);
                            }
                        }
                    }
                }
            }








            foreach (int team_id in teamIDList)
            {
                Team tournamentTeam = teammanager.RetrieveTeamByTeamID(team_id);
                myList.Add(tournamentTeam.TeamName);
            }



            gameTeamListBox.ItemsSource = upcomingGames;
            tournamentTeamListBox.ItemsSource = myList;
        }
        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prepare page to be loaded
                pgAddGame viewGame = new pgAddGame(_tournamentID);

                // Get current page to pass through for previous page
                var currentPage = new pgViewTournament(_tournamentID);

                _pageControl.LoadPage(viewGame, currentPage);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*if (_pageControl.GetSignedInMember() != null && _pageControl.GetSignedInMember().MemberID == tournament.MemberID)
        {
            // Create add game button
            _addGameToTournament = _pageControl.SetCustomButton("Add Game", 1);
        _addGameToTournament.Click += AddGameButton_Click;
        }*/

            // Create add game button

            var signedInMember = _pageControl.GetSignedInMember();
            if (signedInMember != null && signedInMember.MemberID == tournament.MemberID)
            {
                _addGameToTournament = _pageControl.SetCustomButton("Add Game", 1);
                _addGameToTournament.Click += AddGameButton_Click;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            var signedInMember = _pageControl.GetSignedInMember();
            if (signedInMember != null && signedInMember.MemberID == tournament.MemberID)
            {
                _addGameToTournament.Click -= AddGameButton_Click;
            }

        }
    }
}