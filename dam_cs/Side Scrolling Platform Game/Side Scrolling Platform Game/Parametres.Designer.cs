namespace Side_Scrolling_Platform_Game
{
    partial class Parametres
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
            this.cmb_idioma = new System.Windows.Forms.ComboBox();
            this.lbl_lang = new System.Windows.Forms.Label();
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_idioma
            // 
            this.cmb_idioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmb_idioma.FormattingEnabled = true;
            this.cmb_idioma.Items.AddRange(new object[] {
            "Catala",
            "Angles",
            "Espanyol",
            "Italià",
            "Rus"});
            this.cmb_idioma.Location = new System.Drawing.Point(12, 36);
            this.cmb_idioma.Name = "cmb_idioma";
            this.cmb_idioma.Size = new System.Drawing.Size(121, 23);
            this.cmb_idioma.TabIndex = 0;
            this.cmb_idioma.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_idioma_Validating);
            // 
            // lbl_lang
            // 
            this.lbl_lang.AutoSize = true;
            this.lbl_lang.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.lbl_lang.Location = new System.Drawing.Point(12, 9);
            this.lbl_lang.Name = "lbl_lang";
            this.lbl_lang.Size = new System.Drawing.Size(57, 24);
            this.lbl_lang.TabIndex = 1;
            this.lbl_lang.Text = "Idioma";
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Location = new System.Drawing.Point(228, 119);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(75, 23);
            this.btn_aplicar.TabIndex = 2;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            this.btn_aplicar.Click += new System.EventHandler(this.btn_aplicar_Click);
            // 
            // Parametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 154);
            this.Controls.Add(this.btn_aplicar);
            this.Controls.Add(this.lbl_lang);
            this.Controls.Add(this.cmb_idioma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Parametres";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_idioma;
        private System.Windows.Forms.Label lbl_lang;
        private System.Windows.Forms.Button btn_aplicar;
    }
}