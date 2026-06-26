using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Busqueda
{
    public class Busqueda<T>
    {
        public List<IFiltroBusqueda<T>> Filtros { get; set; }
        public Busqueda()
        {
            Filtros = new List<IFiltroBusqueda<T>>();
        }
    }
}
