﻿#pragma checksum "C:\Development\Projects\EC Libraries\Source\EC.Libraries\EC.Silverlight\MessageBoxDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C05E9912BA0ECA48E3E2978644E0C99B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
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


namespace EC.Silverlight {
    
    
    public partial class MessageBoxDialog : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image imgError;
        
        internal System.Windows.Controls.Image imgWarning;
        
        internal System.Windows.Controls.Image imgInfo;
        
        internal System.Windows.Controls.Image imgSuccess;
        
        internal System.Windows.Controls.Image imgConfirm;
        
        internal System.Windows.Controls.TextBlock txtMessage;
        
        internal System.Windows.Controls.TextBlock txtDetail;
        
        internal System.Windows.Controls.Expander expandDetail;
        
        internal System.Windows.Controls.TextBox txtExpanderDetail;
        
        internal System.Windows.Controls.Button btnOk;
        
        internal System.Windows.Controls.Button btnCancel;
        
        internal System.Windows.Controls.Button btnYes;
        
        internal System.Windows.Controls.Button btnNo;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/EC.Silverlight;component/MessageBoxDialog.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.imgError = ((System.Windows.Controls.Image)(this.FindName("imgError")));
            this.imgWarning = ((System.Windows.Controls.Image)(this.FindName("imgWarning")));
            this.imgInfo = ((System.Windows.Controls.Image)(this.FindName("imgInfo")));
            this.imgSuccess = ((System.Windows.Controls.Image)(this.FindName("imgSuccess")));
            this.imgConfirm = ((System.Windows.Controls.Image)(this.FindName("imgConfirm")));
            this.txtMessage = ((System.Windows.Controls.TextBlock)(this.FindName("txtMessage")));
            this.txtDetail = ((System.Windows.Controls.TextBlock)(this.FindName("txtDetail")));
            this.expandDetail = ((System.Windows.Controls.Expander)(this.FindName("expandDetail")));
            this.txtExpanderDetail = ((System.Windows.Controls.TextBox)(this.FindName("txtExpanderDetail")));
            this.btnOk = ((System.Windows.Controls.Button)(this.FindName("btnOk")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.btnYes = ((System.Windows.Controls.Button)(this.FindName("btnYes")));
            this.btnNo = ((System.Windows.Controls.Button)(this.FindName("btnNo")));
        }
    }
}

