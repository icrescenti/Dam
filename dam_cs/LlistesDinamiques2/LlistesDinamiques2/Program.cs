using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//LLIBRERIA AMB ELS OBJECTES CREATS
using ObjectesSerialitzacio;

namespace LlistesDinamiques2
{
    class Program
    {
        //EL MATEIX PROGRAMA ADAPTAT PER A PILES
        static void Main(string[] args)
        {
            bool execucio = true;
            int opcio = 0;
            string fitxer = rutaperfitxer(Environment.CurrentDirectory, "concessionaris_pila.xml");

            Stack<Cotxe> pila = new Stack<Cotxe>();
            Concessionari obj_concessionari = new Concessionari("Porsche", "Bescanó", pila);

            Console.OutputEncoding = Encoding.UTF8;

            #region lectura de arguments existents
            //LA SINTAXI ESPERADA SERIA:
            //Exercicis_Serialitzacio_2.exe --opcio 1
            if (args.Length > 1 && args[0] == "--opcio")
            {
                int.TryParse(args[1], out opcio);
            }
            #endregion

            #region lectura en cas de fitxer existent
            if (File.Exists(fitxer))
                obj_concessionari = InteraccioFixerets.Llegir(obj_concessionari, fitxer);
            #endregion

            while (execucio)
            {
                #region solicita la opcio a l'usuari
                while (opcio == 0)
                {
                    Console.Clear();

                    Console.Write(
                        "Programa de gestio de Cotxes versio 1.4\n" +
                        "=================================================\n" +
                        "(1) Afegir cotxes a la pila\n" +
                        "(2) Mostrar cotxes\n" +
                        "(3) Eliminar un cotxe de la pila\n" +
                        "(4) Sortir de el programa\n" +
                        "=================================================\n" +
                        "Opcio: "
                        );

                    #region validacio de que la opcio es un valor numeric i correcta
                    if (int.TryParse(Console.ReadLine(), out opcio))
                    {
                        if (opcio < 1 || opcio > 4)
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
                    case 1:
                        Concessionari.afegircotxes(obj_concessionari, fitxer);
                        InteraccioFixerets.Guardar(obj_concessionari, fitxer);
                        break;
                    case 2:
                        Concessionari.mostrarcotxes(obj_concessionari);
                        break;
                    case 3: 
                        Concessionari.eliminarcotxeestoc(obj_concessionari, fitxer);
                        break;
                    case 4: execucio = false; break;
                }
                #endregion

                opcio = 0;
            }
        }

        #region altres

        static string rutaperfitxer(string ruta, string nom, bool sobreescriure = true)
        {
            string complert = ruta + "\\" + nom;

            if (Directory.Exists(ruta))
                if (sobreescriure || !File.Exists(complert))
                    return complert;

            return null;

        }

        #endregion
    }
}

