using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class UsuarioExtension
    {
        public static Usuario ToDomain(this EntityUsuario usuario)
        {
            return new Usuario(usuario.IdUsuario, usuario.NombreUsuario, usuario.Contraseña, usuario.Estado, usuario.Rol.ToDomain());
        }
        public static EntityUsuario ToEntity(this Usuario usuario)
        {
            return new EntityUsuario(usuario.IdUsuario, usuario.NombreUsuario, usuario.Contraseña, usuario.Estado, usuario.Rol.IdRol);
        }
    }
}
