using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class CarritoExtension
    {
        public static Carrito ToDomain(this EntityCarrito carrito)
        {
            return new Carrito(carrito.IdCarrito, carrito.Total, carrito.EstadoCarrito.ToDomain());
        }
        public static EntityCarrito ToEntity(this Carrito carrito)
        {
            return new EntityCarrito(carrito.IdCarrito, carrito.Total,carrito.EstadoCarrito.IdEstadoCarrito);
        }
    }
}
