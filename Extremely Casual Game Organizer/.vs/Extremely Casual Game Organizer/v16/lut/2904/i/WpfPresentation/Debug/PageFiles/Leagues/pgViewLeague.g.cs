﻿#pragma checksum "PageFiles\Leagues\pgViewLeague.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "736CEB4817C51A8949DECA944A038B194E73E4CAEC8EA7E6CF7D7A75744B136C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Extremely_Casual_Game_Organizer.PageFiles.Leagues;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Extremely_Casual_Game_Organizer.PageFiles.Leagues {
    
    
    /// <summary>
    /// pgViewLeague
    /// </summary>
    public partial class pgViewLeague : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName;
        
        #line default
        #line hidden
        
        
        #line 37 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 43 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGame;
        
        #line default
        #line hidden
        
        
        #line 49 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDues;
        
        #line default
        #line hidden
        
        
        #line 55 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGender;
        
        #line default
        #line hidden
        
        
        #line 62 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDetails;
        
        #line default
        #line hidden
        
        
        #line 68 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMax;
        
        #line default
        #line hidden
        
        
        #line 71 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 75 "PageFiles\Leagues\pgViewLeague.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRequest;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Extremely Casual Game Organizer;component/pagefiles/leagues/pgviewleague.xaml", System.UriKind.Relative);
            
            #line 1 "PageFiles\Leagues\pgViewLeague.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtGame = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtDues = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtGender = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtDetails = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtMax = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnRequest = ((System.Windows.Controls.Button)(target));
            
            #line 75 "PageFiles\Leagues\pgViewLeague.xaml"
            this.btnRequest.Click += new System.Windows.RoutedEventHandler(this.btnRequest_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

