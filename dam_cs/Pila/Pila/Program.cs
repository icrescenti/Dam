using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piles
{
    class Program
    {
        static void Main(string[] args)
        {
            Pila pila = new Pila();

            Random r = new Random();
            for (int i = 0; i < r.Next(5, 10); i++)
            {
                pila.Insertar(r.Next(0,11));
            }

            if (pila.ComprovarBuit())
            {
                Console.Write("Aqui algo no ha anat be");
            }
            else
            {
                Console.WriteLine("La pila tindra " + pila.Comptador() + " valors.");
                
                pila.Imprimir();

                Console.WriteLine("Extraiem de la pila:" + pila.Extreure());

                Console.WriteLine("Extraiem de la pila:" + pila.Extreure());
                pila.Imprimir();
            }
            Console.ReadKey();
        }
    }
}
