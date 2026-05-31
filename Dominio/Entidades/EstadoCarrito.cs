using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EstadoCarrito
    {
        public EstadoCarrito() { }
        public EstadoCarrito(int idEstadoCarrito,string nombre,ICollection<Carrito> carritos)
        {
            IdEstadoCarrito = idEstadoCarrito;
            Nombre = nombre;
            Carrito = carritos;
        }

        public int IdEstadoCarrito { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Carrito> Carrito { get; set; }
    }
}
