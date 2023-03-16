/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataObjects;
using System;
using System.Windows;
using LogicLayerInterfaces;
using LogicLayer;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows.Controls;

namespace Extremely_Casual_Game_Organizer
{
    /// <summary>
    /// Heritier Otiom
    /// 02/28/2023
    /// </summary> 
    public partial class pgCreateAccount : Page
    {
        //Make sure the user is above 18 years old
        private DateTime adulttxtBirthday = new DateTime(2005, 01, 01);
        private string filename;
        byte[] data;

        MemberManager _memberManager = null;

        public pgCreateAccount(MemberManager memberManager)
        {
            _memberManager = memberManager;
            InitializeComponent();
        }

        public pgCreateAccount()
        {
            _memberManager = new MemberManager();
            InitializeComponent();
        }

        // Reset the form
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resetForm();
        }

        // Method to reset a form
        private void resetForm()
        {
            txtFirstName.Text = "";
            txtFirstName.Focus();
            txtFamilyName.Text = "";
            ddGender.Text = "";
            txtBirthday.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtPasswordHash.Password = "";
            txtConfirmPasswordHash.Password = "";
            cbAgreement.IsChecked = false;
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {

            // The first name can't be empty
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("You must enter a first name.");
                txtFirstName.Focus();
                return;
            }
            // The family name can't be empty
            if (txtFamilyName.Text == "")
            {
                MessageBox.Show("You must enter a family name.");
                txtFamilyName.Focus();
                return;
            }

            // The gender can't be empty
            if (ddGender.Text == "")
            {
                MessageBox.Show("You must select a ddGender.");
                ddGender.Focus();
                return;
            }

            // The birthday canmust be above 18 years old
            if (txtBirthday.SelectedDate.Value.Year > adulttxtBirthday.Year)
            {
                MessageBox.Show("You must be an adult.");
                txtBirthday.Focus();
                return;
            }

            // The phone number must be above 10 digits
            if (txtPhoneNumber.Text.ToString().Length < 10)
            {
                MessageBox.Show("You must enter a valid phone number.");
                txtPhoneNumber.Focus();
                return;
            }

            // Must be a correct email
            if (!(txtEmail.Text.ToString().Length > 6
                  && txtEmail.Text.ToString().Contains("@")
                  && txtEmail.Text.ToString().Contains(".")))
            {
                MessageBox.Show("You must enter a valid txtEmail address.");
                txtEmail.Focus();
                return;
            }

            // The password must be 8 characters
            if (!(txtPasswordHash.Password.ToString().Length >= 8))
            {
                MessageBox.Show("The Password must contain 8 characters.");
                txtPasswordHash.Focus();
                return;
            }
            // The confirm password must match the password
            if (!(txtConfirmPasswordHash.Password == txtPasswordHash.Password))
            {
                MessageBox.Show("The two passwords must be equal.");
                txtConfirmPasswordHash.Focus();
                return;
            }
            // The aggrement must be checked
            if (!(cbAgreement.IsChecked == true))
            {
                MessageBox.Show("You must agree to the terms.");
                cbAgreement.Focus();
                return;
            }


            try
            {
                // Get th value of the birthday
                DateTime dateTime = txtBirthday.SelectedDate.Value;

                // Set default image
                defaultImage();

                // The gender is has BIT type but the ddGender.Text is a string
                // So, I created this to make sure the value if a byte
                bool? _ddGender = false;
                if (ddGender.Text == "Male") _ddGender = false;
                else if (ddGender.Text == "Female") _ddGender = true;
                else _ddGender = null;


                // Hashing the password
                string newtxtPasswordHashed = _memberManager.HashSha256(txtPasswordHash.Password);
                // Load the image:

                //Image _image = new Bitmap(filename);

                //Creating a new member dataObject
                Member member = new Member()
                {
                    FirstName = txtFirstName.Text.ToString(),
                    FamilyName = txtFamilyName.Text.ToString(),
                    Gender = _ddGender,
                    Birthday = txtBirthday.SelectedDate.Value,
                    PhoneNumber = txtPhoneNumber.Text.ToString(),
                    Email = txtEmail.Text.ToString(),
                    PasswordHash = newtxtPasswordHashed,
                    Active = true,
                    Bio = "",
                    ProfilePhoto = data
                };

                // Add user to the database
                if (_memberManager.AddUser(member) > 0)
                {
                    MessageBox.Show("Your account has been created!");
                    resetForm();
                    return;
                }
                else
                {
                    MessageBox.Show("An Error has occur!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Creation Failed! \n\n" + ex.Message);
            }

        }
        // Get focus on the first name when the page is loaded
        private void loaded(object sender, RoutedEventArgs e)
        {
            txtFirstName.Focus();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Load the image:
                filename = openFileDialog.FileName;
                openFileDialog.Filter = "Supported Images | *.jpg;*.png;*jpeg";
                BitmapImage bitmap = new BitmapImage(new Uri(filename));
                img.Source = bitmap;

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }

            }
        }

        private void defaultImage()
        {
            // Load the image:
            string _filename = AppDomain.CurrentDomain.BaseDirectory + "/Images/unknow.jpg"; ;
            BitmapImage bitmap = new BitmapImage(new Uri(_filename));
            img.Source = bitmap;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
        }


    }
}
