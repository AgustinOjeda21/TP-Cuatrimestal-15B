using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class MarcaExtension
    {
        public static Marca ToDomain(this EntityMarca marca)
        {
            return new Marca(marca.IdMarca, marca.Nombre);
        }
        public static EntityMarca ToEntity(this Marca marca)
        {
            return new EntityMarca(marca.IdMarca, marca.Nombre);
        }
    }
}
