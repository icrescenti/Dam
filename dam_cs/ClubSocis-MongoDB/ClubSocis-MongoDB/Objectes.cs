using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocis_MongoDB
{
    public class Pista
    {
        public int numero_pista { get; set; }

        public string tipus { get; set; }
        public bool llum { get; set; }
    }

    public class Soci
    {
        public int numero_soci { get; set; }

        public string nom { get; set; }
        public string cognom { get; set; }
        public string dni { get; set; }
        public bool federat { get; set; }
    }
}
