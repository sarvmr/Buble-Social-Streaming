﻿#pragma checksum "..\..\..\Views\MainView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A1310D3BDFA12AA9111A233D7EDB65E0B087705092A0CF1FB7A9CB8F7141D388"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Buble.ViewModels;
using Buble.Views;
using FontAwesome.Sharp;
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


namespace Buble.Views {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 122 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Upload_button;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pnlControlBar;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/Buble;component/views/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MainView.xaml"
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
            this.Upload_button = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.pnlControlBar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 171 "..\..\..\Views\MainView.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.minimize);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 205 "..\..\..\Views\MainView.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.close);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 306 "..\..\..\Views\MainView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.log_out);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

