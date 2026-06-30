using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.DTOs;
using Aplicacion.Busqueda;
using Dominio.Entidades;

namespace Aplicacion.Gestores
{
    public class GestorReporte
    {
        IRepositorioPedido repoPedido;
        IRepositorioProductoCarrito repoDetalle;
        public GestorReporte(IRepositorioPedido repoPedido, IRepositorioProductoCarrito repoDetalle)
        {
            this.repoPedido = repoPedido;
            this.repoDetalle = repoDetalle;
        }

        public async Task<List<ReportesPedidoDTO>> DevolverPedidos(Busqueda<Pedido> busqueda)
        {
            var lista = await repoPedido.Buscar(busqueda);
            if (lista.Count() == 0) return null;
            List<ReportesPedidoDTO> listaDevolver = new List<ReportesPedidoDTO>();
            foreach (var pedido in lista)
            {
                ReportesPedidoDTO reporte = new ReportesPedidoDTO
                {
                    IdPedido = pedido.IdPedido,
                    Cliente = $"{pedido.Persona.Nombre} {pedido.Persona.Apellido}",
                    Estado = pedido.EstadoPedido.Nombre,
                    FormaPago = pedido.DetallePedido.FormaPago.Nombre,
                    FormaEntrega = pedido.DetallePedido.FormaEntrega.Nombre,
                    Importe = pedido.Carrito.Total,
                    FechaPedido = pedido.DetallePedido.FechaPedido
                };
                listaDevolver.Add(reporte);
            }
            return listaDevolver;
        }
        public async Task<List<ReportesClientesDTO>> DevolverClientes(Busqueda<Pedido> busqueda)
        {
            var lista = await repoPedido.Buscar(busqueda);
            if (lista.Count() == 0) return null;
            Dictionary<int, ReportesClientesDTO> clientes = new Dictionary<int, ReportesClientesDTO>();
            foreach (var pedido in lista)
            {
                if (!clientes.ContainsKey(pedido.Persona.IdPersona))
                {
                    clientes.Add(pedido.Persona.IdPersona, new ReportesClientesDTO
                    {
                        Cliente = $"{pedido.Persona.Nombre} {pedido.Persona.Apellido}",
                        CantidadPedidos = 0,
                        TotalIngresado = 0
                    });
                }
                clientes[pedido.Persona.IdPersona].CantidadPedidos++;
                clientes[pedido.Persona.IdPersona].TotalIngresado += pedido.Carrito.Total;
            }
            return clientes.Values.ToList();
        }

        public async Task<List<ReportesVentasDTO>> DevolverVentas(Busqueda<Pedido> busqueda, string agrupacion)
        {
            string Clave = "";
            var filtro = new FiltroBusqueda<Dominio.Entidades.Pedido, string>
            {
                Selector = obj => obj.EstadoPedido.Nombre,
                Operador = OperadorBusqueda.Igual,
                Valor = "Pagado",
            };
            busqueda.Filtros.Add(filtro);
            var lista = await repoPedido.Buscar(busqueda);
            if (lista.Count() == 0) return null;
            Dictionary<string, ReportesVentasDTO> ventas = new Dictionary<string, ReportesVentasDTO>();
            foreach (var pedido in lista)
            {
                switch (agrupacion)
                {
                    case "Dia":
                        Clave = pedido.DetallePedido.FechaPedido.ToString("yyyy-MM-dd");
                        break;
                    case "Mes":
                        Clave = pedido.DetallePedido.FechaPedido.ToString("yyyy-MM");
                        break;
                    case "Año":
                        Clave = pedido.DetallePedido.FechaPedido.Year.ToString("yyyy");
                        break;
                    default:
                        break;
                }
                if (!ventas.ContainsKey(Clave))
                {
                    ventas.Add(Clave, new ReportesVentasDTO
                    {
                        Fecha = Clave,
                        CantidadPedidos = 0,
                        TotalIngresado = 0
                    });
                }
                ventas[Clave].CantidadPedidos++;
                ventas[Clave].TotalIngresado += pedido.Carrito.Total;
            }
            return ventas.Values.ToList();
        }

