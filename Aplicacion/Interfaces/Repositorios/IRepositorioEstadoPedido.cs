using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioEstadoPedido
    {
        Task<List<EstadoPedido>> ObtenerEstadosPedido();

        Task InsertarEstadoPedido(EstadoPedido aut);


        Task<EstadoPedido> CapturarEstadoPedido(int id);

        Task Actualizar(EstadoPedido obj);
        
    }
}
