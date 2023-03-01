/// /// <summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Page file and methods for the Game List view page.
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
    public partial class pgGameList : Page
    {
        MasterManager _masterManager = null;
        PageControl _pageControl = null;
        Button _viewButton = null;
        DataRowView _selectedItem = null;
        public pgGameList(MasterManager masterManager)
        {
            _masterManager = masterManager;
            _pageControl = new PageControl();

            InitializeComponent();
            LoadGameList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Page loaded event. Need to create click event for the view button.
            /// </summary>

            // Load buttons
            _viewButton = _pageControl.ShowReadOnly();

            // Need to set button the ability to be clicked.
            _viewButton.Click += ViewButton_Click;
        }

        private void LoadGameList()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Method for generating the game list.
            /// </summary>

            DataTable gameList = _masterManager.GameManager.ViewAllGames();

            // Data Grid Properties
            datGameList.AutoGenerateColumns = false;
            datGameList.Focusable = false;
            datGameList.IsReadOnly = true;


            //// In order to hide the first column (which the game_id is needed but does not need to be visible) each column needs to be set manually.
            DataGridTextColumn column1 = new DataGridTextColumn();
            // Binding is determined from column names returned from stored procedure
            column1.Binding = new Binding("game_id");
            column1.Header = "game_id";
            column1.Visibility = Visibility.Hidden;
            datGameList.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Binding = new Binding("Teams");
            column2.Header = "Teams";
            column2.Width = new DataGridLength(200);
            datGameList.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Binding = new Binding("Location");
            column3.Width = new DataGridLength(400);
            column3.Header = "Location";
            datGameList.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Binding = new Binding("Date and Time");
            column4.Width = new DataGridLength(160);
            column4.Header = "Date and Time";
            datGameList.Columns.Add(column4);

            datGameList.ItemsSource = gameList.DefaultView;
        }

        private void datGameList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Grid double click event. Displays game details page for selected game.
            /// </summary>
            try
            {
                _selectedItem = (DataRowView)datGameList.SelectedItem;

                if (_selectedItem == null)
                {
                    MessageBox.Show("Please select an item");
                }
                else
                {
                    int gameID = Convert.ToInt32(_selectedItem["game_id"]);

                    // Prepare page to be loaded
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                    _pageControl.LoadPage(viewGame, new pgGameList(_masterManager));
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);

            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// View button click event
            /// </summary>
            try
            {

                if (datGameList.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item");
                }
                else
                {

                    DataRowView selectedItem = (DataRowView)datGameList.SelectedItem;

                    // Retieve GameID from Row (Should be first column)
                    int gameID = Convert.ToInt32(selectedItem["game_id"]);

                    // Get Selected Row
                    selectedItem = (DataRowView)datGameList.SelectedItem;

                    // Create Managers to process next page.
                    TeamManager teamManager = new TeamManager();
                    GameRosterManager gameRosterManager = new GameRosterManager();
                    GameManager gameManager = new GameManager();

                    // Prepare page to be loaded
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                    _pageControl.LoadPage(viewGame, new pgGameList(_masterManager));

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
            }

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Page unload evnet to remove click events from occurring should we navigate back to this page.
            /// If this is not done the click event will loop on themselves if you navigate back to this page. 
            /// </summary>

            // Remove previous click events to avoid event loops
            _viewButton.Click -= ViewButton_Click;
        }
    }
}
