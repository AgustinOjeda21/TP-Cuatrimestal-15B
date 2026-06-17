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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarDirecciones));
            
        }
        private async Task CargarDirecciones()
        {
            var resultado = await gestorDireccion.DevolverDirecciones();
            rptDirecciones.DataSource = resultado;
            rptDirecciones.DataBind();
        }
    }
}