using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class DireccionExtension
    {
        public static Direccion ToDomain(this EntityDireccion direccion)
        {
            return new Direccion(direccion.IdDireccion, direccion.Calle, direccion.Numero, direccion.Localidad, direccion.Calle, direccion.Observaciones);
        }
        public static EntityDireccion ToEntity(this Direccion direccion)
        {
            return new EntityDireccion(direccion.IdDireccion, direccion.Calle, direccion.Numero, direccion.Localidad, direccion.Calle, direccion.Observaciones);
        }
    }
}
