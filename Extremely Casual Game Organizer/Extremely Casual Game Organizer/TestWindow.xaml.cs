using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private League _league = null;
        private LeagueManager _leagueManager = new LeagueManager();


        public TestWindow()
        {
            InitializeComponent();
        }

        private void btnToEditLeague_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new pgAddEditLeague());
        }

        private void btnInsertLeagueID_Click(object sender, RoutedEventArgs e)
        {
            var leagueID = Int32.Parse(txtLeagueInput.Text);

            
        }

        private void btnToLeagueList_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new pgViewLeagueList());
        }
    }
}
