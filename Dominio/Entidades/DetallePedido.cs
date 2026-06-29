using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class DetallePedido
    {
        public DetallePedido() { }
        public DetallePedido(DateTime Fechapedido, DateTime Fechaentrega,Direccion direccion, FormaEntrega formaEntrega,FormaPago formaPago)
        {
            FechaPedido = Fechapedido;
            FechaEntrega = Fechaentrega;
            Direccion = direccion;
            FormaEntrega = formaEntrega;
            FormaPago = formaPago;
        }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Direccion Direccion { get; set; }
        public FormaEntrega FormaEntrega { get; set; }
        public FormaPago FormaPago { get; set; }
        public Pedido Pedido { get; set; }
    }
}
