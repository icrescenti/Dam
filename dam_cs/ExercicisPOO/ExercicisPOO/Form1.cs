using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicisPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maximnombres_txtbx_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(maximnombres_txtbx.Text, out int x))
            {
                notificacio("Compte! No estem inserin un valor numeric enter com a allargada.", "Error de validacio");
                maximnombres_txtbx.Text = "0";
            }
        }

        private void generar_btn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int maxnums = 0;

            int.TryParse(maximnombres_txtbx.Text, out maxnums);
            resultat_txtbx.Text = "";

            #region generacio de valors
            for (int i = 0;i<maxnums;i++)
            {
                resultat_txtbx.Text += r.Next(1,10) + " ";
            }
            #endregion
        }

        private void guardar_btn_Click(object sender, EventArgs e)
        {
            /*
             * GENERO EL FIXERET EN LA RUTA 
             * ON ES GENERA EL PROGRAMA EN 
             * MODE DE DEBUG PERQUE SIGUI 
             * FACIL DE TROBAR
             * RUTASOLUCIO\ExercicisPOO\bin\Debug\
             */
            using (StreamWriter escriptor = new StreamWriter(Environment.CurrentDirectory + "\\fixeret.txt"))
            {
                escriptor.WriteLine(resultat_txtbx.Text);
                escriptor.Flush();
                escriptor.Close();
                escriptor.Dispose();
            }
            notificacio("Fitxer emmagatzemat en " + Environment.CurrentDirectory + "\\fixeret.txt", "Guardat completat");
        }

        private void llegir_btn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + "\\fixeret.txt"))
            {
                using (StreamReader lector = new StreamReader(Environment.CurrentDirectory + "\\fixeret.txt"))
                {
                    resultat_txtbx.Text = lector.ReadToEnd();
                    lector.Close();
                    lector.Dispose();
                }
            }
            else
            {
                notificacio("El fitxer no existeix", "Error de lectura");
            }
        }

        void notificacio(string missatge, string titol = "")
        {
            MessageBox.Show(missatge, titol);
        }
    }
}
