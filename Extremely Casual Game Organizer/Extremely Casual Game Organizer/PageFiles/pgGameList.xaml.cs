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
    /// <summary>
    /// Interaction logic for pgGameList.xaml
    /// </summary>
    public partial class pgGameList : Page
    {
        GameManager _gameManager = null;
        PageControl _pageControl = null;
        Button _viewButton = null;
        DataRowView _selectedItem = null;
        public pgGameList(GameManager gameManager)
        {
            _gameManager = gameManager;
            _pageControl = new PageControl();

            InitializeComponent();
            LoadGameList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Load buttons
            _viewButton = _pageControl.ShowReadOnly();

            // Need to set button the ability to be clicked.
            _viewButton.Click += ViewButton_Click;
        }

        private void LoadGameList()
        {
            DataTable gameList = _gameManager.ViewAllGames();

            // Data Grid Properties
            datGameList.AutoGenerateColumns = false;
            datGameList.Focusable = false;
            datGameList.IsReadOnly = true;


            // In order to hide the first column (which the game_id is needed but does not need to be visible) each column needs to be set manually.

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Binding = new Binding("game_id");
            column1.Header = "game_id";
            column1.Visibility = Visibility.Hidden;
            datGameList.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Binding = new Binding("Teams");
            column2.Header = "Teams";
            column2.Width = new DataGridLength(300);
            datGameList.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Binding = new Binding("Location");
            column3.Width = new DataGridLength(300);
            column3.Header = "Location";
            datGameList.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Binding = new Binding("Date and Time");
            column4.Width = new DataGridLength(183);
            column4.Header = "Date and Time";
            datGameList.Columns.Add(column4);


            datGameList.ItemsSource = gameList.DefaultView;
        }

        private void datGameList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _selectedItem = (DataRowView)datGameList.SelectedItem;

                int gameID = Convert.ToInt32(_selectedItem["game_id"]);

                TeamManager teamManager = new TeamManager();
                GameRosterManager gameRosterManager = new GameRosterManager();
                GameManager gameManager = new GameManager();

                // Prepare page to be loaded
                pgViewGameDetails viewGame = new pgViewGameDetails(gameID, gameManager, teamManager, gameRosterManager);

                _pageControl.LoadPage(viewGame);
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
                
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
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
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, gameManager, teamManager, gameRosterManager);

                    _pageControl.LoadPage(viewGame);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
            }

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
             // Remove previous click events just in case. 
            _viewButton.Click -= ViewButton_Click;

            // Set selected item to null
            _selectedItem = null;
        }
    }
}
