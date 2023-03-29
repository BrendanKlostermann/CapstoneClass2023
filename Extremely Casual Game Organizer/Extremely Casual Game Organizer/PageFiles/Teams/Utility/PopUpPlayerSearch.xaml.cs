/// <summary>
/// Alex Korte
/// Created: 2023/03/21
/// 
/// </summary>
/// A class used to manage when a user wants to add a player to their team and search 
/// 
/// we are using 1 constructor taking a teamID so that we can run the stored procedure to add a member to a team
/// <remarks>
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
using System.Windows.Shapes;

namespace Extremely_Casual_Game_Organizer.PageFiles.Teams.Utility
{
    /// <summary>
    /// Interaction logic for PopUpPlayerSearch.xaml
    /// </summary>
    public partial class PopUpPlayerSearch : Window
    {
        int _teamID;
        List<Member> _members;
        TeamMemberManager _teamMemberManager;
        MemberManager _memberManager;
        MasterManager _masterManager;
        PageControl _pageControl;
        List<Member> _membersOnTeamNow;
        

        //default constructor
        public PopUpPlayerSearch()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// This is a method to pop up a player search, returns a list of players
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        public PopUpPlayerSearch(int teamID, List<Member> members)
        {
            _masterManager = new MasterManager();
            _teamMemberManager = new TeamMemberManager();
            _memberManager = new MemberManager();
            _pageControl = new PageControl();
            _teamID = teamID;
            _members = new List<Member>();
            if(members == null)
            {
                _membersOnTeamNow = new List<Member>();
            }
            else
            {
                _membersOnTeamNow = members;
            }
            InitializeComponent();
        }

        private void bntCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// this is the search button, that looks through the database, finds the members, and then will return them as a list to the datagrid
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dtaGridMember.ItemsSource = null;//clear the data grid when the user searches
            string _firstName = txtBoxFirstname.Text;
            string _lastName = txtBoxLastName.Text;
            string _email = txtBoxEmail.Text;
            _members = _memberManager.SearchingForMembersByNameAndOrEmail(_firstName, _lastName, _email);
            updateDataGridOfMembers();//display search results
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// This method will select the member the user has clicked on and then send it through the add a member
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Member selectedMember = (Member)dtaGridMember.SelectedItem;
            foreach (var member in _membersOnTeamNow)
            {
                if(selectedMember.MemberID == member.MemberID)
                {
                    MessageBox.Show("Member already on team");
                    break;
                }
                else
                {
                    int successful = _teamMemberManager.AddAPlayerToATeamByTeamIDAndMemberID(_teamID, selectedMember.MemberID);
                    if (successful > 0)
                    {
                        MessageBox.Show("Added");
                        this.Close();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Error");
                        this.Close();
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/03/21
        /// 
        /// </summary>
        /// a helper method for updating the grid
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// </remarks>

        private void updateDataGridOfMembers()
        {
             dtaGridMember.ItemsSource = _members; // Update the data grid with search results
            txtBoxEmail.Text = "";
            txtBoxFirstname.Text = "";
            txtBoxLastName.Text = "";
        }
    }
}
