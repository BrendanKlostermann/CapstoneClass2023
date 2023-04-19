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
    /// This page will be used by the user to view league details, edit, and change registration
    /// 
    public partial class pgLeagueDetails : Page
    {
        League _league = null;
        Member _member = null;
        LeagueManager _leagueManager = new LeagueManager();
        PageControl _pageControl = new PageControl();
        List<Sport> _sports = new List<Sport>();
        List<League> _leagues;
        SportManager _sportManager = new SportManager();
        String _gender;
        public pgLeagueDetails()
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
        public pgLeagueDetails(League league, Member memberID)
        {
            _member = memberID;
            _league = league;
            InitializeComponent();
            populateContents();
            btnSave.Visibility = Visibility.Collapsed;
        }
        private void populateContents()
        {
            try
            {
                datCurrent.ItemsSource = _leagueManager.GetAListOfTeamsByLeagueID(_league.LeagueID);

            }
            catch (Exception)
            {
            }
            try
            {
                datRequest.ItemsSource = _leagueManager.RetrieveRequestsByLeagueID(_league.LeagueID);

            }
            catch (Exception)
            {

            }
            txtName.Text = _league.Name;
            txtDues.Text = _league.LeagueDues.ToString();
            sldDues.Value = (double)_league.LeagueDues;
            txtGame.Text = _sportManager.RetrieveSportBySportID(_league.SportID);
            string registration = "Registration Closed";
            if (_league.Active)
            {
                registration = "Registration Open";
            }
            txtStatus.Text = registration;
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

            if (_league.Active)
            {
                btnOpenCloseRegistration.Content = "Close Registration";
            }
            else
            {
                btnOpenCloseRegistration.Content = "Open Registration";
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete " + _league.Name, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _leagueManager.RemoveLeague(_league.LeagueID);
                    MessageBox.Show("League deletion successful");
                    _pageControl.LoadPage(new pgMyLeagues(_member, _leagueManager));
                }
                catch (Exception)
                {
                    MessageBox.Show("League deletion failed.");
                    _pageControl.LoadPage(new pgMyLeagues(_member, _leagueManager));
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            btnSave.Visibility = Visibility.Visible;
            btnOpenCloseRegistration.Visibility= Visibility.Hidden;
            string status = (string)btnOpenCloseRegistration.Content;
            _sports = _sportManager.RetrieveAllSports();
            List<String> sportNames = new List<string>();
            foreach (Sport sport in _sports)
            {
                sportNames.Add(sport.Description);
            }
            if (!txtDetails.IsReadOnly)
            {
                return;
            }

            List<String> statuses = new List<string>();
            statuses.Add("Open Registration");
            statuses.Add("Close Registration");

            List<String> genders = new List<string>();
            genders.Add("No Assignment");
            genders.Add("Male");
            genders.Add("Female");
            txtName.IsReadOnly = false;

            txtStatus.Visibility = Visibility.Collapsed;
            cboStatus.Visibility = Visibility.Visible;
            cboStatus.ItemsSource = statuses;
            cboStatus.SelectedItem = status;
            cboGender.Visibility = Visibility.Visible;
            cboGender.ItemsSource = genders;
            cboGender.SelectedItem = _gender;

            txtGender.Visibility = Visibility.Collapsed;
            txtDues.Text = _league.LeagueDues.ToString();
            sldDues.Visibility = Visibility.Visible;
            sldDues.Value = (double)_league.LeagueDues;
            txtDues.IsReadOnly = false;
            txtDetails.IsReadOnly = false;
            txtMax.IsReadOnly = false;
            btnSave.Visibility = Visibility.Visible;
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
            decimal leagueDues = 0.00M;
            bool? leagueGender = null;
            string leagueDescription = null;
            bool leagueStatus = true;
            string leagueName = null;
            int leagueMax = 0;


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
            if (txtName == null)
            {
                MessageBox.Show("Please enter the league name");
                return;
            }
            try
            {
                leagueDues = (decimal)Convert.ToDouble(txtDues.Text);
            }
            catch (Exception)
            {
                leagueDues = 0.00M;
            }
            if (cboStatus.SelectedItem != null)
            {
                if (cboStatus.SelectedItem.ToString().Equals("Close Registration"))
                {

                    leagueStatus = false;
                }
            }
            else
            {
                leagueStatus = _league.Active;
            }
            if (cboStatus.SelectedItem != null)
            {
                if (cboStatus.SelectedItem.ToString().Equals("Male"))
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
                LeagueID = _league.LeagueID,
                MemberID = _member.MemberID,
                LeagueDues = leagueDues,
                Gender = leagueGender,
                Description = leagueDescription,
                Name = leagueName,
                MaxNumOfTeams = leagueMax,
                Active = leagueStatus
            };
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Update a League", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _leagueManager.UpdateALeague(league);
                    MessageBox.Show("League update successful!");
                    btnSave.Visibility = Visibility.Hidden;
                    btnOpenCloseRegistration.Visibility = Visibility.Visible;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("League update failed.");
                    throw ex;
                }
            }
        }

        private void btnOpenCloseRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (btnOpenCloseRegistration.Content.ToString().Equals("Open Registration"))
            {
                _leagueManager.ChangeRegistration(_league.LeagueID, true);
                //retrieve by league id
                _leagues = _leagueManager.RetrieveLeagueListByMemberID(_member.MemberID);
                foreach (League league in _leagues)
                {
                    if (league.LeagueID == _league.LeagueID)
                    {
                        _league = league;
                    }
                }
                populateContents();
            }
            else
            {
                _leagueManager.ChangeRegistration(_league.LeagueID, false);
                _leagues = _leagueManager.RetrieveLeagueListByMemberID(_member.MemberID);
                foreach (League league in _leagues)
                {
                    if (league.LeagueID == _league.LeagueID)
                    {
                        _league = league;
                    }
                }
                populateContents();
            }
        }
    }
}
