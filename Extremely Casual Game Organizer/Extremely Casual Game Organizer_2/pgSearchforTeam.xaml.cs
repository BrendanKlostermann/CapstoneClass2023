/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Search for team Page
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgSearchforTeam_2.xaml
    /// </summary>
    public partial class pgSearchforTeam : Page
    {
        TeamManager _teamManager = null;
        TeamManager _sportManager = null;

        // Just for the animation of the sport image
        private List<string> sports;
        private int sport_id = 0;

        public pgSearchforTeam()
        {
            _teamManager = new TeamManager();
            _sportManager = new TeamManager();
            InitializeComponent();
            getSport();
            getTeam();
        }
        public pgSearchforTeam(TeamManager teamManager)
        {
            _teamManager = new TeamManager();
            _sportManager = new TeamManager();
            InitializeComponent();
            getSport();
            getTeam();
        }

        // Get All sports
        private void getSport()
        {
            txtSearch.Focus();

            try
            {
                sports = _sportManager.getSportName();
                ddSport.Items.Add("");
                foreach (string line in sports)
                {
                    // Add them into the listbox
                    ddSport.Items.Add(line.Substring(5));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read sports!");
            }
        }
        
        // Get the team searched
        private void getTeam()
        {
            try
            {
                List<TeamSport> team = _teamManager.getTeamByTeamName(txtSearch.Text.ToString(), sport_id);
                // Remove all items from the list of team
                lbTeam.Items.Clear();

                // If there's a team
                if (team.Count > 0)
                {

                    foreach (TeamSport line in team)
                    {
                        // Populate the team custom control
                        // that I created in = the CustomControls folder
                        var teamSport = new CustomControls.TeamSport();
                        teamSport.lblName.Content = line.Name;
                        teamSport.lblSport.Content = line.Description;
                        setSportImage(teamSport.img, line.Description);

                        // Check for gender
                        if (line.Gender == true) teamSport.lblGender.Content = "Male";
                        else if (line.Gender == false) teamSport.lblGender.Content = "Female";
                        else teamSport.lblGender.Content = "Not specify";

                        // Add result to the listbox
                        lbTeam.Items.Add(teamSport);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot read team!" + e.Message);
            }
        }

        // This is a optional method I create to set predefined images
        // of the sport according to the sport selected
        private void setSportImage(Image image, string value)
        {
            string img = "";
            try
            {
                // If the predefined image for that sport exist
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/" + value + ".png";
                image.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            }
            // If th predefined image for the sport doesn't exist
            catch
            {
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/Sports.png";
            }
            image.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //getTeam();
        }
        // Get the sport while the user is typing
        private void Blur(object sender, KeyEventArgs e)
        {
            getTeam();
        }

        private void lbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        // Get the sport Id of the sport selected from the comboText
        private void ddSport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sport_id = 0;
            foreach (string line in sports)
            {
                if (line.Substring(5) == ddSport.SelectedItem.ToString())
                {
                    sport_id = Int32.Parse(line.Substring(0, 4));
                }
            }

            getTeam(); //
        }
    }
}
