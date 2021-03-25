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

namespace M07UF1EX1IvanCrescenti
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void opcio_sortir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void opcio_ajuda_Click(object sender, RoutedEventArgs e)
        {
            mostrarAjuda();
        }

        private void enllaç_ajuda_Click(object sender, RoutedEventArgs e)
        {
            mostrarAjuda();
        }

        private void enllaç_novamaquina_Click(object sender, RoutedEventArgs e)
        {
            msg("Nova màquina virtual");
        }

        private void enllaç_obrirmaquina_Click(object sender, RoutedEventArgs e)
        {
            msg("Obrir màquina virtual");
        }

        private void enllaç_upgrade_Click(object sender, RoutedEventArgs e)
        {
            msg("Actualitzar VMWare");
        }

        private void img_iniciar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrarAccio("Play");
        }

        private void img_aturar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrarAccio("Stop");
        }

        private void img_pausar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrarAccio("Pause");
        }

        private void img_reiniciar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrarAccio("Restart");
        }

        private void lbx_maquinesVirtuals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbx_maquinesVirtuals.SelectedIndex == 0)
            {
                img_iniciar.IsEnabled = false;
                img_aturar.IsEnabled = false;
                img_pausar.IsEnabled = false;
                img_reiniciar.IsEnabled = false;

                img_iniciar.Visibility = Visibility.Hidden;
                img_aturar.Visibility = Visibility.Hidden;
                img_pausar.Visibility = Visibility.Hidden;
                img_reiniciar.Visibility = Visibility.Hidden;
            }
            else
            {
                img_iniciar.IsEnabled = true;
                img_aturar.IsEnabled = true;
                img_pausar.IsEnabled = true;
                img_reiniciar.IsEnabled = true;

                img_iniciar.Visibility = Visibility.Visible;
                img_aturar.Visibility = Visibility.Visible;
                img_pausar.Visibility = Visibility.Visible;
                img_reiniciar.Visibility = Visibility.Visible;
            }
        }

        #region funcions
        void msg(string missatge)
        {
            MessageBox.Show(missatge);
        }

        void mostrarAjuda()
        {
            FinestraAjudaxaml finestra = new FinestraAjudaxaml();
            finestra.ShowDialog();
        }

        void mostrarAccio(string accio)
        {
            if (lbx_maquinesVirtuals.SelectedIndex == -1 || lbx_maquinesVirtuals.SelectedIndex == 0)
            {
                msg("Heu de seleccionar una màquina virtual de la llista");
                lbx_maquinesVirtuals.SelectedIndex = 0;
            }
            else
                msg(accio + " " + ((ListBoxItem)lbx_maquinesVirtuals.SelectedItem).Tag);
        }


        #endregion
    }
}
