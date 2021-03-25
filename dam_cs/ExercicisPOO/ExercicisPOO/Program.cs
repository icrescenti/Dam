using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicisPOO
{
    class Program
    {
        //============================================================================
        // Name        : ExercicisPOO
        // Author      : Ivan Crescenti Hernandez
        // Version     : 1.0
        // Copyright   : MIT License
        // Description : Test de nivell de C# per a Institut Rafael Campalans
        //============================================================================
        static void Main(string[] args)
        {
            //EXERCICI 1
            //barallacartes();

            //EXERCICI 2
            //taulaenter();

            //EXERCICI 3
            //exercicistrings();

            //EXERCICI 4
            //matriu5x6();

            //EXERCICI 5
            //nombrescuriosos();

            //EXERCICI 6
            //recursivitat();

            //EXERCICI 7
            //Form1 f = new Form1(); f.ShowDialog();

            //EXERCICI 8
            //nombresdeordenats();
        }

        #region exercicis
        static void barallacartes()
        {
            /*
             * Pal 1 es Espases
             * Pal 2 es Copes
             * Pal 3 es Bastos
             * Pal 4 es Ors
             */

            #region variables
            const int MAXCARTES = 10;

            //TUPLA
            (int pal, int valor)[] carta = new (int pal, int valor)[MAXCARTES];

            Random aleatoritzador = new Random();
            #endregion

            Console.WriteLine("Tindrem les seguents cartes:");

            #region codi

            #region generar cartes
            for (int i = 0; i < MAXCARTES; i++)
            {
                carta[i].pal = aleatoritzador.Next(1, 5);
                carta[i].valor = aleatoritzador.Next(1, 13);

                mostrar_carta(carta[i].pal, carta[i].valor);

                Console.Write("\n");
            }
            #endregion

            Console.WriteLine("---------------------------------");

            #region recorrecgut, comptar asos
            int compta = 0;
            for (int i = 0; i < MAXCARTES; i++)
            {
                if (carta[i].valor == 1) compta++;
            }
            Console.WriteLine("Tenim " + compta + " Asos");
            #endregion

            #region cerca de espases
            bool buscar = true;
            int j = 0;

            while (buscar && j < MAXCARTES)
            {
                if (carta[j].pal == 1) buscar = false;
                j++;
            }

            if (buscar) Console.WriteLine("Actualment no tenim cap carta de espases");
            else Console.WriteLine("Alguna carta es de espases");
            #endregion

            #region cerca si hi ha cartes repetides
            buscar = true;
            j = 0;
            int k = 0;

            while (buscar && j < MAXCARTES)
            {
                k = j + 1;
                while (buscar && k < MAXCARTES)
                {
                    if ((carta[j].valor == carta[k].valor) && (carta[j].pal == carta[k].pal))
                    {
                        buscar = false;
                    }
                    k++;
                }
                j++;
            }

            if (buscar)
            {
                Console.WriteLine("No tenim cap carta repetida");
            }
            else
            {
                Console.WriteLine("Tenim algunes cartes repetides");
            }

            #endregion

            Console.ReadLine();

            #endregion
        }

        static void taulaenter()
        {
            int[] vector = new int[0];
            Console.Write("Nombre de valors a inserir (maxim 20): ");
            int max = int.Parse(Console.ReadLine());

            if (max < 21)
            {
                Array.Resize(ref vector, max);

                #region emplenem el vector
                for (int x = 0; x < vector.Length; x++)
                {
                    Console.Write("Valor " + (x+1) + ": ");
                    vector[x] = int.Parse(Console.ReadLine());
                }
                #endregion

                #region cerca si tenim 3 nombres iguals seguits
                bool trobat = false;
                int i = 0;

                while (!trobat && i < vector.Length-2)
                {
                    if (vector[i] == vector[i+1] && vector[i + 1] == vector[i+2]) trobat = true;
                    i++;
                }
                if (trobat)
                {
                    Console.WriteLine("El valor "+ vector[i] + " esta repetit 3 vegades seguidament");
                }
                else
                {
                    Console.WriteLine("Cap valor no esta present 3 vegades seguides");
                }
                #endregion

                #region comprova que el primer valor es mes gran que la resta de la taula
                bool mesgran = false;

                for (i = 0; i<vector.Length; i++)
                {
                    if (vector[0] > vector[i]) mesgran = true;
                }
                
                if (mesgran)
                {
                    Console.WriteLine("El primer valor es el mes gran (" + vector[0] + ")");
                }
                else
                {
                    Console.WriteLine("El primer valor NO es el mes gran");
                }

                #endregion

                #region comprova que la taula estigui en decreixent
                int j = 0;
                bool decreixent = true;
                
                while (decreixent && j<max-1)
                {
                    if (vector[j] < vector[j + 1]) decreixent = false;
                    j++;
                }
                if (decreixent)
                {
                    Console.WriteLine("La taula esta ordenada de manera decreixent");
                }
                else
                {
                    Console.WriteLine("La taula NO esta ordenada de manera decreixent");
                }

                #endregion
            }
            else
            {
                Console.WriteLine("He dit que no es pot inserir mes de 20 valors!");
            }

            Console.ReadLine();
        }
        
        static void exercicistrings()
        {
            string[] cadena = new string[3];

            #region assignacio de variables
            Console.WriteLine("Insereix 3 paraules:");

            for (int i = 0; i<cadena.Length; i++)
                cadena[i] = Console.ReadLine();

            #endregion

            #region determina si les cadenes son iguals
            if (cadena[0] == cadena[1] && cadena[0] == cadena[2])
            {
                Console.WriteLine("Les tres paraules son iguals");
            }
            else
            {
                Console.WriteLine("Les tres paraules NO son iguals");
            }
            #endregion

            #region ordenar alfabeticament

            for (int i = 0; i < cadena.Length-1; i++)
            {
                for (int j = 0; j < cadena.Length - 1; j++)
                {
                    if (cadena[j].CompareTo(cadena[j + 1]) > 0)
                    {
                        swapstrings_array(ref cadena, j);
                    }
                }
            }

            //DE MANERA SENZILLA NO APTE PER EL EXERCICI
            //Array.Sort(cadena);

            Console.WriteLine("La cadena amb el valor \"" + cadena[0] + "\" es la primera ordenada alfabeticament.");

            #endregion

            #region compta les r
            string frase = String.Concat(cadena);
            int contador = 0;

            for (int i = 0; i < frase.Length; i++)
            {
                if (frase[i] == 'r')
                {
                    contador++;
                }
            }

            Console.WriteLine("Tenim " + contador + " \'r\' entre totes les paraules");

            #endregion

            Console.ReadLine();
        }
        
        static void matriu5x6()
        {
            int[,] matriu = new int[4,5];
            int resultat = 0;
            Random r = new Random();

            #region emplena i mostra la matriu
            for (int i = 0;i<matriu.GetUpperBound(0)+1;i++)
            {
                for (int j = 0; j < matriu.GetUpperBound(1)+1; j++)
                {
                    matriu[i, j] = r.Next(0,10);
                    Console.Write(matriu[i, j] + " ");
                }
                Console.Write("\n");
            }
            #endregion

            Console.WriteLine("================================\n\n\n");

            #region mostrar restes horizontals
            
            for (int i = 0, j = 0; i < matriu.GetUpperBound(0) + 1; i++)
            {
                for (j = 0; j < matriu.GetUpperBound(1) + 1; j++)
                {
                    Console.Write("{0,5}", matriu[i, j] + " ");
                    resultat -= matriu[i, j];
                }
                Console.Write(" =  " + resultat);
                resultat = 0;
                Console.Write("\n");
            }
            #endregion

            Console.WriteLine("----------------------------");

            #region suma vertical
            for (int i = 0, j = 0; i < matriu.GetUpperBound(0) + 2; i++)
            {
                for (j = 0; j < matriu.GetUpperBound(1); j++)
                {
                    resultat -= matriu[j, i];
                }
                
                Console.Write("{0,5}", resultat);
                resultat = 0;
            }
            #endregion

            #region suma diagonal
            for (int i = 0; i < matriu.GetUpperBound(1); i++)
            {
                resultat += matriu[i, i + 1];
            }

            Console.Write("{0,5}", resultat);
            #endregion

            Console.ReadLine();
        }
        
        static void nombrescuriosos(int valor = 145)
        {
            int[] digits = new int[0];
            string format = "";

            #region separacio de digits
            int aux = valor;
            for (int i = 0; valor != 0; valor /= 10, i++)
            {
                Array.Resize(ref digits, digits.Length+1);
                digits[i] = valor % 10;
            }
            Array.Reverse(digits);
            valor = aux;
            #endregion

            #region mostra els digits
            foreach (int digit in digits)
                format += digit + "! + ";

            Console.Write(format.Substring(0,format.Length-2) + "= ");
            #endregion

            #region mostra els factorials de els digits
            format = "";
            int sum = 0;
            foreach (int digit in digits)
            {
                aux = factioral(digit);
                format += aux + " + ";
                sum += aux;
            }
            Console.Write(format.Substring(0, format.Length - 2) + "= ");
            #endregion

            Console.WriteLine(sum);
            Console.ReadLine();
        }

        #region recursivitat
        static void recursivitat()
        {
            int valor1 = 0, valor2 = 0;

            Console.Write("Inserir un valor: ");
            valor1 = int.Parse(Console.ReadLine());
            Console.Write("Inserir un altre valor: ");
            valor2 = int.Parse(Console.ReadLine());

            Console.WriteLine("El mcd es " + mcd(valor1,valor2));
            Console.ReadLine();
        }
        static int mcd(int a, int b)
        {
            if (a > b) return mcd(a - b, b);
            else if (a < b) return mcd(a, b - a);
            else return a;
        }
        #endregion

        static void nombresdeordenats()
        {
            /*
             * GENERA UN FITXER DE TEXT AMB ELS VALORS DESORDENATS
             * CAMBIAR TRUE A FALSE SI NO VOLS OBRIR 
             * EL EXPLORADOR UNA VEGADA GENERAT
            */
            generar_fitxer(100, true);

            int[] nombres = new int[100];

            #region lectura de el fitxer
            using (StreamReader lector = new StreamReader(Environment.CurrentDirectory + "/fixerets/nombres-desordenats.txt"))
            {
                int i = 0;

                while(lector.Peek() > -1)
                {
                    nombres[i++] = int.Parse(lector.ReadLine());
                }
                lector.Close();
                lector.Dispose();
            }
            #endregion

            #region ordena els valors de manera ascendent
            for (int i = 0; i < nombres.Length-1; i++)
            {
                for (int j = 0; j < nombres.Length-1; j++)
                {
                    if (nombres[j] > nombres[j + 1])
                    {
                        swapvalor_int(ref nombres, j);
                    }
                }
            }
            #endregion

            #region escriu la informacio a un fitxer de texte
            using (StreamWriter escriptor = new StreamWriter(Environment.CurrentDirectory + "/fixerets/nombres-ordenats.txt"))
            {
                for (int i = 0; i < nombres.Length; i++)
                {
                    escriptor.WriteLine(nombres[i]);
                }
                escriptor.Flush();
                escriptor.Close();
                escriptor.Dispose();
            }
            #endregion

            Console.WriteLine("Numeros ordenats ascendentment a el fitxer " + Environment.CurrentDirectory + @"\fixerets\nombres-ordenats.txt");

            Console.ReadLine();
        }
        #endregion

        #region altres
        static void mostrar_carta(int palnum, int numero)
        {
            #region identificar si es un valor numeric de 2 a 9 o una carta identificada
            if (numero < 10 && numero != 1)
            {
                Console.Write("{0,2}", numero);
            }
            #region en cas de ser una carta identificada, anomenarla
            else
            {
                switch (numero)
                {
                    case 10:
                        Console.Write("Sota");
                        break;
                    case 11:
                        Console.Write("Caballer");
                        break;
                    case 12:
                        Console.Write("Rei");
                        break;
                    case 1:
                        Console.Write("As");
                        break;
                }
            }
            #endregion

            #endregion

            Console.Write(" de ");

            #region defineix de quin pal
            switch (palnum)
            {
                case 1:
                    Console.Write("Espases");
                    break;
                case 2:
                    Console.Write("Copes");
                    break;
                case 3:
                    Console.Write("Bastos");
                    break;
                case 4:
                    Console.Write("Ors");
                    break;
            }
            #endregion
        }
        
        static int factioral(int valor)
        {
            int i = 1, resultat = 1;
            while (i <= valor)
            {
                resultat *= i;
                i++;
            }
            return resultat;
        }

        static void generar_fitxer(int quantitat = 100, bool obriralfinalitzar = false)
        {
            Random aleatori = new Random();

            if (!Directory.Exists(Environment.CurrentDirectory + "/fixerets"))
            {
                try { Directory.CreateDirectory(Environment.CurrentDirectory + "/fixerets"); }
                catch { MessageBox.Show("Error, la carpeta per emmagatzemar fixers no ha pogut estar creada, comprova que tens els permisos suficients", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else if (File.Exists(Environment.CurrentDirectory + "/fixerets/nombres-desordenats.txt"))
            {
                File.Delete(Environment.CurrentDirectory + "/fixerets/nombres-desordenats.txt");
            }

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/fixerets/nombres-desordenats.txt"))
            {
                for (int i = 0; i<quantitat; i++)
                    sw.WriteLine(aleatori.Next(-5000, 5001));

                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            if (obriralfinalitzar)
            {
                Process.Start("explorer.exe", Environment.CurrentDirectory + "\\fixerets");
            }
        }

        static void swapstrings_array(ref string[] vector, int i)
        {
            string temporal = vector[i];
            vector[i] = vector[i+1];
            vector[i+1] = temporal;
        }

        static void swapvalor_int(ref int[] vector, int i)
        {
            int temporal = vector[i + 1];
            vector[i + 1] = vector[i];
            vector[i] = temporal;
        }

        #endregion
    }
}
