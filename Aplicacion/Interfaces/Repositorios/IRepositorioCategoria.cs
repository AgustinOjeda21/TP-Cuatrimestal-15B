using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioCategoria
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task InsertarCategoria(Categoria aut);
        Task<Categoria> CapturarCategoria(int id);
        Task Actualizar(Categoria obj);
        Task Eliminar(int id);
        Task<List<Categoria>> Buscar(Busqueda<Categoria> busqueda);

    }
}
