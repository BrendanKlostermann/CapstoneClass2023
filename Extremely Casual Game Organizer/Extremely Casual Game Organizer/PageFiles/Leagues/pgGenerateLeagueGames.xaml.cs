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

namespace Extremely_Casual_Game_Organizer.PageFiles.Leagues
{
    /// <summary>
    /// Interaction logic for pgGenerateLeagueGames.xaml
    /// </summary>
    public partial class pgGenerateLeagueGames : Page
    {

        MasterManager _masterManager = new MasterManager();
        PageControl _pageControl = new PageControl();
        List<TeamsInGame> _games = null;
        League _league = null;
        ListToDataTableConverter converter = new ListToDataTableConverter();

        public pgGenerateLeagueGames(League league)
        {
            _league = league;
            InitializeComponent();
        }
        private void GenerateGames()
        {
            if (_games != null)
            {
                _games.Clear();
            }
            List<Team> teams = _masterManager.LeagueManager.GetAListOfTeamsByLeagueID(_league.LeagueID);

            // Shuffle the team names to randomize the order
            Random random = new Random();
            for (int i = teams.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Team temp = teams[i];
                teams[i] = teams[j];
                teams[j] = temp;
            }
            int numGames = teams.Count();


            // Create a list of game matchups
            List<TeamsInGame> matchups = new List<TeamsInGame>();

            for (int i = 0; i < numGames; i++)
            {
                // Shuffle the team names again for each game
                for (int j = teams.Count - 1; j > 0; j--)
                {
                    int k = random.Next(j + 1);
                    Team temp = teams[j];
                    teams[j] = teams[k];
                    teams[k] = temp;
                }

                // Pair up teams for each game
                for (int j = 0; j < teams.Count - 1; j += 2)
                {
                    TeamsInGame matchup = new TeamsInGame { Team1Name = teams[j].TeamName, Team1ID = teams[j].TeamID, Team2Name = teams[j + 1].TeamName, Team2ID = teams[j + 1].TeamID };
                    if (!matchups.Contains(matchup))
                    {
                        matchups.Add(matchup);
                    }
                }

                if (teams.Count % 2 != 0)
                {
                    matchups.Add(new TeamsInGame { Team1Name = teams[teams.Count - 1].TeamName, Team1ID = teams[teams.Count - 1].TeamID, Team2ID = teams[0].TeamID });
                }
            }

            _games = matchups;
            LoadGameList();
        }
        private void LoadGameList()
        {
            lstGameList.Items.Clear();
            DataTable gameList = converter.ToDataTable(_games);
            foreach (var matchup in gameList.AsEnumerable())
            {
                ListBoxItem addGame = new ListBoxItem();
                addGame.BorderBrush = Brushes.Black;
                addGame.Margin = new Thickness(5);
                addGame.Width = 700;
                addGame.Height = 50;
                addGame.DataContext = matchup[2] + "," + matchup[3];


                TextBlock name1Text = new TextBlock()
                {
                    Text = matchup[0].ToString(),
                    Width = 350,
                    FontWeight = FontWeights.Bold
                };

                TextBlock name2Text = new TextBlock()
                {
                    Text = matchup[1].ToString(),
                    Width = 350,
                    FontWeight = FontWeights.Bold
                };

                DockPanel gameListItem = new DockPanel();

                gameListItem.Children.Add(name1Text);
                gameListItem.Children.Add(name2Text);

                addGame.Content = gameListItem;

                lstGameList.Items.Add(addGame);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GenerateGames();
            }
            catch
            {
                MessageBox.Show("Sorry, games failed to load.");
                return;
            }
        }

        private void lstGameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGameList.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)lstGameList.SelectedItem;
                string[] ids = selectedItem.DataContext.ToString().Split(',');
                int team1ID = Int32.Parse(ids[0]);
                int team2ID = Int32.Parse(ids[1]);
                _pageControl.LoadPage(new pgAddLeagueGame(_masterManager, team1ID, team2ID));
            }
        }
    }
}
