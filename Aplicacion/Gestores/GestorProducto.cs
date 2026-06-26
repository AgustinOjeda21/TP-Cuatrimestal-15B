using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;

namespace Aplicacion.Gestores
{
    public class GestorProducto : IGestorProducto
    {
        IRepositorioProducto repo;
        IGestorMarca gestorMarca;
        IGestorImagen gestorImagen;

        public GestorProducto(IRepositorioProducto repo, IGestorMarca gestorMarca,IGestorImagen gestorImagen)
        {
            this.repo = repo;
            this.gestorMarca = gestorMarca;
            this.gestorImagen = gestorImagen;
        }

        public async Task<Result<Producto>> CargarProducto(Producto edi,List<Imagen> imagenes)
        {
            var resultado = await gestorMarca.ExisteMarca(edi.Marca.IdMarca);
            if(!resultado.Success)
            {
                return Result<Producto>.Fail("La marca ingresada no existe");
            }
            edi.Imagenes = imagenes;
            await repo.InsertarProducto(edi);
            return Result<Producto>.EjecucionCorrecta();
        }

        public async Task<Producto> CapturarProducto(int id)
        {
            var edi = await repo.CapturarProducto(id);
            return edi;
        }
        public async Task<List<Producto>> DevolverProductos()
        {
            return await repo.ObtenerProductos();
        }

        public async Task<Result<Producto>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteProducto(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Producto>.EjecucionCorrecta();
        }

        public async Task<Result<Producto>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteProducto(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<Producto>.EjecucionCorrecta();
        }
        public async Task<Result<Producto>> ModificarPrecio(decimal Precio, int id)
        {
            var resultado = await ExisteProducto(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Precio = Precio;
            await repo.Actualizar(edi);
            return Result<Producto>.EjecucionCorrecta();
        }
        public async Task<Result<Producto>> ModificarStock(int Stock, int id)
        {
            var resultado = await ExisteProducto(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Stock = Stock;
            await repo.Actualizar(edi);
            return Result<Producto>.EjecucionCorrecta();
        }
        public async Task<Result<Producto>> ModificarMarca(Marca marca, int id)
        {
            var resultado = await ExisteProducto(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var resultadomar = await gestorMarca.ExisteMarca(marca.IdMarca);
            if (!resultadomar.Success)
            {
                return Result<Producto>.Fail("La marca ingresada no existe");
            }
            var edi = resultado.Value;
            edi.Marca = marca;
            await repo.ActualizarMarca(edi);
            return Result<Producto>.EjecucionCorrecta();
        }
        public async Task<Result<Producto>> DarDeBajaAlta(int ID, bool Estado)
        {
            var resultado = await ExisteProducto(ID);
            if (!resultado.Success)
            {
                return resultado;
            }
            var pro = resultado.Value;
            if (pro.Estado == Estado)
            {
                return Result<Producto>.Fail("El Producto ya se encuentra en ese estado");
            }
            pro.Estado = Estado;
            await repo.Actualizar(pro);
            return Result<Producto>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarProducto(int id)
        {
            return await repo.CapturarProducto(id) != null;
        }

        public async Task<Result<Producto>> ExisteProducto(int id)
        {
            Producto obj = await repo.CapturarProducto(id);
            if (obj is null)
            {
                return Result<Producto>.Fail("El Producto ingresado no existe");
            }
            return Result<Producto>.Ok(obj);
        }
        public async Task<Result<Producto>> ValidarProductoActivo(int id)
        {
            Producto obj = await repo.CapturarProducto(id);
            if (obj is null)
            {
                return Result<Producto>.Fail("El Producto ingresado no existe");
            }
            if(!obj.Estado)
            {
                return Result<Producto>.Fail("El producto ingresado esta dado de baja");
            }
            return Result<Producto>.Ok(obj);
        }
        public async Task EliminarProducto(int id)
        {
            await repo.Eliminar(id);
        }

        public async Task AgregarCategoria(int idPersona, Categoria Categoria)
        {
            await repo.AgregarCategoria(idPersona, Categoria);
        }
        public async Task QuitarCategoria(int idPersona, int idCategoria)
        {
            await repo.QuitarCategoria(idPersona, idCategoria);
        }

        public async Task AgregarImagen(int idPersona, Imagen Imagen)
        {
            await repo.AgregarImagen(idPersona, Imagen);
        }
        public async Task QuitarImagen(int idPersona, int idImagen)
        {
            await repo.QuitarImagen(idPersona, idImagen);
        }

        public async Task AgregarProveedor(int idPersona, Proveedor Proveedor)
        {
            await repo.AgregarProveedor(idPersona, Proveedor);
        }
        public async Task QuitarProveedor(int idPersona, int idProveedor)
        {
            await repo.QuitarProveedor(idPersona, idProveedor);
        }
        public async Task<List<Producto>> Buscar(Busqueda<Producto> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
