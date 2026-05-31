using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pedido
    {
        public Pedido() { }
        public Pedido(int idPedido,Carrito carrito, DetallePedido detalle, EstadoPedido estado, Persona persona)
        {
            IdPedido = idPedido;
            Carrito = carrito;
            DetallePedido = detalle;
            EstadoPedido = estado;
            Persona = persona;
        }
        public int IdPedido { get; set; }
        public Carrito Carrito { get; set; }
        public DetallePedido DetallePedido { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public Persona Persona { get; set; }
    }
}
