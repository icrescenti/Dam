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
using Negocio.EntitiesDTO;
using Negocio.Managment;

namespace PresentacioWPF.Views
{
    /// <summary>
    /// Lógica de interacción para AltaLlibre.xaml
    /// </summary>
    public partial class AltaLlibre : Window
    {
        public LibrosDTO llibreMod;
        public AltaLlibre(LibrosDTO llibre)
        {
            llibreMod = llibre;
            InitializeComponent();
        }

        public AltaLlibre()
        {
            InitializeComponent();
        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            if (llibreMod is null != true)
            {
                llibreMod.Nombre = txtNom.Text;
                llibreMod.Autor = txtAutor.Text;
                llibreMod.idCategoria = new Negocio.Managment.LibroManagament().ObtenerCategorias().Where(b => b.Nombre == cmbCategorias.Text).First().idCategoria;
                llibreMod.FechaPublicacion = DateTime.Now;

                new Negocio.Managment.LibroManagament().ModificarLibro(llibreMod);
            }
            else
            {
                LibrosDTO libro = new LibrosDTO();
                libro.Nombre = txtNom.Text;
                libro.Autor = txtAutor.Text;
                libro.idCategoria = new Negocio.Managment.LibroManagament().ObtenerCategorias().Where(b => b.Nombre == cmbCategorias.Text).First().idCategoria;
                libro.FechaPublicacion = DateTime.Now;
                new Negocio.Managment.LibroManagament().AltaLibro(libro);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AltaLlibre1_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategorias.ItemsSource = new Negocio.Managment.LibroManagament().ObtenerCategorias().Select(b => b.Nombre).ToList();

            if (llibreMod is null != true)
            {
                txtNom.Text = llibreMod.Nombre;
                txtAutor.Text = llibreMod.Autor;
                cmbCategorias.Text = new Negocio.Managment.LibroManagament().ObtenerCategorias().Where(b => b.idCategoria == llibreMod.idCategoria).First().Nombre;

                /*
                llibreMod.Nombre = txtNom.Text;
                llibreMod.Autor = txtAutor.Text;
                llibreMod.idCategoria = new Negocio.Managment.LibroManagament().ObtenerCategorias().Where(b => b.Nombre == cmbCategorias.Text).First().idCategoria;
                */
            }
        }
    }
}
