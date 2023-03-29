/// <summary>
/// Created BY: Jacob Lindauer
/// Date: 2023/31/01
/// 
/// Configuration for the main window of the applicaiton.
/// 
/// Updated By: Jacob Lindauer
/// Date: 2023/23/02
/// 
/// Updated the Events tab to be Games instead
/// 
/// Updated By: Jacob Lindauer
/// Date: 2023/02/28
/// 
/// Added class properties for CurrentPage and PreviousPage.
/// This will allow you to navigate back to previous pages as you navigate throughout the program.
/// Since this window should not be newed up after it is running, this made the most sense to place them here.
/// 
/// Updated By: Jacob Lindauer
/// Date: 2023/03/04
/// 
/// Added the CurrentMember property so we can set the current signed in member and get their roles for access
/// </summary>
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
using Extremely_Casual_Game_Organizer.PageFiles;
using Extremely_Casual_Game_Organizer.PageFiles.MemberPages;
using Extremely_Casual_Game_Organizer.PageFiles.Utility;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MasterManager _masterManager = null;
        PageControl _pageControl = null;
        Member _member = null;
        private TeamManager masterManager;

        public Page PreviousPage { get; set; }
        public Page CurrentPage { get; set; }
        public Member CurrentMember { get; set; }

        public MainWindow()
        {
            _pageControl = new PageControl();
            _masterManager = new MasterManager();
            InitializeComponent();
            // Hide all function buttons
            grdFrameFunctions.Visibility = Visibility.Hidden;


        }
        /// <summary>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Redirected loaded to set UI for logout and load the homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                updateUIforLogout();
                _pageControl.LoadPage(new pgHomepage(_pageControl, _masterManager));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void navGames_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _pageControl.LoadPage(new pgGameList(_masterManager));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "/n/n" + ex.InnerException.Message);
            }

        }

        private void navLeagues_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _pageControl.LoadPage(new pgViewLeagueList(_masterManager));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "/n/n" + ex.InnerException.Message);
            }
        }

        private void navSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TeamManager teamManager = new TeamManager();
                _pageControl.LoadPage(new pgSearchforTeam(_masterManager));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void navTeams_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TeamManager teamManager = new TeamManager();
                _pageControl.LoadPage(new pgViewTeamList(_masterManager));
            }
            catch (Exception up)
            {
                MessageBox.Show(up.Message + "\n\n" + up.InnerException.Message);
            }
        }

        /// <summary>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Setup button to make sure user is signed in first
        /// </summary>
        private void navSchedule_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (CurrentMember == null)
                {
                    MessageBox.Show("Please sign in to view your schedule");
                }
                else
                {
                    _pageControl.LoadPage(new pgMemberSchedule(CurrentMember, _masterManager));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created by Garion Opiola
        /// Created 02/28/2023
        /// Logout Logic
        /// 
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Updated method to implement useful logout logic
        /// Set buttons to be hidden upon logout and set member to null then load the homepage to the main view. 
        /// </summary>
        /// 
        private void updateUIforLogout()
        {
            btnSignOut.Visibility = Visibility.Hidden;
            txtSignedIn.Visibility = Visibility.Hidden;
            CurrentMember = null;
            _pageControl.LoadPage(new pgHomepage(_pageControl, _masterManager));
        }

        private void btnAlerts_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Setup button to make sure user is signed in first
        /// </summary>
        private void openMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentMember == null)
                {
                    MessageBox.Show("Please sign in to view your messages");
                }
                else
                {
                    pgRespondToMessage _pgRespondToMessage = new pgRespondToMessage();
                    _pgRespondToMessage.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Setup button to make sure user is signed in first
        /// </summary>
        private void openProfile(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentMember == null)
                {
                    MessageBox.Show("Please sign in to view your profile");
                }
                else
                {
                    _pageControl.LoadPage(new pgMemberProfile(_masterManager));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Updated By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Setup button to direct to created homepage page
        /// </summary>
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _pageControl.LoadPage(new pgHomepage(_pageControl, _masterManager));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/26/03
        /// 
        /// Button preforms logout method
        /// </summary>
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            updateUIforLogout();
        }
    }
}
