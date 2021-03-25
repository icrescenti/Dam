using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Exercicis0
{
    class bucles
    {
        public static void bucleprincipifi()
        {
            int principi = 1, final = 13;

            #region definicions
            Console.Write("Mostrar el recorregut de un valor a un altre\nA quin valor vols començar? ");
            principi = int.Parse(Console.ReadLine()) ;

            Console.Write("A quin valor vols acabar? ");
            final = int.Parse(Console.ReadLine())+1;
            #endregion

            #region bucle
            for (int i = principi; i<final; i++)
            {
                Console.WriteLine(i);
            }
            #endregion

            Console.ReadLine();
        }

        public static void bucleparells()
        {
            int principi = 0, final = 20;

            #region definicions
            Console.Write("Mostrar el recorregut de un valor a un altre\nA quin valor vols començar? ");
            principi = int.Parse(Console.ReadLine());

            Console.Write("A quin valor vols acabar? ");
            final = int.Parse(Console.ReadLine()) + 1;
            #endregion

            #region bucle
            for (int i = principi; i < final; i++)
            {
                if (i%2==0)
                    Console.WriteLine(i);
            }
            #endregion

            Console.ReadLine();
        }

        public static void imparellsentrenumeros()
        {
            int valor1 = 0, valor2 = 0;

            #region definicions
            Console.Write("Primer valor: ");
            valor1 = int.Parse(Console.ReadLine());

            Console.Write("Segon valor: ");
            valor2 = int.Parse(Console.ReadLine()) + 1;
            #endregion

            #region bucle
            for (int i = valor1; i < valor2; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine(i);
            }
            #endregion

            Console.ReadLine();
        }

        public static void multiplesquatre()
        {
            #region bucle
            for (int i = 0; i < 31; i++)
            {
                if (i % 4 == 0)
                    Console.WriteLine(i);
            }
            #endregion

            Console.ReadLine();
        }

        public static void comptaenrrere()
        {
            #region bucle
            for (int i = 20; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
            #endregion

            Console.ReadLine();
        }
    
        public static void mitjananotes()
        {
            int mitjana = 0;

            Console.Write("Insereix 7 notes separat per a comes: ");

            #region operacio
            foreach (string w in Console.ReadLine().Split(','))
            {
                mitjana += int.Parse(w);
            }
            #endregion

            #region mostrar
            Console.WriteLine("La nota mitja es " + mitjana/7);
            Console.ReadLine();
            #endregion
        }

        public static void cadenaasteriscs()
        {
            int quantitat = 0;

            #region assignacio
            Console.Write("Cuants asteriscos vols mostrar? ");
            quantitat = int.Parse(Console.ReadLine());
            #endregion

            #region codi
            for (int i = 0; i < quantitat; i++)
            {
                Console.Write("*");
            }
            #endregion
            Console.ReadLine();
        }
    
        public static void factorial()
        {
            int 
                primer = 0, 
                ultim = 0,
                resultat = 1;

            #region definicio
            Console.Write("Inserir primer valor: ");
            primer = int.Parse(Console.ReadLine());
            
            Console.Write("Inserir segon valor: ");
            ultim = int.Parse(Console.ReadLine());
            #endregion

            #region codi
            //NOMES MULTIPLICAR DE EL PRIMER VALOR FINS AL PENULTIM
            for (;primer<ultim; primer++)
            {
                Console.Write(primer+"*");
                resultat *= primer; 
            }
            Console.Write(ultim + "=" + (resultat*ultim));
            #endregion

            Console.ReadLine();
        }
    
        public static void treballadors()
        {
            string[] noms = new string[5];
            int[] hores = new int[5];

            Console.WriteLine("Insereix les dades de 5 treballadors.");

            #region definicio i calcul
            for (int i = 0;i<5;i++)
            {
                Console.WriteLine("Treballador " + (i+1));
                Console.Write("Insereix nom: ");
                noms[i] = Console.ReadLine();
                Console.Write("Insereix hores: ");
                hores[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("En " + noms[i] + " te un sou net de " + ((12.50f*(float)hores[i])*16.0f/100.0f) + "€ diaris");
            }
            #endregion

            Console.ReadLine();
        }
    
        public static void buclecadena()
        {
            #region codi
            for (int i = 0;i<11;i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j<i; j++)
                {
                    Console.Write("x");
                }
                Console.Write(" ");
            }
            #endregion
            Console.ReadLine();
        }
    }
}
