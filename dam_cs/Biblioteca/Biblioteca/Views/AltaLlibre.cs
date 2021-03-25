using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.EntitiesDTO;
using Negocio.Managment;

namespace Biblioteca.Views
{
    public partial class AltaLlibre : Form
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

        private void AltaLlibre_Load(object sender, EventArgs e)
        {
            cmbCategorias.DataSource = new Negocio.Managment.LibroManagament().ObtenerCategorias().Select(b => b.Nombre).ToList();
            
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceptar_Click(object sender, EventArgs e)
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
    }
}
