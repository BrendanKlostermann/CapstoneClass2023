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

        public PopUpOptions()
        {
            InitializeComponent();
        }

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
        public PopUpOptions(int memberID, int teamID, int optionStatus)
        {
            _teamID = teamID;
            _memberID = memberID;
            _optionStatus = optionStatus;
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
            this.Close();
        }
    }
}
