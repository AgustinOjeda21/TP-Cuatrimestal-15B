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
        protected Label lblNombreError;
        protected Label lblApellidoError;
        protected Label lblMailError;
        protected Label lblTelefonoError;
        protected Label lblContrasenaError;
        protected Label lblCalleError;
        protected Label lblNumeroError;
        protected Label lblLocalidadError;
        protected Label lblCodigoError;
        protected Label lblDireccionesError;
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
            lblNombreError.Visible = false;
            lblApellidoError.Visible = false;
            lblMailError.Visible = false;
            lblTelefonoError.Visible = false;
            lblContrasenaError.Visible = false;
            lblCalleError.Visible = false;
            lblNumeroError.Visible = false;
            lblLocalidadError.Visible = false;
            lblCodigoError.Visible = false;
            lblDireccionesError.Visible = false;
            var direcciones = Session["Direcciones"] as List<Dominio.Entidades.Direccion> ?? new List<Dominio.Entidades.Direccion>();
            bool hayError = false;
            if (txtNombre.Text == "")
            {
                lblNombreError.Text = "Ingresá el nombre";
                lblNombreError.Visible = true;
                hayError = true;
            }
            if (txtApellido.Text == "")
            {
                lblApellidoError.Text = "Ingresá el apellido";
                lblApellidoError.Visible = true;
                hayError = true;
            }
            if (txtMail.Text == "")
            {
                lblMailError.Text = "Ingresá el mail";
                lblMailError.Visible = true;
                hayError = true;
            }
            if (txtTelefono.Text == "")
            {
                lblTelefonoError.Text = "Ingresá el teléfono";
                lblTelefonoError.Visible = true;
                hayError = true;
            }
            if (txtContrasena.Text == "")
            {
                lblContrasenaError.Text = "Ingresá la contraseña";
                lblContrasenaError.Visible = true;
                hayError = true;
            }
            if (direcciones.Count == 0)
            {
                lblDireccionesError.Text = "Agregá al menos una dirección";
                lblDireccionesError.Visible = true;
                hayError = true;
            }
            if (hayError) return;
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
            lblNombreError.Visible = false;
            lblApellidoError.Visible = false;
            lblMailError.Visible = false;
            lblTelefonoError.Visible = false;
            lblContrasenaError.Visible = false;
            lblCalleError.Visible = false;
            lblNumeroError.Visible = false;
            lblLocalidadError.Visible = false;
            lblCodigoError.Visible = false;
            lblDireccionesError.Visible = false;
            bool hayError = false;
            if (txtCalle.Text == "")
            {
                lblCalleError.Text = "Ingresá la calle";
                lblCalleError.Visible = true;
                hayError = true;
            }
            if (txtNumero.Text == "")
            {
                lblNumeroError.Text = "Ingresá el número";
                lblNumeroError.Visible = true;
                hayError = true;
            }
            if (txtLocalidad.Text == "")
            {
                lblLocalidadError.Text = "Ingresá la localidad";
                lblLocalidadError.Visible = true;
                hayError = true;
            }
            if (txtCodigo.Text == "")
            {
                lblCodigoError.Text = "Ingresá el código postal";
                lblCodigoError.Visible = true;
                hayError = true;
            }
            if (hayError) return;
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
