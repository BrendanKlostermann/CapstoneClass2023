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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            TeamMemberManager tmm = new TeamMemberManager();
            List<Member> tempList = tmm.GetAListOfAllMembersByTeamID(1000);
            foreach(Member mem in tempList)
            {

            }
        }


        private void testButton_Click_1(object sender, RoutedEventArgs e)
        {
            frameLoad.Navigate(new TeamMemberScreen(1000));
            Window test = new Window();

        }
    }
}
