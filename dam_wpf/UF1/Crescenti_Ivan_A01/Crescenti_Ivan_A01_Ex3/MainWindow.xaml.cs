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

namespace Crescenti_Ivan_A01_Ex3
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

        #region validacions

        private void txt_preuproducte_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(txt_preuproducte.Text, out float x))
            {
                notificacio("El preu ha de ser un valor numeric decimal", "Error", MessageBoxImage.Error);
                txt_preuproducte.Text = "0,00";
            }
        }

        private void txt_dte_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(txt_dte.Text, out float x))
            {
                notificacio("El descompte ha de ser un valor numeric decimal", "Error", MessageBoxImage.Error);
                txt_dte.Text = "0";
            }
        }

        #endregion

        private void btn_titolcomplet_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_preuproducte.Text) && !String.IsNullOrEmpty(txt_dte.Text))
            {
                //CALCUL MATEMATIC
                txt_preunet.Text = (float.Parse(txt_preuproducte.Text) - ((float.Parse(txt_preuproducte.Text) * (float.Parse(txt_dte.Text) + 21.0f)) / 100)).ToString();
            }
            else
            {
                notificacio("Tots els camps han de estar emplenats", "Error", MessageBoxImage.Error);
            }
        }


        void notificacio(string missatge, string titol = "Informació", MessageBoxImage img = MessageBoxImage.Asterisk)
        {
            MessageBox.Show(missatge, titol, MessageBoxButton.OK, img);
        }
    }
}
