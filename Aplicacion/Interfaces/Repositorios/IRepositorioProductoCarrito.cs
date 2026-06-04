using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioProductoCarrito
    {
        Task<List<ProductoCarrito>> ObtenerProductoCarritoes();

        Task InsertarProductoCarrito(ProductoCarrito aut);

        Task EliminarProductoCarrito(ProductoCarrito aut);
        Task<ProductoCarrito> CapturarProductoCarrito(int idCarrito, int idProducto);

        Task Actualizar(ProductoCarrito obj);
        
    }
}
