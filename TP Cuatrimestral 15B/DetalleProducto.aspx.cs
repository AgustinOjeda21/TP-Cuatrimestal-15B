using System;
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

        private static readonly GestorImagen gestorImagen = new GestorImagen(repositorioImagen);
        private static readonly GestorMarca gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        private static readonly GestorProducto gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);

        protected Producto producto;

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
            }
        }

        private async Task CargarRelacionados()
        {
            var resultado = await gestorProducto.DevolverProductos();
            rptRelacionados.DataSource = resultado;
            rptRelacionados.DataBind();
        }
    }
}
