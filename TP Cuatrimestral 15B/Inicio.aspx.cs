using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Dominio.Entidades;
using System.Linq.Expressions;
using Infraestructura;

namespace TP_Cuatrimestral_15B
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddExpressionMapping();

                    cfg.CreateMap<Carrito, EntityCarrito>()
                    .ForMember(d => d.Total,
                    o => o.MapFrom(s => s.Total));

                    cfg.CreateMap<EntityCarrito, Carrito>()
                       .ForMember(d => d.Total,
                           o => o.MapFrom(s => s.Total));
                });

                var mapper = config.CreateMapper();

                Expression<Func<Carrito, bool>> exp =
                 c => c.Total > 1000;

                var expEntity =
                    mapper.MapExpression<
                        Expression<Func<EntityCarrito, bool>>
                    >(exp);

                Response.Write(expEntity.GetType().ToString());
                Response.Write("<br/>");
                Response.Write(expEntity.Parameters[0].Type.Name);
            }*/
        }
    }
}