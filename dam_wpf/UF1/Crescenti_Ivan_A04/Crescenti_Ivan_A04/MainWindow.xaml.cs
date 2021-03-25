using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Crescenti_Ivan_A04
{
    public partial class MainWindow : Window
    {
        bool inicialitzat = false;
        public MainWindow()
        {
            InitializeComponent();
            inicialitzat = true;
        }

        #region events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mostrarbarra.IsChecked = true;
            sld_tamanylletra.Minimum = 11;
            sld_tamanylletra.Maximum = 44;
        }

        private void tab_pantalles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_configuracio_Click(object sender, RoutedEventArgs e)
        {
            config();
        }

        private void ajudaonline_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.google.com");
            Process.Start(sInfo);
        }

        private void finestra_about_Click(object sender, RoutedEventArgs e)
        {
            WindowAcercaDe acerca = new WindowAcercaDe();
            acerca.ShowDialog();
        }

        private void mostrarbarra_Checked(object sender, RoutedEventArgs e)
        {
            tbr_eines.Visibility = Visibility.Visible;
        }

        private void mostrarbarra_Unchecked(object sender, RoutedEventArgs e)
        {
            tbr_eines.Visibility = Visibility.Hidden;
        }

        private void btn_config_Click(object sender, RoutedEventArgs e)
        {
            config();
        }

        private void btn_imatge_Click(object sender, RoutedEventArgs e)
        {
            lbl_notificacio.Content = "Has accedit a la visualització d'imatges.";
            tab_pantalles.SelectedIndex = 1;
        }

        private void btn_video_Click(object sender, RoutedEventArgs e)
        {
            lbl_notificacio.Content = "Has accedit a la visualització de vídeos.";
            tab_pantalles.SelectedIndex = 2;
        }

        private void btn_tancar_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void sld_tamanylletra_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txt_benvinguda.FontSize = e.NewValue;
        }

        private void cmb_alineacio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inicialitzat)
            {
                if (cmb_alineacio.SelectedIndex == 0)
                {
                    txt_benvinguda.HorizontalAlignment = HorizontalAlignment.Center;
                    txt_benvinguda.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (cmb_alineacio.SelectedIndex == 1)
                {
                    txt_benvinguda.HorizontalAlignment = HorizontalAlignment.Center;
                    txt_benvinguda.VerticalAlignment = VerticalAlignment.Top;
                }
                else if (cmb_alineacio.SelectedIndex == 2)
                {
                    txt_benvinguda.HorizontalAlignment = HorizontalAlignment.Left;
                    txt_benvinguda.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (cmb_alineacio.SelectedIndex == 3)
                {
                    txt_benvinguda.HorizontalAlignment = HorizontalAlignment.Right;
                    txt_benvinguda.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (cmb_alineacio.SelectedIndex == 4)
                {
                    txt_benvinguda.HorizontalAlignment = HorizontalAlignment.Center;
                    txt_benvinguda.VerticalAlignment = VerticalAlignment.Bottom;
                }
            }
        }

        #endregion

        void config()
        {
            lbl_notificacio.Content = "Has accedit a la configuració";
            Configuracio conf = new Configuracio();
            conf.ShowDialog();
        }
    }
}
