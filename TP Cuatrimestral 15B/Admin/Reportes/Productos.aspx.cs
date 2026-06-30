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
    public partial class Productos : System.Web.UI.Page
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


        public Productos()
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
                RegisterAsyncTask(new PageAsyncTask(CargarMarcas));
                RegisterAsyncTask(new PageAsyncTask(CargarProductos));
            }
        }
        private async Task CargarProductos()
        {
            var resultado = await gestorReporte.DevolverProductos();
            if (resultado is null) return;
            switch (ddlAgrupacion.SelectedValue)
            {
                case "MayorCantidadVendida":
                    resultado = resultado.OrderByDescending(obj => obj.TotalVendido).ToList();
                    break;
                case "MenorCantidadVendida":
                    resultado = resultado.OrderBy(obj => obj.TotalVendido).ToList();
                    break;
                case "MayorFacturacion":
                    resultado = resultado.OrderByDescending(obj => obj.TotalIngresado).ToList();
                    break;
                case "MenorFacturacion":
                    resultado = resultado.OrderBy(obj => obj.TotalIngresado).ToList();
                    break;
                case "MayorStock":
                    resultado = resultado.OrderByDescending(obj => obj.Stock).ToList();
                    break;
                case "MenorStock":
                    resultado = resultado.OrderBy(obj => obj.Stock).ToList();
                    break;
                case "Nombre":
                    resultado = resultado.OrderBy(obj => obj.Producto).ToList();
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(ddlMarca.SelectedValue))
            {
                resultado = resultado.Where(obj => obj.IdMarca == int.Parse(ddlMarca.SelectedValue)).ToList();
            }
            rptProductos.DataSource = resultado;
            rptProductos.DataBind();
            lblTotal.Text = resultado.Sum(obj => obj.TotalVendido).ToString();
            lblFacturacion.Text = resultado.Sum(obj => obj.TotalIngresado).ToString();
            var producto = resultado.OrderByDescending(obj=>obj.TotalVendido).FirstOrDefault();
            lblProducto.Text = $"{producto.Producto} {producto.TotalVendido} Unidades";
        }
        private async Task CargarMarcas()
        {
            var resultado = await gestorMarca.DevolverMarcas();
            ddlMarca.DataSource = resultado;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Todas", ""));
        }
        public void btnGenerar_Click(object sender, EventArgs e)
        {

            RegisterAsyncTask(new PageAsyncTask(CargarProductos));
        }
    
    }
}