using System;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminFormasEntrega : Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioFormaEntrega repositorioFormaEntrega;
        private readonly GestorFormaEntrega gestorFormaEntrega;
        public AdminFormasEntrega()
        {
            context = new mydbEntities1();
            repositorioFormaEntrega = new RepositorioFormaEntrega(context);
            gestorFormaEntrega = new GestorFormaEntrega(repositorioFormaEntrega);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            RegisterAsyncTask(new PageAsyncTask(CargarFormaEntrega));
           
        }
        private async Task CargarFormaEntrega()
        {
            var resultado = await gestorFormaEntrega.DevolverFormasEntrega();
            rptFormaEntrega.DataSource = resultado;
            rptFormaEntrega.DataBind();
        }
    }
}
