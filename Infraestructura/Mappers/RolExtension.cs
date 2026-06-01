using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class RolExtension
    {
        public static Rol ToDomain(this EntityRol rol)
        {
            return new Rol(rol.IdRol, rol.Nombre);
        }
        public static EntityRol ToEntity(this Rol rol)
        {
            return new EntityRol(rol.IdRol, rol.Nombre);
        }
    }
}
