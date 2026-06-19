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

namespace TP_Cuatrimestral_15B.Admin.Proveedor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        protected Label lblTelefonoError;
        protected Label lblMailError;
        protected Label lblCalleError;
        protected Label lblNumeroError;
        protected Label lblLocalidadError;
        protected Label lblCodigoError;
        private readonly mydbEntities1 context;
        private readonly RepositorioProveedor repositorioProveedor;
        private readonly GestorProveedor gestorProveedor;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private List<Dominio.Entidades.Direccion> Direcciones;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor,gestorDireccion);
            Direcciones = new List<Dominio.Entidades.Direccion>();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            lblTelefonoError.Visible = false;
            lblMailError.Visible = false;
            lblCalleError.Visible = false;
            lblNumeroError.Visible = false;
            lblLocalidadError.Visible = false;
            lblCodigoError.Visible = false;
            bool hayError = false;
            if (txtNombre.Text == "")
            {
                lblNombreError.Text = "Ingresá el nombre";
                lblNombreError.Visible = true;
                hayError = true;
            }
            if (txtTelefono.Text == "")
            {
                lblTelefonoError.Text = "Ingresá el teléfono";
                lblTelefonoError.Visible = true;
                hayError = true;
            }
            if (txtMail.Text == "")
            {
                lblMailError.Text = "Ingresá el mail";
                lblMailError.Visible = true;
                hayError = true;
            }
            if (txtCalle.Text == "")
            {
                lblCalleError.Text = "Ingresá la calle";
                lblCalleError.Visible = true;
                hayError = true;
            }
            if (txtNumero.Text == "")
            {
                lblNumeroError.Text = "Ingresá el número";
                lblNumeroError.Visible = true;
                hayError = true;
            }
            if (txtLocalida.Text == "")
            {
                lblLocalidadError.Text = "Ingresá la localidad";
                lblLocalidadError.Visible = true;
                hayError = true;
            }
            if (txtCodigo.Text == "")
            {
                lblCodigoError.Text = "Ingresá el código postal";
                lblCodigoError.Visible = true;
                hayError = true;
            }
            if (hayError) return;
            Dominio.Entidades.Direccion direccion = new Dominio.Entidades.Direccion
            {
                Calle = txtCalle.Text,
                Numero = txtNumero.Text,
                Localidad = txtLocalida.Text,
                CodigoPostal = txtCodigo.Text,
                Observaciones = txtObservacion.Text
            };
            Dominio.Entidades.Proveedor Proveedor = new Dominio.Entidades.Proveedor
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Mail = txtMail.Text,
            };
            await gestorProveedor.CargarProveedor(Proveedor,direccion);
            lblConfirmacion.Text = "Proveedor agregado correctamente";
            lblConfirmacion.Visible = true;
        }

    }
}
