using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Permiso
    {
        public Permiso() { }
        public Permiso(int idPermiso, string nombre)
        {
            IdPermiso = idPermiso;
            Nombre = nombre;
        }

        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
    }
}
