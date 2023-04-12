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
using LogicLayerInterfaces;
using LogicLayer;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgModifyTournament.xaml
    /// </summary>
    public partial class pgModifyTournament : Page
    {
        Tournament _tournament;
        ITournamentManager _tournamentManager;
        PageControl _pageControl;
        Button _confirmButton;
        Button _cancelButton;
        int memberID;
        public pgModifyTournament(int id, Tournament tournament)
        {
            memberID = id;
            _pageControl = new PageControl();
            _tournament = tournament;
            _tournamentManager = new TournamentManager();
            InitializeComponent();
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method loads needed assets for the page and its methods.
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SportManager sportManager = new SportManager();

            var selectedSportDesc = from sport in sportManager.RetrieveAllSports()
                                where sport.SportId.Equals(_tournament.SportID)
                                select sport.Description;

            _confirmButton = _pageControl.SetCustomButton("Confirm", 1);
            _cancelButton = _pageControl.SetCustomButton("Cancel", 4);

            _confirmButton.Click += ConfirmButton_Click;
            _cancelButton.Click += CancelButton_Click;


            cmbEditGender.ItemsSource = new List<string>() { "Male", "Female", "NB" };
            cmbEditSport.ItemsSource = sportManager.RetrieveAllSports().Select(x => x.Description);
            cmbEditSport.SelectedItem = selectedSportDesc.First();
            try
            {
                txtEditName.Text = _tournament.Name;
                txtEditDescription.Text = _tournament.Description;
                if (_tournament.Gender == true)
                {
                    cmbEditGender.SelectedItem = "Male";
                }
                else if (_tournament.Gender == false)
                {
                    cmbEditGender.SelectedItem = "Female";
                }
                else
                {
                    cmbEditGender.SelectedItem = "NB";
                }
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }


        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method backs the user out of the modify tournament screen.
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgViewTournamentList());
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method is used to confirm the modifications made by the user and saves them to the database.
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            SportManager sportManager = new SportManager();
            if (txtEditName.Text == "")
            {
                MessageBox.Show("Name can not be empty");
            }
            if (txtEditDescription.Text == "")
            {
                MessageBox.Show("Description can not be empty");
            }
            if (cmbEditSport.SelectedItem == null)
            {
                MessageBox.Show("DPlease choose a sport");
            }
            if (cmbEditGender.SelectedItem == null)
            {
                MessageBox.Show("Gender can not be empty");
            }

            Tournament tournament = new Tournament();
            tournament.TournamentID = _tournament.TournamentID;
            tournament.MemberID = _tournament.MemberID;
            tournament.Name = txtEditName.Text;

            switch (cmbEditGender.SelectedItem)
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

            var selectedSport = from sport in sportManager.RetrieveAllSports()
                                  where sport.Description.Equals(cmbEditSport.SelectedItem)
                                  select sport;


            tournament.SportID = selectedSport.First().SportId;
            tournament.Description = txtEditDescription.Text;
            tournament.Active = true;

            try
            {
                _tournamentManager = new TournamentManager();
                bool success = _tournamentManager.EditTournament(_pageControl.GetSignedInMember().MemberID, tournament);

                if (success)
                {
                    MessageBox.Show("Your tournament was successfully updated.");
                    _pageControl.LoadPage(new pgViewTournamentList());
                }
                else
                {
                    MessageBox.Show("An error occured. The tournament could not be updated at this time.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _confirmButton.Click -= ConfirmButton_Click;
            _cancelButton.Click -= CancelButton_Click;
            _confirmButton = null;
            _cancelButton = null;
        }
    }
}
