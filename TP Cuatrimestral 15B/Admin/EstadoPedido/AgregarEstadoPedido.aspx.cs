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

namespace TP_Cuatrimestral_15B.Admin.EstadoPedido
{
    public partial class WebForm1 : System.Web.UI.Page
    {
            protected Label lblError;
            protected Label lblConfirmacion;
            protected Label lblNombreError;
            protected Label lblDescripcionError;
        
            private readonly mydbEntities1 context;
            private readonly RepositorioEstadoPedido repositorioEstadoPedido;
            private readonly GestorEstadoPedido gestorEstadoPedido;
            public WebForm1()
            {
                context = new mydbEntities1();
                repositorioEstadoPedido = new RepositorioEstadoPedido(context);
                gestorEstadoPedido = new GestorEstadoPedido(repositorioEstadoPedido);
            }
            protected void Page_Load(object sender, EventArgs e)
            {

            }
            protected async void btnGuardar_Click(object sender, EventArgs e)
            {
                lblError.Visible = false;
                lblConfirmacion.Visible = false;
                lblNombreError.Visible = false;
                lblDescripcionError.Visible = false;
                bool hayError = false;
                if (txtNombre.Text == "")
                {
                    lblNombreError.Text = "Ingresá el nombre";
                    lblNombreError.Visible = true;
                    hayError = true;
                }
                if (txtDescripcion.Text == "")
                {
                    lblDescripcionError.Text = "Ingresá la descripción";
                    lblDescripcionError.Visible = true;
                    hayError = true;
                }
                if (hayError) return;
                Dominio.Entidades.EstadoPedido estadoPedido = new Dominio.Entidades.EstadoPedido
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text
                };
                await gestorEstadoPedido.CargarEstadoPedido(estadoPedido);
                lblConfirmacion.Text = "Estado de pedido agregado correctamente";
                lblConfirmacion.Visible = true;
            }
    }
}
