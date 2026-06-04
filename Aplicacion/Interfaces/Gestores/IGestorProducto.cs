using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorProducto
    {
        Task<Result<Producto>> CargarProducto(Producto edi);
        Task<Producto> CapturarProducto(int id);
        Task<List<Producto>> DevolverProductos();
        Task<Result<Producto>> ModificarNombre(string Nombre, int id);
        Task<Result<Producto>> ModificarDescripcion(string Descripcion, int id);
        Task<Result<Producto>> ModificarPrecio(decimal Precio, int id);
        Task<Result<Producto>> ModificarStock(int Stock, int id);
        Task<Result<Producto>> ModificarMarca(Marca marca, int id);
        Task<Result<Producto>> DarDeBajaAlta(int ID, bool Estado);
        Task<bool> ValidarProducto(int id);
        Task<Result<Producto>> ExisteProducto(int id);
        Task<Result<Producto>> ValidarProductoActivo(int id);


    }
}

