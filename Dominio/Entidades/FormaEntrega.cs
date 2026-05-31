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
        public FormaEntrega(int idFormaEntrega, string nombre, string descripcion, ICollection<DetallePedido> detalles)
        {
            IdFormaEntrega = idFormaEntrega;
            Nombre = nombre;
            Descripcion = descripcion;
            DetallePedido = detalles;
        }

        public int IdFormaEntrega { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
