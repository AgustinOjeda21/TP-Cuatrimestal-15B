using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class EstadoPedidoExtension
    {
        public static EstadoPedido ToDomain(this EntityEstadoPedido estadoPedido)
        {
            return new EstadoPedido(estadoPedido.IdEstadoPedido, estadoPedido.Nombre, estadoPedido.Descripcion);
        }
        public static EntityEstadoPedido ToEntity(this EstadoPedido estadoPedido)
        {
            return new EntityEstadoPedido(estadoPedido.IdEstadoPedido, estadoPedido.Nombre, estadoPedido.Descripcion);
        }
    }
}
