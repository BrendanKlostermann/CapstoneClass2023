﻿using System;
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
using LogicLayerInterfaces;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgCreateTournament.xaml
    /// </summary>
    public partial class pgCreateTournament : Page
    {
        TournamentManager _tournamentManager;
        PageControl _pageControl;
        Button _confirmButton;
        Button _cancelButton;

        MainWindow _mainWindow;
        public pgCreateTournament()
        {
            _pageControl = new PageControl();
            _tournamentManager = new TournamentManager();
            InitializeComponent();
        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This method loads the needed assets for this page and its methods.
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SportManager sportManager = new SportManager();
            
            cmbGender.ItemsSource = new List<string>() { "Male", "Female", "NB" };
            cmbSport.ItemsSource = sportManager.RetrieveAllSports().Select(x => x.Description);

            _confirmButton = _pageControl.SetCustomButton("Confirm", 1);
            _cancelButton = _pageControl.SetCustomButton("Cancel", 4);

            _confirmButton.Click += ConfirmButton_Click;
            _cancelButton.Click += CancelButton_Click;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method will take the user out of the create page and return them to the list of tournaments
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(_pageControl.GetPreviousPage());
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method confirms the creation of a new Tournament and uses the MemberID from the signed in member
        /// to determine the owner of the tournament.
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

            Tournament tournament = new Tournament();
            SportManager sportManager = new SportManager();

            if (txtName.Text == "")
            {
                MessageBox.Show("Name can not be blank");
                txtName.Focus();
                return;
            }

            if (cmbSport.SelectedItem == null)
            {
                MessageBox.Show("You must select a sport");
                return;
            }

            tournament.MemberID = _pageControl.GetSignedInMember().MemberID;
            tournament.Description = txtDescription.Text;
            tournament.Name = txtName.Text;
            var selectedSport = from sport in sportManager.RetrieveAllSports()
                                where sport.Description.Equals(cmbSport.SelectedItem)
                                select sport;


            tournament.SportID = selectedSport.First().SportId;
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
                    _pageControl.LoadPage(new pgViewTournamentList());
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

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method unloads the assets from the page to prevent any issues in the future.
        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _confirmButton.Click -= ConfirmButton_Click;
            _cancelButton.Click -= CancelButton_Click;
        }
    }
}
