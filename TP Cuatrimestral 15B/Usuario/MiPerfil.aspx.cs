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
using Aplicacion.Busqueda;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Usuario
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioPersona repositorioPersona;
        private readonly GestorPersona gestorPersona;
        protected Label lblError;
        protected Label lblConfirmacion;
        public WebForm5()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            repositorioPersona = new RepositorioPersona(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorPersona = new GestorPersona(repositorioPersona, gestorDireccion);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CargarPersona));
        }
        public async Task CargarPersona()
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
            lblMail.Text = persona.Mail;
            lblNombre.Text = $"{persona.Nombre} {persona.Apellido}";
            lblTelefono.Text = persona.Telefono;
        }
    }
}
