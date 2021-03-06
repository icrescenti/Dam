using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
//LLIBRERIA AMB ELS OBJECTES CREATS
using ObjectesSerialitzacio;

namespace Exercicis_Serialitzacio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool execucio = true;
            int opcio = 0;
            string fitxer = rutaperfitxer(Environment.CurrentDirectory, "concessionaris_estoc.xml");

            List<Cotxe> llista_estoc = new List<Cotxe>();
            Concessionari obj_concessionari = new Concessionari("Porsche", "Bescanó", llista_estoc);

            Console.OutputEncoding = Encoding.UTF8;

            #region lectura de arguments existents
            //LA SINTAXI ESPERADA SERIA:
            //Exercicis_Serialitzacio_2.exe --opcio 1
            if (args.Length>1 && args[0] == "--opcio")
            {
                int.TryParse(args[1], out opcio);
            }
            #endregion

            #region lectura en cas de fitxer existent
            if (File.Exists(fitxer))
                obj_concessionari = Llegir(fitxer);
            #endregion

            while (execucio)
            {
                #region solicita la opcio a l'usuari
                while (opcio == 0)
                {
                    Console.Clear();

                    Console.Write(
                        "Programa de gestio de Cotxes versio 1.0\n" +
                        "=================================================\n" +
                        "(1) Afegir cotxes a l'estoc\n" +
                        "(2) Mostrar un cotxe per l'estoc\n" +
                        "(3) Eliminar un cotxe per l'estoc\n" +
                        "(4) Eliminar el cotxe en una posició\n" +
                        "(5) Sortir de el programa\n" +
                        "=================================================\n" +
                        "Opcio: "
                        );

                    #region validacio de que la opcio es un valor numeric i correcta
                    if (int.TryParse(Console.ReadLine(), out opcio))
                    {
                        if (opcio < 1 || opcio > 5)
                        {
                            Console.WriteLine("La opcio " + opcio + " no es valida, siusplau utilitza una opcio valida");
                            opcio = 0;
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No has inserit un valor numeric.");
                        Console.ReadKey();
                    }
                    #endregion
                }
                #endregion

                #region executa la opcio solicitada
                switch (opcio)
                {
                    case 1: afegircotxes(obj_concessionari, fitxer); break;
                    case 2: mostrarcotxes(fitxer); break;
                    case 3: eliminarcotxeestoc(obj_concessionari, fitxer); break;
                    case 4: eliminarcotxeposicio(obj_concessionari, fitxer); break;
                    case 5: execucio = false; break;
                }
                #endregion

                opcio = 0;
            }
        }

        #region funcions del programa
        static void afegircotxes(Concessionari obj_concessionari, string fitxer)
        {
            string marca = "", model = "";
            float preu = 0;

            demanardades("AFEGIR COTXE A L'ESTOC", ref marca, ref model, ref preu);

            obj_concessionari.Estoc.Add(new Cotxe(marca, model, preu));

            Guardar(obj_concessionari, fitxer);
        }
        static void mostrarcotxes(string fitxer)
        {
            Concessionari dyncon = Llegir(fitxer);
            if (dyncon != null)
            {
                #region mostra els cotxes en stock
                Console.Clear();
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("|Cotxes actuals en estoc|");
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("{0}", dyncon.ToString());
                Console.ReadLine();
                #endregion
            }
        }
        static void eliminarcotxeestoc(Concessionari obj_concessionari, string fitxer)
        {
            string marca = "", model = ""; 
            float preu = 0;
            bool trobat = false;
            int i = 0;

            demanardades("ELIMINAR COTXE", ref marca, ref model, ref preu);

            Cotxe buscar = new Cotxe(marca, model, preu);

            while (!trobat && i< obj_concessionari.Estoc.Count)
            {
                if (
                    buscar.Marca == obj_concessionari.Estoc[i].Marca &&
                    buscar.Model == obj_concessionari.Estoc[i].Model
                    )
                {
                    trobat = true;
                }
                else
                    i++;
            }

            if (trobat)
            {
                obj_concessionari.Estoc.Remove(obj_concessionari.Estoc[i]);
                Guardar(obj_concessionari, fitxer);
            }
            else
            {
                Console.WriteLine("El cotxe a buscar no existeix en el fitxer");
                Console.ReadLine();
            }
        }
        static void eliminarcotxeposicio(Concessionari obj_concessionari, string fitxer)
        {
            int posicio = -1;

            #region solicita la posicio
            Console.Clear();
            Console.Write("El cotxe a eliminar en quina posicio es troba? (entre les posicions 1-" + obj_concessionari.Estoc.Count + "): ");
            while (!int.TryParse(Console.ReadLine(), out posicio))
            {
                Console.WriteLine("[X] Error, la posicio no es un valor numeric enter.");
                Console.Write("Posicio: ");
            }
            posicio--;
            #endregion

            if (posicio < obj_concessionari.Estoc.Count)
            {
                obj_concessionari.Estoc.RemoveAt(posicio);
                Guardar(obj_concessionari, fitxer);
            }
            else
            {
                Console.WriteLine("[X] La posico excedeix el nombre de cotxes, torna a intentar-ho");
                Console.ReadLine();
            }
        }
        #endregion

        #region Guardar
        static void Guardar(Concessionari objte, string ruta, bool formatsoap = false)
        {
            #region generacio i escriptura
            //Obrim un fitxer en mode de escriptura
            FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write);
            #endregion

            if (formatsoap)
            {
                SoapFormatter serialitzador = new SoapFormatter();
                serialitzador.Serialize(fs, objte);
            }
            else
            {
                //Definim el objecte que ens permet serialitzar amb xml
                //Inicialitzat el serialitzador amb el tipus de el objecte Concessionari
                XmlSerializer serialitzador = new XmlSerializer(typeof(Concessionari));
                serialitzador.Serialize(fs, objte);
            }

            #region metodes per tencar, netejar i deixar de utilitzar el fitxer
            fs.Flush();
            fs.Close();
            fs.Dispose();
            #endregion

            Console.WriteLine("Informacio actualitzada...");
            Console.ReadLine();
        }

        #endregion

        #region Llegir
        static Concessionari Llegir(string rutafitxer)
        {
            Concessionari dyn_concessionari = null;
            XmlSerializer serialitzador = new XmlSerializer(typeof(Concessionari));
            FileStream lector;

            #region validacio i obrim lectura de el fitxer
            if (File.Exists(rutafitxer))
                lector = new FileStream(rutafitxer, FileMode.Open, FileAccess.Read);
            else return null;
            #endregion

            //DESERIALITZACIO
            dyn_concessionari = (Concessionari)serialitzador.Deserialize(lector);

            #region tencament de el fitxer properament
            lector.Close();
            lector.Dispose();
            #endregion

            return dyn_concessionari;
        }

        #endregion

        #region altres
        
        static string rutaperfitxer(string ruta, string nom, bool sobreescriure = true)
        {
            string complert = ruta + "\\" + nom;

            if (Directory.Exists(ruta))
                if (sobreescriure || !File.Exists(complert))
                    return complert;

            return null;

        }

        static void demanardades(string titol, ref string marca, ref string model, ref float preu)
        {
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine(titol);
            Console.WriteLine("=======================");
            Console.Write("Marca de el cotxe: ");
            marca = Console.ReadLine();
            Console.Write("Model de el cotxe: ");
            model = Console.ReadLine();
            Console.Write("Preu de el cotxe: ");
            while (!float.TryParse(Console.ReadLine(), out preu))
            {
                Console.WriteLine("[X] Error, el preu no es un valor numeric decimal.");
                Console.Write("Preu de el cotxe: ");
            }
        }
        
        #endregion
    }
}
