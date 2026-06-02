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
            mydbEntities context = new mydbEntities();
            RepositorioRol repoRol = new RepositorioRol(context);
            RepositorioPersona repoPersona = new RepositorioPersona(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            GestorRol gestorRol = new GestorRol(repoRol);
            GestorPersona gestorPersona = new GestorPersona(repoPersona);
            GestorUsuario gestorUsuario = new GestorUsuario(repoUsuario, gestorRol, gestorPersona);

            var usuarios = await gestorUsuario.DevolverUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == txtNombreUsuario.Text.Trim() && u.Contraseña == txtContraseña.Text);

            if (usuario == null)
            {
                lblError.Visible = true;
                return;
            }

            Session["Usuario"] = usuario;

            if (usuario.Rol != null && usuario.Rol.Nombre == "Admin")
                Response.Redirect("~/Admin/Inicio.aspx");
            else
                Response.Redirect("~/Inicio.aspx");
        }
    }
}
