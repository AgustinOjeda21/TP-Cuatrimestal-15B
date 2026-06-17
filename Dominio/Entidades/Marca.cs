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
        public Marca(int idMarca, string nombre, List<Imagen> imagenes)
        {
            IdMarca = idMarca;
            Nombre = nombre;
            Imagenes = imagenes;
            
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}
