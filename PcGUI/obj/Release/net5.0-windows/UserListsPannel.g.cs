#pragma checksum "..\..\..\UserListsPannel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F67ED370F4E24E2710A95722211A8C8837746041"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PcParted;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using logicPC.Gestionnaires;


namespace PcParted {
    
    
    /// <summary>
    /// UserListsPannel
    /// </summary>
    public partial class UserListsPannel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\UserListsPannel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserListsPannel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ListesComboBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserListsPannel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PcGUI;component/userlistspannel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserListsPannel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\UserListsPannel.xaml"
            ((PcParted.UserListsPannel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.ListesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\UserListsPannel.xaml"
            this.ListesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 46 "..\..\..\UserListsPannel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_rem);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 51 "..\..\..\UserListsPannel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_dupe);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 58 "..\..\..\UserListsPannel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_add);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 72 "..\..\..\UserListsPannel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickRename);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

