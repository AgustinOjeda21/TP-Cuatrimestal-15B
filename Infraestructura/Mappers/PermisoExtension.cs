using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class PermisoExtension
    {
        public static Permiso ToDomain(this EntityPermiso permiso)
        {
            return new Permiso(permiso.IdPermiso, permiso.Nombre);
        }
        public static EntityPermiso ToEntity(this Permiso permiso)
        {
            return new EntityPermiso(permiso.IdPermiso, permiso.Nombre);
        }
    }
}
