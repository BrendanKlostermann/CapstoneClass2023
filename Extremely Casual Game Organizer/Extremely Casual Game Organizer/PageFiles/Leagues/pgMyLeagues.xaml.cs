using DataObjects;
using LogicLayer;
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

namespace Extremely_Casual_Game_Organizer.PageFiles.Leagues
{
    /// <summary>
    /// Rith
    /// 
    /// This page will be used by the user to view the leagues they own
    /// 
    public partial class pgMyLeagues : Page
    {
        Member _member = null;
        List<League> _leagues = null;
        List<League> _myLeagues = new List<League>();
        LeagueManager _leagueManager = null;
        PageControl _pageControl = new PageControl();
        public pgMyLeagues(Member member, LeagueManager leagueManager)
        {
            InitializeComponent();
            _member = member;
            _leagueManager = leagueManager;
            List<League> _leagues = _leagueManager.RetrieveLeagueListByMemberID(_member.MemberID);

            datLeagues.ItemsSource = _leagues;

        }
        private void datLeagues_Loaded(object sender, RoutedEventArgs e)
        {
            // Create Gender List
            List<string> genders = new List<string>();
            foreach (var league in _leagues)
            {
                if (league.Gender == true)
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


            datLeagues.Columns.RemoveAt(0);
            datLeagues.Columns.RemoveAt(0);
            datLeagues.Columns.RemoveAt(1);
            datLeagues.Columns.RemoveAt(1);
            datLeagues.Columns.RemoveAt(0);


            //Edit Columns
            datLeagues.Columns[3].Header = "Max Number of Players";
            datLeagues.Columns[2].DisplayIndex = 0;

        }

        private void datLeagues_Unloaded(object sender, RoutedEventArgs e)
        {
            _leagues = null;
            datLeagues.ItemsSource = null;
        }


        private void datLeagues_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            League league = (League)datLeagues.SelectedItem;
            if (league != null)
            {
                _pageControl.LoadPage(new pgLeagueDetails(league, _member));
            }
        }

    }
}
