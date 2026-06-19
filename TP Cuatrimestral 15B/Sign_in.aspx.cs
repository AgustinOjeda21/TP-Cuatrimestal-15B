using System;
using System.Linq;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using Dominio.Entidades;
using System.Collections.Generic;

namespace TP_Cuatrimestral_15B
{
    public partial class Sign_in : Page
    {
        protected System.Web.UI.WebControls.Label lblError;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
                Response.Redirect("~/Inicio.aspx");
        }

        protected async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            mydbEntities1 context = new mydbEntities1();
            RepositorioPersona repoPersona = new RepositorioPersona(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            RepositorioDireccion repositorioDireccion = new RepositorioDireccion(context);
            GestorDireccion gestorDireccion = new GestorDireccion(repositorioDireccion);
            GestorPersona gestorPersona = new GestorPersona(repoPersona,gestorDireccion);
            GestorUsuario gestorUsuario = new GestorUsuario(repoUsuario, gestorPersona);

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmarPassword = txtConfirmarPassword.Text.Trim();

            lblError.Visible = false;

            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || email == "" || txtTelefono.Text.Trim() == "" || password == "" || confirmarPassword == "" || txtCalle.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtLocalidad.Text.Trim() == "" || txtCodigoPostal.Text.Trim() == "")
            {
                lblError.Text = "Completá todos los campos obligatorios";
                lblError.Visible = true;
                return;
            }

            if (password != confirmarPassword)
            {
                lblError.Text = "Las contraseñas no coinciden";
                lblError.Visible = true;
                return;
            }

            var usuarios = await gestorUsuario.DevolverUsuarios();
            var usuarioExistente = usuarios.FirstOrDefault(u => u.NombreUsuario != null && u.NombreUsuario.Trim().ToLower() == email.ToLower());

            if (usuarioExistente != null)
            {
                lblError.Text = "Ya existe una cuenta con ese mail";
                lblError.Visible = true;
                return;
            }

            Dominio.Entidades.Usuario usuario = new Dominio.Entidades.Usuario
            {
                NombreUsuario = email,
                Contraseña = password,
                Estado = true,
                Rol = Dominio.Entidades.Usuario.Roles.Cliente
            };
            string Obs = txtObservaciones.Text;
            if(txtObservaciones.Text is null)
            {
                Obs = "Sin observaciones";
            }
            Direccion direccion = new Direccion
            {
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Localidad = txtLocalidad.Text,
                CodigoPostal = txtCodigoPostal.Text,
                Observaciones = Obs
            };

            List<Direccion> direcciones = new List<Direccion>();
            direcciones.Add(direccion);

            Persona persona = new Persona
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Mail = email,
                Telefono = txtTelefono.Text,
                Usuario = usuario,
            };

            await gestorUsuario.CargarUsuario(usuario, persona,direcciones);
            Response.Redirect("~/Log_in.aspx");
        }
    }
}
