using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.DTOs
{
    public class ReportesDashboardDTO
    {
        public ReportesDashboardDTO() { }
        public decimal FacuturacionTotal { get; set; }
        public int PedidosTotales { get; set; }
        public int CantidadClientes { get; set; }
        public decimal FacturacioPromedio { get; set; }
        public int Confirmados { get; set; }
        public int Pagados { get; set; }
        public int Cancelados { get; set; }
        public int Entregados { get; set; }
        public List<ReportesProductosDTO> Productos { get; set; }
        public List<ReportesClientesDTO> Personas { get; set; }
        public List<ReportesFomasPagoDTO> FormaPagos { get; set; }
        public List<ReportesFormasEntregaDTO> FormaEntregas { get; set; }
    }
}
