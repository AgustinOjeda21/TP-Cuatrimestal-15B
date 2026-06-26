using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Busqueda;

namespace Aplicacion.Gestores
{
    public class GestorEstadoPedido : IGestorEstadoPedido
    {
        IRepositorioEstadoPedido repo;

        public GestorEstadoPedido(IRepositorioEstadoPedido repo)
        {
            this.repo = repo;
        }

        public async Task<Result<EstadoPedido>> CargarEstadoPedido(EstadoPedido edi)
        {
            await repo.InsertarEstadoPedido(edi);
            return Result<EstadoPedido>.EjecucionCorrecta();
        }

        public async Task<EstadoPedido> CapturarEstadoPedido(int id)
        {
            var edi = await repo.CapturarEstadoPedido(id);
            return edi;
        }
        public async Task<List<EstadoPedido>> DevolverEstadosPedido()
        {
            return await repo.ObtenerEstadosPedido();
        }

        public async Task<Result<EstadoPedido>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteEstadoPedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<EstadoPedido>.EjecucionCorrecta();
        }

        public async Task<Result<EstadoPedido>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteEstadoPedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<EstadoPedido>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarEstadoPedido(int id)
        {
            return await repo.CapturarEstadoPedido(id) != null;
        }

        public async Task<Result<EstadoPedido>> ExisteEstadoPedido(int id)
        {
            EstadoPedido obj = await repo.CapturarEstadoPedido(id);
            if (obj is null)
            {
                return Result<EstadoPedido>.Fail("El Estado de Pedido ingresado no existe");
            }
            return Result<EstadoPedido>.Ok(obj);
        }
        public async Task<List<EstadoPedido>> Buscar(Busqueda<EstadoPedido> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
