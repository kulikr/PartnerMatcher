﻿#pragma checksum "..\..\..\AddTripsProfile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81528E5199E95CA260DCFE6D0C13994F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace PartnerMatcher {
    
    
    /// <summary>
    /// AddTripsProfile
    /// </summary>
    public partial class AddTripsProfile : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_createProfile;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_confirm;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_profiles;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_location;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_gender;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_destination;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_gender;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_dateOfDeparture;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_dateOfReturn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_location_Copy1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AddTripsProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_location_Copy2;
        
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
            System.Uri resourceLocater = new System.Uri("/PartnerMatcher;component/addtripsprofile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddTripsProfile.xaml"
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
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.text_createProfile = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.b_confirm = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\AddTripsProfile.xaml"
            this.b_confirm.Click += new System.Windows.RoutedEventHandler(this.b_confirm_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cb_profiles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txt_location = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txt_gender = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tb_destination = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cb_gender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.dp_dateOfDeparture = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.dp_dateOfReturn = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.txt_location_Copy1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.txt_location_Copy2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

