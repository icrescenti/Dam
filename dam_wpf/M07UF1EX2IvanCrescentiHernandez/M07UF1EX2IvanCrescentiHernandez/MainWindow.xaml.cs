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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M07UF1EX2IvanCrescentiHernandez
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Usuari> usuaris = new ObservableCollection<Usuari>();

        public MainWindow()
        {
            InitializeComponent();

            Usuari usuari0 = new Usuari("Joe", "Doe", "teamIowa12", "joedoe@wyoming.us");
            Usuari usuari1 = new Usuari("Alex", "Martinez", "iesCampalans1899", "amartinez@centreeducatidelageneralitatdecatalunyaiesrafaelcampalans.net.cat.com.cat");
            Usuari usuari2 = new Usuari("Marc", "Vilagines", "aixoFaraunaCridaAlaLambda4", "mvp@claitec.com");
            Usuari usuari3 = new Usuari("Josep", "Mas", "fotemFeine24", "jmas@institutcampalans.net");
            Usuari usuari4 = new Usuari("Giancarlo", "Pinturelli", "scarpeRote409385", "gpinturelli@gmail.it");
            
            usuaris.Add(usuari0);
            usuaris.Add(usuari1);
            usuaris.Add(usuari2);
            usuaris.Add(usuari3);
            usuaris.Add(usuari4);
        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            bool trobat = false;

            if (!String.IsNullOrEmpty(credencialUsuari.campText) && !String.IsNullOrEmpty(credencialPassword.campText))
            {
                while (!trobat && i < (usuaris.Count-1))
                {
                    if (
                        (usuaris[i].Nom == credencialUsuari.campText.ToString()) &&
                        (usuaris[i].Password == credencialPassword.campText.ToString())
                       )
                    {
                        trobat = true;
                    }
                    i++;
                }
            }

            if (trobat)
            {
                DadesUsuari nwFinestra = new DadesUsuari(usuaris);
                nwFinestra.ShowDialog();
            }
            else
            {
                MessageBox.Show("El usuari o contrasenya son incorrectes, siusplau, torna a intentar-ho", "Credencials Invalides", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}