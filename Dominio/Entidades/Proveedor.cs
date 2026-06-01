using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Proveedor
    {
        public Proveedor() { }
        public Proveedor(int idProveedor, string nombre, string telefono, string mail, bool estado, Direccion direccion)
        {
            IdProveedor = idProveedor;
            Nombre = nombre;
            Telefono = telefono;
            Mail = mail;
            Estado = estado;
            Direccion = direccion;
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; }
        public Direccion Direccion { get; set; }

    }
}
