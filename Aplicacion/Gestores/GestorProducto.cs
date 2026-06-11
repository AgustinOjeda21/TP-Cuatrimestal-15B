using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorProducto : IGestorProducto
    {
        IRepositorioProducto repo;
        IGestorMarca gestorMarca;

        public GestorProducto(IRepositorioProducto repo, IGestorMarca gestorMarca)
        {
            this.repo = repo;
            this.gestorMarca = gestorMarca;
        }

        public async Task<Result<Producto>> CargarProducto(Producto edi)
        {
            var resultado = await gestorMarca.ExisteMarca(edi.Marca.IdMarca);
            if(!resultado.Success)
            {
                return Result<Producto>.Fail("La marca ingresada no existe");
            }
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
            await repo.Actualizar(edi);
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
    }
}
