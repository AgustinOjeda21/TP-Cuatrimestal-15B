using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class EstadoCarritoExtension
    {
        public static EstadoCarrito ToDomain(this EntityEstadoCarrito estadoCarrito)
        {
            return new EstadoCarrito(estadoCarrito.IdEstadoCarrito, estadoCarrito.Nombre);
        }
        public static EntityEstadoCarrito ToEntity(this EstadoCarrito estadoCarrito)
        {
            return new EntityEstadoCarrito(estadoCarrito.IdEstadoCarrito, estadoCarrito.Nombre);
        }
    }
}
