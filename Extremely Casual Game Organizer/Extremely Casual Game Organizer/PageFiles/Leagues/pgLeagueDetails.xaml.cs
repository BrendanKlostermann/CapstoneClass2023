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
        MemberManager _memberManager = new MemberManager();
        PageControl _pageControl = new PageControl();
        List<Sport> _sports = new List<Sport>();
        List<League> _leagues;
        SportManager _sportManager = new SportManager();
        String _gender;
        LeagueRequestVM _leagueRequestVM;
        LeagueRequest _leagueRequest;
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
            btnAccept.Visibility = Visibility.Collapsed;
            btnDecline.Visibility = Visibility.Collapsed;
        }

        public List<Team.TeamVM> getTeamVM()
        {

            List<Team> teams;
            List<Team.TeamVM> teamVMs;
            try
            {
                teams = _leagueManager.GetAListOfTeamsByLeagueID(_league.LeagueID);
                teamVMs = new List<Team.TeamVM>();
            }
            catch
            {
                return null;
            }
            foreach (var team in teams)
            {
                Team.TeamVM teamVM = new Team.TeamVM();
                teamVM.TeamID = team.TeamID;
                teamVM.TeamName = team.TeamName;
                teamVM.Gender = team.Gender;
                teamVM.SportID = team.SportID;
                teamVM.Description = team.Description;
                teamVM.MemberID = team.MemberID;
                if (_memberManager.GetMembers() != null)
                {
                    foreach (var member in _memberManager.GetMembers())
                    {
                        if (member.MemberID == team.MemberID)
                        {
                            teamVM.FirstName = member.FirstName;
                            teamVM.LastName = member.FamilyName;
                            if (member.Gender == true)
                            {
                                teamVM.GenderAsText = "M";
                            }
                            else if (member.Gender == false)
                            {
                                teamVM.GenderAsText = "F";
                            }
                            else
                            {
                                teamVM.GenderAsText = "NB";
                            }
                        }
                    }
                }
                teamVMs.Add(teamVM);
            }
            return teamVMs;
        }
        private void populateContents()
        {
            _league = _leagueManager.RetrieveLeagueByLeagueID(_league.LeagueID);
            List<Team.TeamVM> VMs = getTeamVM();
            datCurrent.ItemsSource = VMs;
            try
            {
                List<LeagueRequest> requests = _leagueManager.RetrieveRequestsByLeagueID(_league.LeagueID);
                datRequest.ItemsSource = _leagueManager.RetrieveLeagueRequestVMs(requests);
                datRequest.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception)
            {

            }
            cboGender.Visibility = Visibility.Collapsed;
            txtGender.Visibility = Visibility.Visible;
            cboStatus.Visibility = Visibility.Collapsed;
            txtStatus.Visibility = Visibility.Visible;
            txtName.Text = _league.Name;
            txtName.IsReadOnly = true;
            txtDues.Text = _league.LeagueDues.ToString();
            txtDues.IsReadOnly = true;
            sldDues.Visibility = Visibility.Hidden;
            txtGame.Text = _sportManager.RetrieveSportBySportID(_league.SportID);
            string registration = "Registration Closed";
            if (_league.Active)
            {
                registration = "Registration Open";
            }
            txtStatus.Text = registration;
            txtStatus.IsReadOnly = true;
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
            txtMax.IsReadOnly = true;
            txtDetails.Text = _league.Description;
            txtDetails.IsReadOnly = true;

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
                    _leagueManager.ChangeRegistration(_league.LeagueID, false);
                    MessageBox.Show("League inactivation successful");
                    _pageControl.LoadPage(new pgMyLeagues(_member, _leagueManager));
                }
                catch (Exception)
                {
                    MessageBox.Show("League inactivation failed.");
                    _pageControl.LoadPage(new pgMyLeagues(_member, _leagueManager));
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            btnSave.Visibility = Visibility.Visible;
            btnOpenCloseRegistration.Visibility = Visibility.Hidden;
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
            cboGender.SelectedItem = txtGender.Text.ToString();
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
            if (cboGender.SelectedItem != null)
            {
                if (cboGender.SelectedItem.ToString().Equals("Male"))
                {
                    leagueGender = true;
                }
                else
                {
                    if (cboGender.SelectedItem.ToString().Equals("Female"))
                    {
                        leagueGender = false;
                    }
                    else
                    {
                        leagueGender = null;
                    }
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
                Active = leagueStatus,
                SportID = _league.SportID
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
                    populateContents();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("League update failed.");
                    populateContents();
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

        private void datRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _leagueRequestVM = (LeagueRequestVM)datRequest.SelectedItem;
            foreach (LeagueRequest leagueRequest in _leagueManager.RetrieveRequestsByLeagueID(_league.LeagueID))
            {
                if (leagueRequest.RequestID == _leagueRequestVM.RequestID)
                {
                    _leagueRequest = leagueRequest;
                }
            }
            btnAccept.Visibility = Visibility.Visible;
            btnDecline.Visibility = Visibility.Visible;

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Add a Team", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _leagueManager.AddTeamToLeague(_leagueRequest.TeamID, _league.LeagueID);
                    _leagueManager.UpdateRequestStatus(_leagueRequest.RequestID, "Joined");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Team addition failed.");
                    throw ex;
                }
            }
            btnAccept.Visibility = Visibility.Collapsed;
            btnDecline.Visibility = Visibility.Collapsed;
            populateContents();
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _leagueManager.UpdateRequestStatus(_leagueRequest.RequestID, "Declined");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed.");
                throw ex;
            }
            btnAccept.Visibility = Visibility.Collapsed;
            btnDecline.Visibility = Visibility.Collapsed;
            populateContents();
        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgGenerateLeagueGames(_league));
        }
    }
}
