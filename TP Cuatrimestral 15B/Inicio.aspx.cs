using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;

namespace TP_Cuatrimestral_15B
{
    public partial class Inicio : System.Web.UI.Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioImagen repositorioImagen = new RepositorioImagen(context);
        private static readonly RepositorioMarca repositorioMarca = new RepositorioMarca(context);
        private static readonly RepositorioProducto repositorioProducto = new RepositorioProducto(context);
        private static readonly RepositorioCategoria repositorioCategoria = new RepositorioCategoria(context);

        private static readonly GestorImagen gestorImagen = new GestorImagen(repositorioImagen);
        private static readonly GestorMarca gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        private static readonly GestorProducto gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
        private static readonly GestorCategoria gestorCategoria = new GestorCategoria(repositorioCategoria);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarProductos));
                RegisterAsyncTask(new PageAsyncTask(CargarCategorias));
            }
        }

        private async Task CargarProductos()
        {
            var productos = await gestorProducto.DevolverProductos();
            var resultado = productos.Select(producto => new
            {
                producto.IdProducto,
                producto.Nombre,
                producto.Precio,
                ImagenUrl = producto.Imagenes != null && producto.Imagenes.Count > 0 && producto.Imagenes[0].URL != "" ? producto.Imagenes[0].URL : "https://via.placeholder.com/250x180"
            }).ToList();
            rptProductos.DataSource = resultado;
            rptProductos.DataBind();
        }

        private async Task CargarCategorias()
        {
            var resultado = await gestorCategoria.DevolverCategorias();
            rptCategorias.DataSource = resultado;
            rptCategorias.DataBind();
        }
    }
}
