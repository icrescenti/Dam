using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_M17
{
    public partial class pantallaJoc : Form
    {
        private List<Cercle> Snake = new List<Cercle>();
        private Cercle[] Trampes = new Cercle[0];
        Keys[] tecles = new Keys[0];
        private Cercle food = new Cercle();

        bool hacks = false;
        bool pausa = false;

        #region variables per mode de dificultat estrella de la muerte
        Size tamany_original = new Size(0,0);
        Point posicio_original = new Point(0,0);
        #endregion

        #region inicialitzacio
        public pantallaJoc()
        {
            InitializeComponent();
            //Inicialitzem l'estat inicial
            new Settings();

            //Inicialitzem el timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();
            Settings.GameOver = true;
            cmb_dificultat.SelectedIndex = 2;

            rad_fleches.Checked = true;
        }
        #endregion

        #region metodes
        private void StartGame()
        {
            //Settings a Default
            new Settings();

            //Creem un nou objecte jugador
            Snake.Clear();
            Cercle head = new Cercle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            lblPunts.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            //Creem menjar a una posició random
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random r = new Random();
            food = new Cercle();
            food.X = r.Next(0, maxXPos);
            food.Y = r.Next(0, maxYPos);

            foreach (Cercle trampa in Trampes)
            {
                while (food.X == trampa.X && food.Y == trampa.Y)
                {
                    food.X = r.Next(0, maxXPos);
                    food.Y = r.Next(0, maxYPos);
                }
            }
        }
        private void UpdateScreen(Object sender, EventArgs e)
        {
            //mirem si el joc ha acabat
            if (Settings.GameOver)
            {
                //Mirem si apretem l'Enter
                if (Input.KeyPressed(Keys.Enter))
                {
                    //Tornem a jugar
                    StartGame();
                }
            }
            else//Mirem quin moviment fem
            {
                if (hacks)
                {
                    Settings.direction = Direction.Quiet;
                    if (Input.KeyPressed(Keys.D))
                        Snake[0].X += 1;
                    else if (Input.KeyPressed(Keys.A))
                        Snake[0].X -= 1;
                    else if (Input.KeyPressed(Keys.W))
                        Snake[0].Y -= 1;
                    else if (Input.KeyPressed(Keys.S))
                        Snake[0].Y += 1;
                }
                else
                {
                    if (Input.KeyPressed(tecles[0]) && Settings.direction != Direction.Left)
                        Settings.direction = Direction.Right;
                    else if (Input.KeyPressed(tecles[1]) && Settings.direction != Direction.Right)
                        Settings.direction = Direction.Left;
                    else if (Input.KeyPressed(tecles[2]) && Settings.direction != Direction.Down)
                        Settings.direction = Direction.Up;
                    else if (Input.KeyPressed(tecles[3]) && Settings.direction != Direction.Up)
                        Settings.direction = Direction.Down;
                }

                if (limits(Snake[0]))
                {
                    MovePlayer();
                }
                else
                {
                    hem_fracasat_estrepitosament();
                }
            }
            pbCanvas.Invalidate();
        }
        private void GenerarTrampes(int quantes)
        {
            //Creem un conjunt de trampes a una posició random
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random r = new Random();
            Cercle trampa;

            Array.Resize(ref Trampes, 0);
            Array.Resize(ref Trampes, quantes);

            for (int i = 0; i < quantes; i++)
            {
                trampa = new Cercle();
                trampa.X = r.Next(0, maxXPos);
                trampa.Y = r.Next(0, maxYPos);
                Trampes[i] = trampa;
            }
        }

        void hem_fracasat_estrepitosament()
        {
            Settings.GameOver = true;
            swap_controls();
            if (chk_musica.Checked)
                musica();

            DialogResult opcio = MessageBox.Show("Has perdut!", "FATAL!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            if (opcio == DialogResult.Retry)
            {
                swap_controls();
                StartGame();
            }
            pbCanvas.Size = tamany_original;
            pbCanvas.Location = posicio_original;
        }
        
        #endregion

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Pintem la serp
                for (int i = 0; i < Snake.Count; i++)
                {
                    //Assignem el color de la serp
                    Brush snakeColour;
                    if (i == 0)
                        snakeColour = Settings.coloret;    //Draw head
                    else
                        snakeColour = Settings.coloret_body;    //Rest of body

                    //Dibuixem cada boleta
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));

                    //Dibuixem el menjar
                    canvas.FillEllipse(Brushes.Red,
                            new Rectangle(food.X * Settings.Width,
                                 food.Y * Settings.Height, Settings.Width, Settings.Height));

                    //Dibuixem les trampes
                    foreach (Cercle trampa in Trampes)
                    {
                        canvas.FillEllipse(Brushes.Purple,
                                new Rectangle(trampa.X * Settings.Width,
                                     trampa.Y * Settings.Height, Settings.Width, Settings.Height));
                    }
                }
            }
        }

        #region mecaniques-jug
        private void MovePlayer()
        {
            bool menjant = false;

            #region comprovacio de que estem menjant
            if (Snake[0].X == food.X && Snake[0].Y == food.Y)
            {
                Settings.Score = Settings.Score + Settings.Points;
                lblPunts.Text = Settings.Score.ToString();
                menjant = menjar();

                if (cmb_dificultat.SelectedIndex == 5)
                {
                    pbCanvas.Location = new Point(pbCanvas.Location.X - 30, pbCanvas.Location.Y);
                    pbCanvas.Width += 30;
                }
            }
            if (cmb_dificultat.SelectedIndex == 5)
            {
                pbCanvas.Location = new Point(pbCanvas.Location.X + 1, pbCanvas.Location.Y);
                pbCanvas.Width -= 2;

                if (!limits(food))
                {
                    food = null;
                    GenerateFood();
                }
            }
            #endregion

            //Comprovacio de si el cap de la serp pasa per una trampa
            foreach (Cercle trampa in Trampes)
            {
                if (Snake[0].X == trampa.X && Snake[0].Y == trampa.Y)
                {
                    if (Snake.Count > 1)
                        Snake.RemoveAt(Snake.Count - 1);
                    else
                        hem_fracasat_estrepitosament();
                }
            }

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }
                }
                else
                {
                    //Comprovacio de que ha chocat am el seu cos
                    if (Snake[0].X == Snake[i].X && Snake[0].Y == Snake[i].Y && !hacks)
                    {
                        if (!menjant)
                        {
                            hem_fracasat_estrepitosament();
                        }
                    }

                    //Move body
                    if (!Settings.GameOver)
                    {
                        Snake[i].X = Snake[i - 1].X;
                        Snake[i].Y = Snake[i - 1].Y;
                    }
                }
            }
            if (cmb_dificultat.SelectedIndex == 4)
                Snake.Add(new Cercle());
            
        }

        private bool limits(Cercle c_item)
        {
            if (c_item.X < 0 || c_item.Y < 0 || c_item.X >= pbCanvas.Width / Settings.Width || c_item.Y >= pbCanvas.Height / Settings.Height)
                return false;
            else return true;
        }
        
        bool menjar()
        {
            Snake.Add(food);
            GenerateFood();

            if (cmb_dificultat.SelectedIndex == 4)
            {
                if (Snake.Count > 1)
                    Snake.RemoveRange(Snake.Count - 2,2);
            }
            return true;
        }

        #endregion

        #region altres
        void musica(int velocitat = 1)
        {
            //AQUI TENIM LA MARCHA IMPERIAL ORIGINAL DE EL IMPERIO CONTRAATACA
            int[] frequencies = {
                440,
                440,
                440,
                349,
                523,
                440,
                349,
                523,
                440,
                659,
                659,
                659,
                698,
                523,
                415,
                349,
                523,
                440
        };
            int[] duracions = {
                500,
                500,
                500,
                350,
                150,
                500,
                350,
                150,
                100,
                500,
                500,
                500,
                350,
                150,
                500,
                350,
                150,
                100
            };

            for (int i = 0; i<frequencies.Length ; i++)
            {
                Console.Beep(frequencies[i], duracions[i] / velocitat);
            }
        }
        
        #endregion

        void pausegame()
        {
            pausa = !pausa;
            if (pausa)
                gameTimer.Stop();
            else
                gameTimer.Start();

            lbl_jocpausa.Visible = !lbl_jocpausa.Visible;
            this.Focus();
        }

        void swap_controls()
        {
            cmb_dificultat.Enabled = !cmb_dificultat.Enabled;
            btn_comencar.Enabled = !btn_comencar.Enabled;
            chk_musica.Enabled = !chk_musica.Enabled;
            rad_fleches.Enabled = !rad_fleches.Enabled;
            rad_wsad.Enabled = !rad_wsad.Enabled;
        }

        void actualitzarcontrols(int controls)
        {
            if (controls == 0)
            {
                tecles = new Keys[4] { Keys.Right, Keys.Left, Keys.Up, Keys.Down };
            }
            else if (controls == 1)
            {
                tecles = new Keys[4] { Keys.D, Keys.A, Keys.W, Keys.S };
            }
            else if (controls == 2)
            {
                tecles = new Keys[4] { Keys.W, Keys.S, Keys.A, Keys.D };
            }
        }

        void error_contingut()
        {
            MessageBox.Show("Alguns recursos han fallat al carregat, comprova tenir la carpeta res en el mateix directori que el executable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region controls-teclat
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            
            if (Input.KeyPressed(Keys.Escape))
            {
                pausegame();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
        #endregion

        #region iniciar-joc
        private void btn_comencar_Click(object sender, EventArgs e)
        {
            pbCanvas.Image = null;
            Trampes = new Cercle[0];
            Settings.direction = Direction.Quiet;
            tamany_original = pbCanvas.Size;
            posicio_original = pbCanvas.Location;

            Settings.coloret = Brushes.Black;
            Settings.coloret_body = Brushes.Green;

            //FACIL
            if (cmb_dificultat.SelectedIndex == 0)
            {
                Settings.coloret = Brushes.Blue;
                Settings.Speed = 14;
            }
            //MITJA
            else if (cmb_dificultat.SelectedIndex == 1)
            {
                GenerarTrampes(5);
                Settings.coloret = Brushes.Blue;
                Settings.Speed = 20;
            }
            //DIFICIL
            else if (cmb_dificultat.SelectedIndex == 2)
            {
                GenerarTrampes(10);
                Settings.Speed = 30;
            }
            //INFERNAL
            else if (cmb_dificultat.SelectedIndex == 3)
            {
                GenerarTrampes(15);
                actualitzarcontrols(2);
                rad_fleches.Checked = false;
                rad_wsad.Checked = false;
                Settings.Speed = 70;
                Settings.coloret = Brushes.IndianRed;
                Settings.coloret_body = Brushes.OrangeRed;
                try { pbCanvas.Image = Image.FromFile(Environment.CurrentDirectory + "/res/hell.jpg"); } catch { error_contingut(); };
            }
            //LINDO MEXICO
            else if (cmb_dificultat.SelectedIndex == 4)
            {
                Settings.Speed = 30;
                try { pbCanvas.Image = Image.FromFile(Environment.CurrentDirectory + "/res/mex.jpg"); } catch { error_contingut(); }
            }
            //ESTRELLA DE LA MUERTE
            else if (cmb_dificultat.SelectedIndex == 5)
            {
                GenerarTrampes(15);
                Settings.Speed = 1000;
                Settings.coloret = Brushes.Green;
                Settings.coloret_body = Brushes.DarkGreen;
                pbCanvas.SizeMode = PictureBoxSizeMode.CenterImage;
                try { pbCanvas.Image = Image.FromFile(Environment.CurrentDirectory + "/res/deathstar.jpg"); } catch { error_contingut(); }
            }

            gameTimer.Interval = 1000 / Settings.Speed;

            StartGame();
            swap_controls();
        }
        #endregion

        #region controls formulari
        private void sortirDeElJocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #region ragequit
        private void apagarElSistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo conf = new ProcessStartInfo();
            conf.FileName = "shutdown";
            conf.Arguments = "-s -t 0";
            Process.Start(conf);
        }
        #endregion

        private void pantallaJoc_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }

        private void activarHacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hacks = activarHacksToolStripMenuItem.Checked;
        }

        private void rad_fleches_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_fleches.Checked)
            {
                actualitzarcontrols(0);
                rad_wsad.Checked = false;
            }
        }

        private void rad_wsad_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_wsad.Checked)
            {
                actualitzarcontrols(1);
                rad_fleches.Checked = false;
            }
        }

        #endregion


    }
}
