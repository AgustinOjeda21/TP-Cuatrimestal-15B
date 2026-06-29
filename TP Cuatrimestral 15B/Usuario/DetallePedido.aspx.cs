using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Dominio.Entidades;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_15B.Usuario
{
    public partial class WebForm3 : System.Web.UI.Page
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


            public WebForm3()
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

            }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CargarCarrito));
            RegisterAsyncTask(new PageAsyncTask(CargarDetalle));
        }
        public async Task CargarDetalle()
        {
            var id = (int)Session["PedidoDetalle"];
            var pedido = await gestorPedido.CapturarPedido(id);
            if (pedido is null)
            {
                return;
            }
            lblDireccion.Text = pedido.DetallePedido.Direccion.Descripcion;
            lblEntrega.Text = pedido.DetallePedido.FormaEntrega.Nombre;
            lblEstado.Text = pedido.EstadoPedido.Nombre;
            lblFecha.Text = pedido.DetallePedido.FechaPedido.ToString("dd/MM/yyyy");
            lblNumero.Text = pedido.IdPedido.ToString();
            lblPago.Text = pedido.DetallePedido.FormaPago.Nombre;
            lblTotal.Text = pedido.Carrito.Total.ToString("N2");
            if(pedido.EstadoPedido.Nombre=="Confirmado")
            {
                btnCancelar.Visible = true;
                btnPagar.Visible = true;
            }
            if (pedido.EstadoPedido.Nombre == "Cancelado")
            {
                btnReestablecer.Visible = true;
            }
        }
        public async Task CargarCarrito()
        {
            var id = (int)Session["PedidoDetalle"];
            var pedido = await gestorPedido.CapturarPedido(id);
            if (pedido is null)
            {
                return;
            }
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(pedido.Carrito.IdCarrito);
            rptCarrito.DataSource = productos;
            rptCarrito.DataBind();
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CancelarPedido));
        }
        public async Task CancelarPedido()
        {
            var id = (int)Session["PedidoDetalle"];
            var pedido = await gestorPedido.CapturarPedido(id);
            if (pedido is null)
            {
                return;
            }
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(pedido.Carrito.IdCarrito);
            foreach (var pro in productos)
            {
                await gestorProducto.ModificarStock((pro.Producto.Stock + pro.Cantidad), pro.Producto.IdProducto);
            }
            await gestorPedido.CancelarPedido(id);
            RegisterAsyncTask(new PageAsyncTask(CargarDetalle));
        }
        public void btnPagar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(PagarPedido));
        }
        public async Task PagarPedido()
        {
            var id = (int)Session["PedidoDetalle"];
            await gestorPedido.PagarPedido(id);
            RegisterAsyncTask(new PageAsyncTask(CargarDetalle));
        }
        public void btnReestablecer_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ReestablecerPedido));
        }
        public async Task ReestablecerPedido()
        {
            var id = (int)Session["PedidoDetalle"];
            var pedido = await gestorPedido.CapturarPedido(id);
            if (pedido is null)
            {
                return;
            }
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(pedido.Carrito.IdCarrito);
            foreach (var pro in productos)
            {
                await gestorProducto.ModificarStock((pro.Producto.Stock - pro.Cantidad), pro.Producto.IdProducto);
            }
            await gestorPedido.ReestablecerPedido(id);
            RegisterAsyncTask(new PageAsyncTask(CargarDetalle));
        }
    }
}
