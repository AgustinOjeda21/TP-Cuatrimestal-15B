using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Marca
    {
        public Marca() { }
        public Marca(int idMarca, string nombre)
        {
            IdMarca = idMarca;
            Nombre = nombre;
            
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; }
    }
}
