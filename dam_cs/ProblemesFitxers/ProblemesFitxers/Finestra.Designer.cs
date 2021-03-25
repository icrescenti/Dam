namespace ProblemesFitxers
{
    partial class Finestra
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
            this.txt_mitajana = new System.Windows.Forms.TextBox();
            this.btn_obrirfitxer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_mitajana
            // 
            this.txt_mitajana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mitajana.Location = new System.Drawing.Point(12, 12);
            this.txt_mitajana.Multiline = true;
            this.txt_mitajana.Name = "txt_mitajana";
            this.txt_mitajana.ReadOnly = true;
            this.txt_mitajana.Size = new System.Drawing.Size(236, 129);
            this.txt_mitajana.TabIndex = 0;
            // 
            // btn_obrirfitxer
            // 
            this.btn_obrirfitxer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_obrirfitxer.Location = new System.Drawing.Point(173, 147);
            this.btn_obrirfitxer.Name = "btn_obrirfitxer";
            this.btn_obrirfitxer.Size = new System.Drawing.Size(75, 23);
            this.btn_obrirfitxer.TabIndex = 1;
            this.btn_obrirfitxer.Text = "Obrir";
            this.btn_obrirfitxer.UseVisualStyleBackColor = true;
            this.btn_obrirfitxer.Click += new System.EventHandler(this.btn_obrirfitxer_Click);
            // 
            // Finestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 182);
            this.Controls.Add(this.btn_obrirfitxer);
            this.Controls.Add(this.txt_mitajana);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Finestra";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finestra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mitajana;
        private System.Windows.Forms.Button btn_obrirfitxer;
    }
}