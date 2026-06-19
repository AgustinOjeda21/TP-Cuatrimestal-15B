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

namespace TP_Cuatrimestral_15B.Admin.EstadoCarrito
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        private readonly mydbEntities1 context;
        private readonly RepositorioEstadoCarrito repositorioEstadoCarrito;
        private readonly GestorEstadoCarrito gestorEstadoCarrito;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioEstadoCarrito = new RepositorioEstadoCarrito(context);
            gestorEstadoCarrito = new GestorEstadoCarrito(repositorioEstadoCarrito);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            if (txtNombre.Text == "")
            {
                lblNombreError.Text = "Ingresá el nombre";
                lblNombreError.Visible = true;
                return;
            }
            Dominio.Entidades.EstadoCarrito estadoCarrito = new Dominio.Entidades.EstadoCarrito
            {
                Nombre = txtNombre.Text
            };
            await gestorEstadoCarrito.CargarEstadoCarrito(estadoCarrito);
            lblConfirmacion.Text = "Estado de carrito agregado correctamente";
            lblConfirmacion.Visible = true;
        }

    }
}
