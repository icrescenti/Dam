using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.Repositoris
{
    public class LibroRepository
    {

        public List<Libro> ObtenerLibros()
        {
            List<Libro> listadoRetorno = new List<Libro>();

            try
            {
                using (var contexto = new icrescentidbEntities())
                {
                    listadoRetorno = contexto.Libros.ToList();
                }

                return listadoRetorno;
            }
            catch
            {
                return listadoRetorno;
            }

        }


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


        public List<ObtenerLibrosConUnidades_Result> ObtenerLibrosConUnidades()
        {
            List<ObtenerLibrosConUnidades_Result> listadoRetorno = new List<ObtenerLibrosConUnidades_Result>();

            try
            {
                using (var contexto = new icrescentidbEntities())
                {
                    listadoRetorno = contexto.ObtenerLibrosConUnidades().ToList();
                }

                return listadoRetorno;
            }
            catch
            {
                return listadoRetorno;
            }

        }

        public void AltaLibro(Libro libroAlta)
        {
            using (var contexto = new icrescentidbEntities())
            {
                contexto.Libros.Add(libroAlta);
                contexto.SaveChanges();
            }
        }

        public void ModificarLibro(Libro nouLlibre)
        {
            try
            {
                using (var contexto = new icrescentidbEntities())
                {
                    Libro llibreOriginal = contexto.Libros.Where(b => b.idLibro == nouLlibre.idLibro).First();
                    llibreOriginal.Nombre = nouLlibre.Nombre;
                    llibreOriginal.Autor = nouLlibre.Autor;
                    llibreOriginal.idCategoria = nouLlibre.idCategoria;

                    contexto.Entry(llibreOriginal).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarLibro(Int32 idLibro)
        {
            using (var contexto = new icrescentidbEntities())
            {
                List<LibrosUnidade> libroConUnidades = contexto.LibrosUnidades.Where(b => b.idLibro == idLibro).ToList();
                Libro libroEliminar = contexto.Libros.Where(b => b.idLibro == idLibro).First();

                if (libroConUnidades.Count > 0)
                {
                    contexto.LibrosUnidades.RemoveRange(libroConUnidades);
                }

                contexto.Entry(libroEliminar).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public bool verificarUnidades(Int32 idLibro)
        {
            List<LibrosUnidade> libroConUnidades = new List<LibrosUnidade>();

            using (var contexto = new icrescentidbEntities())
            {
                libroConUnidades = contexto.LibrosUnidades.Where(b => b.idLibro == idLibro).ToList();

                if (libroConUnidades.Count > 0) return false;
                else return true;
            }
        }

    }
}
