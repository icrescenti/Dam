using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Side_Scrolling_Platform_Game
{
    public class Variables
    {
        #region idioma
        /// <summary>Assignem el llenguatge en el que es mostrara el joc
        /// <para>
        /// 0 - Català<br/>
        /// 1 - Angles<br/>
        /// 2 - Espanyol<br/>
        /// 3 - Italia<br/>
        /// 4 - Rus<br/>
        /// </para>
        /// </summary>
        public static int idioma = 0;
        #endregion

        #region jugador
        public static bool goleft = false;// boolean which will control players going left 
        public static bool goright = false; // boolean which will control players going right 
        public static bool jumping = false; // boolean to check if player is jumping or not 
        public static int playSpeed = 18; //this integer will set players speed to 18 
        public static bool hasKey = false; // default value of whether the player has the key 
        public static int jumpSpeed = 10; // integer to set jump speed
        #endregion

        public static int force = 8; // force of the jump in an integer 
        public static int score = 0; // default score integer set to 0 
        
        #region fons
        public static int backLeft = 8; // this integer will set the background moving speed to 8
        public static int skyLeft = 4; // this integer will set the background moving speed to 8
        #endregion
    }
}
