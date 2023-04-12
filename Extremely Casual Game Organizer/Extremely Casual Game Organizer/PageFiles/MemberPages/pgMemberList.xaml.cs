/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>

using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgMemberList_2.xaml
    /// </summary>
    public partial class pgMemberList : Window
    {
        MemberManager memberManager = null;
        //pgRespondToMessage _pgRespondToMessage = null;

        private List<Member> members;
        public pgMemberList()
        {
            memberManager = new MemberManager();
            InitializeComponent();
            getMembers();
            txtSearch.Focus();
        }
        public pgMemberList(MemberManager member)
        {
            memberManager = member;
            InitializeComponent();
            getMembers();
            txtSearch.Focus();
        }

        //Get All members
        private void getMembers()
        {
            lbMember.Items.Clear();

            try
            {
                members = memberManager.GetMembers();

            //Data Grid
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "First Name";
            textColumn.Binding = new Binding("FirstName");

            // If there's a member
            if (members.Count > 0)
            {
                foreach (Member line in members)
                {
                    // I create a custom control for member 
                    // located in the ChatControls folder
                    var memberControl = new ChatControls.member(this);
                    memberControl._member = line;
                    
                    //If the user has a profile picture
                    if (line.ProfilePhoto != null)
                    {
                        memberControl.imgUser.Source = ByteToImage(line.ProfilePhoto);
                    }

                    lbMember.Items.Add(memberControl); 

                }
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read members!");
            }
        }

        //Get members by their name
        private void getMemberByName()
        {
            lbMember.Items.Clear();

            try
            {
                members = memberManager.GetMemberByName(txtSearch.Text);

                // If there's a member
                if (members.Count > 0)
                {
                    foreach (Member line in members)
                    {
                        // Populate the custom control for members
                        var memberControl = new ChatControls.member(this);
                        memberControl._member = line;
                        lbMember.Items.Add(memberControl);

                        if (line.ProfilePhoto != null)
                        {
                            memberControl.imgUser.Source = ByteToImage(line.ProfilePhoto);
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read members!");
            }
        }

        // COnvert the byte array into a Image Source Property
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void lbMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var _member = new ChatControls.member();
            //_member = lbMember.SelectedItem.GetType();
            //MessageBox.Show(lbMember.SelectedItem.GetType().ToString());
            //MessageBox.Show(_member);
        }

        private void GetThisMember(object sender, KeyEventArgs e)
        {
            getMemberByName();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Open the Message page
            pgRespondToMessage _pgRespondToMessage = new pgRespondToMessage();
            _pgRespondToMessage.Show();
            //this.Close();
        }
    }
}
