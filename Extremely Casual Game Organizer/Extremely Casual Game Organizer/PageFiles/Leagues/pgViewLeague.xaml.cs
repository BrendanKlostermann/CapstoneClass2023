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
    /// Interaction logic for pgViewLeague.xaml
    /// </summary>
    public partial class pgViewLeague : Page
    {
        League _league = null;
        Member _member = null;
        LeagueManager _leagueManager = new LeagueManager();
        PageControl _pageControl = new PageControl();
        List<Sport> _sports = new List<Sport>();
        List<League> _leagues;
        SportManager _sportManager = new SportManager();
        String _gender;
        public pgViewLeague()
        {
            _league = new League()
            {
                LeagueID = 1000000,
                Name = "Example"
            };
            _member = new Member()
            {
                MemberID = 1000000
            };
            InitializeComponent();
            populateContents();
        }
        public pgViewLeague(League league, Member memberID)
        {
            _member = memberID;
            _league = league;
            InitializeComponent();
            populateContents();
        }
        private void populateContents()
        {
            if (_member == null || !_league.Active)
            {
                btnRequest.Visibility = Visibility.Hidden;
            }
            txtName.Text = _league.Name;
            txtDues.Text = _league.LeagueDues.ToString();
            txtGame.Text = _sportManager.RetrieveSportBySportID(_league.SportID);
            _gender = "No Assignment";
            if (_league.Gender == true)
            {
                _gender = "Male";
            }
            else if (_league.Gender == false)
            {
                _gender = "Female";
            }
            txtGender.Text = _gender;
            txtMax.Text = _league.MaxNumOfTeams.ToString();
            txtDetails.Text = _league.Description;


        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
