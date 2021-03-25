using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.Views;
using Datos.Repositoires;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProvaConex_Click(object sender, EventArgs e)
        {
            if (new Negocio.Managment.ProvaDeConexio().provaDeConexio())
            {
                lblEstat.Text = "Conexio establerta";
            }
            else
            {
                lblEstat.Text = "Conexio fallida";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultaLibros_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
        }

        private void btnConsultarConUnidades_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Negocio.Managment.LibroManagament().ObtenerLibrosUnidades();
        }

        private void btnAltaLlibre_Click(object sender, EventArgs e)
        {
            AltaLlibre pantallaAlta = new AltaLlibre();
            pantallaAlta.ShowDialog();
        }

        private void btnModLlibre_Click(object sender, EventArgs e)
        {
            Negocio.EntitiesDTO.LibrosDTO LlibreSeleccionat = dataGridView1.CurrentRow.DataBoundItem as Negocio.EntitiesDTO.LibrosDTO;

            AltaLlibre pantallaAlta = new AltaLlibre(LlibreSeleccionat);
            pantallaAlta.ShowDialog();
            dataGridView1.DataSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Negocio.EntitiesDTO.LibrosDTO llibreSeleccionat = dataGridView1.CurrentRow.DataBoundItem as Negocio.EntitiesDTO.LibrosDTO;
                if (new Datos.Repositoris.LibroRepository().verificarUnidades(llibreSeleccionat.idLibro))
                {
                    DialogResult resultat = MessageBox.Show("Aquest llibre no te unitats\nEstas segur de que el vols eliminar?", "Validacio", MessageBoxButtons.YesNo);
                
                    if (resultat == DialogResult.Yes)
                    {
                        new Negocio.Managment.LibroManagament().EliminarLibro(llibreSeleccionat);
                    }
                }
                else
                {
                    new Negocio.Managment.LibroManagament().EliminarLibro(llibreSeleccionat);
                }
                dataGridView1.DataSource = new Negocio.Managment.LibroManagament().ObtenerLibros();
            }
        }
    }
}
