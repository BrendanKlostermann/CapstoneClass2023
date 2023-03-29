///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Class file and Methods for populating data for the Game Details Page
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
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
using LogicLayer;
using DataObjects;
using System.Data;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    public partial class pgViewGameDetails : Page
    {
        MasterManager _masterManager = null;
        Button _backButton = null;
        int _game_id;
        PageControl _pageControl = null;
        public pgViewGameDetails(int game_id, MasterManager masterManager)
        {
            _game_id = game_id;

            _masterManager = masterManager;

            _pageControl = new PageControl();

            InitializeComponent();
        }
        private void pageViewGameDetails_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Loaded event. Need to set the back button and click event for the button. 
            /// </summary>
            _backButton = _pageControl.ShowGoBack();
            _backButton.Click += BackButton_Click;

            LoadRosterData();
            LoadGameDetails();
        }

        private void LoadGameDetails()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Method for loading game details from based on values provided in constructor when class file was called. 
            /// </summary>
            
            DataRow details = _masterManager.GameManager.ViewGameDetails(_game_id);

            // Method to parse location to correct format.
            // details [1] 222 roadName st, IA
            // details [2] City Name
            // details [3] ZIP
            string[] locationString = details[1].ToString().Split(',');
            string locationFormatted = locationString[0].ToString() + ", " + details[2].ToString()
                    + ", " + locationString[1] + " " + details[3].ToString();
            txtLocation.Text = locationFormatted;
            txtVenueName.Text = details[4].ToString();
            txtDate.Text = Convert.ToDateTime(details[4]).ToShortDateString();
            txtTime.Text = Convert.ToDateTime(details[4]).ToShortTimeString();
            txtSport.Text = details[5].ToString();
        }

        private void LoadRosterData()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Method for loading roster details from based teams participating in the selected game
            /// 
            /// Udpated By: Jacob Lindauer
            /// Date: 2023/28/03
            /// 
            /// Updated Method to apply player position in roster details
            /// </summary>
            
            try
            {
                Team team1 = new Team();
                Team team2 = new Team();

                // Linq query to get teams that are attached to game roster
                var teams = _masterManager.GameRosterManager.RetrieveGameRoster(_game_id).Select(x => x.TeamID).Distinct();
                teams.ToList();

                // ONLY expecting 2 results from this per game.
                team1 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.First());

                team2 = _masterManager.TeamManager.RetrieveTeamByTeamID(teams.Last());

                // Populate Team Name Boxes
                txtTeam1.Content = team1.TeamName;
                txtTeam2.Content = team2.TeamName;


                // Need 2 more Linq query to obtain roster list
                var team1PlayerQuery = from player in _masterManager.GameRosterManager.RetrieveGameRoster(_game_id) where player.TeamID.Equals(team1.TeamID) select player;

                var team2PlayerQuery = from player in _masterManager.GameRosterManager.RetrieveGameRoster(_game_id) where player.TeamID.Equals(team2.TeamID) select player;

                // Need to loop through player lists and add those items to the list items.
                foreach (var player in team1PlayerQuery)
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
                    TextBlock memberName = new TextBlock { Text = player.FirstName + " " + player.LastName };

                    // Add Text Block to Name Dock Panel
                    dockPanelName.Children.Add(nameLabel);
                    dockPanelName.Children.Add(memberName);

                    // Get Position from Member team information.
                    TextBlock posLabel = new TextBlock();
                    posLabel.FontWeight = FontWeights.Bold;
                    posLabel.Text = "Position: ";

                    TextBlock posText = new TextBlock { Text = player.Description};

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

                // Do the same loop for other team list view
                foreach (var player in team2PlayerQuery)
                {
                    // Create Dock Panel template for list view item addition.
                    // Need to create 2 dock panel to add to a stack panel. One for Name and one for Position.
                    DockPanel dockPanelName = new DockPanel();
                    DockPanel dockPanelPos = new DockPanel();

                    StackPanel stackPanel = new StackPanel();

                    // Create Text Blocks to add to Dock Panel
                    TextBlock nameLabel = new TextBlock();
                    nameLabel.FontWeight = FontWeights.Bold;
                    nameLabel.Text = "Name: ";

                    // Get Member name from Game Roster.
                    TextBlock memberName = new TextBlock { Text = player.FirstName + " " + player.LastName };

                    // Add Text Block to Name Dock Panel
                    dockPanelName.Children.Add(nameLabel);
                    dockPanelName.Children.Add(memberName);

                    // Get Position from Member team information
                    TextBlock posLabel = new TextBlock();
                    posLabel.FontWeight = FontWeights.Bold;
                    posLabel.Text = "Position: ";

                    TextBlock posText = new TextBlock { Text = player.Description };

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
                return;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Click event for back button. Instead of doing GoBack on the frame loader 
            /// we want to load the last page instead so that its buttons are generated correctly.
            /// 
            /// Updated by: Jacob Lindauer
            /// Date: 2023/02/27
            /// 
            /// Updated back button method to go back to previous page instead of game list details. 
            /// </summary>
            /// 

            // Need to get Previous page.
            Page previousPage = _pageControl.GetPreviousPage();
            _pageControl.LoadPage(previousPage);
        }
    }
}

