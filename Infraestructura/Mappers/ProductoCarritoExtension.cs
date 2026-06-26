using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class ProductoCarritoExtension
    {
        public static ProductoCarrito ToDomain(this EntityProductoCarrito productoCarrito)
        {
            return new ProductoCarrito(productoCarrito.Cantidad, productoCarrito.Carrito.ToDomain(), productoCarrito.Producto.ToDomain());
        }
        public static EntityProductoCarrito ToEntity(this ProductoCarrito productoCarrito)
        {
            return new EntityProductoCarrito(productoCarrito.Producto.IdProducto,productoCarrito.Cantidad, productoCarrito.Carrito.IdCarrito);
        }
    }
}
