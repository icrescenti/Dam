using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample.Entity
{
    public class Soci
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string Dni { get; set; }
        public int Federat { get; set; }
    }
}
