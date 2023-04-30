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
using System.Windows.Shapes;

namespace Extremely_Casual_Game_Organizer.PageFiles.Teams.Utility
{
    /// <summary>
    /// Interaction logic for winTeamInvites.xaml
    /// </summary>
    public partial class winTeamInvites : Window
    {
        PageControl _pageControl;
        MasterManager _masterManager;
        int _teamID;
        public winTeamInvites(int teamID, MasterManager masterManager)
        {
            _pageControl = new PageControl();
            _masterManager = masterManager;
            _teamID = teamID;
            InitializeComponent();
            LoadTeamInvites();
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/29/2023
        /// 
        /// Load Team invites method.
        /// This will populate the invites list box
        /// </summary>
        private void LoadTeamInvites()
        {
            try
            {
                lstInvites.Items.Clear();

                // Pull Team requests for team
                List<TeamRequest> teamRequests = _masterManager.TeamManager.RetrieveRequestByTeamID(_teamID);

                if (teamRequests.Where(x => x.Status == "Waiting").Count() > 0)
                {
                    txtEmptyInvites.Visibility = Visibility.Hidden;
                }

                // Populate listbox with requests
                foreach (var request in teamRequests)
                {
                    if (request.Status == "Waiting")
                    {
                        // Get Member
                        var member = _masterManager.MemberManager.GetMemberByMemberID(request.MemberID);

                        // Need a stack panel with a dock panel
                        DockPanel inviteDock = new DockPanel();

                        DockPanel buttonDock = new DockPanel();

                        StackPanel inviteStack = new StackPanel();



                        TextBox nameLabel = new TextBox()
                        {
                            Text = "Name: ",
                            FontWeight = FontWeights.Bold,
                            IsReadOnly = true,
                            Width = 80
                        };
                        TextBox nameText = new TextBox()
                        {
                            Text = member.FirstName + " " + member.FamilyName,
                            IsReadOnly = true,
                            TextWrapping = TextWrapping.Wrap,
                            Width = 150
                        };

                        // Add text to dock panel
                        inviteDock.Children.Add(nameLabel);
                        inviteDock.Children.Add(nameText);

                        Button acceptButton = new Button()
                        {
                            Content = "Accept",
                            Width = 60,
                            DataContext = request.TeamRequestID + "," + request.MemberID

                        };

                        Button denyButton = new Button()
                        {
                            Content = "Decline",
                            Width = 60,
                            DataContext = request.TeamRequestID + "," + request.MemberID
                        };

                        acceptButton.Click += AcceptRequest_Click;
                        denyButton.Click += DenyRequest_Click;

                        buttonDock.Children.Add(acceptButton);
                        buttonDock.Children.Add(denyButton);

                        // Add dock items to invite stack
                        inviteStack.Children.Add(inviteDock);
                        inviteStack.Children.Add(buttonDock);

                        // Add stack to listbox
                        lstInvites.Items.Add(inviteStack);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/29/2023
        /// 
        /// Deny button click event
        /// </summary>
        private void DenyRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button senderButton = (Button)sender;

                string[] buttonContext = Convert.ToString(senderButton.DataContext).Split(',');

                int requestID = Convert.ToInt32(buttonContext[0]);

                _masterManager.TeamManager.UpdateTeamRequestStatus(requestID, "Denied");

                LoadTeamInvites();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob Lindauer
        /// Date: 04/29/2023
        /// 
        /// Accept button click event
        /// </summary>
        private void AcceptRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button senderButton = (Button)sender;

                string[] buttonContext = Convert.ToString(senderButton.DataContext).Split(',');

                Member acceptMember = _masterManager.MemberManager.GetMemberByMemberID(Convert.ToInt32(buttonContext[1]));

                int requestID = Convert.ToInt32(buttonContext[0]);

                var result = _masterManager.TeamManager.UpdateTeamRequestStatus(requestID, "Accepted");

                if (result)
                {
                    var addMember = _masterManager.TeamMemberManager.AddAPlayerToATeamByTeamIDAndMemberID(_teamID, acceptMember.MemberID);
 
                    if (addMember > 0)
                    {
                        MessageBox.Show(acceptMember.FirstName + " has been added to the team!");
                    }
                }

                LoadTeamInvites();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Created By: Jacob LIndauer
        /// Date: 04/29/2023
        /// 
        /// Close page button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
