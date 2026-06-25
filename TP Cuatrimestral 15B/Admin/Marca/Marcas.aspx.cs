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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        protected Label lblNombreImagenError;
        protected Label lblUrlImagenError;
        private readonly mydbEntities1 context;
        private readonly RepositorioMarca repositorioMarca;
        private readonly GestorMarca gestorMarca;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        public WebForm5()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioMarca = new RepositorioMarca(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
             RegisterAsyncTask(new PageAsyncTask(CargarMarca));
            
        }
        private async Task CargarMarca()
        {
            var resultado = await gestorMarca.DevolverMarcas();
            rptMarca.DataSource = resultado;
            rptMarca.DataBind();
        }
    }
}
