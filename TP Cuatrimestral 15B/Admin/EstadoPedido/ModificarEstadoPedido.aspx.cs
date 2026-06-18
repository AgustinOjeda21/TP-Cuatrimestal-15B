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

namespace TP_Cuatrimestral_15B.Admin.EstadoPedido
{
    public partial class ModificarEstadoPedido : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioEstadoPedido repositorioEstadoPedido;
        private readonly GestorEstadoPedido gestorEstadoPedido;
        public ModificarEstadoPedido()
        {
            context = new mydbEntities1();
            repositorioEstadoPedido = new RepositorioEstadoPedido(context);
            gestorEstadoPedido = new GestorEstadoPedido(repositorioEstadoPedido);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarEstadoPedido));
        }

        private async Task BuscarEstadoPedido()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorEstadoPedido.CapturarEstadoPedido(id);
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
            var resultado = await gestorEstadoPedido.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarDescripcion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
        }
        protected async Task ModificarDescripcion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorEstadoPedido.ModificarDescripcion(txtDescripcion.Text, id);
        }
    }
}
