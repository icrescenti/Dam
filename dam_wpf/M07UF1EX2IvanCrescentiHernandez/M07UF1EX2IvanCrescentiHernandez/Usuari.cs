using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07UF1EX2IvanCrescentiHernandez
{
    public class Usuari
    {
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Usuari (string nom, string cognom, string passwordPla, string email)
        {
            this.Nom = nom;
            this.Cognom = cognom;
            this.Password = passwordPla;
            this.Email = email;
        }
    }
}
