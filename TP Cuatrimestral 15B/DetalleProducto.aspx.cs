using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using Aplicacion.Gestores;
using Dominio.Entidades;
using Infraestructura;
using Infraestructura.Repositorios;

namespace TP_Cuatrimestral_15B
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioImagen repositorioImagen = new RepositorioImagen(context);
        private static readonly RepositorioMarca repositorioMarca = new RepositorioMarca(context);
        private static readonly RepositorioProducto repositorioProducto = new RepositorioProducto(context);
        private static readonly RepositorioCarrito repositorioCarrito = new RepositorioCarrito(context);
        private static readonly RepositorioProductoCarrito repositorioProductoCarrito = new RepositorioProductoCarrito(context);
        private static readonly RepositorioEstadoCarrito repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);

        private static readonly GestorEstadoCarrito gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
        private static readonly GestorImagen gestorImagen = new GestorImagen(repositorioImagen);
        private static readonly GestorMarca gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        private static readonly GestorProducto gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
        private static readonly GestorProductoCarrito gestorProductoCarrito = new GestorProductoCarrito(repositorioProductoCarrito,gestorProducto);
        private static readonly GestorCarrito gestorCarrito = new GestorCarrito(repositorioCarrito,gestorEstadoCarrito,gestorProductoCarrito);

        protected Producto producto;
        protected string imagenUrl = "https://via.placeholder.com/420x320";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarProducto));
                RegisterAsyncTask(new PageAsyncTask(CargarRelacionados));
            }
        }

        private async Task CargarProducto()
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                producto = await gestorProducto.CapturarProducto(id);
                if (producto != null && producto.Imagenes != null && producto.Imagenes.Count > 0 && producto.Imagenes[0].URL != "")
                {
                    imagenUrl = producto.Imagenes[0].URL;
                }
            }
        }

        private async Task CargarRelacionados()
        {
            var productos = await gestorProducto.DevolverProductos();
            var resultado = productos.Select(productoRelacionado => new
            {
                productoRelacionado.IdProducto,
                productoRelacionado.Nombre,
                productoRelacionado.Precio,
                ImagenUrl = productoRelacionado.Imagenes != null && productoRelacionado.Imagenes.Count > 0 && productoRelacionado.Imagenes[0].URL != "" ? productoRelacionado.Imagenes[0].URL : "https://via.placeholder.com/250x180"
            }).ToList();
            rptRelacionados.DataSource = resultado;
            rptRelacionados.DataBind();
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarAlCarrito));
        }

        protected async Task AgregarAlCarrito()
        {
            var usuario = Session["Usuario"] as Dominio.Entidades.Usuario;
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if(carrito is null)
            {
                carrito = new Carrito();
                await gestorCarrito.CargarCarrito(carrito);
                Session["Carrito"] = carrito;
            }
            var producto = await gestorProducto.CapturarProducto(int.Parse(Request.QueryString["id"]));
            if(producto is null)
            {
                return;
            }
            ProductoCarrito productoCarrito = new ProductoCarrito
            {
                Carrito = carrito,
                Producto = producto,
                Cantidad = int.Parse(txtCantidad.Text)
            };
            await gestorProductoCarrito.AgregarProductoCarrito(productoCarrito);
            await gestorCarrito.ActualizarTotal(carrito.IdCarrito);
        }
    }
}
