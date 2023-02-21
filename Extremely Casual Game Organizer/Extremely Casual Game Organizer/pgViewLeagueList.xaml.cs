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
using LogicLayer;

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
            datLeagues.ItemsSource = null;
        }
    }
}
