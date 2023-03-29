/// <summary>
/// Created By: Jacob Lindauer
/// Date: 2023/20/03
/// 
/// Class file handles viewing and creating events from the member schedule.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;

namespace Extremely_Casual_Game_Organizer.PageFiles.MemberPages
{
    /// <summary>
    /// Interaction logic for winEventDetails.xaml
    /// </summary>
    public partial class winEventDetails : Window
    {
        CalendarEvent _calendarEvent;
        bool _editMode;
        int _memberID;
        PageControl _pageControl;
        MasterManager _masterManager;
        public winEventDetails(MasterManager masterManager)
        {
            _calendarEvent = new CalendarEvent();
            _editMode = true;
            _pageControl = new PageControl();
            _masterManager = masterManager;
            _memberID = _pageControl.GetSignedInMember().MemberID;
            InitializeComponent();
        }
        public winEventDetails(CalendarEvent calendarEvent, MasterManager masterManager)
        {
            _masterManager = masterManager;
            _calendarEvent = calendarEvent;
            _editMode = false;
            _pageControl = new PageControl();
            _memberID = _pageControl.GetSignedInMember().MemberID;
            InitializeComponent();
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Method handles items to be done upon page loade.
        /// Based on edit mode and event type provided. The page will load a certain way. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Viewing Mode
                if (_editMode == false)
                {
                    // Hide unneeded lables and textboxes
                    dateStartDate.Visibility = Visibility.Hidden;
                    dateEndDate.Visibility = Visibility.Hidden;
                    btnCancel.Visibility = Visibility.Hidden;
                    btnSave.Visibility = Visibility.Hidden;
                    lblDescription.Visibility = Visibility.Hidden;
                    txtDescription.Visibility = Visibility.Hidden;
                    btnEdit.Visibility = Visibility.Hidden;
                    txtEndDate.IsReadOnly = true;
                    txtEndDate.Focusable = false;
                    txtEndDate.IsReadOnly = true;
                    txtEndDate.Focusable = false;

                    // Update Event Header and window title
                    if (_calendarEvent.Type == "Practice")
                    {
                        lblDetails.Content = "Practice Details";
                        this.Title = "Pracitce";
                        lblEventStartDate.Content = "Date and Time: ";
                        txtStartDate.Text = _calendarEvent.Date;
                        lblEventEndDate.Visibility = Visibility.Hidden;
                        txtEndDate.Visibility = Visibility.Hidden;
                    }
                    else if (_calendarEvent.Type == "Game")
                    {
                        lblDetails.Content = "Game Details";
                        this.Title = "Game";
                        lblEventStartDate.Content = "Date and Time: ";
                        txtStartDate.Text = _calendarEvent.Date;
                        lblEventEndDate.Visibility = Visibility.Hidden;
                        txtEndDate.Visibility = Visibility.Hidden;
                    }
                    else if (_calendarEvent.Type == "Tournament Game")
                    {
                        lblDetails.Content = "Tournament Game Details";
                        this.Title = "Tournament Game";
                        lblEventStartDate.Content = "Date and Time: ";
                        txtStartDate.Text = _calendarEvent.Date;
                        lblEventEndDate.Visibility = Visibility.Hidden;
                        txtEndDate.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lblDetails.Content = "Availability Details";
                        this.Title = "Availability";

                        txtLocation.Visibility = Visibility.Hidden;
                        lblLocation.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Visible;
                        lblDescription.Visibility = Visibility.Visible;
                        txtDescription.Visibility = Visibility.Visible;

                        txtType.Text = _calendarEvent.Type;
                        string[] dates = _calendarEvent.Date.Split(',');
                        txtStartDate.Text = dates[0];
                        txtEndDate.Text = dates[1];
                        txtDescription.Text = _calendarEvent.Description;
                    }

                    // Add description if practice type
                    if (_calendarEvent.Type == "Practice")
                    {
                        lblDescription.Visibility = Visibility.Visible;
                        txtDescription.Visibility = Visibility.Visible;
                        txtDescription.Text = _calendarEvent.Description;
                    }

                    // Add other fields for details. These apply to all event types. 
                    txtType.Text = _calendarEvent.Type;
                    txtLocation.Text = _calendarEvent.Location;

                    this.Title = _calendarEvent.Type;
                }

                // Insert Availability Mode
                if (_editMode == true)
                {
                    lblLocation.Visibility = Visibility.Hidden;
                    btnClose.Visibility = Visibility.Hidden;
                    btnEdit.Visibility = Visibility.Hidden;
                    txtEndDate.IsReadOnly = false;
                    txtEndDate.Focusable = true;
                    txtEndDate.IsReadOnly = false;
                    txtEndDate.Focusable = true;
                    txtDescription.IsReadOnly = false;
                    txtDescription.Focusable = true;

                    btnSave.Content = "Add";
                    txtType.Text = "Availability";
                    this.Title = "Create New Availability";
                    lblDetails.Content = "Create Availability Event";
                    txtLocation.Text = "***Times are created and displayed in 24-hour format***";
                    txtLocation.FontSize = 12;
                    txtStartDate.Text = Convert.ToDateTime(dateStartDate.SelectedDate).ToString("MM/dd/yyyy HH:mm");
                    txtEndDate.Text = Convert.ToDateTime(dateEndDate.SelectedDate).ToString("MM/dd/yyyy HH:mm");
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
        /// Closes window
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Change the text box values when date changes on calendar
        /// </summary>
        private void dateStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStartDate.Text = Convert.ToDateTime(dateStartDate.SelectedDate).ToString("MM/dd/yyyy HH:mm");
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Change the text box values when date changes on calendar
        /// </summary>
        private void dateEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtEndDate.Text = Convert.ToDateTime(dateEndDate.SelectedDate).ToString("MM/dd/yyyy HH:mm");
        }


        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/20/03
        /// 
        /// Even occurs when save is clicked. Outcome will depend on if the user is saving changes or creating a new avilability event.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create Mode
                if (btnSave.Content.Equals("Add"))
                {
                    CalendarEvent addEvent = new CalendarEvent()
                    {
                        Type = "Availability"
                    };


                    var dateFormat = @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/\d{4} (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";

                    // Validate entries
                    if (txtStartDate.Text == null || txtStartDate.Text == "" || Regex.IsMatch(txtStartDate.Text, dateFormat) == false)
                    {
                        MessageBox.Show("Enter a valid start date");
                        txtStartDate.Focus();
                        return;
                    }
                    else if (txtEndDate.Text == null || txtEndDate.Text == "" || Regex.IsMatch(txtEndDate.Text, dateFormat) == false)
                    {
                        MessageBox.Show("Enter a valid end date");
                        txtEndDate.Focus();
                        return;
                    }
                    // TryParse will determine if provided date exists
                    else if (!DateTime.TryParse(txtStartDate.Text, out DateTime startdate)) 
                    {
                        MessageBox.Show("Selected start date does not exist!");
                        txtStartDate.Focus();
                        return;
                    }
                    else if (!DateTime.TryParse(txtEndDate.Text, out DateTime enddate))
                    {
                        MessageBox.Show("Selected end date does not exist!");
                        txtEndDate.Focus();
                        return;
                    }
                    else if (Convert.ToDateTime(txtEndDate.Text.ToString()).CompareTo(Convert.ToDateTime(txtStartDate.Text.ToString())) <= 0)
                    {
                        MessageBox.Show("End date must be after start date abd both dates and time cannot be the same");
                        txtEndDate.Focus();
                        return;
                    }
                    else
                    {
                        try
                        {
                            addEvent.Date = txtStartDate.Text + "," + txtEndDate.Text;

                            if (txtDescription.Text == null || txtDescription.Text == "")
                            {
                                addEvent.Description = "";
                            }
                            else
                            {
                                addEvent.Description = txtDescription.Text;
                            }

                            bool result = _masterManager.MemberManager.AddCalendarEvent(addEvent, _memberID);

                            if (result == true)
                            {
                                MessageBox.Show("Availability Addition Successful!");
                                this.DialogResult = true;
                            }
                            if (result == false)
                            {
                                MessageBox.Show("Availability Addition Failed!");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                        }
                    }
                }
                // Edit Mode
                if (btnSave.Content.Equals("Save"))
                {
                    CalendarEvent updateEvent = new CalendarEvent()
                    {
                        Type = "Availability"
                        ,
                        EventID = _calendarEvent.EventID
                    };

                    var dateFormat = @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/\d{4} (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";

                    // Validate Entries
                    if (txtStartDate.Text == null || txtStartDate.Text == "" || Regex.IsMatch(txtStartDate.Text, dateFormat) == false)
                    {
                        MessageBox.Show("Enter a valid start date");
                        txtStartDate.Focus();
                        return;
                    }
                    else if (txtEndDate.Text == null || txtEndDate.Text == "" || Regex.IsMatch(txtEndDate.Text, dateFormat) == false)
                    {
                        MessageBox.Show("Enter a valid end date");
                        txtEndDate.Focus();
                        return;
                    }
                    // TryParse will determine if provided date exists
                    else if (!DateTime.TryParse(txtStartDate.Text, out DateTime startdate))
                    {
                        MessageBox.Show("Selected start date does not exist!");
                        txtStartDate.Focus();
                        return;
                    }
                    else if (!DateTime.TryParse(txtEndDate.Text, out DateTime enddate))
                    {
                        MessageBox.Show("Selected end date does not exist!");
                        txtEndDate.Focus();
                        return;
                    }
                    else if (Convert.ToDateTime(txtEndDate.Text.ToString()).CompareTo(Convert.ToDateTime(txtStartDate.Text.ToString())) <= 0)
                    {
                        MessageBox.Show("End date must be after start date and both dates and time cannot be the same");
                        txtEndDate.Focus();
                        return;
                    }
                    else
                    {
                        if (txtDescription.Text == "" || txtDescription.Text == null)
                        {
                            updateEvent.Description = "";
                        }
                        else
                        {
                            updateEvent.Description = txtDescription.Text;
                            updateEvent.Date = txtStartDate.Text.ToString() + "," + txtEndDate.Text.ToString();
                        }

                        bool result = _masterManager.MemberManager.UpdateCalendarEvent(updateEvent, _memberID);

                        if (result == true)
                        {
                            MessageBox.Show("Update Successful");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Update Failed!");
                            return;
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
        /// Date: 2023/25/03
        /// 
        /// Actions when the Edit button is clicked.
        /// Should be only be availabile if event is avalability type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Hide unnecessary items
            lblLocation.Visibility = Visibility.Hidden;
            btnClose.Visibility = Visibility.Hidden;

            // Unhide Needed Items/
            lblDescription.Visibility = Visibility.Visible;
            txtDescription.Visibility = Visibility.Visible;
            dateStartDate.Visibility = Visibility.Visible;
            dateEndDate.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;

            // Set field properties
            txtEndDate.IsReadOnly = false;
            txtEndDate.Focusable = true;
            txtEndDate.IsReadOnly = false;
            txtEndDate.Focusable = true;
            txtDescription.IsReadOnly = false;
            txtDescription.Focusable = true;

            txtType.Text = "Availability";
            this.Title = "Edit Availability";
            lblDetails.Content = "Edit Availability Event";
            txtLocation.Text = "***Times are created and displayed in 24-hour format***";
            txtLocation.FontSize = 12;

            // parse dates
            string[] dates = _calendarEvent.Date.Split(',');
            txtStartDate.Text = Convert.ToDateTime(dates[0]).ToString("MM/dd/yyyy HH:mm");
            txtEndDate.Text = Convert.ToDateTime(dates[1]).ToString("MM/dd/yyyy HH:mm");
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 2023/25/03
        /// 
        /// Event when cancel is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var cancel = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButton.OKCancel);

            if (cancel == MessageBoxResult.OK)
            {
                this.Close();
            }
            if (cancel == MessageBoxResult.Cancel)
            {
                return;
            }
        }
    }
}
