﻿#pragma checksum "..\..\..\UpdateOrDeleteIngredientWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF6346CD308A2C9C76379E119264717DD995F464"
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
    /// UpdateOrDeleteIngredientWindow
    /// </summary>
    public partial class UpdateOrDeleteIngredientWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFoodItem;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tQuantityGrams;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tQuantityUnits;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Client_FrontEnd;V1.0.0.0;component/updateordeleteingredientwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
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
            this.cbFoodItem = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.tQuantityGrams = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tQuantityUnits = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.updateButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\UpdateOrDeleteIngredientWindow.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

