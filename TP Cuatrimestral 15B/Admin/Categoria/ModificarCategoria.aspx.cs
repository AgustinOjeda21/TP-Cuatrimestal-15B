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

namespace TP_Cuatrimestral_15B.Admin.Categoria
{
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly GestorCategoria gestorCategoria;
        public ModificarCategoria()
        {
            context = new mydbEntities1();
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarCategoria));
        }

        private async Task BuscarCategoria()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorCategoria.CapturarCategoria(id);
            if (forma != null)
            {
                txtDescripcion.Text = forma.Descripcion;
                txtNombre.Text = forma.Nombre;
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                btnModificarNombre.Enabled = true;
                btnModificarDescripcion.Enabled = true;
            }

        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorCategoria.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarDescripcion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
        }
        protected async Task ModificarDescripcion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorCategoria.ModificarDescripcion(txtDescripcion.Text, id);
        }
    }
}