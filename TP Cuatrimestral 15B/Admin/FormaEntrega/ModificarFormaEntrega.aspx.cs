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

namespace TP_Cuatrimestral_15B.Admin.FormaEntrega
{
    public partial class ModificarFormaEntrega : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioFormaEntrega repositorioFormaEntrega;
        private readonly GestorFormaEntrega gestorFormaEntrega;
        public ModificarFormaEntrega()
        {
            context = new mydbEntities1();
            repositorioFormaEntrega = new RepositorioFormaEntrega(context);
            gestorFormaEntrega = new GestorFormaEntrega(repositorioFormaEntrega);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarFormaEntrega));
        }

        private async Task BuscarFormaEntrega()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorFormaEntrega.CapturarFormaEntrega(id);
            if (forma != null)
            {
                txtDescripcion.Text = forma.Descripcion;
                txtNombre.Text = forma.Nombre;
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                btnModificarNombre.Enabled = true;
                btnModificarDescripcion.Enabled = true;
            }

        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorFormaEntrega.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarDescripcion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
        }
        protected async Task ModificarDescripcion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorFormaEntrega.ModificarDescripcion(txtDescripcion.Text, id);
        }
    }
}
