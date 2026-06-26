using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion.Gestores;
using Infraestructura;
using Infraestructura.Repositorios;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Dominio.Entidades;
using System.Linq.Expressions;

namespace TP_Cuatrimestral_15B.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
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
        private List<string> campos;

        public WebForm5()
        {
            context = new mydbEntities1();
            repositorioImagen = new RepositorioImagen(context);
            repositorioMarca = new RepositorioMarca(context);
            gestorImagen = new GestorImagen(repositorioImagen);
            gestorMarca = new GestorMarca(repositorioMarca, gestorImagen);
            campos = new List<string>{ "IdMarca","Nombre" };
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["FiltrosMarca"] = new Busqueda<Dominio.Entidades.Marca>();
                CargarOperadores();
                CargarPropiedades();
            }
            RegisterAsyncTask(new PageAsyncTask(CargarMarca));

        }
        private async Task CargarMarca()
        {
            var resultado = await gestorMarca.DevolverMarcas();
            rptMarca.DataSource = resultado;
            rptMarca.DataBind();
        }
        private void CargarOperadores()
        {
            ddlOperacion.DataSource = Enum.GetValues(typeof(OperadorBusqueda))
            .Cast<OperadorBusqueda>()
            .Select(x => new {
                Text = x.ToString(),
                Value = (int)x
            });

            ddlOperacion.DataTextField = "Text";
            ddlOperacion.DataValueField = "Value";
            ddlOperacion.DataBind();
        }
        private void CargarPropiedades()
        {
            ddlCampo.DataSource = campos;
            ddlCampo.DataBind();
        }

        protected void btnAgregarFiltro_Click(object sender, EventArgs e)
        {
            Busqueda<Dominio.Entidades.Marca> busqueda = (Busqueda<Dominio.Entidades.Marca>)Session["FiltrosMarca"];
            if(busqueda is null)
            {
                busqueda = new Busqueda<Dominio.Entidades.Marca>();
            }
            var campo = ddlCampo.SelectedValue;
            switch (campo)
            {
                case "IdMarca":
                    var filtroInt = new FiltroBusqueda<Dominio.Entidades.Marca, int>
                    {
                        Selector = obj => obj.IdMarca,
                        Operador = (OperadorBusqueda)int.Parse(ddlOperacion.SelectedValue),
                        Valor = int.Parse(txtValor.Text),
                        ValorHasta = string.IsNullOrEmpty(txtValorHasta.Text) ? 0 : int.Parse(txtValorHasta.Text)
                    };
                    busqueda.Filtros.Add(filtroInt);
                    break;

                case "Nombre":
                    var filtroString = new FiltroBusqueda<Dominio.Entidades.Marca, string>
                    {
                        Selector = obj => obj.Nombre,
                        Operador = (OperadorBusqueda)int.Parse(ddlOperacion.SelectedValue),
                        Valor = txtValor.Text,
                        ValorHasta = string.IsNullOrEmpty(txtValorHasta.Text) ? null : txtValorHasta.Text
                    };
                    busqueda.Filtros.Add(filtroString);
                    break;

                default:
                    throw new Exception("Campo no soportado");
            }
            Session["FiltrosMarca"] = busqueda;
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(Buscar));
        }
        public async Task Buscar()
        {
            Busqueda<Dominio.Entidades.Marca> busqueda = (Busqueda<Dominio.Entidades.Marca>)Session["FiltrosMarca"];
            var resultado = await gestorMarca.Buscar(busqueda);
            rptMarca.DataSource = resultado;
            rptMarca.DataBind();
            Session["FiltrosMarca"] = new Busqueda<Dominio.Entidades.Marca>();
        }

    }
}
