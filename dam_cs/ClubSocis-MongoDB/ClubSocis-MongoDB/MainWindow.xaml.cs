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
        MongoClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProvaConex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new MongoClient("mongodb://192.168.0.46:27017");
                lblEstat.Content = "Connectat al servidor mongoDB!";
            }
            catch { }
        }

        private void btnMostrarTot_Click(object sender, RoutedEventArgs e)
        {
            //taulaDades.ItemsSource = 
                cercarSocis();
            taulaDades.ItemsSource = cercarPistes();
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



        void cercarSocis()
        {
            if (client != null)
            {
                IMongoDatabase database = client.GetDatabase("Tennis");
                IMongoCollection<Soci> socis = database.GetCollection<Soci>("soci");
            }
        }
        
        List<Pista> cercarPistes()
        {
            if (client != null)
            {
                IMongoDatabase database = client.GetDatabase("Tennis");
                IMongoCollection<Pista> pistes = database.GetCollection<Pista>("pista");

                return pistes.AsQueryable<Pista>().ToList();
            }
            return null;
        }
    }
}
