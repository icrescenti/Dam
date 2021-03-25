using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicis0
{
    class condicionals
    {
        public static void mesnumerolletres()
        {
            Console.Write("Inserir numero del mes: ");
            int mes = int.Parse(Console.ReadLine()); ;

            //AQUI BASICAMENT CREO UN OBJETCE DE DATA AMB EL MES SELECCIONAT, EL CONVERTEIXO EN STRING AMB EL FORMAT ADIENT
            Console.WriteLine("El mes "+ mes + " es " + new DateTime(2020, mes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("ca")));
            Console.ReadLine();
        }
        
        public static void multiple()
        {
            #region variables i definicio
            Console.Write("Inserir primer valor: ");
            int valor1 = int.Parse(Console.ReadLine());

            Console.Write("Inserir segon valor: ");
            int valor2 = int.Parse(Console.ReadLine());
            #endregion

            #region comprovant
            if (valor1%valor2 == 0)
            {
                Console.WriteLine("Els valors son multiples");
            }
            else
            {
                Console.WriteLine("Els valors NO son multiples");
            }
            #endregion

            Console.ReadLine();
        }

        public static void valormesgran()
        {
            #region variables i declaracio
            int valor1 = 0, valor2 = 0, valor3 = 0;

            Console.Write("Inserir el primer valor: ");
            int.TryParse(Console.ReadLine(), out valor1);
            
            Console.Write("Inserir el segon valor: ");
            int.TryParse(Console.ReadLine(), out valor2);
            
            Console.Write("Inserir el tercer valor: ");
            int.TryParse(Console.ReadLine(), out valor3);
            #endregion

            #region comparacio
            if (valor1 > valor2 && valor1 > valor3)
            {
                Console.WriteLine("El numero " + valor1 + " es el mes gran");
            }
            else if (valor2 > valor1 && valor2 > valor3)
            {
                Console.WriteLine("El numero " + valor2 + " es el mes gran");
            }
            else
            {
                Console.WriteLine("El numero " + valor3 + " es el mes gran");
            }
            #endregion

            Console.ReadLine();
        }
    
        public static void notes()
        {
            #region variables i defiicio
            int nota = 0;

            Console.Write("Inserir nota: ");
            nota = int.Parse(Console.ReadLine());
            #endregion

            #region codi
            if (nota < 5)
            {
                Console.Write("Desafortunadament l'alumne ha ");
                if (nota <= 3)
                {
                    Console.Write("Suspes");
                }
                else if (nota == 4)
                {
                    Console.Write("adquirit un Insuficient");
                }
            }
            else
            {
                Console.Write("Gratament l'alumne ha ");
                if (nota == 5)
                {
                    Console.Write("superat el curs amb un Suficient");
                }
                else if (nota == 6)
                {
                    Console.Write("realitzat el curs Be");
                }
                else if (nota == 7 || nota == 8)
                {
                    Console.Write("adquirit un Notable");
                }
                else if (nota == 9)
                {
                    Console.Write("adquirit un Excel·lent");
                }
                else if (nota == 10)
                {
                    Console.Write("finalitzat el curs amb Matricula");
                }
            }
            #endregion

            Console.ReadLine();
            
        }
    
        
    }
}
