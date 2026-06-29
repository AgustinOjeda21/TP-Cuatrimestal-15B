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
    public partial class WebForm4 : System.Web.UI.Page
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
 


        public WebForm4()
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
        }
        public async Task CargarCarrito()
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
            Session["PersonaActual"] = persona;
            rptDirecciones.DataSource = persona.Direcciones;
            rptDirecciones.DataBind();
        }

        protected void rptDirecciones_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                var dir = Convert.ToInt32(e.CommandArgument);
                Session["DireccionEliminar"] = dir;
                RegisterAsyncTask(new PageAsyncTask(Quitar));
                return;
            }
            if(e.CommandName == "Modificar")
            {
                var dir = Convert.ToInt32(e.CommandArgument);
                Session["DireccionModificar"] = dir;
                Response.Redirect("ModificarDireccion");
            }
        }

        protected async Task Quitar()
        {
            var direccion = (int)Session["DireccionEliminar"];
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            await gestorPersona.QuitarDireccion(persona.IdPersona, direccion);
            rptDirecciones.DataSource = persona.Direcciones;
            rptDirecciones.DataBind();
        }
        
    }
}
