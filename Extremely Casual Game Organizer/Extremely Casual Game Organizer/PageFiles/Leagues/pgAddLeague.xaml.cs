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
    /// This page will be used by the user to add a league
    /// 
    public partial class pgAddLeague : Page
    {
        Member _member = null;
        LeagueManager _leagueManager = null;
        SportManager _sportManager = null;
        List<Sport> _sports = new List<Sport>();
        List<string> _sportDescriptions = new List<string>();
        List<string> _gender = new List<string>();
        PageControl _pageControl = new PageControl();
        public pgAddLeague(Member member, LeagueManager leagueManager, SportManager sportManager)
        {
            _member = member;
            _leagueManager = leagueManager;
            _sportManager = sportManager;
            InitializeComponent();
            getSports();
            getGenders();


        }
        public pgAddLeague()
        {
            _member = new Member
            {
                MemberID = 100000
            };
            _leagueManager = new LeagueManager();
            _sportManager = new SportManager();
            InitializeComponent();
            getSports();
            getGenders();
            txtDues.Text = "0.00";
        }

        private void getSports()
        {
            _sports = _sportManager.RetrieveAllSports();

            foreach (Sport sport in _sports)
            {
                _sportDescriptions.Add(sport.Description);
            }
            cboGame.ItemsSource = _sportDescriptions;
            cboGame.SelectedIndex = -1;
        }
        private void getGenders()
        {
            _gender.Add("Male");
            _gender.Add("Female");
            _gender.Add("No Specification");
            cboGender.ItemsSource = _gender;
            cboGender.SelectedIndex = -1;
        }
        private void sldDues_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sldDues.Value == 200)
            {
                return;
            }
            decimal value = Convert.ToDecimal(sldDues.Value);
            decimal roundedValue = Math.Round(value * 100) / 100;
            txtDues.Text = roundedValue.ToString();
        }

        private void txtDues_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtDues.Text == null)
                {
                    sldDues.Value = 0;
                }
                if (Convert.ToDecimal(txtDues.Text) > 200)
                {
                    sldDues.Value = 200;
                    return;
                }
                else
                {
                    sldDues.Value = Convert.ToDouble(txtDues.Text);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int leagueSportID = 0;
            decimal leagueDues = 0.00M;
            int leagueCreatorID = _member.MemberID;
            bool? leagueGender = null;
            string leagueDescription = null;
            string leagueName = null;
            int leagueMax = 0;


            if (cboGame.SelectedItem == null)
            {
                MessageBox.Show("Please enter the sport type");
                return;
            }
            if (txtDues.Text.Equals(null))
            {
                MessageBox.Show("Please enter the game type");
                return;
            }
            if (txtMax.Text != null)
            {
                try
                {
                    leagueMax = Convert.ToInt32(txtMax.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid max number of teams");
                    return;
                }
            }
            if (txtName.Text.Equals(null) || txtName.Text.Equals(""))
            {
                MessageBox.Show("Please enter the league name");
                return;
            }
            foreach (Sport sport in _sports)
            {
                if (cboGame.SelectedItem.ToString().Equals(sport.Description))
                {
                    leagueSportID = sport.SportId;
                }
            }
            try
            {
                leagueDues = (decimal)Convert.ToDouble(txtDues.Text);
            }
            catch (Exception)
            {
                leagueDues = 0.00M;
            }
            if (cboGender.SelectedItem != null)
            {
                if (cboGender.SelectedItem.ToString().Equals("Male"))
                {
                    leagueGender = true;
                }
                else
                {
                    leagueGender = false;
                }
            }
            leagueDescription = txtDetails.Text;
            leagueName = txtName.Text;
            League league = new League
            {
                SportID = leagueSportID,
                LeagueDues = leagueDues,
                MemberID = leagueCreatorID,
                Gender = leagueGender,
                Description = leagueDescription,
                Name = leagueName,
                MaxNumOfTeams = leagueMax,
                Active = true
            };
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Create a League", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _leagueManager.AddLeague(league);
                    MessageBox.Show("League creation successful!");
                    _pageControl.LoadPage(new pgMyLeagues(_pageControl.GetSignedInMember(), new LeagueManager()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("League creation failed.");
                    throw ex;
                }
            }
        }
    }
}

