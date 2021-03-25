using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exericis1
{
    class cadenes
    {
        #region exercicis
        public static void allargadanom()
        {
            string nom;
            Console.Write("Insereix el teu nom: ");
            nom = Console.ReadLine();
            Console.WriteLine("El nom " + nom + " te " + nom.Length + " caracters.");
            Console.ReadLine();
        }

        public static void lletresnom()
        {
            #region variables i definicio
            string nom;
            Console.Write("Insereix el teu nom: ");
            nom = Console.ReadLine();
            #endregion

            #region codi
            for (int i = 0; i < nom.Length; i++)
            {
                Console.WriteLine("Nom(" + i + ")=" + nom[i]);
            }
            #endregion

            Console.ReadLine();
        }

        public static void invertirnom()
        {
            #region variables i definicio
            string nom = "Juan";
            Console.Write("Insereix el teu nom: ");
            nom = Console.ReadLine();
            char[] buffer = new char[nom.Length];
            #endregion

            #region codi
            for (int i = 0, j = nom.Length-1; i<nom.Length; i++, j--)
            {
                buffer[i] = nom[j];
            }

            Console.Write("Nom invertit: ");
            for (int i = 0; i < nom.Length; i++)
            {
                Console.Write(buffer[i]);
            }
            #endregion

            Console.ReadLine();
        }
        
        public static void convertiramajuscules()
        {
            #region variables i definicio
            string nom;
            Console.Write("Insereix el teu nom: ");
            nom = Console.ReadLine();
            #endregion

            Console.WriteLine("Nom en majuscules: " + nom.ToUpper());

            Console.ReadLine();
        }

        public static void primersiultims()
        {
            #region variables i definicio
            string nom;
            Console.Write("Insereix el teu nom: ");
            nom = Console.ReadLine();
            #endregion

            Console.WriteLine("Els 3 primers caracters son: " + nom.Substring(0,3) + " i els 3 ultim son:" + nom.Substring(nom.Length-3));

            Console.ReadLine();
        }

        public static void cadenapiramidal()
        {
            #region variables i definicio
            string nom;
            Console.Write("Insereix una parauleta: ");
            nom = Console.ReadLine();
            #endregion

            #region codi
            for (int i = 1; i <= nom.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(nom[j]);
                }
                Console.Write("\n");
            }
            #endregion

            Console.ReadLine();
        }

        public static void exercicisplit()
        {
            #region variables i definicio
            string cadena;
            Console.Write("Insereix 3 paraules separades per una coma: ");
            cadena = Console.ReadLine();
            string[] paraules = cadena.Split(',');
            #endregion

            #region codi
            Console.WriteLine("Les paraulilles son:");
            for (int i = 0; i<paraules.Length; i++)
            {
                Console.WriteLine(paraules[i]);
            }
            #endregion

            Console.ReadLine();
        }

        public static void exercicisplit_multicaracter()
        {
            #region variables i definicio
            string cadena;
            Console.Write("Insereix una operacio matematica: ");
            cadena = Console.ReadLine();
            char[] sep = new char[] {'+', '-', '*', '/'};
            string[] numeros = cadena.Split(sep);
            #endregion

            #region codi
            Console.Write("Els valors de la operacio seran: ");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write(numeros[i] + " ");
            }
            #endregion

            Console.ReadLine();
        }
        #endregion

    }
}
