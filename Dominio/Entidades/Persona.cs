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
        public Persona(int idPersona,string nombre, string apellido, string mail, string telefono,Usuario usuario, List<Direccion> direcciones)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Mail = mail;
            Apellido = apellido;
            Telefono = telefono;
            Usuario = usuario;
            Direcciones = direcciones;
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public Usuario Usuario { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
}
