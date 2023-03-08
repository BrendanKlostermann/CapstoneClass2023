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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemberManager _memberManager = null;
        Member _member = null;
        PageControl _pageControl = null;
        public MainWindow()
        {
            _memberManager = new MemberManager();
            _pageControl = new PageControl();
            InitializeComponent();

            // Hide all function buttons
            grdFrameFunctions.Visibility = Visibility.Hidden;

        }

        private void navEvents_Click(object sender, RoutedEventArgs e)
        {
            GameManager gameManager = new GameManager();

            _pageControl.LoadPage(new pgGameList(gameManager));

        }

        private void navLeagues_Click(object sender, RoutedEventArgs e)
        {
            LeagueManager leagueManager = new LeagueManager();
            _pageControl.LoadPage(new pgViewLeagueList());
        }

        private void navSchedule_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
