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

namespace Extremely_Casual_Game_Organizer.PageFiles.Practices
{
    /// <summary>
    /// Interaction logic for pgCreatePractice.xaml
    /// Nick Vroom
    /// </summary>
    public partial class pgCreatePractice : Page
    {
        int team_id;
        MasterManager masterManager = new MasterManager();
        public pgCreatePractice()
        {
            InitializeComponent();
            DateTimer.Value = DateTime.Now;     //populate the DateTimePicker with the current date and time
        }

        //constructor for passing in the correct teamID
        public pgCreatePractice(int teamId)
        {
            InitializeComponent();
            DateTimer.Value = DateTime.Now;
            team_id = teamId;
        }

        private void btnCreatePractice_Click(object sender, RoutedEventArgs e)
        {
            PracticeManager pm = new PracticeManager();
            Practice practice = new Practice()
            {
                TeamID = team_id,
                Description = txtDescription.Text,
                Location = txtLocation.Text,
                DateAndTime = (DateTime)DateTimer.Value,
                ZIP = int.Parse(txtZip.Text)
            };
            pm.CreatePractice(practice);
            MessageBox.Show("Practice created", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            pgViewTeamDetails page = new pgViewTeamDetails(team_id, masterManager);
            NavigationService.Navigate(page);
        }

        private void btnBackToTeam_Click(object sender, RoutedEventArgs e)
        {
            pgViewTeamDetails page = new pgViewTeamDetails(team_id, masterManager);
            NavigationService.Navigate(page);
        }
    }
}
