using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioEstadoCarrito
    {
        Task<List<EstadoCarrito>> ObtenerEstadosCarrito();

        Task InsertarEstadoCarrito(EstadoCarrito aut);

        Task<List<EstadoCarrito>> Buscar(Busqueda<EstadoCarrito> busqueda);
        Task<EstadoCarrito> CapturarEstadoCarrito(int id);

        Task Actualizar(EstadoCarrito obj);
        
         
    }
}