        public async Task<List<ReportesProductosDTO>> DevolverProductos()
        {
            var lista = await repoPedido.ObtenerPedidoes();
            if (lista.Count() == 0) return null;
            Dictionary<int, ReportesProductosDTO> productos = new Dictionary<int, ReportesProductosDTO>();
            foreach (var pedido in lista)
            {
                Busqueda<ProductoCarrito> busquedaProducto = new Busqueda<ProductoCarrito>();
                var filtro = new FiltroBusqueda<ProductoCarrito, int>
                {
                    Selector = obj => obj.Carrito.IdCarrito,
                    Operador = OperadorBusqueda.Igual,
                    Valor = pedido.Carrito.IdCarrito,
                };
                busquedaProducto.Filtros.Add(filtro);
                var listaProductos = await repoDetalle.Buscar(busquedaProducto);
                foreach (var pro in listaProductos)
                {
                    if (!productos.ContainsKey(pro.Producto.IdProducto))
                    {
                        productos.Add(pro.Producto.IdProducto, new ReportesProductosDTO
                        {
                            IdProducto = pro.Producto.IdProducto,
                            Producto = pro.Producto.Nombre,
                            Stock = pro.Producto.Stock,
                            TotalVendido = 0,
                            TotalIngresado = 0,
                            IdMarca = pro.Producto.Marca.IdMarca,
                            Marca = pro.Producto.Marca.Nombre
                            
                        });
                    }
                    productos[pro.Producto.IdProducto].TotalVendido+=pro.Cantidad;
                    productos[pro.Producto.IdProducto].TotalIngresado += (pro.Cantidad*pro.Producto.Precio);
                }
            }
            return productos.Values.ToList();
        }

        public async Task<List<ReportesFomasPagoDTO>> DevolverFormasPago()
        {
            var lista = await repoPedido.ObtenerPedidoes();
            if (lista.Count() == 0) return null;
            Dictionary<int, ReportesFomasPagoDTO> formas = new Dictionary<int, ReportesFomasPagoDTO>();
            foreach (var pedido in lista)
            {
                if (!formas.ContainsKey(pedido.DetallePedido.FormaPago.IdFormaPago))
                {
                    formas.Add(pedido.DetallePedido.FormaPago.IdFormaPago, new ReportesFomasPagoDTO
                    {
                        FormaPago = pedido.DetallePedido.FormaPago.Nombre,
                        CantidadPedidos = 0,
                        TotalIngresado = 0
                    });
                }
                formas[pedido.DetallePedido.FormaPago.IdFormaPago].CantidadPedidos++;
                formas[pedido.DetallePedido.FormaPago.IdFormaPago].TotalIngresado += pedido.Carrito.Total;
            }
            return formas.Values.ToList();
        }
        public async Task<List<ReportesFormasEntregaDTO>> DevolverFormasEntrega()
        {
            var lista = await repoPedido.ObtenerPedidoes();
            if (lista.Count() == 0) return null;
            Dictionary<int, ReportesFormasEntregaDTO> formas = new Dictionary<int, ReportesFormasEntregaDTO>();
            foreach (var pedido in lista)
            {
                if (!formas.ContainsKey(pedido.DetallePedido.FormaEntrega.IdFormaEntrega))
                {
                    formas.Add(pedido.DetallePedido.FormaEntrega.IdFormaEntrega, new ReportesFormasEntregaDTO
                    {
                        FormaEntrega = pedido.DetallePedido.FormaEntrega.Nombre,
                        CantidadPedidos = 0,
                        TotalIngresado = 0
                    });
                }
                formas[pedido.DetallePedido.FormaEntrega.IdFormaEntrega].CantidadPedidos++;
                formas[pedido.DetallePedido.FormaEntrega.IdFormaEntrega].TotalIngresado += pedido.Carrito.Total;
            }
            return formas.Values.ToList();
        }
        public async Task<ReportesDashboardDTO> DevolverDashboard(Busqueda<Pedido> busqueda)
        {
            var lista = await repoPedido.ObtenerPedidoes();
            if (lista.Count() == 0) return null;
            ReportesDashboardDTO reportes = new ReportesDashboardDTO();
            reportes.Cancelados = lista.Count(obj => obj.EstadoPedido.Nombre == "Cancelado");
            reportes.Pagados = lista.Count(obj => obj.EstadoPedido.Nombre == "Pagado");
            reportes.Entregados = lista.Count(obj => obj.EstadoPedido.Nombre == "Entregado");
            reportes.Confirmados = lista.Count(obj => obj.EstadoPedido.Nombre == "Confirmado");
            reportes.PedidosTotales = lista.Count();
            reportes.FacuturacionTotal = lista.Sum(obj=> obj.Carrito.Total);
            reportes.FacturacioPromedio = lista.Average(obj => obj.Carrito.Total);
            reportes.Productos = await DevolverProductos();
            reportes.Personas = await DevolverClientes(busqueda);
            reportes.Productos = reportes.Productos.OrderByDescending(x => x.TotalIngresado).Take(5).ToList();
            reportes.Personas = reportes.Personas.OrderByDescending(x => x.TotalIngresado).Take(5).ToList();
            reportes.FormaEntregas = await DevolverFormasEntrega();
            reportes.FormaPagos = await DevolverFormasPago();
            return reportes;
        }
    }
}
