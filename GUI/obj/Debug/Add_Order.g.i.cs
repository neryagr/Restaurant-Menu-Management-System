﻿#pragma checksum "..\..\Add_Order.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8102547C2388D366F90771F0B58BDA8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
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


namespace GUI {
    
    
    /// <summary>
    /// Add_Order
    /// </summary>
    public partial class Add_Order : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bruanch_numberTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox clComboBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateDatePicker;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kusher_levelComboBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Add_Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock reservation_numberTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/add_order.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Add_Order.xaml"
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
            
            #line 18 "..\..\Add_Order.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\Add_Order.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Add_Order.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.add_order);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            
            #line 21 "..\..\Add_Order.xaml"
            this.grid1.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.grid1_GotKeyboardFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bruanch_numberTextBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.clComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.dateDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.kusher_levelComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.reservation_numberTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
