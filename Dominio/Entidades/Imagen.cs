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
        public Imagen(int idImagen, string nombre, string descripcion, string Url)
        {
            IdImagen = idImagen;
            Nombre = nombre;
            Descripcion = descripcion;
            URL = Url;
            
        }

        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }
     
    }
}
