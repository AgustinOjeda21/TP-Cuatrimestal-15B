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

namespace TP_Cuatrimestral_15B.Admin.Persona
{
    public partial class ModificarPersona : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        protected Label lblError;
        protected Label lblConfirmacion;
        public ModificarPersona()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            repositorioPersona = new RepositorioPersona(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Direcciones"] = new List<Dominio.Entidades.Direccion>();
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            var direcciones = Session["Direccion"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            gvDirecciones.DataSource = direcciones;
            gvDirecciones.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarPersona));
        }

        private async Task BuscarPersona()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorPersona.CapturarPersona(id);
            if (forma != null)
            {
                txtCalle.Enabled = true;
                txtLocalidad.Enabled = true;
                txtCodigoPostal.Enabled = true;
                txtNumero.Enabled = true;
                txtObservaciones.Enabled = true;
                txtNombre.Text = forma.Nombre;
                txtApellido.Text = forma.Apellido;
                txtMail.Text = forma.Mail;
                txtTelefono.Text = forma.Telefono;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefono.Enabled = true;
                txtMail.Enabled = true;
                btnModificarNombre.Enabled = true;
                btnModificarApellido.Enabled = true;
                btnModificarMail.Enabled = true;
                btnModificarTelefono.Enabled = true;
                btnAgregarDireccion.Enabled = true;
                Session["PersonaActual"] = forma;
                Session["Direcciones"] = forma.Direcciones;
                gvDirecciones.DataSource = forma.Direcciones;
                gvDirecciones.DataBind();

            }

        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorPersona.ModificarNombre(txtNombre.Text, id);
        }
        protected void btnModificarApellido_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarApellido));
        }
        protected async Task ModificarApellido()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorPersona.ModificarApellido(txtApellido.Text, id);
        }
        protected void btnModificarMail_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarMail));
        }
        protected async Task ModificarMail()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorPersona.ModificarMail(txtMail.Text, id);
        }

        protected void btnModificarTelefono_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarTelefono));
        }
        protected async Task ModificarTelefono()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorPersona.ModificarTelefono(txtTelefono.Text, id);
        }

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarDireccion));
        }

        protected async Task AgregarDireccion()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            if (txtCalle.Text == "" || txtNumero.Text == "" || txtLocalidad.Text == "" || txtCodigoPostal.Text == "")
            {
                lblError.Text = "Complet? calle, n?mero, localidad y c?digo postal";
                lblError.Visible = true;
                return;
            }
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            Dominio.Entidades.Direccion direccion = new Dominio.Entidades.Direccion
            {
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Localidad = txtLocalidad.Text,
                CodigoPostal = txtCodigoPostal.Text,
                Observaciones = txtObservaciones.Text
            };
            await gestorPersona.AgregarDireccion(persona.IdPersona, direccion);
            direcciones.Add(direccion);

            Session["Direcciones"] = direcciones;

            gvDirecciones.DataSource = direcciones;
            gvDirecciones.DataBind();
            lblConfirmacion.Text = "Direccion agregada correctamente";
            lblConfirmacion.Visible = true;
        }

        protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion>;

                if (direcciones != null)
                {
                    Session["DireccionQuitar"] = direcciones[indice].IdDireccion;
                    direcciones.RemoveAt(indice);
                    Session["Direcciones"] = direcciones;
                    RegisterAsyncTask(new PageAsyncTask(Quitar));
                }
            }
        }
        protected async Task Quitar()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            if (Session["DireccionQuitar"] == null) return;
            int direccion = (int)Session["DireccionQuitar"];
            if (persona != null)
            {
                await gestorPersona.QuitarDireccion(persona.IdPersona, direccion);
                var direcciones = Session["direcciones"] as List<Dominio.Entidades.Direccion>;
                gvDirecciones.DataSource = direcciones;
                gvDirecciones.DataBind();
            }

        }

    }
}

