﻿#pragma checksum "C:\dev\windowsphone\PelicanCross\PelicanCross\TrafficLights.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D76FF6A28DD602B3D1F432FB3010B21D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PelicanCross {
    
    
    public partial class TrafficLights : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Shapes.Ellipse amberLight;
        
        internal System.Windows.Shapes.Ellipse redLight;
        
        internal System.Windows.Shapes.Ellipse greenLight;
        
        internal System.Windows.Controls.TextBlock readings;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PelicanCross;component/TrafficLights.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.amberLight = ((System.Windows.Shapes.Ellipse)(this.FindName("amberLight")));
            this.redLight = ((System.Windows.Shapes.Ellipse)(this.FindName("redLight")));
            this.greenLight = ((System.Windows.Shapes.Ellipse)(this.FindName("greenLight")));
            this.readings = ((System.Windows.Controls.TextBlock)(this.FindName("readings")));
        }
    }
}

