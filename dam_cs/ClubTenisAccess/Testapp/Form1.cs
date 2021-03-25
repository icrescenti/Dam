using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ClubTenisAccess
{
    public partial class Form1 : Form
    {
        bool validat = false;

        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=clubtenis.accdb");
        
        private void btnInserir_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = con.CreateCommand();
            
            con.Open();

            int federat = 0;
            if (ckFederat.Checked) federat = 1;

            cmd.CommandText = "Insert into socis(numero_soci, nom, cognom, dni, federat)Values(" + txtNumSoci.Text + ",'" + txtNom.Text + "','" + txtCognom.Text + "','" + txtDni.Text + "'," + federat + ")";
            cmd.Connection = con;

            txtNom.Text = txtCognom.Text = txtDni.Text = txtNumSoci.Text = "";
            ckFederat.Checked = false;

            try
            {
                if (validat)
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Dades inserides correctament", "Inserccio");
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Tots els camps han de estar plens avans de inserir la informacio", "Inserccio");
                }
            }
            catch
            {
                con.Close();
                MessageBox.Show("Error, el numero de soci ja existeix", "Error");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM socis";
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, con);
            
            con.Open();
            
            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "socis");
            DataTable dTable = dtSet.Tables[0];
            dataGridView1.DataSource = dtSet.Tables["socis"].DefaultView;

            con.Close();
        }

        private void validacio(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                validat = false;
                MessageBox.Show("Es necessari emplenar aquest camp");
            }
            else validat = true;
        }
    }
}
