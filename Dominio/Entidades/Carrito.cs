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
        public Carrito(int idCarrito, decimal total, EstadoCarrito estado)
        {
            IdCarrito = idCarrito;
            Total = total;
            EstadoCarrito = estado;
        }

        public int IdCarrito { get; set; }
        public decimal Total { get; set; }
        public EstadoCarrito EstadoCarrito { get; set; }
    }
}
