﻿#pragma checksum "..\..\..\..\Views\MainTableViews\uc_InvoiceJOINT_ListAndDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B1B4563B2F1E2EA76685A6D71F72E77"
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
using VcsConnect_Client.Views.MainTableViews;


namespace VcsConnect_Client.Views.MainTableViews {
    
    
    /// <summary>
    /// uc_InvoiceJOINT_ListAndDetail
    /// </summary>
    public partial class uc_InvoiceJOINT_ListAndDetail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Views\MainTableViews\uc_InvoiceJOINT_ListAndDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VcsConnect_Client.Views.MainTableViews.uc_Invoice_List uc_InvList;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\MainTableViews\uc_InvoiceJOINT_ListAndDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VcsConnect_Client.Views.MainTableViews.uc_Invoice_Detail uc_InvDetail;
        
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
            System.Uri resourceLocater = new System.Uri("/VcsConnect_Client;component/views/maintableviews/uc_invoicejoint_listanddetail.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainTableViews\uc_InvoiceJOINT_ListAndDetail.xaml"
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
            this.uc_InvList = ((VcsConnect_Client.Views.MainTableViews.uc_Invoice_List)(target));
            return;
            case 2:
            this.uc_InvDetail = ((VcsConnect_Client.Views.MainTableViews.uc_Invoice_Detail)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

