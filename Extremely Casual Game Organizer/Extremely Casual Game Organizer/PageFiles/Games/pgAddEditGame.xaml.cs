using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles.Teams.Utility;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace Extremely_Casual_Game_Organizer.PageFiles.Games
{
    /// <summary>
    /// Interaction logic for pgAddEditGame.xaml
    /// </summary>
    public partial class pgAddEditGame : Page
    {
        MasterManager _masterManager;
        PageControl _pageControl;
        int _currentTeam1 = 0;
        int _currentTeam2 = 0;
        int _oldTeam1 = 0;
        int _oldTeam2 = 0;
        List<GameRoster> _team1Roster = null;
        List<GameRoster> _team2Roster = null;
        List<TeamMember> _team1Members = null;
        List<TeamMember> _team2Members = null;
        int _memberID;
        bool _editMode;
        int _gameID;
        Venue _newVenue = null;
        Button _deleteButton = null;

        public pgAddEditGame(MasterManager masterManager)
        {
            _masterManager = masterManager;
            _pageControl = new PageControl();
            _memberID = _pageControl.GetSignedInMember().MemberID;
            InitializeComponent();
            PopulateDetailOptions();
            _editMode = false;
        }
        public pgAddEditGame(MasterManager masterManager, int gameID)
        {
            _masterManager = masterManager;
            _pageControl = new PageControl();
            _memberID = _pageControl.GetSignedInMember().MemberID;
            _gameID = gameID;
            _editMode = true;
            InitializeComponent();
            PopulateDetailOptions();
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Page loaded event for creating buttons
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_editMode)
            {
                _deleteButton = _pageControl.SetCustomButton("Delete Game", 3);
                _deleteButton.Click += DeleteButton_Click;
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Delete button click event
        /// /// </summary>

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cancel = MessageBox.Show("Are you sure you want to delete this game?", "Delete", MessageBoxButton.OKCancel);

                if (cancel == MessageBoxResult.OK)
                {
                    int result = _masterManager.GameManager.RemoveGame(_gameID, _pageControl.GetSignedInMember().MemberID);

                    if (result > 0)
                    {
                        MessageBox.Show("Game has been removed");
                        _pageControl.LoadPage(new pgGameList(_masterManager));
                    }
                }
                if (cancel == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/18/2023
        /// 
        /// Method will populate the roster list for a team determined by team provided
        /// </summary>
        /// <param name="teamMemberList"></param>
        /// <param name="team">
        /// true = home
        /// false = away
        /// </param>
        private void PopulateTeamList(List<Member> teamMemberList, bool homeTeam)
        {
            foreach (var member in teamMemberList)
            {
                // Create Dock Panel template for list view item addition.
                // Need to create 2 dock panel to add to a stack panel. One for Name and one for Position.
                DockPanel dockPanelName = new DockPanel();
                DockPanel dockPanelPos = new DockPanel();

                // Stack panel is used to set listbox source and to add dock panels to. This allows them to be in the same listbox object.
                StackPanel stackPanel = new StackPanel();

                // Create Text Blocks to add to Dock Panel
                TextBlock nameLabel = new TextBlock();
                nameLabel.FontWeight = FontWeights.Bold;
                nameLabel.Text = "Name: ";

                // Get Member name from Game Roster.
                TextBlock memberName = new TextBlock { Text = member.FirstName + " " + member.FamilyName };

                // Add Text Block to Name Dock Panel
                dockPanelName.Children.Add(nameLabel);
                dockPanelName.Children.Add(memberName);

                // Get Position from Member team information.
                TextBlock posLabel = new TextBlock();
                posLabel.FontWeight = FontWeights.Bold;
                posLabel.Text = "Position: ";

                TextBlock posText = null;
                if (homeTeam == true)
                {
                    posText = new TextBlock { Text = _team1Members.Where(x => x.MemberID == member.MemberID).First().Description };

                }
                if (homeTeam == false)
                {
                    posText = new TextBlock { Text = _team2Members.Where(x => x.MemberID == member.MemberID).First().Description };

                }
                // Add Text Block to Position Dock Panel
                dockPanelPos.Children.Add(posLabel);
                dockPanelPos.Children.Add(posText);
                dockPanelPos.Children.Add(new TextBlock { Text = "\n" }); // Additional space in list box

                // Add Dock Panels to Stack Panel
                stackPanel.Children.Add(dockPanelName);
                stackPanel.Children.Add(dockPanelPos);


                if (homeTeam)
                {
                    // Set List View source to Stack Panel
                    listTeam1RosterList.Items.Add(stackPanel);
                }
                if (homeTeam == false)
                {
                    listTeam2RosterList.Items.Add(stackPanel);
                }
            }
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method will populate detail combo boxes
        /// </summary>
        private void PopulateDetailOptions()
        {
            try
            {
                if (_editMode == false)
                {
                    btnSaveAdd.Content = "Add";

                    // Hide score entries
                    txtTeam1Score.Visibility = Visibility.Hidden;
                    lblTeam1Score.Visibility = Visibility.Hidden;

                    txtTeam2Score.Visibility = Visibility.Hidden;
                    lblTeam2Score.Visibility = Visibility.Hidden;
                }
                // Clear out combo boxes if data
                cmboTimeHour.Items.Clear();
                cmboTimeMinutes.Items.Clear();
                cmboAMPM.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    cmboTimeHour.Items.Add(i.ToString("D2"));
                }
                for (int i = 0; i <= 59; i++)
                {
                    cmboTimeMinutes.Items.Add(i.ToString("D2"));
                }
                cmboAMPM.Items.Add("AM");
                cmboAMPM.Items.Add("PM");

                List<Sport> sportList = _masterManager.SportManager.RetrieveAllSports();
                cmboSports.Items.Clear();
                foreach (var sport in sportList)
                {
                    TextBox addItem = new TextBox();
                    addItem.Text = sport.Description;
                    addItem.DataContext = sport.SportId;
                    addItem.Width = 200;
                    addItem.IsReadOnly = true;
                    addItem.Focusable = false;
                    addItem.Cursor = Cursors.Hand;
                    addItem.Background = Brushes.Transparent;
                    addItem.BorderBrush = Brushes.Transparent;

                    cmboSports.Items.Add(addItem);
                }
                if (_editMode == true)
                {
                    // Load Game Details
                    DataRow loadGame = _masterManager.GameManager.ViewGameDetails(_gameID);

                    txtVenueName.Text = loadGame[1].ToString();
                    txtStreet.Text = loadGame[2].ToString();

                    // Zip code is last 5 of loadGame[3]
                    txtZip.Text = loadGame[3].ToString().Substring(loadGame[3].ToString().Length - 5);
                    txtState.Text = loadGame[3].ToString().Substring(0, loadGame[3].ToString().Length - 6);

                    // Set Date time fields
                    dateGameDate.SelectedDate = Convert.ToDateTime(loadGame[4]);

                    // Format selected date for box selections. Ex 01:30 AM
                    string date = Convert.ToDateTime(loadGame[4]).ToString("h:mm tt");

                    // 1:30 => [0] 1 [1] 30
                    string[] time = Convert.ToDateTime(loadGame[4]).ToString("h:mm").Split(':');

                    cmboTimeHour.SelectedItem = Convert.ToInt32(time[0]).ToString("D2");

                    cmboTimeMinutes.SelectedItem = time[1];

                    if (date.Contains("AM"))
                    {
                        cmboAMPM.SelectedItem = "AM";
                    }
                    else
                    {
                        cmboAMPM.SelectedItem = "PM";
                    }

                    foreach (TextBox item in cmboSports.Items)
                    {
                        if (item.Text.Equals(loadGame[5]))
                        {
                            cmboSports.SelectedItem = item;
                        }
                    }

                    // Load Team Rosters
                    Team team1 = new Team();
                    Team team2 = new Team();

                    var teams = _masterManager.GameRosterManager.RetrieveGameRoster(_gameID).Select(x => x.TeamID).Distinct();

                    // ONLY expecting 2 results from this per game.
                    team1 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.First());

                    team2 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.Last());

                    _oldTeam1 = team1.TeamID;
                    _oldTeam2 = team2.TeamID;

                    _currentTeam1 = team1.TeamID;
                    _currentTeam2 = team2.TeamID;

                    //Load Scores
                    var scores = _masterManager.GameManager.RetreiveScoresByGameID(_gameID);
                    Score team1Score = (Score)scores.Where(x => x.TeamID == _currentTeam1).First();
                    Score team2Score = (Score)scores.Where(x => x.TeamID == _currentTeam2).First();

                    txtTeam1Score.Text = team1Score.TeamScore.ToString();
                    txtTeam2Score.Text = team2Score.TeamScore.ToString();

                    _team1Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(team1.TeamID);

                    // Set Team Name
                    txtTeam1.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(team1.TeamID).TeamName;

                    // Get member info for each team roster member
                    List<Member> teamMemberList = new List<Member>();

                    foreach (var member in _team1Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        teamMemberList.Add(searchMember);
                    }

                    // Load roster list.
                    // Team1
                    PopulateTeamList(teamMemberList, true);

                    // Team2
                    // Load team Roster
                    // Get team roster
                    _team2Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(team2.TeamID);

                    // Set Team Name
                    txtTeam2.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(team2.TeamID).TeamName;

                    // Get member info for each team roster member
                    List<Member> team2MemberList = new List<Member>();

                    foreach (var member in _team2Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        team2MemberList.Add(searchMember);
                    }

                    // Load roster list.
                    PopulateTeamList(team2MemberList, false);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method for search click event.
        /// This will bring up search menu for team 1 selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeam1Search_Click(object sender, RoutedEventArgs e)
        {
            // ready serach window
            winTeamSearch teamSearch = new winTeamSearch(_masterManager);

            if (teamSearch.ShowDialog() == true)
            {
                listTeam1RosterList.Items.Clear();
                winTeamSearch wintoclose = (winTeamSearch)Application.Current.Windows.OfType<Window>().Where(x => x.Name == "windowTeamSearch").First();
                if (_editMode)
                {
                    _currentTeam1 = wintoclose.SelectedTeamID;
                }
                else
                {
                    _currentTeam1 = wintoclose.SelectedTeamID;
                }

                wintoclose.Close();

                try
                {
                    // Load team Roster
                    _team1Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(_currentTeam1);

                    // Set Team Name
                    txtTeam1.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(_currentTeam1).TeamName;

                    // Get member info for each team roster member
                    List<Member> teamMemberList = new List<Member>();

                    foreach (var member in _team1Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        teamMemberList.Add(searchMember);
                    }

                    // Load roster list
                    PopulateTeamList(teamMemberList, true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method for search click event.
        /// This will bring up search menu for team 1 selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTeam2Search_Click(object sender, RoutedEventArgs e)
        {
            // ready serach window
            winTeamSearch teamSearch = new winTeamSearch(_masterManager);

            if (teamSearch.ShowDialog() == true)
            {
                listTeam2RosterList.Items.Clear();
                winTeamSearch wintoclose = (winTeamSearch)Application.Current.Windows.OfType<Window>().Where(x => x.Name == "windowTeamSearch").First();
                if (_editMode)
                {
                    _currentTeam2 = wintoclose.SelectedTeamID;
                }
                else
                {
                    _currentTeam2 = wintoclose.SelectedTeamID;
                }
                wintoclose.Close();

                try
                {
                    // Load team Roster
                    // Get team roster
                    _team2Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(_currentTeam2);

                    // Set Team Name
                    txtTeam2.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(_currentTeam2).TeamName;

                    // Get member info for each team roster member
                    List<Member> teamMemberList = new List<Member>();

                    foreach (var member in _team2Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        teamMemberList.Add(searchMember);
                    }

                    // Load roster list.
                    PopulateTeamList(teamMemberList, false);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Save / Submit button click event. Method will validate data and create or update game when needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_editMode == false)
            {
                try
                {
                    // Validate Fields
                    if (txtVenueName.Text == "" || txtVenueName.Text == null)
                    {
                        MessageBox.Show("Enter a valid venue name.");
                        txtVenueName.Focus();
                        return;
                    }
                    if (txtStreet.Text == "" || txtStreet.Text == null)
                    {
                        MessageBox.Show("Enter a valid street.");
                        txtStreet.Focus();
                        return;
                    }
                    if (txtZip.Text == "" || txtZip.Text == null)
                    {
                        MessageBox.Show("Enter a valid zip code");
                        txtZip.Focus();
                        return;
                    }
                    if (dateGameDate.SelectedDate == null)
                    {
                        MessageBox.Show("Select a date for the game");
                        dateGameDate.Focus();
                        return;
                    }
                    if (cmboTimeHour.SelectedItem == null || cmboTimeMinutes.SelectedItem == null || cmboAMPM == null)
                    {
                        MessageBox.Show("You need to select a time for the game");
                        cmboTimeHour.Focus();
                        return;
                    }
                    if (cmboSports.SelectedItem == null)
                    {
                        MessageBox.Show("You need to select a sport type for the game");
                        cmboSports.Focus();
                        return;
                    }

                    // Check if Venue already exists, if not create new venue. 
                    string searchText = txtStreet.Text.ToLower().Trim();
                    List<Venue> venueList = _masterManager.VenueManager.RetrieveAllVenues();

                    // Venue should consist of street and zip
                    var existingVenue = venueList.Where(x => x.Location.ToLower().Trim() == searchText && x.ZipCode.ToString().Equals(txtZip.Text));

                    if (existingVenue.Count() > 0)
                    {
                        MessageBox.Show("Provided Venue already exists. Game will reference existing venue", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtVenueName.Text = existingVenue.First().VenueName;
                        txtVenueName.IsReadOnly = true;

                    }
                    else
                    {
                        // Create new Venue since venue does not exist
                        _newVenue = new Venue();
                        _newVenue.VenueName = txtVenueName.Text;
                        _newVenue.Parking = "";
                        _newVenue.Location = txtStreet.Text;
                        _newVenue.ZipCode = Convert.ToInt32(txtZip.Text);
                        _newVenue.Description = "";

                        _newVenue.VenueID = _masterManager.VenueManager.AddVenue(_newVenue);
                    }

                    // Create new game object for creation
                    Game newGame = new Game();
                    if (_currentTeam1 == 0)
                    {
                        MessageBox.Show("Select a team for team 1");
                        btnTeam1Search.Focus();
                        return;
                    }
                    if (_currentTeam2 == 0)
                    {
                        MessageBox.Show("Select a team for team 2");
                        btnTeam2Search.Focus();
                        return;
                    }
                    if (_currentTeam1 == _currentTeam2)
                    {
                        MessageBox.Show("Selected Teams must not be the same team");
                        listTeam1RosterList.Items.Clear();
                        listTeam2RosterList.Items.Clear();
                        txtTeam1.Content = "Team1";
                        txtTeam2.Content = "team2";
                        return;
                    }
                    if (_currentTeam1 != 0 && _currentTeam2 != 0)
                    {
                        // Create Game.
                        // Data context for combo box item is the sportid for the sport
                        newGame.SportID = (int)((TextBox)cmboSports.SelectedItem).DataContext;
                        if (_newVenue == null)
                        {
                            newGame.VenueID = existingVenue.First().VenueID;
                        }
                        else
                        {
                            newGame.VenueID = _newVenue.VenueID;
                        }

                        DateTime selectedDate = (DateTime)dateGameDate.SelectedDate;
                        // 01/01/1011
                        string[] dateTimeParse = selectedDate.ToString("MM/dd/yyyy").Split('/');
                        if (cmboAMPM.SelectedItem.Equals("AM"))
                        {
                            newGame.DateAndTime = new DateTime(Convert.ToInt32(dateTimeParse[2]), Convert.ToInt32(dateTimeParse[0]), Convert.ToInt32(dateTimeParse[1]), Convert.ToInt32(cmboTimeHour.SelectedItem), Convert.ToInt32(cmboTimeMinutes.SelectedItem), 00);
                        }
                        else
                        {
                            newGame.DateAndTime = new DateTime(Convert.ToInt32(dateTimeParse[2]), Convert.ToInt32(dateTimeParse[0]), Convert.ToInt32(dateTimeParse[1]), Convert.ToInt32(cmboTimeHour.SelectedItem) + 12, Convert.ToInt32(cmboTimeMinutes.SelectedItem), 00);

                        }

                        int createGame = _masterManager.GameManager.AddGame(newGame, _memberID);

                        if (createGame > 0)
                        {
                            // Create Game Roster Entries
                            _team1Roster = new List<GameRoster>();
                            foreach (var member in _team1Members)
                            {
                                GameRoster addMember = new GameRoster();
                                addMember.MemberID = member.MemberID;
                                addMember.TeamID = member.TeamID;
                                addMember.GameID = createGame;
                                addMember.Description = member.Description;
                                _team1Roster.Add(addMember);
                            }
                            _team2Roster = new List<GameRoster>();
                            foreach (var member in _team2Members)
                            {
                                GameRoster addMember = new GameRoster();
                                addMember.MemberID = member.MemberID;
                                addMember.TeamID = member.TeamID;
                                addMember.GameID = createGame;
                                addMember.Description = member.Description;
                                _team2Roster.Add(addMember);
                            }

                            if (_team1Roster.Count > 0 && _team2Roster.Count > 0)
                            {
                                _masterManager.GameRosterManager.AddGameRosterMembers(_team1Roster);
                                _masterManager.GameRosterManager.AddGameRosterMembers(_team2Roster);
                            }

                            // Create score entries
                            Score team1Score = new Score();
                            team1Score.GameID = createGame;
                            team1Score.TeamID = _team1Roster[0].TeamID;
                            team1Score.TeamScore = null;

                            Score team2Score = new Score();
                            team2Score.GameID = createGame;
                            team2Score.TeamID = _team2Roster[0].TeamID;
                            team2Score.TeamScore = null;

                            // Add Scores to Score table
                            _masterManager.GameManager.AddScore(team1Score);
                            _masterManager.GameManager.AddScore(team2Score);

                            MessageBox.Show("Game has been created");
                            _pageControl.LoadPage(new pgGameList(_masterManager));
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }

            }
            if (_editMode == true)
            {

                try
                {
                    // Validate Fields
                    if (txtVenueName.Text == "" || txtVenueName.Text == null)
                    {
                        MessageBox.Show("Enter a valid venue name.");
                        txtVenueName.Focus();
                        return;
                    }
                    if (txtStreet.Text == "" || txtStreet.Text == null)
                    {
                        MessageBox.Show("Enter a valid street.");
                        txtStreet.Focus();
                        return;
                    }
                    if (txtZip.Text == "" || txtZip.Text == null)
                    {
                        MessageBox.Show("Enter a valid zip code");
                        txtZip.Focus();
                        return;
                    }
                    if (dateGameDate.SelectedDate == null)
                    {
                        MessageBox.Show("Select a date for the game");
                        dateGameDate.Focus();
                        return;
                    }
                    if (cmboTimeHour.SelectedItem == null || cmboTimeMinutes.SelectedItem == null || cmboAMPM == null)
                    {
                        MessageBox.Show("You need to select a time for the game");
                        cmboTimeHour.Focus();
                        return;
                    }
                    if (cmboSports.SelectedItem == null)
                    {
                        MessageBox.Show("You need to select a sport type for the game");
                        cmboSports.Focus();
                        return;
                    }
                    if (txtTeam1Score.Text != null && txtTeam1Score.Text != "")
                    {
                        if (!int.TryParse(txtTeam1Score.Text, out int n) && !decimal.TryParse(txtTeam1Score.Text, out decimal o))
                        {
                            MessageBox.Show("Team 1 Score must be a number");
                            txtTeam1Score.Text = "";
                            txtTeam1Score.Focus();
                            return;
                        }
                    }
                    if (txtTeam2Score.Text != null && txtTeam2Score.Text != "")
                    {
                        if (!int.TryParse(txtTeam2Score.Text, out int n) && !decimal.TryParse(txtTeam2Score.Text, out decimal o))
                        {
                            MessageBox.Show("Team 2 Score must be a number");
                            txtTeam2Score.Text = "";
                            txtTeam2Score.Focus();
                            return;
                        }
                    }

                    // Check if Venue already exists, if not create new venue. 
                    string searchText = txtStreet.Text.ToLower().Trim();
                    List<Venue> venueList = _masterManager.VenueManager.RetrieveAllVenues();

                    // Venue should consist of street and zip
                    var existingVenue = venueList.Where(x => x.Location.ToLower().Trim() == searchText && x.ZipCode.ToString().Equals(txtZip.Text));

                    if (existingVenue.Count() > 0)
                    {

                        MessageBox.Show("Provided Venue already exists. Game will reference existing venue", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtVenueName.Text = existingVenue.First().VenueName;
                        txtVenueName.IsReadOnly = true;
                    }
                    else
                    {
                        // Create new Venue since venue does not exist
                        _newVenue = new Venue();
                        _newVenue.VenueName = txtVenueName.Text;
                        _newVenue.Parking = "";
                        _newVenue.Location = txtStreet.Text;
                        _newVenue.ZipCode = Convert.ToInt32(txtZip.Text);
                        _newVenue.Description = "";

                        _newVenue.VenueID = _masterManager.VenueManager.AddVenue(_newVenue);
                    }

                    // Create game object for update
                    Game updateGame = new Game();
                    if (_currentTeam1 == 0)
                    {
                        MessageBox.Show("Select a team for team 1");
                        btnTeam1Search.Focus();
                        return;
                    }
                    if (_currentTeam2 == 0)
                    {
                        MessageBox.Show("Select a team for team 2");
                        btnTeam2Search.Focus();
                        return;
                    }
                    if (_currentTeam1 == _currentTeam2)
                    {
                        MessageBox.Show("Selected Teams must not be the same team");
                        listTeam1RosterList.Items.Clear();
                        listTeam2RosterList.Items.Clear();
                        txtTeam1.Content = "Team1";
                        txtTeam2.Content = "team2";
                        return;
                    }
                    if (_currentTeam1 != 0 && _currentTeam2 != 0)
                    {
                        // Create Game.

                        // Data context for combo box item is the sportid for the sport
                        updateGame.SportID = (int)((TextBox)cmboSports.SelectedItem).DataContext;
                        if (_newVenue == null)
                        {
                            updateGame.VenueID = existingVenue.First().VenueID;
                        }
                        else
                        {
                            updateGame.VenueID = _newVenue.VenueID;
                        }

                        DateTime selectedDate = (DateTime)dateGameDate.SelectedDate;
                        // 01/01/1011
                        string[] dateTimeParse = selectedDate.ToString("MM/dd/yyyy").Split('/');
                        if (cmboAMPM.SelectedItem.Equals("AM"))
                        {
                            int hour = Convert.ToInt32(cmboTimeHour.SelectedItem);
                            if (hour == 12)
                            {
                                // If midnight set to 0
                                hour = 0;
                            }
                            updateGame.DateAndTime = new DateTime(Convert.ToInt32(dateTimeParse[2]), Convert.ToInt32(dateTimeParse[0]), Convert.ToInt32(dateTimeParse[1]), hour, Convert.ToInt32(cmboTimeMinutes.SelectedItem), 00);
                        }
                        else
                        {
                            int hour = Convert.ToInt32(cmboTimeHour.SelectedItem);
                            if (hour != 12)
                            {
                                hour += 12;
                            }
                            updateGame.DateAndTime = new DateTime(Convert.ToInt32(dateTimeParse[2]), Convert.ToInt32(dateTimeParse[0]), Convert.ToInt32(dateTimeParse[1]), hour, Convert.ToInt32(cmboTimeMinutes.SelectedItem), 00);

                        }
                        updateGame.GameID = _gameID;

                        // Update Game Table
                        int result = _masterManager.GameManager.EditGame(updateGame, _pageControl.GetSignedInMember().MemberID);

                        // If Update is successful, continue
                        if (result > 0)
                        {
                            // Recreate GameRoster Table Entries if roster was updated

                            // Check if game roster teams have changed
                            if ((_oldTeam1 != _currentTeam1 && _oldTeam2 != _currentTeam1) || (_oldTeam2 != _currentTeam2 && _oldTeam1 != _currentTeam2))
                            {
                                // At least 1 team has been changed. Check and find out which one has changed and update tables
                                if (_currentTeam1 != _oldTeam2 && _currentTeam1 != _oldTeam1) // Selected team is not associated with game
                                {
                                    // Remove old team only if old team is not current selected team 2
                                    if (_oldTeam1 != _currentTeam2)
                                    {
                                        _masterManager.GameRosterManager.RemoveFromGameRoster(_oldTeam1, _gameID);
                                    }
                                    else
                                    {
                                        _masterManager.GameRosterManager.RemoveFromGameRoster(_oldTeam2, _gameID);

                                    }

                                    // Create new Roster Entries to update table
                                    _team1Roster = new List<GameRoster>();
                                    foreach (var member in _team1Members)
                                    {
                                        GameRoster addMember = new GameRoster();
                                        addMember.MemberID = member.MemberID;
                                        addMember.TeamID = member.TeamID;
                                        addMember.GameID = updateGame.GameID;
                                        addMember.Description = member.Description;
                                        _team1Roster.Add(addMember);
                                    }

                                    // Update roster and team table
                                    _masterManager.GameRosterManager.AddGameRosterMembers(_team1Roster);

                                }

                                if (_currentTeam2 != _oldTeam2 && _currentTeam2 != _oldTeam1)
                                {
                                    // Removed previouslty selected team ONLY if it is not current team 1 selection
                                    if (_oldTeam2 != _currentTeam1)
                                    {
                                        _masterManager.GameRosterManager.RemoveFromGameRoster(_oldTeam2, _gameID);
                                    }
                                    else
                                    {
                                        _masterManager.GameRosterManager.RemoveFromGameRoster(_oldTeam1, _gameID);
                                    }

                                    // Create new Roster Entries to update table
                                    _team2Roster = new List<GameRoster>();
                                    foreach (var member in _team2Members)
                                    {
                                        GameRoster addMember = new GameRoster();
                                        addMember.MemberID = member.MemberID;
                                        addMember.TeamID = member.TeamID;
                                        addMember.GameID = updateGame.GameID;
                                        addMember.Description = member.Description;
                                        _team2Roster.Add(addMember);
                                    }

                                    // Update roster and team table
                                    _masterManager.GameRosterManager.AddGameRosterMembers(_team2Roster);
                                }

                            }


                            // Updating Scores
                            // Retrieve game scores
                            var scores = (_masterManager.GameManager.RetreiveScoresByGameID(_gameID).Select(x => x.TeamID)).ToList();
                            List<Score> updateScores = new List<Score>();

                            // Check if current teams exists in score table for game. If so, update scores
                            if (scores.Contains(_currentTeam1) && scores.Contains(_currentTeam2))
                            {
                                //If tables contains both scores, update.
                                Score team1Score = CreateScore(_gameID, _currentTeam1, txtTeam1Score.Text);

                                Score team2Score = CreateScore(_gameID, _currentTeam2, txtTeam2Score.Text);

                                updateScores.Add(team1Score);
                                updateScores.Add(team2Score);

                            }

                            // If at least one team was replaced, update accordingly
                            else if (_currentTeam1 != _oldTeam1 || _currentTeam2 != _oldTeam2)
                            {
                                // Check if team1 is not already in score table
                                if (!scores.Contains(_currentTeam1))
                                {
                                    Score team1Score = CreateScore(_gameID, _currentTeam1, txtTeam1Score.Text);

                                    if (_oldTeam1 != _currentTeam2) // Check what score needs to be replaced
                                    {
                                        _masterManager.GameManager.ReplaceGameScore(team1Score, _oldTeam1);
                                    }
                                    else
                                    {
                                        _masterManager.GameManager.ReplaceGameScore(team1Score, _oldTeam2);

                                    }
                                    updateScores.Add(team1Score);

                                }
                                else // Table already contains score. Create new score and add to update list
                                {
                                    Score team1Score = CreateScore(_gameID, _currentTeam1, txtTeam1Score.Text);

                                    updateScores.Add(team1Score);

                                }

                                // Check if team2 is not already in score table
                                if (!scores.Contains(_currentTeam2))
                                {
                                    Score team2Score = CreateScore(_gameID, _currentTeam2, txtTeam2Score.Text);

                                    if (_oldTeam2 != _currentTeam1) // Check what score needs to be replaced
                                    {
                                        _masterManager.GameManager.ReplaceGameScore(team2Score, _oldTeam2);
                                    }
                                    else
                                    {
                                        _masterManager.GameManager.ReplaceGameScore(team2Score, _oldTeam1);

                                    }
                                    updateScores.Add(team2Score);
                                }
                                else // Table contains score, create score and add to update list
                                {
                                    Score team2Score = CreateScore(_gameID, _currentTeam2, txtTeam2Score.Text);

                                    updateScores.Add(team2Score);
                                }
                            }

                            // Update score table
                            _masterManager.GameManager.EditGameScores(updateScores);

                            MessageBox.Show("Game has been Updated");
                            _pageControl.LoadPage(new pgGameList(_masterManager));
                        }
                    }
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method creates a score object with provided parameters
        /// </summary>
        private Score CreateScore(int game_id, int team_id, string score)
        {
            Score createScore = new Score();

            createScore.GameID = game_id;
            createScore.TeamID = team_id;
            if (score == null || score == "")
            {
                createScore.TeamScore = null;
            }
            else
            {
                if (score.Contains('.'))
                {
                    createScore.TeamScore = Convert.ToDecimal(score);
                }
                else
                {
                    createScore.TeamScore = Convert.ToInt32(score);
                }
            }
            return createScore;
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method closes window and discards changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var cancel = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButton.OKCancel);

            if (cancel == MessageBoxResult.OK)
            {
                _pageControl.LoadPage(new pgGameList(_masterManager));
            }
            if (cancel == MessageBoxResult.Cancel)
            {
                return;
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/08/04
        /// 
        /// Method updates the city and state information if entered zip code is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Updates state information when value changes
        private void txtZip_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                // retieve zip code details

                try
                {
                    if (int.TryParse(txtZip.Text, out int p))
                    {
                        Dictionary<string, object> zipcodeDetails = _masterManager.VenueManager.RetrieveZipCodeDetails(Convert.ToInt32(txtZip.Text));

                        if (zipcodeDetails != null || zipcodeDetails.Count > 0)
                        {
                            // Select city from hash table resutls
                            txtState.Text = zipcodeDetails["City"].ToString() + ", " + zipcodeDetails["State"].ToString();
                        }
                    }
                    else
                    {
                        txtZip.Text = "Invalid Zipcode";
                    }
                }
                catch (ApplicationException ae)
                {

                    if (ae.InnerException.Message == "Invalid zipcode")
                    {
                        txtZip.Text = "Invalid Zipcode";
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/04/08
        /// 
        /// Removed Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_editMode)
            {
                _deleteButton.Click -= DeleteButton_Click;
            }
        }
    }
}
