using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;
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
            var resultadoCarrito = await gestorCarrito.ValidarCarritoConfirmado(edi.Carrito.IdCarrito);
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
            var IdEstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Confirmado");
            if(IdEstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido Confirmado");
            }
            edi.EstadoPedido = IdEstadoPedido; 
            edi.IdPedido = await repo.InsertarPedido(edi);
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
            var resultadoCarrito = await gestorCarrito.ValidarCarritoConfirmado(edi.Carrito.IdCarrito);
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
        public async Task<Result<Pedido>> EntregarPedido(int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if(edi.EstadoPedido.Nombre!="Pagado")
            {
                return Result<Pedido>.Fail("El pedido no ha sido pagado");
            }
            var ListaEstadoPedido = await gestorEstadoPedido.DevolverEstadosPedido();
            var EstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Pagado");
            if (EstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido Pagado");
            }
            edi.EstadoPedido = EstadoPedido;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }

        public async Task<Result<Pedido>> CancelarPedido(int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoPedido.Nombre != "Confirmado")
            {
                return Result<Pedido>.Fail("El pedido ya ha sido pagado o entregado");
            }
            var ListaEstadoPedido = await gestorEstadoPedido.DevolverEstadosPedido();
            var EstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Cancelado");
            if (EstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido Cancelado");
            }
            edi.EstadoPedido = EstadoPedido;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }
        public async Task<Result<Pedido>> PagarPedido(int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoPedido.Nombre != "Confirmado")
            {
                return Result<Pedido>.Fail("El pedido no ha sido confirmado");
            }
            var ListaEstadoPedido = await gestorEstadoPedido.DevolverEstadosPedido();
            var EstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Pagado");
            if (EstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido Pagado");
            }
            edi.EstadoPedido = EstadoPedido;
            await repo.Actualizar(edi);
            return Result<Pedido>.EjecucionCorrecta();
        }
        public async Task<Result<Pedido>> ReestablecerPedido(int id)
        {
            var resultado = await ExistePedido(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoPedido.Nombre != "Cancelado")
            {
                return Result<Pedido>.Fail("El pedido no ha sido cancelado");
            }
            var ListaEstadoPedido = await gestorEstadoPedido.DevolverEstadosPedido();
            var EstadoPedido = ListaEstadoPedido.FirstOrDefault(obj => obj.Nombre == "Confirmado");
            if (EstadoPedido is null)
            {
                return Result<Pedido>.Fail("Fatal error: no existe el estado de pedido Confirmado");
            }
            edi.EstadoPedido = EstadoPedido;
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
        public async Task<List<Pedido>> Buscar(Busqueda<Pedido> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }

}

