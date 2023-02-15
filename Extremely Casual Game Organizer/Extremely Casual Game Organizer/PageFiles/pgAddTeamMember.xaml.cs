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
using LogicLayer;
using LogicLayerInterfaces;
using DataObjects;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgAddTeamMember.xaml
    /// </summary>
    public partial class pgAddTeamMember : Page
    {
        TeamMember _teamMember = null;
        Member _member = null;
        TeamMemberManager _teamMemberManager = null;
        int _teamID;
        public pgAddTeamMember(TeamMemberManager teamMemberManager, int team_id)
        {
            _teamMemberManager = teamMemberManager;
            _teamID = team_id;

            InitializeComponent();
        }

        private List<Member> SearchMember(string name)
        {
            // Method only allows 2 types of input, FirstName(Space)LastName or FirstName for search. Anything else will result in error. 
            List<Member> results = new List<Member>();
            MemberManager memberManager = new MemberManager();
            // Input string should be FirstName(Space)LastName. Need to parse this to acquire first and last name.
            string fullName = name.Trim();
            string firstName = "";
            string lastName = "";

            // Need to determine if name has spaces, otherwise default to just seraching by first name for results.
            int spaceCount = 0;
            foreach (var letter in name)
            {
                if (letter.Equals(' '))
                {
                    spaceCount++;
                }
            }
            // Find users based on first and last name
            if (spaceCount == 1)
            {
                string[] nameParse = name.Split(' ');
                firstName = nameParse[0].ToString();
                lastName = nameParse[1].ToString();

                results = memberManager.SearchMemberByFirstAndLastName(firstName, lastName);
            }
            else if (spaceCount == 0)
            {
                results = memberManager.SearchMemberByFirstName(name);
            }
            else
            {
                MessageBox.Show("User not found" + "\n\n" + "Please Try Again");
                txtMemberSearch.Focus();
            }

            return results;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Member> searchResults = new List<Member>();
            string searchName = txtMemberSearch.Text;

            searchResults = SearchMember(searchName);

            if (searchResults.Count > 0)
            {
                // var gridLoad = searchResults.Select(x => new { x.FirstName, x.FamilyName}).ToList();

                foreach (var result in searchResults)
                {
                    lstSearchResults.Items.Add(result.FirstName + " " + result.FamilyName);
                }

                // lstSearchResults.ItemsSource = gridLoad;
            }
            else
            {
                MessageBox.Show("User not found" + "\n\n" + "Please Try Again");
                txtMemberSearch.Focus();
            }
        }
    }
}
