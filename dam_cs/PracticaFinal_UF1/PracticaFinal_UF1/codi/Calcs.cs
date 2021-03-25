using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal_UF1
{
    public class Calcs
    {
        public static int edat(DateTime data)
        {
            DateTime ara = DateTime.Now;
            return ara.Year - data.Year;
        }
        public static double quota(int edat, bool federat)
        {
            double quantitat;

            if (edat < 16) quantitat = 50;
            else if (edat > 16 && edat < 65) quantitat = 75;
            else quantitat = 25;

            if (federat)
            {
                double descomptePercentatge, descompte;

                descomptePercentatge = 5;
                descomptePercentatge = descomptePercentatge / 100;
                descompte = quantitat * descomptePercentatge;
                quantitat = quantitat - descompte;
            }

            return quantitat;
        }
    }
}
