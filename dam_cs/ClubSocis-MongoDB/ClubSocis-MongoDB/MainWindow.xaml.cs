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
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClubSocis_MongoDB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MongoClient client = new MongoClient();
        bool connectat = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProvaConex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new MongoClient("mongodb://192.168.0.45:27017");
                connectat = true;
            }
            catch { }
        }

        private void btnMostrarTot_Click(object sender, RoutedEventArgs e)
        {
            if (connectat)
            {
                IMongoDatabase database = client.GetDatabase("Tennis");
                var ape = database.GetCollection<Pista>("pista");
                var ape2 = database.GetCollection<Soci>("soci");
            }
        }

        private void btnModLlibre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarSociDNI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModCategoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
