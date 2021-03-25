using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.Repositories
{
    public class CategoriaRepository
    {

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> listadoRetorno = new List<Categoria>();

            try
            {
                using (var contexto = new icrescentidbEntities())
                {
                    listadoRetorno = contexto.Categorias.ToList();
                }

                return listadoRetorno;
            }
            catch
            {
                return listadoRetorno;
            }

        }

        public void AltaCategoria(Categoria CategoriaAlta)
        {
            using (var contexto = new icrescentidbEntities())
            {
                contexto.Categorias.Add(CategoriaAlta);
                contexto.SaveChanges();
            }
        }

        public void ModificarCategoria(Categoria noucategoria)
        {
            try
            {
                using (var contexto = new icrescentidbEntities())
                {
                    Categoria categoriaOriginal = contexto.Categorias.Where(b => b.idCategoria == noucategoria.idCategoria).First();
                    categoriaOriginal.Nombre = noucategoria.Nombre;
                    categoriaOriginal.idCategoria = noucategoria.idCategoria;

                    contexto.Entry(categoriaOriginal).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
