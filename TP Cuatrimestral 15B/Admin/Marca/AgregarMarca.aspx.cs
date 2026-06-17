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

namespace TP_Cuatrimestral_15B.Admin.Marca
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Label lblError;
        protected Label lblConfirmacion;
        private readonly mydbEntities1 context;
        private readonly RepositorioMarca repositorioMarca;
        private readonly GestorMarca gestorMarca;
        private readonly RepositorioImagen repositorioImagen;
        private readonly GestorImagen gestorImagen;
        public WebForm1()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioMarca = new RepositorioMarca(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorMarca = new GestorMarca(repositorioMarca,gestorImagen);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Imagenes"] = new List<Dominio.Entidades.Imagen>();
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
            }
        }
        protected async void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            if (txtNombre.Text == "")
            {
                lblError.Text = "Completá el nombre";
                lblError.Visible = true;
                return;
            }
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            Dominio.Entidades.Marca Marca = new Dominio.Entidades.Marca
            {
                Nombre = txtNombre.Text,
            };
            await gestorMarca.CargarMarca(Marca,imagenes);
            lblConfirmacion.Text = "Marca agregada correctamente";
            lblConfirmacion.Visible = true;
        }
        private void CargarDatos()
        {
            var imagenes = Session["Imagenes"] as List<Dominio.Entidades.Imagen> ?? new List<Dominio.Entidades.Imagen>();
            gvImagenes.DataSource = imagenes;
            gvImagenes.DataBind();
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblConfirmacion.Visible = false;
            if (txtNombreImagen.Text == "" || txtUrlImagen.Text == "")
            {
                lblError.Text = "Completá nombre y URL de la imagen";
                lblError.Visible = true;
                return;
            }
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
    }
}
