namespace Snake_M17
{
    partial class pantallaJoc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pantallaJoc));
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.lblPunts = new System.Windows.Forms.Label();
            this.lblPuntuacio = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_dificultat = new System.Windows.Forms.ComboBox();
            this.btn_comencar = new System.Windows.Forms.Button();
            this.menuOpcions = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarHacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortirDeElJocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarElSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarElSistemaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_musica = new System.Windows.Forms.CheckBox();
            this.lbl_jocpausa = new System.Windows.Forms.Label();
            this.rad_fleches = new System.Windows.Forms.RadioButton();
            this.lbl_controls = new System.Windows.Forms.Label();
            this.rad_wsad = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.menuOpcions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(12, 37);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(408, 297);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // lblPunts
            // 
            this.lblPunts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPunts.AutoSize = true;
            this.lblPunts.BackColor = System.Drawing.Color.Transparent;
            this.lblPunts.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunts.ForeColor = System.Drawing.Color.White;
            this.lblPunts.Location = new System.Drawing.Point(435, 65);
            this.lblPunts.Name = "lblPunts";
            this.lblPunts.Size = new System.Drawing.Size(20, 24);
            this.lblPunts.TabIndex = 1;
            this.lblPunts.Text = "0";
            // 
            // lblPuntuacio
            // 
            this.lblPuntuacio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPuntuacio.AutoSize = true;
            this.lblPuntuacio.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntuacio.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntuacio.ForeColor = System.Drawing.Color.White;
            this.lblPuntuacio.Location = new System.Drawing.Point(426, 37);
            this.lblPuntuacio.Name = "lblPuntuacio";
            this.lblPuntuacio.Size = new System.Drawing.Size(108, 28);
            this.lblPuntuacio.TabIndex = 2;
            this.lblPuntuacio.Text = "Puntuacio";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(426, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dificultat";
            // 
            // cmb_dificultat
            // 
            this.cmb_dificultat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_dificultat.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F);
            this.cmb_dificultat.FormattingEnabled = true;
            this.cmb_dificultat.Items.AddRange(new object[] {
            "Facil",
            "Mitja",
            "Dificil",
            "Infernal",
            "Lindo Mexico",
            "Estrella de la Muerte"});
            this.cmb_dificultat.Location = new System.Drawing.Point(431, 135);
            this.cmb_dificultat.Name = "cmb_dificultat";
            this.cmb_dificultat.Size = new System.Drawing.Size(173, 25);
            this.cmb_dificultat.TabIndex = 4;
            this.cmb_dificultat.TabStop = false;
            // 
            // btn_comencar
            // 
            this.btn_comencar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_comencar.Location = new System.Drawing.Point(514, 301);
            this.btn_comencar.Name = "btn_comencar";
            this.btn_comencar.Size = new System.Drawing.Size(108, 33);
            this.btn_comencar.TabIndex = 5;
            this.btn_comencar.Text = "Videojugar!";
            this.btn_comencar.UseVisualStyleBackColor = true;
            this.btn_comencar.Click += new System.EventHandler(this.btn_comencar_Click);
            // 
            // menuOpcions
            // 
            this.menuOpcions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuOpcions.Location = new System.Drawing.Point(0, 0);
            this.menuOpcions.Name = "menuOpcions";
            this.menuOpcions.Size = new System.Drawing.Size(634, 24);
            this.menuOpcions.TabIndex = 6;
            this.menuOpcions.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarHacksToolStripMenuItem,
            this.sortirDeElJocToolStripMenuItem,
            this.apagarElSistemaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.archivoToolStripMenuItem.Text = "Fitxer";
            // 
            // activarHacksToolStripMenuItem
            // 
            this.activarHacksToolStripMenuItem.CheckOnClick = true;
            this.activarHacksToolStripMenuItem.Name = "activarHacksToolStripMenuItem";
            this.activarHacksToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.activarHacksToolStripMenuItem.Text = "Activar Hacks";
            this.activarHacksToolStripMenuItem.Click += new System.EventHandler(this.activarHacksToolStripMenuItem_Click);
            // 
            // sortirDeElJocToolStripMenuItem
            // 
            this.sortirDeElJocToolStripMenuItem.Name = "sortirDeElJocToolStripMenuItem";
            this.sortirDeElJocToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.sortirDeElJocToolStripMenuItem.Text = "Sortir de el joc";
            this.sortirDeElJocToolStripMenuItem.Click += new System.EventHandler(this.sortirDeElJocToolStripMenuItem_Click);
            // 
            // apagarElSistemaToolStripMenuItem
            // 
            this.apagarElSistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarElSistemaToolStripMenuItem1});
            this.apagarElSistemaToolStripMenuItem.Name = "apagarElSistemaToolStripMenuItem";
            this.apagarElSistemaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.apagarElSistemaToolStripMenuItem.Text = "Ragequit";
            // 
            // apagarElSistemaToolStripMenuItem1
            // 
            this.apagarElSistemaToolStripMenuItem1.Name = "apagarElSistemaToolStripMenuItem1";
            this.apagarElSistemaToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.apagarElSistemaToolStripMenuItem1.Text = "Apagar el Sistema";
            this.apagarElSistemaToolStripMenuItem1.Click += new System.EventHandler(this.apagarElSistemaToolStripMenuItem1_Click);
            // 
            // chk_musica
            // 
            this.chk_musica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_musica.AutoSize = true;
            this.chk_musica.BackColor = System.Drawing.Color.Transparent;
            this.chk_musica.Font = new System.Drawing.Font("MV Boli", 10.25F);
            this.chk_musica.ForeColor = System.Drawing.Color.White;
            this.chk_musica.Location = new System.Drawing.Point(431, 166);
            this.chk_musica.Name = "chk_musica";
            this.chk_musica.Size = new System.Drawing.Size(71, 22);
            this.chk_musica.TabIndex = 7;
            this.chk_musica.Text = "Musica";
            this.chk_musica.UseVisualStyleBackColor = false;
            // 
            // lbl_jocpausa
            // 
            this.lbl_jocpausa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_jocpausa.AutoSize = true;
            this.lbl_jocpausa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_jocpausa.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_jocpausa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_jocpausa.Location = new System.Drawing.Point(202, 52);
            this.lbl_jocpausa.Name = "lbl_jocpausa";
            this.lbl_jocpausa.Size = new System.Drawing.Size(205, 27);
            this.lbl_jocpausa.TabIndex = 8;
            this.lbl_jocpausa.Text = "JOC EN PAUSA";
            this.lbl_jocpausa.Visible = false;
            // 
            // rad_fleches
            // 
            this.rad_fleches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rad_fleches.AutoSize = true;
            this.rad_fleches.BackColor = System.Drawing.Color.Transparent;
            this.rad_fleches.ForeColor = System.Drawing.Color.White;
            this.rad_fleches.Location = new System.Drawing.Point(439, 222);
            this.rad_fleches.Name = "rad_fleches";
            this.rad_fleches.Size = new System.Drawing.Size(62, 17);
            this.rad_fleches.TabIndex = 9;
            this.rad_fleches.TabStop = true;
            this.rad_fleches.Text = "Fleches";
            this.rad_fleches.UseVisualStyleBackColor = false;
            this.rad_fleches.CheckedChanged += new System.EventHandler(this.rad_fleches_CheckedChanged);
            // 
            // lbl_controls
            // 
            this.lbl_controls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_controls.AutoSize = true;
            this.lbl_controls.BackColor = System.Drawing.Color.Transparent;
            this.lbl_controls.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.lbl_controls.ForeColor = System.Drawing.Color.White;
            this.lbl_controls.Location = new System.Drawing.Point(426, 191);
            this.lbl_controls.Name = "lbl_controls";
            this.lbl_controls.Size = new System.Drawing.Size(93, 28);
            this.lbl_controls.TabIndex = 10;
            this.lbl_controls.Text = "Controls";
            // 
            // rad_wsad
            // 
            this.rad_wsad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rad_wsad.AutoSize = true;
            this.rad_wsad.BackColor = System.Drawing.Color.Transparent;
            this.rad_wsad.ForeColor = System.Drawing.Color.White;
            this.rad_wsad.Location = new System.Drawing.Point(518, 222);
            this.rad_wsad.Name = "rad_wsad";
            this.rad_wsad.Size = new System.Drawing.Size(58, 17);
            this.rad_wsad.TabIndex = 11;
            this.rad_wsad.TabStop = true;
            this.rad_wsad.Text = "WASD";
            this.rad_wsad.UseVisualStyleBackColor = false;
            this.rad_wsad.CheckedChanged += new System.EventHandler(this.rad_wsad_CheckedChanged);
            // 
            // pantallaJoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 349);
            this.Controls.Add(this.rad_wsad);
            this.Controls.Add(this.lbl_controls);
            this.Controls.Add(this.rad_fleches);
            this.Controls.Add(this.lbl_jocpausa);
            this.Controls.Add(this.chk_musica);
            this.Controls.Add(this.btn_comencar);
            this.Controls.Add(this.cmb_dificultat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPuntuacio);
            this.Controls.Add(this.lblPunts);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.menuOpcions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuOpcions;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(584, 349);
            this.Name = "pantallaJoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serpentilla (Snake)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.pantallaJoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.menuOpcions.ResumeLayout(false);
            this.menuOpcions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label lblPunts;
        private System.Windows.Forms.Label lblPuntuacio;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_dificultat;
        private System.Windows.Forms.Button btn_comencar;
        private System.Windows.Forms.MenuStrip menuOpcions;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarElSistemaToolStripMenuItem;
        private System.Windows.Forms.CheckBox chk_musica;
        private System.Windows.Forms.ToolStripMenuItem sortirDeElJocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarHacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarElSistemaToolStripMenuItem1;
        private System.Windows.Forms.Label lbl_jocpausa;
        private System.Windows.Forms.RadioButton rad_fleches;
        private System.Windows.Forms.Label lbl_controls;
        private System.Windows.Forms.RadioButton rad_wsad;
    }
}

