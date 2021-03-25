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
using Datos.Repositoires;
using Negocio.Managment;
using Negocio.EntitiesDTO;
using PresentacioWPF.Views;
using System.Windows.Forms;

namespace PresentacioWPF
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

        private void btnProvaConex_Click(object sender, EventArgs e)
        {
            if (new Negocio.Managment.ProvaDeConexio().provaDeConexio())
            {
                lblEstat.Content = "Conexio establerta";
            }
            else
            {
                lblEstat.Content = "Conexio fallida";
            }
        }

        private void btnConsultaLibros_Click(object sender, EventArgs e)
        {
            dataGridView1.ItemsSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
        }

        private void btnConsultarConUnidades_Click(object sender, EventArgs e)
        {
            dataGridView1.ItemsSource = new Negocio.Managment.LibroManagament().ObtenerLibrosUnidades();
        }

        private void btnAltaLlibre_Click(object sender, EventArgs e)
        {
            AltaLlibre pantallaAlta = new AltaLlibre();
            pantallaAlta.ShowDialog();
        }
        
        private void btnModLlibre_Click(object sender, EventArgs e)
        {
            Negocio.EntitiesDTO.LibrosDTO LlibreSeleccionat = dataGridView1.Items[dataGridView1.SelectedIndex] as Negocio.EntitiesDTO.LibrosDTO;

            AltaLlibre pantallaAlta = new AltaLlibre(LlibreSeleccionat);
            pantallaAlta.ShowDialog();
            dataGridView1.ItemsSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView1.Items.Count > 0)
            {
                Negocio.EntitiesDTO.LibrosDTO llibreSeleccionat = dataGridView1.Items[dataGridView1.SelectedIndex] as Negocio.EntitiesDTO.LibrosDTO;
                if (new Datos.Repositoris.LibroRepository().verificarUnidades(llibreSeleccionat.idLibro))
                {
                    DialogResult resultat = System.Windows.Forms.MessageBox.Show("Aquest llibre no te unitats\nEstas segur de que el vols eliminar?", "Validacio", MessageBoxButtons.YesNo);

                    if (resultat == System.Windows.Forms.DialogResult.Yes)
                    {
                        new Negocio.Managment.LibroManagament().EliminarLibro(llibreSeleccionat);
                    }
                }
                else
                {
                    new Negocio.Managment.LibroManagament().EliminarLibro(llibreSeleccionat);
                }
                dataGridView1.ItemsSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
            }
        }

        private void btnAltaCategoria_Click(object sender, RoutedEventArgs e)
        {
            AltaCategorias pantallaAlta = new AltaCategorias();
            pantallaAlta.ShowDialog();
        }

        private void btnConsultaCategorias_Click(object sender, RoutedEventArgs e)
        {
            dataGridView1.ItemsSource = new Negocio.Managment.CategoriaManagment().ObtenerCategorias();
        }

        private void btnModCategoria_Click(object sender, RoutedEventArgs e)
        {
            Negocio.EntitiesDTO.CategoriaDTO LlibreSeleccionat = dataGridView1.Items[dataGridView1.SelectedIndex] as Negocio.EntitiesDTO.CategoriaDTO;

            AltaCategorias pantallaAlta = new AltaCategorias(LlibreSeleccionat);
            pantallaAlta.ShowDialog();
            dataGridView1.ItemsSource = new Negocio.Managment.CategoriaManagment().ObtenerCategorias();

        }

        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
