using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class CategoriaExtension
    {
        public static Categoria ToDomain(this EntityCategoria categoria)
        {
            return new Categoria(categoria.IdCategoria, categoria.Nombre, categoria.Descripcion);
        }
        public static EntityCategoria ToEntity(this Categoria categoria)
        {
            return new EntityCategoria(categoria.IdCategoria, categoria.Nombre, categoria.Descripcion);
        }
    }
}
