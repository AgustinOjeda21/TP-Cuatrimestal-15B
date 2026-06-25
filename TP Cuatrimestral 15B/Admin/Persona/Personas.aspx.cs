using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        protected Label lblError;
        protected Label lblConfirmacion;
        public WebForm6()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            repositorioPersona = new RepositorioPersona(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarPersona));
            
        }
        private async Task CargarPersona()
        {
            var resultado = await gestorPersona.DevolverPersonas();
            rptPersona.DataSource = resultado;
            rptPersona.DataBind();
        }
    }
}
