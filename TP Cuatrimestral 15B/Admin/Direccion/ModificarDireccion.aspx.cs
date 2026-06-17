using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using System.Threading.Tasks;
using Infraestructura;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.Direccion
{
    public partial class ModificarDireccion : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        public ModificarDireccion()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarDireccion));
        }

        private async Task BuscarDireccion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorDireccion.CapturarDireccion(id);
            if (forma != null)
            {
                txtCalle.Text = forma.Calle;
                txtNumero.Text = forma.Numero;
                txtLocalidad.Text = forma.Localidad;
                txtCodigoPostal.Text = forma.CodigoPostal;
                txtObservaciones.Text = forma.Observaciones;
                txtCalle.Enabled = true;
                txtLocalidad.Enabled = true;
                txtCodigoPostal.Enabled = true;
                txtNumero.Enabled = true;
                txtObservaciones.Enabled = true;
                btnModificarCalle.Enabled = true;
                btnModificarNumero.Enabled = true;
                btnLocalidad.Enabled = true;
                btnCodigoPostal.Enabled = true;
                btnObservaciones.Enabled = true;
                
            }

        }
        protected void btnModificarCalle_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCalle));
        }
        protected async Task ModificarCalle()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorDireccion.ModificarCalle(txtCalle.Text, id);
        }

        protected void btnModificarNumero_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNumero));
        }
        protected async Task ModificarNumero()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorDireccion.ModificarNumero(txtNumero.Text, id);
        }
        protected void btnLocalidad_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarLocalidad));
        }
        protected async Task ModificarLocalidad()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorDireccion.ModificarLocalidad(txtLocalidad.Text, id);
        }

        protected void btnCodigoPostal_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCodigo));
        }
        protected async Task ModificarCodigo()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorDireccion.ModificarCodigoPostal(txtCodigoPostal.Text, id);
        }
        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarObservaciones));
        }
        protected async Task ModificarObservaciones()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorDireccion.ModificarObservaciones(txtObservaciones.Text, id);
        }
    }
}