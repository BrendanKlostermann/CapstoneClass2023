/// <summary>
/// Anthoney Hale
/// Created: 2023/03/07
/// page for Tournament Registration
/// </summary>

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
using LogicLayer;
using LogicLayerInterfaces;
using DataObjects;

namespace Extremely_Casual_Game_Organizer.PageFiles.Tournaments
{
    /// <summary>
    /// Interaction logic for pgTournamentRegistration.xaml
    /// </summary>
    public partial class pgTournamentRegistration : Page
    {
        private bool isRegistrationOpen;
        private List<string> participants;
        TournamentManager _tournamentManager = null;

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/03/07
        /// Tournament Registration
        /// </summary>
        public pgTournamentRegistration()
        {
            InitializeComponent();
            _tournamentManager = new TournamentManager();

            // Initialize variables
            isRegistrationOpen = false;
            participants = new List<string>();
        }
        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/03/07
        /// click event for opening and closing registration
        /// </summary>
        private void btnTournamentRegistration_Click(object sender, RoutedEventArgs e)
        {
            // Toggle registration status
            isRegistrationOpen = !isRegistrationOpen;

            // Update button text and color
            if (!isRegistrationOpen)
            {
                btnTournamentRegistration.Content = "Closed Registration";
            }
            else
            {
                btnTournamentRegistration.Content = "Open Registration";
            }

        }

        /// <summary>
        /// Anthoney Hale
        /// Created: 2023/03/07
        /// click event for participants registered
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Add participant to the list
            if (isRegistrationOpen)
            {
                string participant = "";

                if (!string.IsNullOrEmpty(participant) && !participants.Contains(participant))
                {
                    participants.Add(participant);
                    lstParticipants.Items.Add(participant);
                    MessageBox.Show("Participant registered successfully!");
                }
                else
                {
                    MessageBox.Show("Please enter a valid participant name.");
                }
            }
            else
            {
                MessageBox.Show("Registration is currently closed.");
            }
        }
    }
}