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
using System.Windows.Shapes;

namespace Crescenti_Ivan_A06
{
    /// <summary>
    /// Lógica de interacción para ActualitzarInformacio.xaml
    /// </summary>
    public partial class ActualitzarInformacio : Window
    {
        public ActualitzarInformacio(string diasetmana, int max, int min)
        {
            InitializeComponent();
            lblDia.Content = diasetmana;
            sliderTempMax.Value = max;
            sliderTempMin.Value = min;
        }

        #region events
        private void sliderTempMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtTempMax.Text = sliderTempMax.Value.ToString();
        }

        private void sliderTempMin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtTempMin.Text = sliderTempMin.Value.ToString();
        }

        private void txtTempMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTempMax.Text != "" && txtTempMax.Text  != "-")
                sliderTempMax.Value = int.Parse(txtTempMax.Text);
        }
        private void txtTempMin_KeyDown(object sender, KeyEventArgs e)
        {
            sliderTempMin.Value = int.Parse(txtTempMin.Text);
        }
        #endregion
    }
}
