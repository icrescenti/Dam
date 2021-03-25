using System;
using System.Collections.Generic;
using System.Data;
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

namespace PracticaFinal_UF1
{
    public partial class Seleccionar_usr : Window
    {
        public Seleccionar_usr()
        {
            InitializeComponent();
            notificacio.mostrar(false, "Seleccionar", "Selecciona un Soci de la llista a mostrarse");
        }

        private void seleccionar_Loaded(object sender, RoutedEventArgs e)
        {
            #region  lectura de fitxer
            Club club = Serialitzacio.Llegir("crimsondawndb.xml");
            #endregion

            DataTable dt = new DataTable();
            string[] textes = { "ID", "DNI", "Nom", "Cognoms", "Edat", "Federat"};

            #region generacio de dades
            if (club != null)
            {
                for (int i = 0; i < textes.Length; i++)
                    dt.Columns.Add(textes[i]);

                DataRow r;
                DateTime datanaix;

                for (int i = 0; i < club.socis.Length; i++)
                {
                    #region generacio de files
                    r = dt.NewRow();

                    //COMPATIBILITAT AMB DOS FORMATS, PER EDAT O PER DATA DE NAIXAMENT
                    if (DateTime.TryParse(club.socis[i].edat.ToString(), out datanaix))
                        r.SetField(4, Calcs.edat(datanaix));
                    else r.SetField(4, club.socis[i].edat);

                    r.SetField(0, club.socis[i].numeroSoci);
                    r.SetField(1, club.socis[i].dni);
                    r.SetField(2, club.socis[i].nom);
                    r.SetField(3, club.socis[i].cognoms);

                    string federat_str = "";
                    bool federat_bool = bool.Parse(club.socis[i].federat.ToString());
                    booleana_visual(true, ref federat_bool, ref federat_str);

                    r.SetField(5, federat_str);

                    dt.Rows.Add(r);
                    #endregion
                }

                dg_grid.DataContext = dt.DefaultView;
            }
            #endregion
            else
            {
                this.Close();
                notificacio.mostrar(false, "Dades no trobades", "No es pot trobar el fixter amb les dades dels socis, o no hi han socis registrats.");
            }
        }

        private void dg_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView r = dg_grid.SelectedItem as DataRowView;
            if (r == null) return;

            #region federat
            bool federat_bool = false;
            string federat_str = r.Row.ItemArray[5].ToString();

            booleana_visual(false, ref federat_bool, ref federat_str);
            #endregion

            this.Close();

            #region formulari
            dades formulari = new dades(false, new soci(
                int.Parse(r.Row.ItemArray[0].ToString()),
                r.Row.ItemArray[2].ToString(),
                r.Row.ItemArray[3].ToString(),
                r.Row.ItemArray[1].ToString(),
                federat_bool,
                int.Parse(r.Row.ItemArray[4].ToString())
            ));
            #endregion

            formulari.ShowDialog();
        }

        #region altres
        void booleana_visual(bool totext, ref bool fed, ref string visual)
        {
            if (totext)
            {
                if (fed) visual = "Si";
                else visual = "No";
            }
            else
            {
                if (visual == "Si") fed = true;
                else fed = false;
            }
        }

        #endregion
    }
}
