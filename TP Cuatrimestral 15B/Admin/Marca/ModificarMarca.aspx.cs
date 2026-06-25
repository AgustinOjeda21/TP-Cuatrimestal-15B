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
using System.Threading.Tasks;

namespace TP_Cuatrimestral_15B.Admin.Marca
{
    public partial class ModificarMarca : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        protected Label lblNombreError;
        protected Label lblNombreImagenError;
        protected Label lblUrlImagenError;
        private readonly mydbEntities1 context;
        private readonly RepositorioMarca repositorioMarca;
        private readonly GestorMarca gestorMarca;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        public ModificarMarca()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioMarca = new RepositorioMarca(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Imagenes"] = new List<Dominio.Entidades.Imagen>();
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(BuscarMarca));
        }

        private async Task BuscarMarca()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var forma = await gestorMarca.CapturarMarca(id);
            if (forma != null)
            {
                txtNombre.Text = forma.Nombre;
                txtNombre.Enabled = true;
                txtDescripcionImagen.Enabled = true;
                txtNombreImagen.Enabled = true;
                txtUrlImagen.Enabled = true;
                btnAgregarImagen.Enabled = true;
                btnModificarNombre.Enabled = true;
                Session["MarcaActual"] = forma;
                Session["Imagenes"] = forma.Imagenes;
                gvImagenes.DataSource = forma.Imagenes;
                gvImagenes.DataBind();
            }
        }
        protected void btnModificarNombre_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ModificarNombre));
        }
        protected async Task ModificarNombre()
        {
            int id = Convert.ToInt32(txtIdBuscar.Text);
            var resultado = await gestorMarca.ModificarNombre(txtNombre.Text, id);
        }
        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AgregarImagen));
        }

        protected async Task AgregarImagen()
        {
            var marca = Session["MarcaActual"] as Dominio.Entidades.Marca;
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            Dominio.Entidades.Imagen imagen = new Dominio.Entidades.Imagen
            {
                Nombre = txtNombreImagen.Text,
                Descripcion = txtDescripcionImagen.Text,
                URL = txtUrlImagen.Text
            };
            await gestorMarca.AgregarImagen(marca.IdMarca, imagen);
            imagenes.Add(imagen);

            Session["Imagenes"] = imagenes;

            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();
        }

        protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var marca = Session["MarcaActual"] as Dominio.Entidades.Marca;
            if (e.CommandName == "Quitar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;

                if (imagenes != null)
                {
                    Session["ImagenQuitar"] = imagenes[indice].IdImagen;
                    imagenes.RemoveAt(indice);
                    Session["Imagenes"] = imagenes;
                    RegisterAsyncTask(new PageAsyncTask(Quitar));
                }
            }
        }
        protected async Task Quitar()
        {
            var marca = Session["MarcaActual"] as Dominio.Entidades.Marca;
            if (Session["ImagenQuitar"] == null) return;
            int imagen = (int)Session["ImagenQuitar"];
            if (marca != null)
            {
                await gestorMarca.QuitarImagen(marca.IdMarca,imagen);
                var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen>;
                gvImagenes.DataSource = imagenes;
                gvImagenes.DataBind();
            }

        }
    }
}
