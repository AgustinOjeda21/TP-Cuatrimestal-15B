using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ProductoCarrito
    {
        public ProductoCarrito() { }
        public ProductoCarrito(int cantidad, Carrito carrito, Producto producto)
        {
            Cantidad = cantidad;
            Carrito = carrito;
            Producto = producto;
        }
        public int Cantidad { get; set; }
        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
