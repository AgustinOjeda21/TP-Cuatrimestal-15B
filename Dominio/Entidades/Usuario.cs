using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int idUsuario,string nombreUsuario,string contraseña, bool estado, Rol rol)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Estado = estado;
            Rol = rol;
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
