﻿#pragma checksum "C:\Development\Private\Sol Libraries\Sol.Silverlight\DialogWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E65F28E9908A0573D7D9519368217A3B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SOL.Silverlight {
    
    
    public partial class DialogWindow : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Border contentPlaceholder;
        
        internal System.Windows.Controls.StackPanel spButtons;
        
        internal System.Windows.Controls.Button btnCancel;
        
        internal System.Windows.Controls.Button btnNo;
        
        internal System.Windows.Controls.Button btnYes;
        
        internal System.Windows.Controls.Button btnOk;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SOL.Silverlight;component/DialogWindow.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.contentPlaceholder = ((System.Windows.Controls.Border)(this.FindName("contentPlaceholder")));
            this.spButtons = ((System.Windows.Controls.StackPanel)(this.FindName("spButtons")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.btnNo = ((System.Windows.Controls.Button)(this.FindName("btnNo")));
            this.btnYes = ((System.Windows.Controls.Button)(this.FindName("btnYes")));
            this.btnOk = ((System.Windows.Controls.Button)(this.FindName("btnOk")));
        }
    }
}
