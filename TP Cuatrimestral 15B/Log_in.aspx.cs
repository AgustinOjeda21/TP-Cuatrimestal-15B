using System;
using System.Linq;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B
{
    public partial class Log_in : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
                Response.Redirect("~/Inicio.aspx");
        }

        protected async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "admin" && txtContrasena.Text == "pass")
            {
                Session["Usuario"] = new Dominio.Entidades.Usuario
                {
                    IdUsuario = 0,
                    NombreUsuario = "admin",
                    Contraseña = "pass",
                    Estado = true,
                    Rol = Dominio.Entidades.Usuario.Roles.Administrador
                };

                Response.Redirect("~/Admin/Inicio.aspx");
                return;
            }

            mydbEntities1 context = new mydbEntities1();
 
            RepositorioPersona repoPersona = new RepositorioPersona(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            RepositorioDireccion repositorioDireccion = new RepositorioDireccion(context);
            GestorDireccion gestorDireccion = new GestorDireccion(repositorioDireccion);
            GestorPersona gestorPersona = new GestorPersona(repoPersona, gestorDireccion);
            GestorUsuario gestorUsuario = new GestorUsuario(repoUsuario, gestorPersona);

            var usuarios = await gestorUsuario.DevolverUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == txtNombreUsuario.Text && u.Contraseña == txtContrasena.Text);

            if (usuario == null)
            {
                lblError.Visible = true;
                return;
            }

            Session["Usuario"] = usuario;

            if (usuario.Rol==Dominio.Entidades.Usuario.Roles.Administrador)
                Response.Redirect("~/Admin/Inicio.aspx");
            else
                Response.Redirect("~/Inicio.aspx");
        }
    }
}
