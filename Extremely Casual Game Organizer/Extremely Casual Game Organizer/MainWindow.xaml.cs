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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MasterManager _masterManager = null;
        PageControl _pageControl = null;

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

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _pageControl.LoadPage(new pgLogIn(_masterManager));
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
                _pageControl.LoadPage(new pgGameList(_masterManager ));
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
                // _pageControl.LoadPage(new pgViewTeamDetails(1030, _masterManager));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void navTeams_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgViewTeamList(_masterManager));
        }

        private void navSchedule_Click(object sender, RoutedEventArgs e)
        {
            Member openMember = new Member()
            {
                MemberID = 100000
            };
            _pageControl.LoadPage(new pgMemberSchedule(openMember, _masterManager));
        }
    }
}
