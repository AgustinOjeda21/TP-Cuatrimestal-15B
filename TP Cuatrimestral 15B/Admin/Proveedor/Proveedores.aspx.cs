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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        private readonly mydbEntities1 context;
        private readonly RepositorioProveedor repositorioProveedor;
        private readonly GestorProveedor gestorProveedor;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        public WebForm7()
        {
            context = new mydbEntities1();
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarProveedor));
            
        }
        private async Task CargarProveedor()
        {
            var resultado = await gestorProveedor.DevolverProveedores();
            rptProveedor.DataSource = resultado;
            rptProveedor.DataBind();
        }
    }
}
