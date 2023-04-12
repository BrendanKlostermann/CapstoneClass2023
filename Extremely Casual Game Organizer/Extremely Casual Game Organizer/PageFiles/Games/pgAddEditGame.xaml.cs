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
        int _team1 = 0;
        int _team2 = 0;
        GameRoster _team1Roster = null;
        GameRoster _team2Roster = null;
        List<TeamMember> _team1Members = null;
        List<TeamMember> _team2Members = null;
        int _memberID;

        public pgAddEditGame(MasterManager masterManager)
        {
            _masterManager = masterManager;
            _pageControl = new PageControl();
            _memberID = _pageControl.GetSignedInMember().MemberID;
            InitializeComponent();
            PopulateDetailOptions();
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

                    cmbSports.Items.Add(addItem);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnTeam1Search_Click(object sender, RoutedEventArgs e)
        {
            // ready serach window
            winTeamSearch teamSearch = new winTeamSearch(_masterManager);

            if (teamSearch.ShowDialog() == true)
            {
                listTeam1RosterList.Items.Clear();
                winTeamSearch wintoclose = (winTeamSearch)Application.Current.Windows.OfType<Window>().Where(x => x.Name == "windowTeamSearch").First();
                _team1 = wintoclose.SelectedTeamID;
                wintoclose.Close();

                try
                {
                    // Load team Roster
                    _team1Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(_team1);

                    // Set Team Name
                    txtTeam1.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(_team1).TeamName;

                    // Get member info for each team roster member
                    List<Member> teamMemberList = new List<Member>();

                    foreach (var member in _team1Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        teamMemberList.Add(searchMember);
                    }

                    // Load roster list.
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

                        TextBlock posText = new TextBlock { Text = _team1Members.Where(x => x.MemberID == member.MemberID).First().Description };

                        // Add Text Block to Position Dock Panel
                        dockPanelPos.Children.Add(posLabel);
                        dockPanelPos.Children.Add(posText);
                        dockPanelPos.Children.Add(new TextBlock { Text = "\n" }); // Additional space in list box

                        // Add Dock Panels to Stack Panel
                        stackPanel.Children.Add(dockPanelName);
                        stackPanel.Children.Add(dockPanelPos);


                        // Set List View source to Stack Panel
                        listTeam1RosterList.Items.Add(stackPanel);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void btnTeam2Search_Click(object sender, RoutedEventArgs e)
        {
            // ready serach window
            winTeamSearch teamSearch = new winTeamSearch(_masterManager);

            if (teamSearch.ShowDialog() == true)
            {
                listTeam2RosterList.Items.Clear();
                winTeamSearch wintoclose = (winTeamSearch)Application.Current.Windows.OfType<Window>().Where(x => x.Name == "windowTeamSearch").First();
                _team2 = wintoclose.SelectedTeamID;
                wintoclose.Close();

                try
                {
                    // Load team Roster
                    // Get team roster
                    _team2Members = _masterManager.TeamMemberManager.RetrieveTeamRosterByTeamID(_team2);

                    // Set Team Name
                    txtTeam2.Content = _masterManager.TeamManager.RetrieveTeamByTeamID(_team2).TeamName;

                    // Get member info for each team roster member
                    List<Member> teamMemberList = new List<Member>();

                    foreach (var member in _team2Members)
                    {
                        Member searchMember = _masterManager.MemberManager.GetMemberByMemberID(member.MemberID);

                        teamMemberList.Add(searchMember);
                    }

                    // Load roster list.
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

                        TextBlock posText = new TextBlock { Text = _team2Members.Where(x => x.MemberID == member.MemberID).First().Description };

                        // Add Text Block to Position Dock Panel
                        dockPanelPos.Children.Add(posLabel);
                        dockPanelPos.Children.Add(posText);
                        dockPanelPos.Children.Add(new TextBlock { Text = "\n" }); // Additional space in list box

                        // Add Dock Panels to Stack Panel
                        stackPanel.Children.Add(dockPanelName);
                        stackPanel.Children.Add(dockPanelPos);


                        // Set List View source to Stack Panel
                        listTeam2RosterList.Items.Add(stackPanel);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void btnSaveAdd_Click(object sender, RoutedEventArgs e)
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
                if (dateGameDate != null && dateGameDate.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Game data cannot be before the current date");
                    dateGameDate.SelectedDate = null;
                    dateGameDate.Focus();
                    return;
                }
                if (cmboTimeHour.SelectedItem == null || cmboTimeMinutes.SelectedItem == null || cmboAMPM == null)
                {
                    MessageBox.Show("You need to select a time for the game");
                    cmboTimeHour.Focus();
                    return;
                }
                if (cmbSports.SelectedItem == null)
                {
                    MessageBox.Show("You need to select a sport type for the game");
                    cmbSports.Focus();
                    return;
                }

                // Check if Venue already exists, if not create new venue. 
                string searchText = txtStreet.Text.ToLower().Trim();
                List<Venue> venueList = _masterManager.VenueManager.RetrieveAllVenues();

                // Venue should consist of street and zip
                var existingVenue = venueList.Where(x => x.Location.ToLower().Trim() == searchText && x.ZipCode.ToString().Equals(txtZip.Text));

                if (existingVenue.Count() > 0)
                {
                    MessageBox.Show("Provided Venue already exists. Game will reference existing venue","Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtVenueName.Text = existingVenue.First().VenueName;
                    txtVenueName.IsReadOnly = true;
                }
                else
                {
                    // Create new Venue

                }

                // Create new game object for creation
                Game newGame = new Game();
                if (_team1 == 0)
                {
                    MessageBox.Show("Select a team for team 1");
                    btnTeam1Search.Focus();
                }
                if (_team2 == 0)
                {
                    MessageBox.Show("Select a team for team 2");
                    btnTeam2Search.Focus();
                }
                if (_team1 != 0 && _team2 != 0)
                {
                    // Create Game.
                    int createGame = _masterManager.GameManager.AddGame(newGame, _memberID);

                    // Create Game Roster Entries

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

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
    }
}
