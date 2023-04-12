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
        Button _updateButton = null;
        Button _createButton = null;
        Button _deleteButton = null;
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
            var buttons = _pageControl.ShowFullCRUD();
            _createButton = buttons[0];
            _viewButton = buttons[1];
            _updateButton = buttons[2];
            _deleteButton = buttons[3];

            // Need to set button the ability to be clicked.
            _viewButton.Click += ViewButton_Click;
            _createButton.Click += CreateButton_Click;
            _updateButton.Click += UpdateButton_Click;
            _deleteButton.Click += DeleteButton_Click;
        }

        private void LoadGameList()
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// Method for generating the game list.
            /// 
            /// Udpated By: Jacob Lindauer
            /// Date: 2023/04/04
            /// 
            /// Updated game list to be a listbox instead of data table for better formatting
            /// </summary>
            try
            {
                DataTable gameList = _masterManager.GameManager.ViewAllGames();

                foreach (var game in gameList.AsEnumerable())
                {
                    ListBoxItem addGame = new ListBoxItem();
                    addGame.BorderBrush = Brushes.Black;
                    addGame.Margin = new Thickness(5);
                    addGame.Width = 765;
                    addGame.Height = 50;
                    addGame.DataContext = game[0];


                    TextBlock sportText = new TextBlock()
                    {
                        Text = game[1].ToString(),
                        Width = 230
                    };

                    TextBlock boldLocation = new TextBlock()
                    {
                        Text = "@ ",
                        FontWeight = FontWeights.Bold,
                    };

                    TextBlock locationText = new TextBlock()
                    {
                        Text = game[2].ToString(),
                        Width = 340
                    };

                    TextBlock dateTitle = new TextBlock()
                    {
                        Text = "Date: ",
                        FontWeight = FontWeights.Bold
                    };

                    TextBlock dateText = new TextBlock()
                    {
                        Text = game[3].ToString(),
                        Width = 230
                    };

                    DockPanel gameListItem = new DockPanel();

                    gameListItem.Children.Add(sportText);
                    gameListItem.Children.Add(boldLocation);
                    gameListItem.Children.Add(locationText);
                    gameListItem.Children.Add(dateTitle);
                    gameListItem.Children.Add(dateText);

                    addGame.Content = gameListItem;

                    lstGameList.Items.Add(addGame);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException);
            }
        }
        private void lstGameList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /// <summary>
            /// Created By: Jacob Lindauer
            /// Date: 02/15/2023
            /// 
            /// View button click event
            /// </summary>
            try
            {

                if (lstGameList.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item");
                }
                else
                {

                    ListBoxItem selectedItem = (ListBoxItem)lstGameList.SelectedItem;

                    // Retieve GameID from Row (Should be first column)
                    int gameID = (int)selectedItem.DataContext;

                    // Prepare page to be loaded
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                    _pageControl.LoadPage(viewGame, new pgGameList(_masterManager));

                }
            }
            catch(Exception ex)
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

                if (lstGameList.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item");
                }
                else
                {

                    ListBoxItem selectedItem = (ListBoxItem)lstGameList.SelectedItem;

                    // Retieve GameID from Row (Should be first column)
                    int gameID = (int)selectedItem.DataContext;

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
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
            _createButton.Click -= CreateButton_Click;
            _updateButton.Click -= UpdateButton_Click;
            _deleteButton.Click -= DeleteButton_Click;
        }
    }
}
