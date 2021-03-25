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

namespace Crescenti_Ivan_A04
{
    /// <summary>
    /// Lógica de interacción para WindowAcercaDe.xaml
    /// </summary>
    public partial class WindowAcercaDe : Window
    {
        public WindowAcercaDe()
        {
            InitializeComponent();
        }

        private void btn_acceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
