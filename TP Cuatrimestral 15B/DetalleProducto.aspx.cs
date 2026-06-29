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
        private readonly mydbEntities1 context;
        private readonly RepositorioImagen repositorioImagen;
        private readonly RepositorioMarca repositorioMarca;
        private readonly RepositorioProducto repositorioProducto;
        private readonly RepositorioCarrito repositorioCarrito;
        private readonly RepositorioProductoCarrito repositorioProductoCarrito;
        private readonly RepositorioEstadoCarrito repositorioEstadoCarrito;

        private readonly GestorEstadoCarrito gestorEstadoCarrito;
        private readonly GestorImagen gestorImagen;
        private readonly GestorMarca gestorMarca;
        private readonly GestorProducto gestorProducto;
        private readonly GestorProductoCarrito gestorProductoCarrito;
        private readonly GestorCarrito gestorCarrito; 

        public DetalleProducto()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioMarca = new RepositorioMarca(context);
            repositorioProducto = new RepositorioProducto(context);
            repositorioCarrito = new RepositorioCarrito(context);
            repositorioProductoCarrito = new RepositorioProductoCarrito(context);
            repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);

            gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
            gestorProductoCarrito = new GestorProductoCarrito(repositorioProductoCarrito, gestorProducto);
            gestorCarrito = new GestorCarrito(repositorioCarrito, gestorEstadoCarrito, gestorProductoCarrito);
    }


        protected Producto producto;
        protected string imagenUrl = "https://via.placeholder.com/420x320";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarProducto));
                RegisterAsyncTask(new PageAsyncTask(CargarRelacionados));
            }
            var usuario = Session["Usuario"] as Dominio.Entidades.Usuario;
            if (usuario != null)
            {
                linkLogin.Visible = false;
                linkSignin.Visible = false;
                linkPerfil.Visible = true;
            }
            var carrito = Session["Carrito"] as Dominio.Entidades.Carrito;
            if (carrito is null)
            {
                btnCarrito.Visible = false;
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
            var pro = await gestorProductoCarrito.CapturarProductoCarrito(carrito.IdCarrito, producto.IdProducto);
            if (pro is null)
            {
                await gestorProductoCarrito.AgregarProductoCarrito(productoCarrito);
            }
            else
            {
                pro.Cantidad += productoCarrito.Cantidad;
                await gestorProductoCarrito.ModificarCantidad(pro.Cantidad, carrito.IdCarrito, producto.IdProducto);
            }
            await gestorCarrito.ActualizarTotal(carrito.IdCarrito);
        }
    }
}
