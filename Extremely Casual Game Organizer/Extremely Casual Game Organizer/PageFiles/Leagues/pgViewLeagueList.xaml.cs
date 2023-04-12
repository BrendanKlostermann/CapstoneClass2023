/// <summary>
/// Brendan Klostermann
/// Created: 2023/01/31
/// 
/// This page will be used to display the list of leagues from the database
/// and allow further actions upon the list.
/// 
/// .cs file attached to pgViewLeagueList.
/// </summary>
///

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
using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles;
using Extremely_Casual_Game_Organizer.PageFiles.Leagues;
using LogicLayer;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgViewLeagueList.xaml
    /// </summary>
    public partial class pgViewLeagueList : Page
    {
        List<League> _leagues = null;
        Member _member = null;
        List<LeagueGridVM> _leaguesGridVM = null;
        LeagueManager _leagueManager = null;
        List<LeagueGridVM> _leaguesForGrid = null;
        MasterManager _masterManager = null;
        PageControl _pageControl = new PageControl();
        Button _myLeaguesButton;
        Button _addButton;

        public pgViewLeagueList(MasterManager masterManager)
        {
            InitializeComponent();
            _masterManager = masterManager;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// this method will load the list of leagues and display them in a datagrid.
        /// It will call the LeagueManager method RetrieveListOfLeagues.
        /// 
        /// </summary>
        /// 
        private void datLeagues_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _member = _pageControl.GetSignedInMember();
                if (_member != null)
                {
                    _addButton = _pageControl.SetCustomButton("Add new", 1);
                    _myLeaguesButton = _pageControl.SetCustomButton("My Leagues", 2);
                    _addButton.Click += AddButton_Click;
                    _myLeaguesButton.Click += MyLeaguesButton_Click;
                }

                if (_leaguesForGrid == null)
                {

                    _leaguesForGrid = new List<LeagueGridVM>();
                    _leaguesForGrid = _masterManager.LeagueManager.RetrieveListOfLeaguesForGrid();

                    datLeagues.ItemsSource = _leaguesForGrid;


                    ////Remove data users do not need, maybe switch to using a ViewModel?
                    //// Might need to edit data objects to allow league to hold Sport Description as well
                    //// that way user know what sport it is.

                    datLeagues.Columns.RemoveAt(0);
                    datLeagues.Columns.RemoveAt(5);

                    datLeagues.Columns[2].Header = "Sport";
                    datLeagues.Columns[3].Header = "Owner";

                    datLeagues.Columns[1].DisplayIndex = 4;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/02/20
        /// 
        /// When the page is unloaded it will clear out the league list and clear the item
        /// source of the datagrid to ensure they are empty and ready for next time it is loaded.
        /// </summary>
        /// 
        private void datLeagues_Unloaded(object sender, RoutedEventArgs e)
        {
            
            _leaguesGridVM = null;
            datLeagues.ItemsSource = null;
            if (_member!=null)
            {
                _addButton.Click -= AddButton_Click;
                _myLeaguesButton.Click -= MyLeaguesButton_Click;
            }
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// When a item on the datLeagues data grid is selected, the 
        /// selected item becomes the current League object. This is
        /// used later when the data from this league is populated 
        /// in the pgAddEditLeague page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Made by Elijah Morgan
        private void datLeagues_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var leagueGridVM = (LeagueGridVM)datLeagues.SelectedItem;

            if(_leagueManager == null)
            {
                _leagueManager = new LeagueManager();
            }

            League league = null;
            try
            {
                league = _leagueManager.RetrieveLeagueByLeagueID(leagueGridVM.LeagueID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("League not found." + "\n\n" + ex.Message);
            }

            pgAddEditLeague selectedLeague = new pgAddEditLeague(league);

            PageControl pageController = new PageControl();
            pageController.LoadPage(selectedLeague);
            var editWindow = new pgAddEditLeague(league); // use a constructor that takes a league argument
        }
        private void MyLeaguesButton_Click(object sender, RoutedEventArgs e)
        {

            _pageControl.LoadPage(new pgMyLeagues(_pageControl.GetSignedInMember(), new LeagueManager()));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgAddLeague(_pageControl.GetSignedInMember(), new LeagueManager(), new SportManager()));
        }

    }
}

