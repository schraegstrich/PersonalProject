﻿#pragma checksum "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6819EE412BB8B184500509F7A3257C20C4F015BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client_FrontEnd;
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


namespace Client_FrontEnd {
    
    
    /// <summary>
    /// AddFoodItemWindow
    /// </summary>
    public partial class AddFoodItemWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tLink;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tQuantityPackage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tQuantityUnits;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tShelf;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPosition;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client_FrontEnd;component/fooditemmanagement/addfooditemwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.tName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tLink = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tQuantityPackage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tQuantityUnits = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tShelf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cbPosition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\FoodItemManagement\AddFoodItemWindow.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

