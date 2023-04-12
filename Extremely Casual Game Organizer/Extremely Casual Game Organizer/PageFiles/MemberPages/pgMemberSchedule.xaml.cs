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
        List<CalendarEvent> _events = null;
        string _selectedDate;
        Dictionary<int, ListBox> _calendarDays;
        Button _viewButton;
        Button _createButton;
        Button _fullDetails;
        Button _removeButton;
        PageControl _pageControl;
        public pgMemberSchedule(Member member, MasterManager masterManager)
        {
            _member = member;
            _masterManager = masterManager;
            _pageControl = new PageControl();
            InitializeComponent();
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Loaded event for setting button click events and obtaining event list for member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                _viewButton = _pageControl.SetCustomButton("View", 1);
                _createButton = _pageControl.SetCustomButton("Set Availability", 2);
                _fullDetails = _pageControl.SetCustomButton("Full Game Details", 5);
                _removeButton = _pageControl.SetCustomButton("Remove Availbilty", 3);

                _viewButton.Click += ViewButton_Click;
                _createButton.Click += CreateButton_Click;
                _fullDetails.Click += FullDetails_Click;
                _removeButton.Click += RemoveButton_Click;

                // Get current Date
                _selectedDate = DateTime.Now.ToShortDateString();
                LoadCalendar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/25/03
        /// 
        /// Button for removing availability events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CalendarEvent removeEvent = new CalendarEvent();

                bool remove = false;
                // Check if availabilty type is selected
                foreach (var listBox in _calendarDays.Values)
                {
                    // Get selected item text box.
                    var selectedBox = (TextBox)listBox.SelectedItem;

                    if (listBox.SelectedIndex != 0 && listBox.SelectedItem != null && ((CalendarEvent)selectedBox.DataContext).Type == "Availability")
                    {
                        removeEvent.EventID = ((CalendarEvent)selectedBox.DataContext).EventID;
                        removeEvent.Type = "Availability";
                        remove = true;
                        listBox.SelectedItem = null;
                        break;
                    }
                    else
                    {
                        remove = false;
                    }
                }

                if (remove == false)
                {
                    MessageBox.Show("Select a valid availability to remove");
                }
                if (remove == true)
                {
                    var result =  MessageBox.Show("Are you sure you want to remove this event?", "Remove Availability", MessageBoxButton.OKCancel);

                    if (result == MessageBoxResult.OK)
                    {
                        bool removeResult = _masterManager.MemberManager.RemoveCalendarEvent(removeEvent, _member.MemberID);

                        if (removeResult == true)
                        {
                            MessageBox.Show("Removal Successful!");
                            LoadCalendar();
                        }
                        else
                        {
                            MessageBox.Show("Removal Failed, please try again later");
                        }
                    }
                    if (result == MessageBoxResult.Cancel)
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Full Details button click event.
        /// Should only allow view for Game and Tournament game types.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int gameID = 0;

                // Loop through CalendarDays dictionary 
                foreach (var listBox in _calendarDays.Values)
                {
                    // Get selected item text box.
                    var selectedBox = (TextBox)listBox.SelectedItem;

                    // View selected item if a valid item is selected and if the item type is not an availability event. 
                    // Also need to verify the date is not selected. Will be 1st index
                    if (listBox.SelectedIndex != 0 && listBox.SelectedItem != null && (((CalendarEvent)selectedBox.DataContext).Type == "Game" || ((CalendarEvent)selectedBox.DataContext).Type == "Tournament Game"))
                    {
                        // Get selected Item
                        var selectedItem = (TextBox)listBox.SelectedItem;

                        // Convert selected item into calendar event
                        CalendarEvent selectedEvent = (CalendarEvent)selectedItem.DataContext;

                        gameID = selectedEvent.EventID;

                        listBox.SelectedItem = null;
                        break;
                    }
                }
                if (lstEvents.SelectedItem != null)
                {
                    ListBoxItem selectedListItem = (ListBoxItem)lstEvents.SelectedItem;

                    CalendarEvent selectedEvent = (CalendarEvent)selectedListItem.DataContext;
                    if (selectedEvent.Type != "Game" && selectedEvent.Type != "Tournament Game")
                    {
                        MessageBox.Show("Select a valid game to view");
                        lstEvents.SelectedItem = null;
                        return;
                    }
                    else
                    {
                        gameID = selectedEvent.EventID;

                        lstEvents.SelectedItem = null;
                    }
                }

                if (gameID != 0)
                {
                    pgViewGameDetails viewGame = new pgViewGameDetails(gameID, _masterManager);

                    gameID = 0;
                    _pageControl.LoadPage(viewGame, new pgMemberSchedule(_member, _masterManager));
                }
                else
                {
                    MessageBox.Show("Select a Valid Game");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Create Availability Butotn Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            winEventDetails createEvent = new winEventDetails(_masterManager);
            createEvent.ShowDialog();

            bool? dialogResult = createEvent.DialogResult;

            if (dialogResult == true)
            {
                LoadCalendar();
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2022/20/03
        /// 
        /// View Button Click Event.
        /// Views selected item based on its item type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstEvents.SelectedItem != null)
                {
                    ListBoxItem selectedListItem = (ListBoxItem)lstEvents.SelectedItem;

                    CalendarEvent selectedEvent = (CalendarEvent)selectedListItem.DataContext;

                    winEventDetails viewDetails = new winEventDetails(selectedEvent, _masterManager);

                    lstEvents.SelectedItem = null;
                    viewDetails.ShowDialog();
                    return;
                }
                else
                {
                    foreach (var listBox in _calendarDays.Values)
                    {
                        if (listBox.SelectedItem != null)
                        {
                            if (listBox.SelectedIndex != 0)
                            {
                                // Get selected Item
                                var selectedItem = (TextBox)listBox.SelectedItem;
                                // Convert selected item into calendar event
                                CalendarEvent selectedEvent = (CalendarEvent)selectedItem.DataContext;

                                winEventDetails viewDetails = new winEventDetails(selectedEvent, _masterManager);

                                viewDetails.ShowDialog();

                                if (viewDetails.DialogResult == true)
                                {
                                    LoadCalendar();
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Select a valid item to view");
                            }
                        }
                    }
                    // Deslect all items in all listboxes
                    foreach (var listBox in _calendarDays.Values)
                    {
                        if (listBox.SelectedItem != null)
                        {
                            listBox.SelectedItem = null;
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
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
                // Loop through events and exclude availability types
                foreach (var item in _events.Where(x => x.Type != "Availability").OrderBy(x => x.Date))
                {
                    ListBoxItem addEvent = new ListBoxItem();
                    addEvent.BorderBrush = Brushes.Black;
                    addEvent.Margin = new Thickness(5);
                    addEvent.MaxWidth = 160;

                    StackPanel eventStack = new StackPanel();

                    //Event Location
                    TextBlock eventLocation = new TextBlock()
                    {
                        Text = item.Location
                        ,
                        TextWrapping = TextWrapping.Wrap
                    };

                    // Event Time
                    TextBlock eventTime = new TextBlock()
                    {
                        Text = item.Date
                    };

                    // Type Label
                    TextBlock typeLabel = new TextBlock()
                    {
                        Text = item.Type
                        ,
                        FontWeight = FontWeights.Bold
                    };

                    // Location Label
                    TextBlock locationLabel = new TextBlock()
                    {
                        Text = "Location: "
                        ,
                        FontWeight = FontWeights.Bold
                    };

                    // Time Label
                    TextBlock timeLabel = new TextBlock()
                    {
                        Text = "Time: "
                        ,
                        FontWeight = FontWeights.Bold
                    };

                    // Type Dock
                    DockPanel typeDock = new DockPanel();
                    typeDock.Children.Add(typeLabel);

                    // Location Dock
                    DockPanel locationDock = new DockPanel();
                    locationDock.Children.Add(locationLabel);

                    // Time Dock
                    DockPanel timeDock = new DockPanel();
                    timeDock.Children.Add(timeLabel);
                    timeDock.Children.Add(eventTime);

                    // Add dockpanels to stack panel
                    eventStack.Children.Add(typeDock);
                    eventStack.Children.Add(locationDock);
                    eventStack.Children.Add(eventLocation);
                    eventStack.Children.Add(timeDock);

                    // Add stack panel to listboxItem
                    addEvent.Content = eventStack;

                    // Attached eventID to listbox item
                    addEvent.DataContext = item;

                    lstEvents.Items.Add(addEvent);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/14
        /// 
        /// Method will load events into the calendar.
        /// For this to work you need to change the CalendarEvents List to a dictionary based on its date and event type.
        /// </summary>
        private void LoadCalendar()
        {
            try
            {
                _events = _masterManager.MemberManager.RetreiveMemberSchedule(_member.MemberID);
                UpdateCalendar();
                LoadEventList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/14
        /// 
        /// Method will update month title depending on input month
        /// </summary>
        private void UpdateCalendar()
        {
            try
            {
                DateTime calendarDate = Convert.ToDateTime(_selectedDate);
                int month = Convert.ToDateTime(_selectedDate).Month;
                // Need to set month label. Is going to be 1-12 based on current month.
                switch (month)
                {
                    case 1:
                        lblMonth.Content = "January " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 1);
                        AddEvents();
                        break;
                    case 2:
                        lblMonth.Content = "Feburary " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 2);
                        AddEvents();
                        break;
                    case 3:
                        lblMonth.Content = "March " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 3);
                        AddEvents();
                        break;
                    case 4:
                        lblMonth.Content = "April " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 4);
                        AddEvents();
                        break;
                    case 5:
                        lblMonth.Content = "May " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 5);
                        AddEvents();
                        break;
                    case 6:
                        lblMonth.Content = "June " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 6);
                        AddEvents();
                        break;
                    case 7:
                        lblMonth.Content = "July " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 7);
                        AddEvents();
                        break;
                    case 8:
                        lblMonth.Content = "August " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 8);
                        AddEvents();
                        break;
                    case 9:
                        lblMonth.Content = "September " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 9);
                        AddEvents();
                        break;
                    case 10:
                        lblMonth.Content = "October " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 10);
                        AddEvents();
                        break;
                    case 11:
                        lblMonth.Content = "November " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 11);
                        AddEvents();
                        break;
                    case 12:
                        lblMonth.Content = "December " + calendarDate.Year;
                        UpdateDaysInMonth(calendarDate.Year, 12);
                        AddEvents();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/14
        /// 
        /// Method will updated days of the month depending on provided momth and year. Should account for leap years.
        /// Method will remove all events and dates from calendar listboxes
        /// </summary>
        private void UpdateDaysInMonth(int year, int month)
        {
            try
            {
                // selectDate gets the first day of the month determined by provided year and month parameters. 
                DateTime selectedDate = new DateTime(year, month, 1);

                // Instanciate Dictionary
                if (_calendarDays == null)
                {
                    _calendarDays = new Dictionary<int, ListBox>();
                }
                else
                {
                    _calendarDays.Clear();
                }

                // Hide all Listboxes
                foreach (var listBox in grdCalendar.Children.OfType<ListBox>())
                {
                    listBox.Items.Clear();
                    listBox.Background = Brushes.White;
                    listBox.Visibility = Visibility.Hidden;
                }

                // Find out what day the month starts
                string startDay = selectedDate.ToString("dddd");
                int startDayInt = 0;
                switch (startDay)
                {
                    case "Sunday":
                        startDayInt = 1;
                        break;
                    case "Monday":
                        startDayInt = 2;
                        break;
                    case "Tuesday":
                        startDayInt = 3;
                        break;
                    case "Wednesday":
                        startDayInt = 4;
                        break;
                    case "Thursday":
                        startDayInt = 5;
                        break;
                    case "Friday":
                        startDayInt = 6;
                        break;
                    case "Saturday":
                        startDayInt = 7;
                        break;
                    default:
                        break;
                }

                // Find out how many days are in that month
                int daysInMonth = DateTime.DaysInMonth(year, month);

                // Loop through list boxes and add a number to those that are provided for the month and unhide them.
                // Determine what list box will start the month, lopp through the list boxes until end of month is set
                // Add calendar days to calendar dictionary
                int day = 1;
                foreach (var listBox in grdCalendar.Children.OfType<ListBox>())
                {
                    if (Convert.ToInt32(listBox.Name.Substring(3)) >= startDayInt && day <= daysInMonth)
                    {
                        listBox.Visibility = Visibility.Visible;
                        listBox.Items.Add(new TextBox() { Text = day.ToString(), Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, FontSize = 12, IsReadOnly = true, IsEnabled = false, Focusable = false }) ;
                        _calendarDays.Add(day, listBox);
                        day++;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/14
        /// 
        /// Changed month to the next one
        /// </summary>
        private void btnMonthForward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime tempDate = Convert.ToDateTime(_selectedDate);
                int day = tempDate.Day;
                int month = tempDate.Month;
                int year = tempDate.Year;
                if (tempDate.Month == 12)
                {
                    month = 1;
                    year += 1;
                }
                else
                {
                    month += 1;
                }
                // Update SelectedDate
                string newDate = month + "/" + day + "/" + year;
                _selectedDate = Convert.ToDateTime(newDate).ToShortDateString();
                UpdateCalendar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/03/14
        /// 
        /// Changed month to the previous one
        /// </summary>
        private void btnMonthBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime tempDate = Convert.ToDateTime(_selectedDate);
                int day = tempDate.Day;
                int month = tempDate.Month;
                int year = tempDate.Year;
                if (tempDate.Month == 1)
                {
                    month = 12;
                    year -= 1;
                }
                else
                {
                    month -= 1;
                }

                // Update SelectedDate
                string newDate = month + "/" + day + "/" + year;
                _selectedDate = Convert.ToDateTime(newDate).ToShortDateString();
                UpdateCalendar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/18/03
        /// 
        /// Method will go through events and add them to the calandar
        /// </summary>
        private void AddEvents()
        {
            try
            {
                if (_events.Count > 0)
                {
                    txtNoEvents.Visibility = Visibility.Hidden;
                    // Loop through member events
                    foreach (var item in _events)
                    {
                        // Determine if event is availability type. Will contain comma in date
                        if (item.Date.Contains(','))
                        {
                            // Parse dates to get start date and end date
                            string[] dates = item.Date.Split(',');
                            DateTime startDate = Convert.ToDateTime(dates[0]);
                            DateTime endDate = Convert.ToDateTime(dates[1]);

                            // Determine if dates apply to current month
                            if (startDate.Month == Convert.ToDateTime(_selectedDate).Month && startDate.Year == Convert.ToDateTime(_selectedDate).Year)
                            {
                                // Add events to calendar items
                                foreach (var day in _calendarDays)
                                {
                                    // Make sure dates are in the availability date span
                                    if (startDate.Day <= day.Key && endDate.Day >= day.Key)
                                    {
                                        // Add start date
                                        if (day.Key == startDate.Day)
                                        {
                                            day.Value.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);

                                            TextBox addEvent = new TextBox() { DataContext = item, TextWrapping = TextWrapping.Wrap, FontSize = 10, Text = "Unavailable\n" + "Start " + Convert.ToDateTime(startDate).ToString("h:mm tt"), Width = 60, IsReadOnly = true, Cursor = Cursors.Hand, Background = Brushes.PaleVioletRed, Focusable = false };

                                            day.Value.Items.Add(addEvent);
                                        }
                                        // Add end date
                                        if (day.Key == endDate.Day)
                                        {
                                            day.Value.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);

                                            TextBox addEvent = new TextBox() { DataContext = item, FontSize = 10, TextWrapping = TextWrapping.Wrap, Text = "Unavailable\n" + "End " + Convert.ToDateTime(endDate).ToString("h:mm tt"), Width = 60, IsReadOnly = true, Cursor = Cursors.Hand, Background = Brushes.PaleVioletRed, Focusable = false };

                                            day.Value.Items.Add(addEvent);
                                        }
                                        // Add between dates
                                        if (day.Key > startDate.Day && day.Key < endDate.Day)
                                        {
                                            day.Value.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);

                                            TextBox addEvent = new TextBox() { DataContext = item, FontSize = 10, Text = "Unavailable", Width = 60, IsReadOnly = true, Cursor = Cursors.Hand, Background = Brushes.PaleVioletRed, Focusable = false };

                                            day.Value.Items.Add(addEvent);
                                        }
                                    }
                                }
                            }
                        }
                        // For non availability types
                        else
                        {
                            // Determine if event dates apply to current month
                            if (Convert.ToDateTime(item.Date).Month == Convert.ToDateTime(_selectedDate).Month && Convert.ToDateTime(item.Date).Year == Convert.ToDateTime(_selectedDate).Year)
                            {
                                // Need to get the date value from event to update date in calendar
                                int date = Convert.ToDateTime(item.Date).Day;

                                foreach (var day in _calendarDays)
                                {
                                    if (date == day.Key)
                                    {
                                        day.Value.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);

                                        TextBox addEvent = new TextBox() { DataContext = item, FontSize = 10, Text = item.Type + "\n" + Convert.ToDateTime(item.Date).ToString("h:mm tt"), Width = 60, TextWrapping = TextWrapping.Wrap, IsReadOnly = true, Cursor = Cursors.Hand, Focusable = false };

                                        // Apply event background based on type.
                                        switch (item.Type)
                                        {
                                            case "Game":
                                                addEvent.Background = Brushes.LightGreen;
                                                break;
                                            case "Tournament Game":
                                                addEvent.Background = Brushes.LightYellow;
                                                break;
                                            case "Practice":
                                                addEvent.Background = Brushes.LightSkyBlue;
                                                break;
                                            default:
                                                break;
                                        }
                                        day.Value.Items.Add(addEvent);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Unloaded method to remove click events. Avoids click event loops.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _viewButton.Click -= ViewButton_Click;
            _createButton.Click -= CreateButton_Click;
            _fullDetails.Click -= FullDetails_Click;
        }
    }
}
