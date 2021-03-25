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
    public class CategoriaManagment
    {
        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<Categoria> CategoriasDatos = new Datos.Repositories.CategoriaRepository().ObtenerCategorias();
            List<CategoriaDTO> ListadoRetorno = new List<CategoriaDTO>();

            foreach (var item in CategoriasDatos)
            {
                var dto = new CategoriaDTO();
                dto.Nombre = item.Nombre;
                dto.idCategoria = item.idCategoria;
                ListadoRetorno.Add(dto);
            }
            return ListadoRetorno;
        }


        public void AltaCategoria(CategoriaDTO CategoriaAlta)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = CategoriaAlta.Nombre;

            new Datos.Repositories.CategoriaRepository().AltaCategoria(categoria);
        }


        public void ModificarCategoria(CategoriaDTO llibreModificat)
        {
            Categoria CategoriaBaseDatos = new Categoria();
            CategoriaBaseDatos.idCategoria = llibreModificat.idCategoria;
            CategoriaBaseDatos.Nombre = llibreModificat.Nombre;

            new Datos.Repositories.CategoriaRepository().ModificarCategoria(CategoriaBaseDatos);
        }

        public void EliminarCategoria(CategoriaDTO CategoriaEliminar)
        {
            //new Datos.Repositories.CategoriaRepository().EliminarCategoria(CategoriaEliminar.idCategoria);
        }
    }
}
