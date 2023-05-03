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
using System.Reflection;
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
        TeamManager _teamManager = new TeamManager();
        ListToDataTableConverter converter = new ListToDataTableConverter();

        public pgViewLeagueList(MasterManager masterManager)
        {
            InitializeComponent();
            _masterManager = masterManager;
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

        private void LoadLeagueList()
        {
            DataTable leagueList = converter.ToDataTable(_leagueManager.RetrieveListOfLeaguesForGrid());

            foreach (var league in leagueList.AsEnumerable())
            {
                ListBoxItem addLeague = new ListBoxItem();
                addLeague.BorderBrush = Brushes.Black;
                addLeague.Margin = new Thickness(5);
                addLeague.Width = 765;
                addLeague.Height = 50;
                addLeague.DataContext = league[0];


                TextBlock nameText = new TextBlock()
                {
                    Text = league[1].ToString(),
                    Width = 230,
                    FontWeight = FontWeights.Bold
                };

                TextBlock sportText = new TextBlock()
                {
                    Text = league[3].ToString(),
                    Width = 340
                };

                TextBlock creatorText = new TextBlock()
                {
                    Text = league[4].ToString(),
                    Width = 340
                };
                DockPanel leagueListItem = new DockPanel();

                leagueListItem.Children.Add(nameText);
                leagueListItem.Children.Add(sportText);
                leagueListItem.Children.Add(creatorText);

                addLeague.Content = leagueListItem;

                lstLeagueList.Items.Add(addLeague);
            }
        }



        private void MyLeaguesButton_Click(object sender, RoutedEventArgs e)
        {

            _pageControl.LoadPage(new pgMyLeagues(_pageControl.GetSignedInMember(), new LeagueManager()));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgAddLeague(_pageControl.GetSignedInMember(), new LeagueManager(), new SportManager()));
        }

        private void lstLeagueList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (lstLeagueList.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item");
                }
                else
                {

                    ListBoxItem selectedItem = (ListBoxItem)lstLeagueList.SelectedItem;
                    int leagueID = int.Parse(selectedItem.DataContext.ToString());
                    League league = _leagueManager.RetrieveLeagueByLeagueID(leagueID);

                    try
                    {
                        _member = _pageControl.GetSignedInMember();
                    }
                    catch
                    {
                    }
                    List<Team> teams = null;
                    if (_member != null)
                    {
                        try
                        {
                            teams = _masterManager.TeamManager.RetrieveTeamsByMemberID(_member.MemberID);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    pgViewLeague selectedLeague = new pgViewLeague(league, _member, teams);
                    _pageControl.LoadPage(selectedLeague);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sorry, league details are unable to load");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
                    LoadLeagueList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
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
                    LoadLeagueList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}

