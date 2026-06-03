using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Busqueda
{
    public class FiltroBusqueda<T,Tprop> : IFiltroBusqueda<T>
    {
        public Expression<Func<T,Tprop>> Selector { get; set; }
        public OperadorBusqueda Operador { get; set; }
        public Tprop Valor { get; set; }
        public Tprop ValorHasta { get; set; }
    }
}
