﻿#pragma checksum "..\..\..\Card.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6BF4801071B1D4EBBF08434D98C8605FEE236960"
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


namespace PcParted {
    
    
    /// <summary>
    /// UserControl3
    /// </summary>
    public partial class UserControl3 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PcParted.UserControl3 card;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grectanctle;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Bluectangle;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nom_carte;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run eth_S;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run watt;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock eth_S_Copy1;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run prix;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgCard;
        
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
            System.Uri resourceLocater = new System.Uri("/PcParted;component/card.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Card.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.card = ((PcParted.UserControl3)(target));
            
            #line 10 "..\..\..\Card.xaml"
            this.card.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UC_clicked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grectanctle = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Bluectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.nom_carte = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.eth_S = ((System.Windows.Documents.Run)(target));
            return;
            case 6:
            this.watt = ((System.Windows.Documents.Run)(target));
            return;
            case 7:
            this.eth_S_Copy1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.prix = ((System.Windows.Documents.Run)(target));
            return;
            case 9:
            this.ImgCard = ((System.Windows.Controls.Image)(target));
            
            #line 108 "..\..\..\Card.xaml"
            this.ImgCard.Loaded += new System.Windows.RoutedEventHandler(this.ImgCard_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

