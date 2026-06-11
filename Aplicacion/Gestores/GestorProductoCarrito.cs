using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;

namespace Aplicacion.Gestores
{
    public class GestorProductoCarrito : IGestorProductoCarrito
    {
        IRepositorioProductoCarrito repo;
        IGestorCarrito gestorCarrito;
        IGestorProducto gestorProducto;

        public GestorProductoCarrito(IRepositorioProductoCarrito repo,IGestorCarrito gestorCarrito,IGestorProducto gestorProducto)
        {
            this.repo = repo;
            this.gestorProducto = gestorProducto;
            this.gestorCarrito = gestorCarrito;
        }

        public async Task<Result<ProductoCarrito>> AgregarProductoCarrito(ProductoCarrito edi)
        {
            var resultadoCarrito = await gestorCarrito.ValidarCarritoActivo(edi.Carrito.IdCarrito);
            if(!resultadoCarrito.Success)
            {
                return Result<ProductoCarrito>.Fail(resultadoCarrito.Message);
            }
            var resultadoProducto = await gestorProducto.ValidarProductoActivo(edi.Producto.IdProducto);
            if(!resultadoProducto.Success)
            {
                return Result<ProductoCarrito>.Fail(resultadoProducto.Message);
            }
            await repo.InsertarProductoCarrito(edi);
            return Result<ProductoCarrito>.EjecucionCorrecta();
        }

        public async Task<ProductoCarrito> CapturarProductoCarrito(int idCarrito, int idProducto)
        {
            var edi = await repo.CapturarProductoCarrito(idCarrito,idProducto);
            return edi;
        }
        public async Task<List<ProductoCarrito>> DevolverProductoCarritos()
        {
            return await repo.ObtenerProductoCarritoes();
        }

        public async Task<Result<ProductoCarrito>> ModificarCantidad(int Cantidad, int idCarrito, int idProducto)
        {
            var resultado = await ExisteProductoCarrito(idCarrito,idProducto);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Cantidad = Cantidad;
            await repo.Actualizar(edi);
            return Result<ProductoCarrito>.EjecucionCorrecta();
        }
        public async Task<Result<ProductoCarrito>> EliminarProducto(int Cantidad, int idCarrito, int idProducto)
        {
            var resultado = await ExisteProductoCarrito(idCarrito, idProducto);
            if (!resultado.Success)
            {
                return resultado;
            }
            var obj = resultado.Value;
            await repo.EliminarProductoCarrito(obj);
            return Result<ProductoCarrito>.EjecucionCorrecta();
        }

        public async Task<bool> ValidarProductoCarrito(int idCarrito, int idProducto)
        {
            return await repo.CapturarProductoCarrito(idCarrito,idProducto) != null;
        }

        public async Task<Result<ProductoCarrito>> ExisteProductoCarrito(int idCarrito, int idProducto)
        {
            ProductoCarrito obj = await repo.CapturarProductoCarrito(idCarrito,idProducto);
            if (obj is null)
            {
                return Result<ProductoCarrito>.Fail("No existe el producto ingresado en ese carrito ");
            }
            return Result<ProductoCarrito>.Ok(obj);
        }
    }
}
