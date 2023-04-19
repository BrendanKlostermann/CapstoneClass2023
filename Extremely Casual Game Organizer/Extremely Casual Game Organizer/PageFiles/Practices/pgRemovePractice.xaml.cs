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
    /// Interaction logic for pgRemovePractice.xaml
    /// </summary>
    public partial class pgRemovePractice : Page
    {
        int _teamID;
        MasterManager masterManager = new MasterManager();
        public pgRemovePractice(int teamID)
        {
            InitializeComponent();
            _teamID = teamID;
        }

        private void dtaGridPractices_Loaded(object sender, RoutedEventArgs e)
        {
            PracticeManager pm = new PracticeManager();
            List<Practice> practiceList = pm.SelectPractices(_teamID);

            dtaGridPractices.ItemsSource = practiceList;
        }

        private void btnRemovePractice_Click(object sender, RoutedEventArgs e)
        {
            if (dtaGridPractices.SelectedItem != null)
            {
                Practice practice = (Practice)dtaGridPractices.SelectedItem;

                PracticeManager pm = new PracticeManager();
                pm.RemovePractice(practice);

                MessageBox.Show("Practice removed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                pgViewTeamDetails page = new pgViewTeamDetails(_teamID, masterManager);
                NavigationService.Navigate(page);
            }
        }

        private void btnBackToTeam_Click(object sender, RoutedEventArgs e)
        {
            pgViewTeamDetails page = new pgViewTeamDetails(_teamID, masterManager);
            NavigationService.Navigate(page);
        }
    }
}
