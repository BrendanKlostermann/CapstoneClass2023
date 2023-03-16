using DataObjects;
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

namespace Extremely_Casual_Game_Organizer.CustomControls
{
    /// <summary>
    /// Heritier Otiom
    /// 03/01/2023
    /// 
    /// This custom control gets EquipmentList object
    /// And assign that object values to its labels
    /// </summary>
    public partial class EquipmentListControl : UserControl
    {
        pgViewEquipmentList _pgViewEquipmentList = null;
        Equipment _equipmentList = null;
        public EquipmentListControl()
        {
            _pgViewEquipmentList = new pgViewEquipmentList();
            _equipmentList = new Equipment();
            InitializeComponent();
            populateData();
        }

        public EquipmentListControl(pgViewEquipmentList pgViewEquipmentList)
        {
            _pgViewEquipmentList = pgViewEquipmentList;
            _equipmentList = new Equipment();
            InitializeComponent();
        }

        public Equipment equipmentList
        {
            get
            {
                return _equipmentList;
            }
            set
            {
                _equipmentList = value;
                populateData();
            }
        }

        private void populateData()
        {
            if (_equipmentList != null)
            {
                lblName.Content = _equipmentList.Description;
                lblSport.Content = _equipmentList.SportName;
                lblQuantity.Content = _equipmentList.Quantity;
            }
        }

        // To remove an equipment
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove " + _equipmentList.Description + " ?", "Remove",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                _pgViewEquipmentList.deleteTeamEquipmentList(equipmentList.EquipmentID);
            }
        }

        // To edit an equipment
        // Call the openEditPage method of the _pgViewEquipmentList
        // with action of Edit
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _pgViewEquipmentList.openEditPage(equipmentList, "Edit");
        }
    }
}
