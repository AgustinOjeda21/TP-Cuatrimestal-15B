using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class ProductoExtension
    {
        public static Producto ToDomain(this EntityProducto producto)
        {
            return new Producto(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Estado, producto.Marca.ToDomain());
        }
        public static EntityProducto ToEntity(this Producto producto)
        {
            return new EntityProducto(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Estado, producto.Marca.IdMarca);
        }
    }
}
