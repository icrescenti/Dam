using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
//LLIBRERIA AMB ELS OBJECTES CREATS
using ObjectesSerialitzacioXML;

namespace Exercici_Serialitzacio
{
    class Program
    {
        static void Main(string[] args)
        {
            string fitxer = rutaperfitxer(Environment.CurrentDirectory, "concessionaris.xml");

            #region valida que el fitxer es pot crear
            if (fitxer == null)
            {
                Console.WriteLine("ERROR!! No es pot guardar el fitxer, comprova que tens tots els permisos necessaris.");
                Environment.Exit(0);
            }
            #endregion

            #region Generem els objectes

            Cotxe[] obj_cotxes = {
                new Cotxe("Volkswagen", "Polo 1.0 EVO 80 Advance 5p", 16935.0f, 5),
                new Cotxe("Volkswagen", "T-Cross Sport 1.0", 21110.0f, 0),
                new Cotxe("Volkswagen", "Touran 1.5 TSI EVO Advance", 23290.0f, 3)
            };

            Concessionari obj_concessionari = new Concessionari("Volkswagen", "Bescanó", obj_cotxes);
            
            #endregion

            //ESCRIPTURA
            Guardar(obj_concessionari, fitxer);
            //LECTURA
            obj_concessionari = Llegir(fitxer);

            if (obj_concessionari!=null) Console.WriteLine("{0}", obj_concessionari.ToString());
            
            Console.WriteLine("Informacio emmegatzemada correctament.");
            Console.ReadLine();
        }
        
        #region Guardar
        static void Guardar(Concessionari objte, string ruta)
        {
            //Definim el objecte que ens permet serialitzar amb xml
            //Inicialitzat el serialitzador amb el tipus de el objecte Concessionari
            XmlSerializer serialitzador = new XmlSerializer(typeof(Concessionari));

            #region generacio i escriptura
            //Obrim un fitxer en mode de escriptura
            FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write);

            //Serialitzaem el objecte a el filestrem
            serialitzador.Serialize(fs, objte);

            #endregion

            #region metodes per tencar, netejar i deixar de utilitzar el fitxer
            fs.Flush();
            fs.Close();
            fs.Dispose();
            #endregion

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
        
        static string rutaperfitxer(string ruta, string nom, bool sobreescriure = true)
        {
            string complert = ruta + "\\" + nom;
            
            if (Directory.Exists(ruta))
                if (sobreescriure || !File.Exists(complert))
                    return complert;

            return null;

        }
    }
}
