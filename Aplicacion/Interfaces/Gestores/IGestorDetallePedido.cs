using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using Aplicacion.Busqueda;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorDetallePedido
    {
        Task<Result<DetallePedido>> CargarDetallePedido(DetallePedido edi);


        Task<DetallePedido> CapturarDetallePedido(int id);

        Task<List<DetallePedido>> DevolverDetallePedidos();


        Task<Result<DetallePedido>> ModificarFechaPedido(DateTime fecha, int id);


        Task<Result<DetallePedido>> ModificarFechaEntrega(DateTime fecha, int id);

        Task<Result<DetallePedido>> ModificarDireccion(Direccion direccion, int id);

        Task<Result<DetallePedido>> ModificarFormaPago(FormaPago formaPago, int id);

        Task<Result<DetallePedido>> ModificarFormaEntrega(FormaEntrega formaEntrega, int id);


        Task<bool> ValidarDetallePedido(int id);

        Task<Result<DetallePedido>> ExisteDetallePedido(int id);
        
    }
}

