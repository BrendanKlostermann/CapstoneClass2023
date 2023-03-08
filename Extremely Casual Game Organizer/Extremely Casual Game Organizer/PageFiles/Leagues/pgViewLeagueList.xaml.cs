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
using LogicLayer;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgViewLeagueList.xaml
    /// </summary>
    public partial class pgViewLeagueList : Page
    {
        List<League> _leagues = null;
        List<LeagueGridVM> _leaguesGridVM = null;
        LeagueManager _leagueManager = null;
        List<LeagueGridVM> _leaguesForGrid = null;
        MasterManager _masterManager = null;
        PageControl _pageControl = new PageControl();

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
                _pageControl.ShowFullCRUD();


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
    _leagues = null;
    _leaguesGridVM = null;
    datLeagues.ItemsSource = null;
}
    }
}
