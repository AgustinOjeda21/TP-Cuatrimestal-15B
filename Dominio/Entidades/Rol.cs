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
        public Rol(int idRol, string nombre, ICollection<Usuario> usuarios, ICollection<Permiso> permisos)
        {
            IdRol = idRol;
            Nombre = nombre;
            Usuario = usuarios;
            Permiso = permisos;
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }

        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
