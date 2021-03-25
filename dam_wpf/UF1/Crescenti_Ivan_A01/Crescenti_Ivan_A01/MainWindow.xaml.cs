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

namespace Crescenti_Ivan_A01
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
        private void txt_any_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txt_any.Text, out int x))
            {
                notificacio("El camp \"Any de publicació\" ha de ser numeric", "Error", MessageBoxImage.Error);
                txt_any.Text = "1970";
            }
        }
        #endregion

        private void btn_titolcomplet_Click(object sender, RoutedEventArgs e)
        {
            if (txt_titol.Text != "" && txt_desenvolupador.Text != "" && txt_any.Text != "")
                notificacio(txt_titol.Text + " ," + txt_desenvolupador.Text + " ," + txt_any.Text);
            else
                notificacio("Cap de els camps pot estar en blanc", "Error", MessageBoxImage.Error);
        }


        void notificacio(string missatge, string titol = "Informació", MessageBoxImage img = MessageBoxImage.Asterisk)
        {
            MessageBox.Show(missatge, titol, MessageBoxButton.OK, img);
        }
    }
}
