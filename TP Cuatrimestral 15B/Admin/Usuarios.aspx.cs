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
    public partial class WebForm8 : System.Web.UI.Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioDireccion repositorioDireccion = new RepositorioDireccion(context);
        private static readonly GestorDireccion gestorDireccion = new GestorDireccion(repositorioDireccion);
        private static readonly RepositorioPersona repositorioPersona = new RepositorioPersona(context);
        private static readonly GestorPersona gestorPersona = new GestorPersona(repositorioPersona,gestorDireccion);
        private static readonly RepositorioUsuario repositorioUsuario = new RepositorioUsuario(context);
        private static readonly GestorUsuario gestorUsuario = new GestorUsuario(repositorioUsuario,gestorPersona);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarUsuarios));
            }
        }
        private async Task CargarUsuarios()
        {
            var resultado = await gestorUsuario.DevolverUsuarios();
            rptUsuarios.DataSource = resultado;
            rptUsuarios.DataBind();
        }
    }
}