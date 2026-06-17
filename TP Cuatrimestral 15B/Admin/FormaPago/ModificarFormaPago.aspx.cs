using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.FormaPago
{
    public partial class ModificarFormaPago : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioFormaPago repositorioFormaPago;
        private readonly GestorFormaPago gestorFormaPago;
        public ModificarFormaPago()
        {
            context = new mydbEntities1();
            repositorioFormaPago = new RepositorioFormaPago(context);
            gestorFormaPago = new GestorFormaPago(repositorioFormaPago);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarFormaPago));
        }

        private async Task BuscarFormaPago()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorFormaPago.CapturarFormaPago(id);
            if(forma!=null)
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
            var resultado = await gestorFormaPago.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarDescripcion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
        }
        protected async Task ModificarDescripcion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorFormaPago.ModificarDescripcion(txtDescripcion.Text, id);
        }
    }
}