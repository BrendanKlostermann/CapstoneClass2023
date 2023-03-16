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

namespace Extremely_Casual_Game_Organizer.ChatControls
{
    /// <summary>
    /// Interaction logic for outgoing.xaml
    /// </summary>
    public partial class outgoing : UserControl
    {
        public outgoing()
        {
            InitializeComponent();
        }
        public string Message
        {
            get
            {
                return lblMessage.Text.ToString();
            }
            set
            {
                lblMessage.Text = value;
            }
        }
        public string Date
        {
            get
            {
                return lblDate.Text.ToString();
            }
            set
            {
                lblDate.Text = value;
            }
        }
    }
}
