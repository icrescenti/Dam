using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace ApuntsExamen1
{
    class Program
    {
        static string fitxer = "ape.txt";
        FileStream fs = new FileStream(fitxer, FileMode.Create, FileAccess.Write);

        static void Main(string[] args)
        {
        }

        void SerialitzacioGuardarBinaria(object objecte)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, objecte);
            tencarFitxer();
        }

        void SerialitzacioGuardarSOAP(object objte)
        {
            SoapFormatter serialitzador = new SoapFormatter();
            serialitzador.Serialize(fs, objte);
        }

        void SerialitzacioGuardarXML(object objte)
        {
            try
            {
                XmlSerializer serialitzador = new XmlSerializer(typeof(objte));
                serialitzador.Serialize(fs, objte);
            }
            catch { }
        }

        static object Llegir(object objte, string rutafitxer)
        {
            try
            {
                XmlSerializer serialitzador = new XmlSerializer(typeof(object));
                FileStream lector;

                if (File.Exists(rutafitxer))
                    lector = new FileStream(rutafitxer, FileMode.Open, FileAccess.Read);
                else return null;

                //DESERIALITZACIO
                objte = (object)serialitzador.Deserialize(lector);

                lector.Close();
                lector.Dispose();
            }
            catch { }

            return objte;
        }

        void tencarFitxer()
        {
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
    }
}
