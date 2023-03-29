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

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    /// Interaction logic for pgHelp.xaml
    /// </summary>
    public partial class pgHelp : Page
    {
        //Button back = null;
        PageControl pg;
        public pgHelp()
        {
            //pg = new PageControl();
            InitializeComponent();
        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    back = pg.ShowGoBack();
        //    back.Click += BackButton_Click;
        //}

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    pg.LoadPage(pg.GetPreviousPage());
        //}

        //private void Page_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    back.Click -= BackButton_Click;
        //}

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
