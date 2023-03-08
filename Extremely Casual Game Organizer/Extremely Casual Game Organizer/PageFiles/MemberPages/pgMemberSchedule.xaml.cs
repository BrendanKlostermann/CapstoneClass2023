/// Created By: Jacob Lindauer
/// Date: 2023/07/03
/// 
/// Class loads the schedule list and calendar view and handles event adding for the members schedule.
using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Extremely_Casual_Game_Organizer.PageFiles.MemberPages
{
    /// <summary>
    /// Interaction logic for pgMemberSchedule.xaml
    /// </summary>
    public partial class pgMemberSchedule : Page
    {
        Member _member = null;
        MasterManager _masterManager = null;
        public pgMemberSchedule(Member member, MasterManager masterManager)
        {
            _member = member;
            _masterManager = masterManager;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadEventList();
        }

        /// <summary>
        /// Created BY: Jacob Lindauer
        /// Date: 2023/07/03
        /// 
        /// Method loads the event list for the member. Should provide list of games, tournament games, and pracitces sorted by date.
        /// Need to implement the availability List and to set list to a calendar view object.  
        /// </summary>
        private void LoadEventList()
        {
            try
            {
                List<CalendarEvent> events = _masterManager.MemberManager.RetreiveMemberSchedule(_member.MemberID);

                datEventList.AutoGenerateColumns = false;
                datEventList.Focusable = false;
                datEventList.IsReadOnly = true;

                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding("EventID");
                column.Header = "EventID";
                column.Visibility = Visibility.Hidden;
                column.Width = new DataGridLength(100);
                datEventList.Columns.Add(column);

                DataGridTextColumn column1 = new DataGridTextColumn();
                column1.Binding = new Binding("Type");
                column1.Header = "Event Type";
                column1.Width = new DataGridLength(100);
                datEventList.Columns.Add(column1);

                DataGridTextColumn column2 = new DataGridTextColumn();
                column2.Binding = new Binding("Location");
                column2.Header = "Location";
                column2.Width = new DataGridLength(75);
                datEventList.Columns.Add(column2);

                DataGridTextColumn column3 = new DataGridTextColumn();
                column3.Binding = new Binding("Date");
                column3.Header = "Date and Time";
                column3.Width = new DataGridLength(150);
                datEventList.Columns.Add(column3);


                datEventList.ItemsSource = events.OrderBy(x => x.Date);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
