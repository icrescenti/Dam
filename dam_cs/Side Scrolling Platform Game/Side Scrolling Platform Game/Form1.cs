﻿using System;
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
    public partial class Form1 : Form
    {
        #region inicialitzacio
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            foreach (Control x in this.Controls)
            {
                System.Reflection.PropertyInfo prop =
                typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop.SetValue(x, true, null);
            }
            Variables.idioma = 0;
        }
        #endregion

        #region codi principal
        private void mainGameTimer(object sender, EventArgs e)
        {
            player.Top += Variables.jumpSpeed; 
            // refresh the player picture box consistently 
            player.Refresh();
            // if Variables.jumping is true and Variables.force is less than 0 // then change Variables.jumping to false 
            if (Variables.jumping && Variables.force < 0)
            {
                Variables.jumping = false;
            }

            // if Variables.jumping is true // then change jump speed to -12 // reduce Variables.force by 1
            if (Variables.jumping)
            {
                Variables.jumpSpeed = -12;
                Variables.force -= 1;
            }
            else
            { // else change the jump speed to 12 
                Variables.jumpSpeed = 12;
            }
            // if go left is true and players left is greater than 100 pixels
            // only then move player towards left of the
            if (Variables.goleft && player.Left > 100)
            {
                    player.Left -= Variables.playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms left
            // if go right Boolean is true
            // player left plus players width plus 100 is less than the forms width
            // then we move the player towards the right by adding to the players left
            if (Variables.goright && player.Left + (player.Width + 100) < this.ClientSize.Width)
            {
                player.Left += Variables.playSpeed;
            }

            // by doing the if statement above, the player picture will stop on the forms right 
            // if go right is true and the background picture left is greater 1352 
            // then we move the background picture towards the left 
            if (Variables.goright && background.Left > -1353)
            {
                background.Left -= Variables.backLeft;
                sky.Left -= Variables.skyLeft;
                // the for loop below is checking to see the platforms and coins in the level 
                // when they are found it will move them towards the left
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left -= Variables.backLeft;
                    }
                }
            }
            // if go left is true and the background pictures left is less than 2 
            // then we move the background picture towards the right 
            if (Variables.goleft && background.Left < 2)
            {
                background.Left += Variables.backLeft;
                sky.Left += Variables.skyLeft;
                // below the is the for loop thats checking to see the platforms and coins in the level
                // when they are found in the level it will move them all towards the right with the background
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left += Variables.backLeft;
                    }
                }
            }
            // below if the for loop thats checking for all of the controls in this form 
            foreach (Control x in this.Controls)
            {
                // is X is a picture box and it has a tag of platform 
                if (x is PictureBox && x.Tag == "platform")
                {
                    // then we are checking if the player is colliding with the platform
                    // and Variables.jumping is set to false
                    if (player.Bounds.IntersectsWith(x.Bounds) && !Variables.jumping)
                    {
                        // then we do the following
                        Variables.force = 8; // set the Variables.force to 8 
                        player.Top = x.Top - player.Height + 1; // also we place the player on top of the picture box 
                        Variables.jumpSpeed = 0; // set the jump speed to 0
                    }
                }
                // if the picture box found has a tag of coin 
                if (x is PictureBox && x.Tag == "coin")
                {
                    // now if the player collides with the coin picture box 
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x); // then we are going to remove the coin image 
                        Variables.score++; // add 1 to the Variables.score 
                    }
                }
            } // if the player collides with the door and has key boolean is true 
            if (player.Bounds.IntersectsWith(door.Bounds) && Variables.hasKey)
            { // then we change the image of the door to open 
                door.Image = Properties.Resources.door_open;
                // and we stop the timer 
                gameTimer.Stop();
                MessageBox.Show(string_llenguatge(0)); // show the message box 
                Variables.hasKey = false;
                this.Close();
                Form2 nivell_2 = new Form2();
                nivell_2.ShowDialog();
            }
            // if the player collides with the key picture box 
            if (player.Bounds.IntersectsWith(key.Bounds))
            {
                // then we remove the key from the game 
                this.Controls.Remove(key);
                // change the has key boolean to true 
                Variables.hasKey = true;
            }

            // this is where the player dies 
            // if the player goes below the forms height then we will end the game 
            if (player.Top + player.Height > this.ClientSize.Height + 60)
            {
                gameTimer.Stop(); // stop the timer 
                MessageBox.Show(string_llenguatge(1)); // show the message box 

            }
        } // linking the Variables.jumpSpeed i
        #endregion

        #region recepcio de controls de el jugador
        private void keyisdown(object sender, KeyEventArgs e)
        {
            // then we set the car left boolean to true 
            if (e.KeyCode == Keys.Left)
            {
                Variables.goleft = true;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width 
            if (e.KeyCode == Keys.Right)
            { // then we set the player right to true 
                Variables.goright = true; 
            }
            //if the player pressed the space key and Variables.jumping boolean is false 
            if (e.KeyCode == Keys.Space && !Variables.jumping)
            { // then we set Variables.jumping to true
                Variables.jumping = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Parametres np = new Parametres();
                np.ShowDialog();
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            // then we set the car left boolean to true 
            if (e.KeyCode == Keys.Left)
            {
                Variables.goleft = false;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width 
            if (e.KeyCode == Keys.Right)
            { // then we set the player right to true 
                Variables.goright = false;
            }

            if (Variables.jumping)
            {
                Variables.jumping = false;
            }
        }

        #endregion

        #region altres
        public string string_llenguatge(int textnum)
        {
            if (Variables.idioma == 0)
                return Idiomes.catala[textnum];
            else if (Variables.idioma == 1)
                return Idiomes.angles[textnum];
            else if (Variables.idioma == 2)
                return Idiomes.espanyol[textnum];
            else if (Variables.idioma == 3)
                return Idiomes.italia[textnum];
            else if (Variables.idioma == 4)
                return Idiomes.rus[textnum];

            return Idiomes.angles[textnum];
        }
        #endregion
    }
}
