using System;
using System.Linq;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B
{
    public partial class Sign_in : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
                Response.Redirect("~/Inicio.aspx");
        }

        protected async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            mydbEntities context = new mydbEntities();
            RepositorioRol repoRol = new RepositorioRol(context);
            RepositorioPersona repoPersona = new RepositorioPersona(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            GestorRol gestorRol = new GestorRol(repoRol);
            GestorPersona gestorPersona = new GestorPersona(repoPersona);
            GestorUsuario gestorUsuario = new GestorUsuario(repoUsuario, gestorRol, gestorPersona);

            var roles = await gestorRol.DevolverRoles();
            var rolCliente = roles.FirstOrDefault(r => r.Nombre == "Cliente");

            if (rolCliente == null)
                return;

            Usuario usuario = new Usuario
            {
                NombreUsuario = txtEmail.Text.Trim(),
                Contraseña = txtPassword.Text,
                Estado = true,
                Rol = rolCliente
            };

            Persona persona = new Persona
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Mail = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Usuario = usuario
            };

            await gestorUsuario.CargarUsuario(usuario, persona);
            Response.Redirect("~/Log_in.aspx");
        }
    }
}
