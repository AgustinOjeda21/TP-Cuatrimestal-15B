using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using System.Threading.Tasks;
using Infraestructura;
using Dominio.Entidades;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_15B.Usuario
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        public WebForm6()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(BuscarDireccion));
            }
        }
        private async Task BuscarDireccion()
        {
            var id = (int)Session["DireccionModificar"];
            var forma = await gestorDireccion.CapturarDireccion(id);
            if (forma != null)
            {
                txtCalle.Text = forma.Calle;
                txtNumero.Text = forma.Numero;
                txtLocalidad.Text = forma.Localidad;
                txtCodigoPostal.Text = forma.CodigoPostal;
                txtObservaciones.Text = forma.Observaciones;
            }

        }
        protected void btnModificarCalle_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCalle));
        }
        protected async Task ModificarCalle()
        {
            var id = (int)Session["DireccionModificar"];
            var resultado = await gestorDireccion.ModificarCalle(txtCalle.Text, id);
        }

        protected void btnModificarNumero_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNumero));
        }
        protected async Task ModificarNumero()
        {
            var id = (int)Session["DireccionModificar"];
            var resultado = await gestorDireccion.ModificarNumero(txtNumero.Text, id);
        }
        protected void btnLocalidad_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarLocalidad));
        }
        protected async Task ModificarLocalidad()
        {
            var id = (int)Session["DireccionModificar"];
            var resultado = await gestorDireccion.ModificarLocalidad(txtLocalidad.Text, id);
        }

        protected void btnCodigoPostal_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCodigo));
        }
        protected async Task ModificarCodigo()
        {
            var id = (int)Session["DireccionModificar"];
            var resultado = await gestorDireccion.ModificarCodigoPostal(txtCodigoPostal.Text, id);
        }
        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarObservaciones));
        }
        protected async Task ModificarObservaciones()
        {
            var id = (int)Session["DireccionModificar"];
            var resultado = await gestorDireccion.ModificarObservaciones(txtObservaciones.Text, id);
        }
    }
}