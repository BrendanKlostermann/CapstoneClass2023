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
using DataObjects;
using LogicLayer;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgCreateTournament.xaml
    /// </summary>
    public partial class pgCreateTournament : Page
    {
        TournamentManager _tournamentManager;

        MainWindow _mainWindow;
        public pgCreateTournament()
        {
            InitializeComponent();
            _tournamentManager = new TournamentManager();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tournament tournament = new Tournament();
            tournament.Description = txtDescription.Text;
            tournament.Name = txtName.Text;
            tournament.SportID = ((Sport)cmbSport.SelectedItem).SportId;
            _mainWindow = (MainWindow)Application.Current.MainWindow;
            // Member member = _mainWindow.CurrentMember;
            // tournament.MemberID = member.MemberID;
            switch (cmbGender.SelectedItem)
            {
                case "Male":
                    tournament.Gender = true;
                    break;
                case "Female":
                    tournament.Gender = false;
                    break;
                default:
                    tournament.Gender = null;
                    break;
            }
            try
            {
                if (_tournamentManager.CreateTournament(tournament))
                {
                    MessageBox.Show("The new tournament was created!");
                }
                else
                {
                    MessageBox.Show("An error occured, the tournament was not created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured \n\n" + ex.Message + "\n\n" + ex.InnerException.Message);
            }
            
            
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cmbGender.ItemsSource = new List<string>() { "Male", "Female", "NB" };
            cmbSport.ItemsSource = new List<Sport>();
        }
    }
}
