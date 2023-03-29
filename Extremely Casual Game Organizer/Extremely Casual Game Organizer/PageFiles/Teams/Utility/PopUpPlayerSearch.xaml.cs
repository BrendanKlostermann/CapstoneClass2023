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
        MasterManager _masterManager;
        PageControl _pageControl;
        List<Member> _members;
        List<Member> _searchedMembers;
        MemberManager _memberManager;

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
            _members = members;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _searchedMembers = _memberManager.SearchingForMembersByNameAndOrEmail(txtFirstname.Text, txtFamilyName.Text, txtEmail.Text);
            updateDataGrid();
        }

        private void bntCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateDataGrid()
        {
        
            dtaGridMember.Items.Clear(); // Clear any existing data in the data grid
            dtaGridMember.ItemsSource = _searchedMembers; // Assign the new data to the data grid
        
        }
    }
}
