using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioCategoria
    {
        Task<List<Categoria>> ObtenerCategoriaes();
        Task InsertarCategoria(Categoria aut);
        Task<Categoria> CapturarCategoria(int id);
        Task Actualizar(Categoria obj);
        
    }
}
