using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class PedidoExtension
    {
        public static Pedido ToDomain(this EntityPedido pedido)
        {
            return new Pedido(pedido.IdPedido, pedido.Carrito.ToDomain(), pedido.DetallePedido.ToDomain(), pedido.EstadoPedido.ToDomain(), pedido.Persona.ToDomain());
        }
        public static EntityPedido ToEntity(this Pedido pedido)
        {
            return new EntityPedido(pedido.IdPedido, pedido.Carrito.IdCarrito, pedido.EstadoPedido.IdEstadoPedido, pedido.Persona.IdPersona);
        }
    }
}
