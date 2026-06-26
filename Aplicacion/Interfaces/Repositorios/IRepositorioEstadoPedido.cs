using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioEstadoPedido
    {
        Task<List<EstadoPedido>> ObtenerEstadosPedido();

        Task InsertarEstadoPedido(EstadoPedido aut);

        Task<List<EstadoPedido>> Buscar(Busqueda<EstadoPedido> busqueda);
        Task<EstadoPedido> CapturarEstadoPedido(int id);

        Task Actualizar(EstadoPedido obj);
        
    }
}
