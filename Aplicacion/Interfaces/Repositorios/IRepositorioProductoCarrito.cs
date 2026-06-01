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


        Task<ProductoCarrito> CapturarProductoCarrito(int id);

        Task Actualizar(ProductoCarrito obj);
        
    }
}
