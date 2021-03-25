using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;
using Datos.Repositoris;
using Negocio.EntitiesDTO;

namespace Negocio.Managment
{
    public class LibroManagament
    {
        public List<LibrosDTO> ObtenerLibros()
        {
            List<Libro> LibrosDatos = new Datos.Repositoris.LibroRepository().ObtenerLibros();
            List<LibrosDTO> ListadoRetorno = new List<LibrosDTO>();

            foreach (var item in LibrosDatos)
            {
                var dto = new LibrosDTO();
                dto.idLibro = item.idLibro;
                dto.Nombre = item.Nombre;
                dto.Autor = item.Autor;
                dto.FechaPublicacion = item.FechaPublicacion;
                dto.idCategoria = item.idCategoria;
                ListadoRetorno.Add(dto);
            }
            return ListadoRetorno;
        }
        
        
        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<Categoria> LibrosDatos = new Datos.Repositoris.LibroRepository().ObtenerCategorias();
            List<CategoriaDTO> ListadoRetorno = new List<CategoriaDTO>();

            foreach (var item in LibrosDatos)
            {
                var dto = new CategoriaDTO();
                dto.Nombre = item.Nombre;
                dto.idCategoria = item.idCategoria;
                ListadoRetorno.Add(dto);
            }
            return ListadoRetorno;
        }


        public void AltaLibro(LibrosDTO libroAlta)
        {
            Libro LibroBaseDatos = new Libro();
            LibroBaseDatos.idCategoria = libroAlta.idCategoria;
            LibroBaseDatos.Nombre = libroAlta.Nombre;
            LibroBaseDatos.Autor = libroAlta.Autor;
            LibroBaseDatos.FechaPublicacion = libroAlta.FechaPublicacion;
            new Datos.Repositoris.LibroRepository().AltaLibro(LibroBaseDatos);
        }


        public void ModificarLibro(LibrosDTO llibreModificat)
        {
            Libro LibroBaseDatos = new Libro();
            LibroBaseDatos.idLibro = llibreModificat.idLibro;
            LibroBaseDatos.idCategoria = llibreModificat.idCategoria;
            LibroBaseDatos.Nombre = llibreModificat.Nombre;
            LibroBaseDatos.Autor = llibreModificat.Autor;
            LibroBaseDatos.FechaPublicacion = llibreModificat.FechaPublicacion;

            new Datos.Repositoris.LibroRepository().ModificarLibro(LibroBaseDatos);
        }

        public void EliminarLibro(LibrosDTO libroEliminar)
        {
            new Datos.Repositoris.LibroRepository().EliminarLibro(libroEliminar.idLibro);
        }

        public bool verificarUnidades(Int32 idLibro)
        {
            return new Datos.Repositoris.LibroRepository().verificarUnidades(idLibro);
        }


        public List<LibroConUnidadesDTO> ObtenerLibrosUnidades()
        {
            List<ObtenerLibrosConUnidades_Result> LibrosDatos = new Datos.Repositoris.LibroRepository().ObtenerLibrosConUnidades();
            List<LibroConUnidadesDTO> ListadoRetorno = new List<LibroConUnidadesDTO>();

            foreach (var item in LibrosDatos)
            {
                var dto = new LibroConUnidadesDTO();
                dto.AutorDelLibro = item.AutorDelLibro;
                dto.NombreDelLibro = item.NombreDelLibro;
                dto.Unidades = item.Unidades;
                ListadoRetorno.Add(dto);
            }
            return ListadoRetorno;
        }
    }
}
