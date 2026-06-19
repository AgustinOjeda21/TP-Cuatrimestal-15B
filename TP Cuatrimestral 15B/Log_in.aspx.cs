using System;
using System.Linq;
using System.Data.Entity;
using System.Web.UI;
using Infraestructura;
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
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (nombreUsuario == "admin" && contrasena == "pass")
            {
                Session["Usuario"] = new Dominio.Entidades.Usuario
                {
                    IdUsuario = 0,
                    NombreUsuario = "admin",
                    Contraseña = "pass",
                    Estado = true,
                    Rol = Dominio.Entidades.Usuario.Roles.Administrador
                };

                Response.Redirect("~/Admin/Inicio.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            mydbEntities1 context = new mydbEntities1();
            var usuarios = await context.Usuario.ToListAsync();
            var usuarioEntity = usuarios.FirstOrDefault(u => u.NombreUsuario != null && u.Contraseña != null && u.NombreUsuario.Trim().ToLower() == nombreUsuario.ToLower() && u.Contraseña.Trim() == contrasena);

            if (usuarioEntity == null)
            {
                lblError.Text = "Usuario o contraseña incorrectos";
                lblError.Visible = true;
                return;
            }

            Dominio.Entidades.Usuario usuario = new Dominio.Entidades.Usuario
            {
                IdUsuario = usuarioEntity.IdUsuario,
                NombreUsuario = usuarioEntity.NombreUsuario,
                Contraseña = usuarioEntity.Contraseña,
                Estado = usuarioEntity.Estado,
                Rol = (Dominio.Entidades.Usuario.Roles)usuarioEntity.Rol
            };

            Session["Usuario"] = usuario;

            if (usuario.Rol==Dominio.Entidades.Usuario.Roles.Administrador)
                Response.Redirect("~/Admin/Inicio.aspx", false);
            else
                Response.Redirect("~/Inicio.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
