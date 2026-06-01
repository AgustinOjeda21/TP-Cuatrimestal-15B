using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class FormaEntregaExtension
    {
        public static FormaEntrega ToDomain(this EntityFormaEntrega formaEntrega)
        {
            return new FormaEntrega(formaEntrega.IdFormaEntrega, formaEntrega.Nombre, formaEntrega.Descripcion);
        }
        public static EntityFormaEntrega ToEntity(this FormaEntrega formaEntrega)
        {
            return new EntityFormaEntrega(formaEntrega.IdFormaEntrega, formaEntrega.Nombre, formaEntrega.Descripcion);
        }
    }
}
