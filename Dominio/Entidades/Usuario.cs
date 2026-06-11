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
        public Usuario(int idUsuario,string nombreUsuario,string contraseña, bool estado, int rol)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Estado = estado;
            Rol = (Roles)rol;
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public Roles Rol { get; set; }
        public enum Roles
        {
            Empleado = 1,
            Administrador = 2,
            Cliente = 3
        }
    }

    
}
