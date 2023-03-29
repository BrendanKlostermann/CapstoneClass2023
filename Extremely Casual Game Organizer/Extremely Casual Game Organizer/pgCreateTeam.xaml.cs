/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Create Team Page
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>

using DataObjects;
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
using LogicLayer;
using System.Text.RegularExpressions;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgCreateTeam_2.xaml
    /// </summary>
    /// 
    public partial class pgCreateTeam : Page
    {
        TeamManager _teamManager = null;
        TeamManager _sportManager = null;
        private int memberID = 100017;
        private MasterManager _masterManager;

        // Just for the animation of the sport image
        private List<string> sports;
        private MasterManager masterManager;

        // Open pgCreateTeam_2 whith a TeamManager passed to it
        public pgCreateTeam(TeamManager teamManager)
        {
            _teamManager = teamManager;
            _sportManager = teamManager;
            InitializeComponent();
            getSport();
            setSportImage("Sports");
        }

        // Open pgCreateTeam_2 whith a memberID passed to it
        public pgCreateTeam(MasterManager _masterManager, int memberID)
        {
            _teamManager = new TeamManager();
            _sportManager = new TeamManager();
            this.memberID = memberID;
            this._masterManager = _masterManager;
            InitializeComponent();
            getSport();
            setSportImage("Sports");
        }

        public pgCreateTeam(MasterManager masterManager)
        {
            this.masterManager = masterManager;
            _teamManager = new TeamManager();
            _sportManager = new TeamManager();
            InitializeComponent();
            getSport();
            setSportImage("Sports");
        }

        // Get the sport data according to sport_id
        private void getSport()
        {
            try
            {
                sports = _sportManager.getSportName();

                foreach (string line in sports)
                {
                    ddSportId.Items.Add(line.Substring(5));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read sports!");
            }
        }

        // Create team
        private void btn_create_Click(object sender, RoutedEventArgs e)
        {

            // The team name should not be empty
            if (txtTeamName.Text == "")
            {
                MessageBox.Show("You must provide a team name.");
                txtTeamName.Focus();
                return;
            }
            if (ddGender.Text == "")
            {
                MessageBox.Show("You must select a gender.");
                ddGender.Focus();
                return;
            }

            if (ddSportId.Text == "")
            {
                MessageBox.Show("You must select a sport.");
                ddSportId.Focus();
                return;
            }


            // The gender is has BIT type but the ddGender.Text is a string
            // So, I created this to make sure the value if a boolean
            bool? _gender = true;
            if (ddGender.Text == "Male") _gender = true;
            else if (ddGender.Text == "Female") _gender = false;
            else _gender = null;

            //try
            //{
            // Create a new team dataObject
            Team team = new Team()
            {
                TeamName = txtTeamName.Text,
                Gender = _gender,
                SportID = Int32.Parse(lblSportId.Content.ToString()),
                MemberID = memberID
            };

            // Add team to the database
            // if there are rowsaffected
            if (_teamManager.AddTeam(team) > 0)
            {
                MessageBox.Show("Team created successfully!");
                resetForm();
                return;
            }
            else
            {
                MessageBox.Show("An error occur!");
                return;
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Creation Failed. \n\n" + ex.Message);
            //}

        }

        // Reste the form
        private void resetForm()
        {
            txtTeamName.Text = "";
            txtTeamName.Focus();
            ddGender.Text = "";
            ddSportId.Text = "";
            setSportImage("Sports");
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            NavigationService.Navigate(new pgMemberProfile(_masterManager));
        }

        // just for the animation purpose. Changing the sport image
        private void ddSportId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Dp_sport_id.SelectedItem.ToString());
            try
            {
                var item = sports.Find(x => x.Contains(ddSportId.SelectedItem.ToString()));
                lblSportId.Content = (Regex.Match(item, @"\d+").Value);
                setSportImage(ddSportId.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
        }

        // Same here
        // The images are located in the bin directory
        private void setSportImage(string value)
        {
            //AppDomain.CurrentDomain.BaseDirectory: The bin folder
            string img = "";
            try
            {
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/" + value + ".png";
                img_logo.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/Sports.png";
            }
            img_logo.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));

        }

    }
}
