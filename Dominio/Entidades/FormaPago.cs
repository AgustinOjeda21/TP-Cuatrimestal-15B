using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class FormaPago
    {
        public FormaPago() { }
        public FormaPago(int idFormaPago,string nombre, string descripcion)
        {
            IdFormaPago = idFormaPago;
            Nombre = nombre;
            Descripcion = descripcion;
            
        }

        public int IdFormaPago { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
     
    }
}
