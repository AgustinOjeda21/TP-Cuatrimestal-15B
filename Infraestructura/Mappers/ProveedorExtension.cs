using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Infraestructura.Mappers
{
    public static class ProveedorExtension
    {
        public static Proveedor ToDomain(this EntityProveedor proveedor)
        {
            return new Proveedor(proveedor.IdProveedor, proveedor.Nombre, proveedor.Telefono, proveedor.Mail, proveedor.Estado, proveedor.Direccion.ToDomain());
        }
        public static EntityProveedor ToEntity(this Proveedor proveedor)
        {
            return new EntityProveedor(proveedor.IdProveedor, proveedor.Nombre, proveedor.Telefono, proveedor.Mail, proveedor.Estado, proveedor.Direccion.IdDireccion);
        }
    }
}
