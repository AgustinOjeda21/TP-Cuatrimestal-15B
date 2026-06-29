using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorProducto
    {
        Task<Result<Producto>> CargarProducto(Producto edi, List<Imagen> imagenes);
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
        Task EliminarProducto(int id);
        Task AgregarProveedor(int idPersona, Proveedor Proveedor);
        Task QuitarProveedor(int idPersona, int idProveedor);
        Task<bool> ConsultarStock(int idProducto, int cantidad);
        Task AgregarCategoria(int idPersona, Categoria Categoria);
        Task QuitarCategoria(int idPersona, int idCategoria);
        Task AgregarImagen(int idPersona, Imagen Imagen);
        Task QuitarImagen(int idPersona, int idImagen);


    }
}

