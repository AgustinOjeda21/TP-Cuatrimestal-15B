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
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.Proveedor
{
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        private readonly mydbEntities1 context;
        private readonly RepositorioProveedor repositorioProveedor;
        private readonly GestorProveedor gestorProveedor;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private List<Dominio.Entidades.Direccion> Direcciones;
        public ModificarProveedor()
        {
            context = new mydbEntities1();
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
            Direcciones = new List<Dominio.Entidades.Direccion>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarProveedor));
        }

        private async Task BuscarProveedor()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorProveedor.CapturarProveedor(id);
            Session["ProveedorActual"] = forma;
            if (forma != null)
            {
                txtNombre.Text = forma.Nombre;
                txtMail.Text = forma.Mail;
                txtTelefono.Text = forma.Telefono;
                txtNombre.Enabled = true;
                txtMail.Enabled = true;
                txtTelefono.Enabled = true;
                btnModificarNombre.Enabled = true;
                btnModificarMail.Enabled = true;
                btnModificarTelefono.Enabled = true;
                txtCalle.Text = forma.Direccion.Calle;
                txtNumero.Text = forma.Direccion.Numero;
                txtLocalidad.Text = forma.Direccion.Localidad;
                txtCodigoPostal.Text = forma.Direccion.CodigoPostal;
                txtObservaciones.Text = forma.Direccion.Observaciones;
                txtCalle.Enabled = true;
                txtLocalidad.Enabled = true;
                txtCodigoPostal.Enabled = true;
                txtNumero.Enabled = true;
                txtObservaciones.Enabled = true;
                btnModificarCalle.Enabled = true;
                btnModificarNumero.Enabled = true;
                btnLocalidad.Enabled = true;
                btnCodigoPostal.Enabled = true;
                btnObservaciones.Enabled = true;
            }
        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorProveedor.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarMail_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarMail));
        }
        protected async Task ModificarMail()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorProveedor.ModificarMail(txtMail.Text, id);
        }
        protected void btnModificarTelefono_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarTelefono));
        }
        protected async Task ModificarTelefono()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorProveedor.ModificarTelefono(txtTelefono.Text, id);
        }

        protected void btnModificarCalle_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCalle));
        }
        protected async Task ModificarCalle()
        {
            var proveedor = Session["ProveedorActual"] as Dominio.Entidades.Proveedor;
            var resultado = await gestorDireccion.ModificarCalle(txtCalle.Text, proveedor.Direccion.IdDireccion);
        }

        protected void btnModificarNumero_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNumero));
        }
        protected async Task ModificarNumero()
        {
            var proveedor = Session["ProveedorActual"] as Dominio.Entidades.Proveedor;
            var resultado = await gestorDireccion.ModificarNumero(txtNumero.Text, proveedor.Direccion.IdDireccion);
        }
        protected void btnLocalidad_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarLocalidad));
        }
        protected async Task ModificarLocalidad()
        {
            var proveedor = Session["ProveedorActual"] as Dominio.Entidades.Proveedor;
            var resultado = await gestorDireccion.ModificarLocalidad(txtLocalidad.Text, proveedor.Direccion.IdDireccion);
        }

        protected void btnCodigoPostal_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarCodigo));
        }
        protected async Task ModificarCodigo()
        {
            var proveedor = Session["ProveedorActual"] as Dominio.Entidades.Proveedor;
            var resultado = await gestorDireccion.ModificarCodigoPostal(txtCodigoPostal.Text, proveedor.Direccion.IdDireccion);
        }
        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarObservaciones));
        }
        protected async Task ModificarObservaciones()
        {
            var proveedor = Session["ProveedorActual"] as Dominio.Entidades.Proveedor;
            var resultado = await gestorDireccion.ModificarObservaciones(txtObservaciones.Text, proveedor.Direccion.IdDireccion);
        }

    }
}
