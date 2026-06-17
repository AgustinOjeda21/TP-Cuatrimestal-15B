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
        }

    }
}