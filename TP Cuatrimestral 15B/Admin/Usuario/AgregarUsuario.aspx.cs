using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.Usuario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        private readonly mydbEntities1 context;
        private readonly RepositorioUsuario repositorioUsuario;
        private readonly GestorUsuario gestorUsuario;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        private List<Dominio.Entidades.Direccion> Direcciones;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioUsuario = new RepositorioUsuario(context);
            repositorioDireccion = new RepositorioDireccion(context);
            repositorioPersona = new RepositorioPersona(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
            gestorUsuario = new GestorUsuario(repositorioUsuario, gestorPersona);
            Direcciones = new List<Dominio.Entidades.Direccion>();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Direcciones"] = new List<Dominio.Entidades.Direccion>();
                CargarDatos();
            }
            else
            {
                var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion>;
                if (direcciones != null)
                {
                    gvDirecciones.DataSource = direcciones;
                    gvDirecciones.DataBind();
                }
            }
        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtMail.Text == "" || txtTelefono.Text == "" || txtContrasena.Text == "")
            {
                lblError.Text = "Completá nombre, apellido, mail, teléfono y contraseña";
                lblError.Visible = true;
                return;
            }
            if (direcciones.Count == 0)
            {
                lblError.Text = "Agregá al menos una dirección";
                lblError.Visible = true;
                return;
            }
            Dominio.Entidades.Usuario Usuario = new Dominio.Entidades.Usuario
            {
                NombreUsuario = txtMail.Text,
                Contraseña = txtContrasena.Text,
                Estado = true,
                Rol = Dominio.Entidades.Usuario.Roles.Empleado

            };

            Dominio.Entidades.Persona persona = new Dominio.Entidades.Persona
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Mail = txtMail.Text,
                Telefono = txtTelefono.Text,
            };

            await gestorUsuario.CargarUsuario(Usuario,persona,direcciones);
            lblConfirmacion.Text = "Usuario agregado correctamente";
            lblConfirmacion.Visible = true;
        }

        private void CargarDatos()
        {
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            gvDirecciones.DataSource = direcciones;
            gvDirecciones.DataBind();
        }

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            if (txtCalle.Text == "" || txtNumero.Text == "" || txtLocalidad.Text == "" || txtCodigo.Text == "")
            {
                lblError.Text = "Completá calle, número, localidad y código postal";
                lblError.Visible = true;
                return;
            }
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            Dominio.Entidades.Direccion direccion = new Dominio.Entidades.Direccion
            {
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Localidad = txtLocalidad.Text,
                CodigoPostal = txtCodigo.Text,
                Observaciones = txtObservaciones.Text
            };
            direcciones.Add(direccion);

            Session["Direcciones"] = direcciones;

            gvDirecciones.DataSource = direcciones;
            gvDirecciones.DataBind();
            lblConfirmacion.Text = "Dirección agregada correctamente";
            lblConfirmacion.Visible = true;
        }
        protected void gvDirecciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion>;
                if (direcciones != null)
                {
                    direcciones.RemoveAt(indice);
                    Session["Direcciones"] = direcciones;
                    gvDirecciones.DataSource = direcciones;
                    gvDirecciones.DataBind();
                }
            }
        }
    }
}
