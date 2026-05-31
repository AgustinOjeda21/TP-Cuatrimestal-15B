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
        public Permiso(int idPermiso, string nombre, ICollection<Rol> rols)
        {
            IdPermiso = idPermiso;
            Nombre = nombre;
            Rol = rols;
        }

        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Rol> Rol { get; set; }
    }
}
