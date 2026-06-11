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
            mydbEntities1 context = new mydbEntities1();
            RepositorioPersona repoPersona = new RepositorioPersona(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            RepositorioDireccion repositorioDireccion = new RepositorioDireccion(context);
            GestorDireccion gestorDireccion = new GestorDireccion(repositorioDireccion);
            GestorPersona gestorPersona = new GestorPersona(repoPersona,gestorDireccion);
            GestorUsuario gestorUsuario = new GestorUsuario(repoUsuario, gestorPersona);


            Usuario usuario = new Usuario
            {
                NombreUsuario = txtEmail.Text,
                Contraseña = txtPassword.Text,
                Estado = true,
                Rol = Usuario.Roles.Administrador
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

            Persona persona = new Persona
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Mail = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Usuario = usuario,
                Direcciones = new System.Collections.Generic.List<Direccion>()
                
            };

            await gestorUsuario.CargarUsuario(usuario, persona,direccion);
            Response.Redirect("~/Log_in.aspx");
        }
    }
}
