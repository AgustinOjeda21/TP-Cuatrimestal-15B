using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EstadoPedido
    {
        public EstadoPedido() { }
        public EstadoPedido(int idEstadoPedido, string nombre, string descripcion)
        {
            IdEstadoPedido = idEstadoPedido;
            Nombre = nombre;
            Descripcion = descripcion;
            
        }

        public int IdEstadoPedido { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
