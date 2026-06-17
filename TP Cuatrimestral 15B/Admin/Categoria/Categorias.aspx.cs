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
        private readonly mydbEntities1 context;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly GestorCategoria gestorCategoria;
        public AdminCategorias()
        {
            context = new mydbEntities1();
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            RegisterAsyncTask(new PageAsyncTask(CargarCategorias));
            
        }
        private async Task CargarCategorias()
        {
            var resultado = await gestorCategoria.DevolverCategorias();
            rptCategorias.DataSource = resultado;
            rptCategorias.DataBind();
        }
    }
}
