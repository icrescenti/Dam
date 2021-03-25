using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.Repositoires
{
    public class PruebaDeConexion
    {
        public bool Connectar()
        {
            try
            {
                var contexto = new icrescentidbEntities();
                List<Libro> llibre = contexto.Libros.ToList();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
