using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infraestructura.Repositorios;
using Aplicacion.Gestores;
using Infraestructura;
using Dominio.Entidades;
using System.Collections.Generic;

namespace TP_Cuatrimestral_15B.Admin.Producto
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
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
        public ModificarProducto()
        {
            context = new mydbEntities1();
            repositorioDireccion = new RepositorioDireccion(context);
            gestorDireccion = new GestorDireccion(repositorioDireccion);
            repositorioMarca = new RepositorioMarca(context);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            repositorioProducto = new RepositorioProducto(context);
            repositorioProveedor = new RepositorioProveedor(context);
            repositorioImagen = new RepositorioImagen(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorProveedor = new GestorProveedor(repositorioProveedor, gestorDireccion);
            repositorioCategoria = new RepositorioCategoria(context);
            gestorCategoria = new GestorCategoria(repositorioCategoria);
            gestorProducto = new GestorProducto(repositorioProducto, gestorMarca, gestorImagen);
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
            }

            private void CargarDatos()
            {
                var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
                var categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria> ?? new List<Dominio.Entidades.Categoria>();
                var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor> ?? new List<Dominio.Entidades.Proveedor>();
                gvImagenes.DataSource = imagenes;
                gvImagenes.DataBind();
                gvCategoriasSeleccionadas.DataSource = categorias;
                gvCategoriasSeleccionadas.DataBind();
                gvProveedores.DataSource = proveedores;
                gvProveedores.DataBind();
        }
            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(BuscarProducto));
            }

            private async Task BuscarProducto()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var forma = await gestorProducto.CapturarProducto(id);
                if (forma != null)
                {
                    ddlCategorias.Enabled = true;
                    btnAgregarProveedor.Enabled = true;
                    btnAgregarImagen.Enabled = true;
                    btnAgregarCategoria.Enabled = true;
                    ddlMarca.Enabled = true;
                    btnMarca.Enabled = true;
                    btnAgregarCategoria.Enabled = true;
                    txtNombre.Enabled = true;
                    ddlProveedor.Enabled = true;
                    txtDescripcion.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;
                    txtNombreImagen.Enabled = true;
                    txtDescripcionImagen.Enabled = true;
                    txtUrlImagen.Enabled = true;
                    txtNombre.Text = forma.Nombre;
                    txtDescripcion.Text = forma.Descripcion;
                    txtStock.Text = forma.Stock.ToString();
                    txtPrecio.Text = forma.Precio.ToString();
                    btnNombre.Enabled = true;
                    btnDescripcion.Enabled = true;
                    btnPrecio.Enabled = true;
                    btnStock.Enabled = true;
                    Session["ProductoActual"] = forma;
                    Session["Imagenes"] = forma.Imagenes;
                    gvImagenes.DataSource = forma.Imagenes;
                    gvImagenes.DataBind();
                    Session["Proveedores"] = forma.Proveedores;
                    gvProveedores.DataSource = forma.Proveedores;
                    gvProveedores.DataBind();
                    Session["Categorias"] = forma.Categorias;
                    gvCategoriasSeleccionadas.DataSource = forma.Categorias;
                    gvCategoriasSeleccionadas.DataBind();
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
                    ddlProveedor.DataSource = proveedoresLista;
                    ddlProveedor.DataTextField = "Nombre";
                    ddlProveedor.DataValueField = "IdProveedor";
                    ddlProveedor.DataBind();
                    ddlMarca.SelectedValue = forma.Marca.IdMarca.ToString();

            }

            }
            protected void btnNombre_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
            }
            protected async Task ModificarNombre()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var resultado = await gestorProducto.ModificarNombre(txtNombre.Text, id);
            }
            protected void btnDescripcion_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(ModificarDescripcion));
            }
            protected async Task ModificarDescripcion()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var resultado = await gestorProducto.ModificarDescripcion(txtDescripcion.Text, id);
            }

            protected void btnMarca_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(ModificarMarca));
            }
            protected async Task ModificarMarca()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var marca = await gestorMarca.CapturarMarca(int.Parse(ddlMarca.SelectedValue));
                var resultado = await gestorProducto.ModificarMarca(marca, id);
            }
        protected void btnStock_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(ModificarStock));
            }
            protected async Task ModificarStock()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var resultado = await gestorProducto.ModificarStock(int.Parse(txtStock.Text), id);
            }

            protected void btnPrecio_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(ModificarPrecio));
            }
            protected async Task ModificarPrecio()
            {
                int id = Convert.ToInt32(txtIdBuscar.Text);
                var resultado = await gestorProducto.ModificarPrecio(decimal.Parse(txtPrecio.Text), id);
            }

            protected void btnAgregarImagen_Click(object sender, EventArgs e)
            {
                RegisterAsyncTask(new PageAsyncTask(AgregarImagen));
            }

            protected async Task AgregarImagen()
            {
                var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
                
                var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
                Dominio.Entidades.Imagen imagen = new Dominio.Entidades.Imagen
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcionImagen.Text,
                    URL = txtUrlImagen.Text
                };
                await gestorProducto.AgregarImagen(Producto.IdProducto, imagen);
                imagenes.Add(imagen);

                Session["Imagenes"] = imagenes;

                gvImagenes.DataSource = imagenes;
                gvImagenes.DataBind();
                
            }

            protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
                if (e.CommandName == "Quitar")
                {
                    int indice = Convert.ToInt32(e.CommandArgument);
                    var Imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;

                    if (Imagenes != null)
                    {
                        Session["ImagenQuitar"] = Imagenes[indice].IdImagen;
                        Imagenes.RemoveAt(indice);
                        Session["Imagenes"] = Imagenes;
                        RegisterAsyncTask(new PageAsyncTask(Quitar));
                    }
                }
            }
            protected async Task Quitar()
            {
                var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
                if (Session["ImagenQuitar"] == null) return;
                int Imagen = (int)Session["ImagenQuitar"];
                if (Producto != null)
                {
                    await gestorProducto.QuitarImagen(Producto.IdProducto, Imagen);
                    var Imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;
                    gvImagenes.DataSource = Imagenes;
                    gvImagenes.DataBind();
                }

            }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarCategoria));
        }
        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarProveedor));
        }

        protected async Task AgregarProveedor()
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            var proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor> ?? new List<Dominio.Entidades.Proveedor>();
            var pro = await gestorProveedor.CapturarProveedor(int.Parse(ddlProveedor.SelectedValue));
            await gestorProducto.AgregarProveedor(Producto.IdProducto, pro);
            proveedores.Add(pro);
            Session["Proveedores"] = proveedores;
            gvProveedores.DataSource = proveedores;
            gvProveedores.DataBind();
            
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                var Proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor>;

                if (Proveedores != null)
                {
                    Session["ProveedorQuitar"] = Proveedores[indice].IdProveedor;
                    Proveedores.RemoveAt(indice);
                    Session["Proveedores"] = Proveedores;
                    RegisterAsyncTask(new PageAsyncTask(QuitarProveedor));
                }
            }
        }
        protected async Task QuitarProveedor()
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            if (Session["ProveedorQuitar"] == null) return;
            int Proveedor = (int)Session["ProveedorQuitar"];
            if (Producto != null)
            {
                await gestorProducto.QuitarProveedor(Producto.IdProducto, Proveedor);
                var Proveedores = Session["Proveedores"] as List<Dominio.Entidades.Proveedor>;
                gvProveedores.DataSource = Proveedores;
                gvProveedores.DataBind();
            }

        }

        protected async Task AgregarCategoria()
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            var Categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria> ?? new List<Dominio.Entidades.Categoria>();
            var cat = await gestorCategoria.CapturarCategoria(int.Parse(ddlCategorias.SelectedValue));
            await gestorProducto.AgregarCategoria(Producto.IdProducto, cat);
            Categorias.Add(cat);
            Session["Categorias"] = Categorias;
            gvCategoriasSeleccionadas.DataSource = Categorias;
            gvCategoriasSeleccionadas.DataBind();
           
        }

        protected void gvCategoriasSeleccionadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                var Categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria>;

                if (Categorias != null)
                {
                    Session["CategoriaQuitar"] = Categorias[indice].IdCategoria;
                    Categorias.RemoveAt(indice);
                    Session["Categorias"] = Categorias;
                    RegisterAsyncTask(new PageAsyncTask(QuitarCategoria));
                }
            }
        }
        protected async Task QuitarCategoria()
        {
            var Producto = Session["ProductoActual"] as Dominio.Entidades.Producto;
            if (Session["CategoriaQuitar"] == null) return;
            int Categoria = (int)Session["CategoriaQuitar"];
            if (Producto != null)
            {
                await gestorProducto.QuitarCategoria(Producto.IdProducto, Categoria);
                var Categorias = Session["Categorias"] as List<Dominio.Entidades.Categoria>;
                gvCategoriasSeleccionadas.DataSource = Categorias;
                gvCategoriasSeleccionadas.DataBind();
            }

        }

    }
}
