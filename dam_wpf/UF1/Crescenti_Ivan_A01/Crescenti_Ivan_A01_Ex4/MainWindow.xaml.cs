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

namespace Crescenti_Ivan_A01_Ex4
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

        private void txt_altura_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(txt_altura.Text, out float x))
            {
                notificacio("La altura ha de ser un valor numeric!", "Error", MessageBoxImage.Error);
                txt_altura.Text = "1,00";
            }
        }

        private void txt_allargada_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(txt_allargada.Text, out float x))
            {
                notificacio("La allargada ha de ser un valor numeric!", "Error", MessageBoxImage.Error);
                txt_allargada.Text = "1,00";
            }
        }

        #endregion

        private void btn_calcular_Click(object sender, RoutedEventArgs e)
        {
            if (txt_allargada.Text.Length > 0 && txt_altura.Text.Length > 0)
            {
                txt_area.Text = "Area: " + ( float.Parse(txt_altura.Text) * float.Parse(txt_allargada.Text) );
                txt_permietre.Text = "Perimetre: " + ( ( float.Parse(txt_altura.Text) * 2) + ( float.Parse(txt_allargada.Text) * 2) );
                txt_diagonal.Text = "Diagonal: " + ( float.Parse(txt_altura.Text) + float.Parse(txt_allargada.Text) ) + "²";
            }
            else
                notificacio("Cap de els camps pot estar en blanc", "Error", MessageBoxImage.Error);
        }

        void notificacio(string missatge, string titol = "Informació", MessageBoxImage img = MessageBoxImage.Asterisk)
        {
            MessageBox.Show(missatge, titol, MessageBoxButton.OK, img);
        }
    }
}