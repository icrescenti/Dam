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

        #region events
        private void btnProvaConex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new MongoClient(Config.dbSocket);
                lblEstat.Content = "Connectat al servidor mongoDB!";
            }
            catch { }
        }

        private void btnMostrarTot_Click(object sender, RoutedEventArgs e)
        {
            if (estasConectat())
            {
                mostrarPistesGrid(true);
                taulaDades.ItemsSource = cercarSocis();
                taulaPistes.ItemsSource = cercarPistes();
            }
        }

        private void btnBuscarSoci_Click(object sender, RoutedEventArgs e)
        {
            if (estasConectat())
            {
                mostrarPistesGrid();
                AdminSoci formulari = new AdminSoci(1);
                formulari.ShowDialog();
                if (formulari.result != null)
                    taulaDades.ItemsSource = cercarSocis(formulari.result.nom, formulari.result.dni);
            }
        }

        private void btnInserirSoci_Click(object sender, RoutedEventArgs e)
        {
            if (estasConectat())
            {
                mostrarPistesGrid();
                AdminSoci formulari = new AdminSoci(2);
                formulari.ShowDialog();
                if (formulari.result != null)
                    inserirSoci(formulari.result);

                taulaDades.ItemsSource = cercarSocis();
            }
        }

        private void btnModificarSoci_Click(object sender, RoutedEventArgs e)
        {
            if (estasConectat())
            {
                mostrarPistesGrid();
                AdminSoci formulari = new AdminSoci(1);
                formulari.ShowDialog();
                if (formulari.result != null && (formulari.result.nom != "" || formulari.result.dni != ""))
                {
                    List<Soci> socis = cercarSocis(formulari.result.nom, formulari.result.dni);
                    formulari = new AdminSoci(3, socis);
                    formulari.ShowDialog();
                    if (formulari.result != null)
                        modificarSoci(socis[0], formulari.result);
                    
                    taulaDades.ItemsSource = cercarSocis();
                }
            }
        }
        #endregion


        #region funcions
        List<Soci> cercarSocis(string nom = "", string dni = "")
        {
            IMongoDatabase database = client.GetDatabase("Tennis");

            if (nom == "" && dni == "")
            {
                IMongoCollection<Soci> socis = database.GetCollection<Soci>("soci");
                return socis.AsQueryable<Soci>().ToList();
            }
            else
            {
                IMongoCollection<Soci> socis = database.GetCollection<Soci>("soci");
                return socis.AsQueryable<Soci>().Where<Soci>(soci =>
                    soci.nom.ToLower() == nom.ToLower() ||
                    soci.dni.ToLower() == dni.ToLower()
                ).ToList();
            }
        }
        
        List<Pista> cercarPistes()
        {
            IMongoDatabase database = client.GetDatabase("Tennis");
            IMongoCollection<Pista> pistes = database.GetCollection<Pista>("pista");
            return pistes.AsQueryable<Pista>().ToList();
        }

        void inserirSoci(Soci nouSoci)
        {
            IMongoDatabase database = client.GetDatabase("Tennis");
            IMongoCollection<Soci> socis = database.GetCollection<Soci>("soci");

            socis.InsertOne(nouSoci);
        }
        
        void modificarSoci(Soci sociOriginal, Soci nouSoci)
        {
            IMongoDatabase database = client.GetDatabase("Tennis");
            IMongoCollection<Soci> socis = database.GetCollection<Soci>("soci");

            FilterDefinition<Soci> filtres = Builders<Soci>.Filter.Eq("objecteId", sociOriginal.objecteId);

            UpdateDefinition<Soci> update = Builders<Soci>.Update
                .Set("numero_soci", nouSoci.numero_soci)
                .Set("nom", nouSoci.nom)
                .Set("cognom", nouSoci.cognom)
                .Set("dni", nouSoci.dni)
                .Set("federat", nouSoci.federat);
            
            socis.UpdateOne(filtres, update);
        }

        bool estasConectat()
        {
            if (client != null)
                return true;
            else
            {
                MessageBox.Show("Error, no tens establerta una conexio activa amb a la base de dades", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        void mostrarPistesGrid(bool mostrar = false)
        {
            if (mostrar)
                taulaPistes.Visibility = Visibility.Visible;
            else
                taulaPistes.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
