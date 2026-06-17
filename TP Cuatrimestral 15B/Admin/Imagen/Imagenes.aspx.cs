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
    public partial class WebForm4 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        public WebForm4()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            gestorImagen = new GestorImagen(repositorioImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            RegisterAsyncTask(new PageAsyncTask(CargarImagen));
           
        }
        private async Task CargarImagen()
        {
            var resultado = await gestorImagen.DevolverImagenes();
            rptImagen.DataSource = resultado;
            rptImagen.DataBind();
        }
    }
}