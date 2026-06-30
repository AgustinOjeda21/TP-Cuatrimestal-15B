using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ReportesPedidoDTO
    {
        public ReportesPedidoDTO() { }
        public ReportesPedidoDTO(int id,string cliente,string estado, string formapago, string formaentrega, decimal importe,DateTime fecha)
        {
            IdPedido = id;
            Cliente = cliente;
            Estado = estado;
            FormaPago = formapago;
            FormaEntrega = formaentrega;
            Importe = importe;
            FechaPedido = fecha;
        }
        public int IdPedido { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; }
        public string FormaPago { get; set; }
        public string FormaEntrega { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
