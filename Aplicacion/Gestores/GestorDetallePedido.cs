using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;

namespace Aplicacion.Gestores
{
    class GestorDetallePedido
    {
        IRepositorioDetallePedido repo;
        IGestorPedido gestorPedido;
        IGestorFormaPago gestorFormaPago;
        IGestorFormaEntrega gestorFormaEntrega;
        IGestorDireccion gestorDireccion;

        public GestorDetallePedido(IRepositorioDetallePedido repo)
        {
            this.repo = repo;
        }

        public async Task<Result<DetallePedido>> CargarDetallePedido(DetallePedido edi)
        {
            var resultadoDireccion = await gestorDireccion.ExisteDireccion(edi.Direccion.IdDireccion);
            if(!resultadoDireccion.Success)
            {
                return Result<DetallePedido>.Fail(resultadoDireccion.Message);
            }
            var resultadoPago = await gestorFormaPago.ExisteFormaPago(edi.FormaPago.IdFormaPago);
            if (!resultadoPago.Success)
            {
                return Result<DetallePedido>.Fail(resultadoPago.Message);
            }
            var resultadoEntrega = await gestorFormaEntrega.ExisteFormaEntrega(edi.FormaEntrega.IdFormaEntrega);
            if (!resultadoEntrega.Success)
            {
                return Result<DetallePedido>.Fail(resultadoEntrega.Message);
            }
            await repo.InsertarDetallePedido(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }

        public async Task<DetallePedido> CapturarDetallePedido(int id)
        {
            var edi = await repo.CapturarDetallePedido(id);
            return edi;
        }
        public async Task<List<DetallePedido>> DevolverDetallePedidos()
        {
            return await repo.ObtenerDetallePedidoes();
        }

        public async Task<Result<DetallePedido>> ModificarFechaPedido(DateTime fecha, int id)
        {
            var resultado = await ExisteDetallePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if(fecha>edi.FechaEntrega)
            {
                return Result<DetallePedido>.Fail("La fecha no puede ser mayor a la fecha de entrega");
            }
            edi.FechaPedido = fecha;
            await repo.Actualizar(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }

        public async Task<Result<DetallePedido>> ModificarFechaEntrega(DateTime fecha, int id)
        {
            var resultado = await ExisteDetallePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (fecha < edi.FechaPedido)
            {
                return Result<DetallePedido>.Fail("La fecha no puede ser menoor a la fecha de pedido");
            }
            edi.FechaEntrega = fecha;
            await repo.Actualizar(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }
        public async Task<Result<DetallePedido>> ModificarDireccion(Direccion direccion, int id)
        {
            var resultado = await ExisteDetallePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            var resultadoDireccion = await gestorDireccion.ExisteDireccion(edi.Direccion.IdDireccion);
            if (!resultadoDireccion.Success)
            {
                return Result<DetallePedido>.Fail(resultadoDireccion.Message);
            }
            edi.Direccion = direccion;
            await repo.Actualizar(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }
        public async Task<Result<DetallePedido>> ModificarFormaPago(FormaPago formaPago, int id)
        {
            var resultado = await ExisteDetallePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            var resultadoPago = await gestorFormaPago.ExisteFormaPago(edi.FormaPago.IdFormaPago);
            if (!resultadoPago.Success)
            {
                return Result<DetallePedido>.Fail(resultadoPago.Message);
            }
            edi.FormaPago = formaPago;
            await repo.Actualizar(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }
        public async Task<Result<DetallePedido>> ModificarFormaEntrega(FormaEntrega formaEntrega, int id)
        {
            var resultado = await ExisteDetallePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            var resultadoEntrega = await gestorFormaEntrega.ExisteFormaEntrega(edi.FormaEntrega.IdFormaEntrega);
            if (!resultadoEntrega.Success)
            {
                return Result<DetallePedido>.Fail(resultadoEntrega.Message);
            }
            edi.FormaEntrega = formaEntrega;
            await repo.Actualizar(edi);
            return Result<DetallePedido>.EjecucionCorrecta();
        }

        public async Task<bool> ValidarDetallePedido(int id)
        {
            return await repo.CapturarDetallePedido(id) != null;
        }

        public async Task<Result<DetallePedido>> ExisteDetallePedido(int id)
        {
            DetallePedido obj = await repo.CapturarDetallePedido(id);
            if (obj is null)
            {
                return Result<DetallePedido>.Fail("El Pedido ingresado no existe");
            }
            return Result<DetallePedido>.Ok(obj);
        }
    }
}
