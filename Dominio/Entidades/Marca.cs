using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Marca
    {
        public Marca(int idMarca, string nombre, ICollection<Producto> productos, ICollection<Imagen> imagens)
        {
            IdMarca = idMarca;
            Nombre = nombre;
            Producto = productos;
            Imagen = imagens;
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
    }
}
