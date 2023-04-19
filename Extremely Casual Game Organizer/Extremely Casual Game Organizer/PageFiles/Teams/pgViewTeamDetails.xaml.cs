/// <summary>
/// Created By: Jacob Lindauer
/// Date: 2023/24/02
/// 
/// Page file for viewing team details
/// 
/// Updated By: 
/// Date: 
/// 
/// 
/// </summary>
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
using LogicLayerInterfaces;
using LogicLayer;
using DataObjects;
using System.Data;
using Extremely_Casual_Game_Organizer.PageFiles.Practices;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgViewTeamDetails.xaml
    /// </summary>
    public partial class pgViewTeamDetails : Page
    {
        int _teamID = 0;
        Team _team = null;
        MasterManager _masterManager = null;
        PageControl _pageControl = new PageControl();
        Button _viewRoster = null;
        public pgViewTeamDetails(int teamID, MasterManager masterManager)
        {
            _teamID = teamID;

            _masterManager = masterManager;

            InitializeComponent();
        }
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/25/02
        /// 
        /// Page loaded event. Should add click events to buttons and load data for page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Creating button for viewing team roster
            _viewRoster = _pageControl.SetCustomButton("View Roster", 1);
            _viewRoster.Click += ViewRosterButton_Click;
            LoadTeamDetails();
            LoadGameData();
            LoadLeagueList();
            LoadUserDetails();
        }

        /// <summary>
        ///  Created By: Nick Vroom
        ///  Date: 2023/04/18
        ///  
        /// Method checks to see if the logged-in user is the owner of the team, if so, they can create and remove practices 
        /// </summary>
        private void LoadUserDetails()
        {
            int ownerID = _masterManager.TeamManager.SelectTeamOwner(_teamID);
            Console.WriteLine(ownerID);
            Console.WriteLine(_pageControl.GetSignedInMember()?.MemberID);
            if (_pageControl.GetSignedInMember()?.MemberID.Equals(100042) == true)
            {
                btnCreatePractice.Visibility = Visibility.Visible;
                btnRemovePractice.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        ///  Created By: Jacob Lindauer
        ///  Date: 2023/24/02
        ///  
        /// Method takes the TeamID and retireves the Team Data Object and uses its properties to populate items in Team Details Grid. 
        /// </summary>
        private void LoadTeamDetails()
        {
            try
            {
                _team = _masterManager.TeamManager.RetrieveTeamByTeamID(_teamID);

                lblTeamName.Text = _team.TeamName;
                txtTeamSport.Text = (from sport in _masterManager.SportManager.RetrieveAllSports() where sport.SportId.Equals(_team.SportID) select sport.Description).First(); // should only return 1 result
                txtDescription.Text = _team.Description;

                if (_team.Gender == null)
                {
                    txtTeamGender.Text = "Coed";
                }
                else if (_team.Gender == true)
                {
                    txtTeamGender.Text = "Male";
                }
                else if (_team.Gender == false)
                {
                    txtTeamGender.Text = "Female";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/02/26
        /// 
        /// Method will load data list.
        /// Upcoming games are games where the start date is after current date.
        /// Previous games are games where start data is before current date.
        /// </summary>
        private void LoadGameData()
        {
            try
            {
                // Get the list of games.
                DataTable gameList = _masterManager.GameManager.RetrieveTeamGameList(_teamID);

                // Prepare data tables
                DataTable upcomingGames = new DataTable();
                DataTable previousGames = new DataTable();

                // Need to clone table columns. Clone() does whole table so rows will need to be cleared.
                previousGames = gameList.Clone();
                previousGames.Rows.Clear();

                upcomingGames = gameList.Clone();
                upcomingGames.Rows.Clear();
                // Loop through each game
                foreach (var game in gameList.AsEnumerable())
                {
                    // Cannot use boolean directly on Date Time types. Need to use Compare method.
                    int compareDate = DateTime.Compare(Convert.ToDateTime(game["Date and Time"]), DateTime.Now);
                    if (compareDate < 0)
                    {
                        previousGames.Rows.Add(game.ItemArray);
                    }
                    if (compareDate > 0 || compareDate == 0)
                    {
                        upcomingGames.Rows.Add(game.ItemArray);
                    }
                }

                // Prepare Data List formatting. Need to create each column and remove column for gameID.
                // Binding is determined from column names returned from stored procedure
                // Previous Games
                datPreviousGamesList.AutoGenerateColumns = false;
                datPreviousGamesList.Focusable = false;
                datPreviousGamesList.IsReadOnly = true;

                DataGridTextColumn prevColumn2 = new DataGridTextColumn();
                prevColumn2.Binding = new Binding("Teams");
                prevColumn2.Header = "Teams";
                prevColumn2.Width = new DataGridLength(230);
                datPreviousGamesList.Columns.Add(prevColumn2);

                DataGridTextColumn prevColumn4 = new DataGridTextColumn();
                prevColumn4.Binding = new Binding("Date and Time");
                prevColumn4.Width = new DataGridLength(130);
                prevColumn4.Header = "Date and Time";
                datPreviousGamesList.Columns.Add(prevColumn4);

                datPreviousGamesList.ItemsSource = previousGames.DefaultView;

                // Current Games
                datUpcomingGamesList.AutoGenerateColumns = false;
                datUpcomingGamesList.Focusable = false;
                datUpcomingGamesList.IsReadOnly = true;
                datUpcomingGamesList.HeadersVisibility = DataGridHeadersVisibility.None;



                DataGridTextColumn column2 = new DataGridTextColumn();
                column2.Binding = new Binding("Teams");
                column2.Header = "Teams";
                column2.Width = new DataGridLength(220);
                datUpcomingGamesList.Columns.Add(column2);

                DataGridTextColumn column4 = new DataGridTextColumn();
                column4.Binding = new Binding("Date and Time");
                column4.Width = new DataGridLength(125);
                column4.Header = "Date and Time";
                datUpcomingGamesList.Columns.Add(column4);

                datUpcomingGamesList.ItemsSource = upcomingGames.DefaultView;

                // Hide lables if tables have data
                if (upcomingGames.Rows.Count > 0)
                {
                    lblUpcomingEmptyGrid.Visibility = Visibility.Hidden;
                }
                if (previousGames.Rows.Count > 0)
                {
                    lblPrevEmptyGrid.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
            
        }
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/02/26
        /// 
        /// Method will load active leagues the viewed team is currently in
        /// </summary>
        private void LoadLeagueList()
        {
            // Get league list for all active leagues
            var leagueList = _masterManager.LeagueManager.RetrieveLeagueListByTeamID(_teamID).Where(x => x.Active == true);

            // Hide label is data is present
            if (leagueList.Count() > 0)
            {
                lblLeagueEmptyGrid.Visibility = Visibility.Hidden;
            }

            datLeagueList.AutoGenerateColumns = false;
            datLeagueList.Focusable = false;
            datLeagueList.IsReadOnly = true;


            DataGridTextColumn column8 = new DataGridTextColumn();
            column8.Binding = new Binding("Name");
            column8.Header = "Name";
            column8.Width = new DataGridLength(380);
            datLeagueList.Columns.Add(column8);


            datLeagueList.ItemsSource = leagueList;
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 02/15/2023
        /// 
        /// Grid double click event. Displays game details page for selected game.
        /// </summary>
        private void datUpcomingGamesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectedItem = (DataRowView)datUpcomingGamesList.SelectedItem;

                int gameID = Convert.ToInt32(selectedItem["game_id"]);

                // Prepare page to be loaded
                pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                var currentPage = new pgViewTeamDetails(_teamID, _masterManager);

                _pageControl.LoadPage(viewGame, currentPage);


            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);

            }
        }
        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/26/02
        /// 
        /// Method for view roster button click event
        /// </summary> 
        /// 
        private void ViewRosterButton_Click(object sender, RoutedEventArgs e)
        {
            new pgTeamMemberScreen(_masterManager);

            _pageControl.LoadPage(new pgTeamMemberScreen(_teamID, _masterManager), new pgViewTeamDetails(_teamID, _masterManager));
        }

        private void datLeagueList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Need to set this to method for displaying league details
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 02/15/2023
        /// 
        /// Grid double click event. Displays game details page for selected game.
        /// </summary>
        private void datPreviousGamesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectedItem = (DataRowView)datPreviousGamesList.SelectedItem;

                if (selectedItem == null)
                {
                    MessageBox.Show("Please select a row item");
                }
                else
                {
                    int gameID = Convert.ToInt32(selectedItem["game_id"]);

                    // Prepare page to be loaded
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                    // Get current page to pass through for previous page
                    var currentPage = new pgViewTeamDetails(_teamID, _masterManager);

                    _pageControl.LoadPage(viewGame, currentPage);
                }

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            // Need to remove click event, should user return to this page

            _viewRoster.Click -= ViewRosterButton_Click;

            // nulling selected items
            datPreviousGamesList.SelectedItem = null;
            datUpcomingGamesList.SelectedItem = null;
            datLeagueList.SelectedItem = null;
        }

        private void btnCreatePractice_Click(object sender, RoutedEventArgs e)
        {
            pgCreatePractice page = new pgCreatePractice(_team.TeamID);

            NavigationService.Navigate(page);
        }

        private void btnRemovePractice_Click(object sender, RoutedEventArgs e)
        {
            pgRemovePractice page = new pgRemovePractice(_team.TeamID);
            NavigationService.Navigate(page);
        }
    }
}
