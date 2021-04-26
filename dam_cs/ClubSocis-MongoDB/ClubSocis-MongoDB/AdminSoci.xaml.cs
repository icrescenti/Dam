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

namespace ClubSocis_MongoDB
{
    /// <summary>
    /// Lógica de interacción para AdminSoci.xaml
    /// </summary>
    public partial class AdminSoci : Window
    {
        private int tipusId = 0;
        public Soci result;

        public AdminSoci(int tipusId, List<Soci> socis = null)
        {
            InitializeComponent();
            this.tipusId = tipusId;

            if (tipusId == 1)
            {
                cercarSociGrid.Visibility = Visibility.Visible;
            }
            else if (tipusId == 2)
            {
                inserirModificarSociGrid.Visibility = Visibility.Visible;
            }
            else if (tipusId == 3)
            {
                txtNumeroSoci.Text = socis[0].numero_soci.ToString();
                txtNom2.Text = socis[0].nom;
                txtCognom.Text = socis[0].cognom;
                txtDNI.Text = socis[0].dni;
                ckFederat.IsChecked = socis[0].federat;

                inserirModificarSociGrid.Visibility = Visibility.Visible;
            }
        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            if (tipusId == 1)
            {
                result = new Soci(0, "", "", "", false);
                result.nom = txtNom.Text;
                result.dni = txtDni.Text;
            }
            else if (tipusId == 2)
            {
                result = new Soci(0, "", "", "", false);

                int x;
                int.TryParse(txtNumeroSoci.Text, out x);
                result.numero_soci = x;

                result.nom = txtNom2.Text;
                result.cognom = txtCognom.Text;
                result.dni = txtDNI.Text;
                result.federat = (bool)ckFederat.IsChecked;

                if (x < 1)
                {
                    MessageBox.Show("Error, el numero de soci no es valid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = null;
                    return;
                }
            }
            else if (tipusId == 3)
            {
                result = new Soci(0, "", "", "", false);

                int x;
                int.TryParse(txtNumeroSoci.Text, out x);
                result.numero_soci = x;

                result.nom = txtNom2.Text;
                result.cognom = txtCognom.Text;
                result.dni = txtDNI.Text;
                result.federat = (bool)ckFederat.IsChecked;

                if (x < 1)
                {
                    MessageBox.Show("Error, el numero de soci no es valid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = null;
                    return;
                }
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
    }
}
