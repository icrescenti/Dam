using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio.Managment
{
    public class ProvaDeConexio
    {
        public bool provaDeConexio()
        {
            return new Datos.Repositoires.PruebaDeConexion().Connectar();
        }
    }
}
