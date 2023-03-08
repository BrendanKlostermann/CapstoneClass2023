/// <summary>
/// Elijah Morgan
/// Created: 2023/02/28
/// 
/// An page where the a League's data is displayed
/// and can be edited
///

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles;
using LogicLayer;
using LogicLayerInterfaces;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgAddEdit.xaml
    /// </summary>
    public partial class pgAddEditLeague : Page
    {
        private List<Sport> _sports;
        private SportManager _sportManager = new SportManager();
        private LeagueManager _leagueManager = new LeagueManager();
        private League _league = null;
        bool _addMode = false;
        PageControl _pageControl = null;

        public pgAddEditLeague()
        {
            _addMode = true;
            InitializeComponent();
        }

        public pgAddEditLeague(League league)
        {
            _addMode = false;
            _league = league;
            InitializeComponent();
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Reloads the page when called, used to reset page
        /// in cases where the page needs to be reloaded 
        /// (such as refreshing after an edit).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //GetSports();
            cboSport.ItemsSource = _sportManager.RetrieveAllSports().Select(x => x.Description);

            txtLeagueID.IsEnabled = true;
            if (_addMode) // set up addMode
            {
                setAddMode();
            }
            else // set up detail mode (edit mode with readonly controls)
            {
                setDetailMode();
            }
        }

        private void setAddMode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// When called, populates the txtBoxes, comboBoxes 
        /// and anything else on datLeagues in the pgAddEditLeague 
        /// page with the current data stored in the selected league.
        /// </summary> 
        ///
        private void populateControls()
        {
            lblName.Content = _league.Name.ToString();
            txtLeagueID.Text = _league.LeagueID.ToString();
            txtName.Text = _league.Name;
            // Jacob L. helped imenselly with this part (Thank you Jacob) 
            var selectedSport = from sport in _sportManager.RetrieveAllSports() 
                                where sport.SportID.Equals(_league.SportID) 
                                select sport;
            cboSport.SelectedItem = selectedSport.First().Description;
            sldDues.Value = (double)_league.LeagueDues;
            txtDues.Text = _league.LeagueDues.ToString();
            txtDues.Text = sldDues.Value.ToString();
            chkStatus.IsChecked = _league.Active;
            txtMaxTeams.Text = _league.MaxNumberOfTeams.ToString();
            cboGender.Text = _league.Gender.ToString();
            if (_league.Gender == true)
            {
                cboGender.SelectedItem = selectionMale;
            }
            if (_league.Gender == false)
            {
                cboGender.SelectedItem = selectionFemale;
            }
            else
            {
                cboGender.SelectedItem = selectionEitherGender;
            }

            txtDetails.Text = _league.LeagueDescription;
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Sets the page to Detail mode when called, this
        /// is used when the page needs to be set into a
        /// mode where the user can view the League details
        /// without editing anything.
        /// </summary>
        ///
        private void setDetailMode()
        {
            populateControls();

            txtLeagueID.IsEnabled = false;
            txtName.IsEnabled = false;
            cboSport.IsEnabled = false;
            txtDues.IsEnabled = false;
            sldDues.IsEnabled = false;
            chkStatus.IsEnabled = false;
            txtMaxTeams.IsEnabled = false;
            cboGender.IsEnabled = false;
            txtDetails.IsEnabled = false;

            btnEditSave.Content = "Edit";
            btnCancel.Content = "Close";
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Sets the page to edit mode, this mode
        /// is used when the user needs to make 
        /// an edit to the league object in the 
        /// edit menu.
        /// </summary>
        ///
        private void setEditMode()
        {
            txtLeagueID.IsEnabled = false;
            txtName.IsEnabled = true;
            sldDues.IsEnabled = true;
            txtDues.IsEnabled = true;
            chkStatus.IsEnabled = true;
            txtMaxTeams.IsEnabled = true;
            cboGender.IsEnabled = true;
            txtDetails.IsEnabled = true;

            btnCancel.Content = "Cancel";
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// Checks if a string contains any letters.
        /// </summary>
        /// <param name="str">The string that is input for checking</param>
        /// 
        private static bool IsNumeric(String str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// When this button is clicked, we check the values that were 
        /// inputted within the textBoxes, comboBoxes any anything else 
        /// where data needs to be changed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            //_sportsList = _sportManager.

            if (btnEditSave.Content.ToString() == "Edit")
            {
                setEditMode();
                btnEditSave.Content = "Save";
            }
            else // this button is a save button, so save the update
            { 
                {
                    if (txtName.Text.ToString() == "")//getting first name
                    {
                        MessageBox.Show("Please enter a name.");
                        txtName.Focus();
                        return;
                    }
                    if (cboSport.Text.ToString() == "")//getting sport
                    {
                        MessageBox.Show("Please select a game to be played.");
                        cboSport.Focus();
                        return;
                    }
                    if (txtMaxTeams.Text.ToString() == "")//getting max number of teams
                    {
                        MessageBox.Show("Please enter a max number of teams.");
                        txtMaxTeams.Focus();
                        return;
                    }
                    if (txtMaxTeams.Text.ToString() == "0")//checking if max teams is zero
                    {
                        MessageBox.Show("The maximum amount of teams cannot be 0");
                        txtMaxTeams.Focus();
                        return;
                    }
                    try
                    {
                        IsNumeric(txtMaxTeams.Text);
                    }
                    catch (Exception)//if max teams is 0, throw exception
                    {
                        MessageBox.Show("Please enter a real number.");
                        txtMaxTeams.Focus();
                        return;
                    }

                    decimal leagueDues;
                    try
                    {
                        leagueDues = decimal.Parse(txtDues.Text.ToString());
                    }
                    catch (Exception)//if dues is a not a number, throw an exception
                    {
                        MessageBox.Show("Please enter a valid amount due, even if it is 0.");
                        txtDues.SelectAll();
                        txtDues.Focus();
                        return;
                    }

                    int maxTeams;
                    try
                    {
                        maxTeams = Int32.Parse(txtMaxTeams.Text);
                    }
                    catch //if teams is not a number, throw an exception
                    {
                        MessageBox.Show("Please enter a valid amount due, even if it is 0.");
                        txtDues.SelectAll();
                        txtDues.Focus();
                        return;
                    }

                    var selectedSportID = from sport in _sportManager.RetrieveAllSports()
                                          where sport.SportID.Equals(_league.SportID)
                                          select sport.SportID;

                    if (cboGender.SelectedItem == selectionMale)//set gender to male
                    {
                        _league.Gender = true;
                    }
                    else
                    {
                    }
                    if (cboGender.SelectedItem == selectionFemale)//set gender to female
                    {
                        _league.Gender = false;
                    }
                    else //set gender to non-binary
                    {
                        _league.Gender = null;
                    }

                    bool? _gender = null;

                    if (cboGender.SelectionBoxItem.ToString().Equals("Male")) {
                        _gender = true;
                    } else if (cboGender.SelectionBoxItem.ToString().Equals("Female"))
                    {
                        _gender = false;
                    }
                    else
                    {
                        _gender = null;
                    }


                    // build a new League object with the new data that is passed
                    League league = new League()
                    {
                        LeagueID = _league.LeagueID,
                        MemberID = _league.MemberID,
                        SportID = _league.SportID,
                        Name = txtName.Text,
                        LeagueDues = leagueDues,
                        Active = (bool)chkStatus.IsChecked,
                        MaxNumberOfTeams = maxTeams,
                        Gender = _gender,
                        LeagueDescription = txtDetails.Text
                    };

                    _pageControl = new PageControl();

                    try
                    {
                        if (_leagueManager.EditLeague(_league, league))
                        {
                            // LeagueManager leagueManager = new LeagueManager();
                            setDetailMode();

                            _league = league;
                            populateControls();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Data not available", ex);
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Elijah
        /// Created: 2023/02/28
        /// 
        /// When this button is clicked, the page checks what mode we
        /// are currently in. If the page is in edit mode, the button is
        /// set to cancel all of the potential changes that were made. If
        /// the page is in detail mode, the button will close the edit menu
        /// and return the user back to the league list view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _pageControl = new PageControl();

            if (btnCancel.Content.ToString() == "Cancel")
            {   // we are in edit mode
                var result = MessageBox.Show("Are you sure?",
                             "Discard Changes",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    setDetailMode();
                }
            }
            else // close window when done
            {
                btnCancel.Content = "Close";
            }

            if (btnCancel.Content.ToString() == "Close")
            {
                LeagueManager leagueManager = new LeagueManager();
                _pageControl.LoadPage(new pgViewLeagueList());
            }
        }
    }
}
