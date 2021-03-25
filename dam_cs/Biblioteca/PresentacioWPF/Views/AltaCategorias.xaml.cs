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
    /// Lógica de interacción para AltaCategorias.xaml
    /// </summary>
    public partial class AltaCategorias : Window
    {
        public CategoriaDTO categoriaMod;
        
        public AltaCategorias()
        {
            InitializeComponent();
        }
        public AltaCategorias(CategoriaDTO categoria)
        {
            categoriaMod = categoria;
            InitializeComponent();
        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            if (categoriaMod is null != true)
            {
                categoriaMod.Nombre = txtNomCategoria.Text;
                new Negocio.Managment.CategoriaManagment().ModificarCategoria(categoriaMod);
            }
            else
            {
                CategoriaDTO categoria = new CategoriaDTO();
                categoria.Nombre = txtNomCategoria.Text;
                new Negocio.Managment.CategoriaManagment().AltaCategoria(categoria);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AltaLlibre1_Loaded(object sender, RoutedEventArgs e)
        {
            if (categoriaMod is null != true)
            {
                txtNomCategoria.Text = categoriaMod.Nombre;
            }
        }
    }
}
