using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion.Busqueda;
using System.Threading.Tasks;


namespace Infraestructura.Especificaciones
{
    public static class EspecificacionFactory<T>
    {
        public static Especificacion<T> CrearSpec(IFiltroBusqueda<T> Filtro)
        {
            switch(Filtro)
            {
                case FiltroBusqueda<T, decimal> f:
                    return DefinirSpec(f);
                case FiltroBusqueda<T, int> f:
                    return DefinirSpec(f);
                case FiltroBusqueda<T, DateTime> f:
                    return DefinirSpec(f);
                case FiltroBusqueda<T, string> f:
                    return DefinirSpec(f);
                case FiltroBusqueda<T, bool> f:
                    return DefinirSpec(f);
                default:
                    throw new Exception("Error de programa");
            }
        }

        private static Especificacion<T> DefinirSpec<Tprop>(FiltroBusqueda<T, Tprop> Filtro)
        {
            switch (Filtro.Operador)
            {
                case OperadorBusqueda.Igual:
                    return new EsIgualEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor);
                case OperadorBusqueda.MayorQue:
                    return new MayorEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor);
                case OperadorBusqueda.MenorQue:
                    return new MenorEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor);
                case OperadorBusqueda.Entre:
                    return new EntreEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor, Filtro.ValorHasta);
                case OperadorBusqueda.MayorMenor:
                    return new MayorMenorEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor, Filtro.ValorHasta);
                case OperadorBusqueda.Contiene:
                    return new BuscarStringEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor, "Contains");
                case OperadorBusqueda.EmpiezaCon:
                    return new BuscarStringEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor, "StartsWith");
                case OperadorBusqueda.TerminaCon:
                    return new BuscarStringEspecificacion<T, Tprop>(Filtro.Selector, Filtro.Valor, "EndsWith");
                default:
                    throw new Exception("Error de programa");
            }
        }
    }
}
