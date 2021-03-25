using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicis0
{
    class operacions
    {
        public static void nomedat()
        {
            //variable de edat
            int edat;

            //demana el nom
            Console.Write("Inserir el teu nom: ");
            string nom = Console.ReadLine();

            //demana la edat
            Console.Write("Quina edat tens nano? ");
            int.TryParse(Console.ReadLine(), out edat);

            //mostra el resultat per pantalla
            Console.WriteLine("NOM: " + nom + "\nEDAT: " + edat);
            Console.ReadLine();
        }
        
        public static void edat_previsora()
        {
            //variable de edat
            int edat;

            //demana el nom
            Console.Write("Inserir el teu nom: ");
            string nom = Console.ReadLine();

            //demana la edat
            Console.Write("Quina edat tens nano? ");
            int.TryParse(Console.ReadLine(), out edat);

            //mostra el resultat per pantalla
            Console.WriteLine("NOM: " + nom + "\nEDAT: " + edat);
            Console.WriteLine("D'aqui 5 anys tindras " + (edat+5));
            Console.WriteLine("D'aqui 10 anys tindras " + (edat + 10));
            Console.ReadLine();
        }
        
        public static void radi()
        {
            #region variables
            const float PI = 3.1415926535f;
            float area = 0.0f;
            int radi = 0;
            #endregion

            #region codi
            Console.Write("Inserir radi: ");
            int.TryParse(Console.ReadLine(), out radi);
            area = PI * radi * radi;
            Console.WriteLine("La area sera: " + area);
            Console.ReadLine();
            #endregion
        }
    
        public static void multiplicacio()
        {
            #region variables
            int primer_valor = 0, segon_valor = 0;
            #endregion

            Console.Write("Inserir el primer valor: ");
            int.TryParse(Console.ReadLine(), out primer_valor);
            Console.Write("Inserir el segon valor: ");
            int.TryParse(Console.ReadLine(), out segon_valor);
            Console.WriteLine("El producte de " + primer_valor + " i " + segon_valor + " es " + (primer_valor*segon_valor));
            Console.ReadLine();
        }
    
        public static void anyllum()
        {
            float segons_en_any = 365.2425f * 86400.0f;
            Console.WriteLine("Serien "+ (segons_en_any * 300000) +" KM que fa la llum en 1 segon");
            Console.ReadLine();
        }
    
        public static void forzaterra()
        {
            #region variables
            const float 
                G = 6.67E-11f,
                RADIT = 6370.0f,
                MT = 5.98E24f
            ;
            float
                forza = 0.0f,
                alcada = 0.0f
            ;
            #endregion

            #region input
            Console.Write("Inserir la alçada: ");
            float.TryParse(Console.ReadLine(), out alcada);
            #endregion

            forza = (float)Math.Pow( (G * MT * 1.0f)/(RADIT+alcada), 2.0);
            Console.WriteLine("La força que fa la terra sobre 1kg a la alçada de " + alcada + " es de " + forza);
            Console.ReadLine();
        }
    
        public static void rendacapit()
        {
            #region variables i calcul
            long capita = 4_000_000_000;
            int habitants = 6_857_125;
            float renda = (float)capita / habitants;
            #endregion

            Console.WriteLine("La renda per habitant sera: " + renda.ToString("0.00"));
            Console.ReadLine();
        }
    
        public static void multiplicarnen()
        {
            #region variables i definicio
            int numero1 = 0, numero2 = 0, resultat = 0;

            Console.Write("Inserir el pirmer valor: ");
            numero1 = int.Parse(Console.ReadLine());

            Console.Write("Inserir el segon valor: ");
            numero2 = int.Parse(Console.ReadLine());

            int calcul = numero1 * numero2;
            #endregion

            #region codi
            Console.WriteLine("Quina sera la seva multiplicaio?");
            resultat = int.Parse(Console.ReadLine());

            if (resultat == calcul)
            {
                Console.WriteLine("Molt be");
            }
            else
            {
                Console.WriteLine("No es correcte, torna a executar el programa.");
            }
            Console.ReadLine();
            #endregion
        }
    }
}
