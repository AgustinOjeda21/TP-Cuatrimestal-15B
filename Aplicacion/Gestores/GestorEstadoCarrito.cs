using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Busqueda;

namespace Aplicacion.Gestores
{
    public class GestorEstadoCarrito : IGestorEstadoCarrito
    {
        IRepositorioEstadoCarrito repo;

        public GestorEstadoCarrito(IRepositorioEstadoCarrito repo)
        {
            this.repo = repo;
        }

        public async Task<Result<EstadoCarrito>> CargarEstadoCarrito(EstadoCarrito edi)
        {
            await repo.InsertarEstadoCarrito(edi);
            return Result<EstadoCarrito>.EjecucionCorrecta();
        }

        public async Task<EstadoCarrito> CapturarEstadoCarrito(int id)
        {
            var edi = await repo.CapturarEstadoCarrito(id);
            return edi;
        }
        public async Task<List<EstadoCarrito>> DevolverEstadosCarrito()
        {
            return await repo.ObtenerEstadosCarrito();
        }

        public async Task<Result<EstadoCarrito>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteEstadoCarrito(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<EstadoCarrito>.EjecucionCorrecta();
        }

        public async Task<bool> ValidarEstadoCarrito(int id)
        {
            return await repo.CapturarEstadoCarrito(id) != null;
        }

        public async Task<Result<EstadoCarrito>> ExisteEstadoCarrito(int id)
        {
            EstadoCarrito obj = await repo.CapturarEstadoCarrito(id);
            if (obj is null)
            {
                return Result<EstadoCarrito>.Fail("El Estado de Carrito ingresado no existe");
            }
            return Result<EstadoCarrito>.Ok(obj);
        }
        public async Task<List<EstadoCarrito>> Buscar(Busqueda<EstadoCarrito> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
