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
        public Direccion(int idDireccion, string calle, string numero, string localidad, string codigo, string observaciones)
        {
            IdDireccion = idDireccion;
            Calle = calle;
            Numero = numero;
            Localidad = localidad;
            CodigoPostal = codigo;
            Observaciones = observaciones;
        }

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Observaciones { get; set; }
    }
}
