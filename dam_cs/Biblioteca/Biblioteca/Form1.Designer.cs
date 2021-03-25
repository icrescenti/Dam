
namespace Biblioteca
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProvaConex = new System.Windows.Forms.Button();
            this.lblEstat = new System.Windows.Forms.Label();
            this.btnAltaLlibre = new System.Windows.Forms.Button();
            this.btnModLlibre = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConsultaLibros = new System.Windows.Forms.Button();
            this.btnConsultarConUnidades = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProvaConex
            // 
            this.btnProvaConex.Location = new System.Drawing.Point(25, 23);
            this.btnProvaConex.Name = "btnProvaConex";
            this.btnProvaConex.Size = new System.Drawing.Size(109, 36);
            this.btnProvaConex.TabIndex = 0;
            this.btnProvaConex.Text = "Provar Conexio";
            this.btnProvaConex.UseVisualStyleBackColor = true;
            this.btnProvaConex.Click += new System.EventHandler(this.btnProvaConex_Click);
            // 
            // lblEstat
            // 
            this.lblEstat.AutoSize = true;
            this.lblEstat.Location = new System.Drawing.Point(140, 35);
            this.lblEstat.Name = "lblEstat";
            this.lblEstat.Size = new System.Drawing.Size(0, 13);
            this.lblEstat.TabIndex = 1;
            // 
            // btnAltaLlibre
            // 
            this.btnAltaLlibre.Location = new System.Drawing.Point(25, 65);
            this.btnAltaLlibre.Name = "btnAltaLlibre";
            this.btnAltaLlibre.Size = new System.Drawing.Size(109, 36);
            this.btnAltaLlibre.TabIndex = 2;
            this.btnAltaLlibre.Text = "Alta Llibre";
            this.btnAltaLlibre.UseVisualStyleBackColor = true;
            this.btnAltaLlibre.Click += new System.EventHandler(this.btnAltaLlibre_Click);
            // 
            // btnModLlibre
            // 
            this.btnModLlibre.Location = new System.Drawing.Point(25, 107);
            this.btnModLlibre.Name = "btnModLlibre";
            this.btnModLlibre.Size = new System.Drawing.Size(109, 36);
            this.btnModLlibre.TabIndex = 3;
            this.btnModLlibre.Text = "Modificacio de Llibre";
            this.btnModLlibre.UseVisualStyleBackColor = true;
            this.btnModLlibre.Click += new System.EventHandler(this.btnModLlibre_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(25, 149);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 36);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar Llibre";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(615, 250);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnConsultaLibros
            // 
            this.btnConsultaLibros.Location = new System.Drawing.Point(531, 23);
            this.btnConsultaLibros.Name = "btnConsultaLibros";
            this.btnConsultaLibros.Size = new System.Drawing.Size(109, 36);
            this.btnConsultaLibros.TabIndex = 6;
            this.btnConsultaLibros.Text = "Consulta de Llibres";
            this.btnConsultaLibros.UseVisualStyleBackColor = true;
            this.btnConsultaLibros.Click += new System.EventHandler(this.btnConsultaLibros_Click);
            // 
            // btnConsultarConUnidades
            // 
            this.btnConsultarConUnidades.Location = new System.Drawing.Point(531, 65);
            this.btnConsultarConUnidades.Name = "btnConsultarConUnidades";
            this.btnConsultarConUnidades.Size = new System.Drawing.Size(109, 49);
            this.btnConsultarConUnidades.TabIndex = 7;
            this.btnConsultarConUnidades.Text = "Consulta de Llibres amb Unitats";
            this.btnConsultarConUnidades.UseVisualStyleBackColor = true;
            this.btnConsultarConUnidades.Click += new System.EventHandler(this.btnConsultarConUnidades_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 473);
            this.Controls.Add(this.btnConsultarConUnidades);
            this.Controls.Add(this.btnConsultaLibros);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModLlibre);
            this.Controls.Add(this.btnAltaLlibre);
            this.Controls.Add(this.lblEstat);
            this.Controls.Add(this.btnProvaConex);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProvaConex;
        private System.Windows.Forms.Label lblEstat;
        private System.Windows.Forms.Button btnAltaLlibre;
        private System.Windows.Forms.Button btnModLlibre;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConsultaLibros;
        private System.Windows.Forms.Button btnConsultarConUnidades;
    }
}

