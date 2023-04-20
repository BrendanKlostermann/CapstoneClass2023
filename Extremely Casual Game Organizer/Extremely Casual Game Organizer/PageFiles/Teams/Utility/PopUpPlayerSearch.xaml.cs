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
        TeamMemberManager _teamMemberManager;
        MemberManager _memberManager;
        MasterManager _masterManager;
        PageControl _pageControl;
        List<Member> _searchedMembers = new List<Member>();
        List<Member> _currentMembers;

        public PopUpPlayerSearch()
        {
            InitializeComponent();
        }




        public PopUpPlayerSearch(int teamID, List<Member> members)
        {
            _masterManager = new MasterManager();
            _teamMemberManager = new TeamMemberManager();
            _pageControl = new PageControl();
            _memberManager = new MemberManager();
            _teamID = teamID;
            _currentMembers = members;
            InitializeComponent();
        }

        private void bntCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //need to get the accessor that searches players and returns a list of members
            //will need to limit to first name, last name, and email adddress
            //_masterManager.MemberManager.
            if (txtEmail.Text == "" && txtFamilyName.Text == "" && txtFirstname.Text == "")
            {
                MessageBox.Show("Please enter a name or email");
            }
            else
            {
                _searchedMembers = _memberManager.GetAListOfMembersByFirstNameLastNameOrEmail(txtFirstname.Text, txtFamilyName.Text, txtEmail.Text);
                updateDataGrid();
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Member selectedMember = (Member)dtaGridMember.SelectedItem;
            if (selectedMember == null)
            {
                MessageBox.Show("Please select a member or click cancel");
                return;
            }


            var member = _currentMembers.Find(m => m.MemberID == selectedMember.MemberID);

            if (member == null) // not found in team
            {
                try
                {
                    if (1 == _teamMemberManager.AddAPlayerToATeamByTeamIDAndMemberID(_teamID, selectedMember.MemberID))
                    {
                        MessageBox.Show("Member added to team");
                        this.Close();
                        _pageControl.LoadPage(new pgTeamMemberScreen(_teamID, _masterManager));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Adding member failed." + "\n\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("That member is already on your team.");
            }
            return;
        }

        private void updateDataGrid()
        {
            dtaGridMember.ItemsSource = null;
            dtaGridMember.ItemsSource = _searchedMembers;
        }
    }
}
