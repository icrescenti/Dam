#pragma checksum "..\..\ActualitzarInformacio.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "413446ED60F37BB7C2B72FA70CE19BAE8EAAB92AAA115F857ED2BB9789CEEB37"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Crescenti_Ivan_A06;
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


namespace Crescenti_Ivan_A06 {
    
    
    /// <summary>
    /// ActualitzarInformacio
    /// </summary>
    public partial class ActualitzarInformacio : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDia;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTempsMaxim;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderTempMax;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTempMax;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTempsMinima;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderTempMin;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTempMin;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPrevisio;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTemps;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeguent;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ActualitzarInformacio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnterior;
        
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
            System.Uri resourceLocater = new System.Uri("/Crescenti_Ivan_A06;component/actualitzarinformacio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ActualitzarInformacio.xaml"
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
            this.lblDia = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblTempsMaxim = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.sliderTempMax = ((System.Windows.Controls.Slider)(target));
            
            #line 13 "..\..\ActualitzarInformacio.xaml"
            this.sliderTempMax.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderTempMax_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtTempMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\ActualitzarInformacio.xaml"
            this.txtTempMax.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtTempMax_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblTempsMinima = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.sliderTempMin = ((System.Windows.Controls.Slider)(target));
            
            #line 16 "..\..\ActualitzarInformacio.xaml"
            this.sliderTempMin.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderTempMin_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtTempMin = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\ActualitzarInformacio.xaml"
            this.txtTempMin.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtTempMin_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblPrevisio = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.cmbTemps = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.btnSeguent = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnAnterior = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

