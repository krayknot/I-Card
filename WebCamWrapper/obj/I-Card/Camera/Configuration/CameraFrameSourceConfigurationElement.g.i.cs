﻿#pragma checksum "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D82BA9483D5927F1D132CA72A6B4BF03"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Touchless.Vision.Camera.Configuration {
    
    
    /// <summary>
    /// CameraFrameSourceConfigurationElement
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class CameraFrameSourceConfigurationElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxCameras;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelCameraInfo;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCameraProperties;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCameraFPSValue;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkLimitFps;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLimitFps;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPreview;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Touchless.Vision;component/camera/configuration/cameraframesourceconfigurationel" +
                    "ement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.comboBoxCameras = ((System.Windows.Controls.ComboBox)(target));
            
            #line 8 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            this.comboBoxCameras.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxCameras_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.panelCameraInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.buttonCameraProperties = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            this.buttonCameraProperties.Click += new System.Windows.RoutedEventHandler(this.buttonCameraProperties_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.labelCameraFPSValue = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.chkLimitFps = ((System.Windows.Controls.CheckBox)(target));
            
            #line 18 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            this.chkLimitFps.Checked += new System.Windows.RoutedEventHandler(this.chkLimitFps_Checked);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            this.chkLimitFps.Unchecked += new System.Windows.RoutedEventHandler(this.chkLimitFps_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtLimitFps = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Camera\Configuration\CameraFrameSourceConfigurationElement.xaml"
            this.txtLimitFps.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtLimitFps_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imgPreview = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

