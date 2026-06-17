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

namespace TP_Cuatrimestral_15B.Admin.Imagen
{
    public partial class ModificarImagen : System.Web.UI.Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        public ModificarImagen()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            gestorImagen = new GestorImagen(repositorioImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarImagen));
        }

        private async Task BuscarImagen()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorImagen.CapturarImagen(id);
            if (forma != null)
            {
                txtDescripcion.Text = forma.Descripcion;
                txtNombre.Text = forma.Nombre;
                txtUrl.Text = forma.URL;
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                txtUrl.Enabled = true;
                ModificarUrl.Enabled = true;
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
            var resultado = await gestorImagen.ModificarNombre(txtNombre.Text, id);
        }

        protected void btnModificarDescripcion_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
        }
        protected async Task ModificarDescripcion()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorImagen.ModificarDescripcion(txtDescripcion.Text, id);
        }
        protected void btnModificarUrl_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarURL));
        }
        protected async Task ModificarURL()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorImagen.ModificarURL(txtDescripcion.Text, id);
        }
    }
}