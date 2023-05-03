using DataObjects;
using LogicLayer;
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
        SportManager _sportManager = new SportManager();
        MemberManager _memberManager = new MemberManager();
        String _gender;
        List<Team> _teams;
        Team _team = null;
        List<Team> notRequested = new List<Team>();
        ListToDataTableConverter converter = new ListToDataTableConverter();
        TeamManager _teamManager = new TeamManager();
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
        public pgViewLeague(League league, Member member, List<Team> teams)
        {
            _member = member;
            _league = league;
            _teams = teams;
            InitializeComponent();
            populateContents();
        }
        private void LoadTeamList()
        {
            DataTable teamList = converter.ToDataTable(getTeamVM());

            foreach (var team in teamList.AsEnumerable())
            {
                ListBoxItem addTeam = new ListBoxItem();
                addTeam.BorderBrush = Brushes.Black;
                addTeam.Margin = new Thickness(5);
                addTeam.Width = 500;
                addTeam.Height = 30;
                addTeam.DataContext = team[0];



                TextBlock nameText = new TextBlock()
                {
                    Text = team[5].ToString(),
                    Width = 200
                };
                TextBlock sportText = new TextBlock()
                {
                    Text = team[3].ToString(),
                    Width = 150
                };
                TextBlock ownerText = new TextBlock()
                {
                    Text = team[4].ToString(),
                    Width = 150
                };
                DockPanel leagueListItem = new DockPanel();

                leagueListItem.Children.Add(nameText);
                leagueListItem.Children.Add(sportText);
                leagueListItem.Children.Add(ownerText);

                addTeam.Content = leagueListItem;

                lstCurrent.Items.Add(addTeam);
            }
        }
        private void populateContents()
        {
            txtDetails.Text = _league.Description;
            Your.Visibility = Visibility.Collapsed;
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
            int count;
            List<Team> teams;
            try
            {
                teams = _leagueManager.GetAListOfTeamsByLeagueID(_league.LeagueID);
                count = teams.Count();
                LoadTeamList();
            }
            catch
            {
                count = 0;
            }
            txtMax.Text = count.ToString() + "/" + _league.MaxNumOfTeams.ToString();
            if (_member != null && _league.Active && _teams != null)
            {

                notRequested = _leagueManager.RetrieveNotRequestedTeams(_member.MemberID, _league.LeagueID);
                List<string> teamrequests = new List<string>();
                foreach (Team team in _teams)
                {
                    if (_leagueManager.RetrieveRequestsByLeagueID(_league.LeagueID) != null)
                    {
                        foreach (LeagueRequest leagueRequest in _leagueManager.RetrieveRequestsByLeagueID(_league.LeagueID))
                        {
                            if (team.TeamID == leagueRequest.TeamID)
                            {
                                teamrequests.Add(team.TeamName + " Status: " + leagueRequest.Status);
                            }
                        }
                    }
                }
                string textToDisplay = "";
                foreach (string teamrequest in teamrequests)
                {
                    textToDisplay = textToDisplay + teamrequest + "\n";
                }
                txtRequestStatus.Text = textToDisplay;
            }

            if (notRequested.Count > 0)
            {
                btnRequest.Visibility = Visibility.Visible;
                if (notRequested.Count > 1)
                {
                    Your.Visibility = Visibility.Visible;
                    cboRequests.Visibility = Visibility.Visible;
                    List<String> names = new List<String>();
                    foreach (Team team in notRequested)
                    {
                        names.Add(team.TeamName);
                    }
                    cboRequests.ItemsSource = names;
                }
            }
            else
            {
                btnRequest.Visibility = Visibility.Hidden;
                cboRequests.Visibility = Visibility.Hidden;
            }
        }
        public List<Team.TeamVM> getTeamVM()
        {

            List<Team> teams = _leagueManager.GetAListOfTeamsByLeagueID(_league.LeagueID);
            List<Team.TeamVM> teamVMs = new List<Team.TeamVM>();
            foreach (var team in teams)
            {
                Team.TeamVM teamVM = new Team.TeamVM();
                teamVM.TeamID = team.TeamID;
                teamVM.TeamName = team.TeamName;
                teamVM.Gender = team.Gender;
                teamVM.SportID = team.SportID;
                teamVM.Description = team.Description;
                teamVM.MemberID = team.MemberID;
                teamVM.SportName = _sportManager.RetrieveSportBySportID(teamVM.SportID);
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
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            pgViewLeagueList viewList = new pgViewLeagueList(new MasterManager());
            _pageControl.LoadPage(viewList);
        }
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            LeagueRequest request;
            if (cboRequests.Visibility == Visibility)
            {
                if (cboRequests.SelectedItem == null)
                {
                    MessageBox.Show("Please select a team", "Select a Team");
                    return;
                }
                else
                {
                    foreach (Team team in _teams)
                    {
                        if (team.TeamName.Equals(cboRequests.Text.ToString()))
                        {
                            _team = team;
                            break;
                        }
                    }
                    request = new LeagueRequest()
                    {
                        LeagueID = _league.LeagueID,
                        TeamID = _team.TeamID,
                        Status = "Waiting"
                    };
                    MessageBoxResult results = MessageBox.Show("Are you sure?", "Request to Join a League", MessageBoxButton.YesNo);
                    if (results == MessageBoxResult.Yes)
                    {
                        try
                        {
                            _leagueManager.AddRequest(request);
                            MessageBox.Show("Join request successful!");
                        }
                        catch
                        {
                            MessageBox.Show("Request failed.");
                        }
                        populateContents();
                    }
                }
            }
            else
            {
                _team = _teams[0];
                request = new LeagueRequest()
                {
                    LeagueID = _league.LeagueID,
                    TeamID = _team.TeamID,
                    Status = "Waiting"
                };
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Request to Join a League", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _leagueManager.AddRequest(request);
                        MessageBox.Show("Join request successful!");
                        populateContents();
                    }
                    catch
                    {
                        MessageBox.Show("Request failed.");
                    }
                }
            }
        }


    }
}
