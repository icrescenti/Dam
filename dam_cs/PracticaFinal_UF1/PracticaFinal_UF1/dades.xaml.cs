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
using Microsoft.Office.Interop.Excel;

namespace PracticaFinal_UF1
{
    public partial class dades : System.Windows.Window
    {
        bool registrar;
        public dades(bool arg0, soci cli)
        {
            registrar = arg0;
            InitializeComponent();

            if (registrar)
            {
                lbl_titol.Content = "Registrat com a usuari";
                tb_edat.Visibility = Visibility.Hidden;
                btn_exportar.Visibility = Visibility.Hidden;
                btn_exportarSocis.Visibility = Visibility.Hidden;
            }
            else
            {
                dpk_data.Visibility = Visibility.Hidden;
                lbl_infoquota.Visibility = Visibility.Visible;
                lbl_quota.Visibility = Visibility.Visible;

                #region carrega de valors
                lbl_titol.Content = "Informació de: " + cli.nom + " " + cli.cognoms;

                tb_nom.Text = cli.nom;
                tb_Cognoms.Text = cli.cognoms;
                tb_DNI.Text = cli.dni;
                tb_edat.Text = cli.edat.ToString();

                if (cli.federat)
                    rb_si.IsChecked = true;
                else rb_no.IsChecked = true;
                #endregion

                #region desactivacio de controls
                tb_nom.IsReadOnly = true;
                tb_Cognoms.IsReadOnly = true;
                tb_DNI.IsReadOnly = true;
                tb_edat.IsReadOnly = true;

                rb_si.IsEnabled = false;
                rb_no.IsEnabled = false;
                #endregion

                lbl_quota.Content = Calcs.quota(cli.edat, cli.federat) + "€/mes";
            }
        }

        private void btn_acceptar_Click(object sender, RoutedEventArgs e)
        {
            bool validat = true;
            if (registrar)
            {
                Club club = Serialitzacio.Llegir("crimsondawndb.xml");
                soci[] clis;
                int id = -1;

                if (club != null)
                {
                    id = club.socis[club.socis.Length - 1].numeroSoci;
                    clis = club.socis;
                }
                else
                {
                    club = new Club();
                    clis = new soci[0];
                }

                Array.Resize(ref clis, clis.Length + 1);

                clis[clis.Length - 1] = new soci(
                    id + 1,
                    tb_nom.Text,
                    tb_Cognoms.Text,
                    tb_DNI.Text,
                    (bool)rb_si.IsChecked,
                    Calcs.edat(dpk_data.DisplayDate)
                );

                club.socis = clis;

                validat = validacio();
                if (validat)
                {
                    Serialitzacio.Guardar(club, "crimsondawndb.xml");
                    notificacio.mostrar(false, "Soci enregistrat", "Has enregistrat el soci correctament");
                }
                else
                    notificacio.mostrar(true, "Informació incorrectes", "Emplena tots els camps obligatoris per enregistrar el usuari.");
            }
            if (validat)
                this.Close();
        }

        bool validacio()
        {
            if (String.IsNullOrEmpty(tb_nom.Text) ||
                String.IsNullOrEmpty(tb_DNI.Text) || 
                String.IsNullOrEmpty(tb_Cognoms.Text) ||
                String.IsNullOrEmpty(dpk_data.Text))
            {
                return false;
            }
            return true;
        }

        private void btn_exportar_Click(object sender, RoutedEventArgs e)
        {
            DateTime ara = DateTime.Now;

            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                app.WindowState = XlWindowState.xlMaximized;

                Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet taula = wb.Worksheets[1];

                string[] columnes = { "Data", "Nom", "Cognoms", "DNI", "Edat", "Federat", "Quota", "Quantitat Abonada" };

                for (int i = 1; i <= columnes.Length; i++)
                {
                    taula.Cells[1, i].Value = columnes[i - 1];
                    taula.Cells[1, i].Style.Font.Size = 20;
                }

                taula.Cells[2, 1].Value = ara.Day.ToString() + "/" + ara.Month.ToString() + "/" + ara.Year.ToString();
                taula.Cells[2, 2].Value = tb_nom.Text;
                taula.Cells[2, 3].Value = tb_Cognoms.Text;
                taula.Cells[2, 4].Value = tb_DNI.Text;
                taula.Cells[2, 5].Value = tb_edat.Text;
                taula.Cells[2, 6].Value = rb_si.IsChecked;
                taula.Cells[2, 7].Value = lbl_quota.Content;
                taula.Cells[2, 8].Value = "0€";

                taula.Range["A1:H2"].Columns.AutoFit();
                taula.Range["A1:H2"].Cells.HorizontalAlignment =
                     Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                string fitxer = Environment.CurrentDirectory + "/reporte_" + ara.Year.ToString() + ara.Month.ToString() + ara.Day.ToString() + ara.Hour.ToString() + ara.Minute.ToString() + ara.Second.ToString() + ara.Millisecond.ToString() + ".xlsx";

                wb.SaveAs(fitxer);
            } catch { notificacio.mostrar(true, "Error", "No es pot generar correctament el fitxer excel, comprova a tenir una llicencia valida de Office"); }
        }

        private void btn_exportarSocis_Click(object sender, RoutedEventArgs e)
        {
            DateTime ara = DateTime.Now;

            try
            {
                #region  lectura de fitxer
                Club club = Serialitzacio.Llegir("crimsondawndb.xml");
                #endregion

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                app.WindowState = XlWindowState.xlMaximized;

                Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet taula = wb.Worksheets[1];

                string[] columnes = { "Data", "Nom", "Cognoms", "DNI", "Edat", "Federat", "Quota", "Quantitat Abonada" };

                for (int i = 1; i <= columnes.Length; i++)
                {
                    taula.Cells[1, i].Value = columnes[i - 1];
                    taula.Cells[1, i].Style.Font.Size = 20;
                }

                int x = 0;
                for (int i = 2; i < (club.socis.Length+2); i++)
                {
                    soci cli = club.socis[i - 2];

                    taula.Cells[i, 1].Value = ara.Day.ToString() + "/" + ara.Month.ToString() + "/" + ara.Year.ToString();
                    taula.Cells[i, 2].Value = cli.nom;
                    taula.Cells[i, 3].Value = cli.cognoms;
                    taula.Cells[i, 4].Value = cli.dni;
                    taula.Cells[i, 5].Value = cli.edat;
                    taula.Cells[i, 6].Value = cli.federat;
                    taula.Cells[i, 7].Value = Calcs.quota(cli.edat, cli.federat);
                    taula.Cells[i, 8].Value = "0€";
                }

                taula.Cells[club.socis.Length+2, 1].Value = "Total:";
                taula.Cells[club.socis.Length+2, 7].Value = "=SUM(G2:G" + (club.socis.Length+1) + ")";
                
                taula.Range["A1:H" + club.socis.Length+2].Columns.AutoFit();
                taula.Range["A1:H" + club.socis.Length+2].Cells.HorizontalAlignment =
                     Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                string fitxer = Environment.CurrentDirectory + "/reporte_" + ara.Year.ToString() + ara.Month.ToString() + ara.Day.ToString() + ara.Hour.ToString() + ara.Minute.ToString() + ara.Second.ToString() + ara.Millisecond.ToString() + ".xlsx";

                wb.SaveAs(fitxer);
            }
            catch { notificacio.mostrar(true, "Error", "No es pot generar correctament el fitxer excel, comprova a tenir una llicencia valida de Office"); }
        }
    }
}
