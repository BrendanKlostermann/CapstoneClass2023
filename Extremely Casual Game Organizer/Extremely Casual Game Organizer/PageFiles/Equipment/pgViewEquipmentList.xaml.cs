/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataObjects;
using LogicLayer;
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgViewEquipmentList.xaml
    /// </summary>
    public partial class pgViewEquipmentList : Page
    {

        private EquipmentManager _equipmentManager= null;
        private List<Equipment> _equipmentLists = null;
        private int _team_id;
        private MasterManager masterManager = null;

        public pgViewEquipmentList(TeamMemberAndSport teamMemberAndSport)
        {
            _equipmentManager = new EquipmentManager();
            _equipmentLists = new List<Equipment>();
            this._team_id = teamMemberAndSport.TeamID;
            InitializeComponent();
            txtTeam.Content = "Team: "+teamMemberAndSport.TeamName;
            getTeamEquipmentList();
            txtSearch.Focus();
        }
        public pgViewEquipmentList(int team_id)
        {
            _equipmentManager = new EquipmentManager();
            _equipmentLists = new List<Equipment>();
            _team_id = team_id;
            InitializeComponent();
            getTeamEquipmentList();
            txtSearch.Focus();
        }

        public pgViewEquipmentList()
        {
            _equipmentManager = new EquipmentManager();
            _equipmentLists = new List<Equipment>();
            InitializeComponent();
            getTeamEquipmentList();
            txtSearch.Focus();
        }

        public pgViewEquipmentList(MasterManager masterManager)
        {
            this.masterManager = masterManager;
            _equipmentManager = new EquipmentManager();
            _equipmentLists = new List<Equipment>();
            InitializeComponent();
            getTeamEquipmentList();
            txtSearch.Focus();
        }

        // Get all team equipment
        private void getTeamEquipmentList()
        {
            lbEquipmentList.Items.Clear();
            try
            {
                _equipmentLists = _equipmentManager.RetrieveEquipmentListsByTeamID(_team_id, txtSearch.Text);

                foreach (Equipment line in _equipmentLists)
                {
                    // I created a custom control for equipment list
                    // located at the CustomControls folder
                    var equipmentCustomControl = new CustomControls.EquipmentListControl(this);
                    equipmentCustomControl.equipmentList = line;
                    lbEquipmentList.Items.Add(equipmentCustomControl);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot read team! " + e.Message);
            }

            lblEquipmentList.Content = "Equipment List: " + _equipmentLists.Count;
        }

        // Delete team equipment
        public void deleteTeamEquipmentList(int equipment_id)
        {
            int result = 0;
            try
            {
                Equipment equipmentList = new Equipment()
                {
                    EquipmentID = equipment_id,
                    TeamID = _team_id
                };

                result = _equipmentManager.DeleteTeamEquipment(equipmentList);

                if (result > 0)
                {
                    MessageBox.Show("Deleted successfully!");
                    getTeamEquipmentList();
                }
                else
                {
                    MessageBox.Show("Cannot remove this team equipment!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot remove this team equipment!");
            }
        }

        // open the add and edit page accoring to the action selected
        // There are two actions:
        // Add: to add a new equipment
        // Edit: to edit an existing equipment
        public void openEditPage(Equipment _equipmentList, string action)
        {
            NavigationService.Navigate(new pgAddAndEditEquipmentList(this, _equipmentList, action, _team_id));
        }

        // Selected an equipment by the value typed on the search TextBox
        private void Blur(object sender, KeyEventArgs e)
        {
            getTeamEquipmentList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Equipment _equipmentList = new Equipment()
            {
                TeamID = _team_id
            };
            //Set action for adding
            openEditPage(_equipmentList, "Add");
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgMemberProfile(masterManager));
        }
    }
}
