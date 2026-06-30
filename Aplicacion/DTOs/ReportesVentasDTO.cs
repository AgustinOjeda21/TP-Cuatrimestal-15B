using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ReportesVentasDTO
    {
        public string Fecha { get; set; }
        public int CantidadPedidos { get; set; }
        public decimal TotalIngresado { get; set; }
    }
}
