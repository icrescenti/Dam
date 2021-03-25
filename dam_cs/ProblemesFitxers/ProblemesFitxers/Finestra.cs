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

namespace ProblemesFitxers
{
    public partial class Finestra : Form
    {
        public Finestra()
        {
            InitializeComponent();
        }

        private void btn_obrirfitxer_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscador_fitxer = new OpenFileDialog();
            buscador_fitxer.InitialDirectory = Environment.CurrentDirectory;
            buscador_fitxer.Filter = "Fixerets de texte (*.txt)|*.txt";
            buscador_fitxer.RestoreDirectory = true;

            if (buscador_fitxer.ShowDialog() == DialogResult.OK)
            {
                int[] numeros = new int[0];
                int mitjana = 0;

                int i = 0;
                using (StreamReader lector = new StreamReader(buscador_fitxer.FileName))
                {
                    while (lector.Peek() > -1)
                    {
                        Array.Resize(ref numeros, numeros.Length+1);
                        int.TryParse(lector.ReadLine(), out numeros[i++]);
                    }
                }
                txt_mitajana.Text = "La mitjana de ";
                for (i = 0; i < numeros.Length; i++)
                {
                    mitjana += numeros[i];
                    txt_mitajana.Text += (numeros[i] + " ");
                }
                txt_mitajana.Text += ("es " + (float)mitjana/numeros.Length);
            }
        }
    }
}
