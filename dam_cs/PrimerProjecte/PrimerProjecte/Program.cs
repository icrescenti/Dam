using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PrimerProjecte
{
    class Program
    {
        static void Main(string[] args)
        {
            #region parides
            Array.Clear(args, 0, args.Length);
            #endregion

            #region codi
            Console.WriteLine("Com et dius?");
            string nom = Console.ReadLine();
            Console.WriteLine("Benvingut/da "+nom);
            #endregion

            #region parida definitiva
            Console.WriteLine("Instalant malware " + nom + ".exe");
            Thread.Sleep(1000);
            while (true)
            {
                Console.WriteLine("_0x" + new Random().Next(1, 99999),UTF8Encoding.UTF8);
                Thread.Sleep(100);
            }
            #endregion
        }
    }
}
