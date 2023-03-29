/// <summary>
/// Alex Korte
/// Created: 2023/02/21
/// 
/// </summary>
/// A class used to manage what the user clicks on and what options they get when 
/// managing their team
/// 
/// we have 2 constructors for this, passing a value as to what options are 
/// avaliable.
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

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
using System.Windows.Shapes;
using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles;
using Extremely_Casual_Game_Organizer.PageFiles.Teams.Utility;
using LogicLayer;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for PopUpOptions.xaml
    /// </summary>
    public partial class PopUpOptions : Window
    {
        int _teamID; //used to store the team id for methods
        int _memberID; // used to store the member selected
        int _optionStatus; //used to show which options are avaliable
        bool _starter; //used to get weather or not they are a starter or a bench
        TeamMemberManager _teamMemberManager;
        PageControl _pageControl;
        MasterManager _masterManager;
        List<Member> _members = null;

        //public event EventHandler WindowClosed; //handler that manages when the pop up menue closes. 

        public PopUpOptions(MasterManager masterManager)
        {
            _masterManager = masterManager;
            InitializeComponent();
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    WindowClosed?.Invoke(this, EventArgs.Empty);
        //}

        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Constructor that builds the menu and what options are avaliable
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        public PopUpOptions(int memberID, int teamID, int optionStatus, bool starter, List<Member> members)
        {
            _pageControl = new PageControl();
            _teamMemberManager = new TeamMemberManager();
            _masterManager = new MasterManager();
            _teamID = teamID;
            _memberID = memberID;
            _optionStatus = optionStatus;
            _starter = starter;
            _members = members;
            InitializeComponent();
            this.Topmost = true;
            if(_optionStatus == 1)
            {
                btnAdd.IsEnabled = true;
                btnBench.IsEnabled = false;
                btnRemove.IsEnabled = false;
                btnCancel.IsEnabled = true;
            }
            else
            {
                btnAdd.IsEnabled = false;
                btnBench.IsEnabled = true;
                btnRemove.IsEnabled = true;
                btnCancel.IsEnabled = true;
                if(_starter == true)
                {
                    btnBench.Content = "Bench";
                }
                else
                {
                    btnBench.Content = "Starter";
                }
            }
        }



        /// <summary>
        /// Alex Korte
        /// Created: 2023/02/21
        /// 
        /// </summary>
        /// Method to close and send back values initially handed.
        /// 
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pgTeamMemberScreen _teamMemberScreen = new pgTeamMemberScreen(_teamID, _masterManager);
            _pageControl.LoadPage(_teamMemberScreen);
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int successful = _masterManager.TeamMemberManager.RemoveAPlayerFromATeamByTeamIDAndMemberID(_teamID, _memberID);
            pgTeamMemberScreen _teamMemberScreen = new pgTeamMemberScreen(_teamID, _masterManager);
            _pageControl.LoadPage(_teamMemberScreen);
            this.Close();
        }

        private void btnBench_Click(object sender, RoutedEventArgs e)
        {
            if (_starter == true)
            {
                _starter = false;
            }
            else if(_starter == false)
            {
                _starter = true;
            }
            String successful = _masterManager.TeamMemberManager.MoveAPlayerToBenchOrStarter(_teamID, _starter, _memberID);
            pgTeamMemberScreen _teamMemberScreen = new pgTeamMemberScreen(_teamID, _masterManager);
            _pageControl.LoadPage(_teamMemberScreen);
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PopUpPlayerSearch _playerSearch = new PopUpPlayerSearch(_teamID, _members);
            this.Close();
            _playerSearch.ShowDialog();

        }
    }
}
