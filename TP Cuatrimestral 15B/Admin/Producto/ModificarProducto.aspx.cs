using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using Dominio.Entidades;

namespace TP_Cuatrimestral_15B.Admin.Producto
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        private static readonly mydbEntities1 context = new mydbEntities1();
        private static readonly RepositorioImagen repositorioImagen = new RepositorioImagen(context);
        private static readonly RepositorioMarca repositorioMarca = new RepositorioMarca(context);
        private static readonly RepositorioProducto repositorioProducto = new RepositorioProducto(context);

        private static readonly GestorImagen gestorImagen = new GestorImagen(repositorioImagen);
        private static readonly GestorMarca gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        private static readonly GestorProducto gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(CargarMarcas));
            }
        }

        private async Task CargarMarcas()
        {
            var marcas = await gestorMarca.DevolverMarcas();
            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                int id;
                if (!int.TryParse(txtIdBuscar.Text, out id))
                    return;
                var producto = await gestorProducto.CapturarProducto(id);
                if (producto == null)
                    return;
                Session["ProductoIdModificar"] = id;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;
                TextBox1.Text = producto.Precio.ToString();
                TextBox2.Text = producto.Stock.ToString();
            }));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["ProductoIdModificar"] == null)
                return;
            int id = (int)Session["ProductoIdModificar"];
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string precioTexto = TextBox1.Text;
            string stockTexto = TextBox2.Text;
            string marcaId = ddlMarca.SelectedValue;

            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                await gestorProducto.ModificarNombre(nombre, id);
                await gestorProducto.ModificarDescripcion(descripcion, id);
                decimal precio;
                if (decimal.TryParse(precioTexto, out precio))
                    await gestorProducto.ModificarPrecio(precio, id);
                int stock;
                if (int.TryParse(stockTexto, out stock))
                    await gestorProducto.ModificarStock(stock, id);
                if (!string.IsNullOrEmpty(marcaId))
                {
                    var marca = await gestorMarca.CapturarMarca(int.Parse(marcaId));
                    await gestorProducto.ModificarMarca(marca, id);
                }
            }));
        }
    }
}
