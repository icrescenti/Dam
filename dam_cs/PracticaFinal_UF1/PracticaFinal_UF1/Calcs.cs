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
        int quota_condicio(int edat)
        {
            if (edat < 16) return 50;
            else if (edat > 16 && edat < 65) return 75;
            else return 25;
        }
    }
}
