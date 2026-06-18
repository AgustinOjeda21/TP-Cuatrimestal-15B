using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;

using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioEstadoPedido repositorioEstadoPedido;
        private readonly GestorEstadoPedido gestorEstadoPedido;
        public WebForm2()
        {
            context = new mydbEntities1();
            repositorioEstadoPedido = new RepositorioEstadoPedido(context);
            gestorEstadoPedido = new GestorEstadoPedido(repositorioEstadoPedido);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarEstadoPedido));
            
        }
        private async Task CargarEstadoPedido()
        {
            var resultado = await gestorEstadoPedido.DevolverEstadosPedido();
            rptEstadoPedido.DataSource = resultado;
            rptEstadoPedido.DataBind();
        }
    }
}
