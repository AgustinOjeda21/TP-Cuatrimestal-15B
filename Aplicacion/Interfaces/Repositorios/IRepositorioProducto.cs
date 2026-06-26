using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioProducto
    {
        Task<List<Producto>> ObtenerProductos();

        Task InsertarProducto(Producto aut);


        Task<Producto> CapturarProducto(int id);

        Task Actualizar(Producto obj);
        Task Eliminar(int id);
        Task QuitarImagen(int Producto, int IdImagen);
        Task AgregarImagen(int Producto, Imagen Imagen);
        Task QuitarProveedor(int Producto, int IdProveedor);
        Task AgregarProveedor(int Producto, Proveedor Proveedor);
        Task QuitarCategoria(int Producto, int IdCategoria);
        Task AgregarCategoria(int Producto, Categoria Categoria);
        Task ActualizarMarca(Producto obj);
        Task<List<Producto>> Buscar(Busqueda<Producto> busqueda);

    }
}
