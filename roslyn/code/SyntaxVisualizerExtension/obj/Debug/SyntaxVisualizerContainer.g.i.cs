﻿#pragma checksum "..\..\SyntaxVisualizerContainer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B597980C96A2C3F76F51326ADD6E7984"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.VisualStudio.Shell;
using Roslyn.Samples.SyntaxVisualizer.Control;
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


namespace Roslyn.Samples.SyntaxVisualizer.Extension {
    
    
    internal partial class SyntaxVisualizerContainer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\SyntaxVisualizerContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Roslyn.Samples.SyntaxVisualizer.Extension.SyntaxVisualizerContainer SyntaxVisualizerToolWindow;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\SyntaxVisualizerContainer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Roslyn.Samples.SyntaxVisualizer.Control.SyntaxVisualizerControl syntaxVisualizer;
        
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
            System.Uri resourceLocater = new System.Uri("/Roslyn.Samples.SyntaxVisualizer.Extension;component/syntaxvisualizercontainer.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\SyntaxVisualizerContainer.xaml"
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
            this.SyntaxVisualizerToolWindow = ((Roslyn.Samples.SyntaxVisualizer.Extension.SyntaxVisualizerContainer)(target));
            
            #line 37 "..\..\SyntaxVisualizerContainer.xaml"
            this.SyntaxVisualizerToolWindow.Loaded += new System.Windows.RoutedEventHandler(this.SyntaxVisualizerToolWindow_Loaded);
            
            #line default
            #line hidden
            
            #line 38 "..\..\SyntaxVisualizerContainer.xaml"
            this.SyntaxVisualizerToolWindow.GotFocus += new System.Windows.RoutedEventHandler(this.SyntaxVisualizerToolWindow_GotFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\SyntaxVisualizerContainer.xaml"
            this.SyntaxVisualizerToolWindow.LostFocus += new System.Windows.RoutedEventHandler(this.SyntaxVisualizerToolWindow_LostFocus);
            
            #line default
            #line hidden
            
            #line 40 "..\..\SyntaxVisualizerContainer.xaml"
            this.SyntaxVisualizerToolWindow.Unloaded += new System.Windows.RoutedEventHandler(this.SyntaxVisualizerToolWindow_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.syntaxVisualizer = ((Roslyn.Samples.SyntaxVisualizer.Control.SyntaxVisualizerControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

