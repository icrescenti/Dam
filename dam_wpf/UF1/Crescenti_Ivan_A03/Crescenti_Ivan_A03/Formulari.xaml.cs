using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
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

namespace Crescenti_Ivan_A03
{
    /// <summary>
    /// Implementacions realitzades
    /// <para>
    /// Robustesa de l'applicació millorada<br/>
    /// Noms adients a els controls<br/>
    /// TabIndex assignats properament<br/>
    /// La resoulció no es adaptativa ni es pot cambiar<br/>
    /// Codi documentat<br/>
    /// Sorolls per a els botons<br/>
    /// Sistema de guardar/carregar informacio<br/>
    /// </para>
    /// </summary>
    public partial class Formulari : Window
    {
        #region Inicialitzacio
        public Formulari()
        {
            InitializeComponent();
            lstbx_centres.SelectedIndex =
            cmb_horaris.SelectedIndex =
            cmb_sexe.SelectedIndex = 0;
            dta_datanaix.SelectedDate = DateTime.Now;
        }

        private void Finestra0_Loaded(object sender, RoutedEventArgs e)
        {
            #region carrega d'informacio inicial
            Reserva res_obj = new Reserva();
            res_obj.Deserialitzar(Environment.CurrentDirectory);

            cmb_horaris.SelectedItem = res_obj.DataReserva;

            txtbx_nom.Text = res_obj.Nom;
            txtbx_cognom.Text = res_obj.Cognom;
            txtbx_email.Text = res_obj.Email;
            txtbx_telefon.Text = res_obj.Telefon;

            txtbx_comentaris.Text = res_obj.Comentaris;
            lstbx_centres.SelectedItem = res_obj.Centre;
            ckx_protecciodades.IsChecked = res_obj.AcceptaCondicions;
            #endregion
        }
        #endregion

        #region funcions
        public void netejar()
        {
            #region NETEJEM LES DADES ACTUALS I REINICIALITZEM ELS VALORS DE ELS DESPLEGABLES
            txtbx_cognom.Text =
            txtbx_comentaris.Text =
            txtbx_email.Text =
            txtbx_nom.Text =
            txtbx_telefon.Text =
            String.Empty;
            cmb_horaris.SelectedIndex =
            cmb_sexe.SelectedIndex =
            lstbx_centres.SelectedIndex =
            0;
            #endregion
        }

        public bool validacio(ref Reserva r)
        {
            r.DataReserva = DateTime.Now;
            
            //VALORS INCECESSARIS
            r.HoraReserva = 0;
            r.MinutsReserva = 0;
            r.Comensals = 0;

            if (txtbx_nom.Text != String.Empty) r.Nom = txtbx_nom.Text; else return false;
            if (txtbx_cognom.Text != String.Empty) r.Cognom = txtbx_cognom.Text; else return false;
            if (txtbx_email.Text != String.Empty) r.Email = txtbx_email.Text; else return false;

            #region validacio de telefon
            long telf_num = 0;

            if (long.TryParse(txtbx_telefon.Text.Replace("+", ""), out telf_num) && telf_num.ToString().Length<12)
            {
                char[] numeros = txtbx_telefon.Text.Replace("+", "").ToCharArray();
                
                r.Telefon = String.Format("{0}{1} {2}{3}{4} {5}{6}{7} {8}{9}{10}", Formatar(numeros, 11));
            }
            else
            {
                Altres.notficiacio("Numero de telefon invalid!", "Error en les dades");
                return false;
            }
            #endregion

            return true;
        }

        public void reservar()
        {
            Reserva res_obj = new Reserva();

            if (validacio(ref res_obj))
            {
                res_obj.Comentaris = txtbx_comentaris.Text;
                res_obj.Centre = ((ListBoxItem)lstbx_centres.SelectedItem).Content.ToString();
                res_obj.AcceptaCondicions = (bool)ckx_protecciodades.IsChecked;

                //GRABEM LA INFORMACIÓ
                res_obj.Seritalitzar(Environment.CurrentDirectory);
            }
            else
            {
                Altres.notficiacio("La informació proporcionada no es correcte");
            }
        }
        #endregion

        #region botons
        private void btn_netejar_Click(object sender, RoutedEventArgs e)
        {
            string ruta = Environment.CurrentDirectory + "/data/netejar.wav";

            executarsoroll(ruta);
            netejar();
        }

        private void btn_reservar_Click(object sender, RoutedEventArgs e)
        {
            string ruta = Environment.CurrentDirectory + "/data/reservar.wav";

            executarsoroll(ruta);
            reservar();
        }
        #endregion

        #region altres
        public string[] Formatar(char[] vector_chars, int quantitatobjectes)
        {
            string[] vector_string = new string[quantitatobjectes];

            for (int i = 0; i < vector_chars.Length; i++)
                vector_string[i] = vector_chars[i].ToString();

            return vector_string;
        }
        void executarsoroll(string ruta)
        {
            if (File.Exists(ruta))
            {
                SoundPlayer soroll = new SoundPlayer(ruta);
                soroll.Play();
            }
        }
        #endregion
    }
}
