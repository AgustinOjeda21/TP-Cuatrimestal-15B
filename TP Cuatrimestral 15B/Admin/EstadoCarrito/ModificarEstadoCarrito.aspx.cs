using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.EstadoCarrito
{
    public partial class ModificarEstadoCarrito : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioEstadoCarrito repositorioEstadoCarrito;
        private readonly GestorEstadoCarrito gestorEstadoCarrito;
        public ModificarEstadoCarrito()
        {
            context = new mydbEntities1();
            repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);
            gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarEstadoCarrito));
        }

        private async Task BuscarEstadoCarrito()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorEstadoCarrito.CapturarEstadoCarrito(id);
            if (forma != null)
            {
                
                txtNombre.Text = forma.Nombre;
                txtNombre.Enabled = true;
                
                btnModificarNombre.Enabled = true;
                
            }

        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorEstadoCarrito.ModificarNombre(txtNombre.Text, id);
        }

    }
}
