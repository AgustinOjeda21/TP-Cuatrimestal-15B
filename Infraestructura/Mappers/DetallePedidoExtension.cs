using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class DetallePedidoExtension
    {
        public static DetallePedido ToDomain(this EntityDetallePedido detallePedido)
        {
            return new DetallePedido(detallePedido.FechaPedido, detallePedido.FechaEntrega, detallePedido.Direccion.ToDomain(), detallePedido.FormaEntrega.ToDomain(), detallePedido.FormaPago.ToDomain(), detallePedido.Pedido.ToDomain());
        }
        public static EntityDetallePedido ToEntity(this DetallePedido detallePedido)
        {
            return new EntityDetallePedido(detallePedido.FechaPedido, detallePedido.FechaEntrega, detallePedido.Direccion.IdDireccion, detallePedido.FormaEntrega.IdFormaEntrega, detallePedido.FormaPago.IdFormaPago, detallePedido.Pedido.IdPedido);
        }
    }
}
