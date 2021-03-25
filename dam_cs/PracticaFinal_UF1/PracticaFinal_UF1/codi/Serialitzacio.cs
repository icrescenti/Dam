using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticaFinal_UF1
{
    class Serialitzacio
    {
        #region XML

        #region Guardar
        public static void Guardar(Club socis, string fitxer)
        {
            #region generacio i escriptura
            FileStream fs = new FileStream(fitxer, FileMode.Create, FileAccess.Write);
            #endregion

            try
            {
                XmlSerializer serialitzador = new XmlSerializer(typeof(Club));
                serialitzador.Serialize(fs, socis);
            }
            catch { }

            tencarfitxer(fs, true);

            Console.WriteLine("Informacio actualitzada...");
            Console.ReadLine();
        }

        #endregion

        #region Llegir
        public static Club Llegir(string fitxer)
        {
            Club cl = null;
            try
            {
                XmlSerializer serialitzador = new XmlSerializer(typeof(Club));
                FileStream lector;

                #region validacio i obrim lectura de el fitxer
                if (File.Exists(fitxer))
                    lector = new FileStream(fitxer, FileMode.Open, FileAccess.Read);
                else return null;
                #endregion

                //DESERIALITZACIO
                cl = (Club)serialitzador.Deserialize(lector);

                tencarfitxer(lector, false);
            }
            catch { }

            return cl;
        }

        #endregion

        #endregion

        #region Generics
        static void tencarfitxer(FileStream fs, bool escriptor)
        {
            if (escriptor) fs.Flush();
            fs.Close();
            fs.Dispose();
        }
        #endregion
    }
}
