using DataObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Extremely_Casual_Game_Organizer.ChatControls
{
    /// <summary>
    /// Interaction logic for member.xaml
    /// </summary>
    public partial class member : UserControl
    {
        Member temporaryMember = new Member();
        pgMemberList pgMemberList = null;
        public member()
        {
            InitializeComponent();
        }
        public member(pgMemberList pgMemberList)
        {
            this.pgMemberList = pgMemberList;
            InitializeComponent();
        }

        public Member _member
        {
            get
            {
                return temporaryMember;
            }
            set
            {
                lblMember.Text = value.FirstName+" "+ value.FamilyName;
                temporaryMember = value;
                insertImage(value.ProfilePhoto);
            }
        }

        private void insertImage(byte[] value)
        {
            //if (value != null)
            //{
            //    Image x = (BitmapFrame)((new ImageConverter()).ConvertFrom(value));
            //}
            //using (var ms = new MemoryStream(value))
            //{
            //    return Image.FromStream(ms);
            //}
        }

        //public string Text { get; set; }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Reopen the message page closed before
            // and assign the _member selected to it
            pgMemberList.Close();
            pgRespondToMessage _pgRespondToMessage = new pgRespondToMessage(_member);
            _pgRespondToMessage.Show();

        }
    }
}
