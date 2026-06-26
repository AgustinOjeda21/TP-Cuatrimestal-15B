using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioProductoCarrito
    {
        Task<List<ProductoCarrito>> ObtenerProductoCarritoes();

        Task InsertarProductoCarrito(ProductoCarrito aut);

        Task<ProductoCarrito> CapturarProductoCarrito(int idCarrito, int idProducto);

        Task Actualizar(ProductoCarrito obj);
        Task<List<ProductoCarrito>> Buscar(Busqueda<ProductoCarrito> busqueda);
        Task Eliminar(int idCarrito, int idProducto);


    }
}
