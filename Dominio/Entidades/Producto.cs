using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Producto
    {
        public Producto() { }
        public Producto(int idProducto, string nombre, string descripcion, decimal precio, int stock, bool estado, Marca marca, ICollection<ProductoCarrito> productoCarritos, ICollection<Imagen> imagens, ICollection<Categoria> categorias, ICollection<Proveedor> proveedors)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Estado = estado;
            Marca = marca;
            ProductoCarrito = productoCarritos;
            Imagen = imagens;
            Categoria = categorias;
            Proveedor = proveedors;
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual ICollection<ProductoCarrito> ProductoCarrito { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
