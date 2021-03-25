using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace M07UF1EX2IvanCrescentiHernandez
{
    /// <summary>
    /// Lógica de interacción para DadesUsuari.xaml
    /// </summary>
    public partial class DadesUsuari : Window
    {
        ObservableCollection<Usuari> usuaris;
        public DadesUsuari(ObservableCollection<Usuari> usuarisParametre)
        {
            InitializeComponent();
            //this.DataContext = this;

            usuaris = usuarisParametre;
            llistaUsuaris.ItemsSource = usuaris;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(llistaUsuaris.ItemsSource);
        }

        private void dadesUsuari_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (Usuari usuari in usuaris)
            {
                ListBoxItem listitem = (ListBoxItem)(llistaUsuaris.ItemContainerGenerator.ContainerFromIndex(i));
                i++;
            }
        }
    }
}
