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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgAddAndEditEquipmentList.xaml
    /// </summary>
    public partial class pgAddAndEditEquipmentList : Page
    {
        TeamManager _sportManager = null;
        Equipment _equipmentList = null;
        private EquipmentManager _equipmentManager = null;

        // Just for the animation of the sport image
        private List<string> sports;
        private string _action;
        private int _team_id;

        public pgAddAndEditEquipmentList(pgViewEquipmentList pgViewEquipmentList, Equipment equipmentList , string action, int _team_id)
        {
            //To get sport data
            _sportManager = new TeamManager();
            // TO get equipment
            _equipmentManager = new EquipmentManager();
            InitializeComponent();
            //Get sports
            getSport();
            setSportImage("Sports");
            // I created one page that do the both Add and Edit
            // So in this variable _action, I will be check what functionality 
            // I need to perform
            _action = action;
            _equipmentList = equipmentList;
            this._team_id = _team_id;
            // check what action to perform
            actionToDo();
        }

        //Check what action to take.
        // The action are Add to add a new equipment
        // and Edit to edit an existing equipment
        private void actionToDo()
        {
            if (_action == "Add")
            {
                lblTitle.Content = "Add an equipment";
                btnAddOrUpdate.Content = "Add";
            }else
            {
                lblTitle.Content = "Edit equipment";
                btnAddOrUpdate.Content = "Edit";
                getEquipmentData();
            }
        }

        // If we're editing, assign values on the textbox
        private void getEquipmentData()
        {
            if (_equipmentList != null)
            {
                txtDescription.Text = _equipmentList.Description;
                txtQuantity.Text = _equipmentList.Quantity.ToString();
                ddSport.SelectedItem = _equipmentList.SportName;
            }
        }


        // Get the sport data according to sport_id
        private void getSport()
        {
            try
            {
                sports = _sportManager.getSportName();

                foreach (string line in sports)
                {
                    ddSport.Items.Add(line.Substring(5));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read sports!");
            }
        }

        // The images are located in the bin directory
        private void setSportImage(string value)
        {
            string img = "";
            try
            {
                //AppDomain.CurrentDomain.BaseDirectory: The bin folder
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/" + value + ".png";
                img_logo.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/Sports.png";
            }
            img_logo.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));

        }

        private void btnAddorUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_action == "Add") addEquipment();
            else updateEquipment();
        }

        // Method to add equipment
        private void addEquipment()
        {
            int result = 0;
            try
            {
                if(txtDescription.Text!="" && txtQuantity.Text != "" && ddSport.SelectedItem.ToString() != ""
                    && Int32.Parse(txtQuantity.Text) >= 0)
                {
                    _equipmentList.Description = txtDescription.Text;
                    _equipmentList.Quantity = Int32.Parse(txtQuantity.Text);

                    result = _equipmentManager.AddTeamEquipment(_equipmentList);

                    if (result > 0)
                    {
                        MessageBox.Show("Added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Cannot add this team equipment.");
                    }
                }
                else
                {
                    MessageBox.Show("Make sure you typed correct data.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot add this team equipment. Make sure you typed correct data");
            }
        }

        // Method to edit equipment
        private void updateEquipment()
        {
            int result = 0;
            try
            {

                if (txtDescription.Text != "" && txtQuantity.Text != "" && ddSport.SelectedItem.ToString() != ""
                    && Int32.Parse(txtQuantity.Text)>= 0)
                {
                    _equipmentList.Description = txtDescription.Text;
                    _equipmentList.Quantity = Int32.Parse(txtQuantity.Text);

                    result = _equipmentManager.UpdateTeamEquipment(_equipmentList);

                    if (result > 0)
                    {
                        MessageBox.Show("Updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Cannot update this team equipment!");
                    }
                }
                else
                {
                    MessageBox.Show("Make sure you typed correct data.");
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot update this team equipment!");
            }
        }
        
        //Set sport image according to the sport selected
        private void ddSport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = sports.Find(x => x.Contains(ddSport.SelectedItem.ToString()));
                _equipmentList.SportID = Int32.Parse((Regex.Match(item, @"\d+").Value));
                setSportImage(ddSport.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgViewEquipmentList(_team_id));
        }
    }
}
