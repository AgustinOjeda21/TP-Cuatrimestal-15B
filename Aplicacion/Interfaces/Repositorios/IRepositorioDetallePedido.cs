using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioDetallePedido
    {
        Task<List<DetallePedido>> ObtenerDetallePedidoes();
        Task InsertarDetallePedido(DetallePedido aut);
        Task<DetallePedido> CapturarDetallePedido(int id);
        Task Actualizar(DetallePedido obj);
        
    }
}
