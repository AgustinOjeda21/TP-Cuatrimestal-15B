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
    public partial class WebForm1 : System.Web.UI.Page
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


        public WebForm1()
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
            gestorDetallePedido = new GestorDetallePedido(repositorioDetallePedido,gestorFormaPago,gestorFormaEntrega,gestorDireccion);
            repositorioPedido = new RepositorioPedido(context);
            gestorPedido = new GestorPedido(repositorioPedido, gestorCarrito,gestorEstadoPedido,gestorPersona,gestorDetallePedido);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CargarCarrito));
            if(!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarFormasPago));
                RegisterAsyncTask(new PageAsyncTask(CargarFormasEntrega));
                RegisterAsyncTask(new PageAsyncTask(CargarDirecciones));
            }
        }
        public async Task CargarCarrito()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if (carrito is null) return;
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(carrito.IdCarrito);
            rptCarrito.DataSource = productos;
            rptCarrito.DataBind();
            lblTotal.Text = productos.Sum(obj => obj.Cantidad * obj.Producto.Precio).ToString();
        }
        public async Task CargarFormasPago()
        {
            var formas = await gestorFormaPago.DevolverFormasPago();
            ddlFormaPago.DataSource = formas;
            ddlFormaPago.DataTextField = "Nombre";
            ddlFormaPago.DataValueField = "IdFormaPago";
            ddlFormaPago.DataBind();
        }
        public async Task CargarFormasEntrega()
        {
            var formas = await gestorFormaEntrega.DevolverFormasEntrega();
            ddlFormaEntrega.DataSource = formas;
            ddlFormaEntrega.DataTextField = "Nombre";
            ddlFormaEntrega.DataValueField = "IdFormaEntrega";
            ddlFormaEntrega.DataBind();
        }

        public async Task CargarDirecciones()
        {
            var usuario = Session["Usuario"] as Dominio.Entidades.Usuario;
            var busqueda = new Busqueda<Dominio.Entidades.Persona>();
            var filtro = new FiltroBusqueda<Dominio.Entidades.Persona, int>
            {
                Selector = obj => obj.Usuario.IdUsuario,
                Operador = OperadorBusqueda.Igual,
                Valor = usuario.IdUsuario,
            };
            busqueda.Filtros.Add(filtro);
            var lista = await gestorPersona.Buscar(busqueda);
            var persona = lista[0];
            ddlDirecciones.DataSource = persona.Direcciones;
            ddlDirecciones.DataTextField = "Descripcion";
            ddlDirecciones.DataValueField = "IdDireccion";
            ddlDirecciones.DataBind();
            Session["PersonaUsuario"] = persona;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ConfirmarPedido));
        }
        protected async Task ConfirmarPedido()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if (carrito is null) return;
            var persona = Session["PersonaUsuario"] as Dominio.Entidades.Persona;
            Pedido pedido = new Pedido
            {
                Carrito = carrito,
                Persona = persona
            };
            DetallePedido detallePedido = new DetallePedido
            {
                FechaPedido = DateTime.Now,
                FechaEntrega = DateTime.Now,
                FormaEntrega = await gestorFormaEntrega.CapturarFormaEntrega(int.Parse(ddlFormaEntrega.SelectedValue)),
                FormaPago = await gestorFormaPago.CapturarFormaPago(int.Parse(ddlFormaPago.SelectedValue)),
                Direccion = await gestorDireccion.CapturarDireccion(int.Parse(ddlDirecciones.SelectedValue)),

            };
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(carrito.IdCarrito);
            foreach (var pro in productos)
            {
                await gestorProducto.ModificarStock((pro.Producto.Stock - pro.Cantidad), pro.Producto.IdProducto);
            }
            await gestorPedido.CargarPedido(pedido, detallePedido);
            Session["Carrito"] = null;
            Response.Redirect("MisCompras");
        }
    }
}
