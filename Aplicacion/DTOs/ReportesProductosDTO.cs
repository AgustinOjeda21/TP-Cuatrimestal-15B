using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ReportesProductosDTO
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int TotalVendido { get; set; }
        public decimal TotalIngresado { get; set; }
        public int Stock { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
    }
}
