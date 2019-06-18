﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4455F027681A5C7DDEE1134A610D47251F55E114221970374E58AEF003947540"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MiniProject_Batch_Rename;
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


namespace MiniProject_Batch_Rename {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox newCaseCheckBox;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox moveCheckBox;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox removePatternCheckBox;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox replaceCheckBox;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox newNameCheckBox;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView fileListView;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView folderListView;
        
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
            System.Uri resourceLocater = new System.Uri("/MiniProject-Batch-Rename;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            
            #line 102 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.handleNewCaseAction);
            
            #line default
            #line hidden
            return;
            case 2:
            this.newCaseCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            
            #line 110 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.handleMoveAction);
            
            #line default
            #line hidden
            return;
            case 4:
            this.moveCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            
            #line 118 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.handleReplaceAction);
            
            #line default
            #line hidden
            return;
            case 6:
            this.removePatternCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            
            #line 126 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.handleFullNameNormalize);
            
            #line default
            #line hidden
            return;
            case 8:
            this.replaceCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            
            #line 134 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.handleUniqueName);
            
            #line default
            #line hidden
            return;
            case 10:
            this.newNameCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            
            #line 164 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addSysFileDialog);
            
            #line default
            #line hidden
            return;
            case 12:
            this.fileListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 13:
            
            #line 194 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addSysFolderDialog);
            
            #line default
            #line hidden
            return;
            case 14:
            this.folderListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

