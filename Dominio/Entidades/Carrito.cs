using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Carrito
    {
        public Carrito() { }
        public Carrito(int idCarrito, decimal total, EstadoCarrito estado, ICollection<Pedido> pedidos, ICollection<ProductoCarrito> productoCarritos)
        {
            IdCarrito = idCarrito;
            Total = total;
            EstadoCarrito = estado;
            Pedido = pedidos;
            ProductoCarrito = productoCarritos;
        }

        public int IdCarrito { get; set; }
        public decimal Total { get; set; }
        public virtual EstadoCarrito EstadoCarrito { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual ICollection<ProductoCarrito> ProductoCarrito { get; set; }
    }
}
