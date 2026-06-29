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
using Aplicacion.Busqueda;

namespace TP_Cuatrimestral_15B.Usuario
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        protected Label lblError;
        protected Label lblConfirmacion;
        public WebForm7()
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
                RegisterAsyncTask(new PageAsyncTask(BuscarPersona));
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            gvDirecciones.DataSource = direcciones;
            gvDirecciones.DataBind();
        }

        private async Task BuscarPersona()
        {
            var usuario = Session["Usuario"] as Dominio.Entidades.Usuario;
            var busqueda = new Busqueda<Dominio.Entidades.Persona>();
            var filtro = new FiltroBusqueda<Dominio.Entidades.Persona, int>
            {
                Selector = obj => obj.Usuario.IdUsuario,
                Operador = OperadorBusqueda.Igual,
                Valor = usuario.IdUsuario,
            };
            busqueda.Filtros.Add(filtro);
            var lista = await gestorPersona.Buscar(busqueda);
            var persona = lista[0];
            if (persona != null)
            {

                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtMail.Text = persona.Mail;
                txtTelefono.Text = persona.Telefono;
                Session["PersonaActual"] = persona;
                Session["Direcciones"] = persona.Direcciones;
                gvDirecciones.DataSource = persona.Direcciones;
                gvDirecciones.DataBind();

            }

        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            var resultado = await gestorPersona.ModificarNombre(txtNombre.Text, persona.IdPersona);
        }
        protected void btnModificarApellido_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarApellido));
        }
        protected async Task ModificarApellido()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            var resultado = await gestorPersona.ModificarApellido(txtApellido.Text, persona.IdPersona);
        }
        protected void btnModificarMail_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarMail));
        }
        protected async Task ModificarMail()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            var resultado = await gestorPersona.ModificarMail(txtMail.Text, persona.IdPersona);
        }

        protected void btnModificarTelefono_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarTelefono));
        }
        protected async Task ModificarTelefono()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
            var resultado = await gestorPersona.ModificarTelefono(txtTelefono.Text, persona.IdPersona);
        }

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarDireccion));
        }

        protected async Task AgregarDireccion()
        {
            var persona = Session["PersonaActual"] as Dominio.Entidades.Persona;
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
                var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion>;
                gvDirecciones.DataSource = direcciones;
                gvDirecciones.DataBind();
            }

        }
    }
}