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

namespace Crescenti_Ivan_A01_Ex2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region inicialitzacio
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region validacions
        private void txt_nombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txt_nombre.Text, out int x))
            {
                notificacio("El camp \"" + lbl_nombre.Content + "\" ha de ser numeric", "Error", MessageBoxImage.Error);
                txt_nombre.Text = "5";
            }
            
        }
        #endregion


        private void btn_titolcomplet_Click(object sender, RoutedEventArgs e)
        {
            int residu = -1;
            if (txt_nombre.Text != "")
            {
                residu = int.Parse(txt_nombre.Text) % 5;

                if (residu == 0)
                {
                    txt_resultat.Text = "El nombre es multiple de 5";
                }
                else
                {
                    txt_resultat.Text = "El nombre NO es multiple de 5";
                }
            }
            else
                notificacio("La casella amb el valor no pot estar buida", "Error", MessageBoxImage.Error);
        }

        void notificacio(string missatge, string titol = "Informació", MessageBoxImage img = MessageBoxImage.Asterisk)
        {
            MessageBox.Show(missatge, titol, MessageBoxButton.OK, img);
        }
    }
}
