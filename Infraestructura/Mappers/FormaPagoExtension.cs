using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class FormaPagoExtension
    {
        public static FormaPago ToDomain(this EntityFormaPago formaPago)
        {
            return new FormaPago(formaPago.IdFormaPago, formaPago.Nombre, formaPago.Descripcion);
        }
        public static EntityFormaPago ToEntity(this FormaPago formaPago)
        {
            return new EntityFormaPago(formaPago.IdFormaPago, formaPago.Nombre, formaPago.Descripcion);
        }

    }
}
