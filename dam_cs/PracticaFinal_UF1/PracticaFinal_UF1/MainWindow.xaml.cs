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

using System.Media;

namespace PracticaFinal_UF1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer musica;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Registra_t_Click(object sender, RoutedEventArgs e)
        {
            dades formulari = new dades(true, null);

            formulari.ShowDialog();
        }

        private void btn_mostrar_dades_Click(object sender, RoutedEventArgs e)
        {
            Seleccionar_usr sel_usuari = new Seleccionar_usr();
            sel_usuari.ShowDialog();
        }

        private void ck_musica_Checked(object sender, RoutedEventArgs e)
        {
            musica = new SoundPlayer("res/musica.wav");
            musica.Load();
            musica.Play();
        }

        private void ck_musica_Unchecked(object sender, RoutedEventArgs e)
        {
            musica.Stop();
        }
    }
}
