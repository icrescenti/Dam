using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crescenti_Ivan_A06
{
    /// <summary>
    /// Lógica de interacción para ControlDades.xaml
    /// </summary>
    public partial class ControlDades : UserControl
    {
        public ControlDades()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static DependencyProperty SetMaxTemperatura = DependencyProperty.Register("maxTemperatura", typeof(string), typeof(ControlDades));
        public static DependencyProperty SetMinTemperatura = DependencyProperty.Register("minTemperatura", typeof(string), typeof(ControlDades));
        public static DependencyProperty SetDia = DependencyProperty.Register("diaSetmana", typeof(string), typeof(ControlDades));
        public static DependencyProperty SetTemps = DependencyProperty.Register("imgTemps", typeof(ImageSource), typeof(ControlDades));


        public string maxTemperatura
        {
            get { return (string)GetValue(SetMaxTemperatura); }
            set { SetValue(SetMaxTemperatura, value); }
        }
        public string minTemperatura
        {
            get { return (string)GetValue(SetMinTemperatura); }
            set { SetValue(SetMinTemperatura, value); }
        }
        public string diaSetmana
        {
            get { return (string)GetValue(SetDia); }
            set { SetValue(SetDia, value); }
        }
        public ImageSource imgTemps
        {
            get { return (ImageSource)GetValue(SetTemps); }
            set { SetValue(SetTemps, value); }
        }

        private void actualitzarDades_Click(object sender, RoutedEventArgs e)
        {
            ActualitzarInformacio nw = new ActualitzarInformacio(this.lblDia.Content.ToString(), int.Parse(this.maxTemperatura.ToString()), int.Parse(this.minTemperatura.ToString()));
            nw.ShowDialog();
        }
    }
}
