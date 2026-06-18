using System;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminFormasPago : Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioFormaPago repositorioFormaPago;
        private readonly GestorFormaPago gestorFormaPago;
        public AdminFormasPago()
        {
            context = new mydbEntities1();
            repositorioFormaPago = new RepositorioFormaPago(context);
            gestorFormaPago = new GestorFormaPago(repositorioFormaPago);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarFormaPago));
            
        }
        private async Task CargarFormaPago()
        {
            var resultado = await gestorFormaPago.DevolverFormasPago();
            rptFormaPago.DataSource = resultado;
            rptFormaPago.DataBind();
        }
    }
}
