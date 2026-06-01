using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Rol
    {
        public Rol() { }
        public Rol(int idRol, string nombre)
        {
            IdRol = idRol;
            Nombre = nombre;
           
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        
    }
}
