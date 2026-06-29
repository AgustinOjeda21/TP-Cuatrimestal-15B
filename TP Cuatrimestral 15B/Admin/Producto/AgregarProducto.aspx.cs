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

namespace TP_Cuatrimestral_15B.Admin.Producto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        protected Label lblPrecioError;
        protected Label lblStockError;
        protected Label lblMarcaError;
        protected Label lblCategoriaError;
        protected Label lblNombreImagenError;
        protected Label lblUrlImagenError;
        protected Label lblProveedorError;
        protected Label lblDescripcionError;
        private readonly mydbEntities1 context;
        private readonly RepositorioProducto repositorioProducto;
        private readonly GestorProducto gestorProducto;
        private readonly RepositorioMarca repositorioMarca;
        private readonly GestorMarca gestorMarca;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        private readonly RepositorioProveedor repositorioProveedor;
        private readonly GestorProveedor gestorProveedor;
        private readonly RepositorioDireccion repositorioDireccion;
        private readonly GestorDireccion gestorDireccion;
        private readonly RepositorioCategoria repositorioCategoria;
        private readonly GestorCategoria gestorCategoria;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            repositorioMarca = new RepositorioMarca(context);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            repositorioProducto = new RepositorioProducto(context);
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
            gestorProducto = new GestorProducto(repositorioProducto,gestorMarca,gestorImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Imagenes"] = new List<Dominio.Entidades.Imagen>();
                Session["Categorias"] = new List<Dominio.Entidades.Categoria>();
                Session["Proveedores"] = new List<Dominio.Entidades.Proveedor>();
                CargarDatos();
            }
            else
            {
                var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;
                if (imagenes != null)
                {
                    gvImagenes.DataSource = imagenes;
                    gvImagenes.DataBind();
                }
                var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria>;
                if (categorias != null)
                {
                    gvCategorias.DataSource = categorias;
                    gvCategorias.DataBind();
                }
                var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor>;
                if (proveedores != null)
                {
                    gvProveedores.DataSource = proveedores;
                    gvProveedores.DataBind();
                }
            }
        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            lblPrecioError.Visible = false;
            lblStockError.Visible = false;
            lblMarcaError.Visible = false;
            lblCategoriaError.Visible = false;
            lblNombreImagenError.Visible = false;
            lblUrlImagenError.Visible = false;
            lblProveedorError.Visible = false;
            lblDescripcionError.Visible = false;
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria> ?? new List<Dominio.Entidades.Categoria>();
            var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor> ?? new List<Dominio.Entidades.Proveedor>();
            decimal precio = 0;
            int stock = 0;
            bool hayError = false;
            if (txtNombre.Text == "")
            {
                lblNombreError.Text = "Ingresá el nombre";
                lblNombreError.Visible = true;
                hayError = true;
            }
            if (txtPrecio.Text == "")
            {
                lblPrecioError.Text = "Ingresá el precio";
                lblPrecioError.Visible = true;
                hayError = true;
            }
            else if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                lblPrecioError.Text = "El precio debe ser un número";
                lblPrecioError.Visible = true;
                hayError = true;
            }
            if (txtStock.Text == "")
            {
                lblStockError.Text = "Ingresá el stock";
                lblStockError.Visible = true;
                hayError = true;
            }
            else if (!int.TryParse(txtStock.Text, out stock))
            {
                lblStockError.Text = "El stock debe ser un número";
                lblStockError.Visible = true;
                hayError = true;
            }
            if (ddlMarca.SelectedValue == "")
            {
                lblMarcaError.Text = "Seleccioná una marca";
                lblMarcaError.Visible = true;
                hayError = true;
            }
            if (categorias.Count == 0)
            {
                lblCategoriaError.Text = "Agregá al menos una categoría";
                lblCategoriaError.Visible = true;
                hayError = true;
            }
            if (proveedores.Count == 0)
            {
                lblProveedorError.Text = "Agregá al menos un proveedor";
                lblProveedorError.Visible = true;
                hayError = true;
            }
            if (txtDescripcion.Text == "")
            {
                lblDescripcionError.Text = "Ingresá la descripción";
                lblDescripcionError.Visible = true;
                hayError = true;
            }
            if (hayError) return;
            var marca = await gestorMarca.CapturarMarca(int.Parse(ddlMarca.SelectedValue));
            Dominio.Entidades.Producto Producto = new Dominio.Entidades.Producto
            {
                Nombre = txtNombre.Text,
                Precio = precio,
                Stock = stock,
                Estado = true,
                Descripcion = txtDescripcion.Text,
                Categorias = categorias,
                Proveedores = proveedores,
                Marca = marca
            };
            await gestorProducto.CargarProducto(Producto,imagenes);
            lblConfirmacion.Text = "Producto agregado correctamente";
            lblConfirmacion.Visible = true;
        }
        private async void CargarDatos()
        {
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria> ?? new List<Dominio.Entidades.Categoria>();
            var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor> ?? new List<Dominio.Entidades.Proveedor>();
            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
            gvProveedores.DataSource = proveedores;
            gvProveedores.DataBind();

            var marcas = await gestorMarca.DevolverMarcas();
            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();

            var Categorias = await gestorCategoria.DevolverCategorias();
            ddlCategorias.DataSource = Categorias;
            ddlCategorias.DataTextField = "Nombre";
            ddlCategorias.DataValueField = "IdCategoria";
            ddlCategorias.DataBind();

            var proveedoresLista = await gestorProveedor.DevolverProveedores();
            ddlProveedores.DataSource = proveedoresLista;
            ddlProveedores.DataTextField = "Nombre";
            ddlProveedores.DataValueField = "IdProveedor";
            ddlProveedores.DataBind();
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            lblPrecioError.Visible = false;
            lblStockError.Visible = false;
            lblMarcaError.Visible = false;
            lblCategoriaError.Visible = false;
            lblNombreImagenError.Visible = false;
            lblUrlImagenError.Visible = false;
            lblProveedorError.Visible = false;
            lblDescripcionError.Visible = false;
            bool hayError = false;
            if (txtNombreImagen.Text == "")
            {
                lblNombreImagenError.Text = "Ingresá el nombre de la imagen";
                lblNombreImagenError.Visible = true;
                hayError = true;
            }
            if (txtUrlImagen.Text == "")
            {
                lblUrlImagenError.Text = "Ingresá la URL";
                lblUrlImagenError.Visible = true;
                hayError = true;
            }
            if (hayError) return;
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            Dominio.Entidades.Imagen imagen = new Dominio.Entidades.Imagen
            {
                Nombre = txtNombreImagen.Text,
                Descripcion = txtDescripcionImagen.Text,
                URL = txtUrlImagen.Text
            };
            imagenes.Add(imagen);

            Session["Imagenes"] = imagenes;

            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();
            lblConfirmacion.Text = "Imagen agregada correctamente";
            lblConfirmacion.Visible = true;
        }
        protected async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            lblPrecioError.Visible = false;
            lblStockError.Visible = false;
            lblMarcaError.Visible = false;
            lblCategoriaError.Visible = false;
            lblNombreImagenError.Visible = false;
            lblUrlImagenError.Visible = false;
            lblProveedorError.Visible = false;
            lblDescripcionError.Visible = false;
            if (ddlProveedores.SelectedValue == "")
            {
                lblProveedorError.Text = "Seleccioná un proveedor";
                lblProveedorError.Visible = true;
                return;
            }
            var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor> ?? new List<Dominio.Entidades.Proveedor>();
            var pro = await gestorProveedor.CapturarProveedor(int.Parse(ddlProveedores.SelectedValue));
            proveedores.Add(pro);
            Session["Proveedores"] = proveedores;
            gvProveedores.DataSource = proveedores;
            gvProveedores.DataBind();
            lblConfirmacion.Text = "Proveedor agregado correctamente";
            lblConfirmacion.Visible = true;
        }
        protected async void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            lblNombreError.Visible = false;
            lblPrecioError.Visible = false;
            lblStockError.Visible = false;
            lblMarcaError.Visible = false;
            lblCategoriaError.Visible = false;
            lblNombreImagenError.Visible = false;
            lblUrlImagenError.Visible = false;
            lblProveedorError.Visible = false;
            lblDescripcionError.Visible = false;
            if (ddlCategorias.SelectedValue == "")
            {
                lblCategoriaError.Text = "Seleccioná una categoría";
                lblCategoriaError.Visible = true;
                return;
            }
            var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria> ?? new List<Dominio.Entidades.Categoria>();
            var cat = await gestorCategoria.CapturarCategoria(int.Parse(ddlCategorias.SelectedValue));
            categorias.Add(cat);
            Session["Categorias"] = categorias;
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
            lblConfirmacion.Text = "Categoría agregada correctamente";
            lblConfirmacion.Visible = true;
        }
        protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                var Imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;
                if (Imagenes != null)
                {
                    Imagenes.RemoveAt(indice);
                    Session["Imagenes"] = Imagenes;
                    gvImagenes.DataSource = Imagenes;
                    gvImagenes.DataBind();
                }
            }
        }
        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor>;
                if (proveedores != null)
                {
                    proveedores.RemoveAt(indice);
                    Session["Proveedores"] = proveedores;
                    gvProveedores.DataSource = proveedores;
                    gvProveedores.DataBind();
                }
            }
        }
        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria>;
                if (categorias != null)
                {
                    categorias.RemoveAt(indice);
                    Session["Categorias"] = categorias;
                    gvCategorias.DataSource = categorias;
                    gvCategorias.DataBind();
                }
            }
        }
    }
}
