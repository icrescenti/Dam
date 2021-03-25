using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ObjectesSerialitzacio
{
    public class InteraccioFixerets
    {
        #region Guardar
        public static void Guardar(Concessionari objte, string ruta, bool formatsoap = false)
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
                try
                {
                    XmlSerializer serialitzador = new XmlSerializer(typeof(Concessionari));
                    serialitzador.Serialize(fs, objte);
                }
                catch { }
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
        public static Concessionari Llegir(Concessionari dyn_concessionari, string rutafitxer)
        {
            try
            {
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
            }
            catch { Console.WriteLine("Error, no es possible llegir el fitxeret"); Console.ReadLine(); }

            return dyn_concessionari;
        }

        #endregion
    }
}
