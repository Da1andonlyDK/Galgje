﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E26C7453E496601D8C42415CB2D4F2CF646C6F318BEFAC22B91D8B591044E67A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Galgje_v2;
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


namespace Galgje_v2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label MSG_Label;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_NieuwSpel;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_Verberg;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_StartOpnieuw;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_Raad;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Input;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Output;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TimerText;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Timer;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_Play;
        
        #line default
        #line hidden
        
        
        #line 278 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BTN_Stop;
        
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
            System.Uri resourceLocater = new System.Uri("/Galgje v2;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.MSG_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.BTN_NieuwSpel = ((System.Windows.Controls.Label)(target));
            
            #line 86 "..\..\MainWindow.xaml"
            this.BTN_NieuwSpel.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_NieuwSpel_MouseDown);
            
            #line default
            #line hidden
            
            #line 87 "..\..\MainWindow.xaml"
            this.BTN_NieuwSpel.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LBL_MouseEnter);
            
            #line default
            #line hidden
            
            #line 88 "..\..\MainWindow.xaml"
            this.BTN_NieuwSpel.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LBL_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTN_Verberg = ((System.Windows.Controls.Label)(target));
            
            #line 114 "..\..\MainWindow.xaml"
            this.BTN_Verberg.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_Verberg_MouseDown);
            
            #line default
            #line hidden
            
            #line 115 "..\..\MainWindow.xaml"
            this.BTN_Verberg.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LBL_MouseEnter);
            
            #line default
            #line hidden
            
            #line 116 "..\..\MainWindow.xaml"
            this.BTN_Verberg.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LBL_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTN_StartOpnieuw = ((System.Windows.Controls.Label)(target));
            
            #line 142 "..\..\MainWindow.xaml"
            this.BTN_StartOpnieuw.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_StartOpnieuw_MouseDown);
            
            #line default
            #line hidden
            
            #line 143 "..\..\MainWindow.xaml"
            this.BTN_StartOpnieuw.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LBL_MouseEnter);
            
            #line default
            #line hidden
            
            #line 144 "..\..\MainWindow.xaml"
            this.BTN_StartOpnieuw.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LBL_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTN_Raad = ((System.Windows.Controls.Label)(target));
            
            #line 171 "..\..\MainWindow.xaml"
            this.BTN_Raad.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_Raad_MouseDown);
            
            #line default
            #line hidden
            
            #line 172 "..\..\MainWindow.xaml"
            this.BTN_Raad.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LBL_MouseEnter);
            
            #line default
            #line hidden
            
            #line 173 "..\..\MainWindow.xaml"
            this.BTN_Raad.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LBL_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Input = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Output = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TimerText = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.Timer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.BTN_Play = ((System.Windows.Controls.Label)(target));
            
            #line 271 "..\..\MainWindow.xaml"
            this.BTN_Play.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_Play_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BTN_Stop = ((System.Windows.Controls.Label)(target));
            
            #line 288 "..\..\MainWindow.xaml"
            this.BTN_Stop.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_Stop_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

