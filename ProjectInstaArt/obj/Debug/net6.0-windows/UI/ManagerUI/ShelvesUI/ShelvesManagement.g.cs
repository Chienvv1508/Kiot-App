﻿#pragma checksum "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20BE5D4BF3F5CE009E99CBF49735568A619BF63B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectInstaArt.UI.ManagerUI.ShelvesUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjectInstaArt.UI.ManagerUI.ShelvesUI {
    
    
    /// <summary>
    /// ShelvesManagement
    /// </summary>
    public partial class ShelvesManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductCode;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImportDetailId;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUnit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuantity;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvShelves;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectInstaArt;component/ui/managerui/shelvesui/shelvesmanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtProductCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtImportDetailId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtUnit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\..\UI\ManagerUI\ShelvesUI\ShelvesManagement.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lvShelves = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

