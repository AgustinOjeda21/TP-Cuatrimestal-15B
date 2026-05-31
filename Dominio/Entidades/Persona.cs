using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Persona
    {
        public Persona() { }
        public Persona(int idPersona,string nombre, string apellido, string mail, string telefono, ICollection<Pedido> pedidos, Usuario usuario, ICollection<Direccion> direccions)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Mail = mail;
            Apellido = apellido;
            Telefono = telefono;
            Pedido = pedidos;
            Usuario = usuario;
            Direccion = direccions;
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
    }
}
