using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Imagen
    {
        public Imagen() { }
        public Imagen(int idImagen, string nombre, string descripcion, string Url, ICollection<Marca> marcas, ICollection<Producto> productos)
        {
            IdImagen = idImagen;
            Nombre = nombre;
            Descripcion = descripcion;
            URL = Url;
            Marca = marcas;
            Producto = productos;
        }

        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
