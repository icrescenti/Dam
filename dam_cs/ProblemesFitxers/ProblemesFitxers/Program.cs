using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProblemesFitxers
{
    class Program
    {
        //DESCOMENTAR PER UTILITZAR EL EXERCICI 4 (FORMULARI)
        //[STAThread]
        static void Main(string[] args)
        {
            //EXERCICI 1
            mitjanatemperatures();

            //EXERCICI 2
            //escriurealeatoris();

            //EXERCICI 3
            //numerorepetit();

            //EXERCICI 4
            //Finestra formulari = new Finestra(); Application.Run(formulari);
        }

        #region exercicis

        static void mitjanatemperatures()
        {
            #region variables i generacio
            int[] temperatura = new int[0];
            char spearador = ',';

            //GENERACIO DE EL FIXERET
            generarfitxer(Environment.CurrentDirectory, false);
            #endregion

            int i = 0;
            using (StreamReader lector = new StreamReader(Environment.CurrentDirectory + "/temperatures.txt"))
            {
                while (lector.Peek() > -1)
                {
                    string line = lector.ReadLine();
                    Console.WriteLine(line);

                    Array.Resize(ref temperatura, temperatura.Length+1);
                    temperatura[i++] = int.Parse( line.Split(spearador)[1] );
                }
                lector.Close();
                lector.Dispose();
            }
            i = 0;
            for (int j = 0; j< temperatura.Length; j++)
            {
                i += temperatura[j];
            }
            Console.WriteLine("La temperatura mitja es de " + i / temperatura.Length + " graus");
            Console.ReadLine();
        
        }

        static void escriurealeatoris()
        {
            const int max_numeros = 10;
            Random r = new Random();

            using (StreamWriter escriptor = new StreamWriter(Environment.CurrentDirectory + "/nombresaleatoris.txt"))
            {
                //escriptor.AutoFlush = true;
                for (int i = 0;i < max_numeros; i++)
                {
                    escriptor.Write(r.Next(1,6) + " ");
                }
                escriptor.Flush();
                escriptor.Close();
                escriptor.Dispose();
            }

        }

        static void numerorepetit()
        {
            int[] nombres = new int[0];

            //LECTURA I PARSEJAR DE STRING A INT
            {
                string[] numeros_fitxer;

                StreamReader lector = new StreamReader(Environment.CurrentDirectory + "/nombresaleatoris.txt");
                numeros_fitxer = lector.ReadToEnd().Split();
                lector.Close();
                lector.Dispose();

                for (int i = 0; i < numeros_fitxer.Length - 1; i++)
                {
                    Array.Resize(ref nombres, nombres.Length + 1);
                    nombres[i] = int.Parse(numeros_fitxer[i]);
                }
                //Array.Clear(numeros_fitxer, 0, numeros_fitxer.Length);
            }

            #region ordena els valors de manera ascendent
            for (int i = 0; i < nombres.Length - 1; i++)
            {
                for (int j = 0; j < nombres.Length - 1; j++)
                {
                    if (nombres[j] > nombres[j + 1])
                    {
                        swapvalor_int(ref nombres, j);
                    }
                }
            }
            #endregion

            #region comptem quin valors dins la array estan mes repetits
            int x = 0, previ = 0, posicio = 0;
            for (int i = 0; i < nombres.Length-1; i++)
            {
                if (nombres[i] == nombres[i+1]) x++;
                else
                {
                    if (x > previ)
                    {
                        previ = x;
                        posicio = i;
                    }
                    x = 0;
                }
            }
            #endregion

            Console.WriteLine("El valor que ha sortit mes vegades es " + nombres[posicio]);
            Console.ReadLine();
        }
        
        #endregion

        #region altres
        static void generarfitxer(string ruta, bool obriralfinalitzar = false)
        {
            Random r = new Random();
            File.WriteAllText(ruta + "/temperatures.txt", "Girona, " + r.Next(0,21) + "\nTarragona, " + r.Next(0, 21) + "\nLleida, " + r.Next(0, 21) + "\nBarcelona, " + r.Next(0, 21));
            
            if (obriralfinalitzar)
            {
                System.Diagnostics.Process.Start("explorer.exe", ruta);
            }
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
