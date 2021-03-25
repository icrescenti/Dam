using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace ClubTenisUI
{
	public class Form1 : Form
	{
        #region variables
        private int IDe = 0;

		private SQLiteConnection conn;
		private SQLiteCommand sql_cmd;
		private SQLiteDataAdapter DB;
		#endregion

		#region diseny
		private DataGrid Grid;
		private TextBox txtNom;
		private Button btnDel;
		private Button btnAdd;
		private Button btnNew;
		private Button btnEdit;
		
		private DataSet dSet = new DataSet();
		private DataTable dTaula = new DataTable();
        private CheckBox ckFederat;
        private TextBox txtCognom;
        private TextBox txtDni;
        private Label label1;
        private TextBox txtResultats;
        private Button btnActualitzar;
        private Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.Grid = new System.Windows.Forms.DataGrid();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ckFederat = new System.Windows.Forms.CheckBox();
            this.txtCognom = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultats = new System.Windows.Forms.TextBox();
            this.btnActualitzar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.BackColor = System.Drawing.Color.Gainsboro;
            this.Grid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Grid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Grid.CaptionForeColor = System.Drawing.Color.Black;
            this.Grid.DataMember = "";
            this.Grid.FlatMode = true;
            this.Grid.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Grid.ForeColor = System.Drawing.Color.Black;
            this.Grid.GridLineColor = System.Drawing.Color.Silver;
            this.Grid.HeaderBackColor = System.Drawing.Color.Black;
            this.Grid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Grid.HeaderForeColor = System.Drawing.Color.White;
            this.Grid.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.Grid.Location = new System.Drawing.Point(9, 9);
            this.Grid.Margin = new System.Windows.Forms.Padding(0);
            this.Grid.Name = "Grid";
            this.Grid.ParentRowsBackColor = System.Drawing.Color.LightGray;
            this.Grid.ParentRowsForeColor = System.Drawing.Color.Black;
            this.Grid.PreferredColumnWidth = 120;
            this.Grid.PreferredRowHeight = 25;
            this.Grid.ReadOnly = true;
            this.Grid.SelectionBackColor = System.Drawing.Color.Firebrick;
            this.Grid.SelectionForeColor = System.Drawing.Color.White;
            this.Grid.Size = new System.Drawing.Size(556, 291);
            this.Grid.TabIndex = 0;
            this.Grid.Click += new System.EventHandler(this.Grid_Click);
            // 
            // txtNom
            // 
            this.txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(12, 312);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(90, 25);
            this.txtNom.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(156, 343);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 23);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(60, 343);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 343);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(42, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(108, 343);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ckFederat
            // 
            this.ckFederat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckFederat.AutoSize = true;
            this.ckFederat.Enabled = false;
            this.ckFederat.Location = new System.Drawing.Point(300, 314);
            this.ckFederat.Name = "ckFederat";
            this.ckFederat.Size = new System.Drawing.Size(62, 17);
            this.ckFederat.TabIndex = 4;
            this.ckFederat.Text = "Federat";
            this.ckFederat.UseVisualStyleBackColor = true;
            // 
            // txtCognom
            // 
            this.txtCognom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCognom.Enabled = false;
            this.txtCognom.Location = new System.Drawing.Point(108, 312);
            this.txtCognom.Multiline = true;
            this.txtCognom.Name = "txtCognom";
            this.txtCognom.Size = new System.Drawing.Size(90, 25);
            this.txtCognom.TabIndex = 2;
            // 
            // txtDni
            // 
            this.txtDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDni.Enabled = false;
            this.txtDni.Location = new System.Drawing.Point(204, 312);
            this.txtDni.Multiline = true;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(90, 25);
            this.txtDni.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Numero de resultats";
            // 
            // txtResultats
            // 
            this.txtResultats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultats.Location = new System.Drawing.Point(571, 25);
            this.txtResultats.Name = "txtResultats";
            this.txtResultats.Size = new System.Drawing.Size(98, 20);
            this.txtResultats.TabIndex = 9;
            this.txtResultats.Text = "1000";
            this.txtResultats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnActualitzar
            // 
            this.btnActualitzar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualitzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.55F);
            this.btnActualitzar.Location = new System.Drawing.Point(627, 331);
            this.btnActualitzar.Name = "btnActualitzar";
            this.btnActualitzar.Size = new System.Drawing.Size(37, 35);
            this.btnActualitzar.TabIndex = 10;
            this.btnActualitzar.Text = "R";
            this.btnActualitzar.Click += new System.EventHandler(this.btnActualitzar_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(676, 378);
            this.Controls.Add(this.btnActualitzar);
            this.Controls.Add(this.txtResultats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtCognom);
            this.Controls.Add(this.ckFederat);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.Grid);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor del club de tenis";
            this.Load += new System.EventHandler(this.Carregar);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#endregion

		#region funcionalitat
		private void Inicialitzar()
		{
			bool nou = true;
			string dbruta = "clubtenis.db";

            if (File.Exists(dbruta))
                nou = false;

			conn = new SQLiteConnection("Data Source=" + dbruta + ";Version=3;New=" + nou + ";Compress=True;");
		    
            if (nou) ExecSQL(File.ReadAllText("sentences/creacio.sql"));
        }

		private void ExecQuery(string taula = "socis")
		{
            int resultats = 1000;
            int.TryParse(txtResultats.Text, out resultats);

            conn.Open();

			sql_cmd = conn.CreateCommand();
			string cmd = "select * from " + taula + " LIMIT " + resultats + ";";
			DB = new SQLiteDataAdapter(cmd, conn);
            dSet.Reset();
			DB.Fill(dSet);
			dTaula= dSet.Tables[0];
			Grid.DataSource = dTaula;

			conn.Close();
		}
        
		private void ExecSQL(string qry)
		{
			conn.Open();
			sql_cmd = conn.CreateCommand();
			sql_cmd.CommandText = qry;
			sql_cmd.ExecuteNonQuery();
			conn.Close();
		}

		private void AfegirFila(string taula = "socis")
		{
            int federat = 0;
            if (ckFederat.Checked)
                federat = 1;

            string cmd = "insert into " + taula + " (nom,cognom,dni,federat) values (\""+ txtNom.Text +"\", \"" + txtCognom.Text + "\", \"" + txtDni.Text + "\", " + federat + ")";
		    ExecSQL(cmd);
		}

		private void Eliminar(string taula = "socis")
		{
			string cmd = "delete from " + taula + " where numero_soci = " + IDe;
			ExecSQL(cmd);
			
            txtNom.Text = string.Empty;
            txtCognom.Text = string.Empty;
            txtDni.Text = string.Empty;
            ckFederat.Checked = false;
		}
		
		private void Editar(string taula = "socis")
		{
            int federat = 0;
            if (ckFederat.Checked) federat = 1;

			string cmd = 
                "update " + taula + 
                " set nom = \"" + txtNom.Text + "\"," +
                " cognom = \"" + txtCognom.Text + "\"," +
                " dni = \"" + txtDni.Text + "\"," +
                " federat = " + federat +
                " where numero_soci = " + IDe + ";";
			ExecSQL(cmd);
		}

        private void InvControls()
        {
            txtNom.Enabled = !txtNom.Enabled;
            txtCognom.Enabled = !txtCognom.Enabled;
            txtDni.Enabled = !txtDni.Enabled;
            ckFederat.Enabled = !ckFederat.Enabled;
        }


        #region events
        private void Carregar(object sender, EventArgs e)
		{
			Inicialitzar();
			ExecQuery();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AfegirFila();
			ExecQuery();
			btnAdd.Enabled = false;
			btnNew.Enabled = true;
			btnEdit.Enabled = false;

			txtNom.Text = string.Empty;
            txtCognom.Text = string.Empty;
            txtDni.Text = string.Empty;
            ckFederat.Checked = false;

            InvControls();
        }

		private void btnNew_Click(object sender, EventArgs e)
		{
			btnAdd.Enabled = true;
			btnDel.Enabled = false;
			btnNew.Enabled = false;
			btnEdit.Enabled = false;

            InvControls();

            txtNom.Text = string.Empty;
            txtCognom.Text = string.Empty;
            txtDni.Text = string.Empty;
            ckFederat.Checked = false;
        }

		private void Grid_Click(object sender, EventArgs e)
		{
            try
            {
                IDe = Convert.ToInt32(dTaula.Rows[Grid.CurrentRowIndex]["numero_soci"]);
            } 
            catch { MessageBox.Show("No hi ha cap registre el la taula!" , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

			btnDel.Enabled = true;
			btnEdit.Enabled = true;
			txtNom.Text = dTaula.Rows[Grid.CurrentCell.RowNumber]["nom"].ToString();
			txtCognom.Text = dTaula.Rows[Grid.CurrentCell.RowNumber]["cognom"].ToString();
			txtDni.Text = dTaula.Rows[Grid.CurrentCell.RowNumber]["dni"].ToString();
            
            if (!txtNom.Enabled) InvControls();
        }

		private void btnDel_Click(object sender, EventArgs e)
		{
			Eliminar();
			ExecQuery();
        }

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Editar();
			ExecQuery();
            InvControls();
        }

        private void btnActualitzar_Click(object sender, EventArgs e)
        {
            ExecQuery();
        }

        #endregion

        #endregion
    }
}
