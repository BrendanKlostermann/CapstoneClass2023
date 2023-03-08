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
using static DataObjects.League;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgViewLeagueList.xaml
    /// </summary>
    public partial class pgViewLeagueList : Page
    {
        List<League> _leagues = null;
        LeagueManager _leagueManager = null;

        public pgViewLeagueList()
        {
            InitializeComponent();
            _leagueManager = new LeagueManager();
        }

        private void datLeagues_Loaded(object sender, RoutedEventArgs e)
        {
            if(_leagues == null)
            {
                _leagues = new List<League>();
                _leagues = _leagueManager.RetrieveListOfLeagues();



                // Create Gender List
                List<string> genders = new List<string>();
                foreach(var league in _leagues)
                {
                    if(league.Gender == true)
                    {
                        genders.Add("Male");
                    }
                    if (league.Gender == false)
                    {
                        genders.Add("Female");
                    }
                    else
                    {
                        genders.Add("Unassigned");
                    }
                }

                datLeagues.ItemsSource = _leagues;



                //Remove data users do not need, maybe switch to using a ViewModel?
                // Might need to edit data objects to allow league to hold Sport Description as well
                //      that way user know what sport it is.

                datLeagues.Columns.RemoveAt(0);
                datLeagues.Columns.RemoveAt(0);
                datLeagues.Columns.RemoveAt(1);
                datLeagues.Columns.RemoveAt(1);
                datLeagues.Columns.RemoveAt(0);

                //Edit Columns
                datLeagues.Columns[3].Header = "Max Number of Players";
                datLeagues.Columns[2].DisplayIndex = 0;
                
            }
        }

        private void datLeagues_Unloaded(object sender, RoutedEventArgs e)
        {
            _leagues = null;
            datLeagues.ItemsSource = null;
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
            var league = (League)datLeagues.SelectedItem;

            pgAddEditLeague selectedLeague = new pgAddEditLeague(league);

            PageControl pageController = new PageControl();
            pageController.LoadPage(selectedLeague);
            var editWindow = new pgAddEditLeague(league); // use a constructor that takes a league argument
        }
    }
}
