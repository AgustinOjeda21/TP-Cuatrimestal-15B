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

namespace TP_Cuatrimestral_15B.Admin.FormaEntrega
{
    public partial class AgregarFormaEntrega : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        private readonly mydbEntities1 context;
        private readonly RepositorioFormaEntrega repositorioFormaEntrega;
        private readonly GestorFormaEntrega gestorFormaEntrega;
        public AgregarFormaEntrega()
        {
            context = new mydbEntities1();
            repositorioFormaEntrega = new RepositorioFormaEntrega(context);
            gestorFormaEntrega = new GestorFormaEntrega(repositorioFormaEntrega);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            if (txtNombre.Text == "" || txtDescripcion.Text == "")
            {
                lblError.Text = "Completá nombre y descripción";
                lblError.Visible = true;
                return;
            }
            Dominio.Entidades.FormaEntrega formaEntrega = new Dominio.Entidades.FormaEntrega
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            await gestorFormaEntrega.CargarFormaEntrega(formaEntrega);
            lblConfirmacion.Text = "Forma de entrega agregada correctamente";
            lblConfirmacion.Visible = true;
        }
    }
}
