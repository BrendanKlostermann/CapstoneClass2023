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
    /// Interaction logic for winTeamSearch.xaml
    /// </summary>
    public partial class winTeamSearch : Window
    {
        // Just for the animation of the sport image
        private List<string> sports;
        private int sport_id = 0;
        private MasterManager _masterManager;

        public int SelectedTeamID { get; set; }

        public winTeamSearch(MasterManager masterManager)
        {
            _masterManager = masterManager;
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
                sports = _masterManager.TeamManager.getSportName();
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
                List<TeamSport> team = _masterManager.TeamManager.getTeamByTeamName(txtSearch.Text.ToString(), sport_id);
                // Remove all items from the list of team
                lbTeam.Items.Clear();

                // If there's a team
                if (team.Count > 0)
                {

                    foreach (TeamSport line in team)
                    {
                        // Populate the team custom control
                        // that I created in = the CustomControls folder
                        var teamSport = new CustomControls.TeamSearchItem(line, _masterManager);
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
        // Get the sport while the user is typing
        private void Blur(object sender, KeyEventArgs e)
        {
            getTeam();
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
        public void ReturnSelectedTeam(int team_id)
        {
            try
            {
                SelectedTeamID = team_id;

                // Window should close when ID is set

                Window wintoclose = Application.Current.Windows.OfType<Window>().Where(x => x.Name == "windowTeamSearch").First();
                wintoclose.DialogResult = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }
    }
}
