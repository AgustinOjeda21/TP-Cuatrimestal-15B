using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class FiltroTraductor
    {
       public static IFiltroBusqueda<TDest> Traducir<TOrig, TDest, Tprop>(
       FiltroBusqueda<TOrig, Tprop> filtro, IMapper mapper)
        {
            return new FiltroBusqueda<TDest, Tprop>
            {
                Selector = mapper.MapExpression<Expression<Func<TDest, Tprop>>>(filtro.Selector),
                Operador = filtro.Operador,
                Valor = filtro.Valor,
                ValorHasta = filtro.ValorHasta
            };
        }

        public static IFiltroBusqueda<TDest> Traducir<TOrig, TDest>(
            IFiltroBusqueda<TOrig> filtro, IMapper mapper)
        {
            switch (filtro)
            {
                case FiltroBusqueda<TOrig, decimal> f:
                    return Traducir<TOrig, TDest, decimal>(f, mapper);
                case FiltroBusqueda<TOrig, int> f:
                    return Traducir<TOrig, TDest, int>(f, mapper);
                case FiltroBusqueda<TOrig, string> f:
                    return Traducir<TOrig, TDest, string>(f, mapper);
                case FiltroBusqueda<TOrig, DateTime> f:
                    return Traducir<TOrig, TDest, DateTime>(f, mapper);
                default:
                    throw new Exception("Tipo de filtro no soportado");
            }
        }
    }
}
