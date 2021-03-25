using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Side_Scrolling_Platform_Game
{
    public partial class Parametres : Form
    {
        public Parametres()
        {
            InitializeComponent();
        }

        private void cmb_idioma_Validating(object sender, CancelEventArgs e)
        {
            if (cmb_idioma.SelectedIndex == 0)
                cambiar_noms_idiomes(Idiomes.catala);
            else if (cmb_idioma.SelectedIndex == 1)
                cambiar_noms_idiomes(Idiomes.angles);
            else if (cmb_idioma.SelectedIndex == 2)
                cambiar_noms_idiomes(Idiomes.espanyol);
            else if (cmb_idioma.SelectedIndex == 3)
                cambiar_noms_idiomes(Idiomes.italia);
            else if (cmb_idioma.SelectedIndex == 4)
                cambiar_noms_idiomes(Idiomes.rus);
        }
        
        public void cambiar_noms_idiomes(string[] vector)
        {
            lbl_lang.Text = vector[2];
            btn_aplicar.Text = vector[3];
            for (int i = 0; i < cmb_idioma.Items.Count; i++)
                cmb_idioma.Items[i] = vector[i + 4];
        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            Variables.idioma = cmb_idioma.SelectedIndex;
        }
    }
}
