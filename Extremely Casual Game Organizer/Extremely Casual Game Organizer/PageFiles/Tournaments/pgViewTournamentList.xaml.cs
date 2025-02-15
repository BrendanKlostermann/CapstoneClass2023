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
using Extremely_Casual_Game_Organizer.PageFiles.Practices;
using Extremely_Casual_Game_Organizer.PageFiles.Tournaments;
using LogicLayer;
using LogicLayerInterfaces;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgViewTournamentList.xaml
    /// </summary>
    public partial class pgViewTournamentList : Page
    {
        TournamentManager _tournamentManager = null;
        List<TournamentVM> _tournaments;
        PageControl _pageControl;
        Button _viewButton;
        Button _updateButton;
        Button _addButton;
        Button _deleteButton;

        public pgViewTournamentList()
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
        /// This method is used to Load needed items for the page
        private void datTournamentGrid_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {

                List<Button> buttons = _pageControl.ShowFullCRUD();
                _addButton = buttons[0];
                _viewButton = buttons[1];
                _updateButton = buttons[2];
                _deleteButton = buttons[3];


                if (_tournaments == null)
                {
                    _tournaments = _tournamentManager.RetrieveAllTournamentVMs();
                    datTournamentGrid.ItemsSource = _tournaments;

                    //Removes not needed data from being displayed, Like ID values and bools.
                    datTournamentGrid.Columns[3].Visibility = Visibility.Hidden;
                    datTournamentGrid.Columns[0].Visibility = Visibility.Hidden;
                }


                //Attach methods to the buttons.
                _addButton.Click += AddButton_Click;
                _updateButton.Click += UpdateButton_Click;
                _deleteButton.Click += DeleteButton_Click;
                _viewButton.Click += ViewButton_Click;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }
        /// <summary>
        /// Nick Vroom
        /// Created: 2023/04/24
        /// 
        /// </summary>
        /// this method views a tournament's details when clicking the view button
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datTournamentGrid.SelectedItem == null)
                {
                    MessageBox.Show("You must select a tournament");
                    return;
                }
                else
                {
                    int tournamentID = ((TournamentVM)datTournamentGrid.SelectedItem).TournamentID;
                    pgViewTournament page = new pgViewTournament(tournamentID);

                    _pageControl.LoadPage(page);
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
        /// this method will allow a user to deactivate their tournaments so it will no longer show up as
        /// available
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Member member = null;
            Tournament tournament = null;

            try
            {
                if (datTournamentGrid.SelectedItem == null)
                {
                    MessageBox.Show("You must select a tournament");
                    return;
                }
                member = _pageControl.GetSignedInMember();
                if (member == null)
                {
                    MessageBox.Show("You must be signed in to make changes.");
                    return;
                }

                //Create a tournament based off tournament id from the view model
                int tournamentID = ((TournamentVM)datTournamentGrid.SelectedItem).TournamentID;
                tournament = _tournamentManager.RetrieveTournamentByTournamentID(tournamentID);

                if (member.MemberID == tournament.MemberID)
                {
                    if (MessageBox.Show("Are you sure you want to delete this tounrament?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (_tournamentManager.DeleteTournament(member.MemberID, tournament.TournamentID))
                        {
                            MessageBox.Show("Tournament successfully deleted.");
                            _pageControl.LoadPage(new pgViewTournamentList());
                        }
                        else
                        {
                            MessageBox.Show("Could not delete the tournament");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You are not the owner of this tournament and can not delete it.");
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
        /// this method allows a user to update their own tournament information.
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Member member = _pageControl.GetSignedInMember();
            if (member == null)
            {
                MessageBox.Show("You must be signed in to make changes.");
                return;
            }
            if (datTournamentGrid.SelectedItem == null)
            {
                MessageBox.Show("You must select a tournament to edit.");
                return;
            }

            //Create a tournament based off tournament id from the view model
            int tournamentID = ((TournamentVM)datTournamentGrid.SelectedItem).TournamentID;
            Tournament tournament = _tournamentManager.RetrieveTournamentByTournamentID(tournamentID);
            if (member.MemberID == tournament.MemberID)
            {
                try
                {
                    _pageControl.LoadPage(new pgModifyTournament(member.MemberID, tournament), new pgViewTournamentList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n");
                }
            }
            else
            {
                MessageBox.Show("You are not the owner of this tournament and can not edit it.");
            }

        }


        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// this method allows a user to create a new tournament. It uses the logged in user's id
        /// to set as the memberID.
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageControl.GetSignedInMember() == null)
            {
                MessageBox.Show("You must be signed in to create a tournament");
                return;
            }

            try
            {
                _pageControl.LoadPage(new pgCreateTournament(), new pgViewTournamentList());
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
        /// this method will unload the pages assets so that no issues will be cause later.
        private void datTournamentGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            datTournamentGrid.ItemsSource = null;
            _tournaments = null;
            datTournamentGrid.SelectedItem = null;



            //Remove method attachment from buttons
            _addButton.Click -= AddButton_Click;
            _updateButton.Click -= UpdateButton_Click;
            _deleteButton.Click -= DeleteButton_Click;
            _viewButton.Click -= ViewButton_Click;
        }

    }
}
