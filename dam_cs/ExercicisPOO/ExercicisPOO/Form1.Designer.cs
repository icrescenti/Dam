namespace ExercicisPOO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numero_lbl = new System.Windows.Forms.Label();
            this.maximnombres_txtbx = new System.Windows.Forms.TextBox();
            this.resultat_txtbx = new System.Windows.Forms.TextBox();
            this.generar_btn = new System.Windows.Forms.Button();
            this.guardar_btn = new System.Windows.Forms.Button();
            this.llegir_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numero_lbl
            // 
            this.numero_lbl.AutoSize = true;
            this.numero_lbl.Location = new System.Drawing.Point(49, 34);
            this.numero_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numero_lbl.Name = "numero_lbl";
            this.numero_lbl.Size = new System.Drawing.Size(58, 17);
            this.numero_lbl.TabIndex = 0;
            this.numero_lbl.Text = "Numero";
            // 
            // maximnombres_txtbx
            // 
            this.maximnombres_txtbx.Location = new System.Drawing.Point(140, 31);
            this.maximnombres_txtbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maximnombres_txtbx.Name = "maximnombres_txtbx";
            this.maximnombres_txtbx.Size = new System.Drawing.Size(132, 22);
            this.maximnombres_txtbx.TabIndex = 1;
            this.maximnombres_txtbx.Validating += new System.ComponentModel.CancelEventHandler(this.maximnombres_txtbx_Validating);
            // 
            // resultat_txtbx
            // 
            this.resultat_txtbx.Location = new System.Drawing.Point(28, 75);
            this.resultat_txtbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultat_txtbx.Multiline = true;
            this.resultat_txtbx.Name = "resultat_txtbx";
            this.resultat_txtbx.ReadOnly = true;
            this.resultat_txtbx.Size = new System.Drawing.Size(273, 141);
            this.resultat_txtbx.TabIndex = 2;
            // 
            // generar_btn
            // 
            this.generar_btn.Location = new System.Drawing.Point(8, 235);
            this.generar_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.generar_btn.Name = "generar_btn";
            this.generar_btn.Size = new System.Drawing.Size(100, 28);
            this.generar_btn.TabIndex = 3;
            this.generar_btn.Text = "Generar";
            this.generar_btn.UseVisualStyleBackColor = true;
            this.generar_btn.Click += new System.EventHandler(this.generar_btn_Click);
            // 
            // guardar_btn
            // 
            this.guardar_btn.Location = new System.Drawing.Point(116, 235);
            this.guardar_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guardar_btn.Name = "guardar_btn";
            this.guardar_btn.Size = new System.Drawing.Size(100, 28);
            this.guardar_btn.TabIndex = 4;
            this.guardar_btn.Text = "Guardar";
            this.guardar_btn.UseVisualStyleBackColor = true;
            this.guardar_btn.Click += new System.EventHandler(this.guardar_btn_Click);
            // 
            // llegir_btn
            // 
            this.llegir_btn.Location = new System.Drawing.Point(224, 235);
            this.llegir_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.llegir_btn.Name = "llegir_btn";
            this.llegir_btn.Size = new System.Drawing.Size(100, 28);
            this.llegir_btn.TabIndex = 5;
            this.llegir_btn.Text = "Llegir";
            this.llegir_btn.UseVisualStyleBackColor = true;
            this.llegir_btn.Click += new System.EventHandler(this.llegir_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 278);
            this.Controls.Add(this.llegir_btn);
            this.Controls.Add(this.guardar_btn);
            this.Controls.Add(this.generar_btn);
            this.Controls.Add(this.resultat_txtbx);
            this.Controls.Add(this.maximnombres_txtbx);
            this.Controls.Add(this.numero_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exercici 7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numero_lbl;
        private System.Windows.Forms.TextBox maximnombres_txtbx;
        private System.Windows.Forms.TextBox resultat_txtbx;
        private System.Windows.Forms.Button generar_btn;
        private System.Windows.Forms.Button guardar_btn;
        private System.Windows.Forms.Button llegir_btn;
    }
}