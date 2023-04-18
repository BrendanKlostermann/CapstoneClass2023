/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// Updater Name: Garion Opiola
/// Updated: 2023/03/28
/// updated getMemberByID and added buttton to access deactivate teams
/// </summary>
using DataObjects;
using Extremely_Casual_Game_Organizer.PageFiles;
using LogicLayer;
using Microsoft.Win32;
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
    /// Interaction logic for pgMemberProfile_2.xaml
    /// 
    /// Updater Name: Garion Opiola
    /// Updated: 2023/03/28
    /// uses page control for getMemberByID()
    /// </summary>
    public partial class pgMemberProfile : Page
    {
        MemberManager memberManager = null;
        MasterManager _masterManager = null;
        TeamManager _teamManager = null;
        private Member _member = null;
        PageControl _pgControl = new PageControl();
        private byte[] data; // For image
        public pgMemberProfile(MasterManager _masterManager)
        {
            memberManager = new MemberManager();
            _teamManager = new TeamManager();
            _member = new Member();
            this._masterManager = _masterManager;
            InitializeComponent();
            getMemberByID();
            getTeams();
        }

        // Get Member by id
        private void getMemberByID()
        {
            ///Updater Name: Garion Opiola
            /// Updated: 2023/03/28
            /// uses page control for getMemberByID
            try
            {
                _member = _pgControl.GetSignedInMember();


                // If there's a member
                if (_member != null)
                {
                    lblName.Content = _member.FirstName + " " + _member.FamilyName;
                    lblEmail.Content = "Email: " + _member.Email;

                    //Gender
                    if (_member.Gender == false) lblGender.Content = "Gender: Male";
                    else if (_member.Gender == true) lblGender.Content = "Gender: Female";
                    else lblGender.Content = "Gender: Not specify";
                    lblPhone.Content = "Phone Number: " + _member.PhoneNumber;
                    txtBio.Text = _member.Bio;

                    // If the user has a profile picture, 
                    // convert the byte array into an image
                    // otherwise, set a default picture
                    if (_member.ProfilePhoto != null)
                    {
                        img.Source = ByteToImage(_member.ProfilePhoto);
                    }
                    else
                    {
                        defaultImage();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read members!");
            }
        }
        // COnvert byte array to image source
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

        // Set default image
        private void defaultImage()
        {
            // Load the image:
            string _filename = AppDomain.CurrentDomain.BaseDirectory + "/Images/unknow.jpg"; ;
            BitmapImage bitmap = new BitmapImage(new Uri(_filename));
            img.Source = bitmap;
        }

        // Get the team where the user is part of
        private void getTeams()
        {
            try
            {
                List<TeamMemberAndSport> team = _teamManager.getTeamByMemberID(_member.MemberID);
                // Remove all items from the list of team
                lbTeam.Items.Clear();

                if (team.Count <= 1) lblTeamTitle.Content = "My Team (" + team.Count + ")";
                else lblTeamTitle.Content = "My Teams (" + team.Count + ")";

                // If there's a team
                if (team.Count > 0)
                {

                    foreach (TeamMemberAndSport line in team)
                    {
                        // Populate the custom control for Team
                        var teamMemberAndSport = new CustomControls.TeamMemberAndSport(_masterManager, line);
                        teamMemberAndSport.lblName.Content = line.TeamName;
                        setSportImage(teamMemberAndSport.img, line.SportName);

                        string sport = "";
                        string position = line.Description;

                        // CHeck for gender
                        if (line.Gender == true) sport = "Male " + line.SportName;
                        else if (line.Gender == false) sport = "Female " + line.SportName;
                        else sport = line.SportName + " (Gender not specify)";

                        teamMemberAndSport.lblSport.Content = sport;

                        // CHeck if the user is a starter or not
                        if (line.Starter == false) position += " (Bench Player)";
                        else position += " (Starter)";

                        teamMemberAndSport.lblPosition.Content = position;

                        // Add the custom control into the listBox
                        lbTeam.Items.Add(teamMemberAndSport);
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot read team! " + e.Message);
            }
        }

        // Set the image for each sport
        private void setSportImage(Image image, string value)
        {
            string img = "";
            try
            {
                //MessageBox.Show(value);
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/" + value + ".png";
                image.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                img = AppDomain.CurrentDomain.BaseDirectory + "/Images/Sports/Sports.png";
            }
            image.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Update User Bio
            if (_member != null)
            {
                try
                {
                    _member.Bio = txtBio.Text;
                    int rowsAffected = memberManager.UpdateUserBio(_member);

                    if (rowsAffected == 1) MessageBox.Show("Update successfully!");
                    else MessageBox.Show("Error !");
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show("Error!" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("vide");
            }
        }

        // Update Profile picture 
        // By letting the user select a picture from his device
        // Convert that image to a byte array
        // and then, update the database
        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Load the image:
                string filename = openFileDialog.FileName;
                openFileDialog.Filter = "Supported Images | *.jpg;*.png;*jpeg";
                BitmapImage bitmap = new BitmapImage(new Uri(filename));
                img.Source = bitmap;

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray(); // This is a byte Array
                    //Update Profile Picture
                    try
                    {
                        _member.ProfilePhoto = data;
                        int rowsAffected = memberManager.UpdateProfilePicture(_member);

                        if (rowsAffected == 1) MessageBox.Show("Update successfully!");
                        else
                        {
                            MessageBox.Show("Error updating your picture!");
                            defaultImage();
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show("Error!" + ex.Message);
                    }
                }

            }
        }

        // Let the user create another team
        private void btnCreateTeam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgCreateTeam(_masterManager, _member.MemberID));
            //pgCreateTeam_2 _pgCreateTeam = new pgCreateTeam_2(MemberID); //Pass his memberID
            //_pgCreateTeam.Show();
        }

        private void btnDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            // <summary>
            // Created by Garion Opiola
            // Created 03/19/2023
            // Let the user delete a team
            // </summary>
            NavigationService.Navigate(new pgDeactivateTeam());
        }
    }
}
