/// <TeamObject>
/// Alex Korte
/// Created: 2023/02/26
/// 
/// </summary>
/// Class to view all of the current teams, helps lead them to where members are on a team.
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgViewTeamList.xaml
    /// </summary>
    /// 

    /// <TeamObject>
    /// Alex Korte
    /// Created: 2023/02/26
    /// 
    /// </summary>
    /// Method to display all of the teams
    /// 
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
    public partial class pgViewTeamList : Page
    {
        List<int> _memberID = null;//get a list of member ids so we can see who the coaches are
        List<Team> _teams = null;//list of teams
        List<Member> _members = null;//list of members (coaches)
        List<Team.TeamVM> _teamVMs = null; //getting human readable data
        PageControl _pageControl = new PageControl();
        Button _viewBtn = new Button();
        MasterManager _masterManager = null;

        public pgViewTeamList(MasterManager masterManager)
        {
            _masterManager = masterManager;
            InitializeComponent();
            loadData();//method to get all teams
        }


        /// <TeamViewPage>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list all teams
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public void loadData()
        {
            _teams = _masterManager.TeamManager.RetrieveAllTeams();
            getMemberID(_teams);
            _members = _masterManager.MemberManager.RetrieveMembersByMemberID(_memberID);
            getTeamVM();
            
            dtaGridTeamList.ItemsSource = _teamVMs;
            
        }

        /// <TeamView>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// Method to get a list of members by their member id
        /// so that we can assign the coaches
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public void getMemberID(List<Team> teams)
        {
            _memberID = new List<int>();
            foreach (var team in teams)
            {
                _memberID.Add(team.MemberID);
            }


        }

        /// <TeamView>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// This is a method to make the list of VM's so that we can display them
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public void getTeamVM()
        {
            _teamVMs = new List<Team.TeamVM>();
            foreach (var team in _teams)
            {
                Team.TeamVM teamVM = new Team.TeamVM();
                teamVM.TeamID = team.TeamID;
                teamVM.TeamName = team.TeamName;
                teamVM.Gender = team.Gender;
                teamVM.SportID = team.SportID;
                teamVM.Description = team.Description;
                teamVM.MemberID = team.MemberID;
                foreach (var memberID in _members)
                {
                    if(memberID.MemberID == team.MemberID)
                    {
                        teamVM.FirstName = memberID.FirstName;
                        teamVM.LastName = memberID.FamilyName;
                        if(memberID.Gender == true)
                        {
                            teamVM.GenderAsText = "M";
                        }else if(memberID.Gender == false)
                        {
                            teamVM.GenderAsText = "F";
                        }
                        else
                        {
                            teamVM.GenderAsText = "NB";
                        }
                    }
                }
                _teamVMs.Add(teamVM);
            }
        }

        /// <TeamView>
        /// Alex Korte
        /// Created: 2023/02/26
        /// 
        /// </summary>
        /// This is a method to change and hide the columns not used.
        /// 
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        private void dtaGridTeamList_Loaded(object sender, RoutedEventArgs e)
        {
            dtaGridTeamList.Columns.RemoveAt(5);//hiding gender bool
            dtaGridTeamList.Columns.RemoveAt(6);//hiding member id
            dtaGridTeamList.IsReadOnly = true;
            // dtaGridTeamList.ColumnWidth.4
            dtaGridTeamList.Columns[0].Width = 114;//firstname
            dtaGridTeamList.Columns[1].Width = 114;//lastname
            dtaGridTeamList.Columns[2].Width = 70;//gender
            dtaGridTeamList.Columns[2].Header = "Gender";//title head
            dtaGridTeamList.Columns[3].Width = 50;//TeamID
            dtaGridTeamList.Columns[4].Width = 214;//TeamName
            dtaGridTeamList.Columns[5].Width = 75;//sportID
            dtaGridTeamList.Columns.RemoveAt(6);//hiding description
        }
        /// <summary>
        /// Updated BY: Jacob Lindauer
        /// 2023/07/03
        /// 
        /// Updated method to view team details. On team details page there is a button to edit team roster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewTeamMemberScreen(object sender, RoutedEventArgs e)
        {

            try
            {
                Team.TeamVM teamVM = (Team.TeamVM)dtaGridTeamList.SelectedItem;
                if (teamVM != null)
                {
                    pgViewTeamDetails teamDetails = new pgViewTeamDetails(teamVM.TeamID, _masterManager);
                    //MessageBox.Show("test");
                    _pageControl.LoadPage(teamDetails);
                }
                else
                {
                    MessageBox.Show("Please Select A Team");
                }
            }
            catch (Exception up)
            {
                MessageBox.Show("Error, please try again", up.InnerException.Message);
            }

            //open
        }

        private void pageTeamList_Loaded(object sender, RoutedEventArgs e)
        {
            _viewBtn = _pageControl.SetCustomButton("View Team", 1);
            _viewBtn.Click += ViewTeamMemberScreen;
        }

        private void pageTeamList_Unloaded(object sender, RoutedEventArgs e)
        {
            _viewBtn.Click -= ViewTeamMemberScreen;
        }
    }
}
