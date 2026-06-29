using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_15B.Usuario
{
    public partial class Carrito : System.Web.UI.Page
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

        public Carrito()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioProductoCarrito = new RepositorioProductoCarrito(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            repositorioMarca = new RepositorioMarca(context);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            repositorioProducto = new RepositorioProducto(context);
            repositorioCarrito = new RepositorioCarrito(context);
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

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CargarCarrito));
        }
        public async Task CargarCarrito()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if(carrito is null)
            {
                return;
            }
            btnCancelar.Visible = true;
            btnConfirmar.Visible = true;
            var productos = await gestorProductoCarrito.DevolverProductoCarrito(carrito.IdCarrito);
            rptCarrito.DataSource = productos;
            rptCarrito.DataBind();
        }
        public decimal CalcularSubtotal(object item)
        {
            var pc = item as Dominio.Entidades.ProductoCarrito;
            return pc.Producto.Precio * pc.Cantidad;
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName=="Eliminar")
            {
                var pro  = Convert.ToInt32(e.CommandArgument);
                Session["ProductoEliminar"] = pro;
                RegisterAsyncTask(new PageAsyncTask(EliminarProducto));
            }
            if (e.CommandName == "Sumar")
            {
                var pro = Convert.ToInt32(e.CommandArgument);
                Session["ProductoEliminar"] = pro;
                RegisterAsyncTask(new PageAsyncTask(SumarCantidad));
            }
            if (e.CommandName == "Restar")
            {
                var pro = Convert.ToInt32(e.CommandArgument);
                Session["ProductoEliminar"] = pro;
                RegisterAsyncTask(new PageAsyncTask(RestarCantidad));
            }
        }
        protected async Task EliminarProducto()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            var producto = (int)Session["ProductoEliminar"];
            var productoCarrito = await gestorProductoCarrito.CapturarProductoCarrito(carrito.IdCarrito, producto);
            await gestorProductoCarrito.Eliminar(carrito.IdCarrito, producto);
            await CargarCarrito();
        }
        protected async Task SumarCantidad()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            var producto = (int)Session["ProductoEliminar"];
            var productoCarrito = await gestorProductoCarrito.CapturarProductoCarrito(carrito.IdCarrito, producto);
            await gestorProductoCarrito.ModificarCantidad(productoCarrito.Cantidad+1,carrito.IdCarrito,producto);
            await CargarCarrito();
        }
        protected async Task RestarCantidad()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            var producto = (int)Session["ProductoEliminar"];
            var productoCarrito = await gestorProductoCarrito.CapturarProductoCarrito(carrito.IdCarrito, producto);
            if(productoCarrito.Cantidad==1)
            {
                RegisterAsyncTask(new PageAsyncTask(EliminarProducto));
                return;
            }
            await gestorProductoCarrito.ModificarCantidad(productoCarrito.Cantidad - 1, carrito.IdCarrito, producto);
            await CargarCarrito();
        }

        protected void btnCancelar_Click(object source, EventArgs e)
        {
             RegisterAsyncTask(new PageAsyncTask(CancelarCarrito));
        }

        protected async Task CancelarCarrito()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if (carrito == null) return;

            await gestorCarrito.CancelarCarrito(carrito.IdCarrito);
            Session["Carrito"] = null;
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btnConfirmarCarrito_Click(object source, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ConfirmarCarrito));
        }

        protected async Task ConfirmarCarrito()
        {
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if(carrito is null)
            {
                return;
            }
            await gestorCarrito.ConfirmarCarrito(carrito.IdCarrito);
            Response.Redirect("Checkout");
        }


    }
}
