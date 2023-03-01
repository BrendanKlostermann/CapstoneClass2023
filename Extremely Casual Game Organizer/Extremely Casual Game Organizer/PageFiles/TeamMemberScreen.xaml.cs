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


namespace Extremely_Casual_Game_Organizer
{

    /// <summary>
    /// Interaction logic for TeamMemberScreen.xaml
    /// </summary>
    public partial class TeamMemberScreen : Page
    {
        List<TeamMember> _teamMembers = new List<TeamMember>();
        List<Member> _members = new List<Member>();
        List<Member> _starterOrBenchers = new List<Member>();
        TeamMemberManager _teamMemberManager = null;
        MemberManager _membersM = null;
        bool toggleBench = true; //true = starter false = benched
        private int _teamID = 0;
        int _optionStatus = 0; //used to figure out which options to display when clicking on a team member

        public TeamMemberScreen()
        {
            InitializeComponent();
            _teamMemberManager = new TeamMemberManager();
            _membersM = new MemberManager();
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// constructor used to load the frame into the window.  Needs a team ID 
        /// that gets the team members on that team
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public TeamMemberScreen(int teamID)
        {
            _teamID = teamID;
            _teamMemberManager = new TeamMemberManager();
            _membersM = new MemberManager();
            _members = _membersM.GetAListOfMembersByTeamID(_teamID);
            _starterOrBenchers = _teamMemberManager.SortIntoStarters(_members, _teamID, toggleBench);
            InitializeComponent();
            DisplayTeamMembers();

        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Method to that swaps the team members to display, benched or starters
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void swapButton_Click(object sender, RoutedEventArgs e)
        {
            if (swapButton.Content.Equals("View Bench"))
            {
                lblStarter.Content = "Bench";
                swapButton.Content = " View Starters";
                toggleBench = false;
                _starterOrBenchers = _teamMemberManager.SortIntoStarters(_members, _teamID, toggleBench);
                DisplayTeamMembers();
            }
            else
            {
                lblStarter.Content = "Starters";
                swapButton.Content = "View Bench";
                toggleBench = true;
                _starterOrBenchers = _teamMemberManager.SortIntoStarters(_members, _teamID, toggleBench);
                DisplayTeamMembers();
            }
        }


        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Method to reload the page when the user comes back.
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void ReloadPage()
        {
            this.IsEnabled = true;
            DisplayTeamMembers();
        }

        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Method used to display each team member on the grid.
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void DisplayTeamMembers()
        {
            for(int i = 0; i < 20; i++)
            {
                int _numberOfPlayers = _starterOrBenchers.Count -1;
                switch (i + 1)
                {
                    case 1:
                        if (_numberOfPlayers < i)
                        {
                           spot1.Content = "";
                        }
                        else
                        {
                            spot1.Content = _starterOrBenchers[i].FamilyName;
                        }

                        break;
                    case 2:
                        if (_numberOfPlayers < i)
                        {
                            spot2.Content = "";
                        }
                        else
                        {
                            spot2.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 3:
                        if (_numberOfPlayers < i)
                        {
                            spot3.Content = "";
                        }
                        else
                        {
                            spot3.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 4:
                        if (_numberOfPlayers < i)
                        {
                            spot4.Content = "";
                        }
                        else
                        {
                            spot4.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 5:
                        if (_numberOfPlayers < i)
                        {
                            spot5.Content = "";
                        }
                        else
                        {
                            spot5.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 6:
                        if (_numberOfPlayers < i)
                        {
                            spot6.Content = "";
                        }
                        else
                        {
                            spot6.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 7:
                        if (_numberOfPlayers < i)
                        {
                            spot7.Content = "";
                        }
                        else
                        {
                            spot7.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 8:
                        if (_numberOfPlayers < i)
                        {
                            spot8.Content = "";
                        }
                        else
                        {
                            spot8.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 9:
                        if (_numberOfPlayers < i)
                        {
                            spot9.Content = "";
                        }
                        else
                        {
                            spot9.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 10:
                        if (_numberOfPlayers < i)
                        {
                            spot10.Content = "";
                        }
                        else
                        {
                            spot10.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 11:
                        if (_numberOfPlayers < i)
                        {
                            spot11.Content = "";
                        }
                        else
                        {
                            spot11.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 12:
                        if (_numberOfPlayers < i)
                        {
                            spot12.Content = "";
                        }
                        else
                        {
                            spot12.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 13:
                        if (_numberOfPlayers < i)
                        {
                            spot13.Content = "";
                        }
                        else
                        {
                            spot13.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 14:
                        if (_numberOfPlayers < i)
                        {
                            spot14.Content = "";
                        }
                        else
                        {
                            spot14.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 15:
                        if (_numberOfPlayers < i)
                        {
                            spot15.Content = "";
                        }
                        else
                        {
                            spot15.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 16:
                        if (_numberOfPlayers < i)
                        {
                            spot16.Content = "";
                        }
                        else
                        {
                            spot16.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 17:
                        if (_numberOfPlayers < i)
                        {
                            spot17.Content = "";
                        }
                        else
                        {
                            spot17.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 18:
                        if (_numberOfPlayers < i)
                        {
                            spot18.Content = "";
                        }
                        else
                        {
                            spot18.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 19:
                        if (_numberOfPlayers < i)
                        {
                            spot19.Content = "";
                        }
                        else
                        {
                            spot19.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    case 20:
                        if (_numberOfPlayers < i)
                        {
                            spot20.Content = "";
                        }
                        else
                        {
                            spot20.Content = _starterOrBenchers[i].FamilyName;
                        }
                        break;
                    default:
                        break;
                }

            }

        }


        //row one click actions
        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Methods that manage which player is clicked on
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void spot1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot1.Content == "")
                {
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();

                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }

            }catch(ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot2.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[1].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot3.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[2].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot4.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[3].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot5.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[4].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot6.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[5].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot7.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[6].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot8.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[7].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot9.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[8].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot10.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[9].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot11.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[10].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot12.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[11].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot13.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[12].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot14.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[13].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot15.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[14].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot16_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot16.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[15].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot17_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot17.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[16].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);

            }
        }

        private void spot18_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot18.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[17].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot19_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot19.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[18].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        private void spot20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (spot20.Content == "")
                {
                    _optionStatus = 1;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[0].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();
                }
                else
                {
                    _optionStatus = 2;
                    PopUpOptions _options = new PopUpOptions(_starterOrBenchers[19].MemberID, _teamID, _optionStatus);
                    this.IsEnabled = false;
                    _options.ShowDialog();
                    ReloadPage();

                }
            }
            catch (ApplicationException up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }
    }
}


