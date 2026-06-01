using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class FormaEntrega
    {
        public FormaEntrega() { }
        public FormaEntrega(int idFormaEntrega, string nombre, string descripcion)
        {
            IdFormaEntrega = idFormaEntrega;
            Nombre = nombre;
            Descripcion = descripcion;
            
        }

        public int IdFormaEntrega { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
    }
}
