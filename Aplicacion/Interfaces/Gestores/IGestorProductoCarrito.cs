using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorProductoCarrito
    {
       Task<Result<ProductoCarrito>> AgregarProductoCarrito(ProductoCarrito edi);


        Task<ProductoCarrito> CapturarProductoCarrito(int idCarrito, int idProducto);

        Task<List<ProductoCarrito>> DevolverProductoCarritos();


        Task<Result<ProductoCarrito>> ModificarCantidad(int Cantidad, int idCarrito, int idProducto);
        Task Eliminar(int idCarrito, int idProducto);
        Task<bool> ValidarProductoCarrito(int idCarrito, int idProducto);
        Task<List<ProductoCarrito>> DevolverProductoCarrito(int idCarrito);
        Task<Result<ProductoCarrito>> ExisteProductoCarrito(int idCarrito, int idProducto);
       
    }
}

