using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class AdminCategorias : Page
    {
        private readonly mydbEntities1 context;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly GestorCategoria gestorCategoria;
        public AdminCategorias()
        {
            context = new mydbEntities1();
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            RegisterAsyncTask(new PageAsyncTask(CargarCategorias));
            
        }

        private async Task CargarCategorias()
        {
            var resultado = await gestorCategoria.DevolverCategorias();
            rptCategorias.DataSource = resultado;
            rptCategorias.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                var resultado = await gestorCategoria.DevolverCategorias();
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                    resultado = resultado.Where(c => c.Nombre.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                rptCategorias.DataSource = resultado;
                rptCategorias.DataBind();
            }));
        }

        protected void rptCategorias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    await gestorCategoria.EliminarCategoria(id);
                    var resultado = await gestorCategoria.DevolverCategorias();
                    rptCategorias.DataSource = resultado;
                    rptCategorias.DataBind();
                }));
            }
        }
    }
}
