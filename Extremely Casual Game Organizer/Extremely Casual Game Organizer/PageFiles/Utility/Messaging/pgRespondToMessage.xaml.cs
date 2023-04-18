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
using Extremely_Casual_Game_Organizer.PageFiles;
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

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Interaction logic for pgRespondToMessage.xaml
    /// </summary>
    /// 

    public partial class pgRespondToMessage : Window
    {
        public Member _otherUser;
        private Member _member = null;

        MessageManager _messageManager = null;
        MemberManager _memberManager = null;

        private List<Message> _messages;
        private List<Member> _members;
        private int _memberID = 0;

        PageControl _pgControl = new PageControl();
        // Regular construction
        public pgRespondToMessage()
        {
            _messageManager = new MessageManager();
            _memberManager = new MemberManager();
            InitializeComponent();
            _memberID = _pgControl.GetSignedInMember().MemberID;
            GetMyAccountInfo();
            reduceRemainingCharacter();
            txtMessage.Focus();
            //GetMessage();
            GetPeopleITexted();
        }

        // Open the message page with the member selected as receiver of the text message
        public pgRespondToMessage(Member member)
        {
            _messageManager = new MessageManager();
            _memberManager = new MemberManager();
            InitializeComponent();
            _otherUser = member;
            _memberID = _pgControl.GetSignedInMember().MemberID;
            GetMyAccountInfo();
            chatWith();
            reduceRemainingCharacter();
            txtMessage.Focus();
            getMyMessage();
            //GetPeopleITexted();
        }

        public pgRespondToMessage(MessageManager messageManager)
        {
            this._messageManager = messageManager;
            _memberManager = new MemberManager();
            InitializeComponent();
            _memberID = _pgControl.GetSignedInMember().MemberID;
            GetMyAccountInfo();
            reduceRemainingCharacter();
            txtMessage.Focus();
            //GetMessage();
            //GetPeopleITexted();
            getMyMessage();
        }

        // Get account information (name, picture, etc.) for this member
        private void GetMyAccountInfo()
        {
            try
            {
                _member = _memberManager.GetMemberByMemberID(_memberID);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot get your account!");
            }
        }

        // Get users conversations with other users
        // Including his
        private void getMyMessage()
        {
            if (_member == null) return;

            _memberID = _member.MemberID;

            try
            {
                GetMessage(); // Get the messages
                GetPeopleITexted(); // Get others users I messaged
            }
            catch
            {
                return;
            }
        }

        //Get users I messaged before
        private void GetPeopleITexted()
        {
            if (_member != null) { 
                try
                {
                    _members = _messageManager.GetMembers(_member.MemberID);
                    lbMember.Items.Clear();

                    // If there's a member
                    if (_members.Count > 0)
                    {
                        foreach (Member line in _members)
                        {
                            lbMember.Items.Add(line.FirstName + " " + line.FamilyName);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot read the users you talked to!");
                }
            }
        }

        // Assign a member that I can chat with
        private void chatWith()
        {
            if (_otherUser != null)
            {
                lblMemberName.Content = _otherUser.FirstName + " " + _otherUser.FamilyName;

                if (_otherUser.ProfilePhoto == null) imgMember.Source = defaultImage();
                // TO DO:
                else imgMember.Source = ByteToImage(_otherUser.ProfilePhoto);
            }
        }

        // Convert image in byte array
        public static ImageSource ByteToImage(byte[] imageData)
        {
            try
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                ImageSource imgSrc = biImg as ImageSource;

                return imgSrc;
            }
            catch
            {
                return null;
            }
        }

        // Send a message
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if(txtMessage.Text == "") 
                    {
                        MessageBox.Show("The Message must not be empty");
                        return;
                    }
                    if (_otherUser == null)
                    {
                        MessageBox.Show("You must select a user first!");
                        return;
                    }

                    if (_member == null) return;
               

                    // If every thing is goood
                    // Send the message
                    Message message = new Message()
                    {
                        UserIdSender = _member.MemberID,
                        UserIdReceiver = _otherUser.MemberID,
                        Date = DateTime.Now,
                        Important = false,
                        MessageText = txtMessage.Text
                    };

                    int rowsAffected = _messageManager.AddMessage(message);

                    if (rowsAffected > 0)
                    {
                        RefreshOutgoing(txtMessage.Text, DateTime.Now.ToString(), _member.ProfilePhoto);

                        txtMessage.Text = "";
                        txtMessage.Focus();
                        ifAlreadyThere(lblMemberName.Content.ToString());

                    }
                    else
                    {
                        MessageBox.Show("An error has occured");
                    }

                
            }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured");
                }
        }

        // Add a person to the list of those I already talk to
        // if they aren't there
        private void ifAlreadyThere(string value)
        {
            bool isThere = false;
            foreach (Member line in _members)
            {
                string fullname = line.FirstName + " " + line.FamilyName;
                if (fullname == value)
                {
                    isThere = true;
                }
            }

            if(!isThere) lbMember.Items.Add(lblMemberName.Content);

        }

        // Get message between the sender and the receiver
        private void GetMessage()
        {
            if (_member == null) return;

            if (_otherUser!=null)
            {
                lbMessage.Items.Clear();

                try
                {
                    _messages = _messageManager.GetMessages(_member.MemberID, _otherUser.MemberID);

                    // If there's a member
                    if (_messages.Count > 0)
                    {
                        foreach (Message line in _messages)
                        {
                            if (line.UserIdSender == _member.MemberID) RefreshOutgoing(line.MessageText, line.Date.ToString(), _member.ProfilePhoto);
                            else RefreshIncoming(line.MessageText, line.Date.ToString(), _otherUser.ProfilePhoto);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot read messages!");
                }
            }
        }

        // I created a custom control for incoming and outgoing messages
        // Located in ChatControls
        
        // Use incoming control for people messages
        private void RefreshIncoming(string message, string date, byte[] photo)
        {
            var incoming = new ChatControls.incoming();
            incoming.Message = message;
            incoming.Date = date;

            if (photo != null) incoming.imgUser.Source = ByteToImage(photo);
            else incoming.imgUser.Source = defaultImage();

            lbMessage.Items.Add(incoming);
            lbMessage.SelectedIndex = lbMessage.Items.Count - 1;
            lbMessage.ScrollIntoView(lbMessage.SelectedItem);
        }

        // Use outcoming control for my messages
        private void RefreshOutgoing(string message, string date, byte[] photo)
        {
            var outgoing = new ChatControls.outgoing();
            outgoing.Message = message;
            outgoing.Date = date;

            if (photo != null) outgoing.imgUser.Source = ByteToImage(photo);
            else outgoing.imgUser.Source = defaultImage();

            lbMessage.Items.Add(outgoing);
            lbMessage.SelectedIndex = lbMessage.Items.Count - 1;
            lbMessage.ScrollIntoView(lbMessage.SelectedItem);
        }


        private void btnSend1_Copy_Click(object sender, RoutedEventArgs e)
        {
            pgRespondToMessage _pgRespondToMessage = this;
            _pgRespondToMessage.Hide();

            // Create an object pgMemberList
            pgMemberList _pgMemberList = new pgMemberList();
            _pgMemberList.Show();
        }

        private void chatWith(object sender, RoutedEventArgs e)
        {
        }

        // When you selection a member on the member list 
        // 1. Gets all messages between this member and the other member
        // 2. Assign the other member name and profile picture to the right (message panel)
        private void lbMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string itemSelected = lbMember.SelectedItem.ToString();
            foreach (Member line in _members)
            {

                string fullname = line.FirstName + " " + line.FamilyName;
                if (fullname == itemSelected) {
                    _otherUser = line;
                    lblMemberName.Content = line.FirstName + " " + line.FamilyName;

                    if (line.ProfilePhoto != null) imgMember.Source = ByteToImage(line.ProfilePhoto);
                    else imgMember.Source = defaultImage();

                    GetMessage();
                }
            }

        }

        private void txtMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            reduceRemainingCharacter();
        }

        // Check the number of characters entered
        private void reduceRemainingCharacter()
        {
            int total = 133; // I don't know why?
            int characters = txtMessage.ToString().Length;
            lblRemaining.Content = (total - characters)+" letters remaining";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _memberID = Int32.Parse(txtMemberId.Text);
            GetMyAccountInfo();
            getMyMessage();
        }

        // Load default image
        private ImageSource defaultImage()
        {
            // Load the image:
            string _filename = AppDomain.CurrentDomain.BaseDirectory + "/Images/unknow.jpg"; ;
            BitmapImage bitmap = new BitmapImage(new Uri(_filename));
            return bitmap;
        }

    }
}
