using System;
using System.Threading.Tasks;
using System.Web.UI;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;

namespace TP_Cuatrimestral_15B.Admin.Categoria
{
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioCategoria repositorioCategoria = new RepositorioCategoria(context);
        private static readonly GestorCategoria gestorCategoria = new GestorCategoria(repositorioCategoria);

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                int id;
                if (!int.TryParse(txtIdBuscar.Text, out id))
                    return;
                var categoria = await gestorCategoria.CapturarCategoria(id);
                if (categoria == null)
                    return;
                Session["CategoriaIdModificar"] = id;
                txtNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion;
            }));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["CategoriaIdModificar"] == null)
                return;
            int id = (int)Session["CategoriaIdModificar"];
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                await gestorCategoria.ModificarNombre(nombre, id);
                await gestorCategoria.ModificarDescripcion(descripcion, id);
            }));
        }
    }
}
