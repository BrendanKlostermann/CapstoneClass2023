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
using LogicLayer;
using DataObjects;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgViewTournamentList.xaml
    /// </summary>
    public partial class pgViewTournamentList : Page
    {
        TournamentManager _tournamentManager = null;
        List<TournamentVM> _tournaments;

        public pgViewTournamentList()
        {
            InitializeComponent();
            _tournamentManager = new TournamentManager();

        }

        private void datTournamentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_tournaments == null)
                {
                    _tournaments = _tournamentManager.RetrieveAllTournamentVMs();
                    datTournamentGrid.ItemsSource = _tournaments;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
            
        }

        private void datTournamentGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            datTournamentGrid.ItemsSource = null;
            _tournaments = null;
        }
    }
}
