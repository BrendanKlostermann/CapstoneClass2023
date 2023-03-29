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
using LogicLayer;

namespace Extremely_Casual_Game_Organizer.PageFiles.Utility
{
    /// <summary>
    /// Interaction logic for pgHomepage.xaml
    /// </summary>
    public partial class pgHomepage : Page
    {
        PageControl _pageControl;
        Member _member;
        MasterManager _masterManager;
        List<CalendarEvent> _events = null;
        public pgHomepage(PageControl pageControl, MasterManager masterManager)
        {
            _pageControl = pageControl;
            _masterManager = masterManager;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHeading.Text = "Welcome to Extremely Casual Game Organizer";
                _member = _pageControl.GetSignedInMember();

                if (_member == null)
                {
                    UpdateUIForLogout();
                }
                if (_member != null)
                {
                    UpdateUIForSignIn();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        private void UpdateUIForLogout()
        {
            lstEvents.Visibility = Visibility.Hidden;
            txtNoEvents.Visibility = Visibility.Hidden;
            txtUpcomingEvents.Visibility = Visibility.Hidden;

            imgLogoLogout.Visibility = Visibility.Visible;
            imgLogoLogin.Visibility = Visibility.Hidden;

            lblLogin.Visibility = Visibility.Visible;
            btnSignIn.Visibility = Visibility.Visible;
            lblCreateAccount.Visibility = Visibility.Visible;
            btnCreateAccount.Visibility = Visibility.Visible;
        }
        private void UpdateUIForSignIn()
        {
            // Hide Unneeded Textboxes and Labels
            lblLogin.Visibility = Visibility.Hidden;
            btnSignIn.Visibility = Visibility.Hidden;
            lblCreateAccount.Visibility = Visibility.Hidden;
            btnCreateAccount.Visibility = Visibility.Hidden;

            // Move image to other column
            imgLogoLogout.Visibility = Visibility.Hidden;
            imgLogoLogin.Visibility = Visibility.Visible;

            // Populate Item List
            try
            {
                _events = _masterManager.MemberManager.RetreiveMemberSchedule(_member.MemberID);

                if (_events.Count > 0)
                {
                    txtNoEvents.Visibility = Visibility.Hidden;

                    // Loop through events and exclude availability types
                    foreach (var item in _events.Where(x => x.Type != "Availability").OrderBy(x => x.Date))
                    {
                        ListBoxItem addEvent = new ListBoxItem();
                        addEvent.BorderBrush = Brushes.Black;
                        addEvent.Margin = new Thickness(5);

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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
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

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _pageControl.LoadPage(new pgCreateAccount(_masterManager));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
