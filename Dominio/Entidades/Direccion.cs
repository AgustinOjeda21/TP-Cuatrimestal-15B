using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Direccion
    {
        public Direccion() { }
        public Direccion(int idDireccion, string calle, string numero, string localidad, string codigo, string observaciones, ICollection<DetallePedido> detalles, ICollection<Proveedor> proveedors, ICollection<Persona> personas)
        {
            IdDireccion = idDireccion;
            Calle = calle;
            Numero = numero;
            Localidad = localidad;
            CodigoPostal = codigo;
            Observaciones = observaciones;
            DetallePedido = detalles;
            Proveedor = proveedors;
            Persona = personas;
        }

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Observaciones { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
