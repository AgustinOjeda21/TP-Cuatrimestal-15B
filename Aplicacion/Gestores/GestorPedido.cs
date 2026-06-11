using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;

namespace Aplicacion.Gestores
{
    public class GestorPedido : IGestorPedido
    {
        IRepositorioPedido repo;
        IGestorCarrito gestorCarrito;
        IGestorEstadoPedido gestorEstadoPedido;
        IGestorPersona gestorPersona;
        IGestorDetallePedido gestorDetallePedido;

        public GestorPedido(IRepositorioPedido repo,IGestorCarrito gestorCarrito,IGestorEstadoPedido gestorEstadoPedido,IGestorPersona gestorPersona,IGestorDetallePedido gestorDetallePedido)
        {
            this.repo = repo;
            this.gestorDetallePedido = gestorDetallePedido;
            this.gestorEstadoPedido = gestorEstadoPedido;
            this.gestorPersona = gestorPersona;
            this.gestorCarrito = gestorCarrito;
        }
        public async Task<Result<Pedido>> CargarPedido(Pedido edi,DetallePedido det)
        {
            var resultadoCarrito = await gestorCarrito.ValidarCarritoPagado(edi.Carrito.IdCarrito);
            if(!resultadoCarrito.Success)
            {
                return Result<Pedido>.Fail(resultadoCarrito.Message);
            }
            var resultadoPersona = await gestorPersona.ExistePersona(edi.Persona.IdPersona);
            if (!resultadoPersona.Success)
            {
                return Result<Pedido>.Fail(resultadoPersona.Message);
            }
            var ListaEstadoPedido = await gestorEstadoPedido.DevolverEstadosPedido();
            var IdEstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Pendiente de entrega");
            if(IdEstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido pagado");
            }
            edi.EstadoPedido = IdEstadoPedido; 
            await repo.InsertarPedido(edi);
            det.Pedido = edi;
            var resultadoDetalle = await gestorDetallePedido.CargarDetallePedido(det);
            if (!resultadoDetalle.Success)
            {
                return Result<Pedido>.Fail(resultadoDetalle.Message);
            }
            return Result<Pedido>.EjecucionCorrecta();
        }

        public async Task<Pedido> CapturarPedido(int id)
        {
            var edi = await repo.CapturarPedido(id);
            return edi;
        }
        public async Task<List<Pedido>> DevolverPedidos()
        {
            return await repo.ObtenerPedidoes();
        }

        public async Task<Result<Pedido>> ModificarCarrito(Carrito carrito, int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            var resultadoCarrito = await gestorCarrito.ValidarCarritoPagado(edi.Carrito.IdCarrito);
            if (!resultadoCarrito.Success)
            {
                return Result<Pedido>.Fail(resultadoCarrito.Message);
            }
            edi.Carrito = carrito;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }
        public async Task<Result<Pedido>> ModificarPersona(Persona persona, int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            var resultadoPersona = await gestorPersona.ExistePersona(edi.Persona.IdPersona);
            if (!resultadoPersona.Success)
            {
                return Result<Pedido>.Fail(resultadoPersona.Message);
            }
            edi.Persona = persona;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }
        public async Task<Result<Pedido>> EntregarPedido(Persona persona, int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if(edi.EstadoPedido.Nombre!="Pendiente de pago")
            {

            }
            edi.Persona = persona;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarPedido(int id)
        {
            return await repo.CapturarPedido(id) != null;
        }

        public async Task<Result<Pedido>> ExistePedido(int id)
        {
            Pedido obj = await repo.CapturarPedido(id);
            if (obj is null)
            {
                return Result<Pedido>.Fail("El Pedido ingresada no existe");
            }
            return Result<Pedido>.Ok(obj);
        }
    }

}

