﻿using Extremely_Casual_Game_Organizer.PageFiles;
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

namespace Extremely_Casual_Game_Organizer.CustomControls
{
    /// <summary>
    /// Heritier Otiom
    /// 03/01/2023
    /// 
    /// This custom control assign TeamMemberAndSport objects to its labels
    /// </summary>
    public partial class TeamMemberAndSport : UserControl
    {
        private MasterManager masterManager;
        DataObjects.TeamMemberAndSport teamMemberAndSport = null;

        PageControl _pageControl = null;

        public TeamMemberAndSport(MasterManager masterManager, DataObjects.TeamMemberAndSport teamMemberAndSport)
        {
            _pageControl = new PageControl();
            InitializeComponent();
            this.masterManager = masterManager;
            this.teamMemberAndSport = teamMemberAndSport;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgViewEquipmentList(teamMemberAndSport));
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            _pageControl.LoadPage(new pgTeamMemberScreen(teamMemberAndSport.TeamID, masterManager));
        }
    }
}
