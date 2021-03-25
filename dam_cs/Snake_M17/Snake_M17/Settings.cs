using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_M17
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Quiet
    };
    class Settings
    {
        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 14;
            Score = 0;
            Points = 100;
            GameOver = false;
            direction = Direction.Down;
            coloret = Settings.coloret;
            coloret_body = Settings.coloret_body;
        }


        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }
        public static Brush coloret { get; set; }
        public static Brush coloret_body { get; set; }
    }
}
