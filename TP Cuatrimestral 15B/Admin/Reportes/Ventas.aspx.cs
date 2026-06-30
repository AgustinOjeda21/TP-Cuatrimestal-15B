using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Dominio.Entidades;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_15B.Admin.Reportes
{
    public partial class Ventas : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioProducto repositorioProducto;
        private readonly GestorProducto gestorProducto;
        private readonly RepositorioMarca repositorioMarca;
        private readonly GestorMarca gestorMarca;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        private readonly RepositorioProveedor repositorioProveedor;
        private readonly GestorProveedor gestorProveedor;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly RepositorioCarrito repositorioCarrito;
        private readonly RepositorioProductoCarrito repositorioProductoCarrito;
        private readonly GestorProductoCarrito gestorProductoCarrito;
        private readonly GestorCarrito gestorCarrito;
        private readonly GestorCategoria gestorCategoria;
        private readonly RepositorioEstadoCarrito repositorioEstadoCarrito;
        private readonly GestorEstadoCarrito gestorEstadoCarrito;
        private readonly RepositorioFormaPago repositorioFormaPago;
        private readonly GestorFormaPago gestorFormaPago;
        private readonly RepositorioFormaEntrega repositorioFormaEntrega;
        private readonly GestorFormaEntrega gestorFormaEntrega;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        private readonly RepositorioPedido repositorioPedido;
        private readonly GestorPedido gestorPedido;
        private readonly RepositorioDetallePedido repositorioDetallePedido;
        private readonly GestorDetallePedido gestorDetallePedido;
        private readonly RepositorioEstadoPedido repositorioEstadoPedido;
        private readonly GestorEstadoPedido gestorEstadoPedido;
        private readonly GestorReporte gestorReporte;


        public Ventas()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioProductoCarrito = new RepositorioProductoCarrito(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            repositorioMarca = new RepositorioMarca(context);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            repositorioProducto = new RepositorioProducto(context);
            repositorioCarrito = new RepositorioCarrito(context);
            repositorioFormaPago = new RepositorioFormaPago(context);
            repositorioFormaEntrega = new RepositorioFormaEntrega(context);
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
            repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);
            gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
            gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
            gestorProductoCarrito = new GestorProductoCarrito(repositorioProductoCarrito, gestorProducto);
            gestorCarrito = new GestorCarrito(repositorioCarrito, gestorEstadoCarrito, gestorProductoCarrito);
            gestorFormaPago = new GestorFormaPago(repositorioFormaPago);
            gestorFormaEntrega = new GestorFormaEntrega(repositorioFormaEntrega);
            repositorioPersona = new RepositorioPersona(context);
            gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
            repositorioEstadoPedido = new RepositorioEstadoPedido(context);
            gestorEstadoPedido = new GestorEstadoPedido(repositorioEstadoPedido);
            repositorioDetallePedido = new RepositorioDetallePedido(context);
            gestorDetallePedido = new GestorDetallePedido(repositorioDetallePedido, gestorFormaPago, gestorFormaEntrega, gestorDireccion);
            repositorioPedido = new RepositorioPedido(context);
            gestorPedido = new GestorPedido(repositorioPedido, gestorCarrito, gestorEstadoPedido, gestorPersona, gestorDetallePedido);
            gestorReporte = new GestorReporte(repositorioPedido, repositorioProductoCarrito);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FiltrosVentas"] = new Busqueda<Dominio.Entidades.Pedido>();
                RegisterAsyncTask(new PageAsyncTask(CargarVentas));

            }
        }
        private async Task CargarVentas()
        {
            var filtros = (Busqueda<Dominio.Entidades.Pedido>)Session["FiltrosVentas"];
            var resultado = await gestorReporte.DevolverVentas(filtros,ddlAgrupacion.SelectedValue);
            if (resultado is null) return;
            switch (ddlOrdenar.SelectedValue)
            {
                case "Recientes":
                    resultado = resultado.OrderByDescending(obj => obj.Fecha).ToList();
                    break;
                case "Viejos":
                    resultado = resultado.OrderBy(obj => obj.Fecha).ToList();
                    break;
                case "MayorCantidad":
                    resultado = resultado.OrderByDescending(obj => obj.CantidadPedidos).ToList();
                    break;
                case "MenorCantidad":
                    resultado = resultado.OrderBy(obj => obj.CantidadPedidos).ToList();
                    break;
                case "MayorFacturacion":
                    resultado = resultado.OrderByDescending(obj => obj.TotalIngresado).ToList();
                    break;
                case "MenorFacturacion":
                    resultado = resultado.OrderBy(obj => obj.TotalIngresado).ToList();
                    break;
                default:
                    break;
            }
            rptVentas.DataSource = resultado;
            rptVentas.DataBind();
            lblTotal.Text = resultado.Sum(obj => obj.TotalIngresado).ToString();
            lblPedidos.Text = resultado.Sum(obj => obj.CantidadPedidos).ToString();
            lblPromedio.Text = resultado.Average(obj => obj.TotalIngresado).ToString();
        }
        public async void btnGenerar_Click(object sender, EventArgs e)
        {
            Busqueda<Dominio.Entidades.Pedido> busqueda = (Busqueda<Dominio.Entidades.Pedido>)Session["FiltrosVentas"];
            busqueda.Filtros.Clear();
            if (!string.IsNullOrEmpty(txtDesde.Text) && !string.IsNullOrEmpty(txtHasta.Text))
            {
                var filtro = new FiltroBusqueda<Dominio.Entidades.Pedido, DateTime>
                {
                    Selector = obj => obj.DetallePedido.FechaPedido,
                    Operador = OperadorBusqueda.Entre,
                    Valor = DateTime.Parse(txtDesde.Text),
                    ValorHasta = DateTime.Parse(txtHasta.Text)
                };
                busqueda.Filtros.Add(filtro);
            }
            await CargarVentas();
        }

    }
}