using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Dominio.Entidades;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_15B.Admin.Reportes
{
    public partial class Pedidos : System.Web.UI.Page
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


        public Pedidos()
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
            gestorReporte = new GestorReporte(repositorioPedido,repositorioProductoCarrito);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FiltrosPedido"] = new Busqueda<Dominio.Entidades.Pedido>();
                RegisterAsyncTask(new PageAsyncTask(CargarFormasEntrega));
                RegisterAsyncTask(new PageAsyncTask(CargarFormasPago));
                RegisterAsyncTask(new PageAsyncTask(CargarEstados));
                RegisterAsyncTask(new PageAsyncTask(CargarPedidos));

            }
        }
        private async Task CargarPedidos()
        {
            var filtros = (Busqueda<Dominio.Entidades.Pedido>)Session["FiltrosPedido"];
            var resultado = await gestorReporte.DevolverPedidos(filtros);
            if (resultado is null) return;
            switch(ddlAgrupacion.SelectedValue)
            {
                case "FechaAntigua":
                    resultado = resultado.OrderBy(obj => obj.FechaPedido).ToList();
                    break;
                case "FechaReciente":
                    resultado = resultado.OrderByDescending(obj => obj.FechaPedido).ToList();
                    break;
                case "ImporteMayor":
                    resultado = resultado.OrderByDescending(obj => obj.Importe).ToList();
                    break;
                case "ImporteMenor":
                    resultado = resultado.OrderBy(obj => obj.Importe).ToList();
                    break;
                case "Cliente":
                    resultado = resultado.OrderBy(obj => obj.Cliente).ToList();
                    break;
                default:
                    break;
            }
            rptPedido.DataSource = resultado;
            rptPedido.DataBind();
            lblCancelados.Text = resultado.Count(obj => obj.Estado == "Cancelado").ToString();
            lblPagados.Text = resultado.Count(obj => obj.Estado == "Pagado").ToString();
            lblEntregados.Text = resultado.Count(obj => obj.Estado == "Entregado").ToString();
            lblConfirmados.Text = resultado.Count(obj => obj.Estado == "Confirmado").ToString();
        }
        private async Task CargarFormasEntrega()
        {
            var resultado = await gestorFormaEntrega.DevolverFormasEntrega();
            ddlFormaEntrega.DataSource = resultado;
            ddlFormaEntrega.DataTextField = "Nombre";
            ddlFormaEntrega.DataValueField = "IdFormaEntrega";
            ddlFormaEntrega.DataBind();
            ddlFormaEntrega.Items.Insert(0, new ListItem("Todas", ""));
        }
        private async Task CargarFormasPago()
        {
            var resultado = await gestorFormaPago.DevolverFormasPago();
            ddlFormaPago.DataSource = resultado;
            ddlFormaPago.DataTextField = "Nombre";
            ddlFormaPago.DataValueField = "IdFormaPago";
            ddlFormaPago.DataBind();
            ddlFormaPago.Items.Insert(0, new ListItem("Todas", ""));
        }
        private async Task CargarEstados()
        {
            var resultado = await gestorEstadoPedido.DevolverEstadosPedido();
            ddlEstado.DataSource = resultado;
            ddlEstado.DataTextField = "Nombre";
            ddlEstado.DataValueField = "IdEstadoPedido";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Todos", ""));
        }

        public async void btnGenerar_Click(object sender, EventArgs e)
        {
            Busqueda<Dominio.Entidades.Pedido> busqueda = (Busqueda<Dominio.Entidades.Pedido>)Session["FiltrosPedido"];
            busqueda.Filtros.Clear();
            if (!string.IsNullOrEmpty(ddlFormaEntrega.SelectedValue))
            {
                var filtro = new FiltroBusqueda<Dominio.Entidades.Pedido, int>
                {
                    Selector = obj => obj.DetallePedido.FormaEntrega.IdFormaEntrega,
                    Operador = OperadorBusqueda.Igual,
                    Valor = int.Parse(ddlFormaEntrega.SelectedValue),
                };
                busqueda.Filtros.Add(filtro);
            }
            if (!string.IsNullOrEmpty(ddlFormaPago.SelectedValue))
            {
                var filtro = new FiltroBusqueda<Dominio.Entidades.Pedido, int>
                {
                    Selector = obj => obj.DetallePedido.FormaPago.IdFormaPago,
                    Operador = OperadorBusqueda.Igual,
                    Valor = int.Parse(ddlFormaPago.SelectedValue),
                };
                busqueda.Filtros.Add(filtro);
            }
            if (!string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                var filtro = new FiltroBusqueda<Dominio.Entidades.Pedido, int>
                {
                    Selector = obj => obj.EstadoPedido.IdEstadoPedido,
                    Operador = OperadorBusqueda.Igual,
                    Valor = int.Parse(ddlEstado.SelectedValue),
                };
                busqueda.Filtros.Add(filtro);
            }
            if(!string.IsNullOrEmpty(txtDesde.Text)&&!string.IsNullOrEmpty(txtHasta.Text))
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
            await CargarPedidos();
        }

    }
}