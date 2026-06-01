using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class ImagenExtension
    {
        public static Imagen ToDomain(this EntityImagen imagen)
        {
            return new Imagen(imagen.IdImagen, imagen.Nombre, imagen.Descripcion, imagen.URL);
        }
        public static EntityImagen ToEntity(this Imagen imagen)
        {
            return new EntityImagen(imagen.IdImagen, imagen.Nombre, imagen.Descripcion, imagen.URL);
        }
    }
}
