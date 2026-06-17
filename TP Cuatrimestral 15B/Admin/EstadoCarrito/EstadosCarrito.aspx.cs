using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioEstadoCarrito repositorioEstadoCarrito;
        private readonly GestorEstadoCarrito gestorEstadoCarrito;
        public WebForm3()
        {
            context = new mydbEntities1();
            repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);
            gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarEstadoCarrito));
            }
        }
        private async Task CargarEstadoCarrito()
        {
            var resultado = await gestorEstadoCarrito.DevolverEstadosCarrito();
            rptEstadoCarrito.DataSource = resultado;
            rptEstadoCarrito.DataBind();
        }
    }
}