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


namespace TP_Cuatrimestral_15B.Admin.Categoria
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly GestorCategoria gestorCategoria;

        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            Dominio.Entidades.Categoria categoria = new Dominio.Entidades.Categoria
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
                
            };
            await gestorCategoria.CargarCategoria(categoria);
        }
    }
}