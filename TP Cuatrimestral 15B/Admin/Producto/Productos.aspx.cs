using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminProductos : Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        protected Label lblPrecioError;
        protected Label lblStockError;
        protected Label lblMarcaError;
        protected Label lblCategoriaError;
        protected Label lblNombreImagenError;
        protected Label lblUrlImagenError;
        protected Label lblProveedorError;
        protected Label lblDescripcionError;
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
        private readonly GestorCategoria gestorCategoria;
        public AdminProductos()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            repositorioMarca = new RepositorioMarca(context);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            repositorioProducto = new RepositorioProducto(context);
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
            gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarProducto));
            }
        }

        private async Task CargarProducto()
        {
            var resultado = await gestorProducto.DevolverProductos();
            rptProducto.DataSource = resultado;
            rptProducto.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                var resultado = await gestorProducto.DevolverProductos();
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                    resultado = resultado.Where(p => p.Nombre.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                rptProducto.DataSource = resultado;
                rptProducto.DataBind();
            }));
        }

        protected void rptProducto_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    await gestorProducto.EliminarProducto(id);
                    var resultado = await gestorProducto.DevolverProductos();
                    rptProducto.DataSource = resultado;
                    rptProducto.DataBind();
                }));
            }
        }
    }
}
