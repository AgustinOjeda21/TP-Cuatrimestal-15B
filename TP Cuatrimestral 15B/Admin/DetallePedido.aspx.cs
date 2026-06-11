using System;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminDetallePedido : Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();

        // Repositorios primero
        private static readonly RepositorioImagen repositorioImagen = new RepositorioImagen(context);
        private static readonly RepositorioDireccion repositorioDireccion = new RepositorioDireccion(context);
        private static readonly RepositorioEstadoCarrito repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);
        private static readonly RepositorioCarrito repositorioCarrito = new RepositorioCarrito(context);
        private static readonly RepositorioFormaPago repositorioFormaPago = new RepositorioFormaPago(context);
        private static readonly RepositorioFormaEntrega repositorioFormaEntrega = new RepositorioFormaEntrega(context);
        private static readonly RepositorioEstadoPedido repositorioEstadoPedido = new RepositorioEstadoPedido(context);
        private static readonly RepositorioDetallePedido repositorioDetallePedido = new RepositorioDetallePedido(context);
        private static readonly RepositorioPedido repositorioPedido = new RepositorioPedido(context);
        private static readonly RepositorioPersona repositorioPersona = new RepositorioPersona(context);
        private static readonly RepositorioMarca repositorioMarca = new RepositorioMarca(context);
        private static readonly RepositorioProveedor repositorioProveedor = new RepositorioProveedor(context);
        private static readonly RepositorioUsuario repositorioUsuario = new RepositorioUsuario(context);
        private static readonly RepositorioProducto repositorioProducto = new RepositorioProducto(context);

        // Gestores sin dependencias de otros gestores
        private static readonly GestorImagen gestorImagen = new GestorImagen(repositorioImagen);
        private static readonly GestorDireccion gestorDireccion = new GestorDireccion(repositorioDireccion);
        private static readonly GestorEstadoCarrito gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
        private static readonly GestorFormaPago gestorFormaPago = new GestorFormaPago(repositorioFormaPago);
        private static readonly GestorFormaEntrega gestorFormaEntrega = new GestorFormaEntrega(repositorioFormaEntrega);
        private static readonly GestorEstadoPedido gestorEstadoPedido = new GestorEstadoPedido(repositorioEstadoPedido);
        private static readonly GestorMarca gestorMarca = new GestorMarca(repositorioMarca);

        // Gestores con dependencias de otros gestores
        private static readonly GestorCarrito gestorCarrito = new GestorCarrito(repositorioCarrito, gestorEstadoCarrito);
        private static readonly GestorPersona gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
        private static readonly GestorUsuario gestorUsuario = new GestorUsuario(repositorioUsuario, gestorPersona);
        private static readonly GestorProveedor gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
        private static readonly GestorProducto gestorProducto = new GestorProducto(repositorioProducto, gestorMarca);

        // Gestores con dependencias de múltiples gestores
        private static readonly GestorDetallePedido gestorDetallePedido = new GestorDetallePedido(repositorioDetallePedido, gestorPedido, gestorFormaPago, gestorFormaEntrega, gestorDireccion);
        private static readonly GestorPedido gestorPedido = new GestorPedido(repositorioPedido, gestorCarrito, gestorEstadoPedido, gestorPersona, gestorDetallePedido);
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarDetallePedidos));
            }*/
        }
        /*private async Task CargarDetallePedidos()
        {
            var resultado = await gestorDetallePedido.DevolverDetallePedidos();
            rptDetallePedidos.DataSource = resultado;
            rptDetallePedidos.DataBind();
        }*/
    }
}
