using System;
using System.Threading.Tasks;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;


namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminCategorias : Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioCategoria repositorioCategoria = new RepositorioCategoria(context);
        private GestorCategoria gestorCategoria = new GestorCategoria(repositorioCategoria);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarCategorias));
            }
        }
        private async Task CargarCategorias()
        {
            var resultado = await gestorCategoria.DevolverCategorias();
            rptCategorias.DataSource = resultado;
            rptCategorias.DataBind();
        }
    }
}
