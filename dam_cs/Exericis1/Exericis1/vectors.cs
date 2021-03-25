using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exericis1
{
    class vectors
    {
        #region exercicis
        public static void ordernarpuntuacions_ascendent()
        {
            #region variables
            int[] puntuacio = new int[5];
            #endregion

            #region emplena array
            for (int i = 0; i < puntuacio.Length; i++)
            {
                Console.Write("Inserir un valor: ");
                puntuacio[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("Puntuacio: " + puntuacio[i]);
            }
            #endregion

            #region codi
            for (int i = 0; i <= puntuacio.Length - 2; i++)
            {
                for (int j = 0; j <= puntuacio.Length - 2; j++)
                {
                    if (puntuacio[j] > puntuacio[j + 1])
                    {
                        swapvalor_int(ref puntuacio, j);
                    }
                }
            }
            #endregion

            Console.Write("Puntuacions ordenades ascendentment: ");

            #region mostrar valors
            foreach (int p in puntuacio)
            {
                Console.Write(p + " ");
            }
            #endregion

            Console.ReadLine();
        }

        public static void ordernarpuntuacions_descendent()
        {
            /*
             * ATENCIO 
             * NOMES HE CAMBIAT LA SEGUENT LINEA
             * RESPECTIVAMENT A EL PROGRAMA ANTERIOR
             *    if (puntuacio[j] < puntuacio[j + 1])
             * A la linea 81
            */

            #region variables
            int[] puntuacio = new int[5];
            #endregion

            #region emplena array
            for (int i = 0; i < puntuacio.Length; i++)
            {
                Console.Write("Inserir un valor: ");
                puntuacio[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("Puntuacio: " + puntuacio[i]);
            }
            #endregion

            #region codi
            for (int i = 0; i <= puntuacio.Length - 2; i++)
            {
                for (int j = 0; j <= puntuacio.Length - 2; j++)
                {
                    if (puntuacio[j] < puntuacio[j + 1])
                    {
                        swapvalor_int(ref puntuacio, j);
                    }
                }
            }
            #endregion

            Console.Write("Puntuacions ordenades descendentment: ");

            #region mostrar valors
            foreach (int p in puntuacio)
            {
                Console.Write(p + " ");
            }
            #endregion

            Console.ReadLine();
        }

        public static void ordenarcadenes()
        {
            #region variables
            string[] cadena = new string[3];
            #endregion

            cadena[0] = "Paraula";
            cadena[1] = "Informatica";
            cadena[2] = "Test";

            #region mostra les cadenes de el array
            for (int i = 0; i < cadena.Length; i++)
            {
                Console.WriteLine("Cadena: " + cadena[i]);
            }
            #endregion

            #region codi
            for (int i = 0; i <= cadena.Length - 2; i++)
            {
                for (int j = 0; j <= cadena.Length - 2; j++)
                {
                    if (cadena[j].Length > cadena[j + 1].Length)
                    {
                        swapvalor_string(ref cadena, j);
                    }
                }
            }
            #endregion

            Console.Write("Cadenes ordenades ascendentment: ");

            #region mostrar valors
            foreach (string s in cadena)
            {
                Console.Write(s + " ");
            }
            #endregion

            Console.ReadLine();
        }

        public static void ordernarpuntuacions_aleatori_descendent()
        {
            #region variables
            int[] puntuacio = new int[5];
            Random r = new Random();
            #endregion

            #region emplena array
            for (int i = 0; i < puntuacio.Length; i++)
            {
                puntuacio[i] = r.Next(1, 10);
                Console.WriteLine("Puntuacio: " + puntuacio[i]);
            }
            #endregion

            #region codi
            for (int i = 0; i <= puntuacio.Length - 2; i++)
            {
                for (int j = 0; j <= puntuacio.Length - 2; j++)
                {
                    if (puntuacio[j] < puntuacio[j + 1])
                    {
                        swapvalor_int(ref puntuacio, j);
                    }
                }
            }
            #endregion

            Console.Write("Puntuacions ordenades descendentment: ");

            #region mostrar valors
            foreach (int p in puntuacio)
            {
                Console.Write(p + " ");
            }
            #endregion

            Console.ReadLine();
        }

        public static void ordernarpuntuacionsiequips_descendent()
        {
            #region variables
            string[] equips = new string[] { "Barca", "Atletic de Madriz", "Espanyol", "Legane", "Sevilla" };
            int[] puntuacio = new int[5];
            Random r = new Random();
            #endregion

            Console.WriteLine("Puntuacio de els equips:");

            #region emplena array
            for (int i = 0; i < puntuacio.Length; i++)
            {
                puntuacio[i] = r.Next(1, 7);
                Console.WriteLine(equips[i] + ": " + puntuacio[i]);
            }
            #endregion

            #region codi
            for (int i = 0; i <= puntuacio.Length - 2; i++)
            {
                for (int j = 0; j <= puntuacio.Length - 2; j++)
                {
                    if (puntuacio[j] < puntuacio[j + 1])
                    {
                        swapvalor_int(ref puntuacio, j);
                        swapvalor_string(ref equips, j);
                    }
                }
            }
            #endregion

            Console.WriteLine("Classificacio de equips per puntuacio mes alta:");

            #region mostrar valors
            for (int i = 0; i < puntuacio.Length; i++)
            {
                Console.WriteLine(equips[i] + ": " + puntuacio[i]);
            }
            #endregion

            Console.ReadLine();
        }

        #endregion

        #region altres funcions
        static void swapvalor_int(ref int[] vector, int i)
        {
            int temporal = vector[i + 1];
            vector[i + 1] = vector[i];
            vector[i] = temporal;
        }
        static void swapvalor_string(ref string[] vector, int i)
        {
            string temporal = vector[i + 1];
            vector[i + 1] = vector[i];
            vector[i] = temporal;
        }
        #endregion
    }
}
