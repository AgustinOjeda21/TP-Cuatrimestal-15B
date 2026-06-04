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
    class GestorCarrito
    {
        IRepositorioCarrito repo;
        IGestorEstadoCarrito gestorEstadoCarrito;

        public GestorCarrito(IRepositorioCarrito repo, IGestorEstadoCarrito gestorEstadoCarrito)
        {
            this.repo = repo;
            this.gestorEstadoCarrito = gestorEstadoCarrito;
        }

        public async Task<Result<Carrito>> CargarCarrito(Carrito edi)
        {
            var ListaEstadoCarrito = await gestorEstadoCarrito.DevolverEstadosCarrito();
            var IdEstadoCarrito = ListaEstadoCarrito.FirstOrDefault(obj => obj.Nombre == "Activo");
            edi.EstadoCarrito = IdEstadoCarrito;
            edi.Total = 0;
            await repo.InsertarCarrito(edi);
            return Result<Carrito>.EjecucionCorrecta();
        }

        public async Task<Carrito> CapturarCarrito(int id)
        {
            var edi = await repo.CapturarCarrito(id);
            return edi;
        }
        public async Task<List<Carrito>> DevolverCarritos()
        {
            return await repo.ObtenerCarritos();
        }

        public async Task<Result<Carrito>> CancelarCarrito(int id)
        {
            var resultado = await ExisteCarrito(id);
            if(!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if(edi.EstadoCarrito.Nombre=="Pagado")
            {
                return Result<Carrito>.Fail("El carrito ya fue pagado, por lo tanto no se puede cancelar");
            }
            if (edi.EstadoCarrito.Nombre == "Cancelado")
            {
                return Result<Carrito>.Fail("El carrito ya estaba cancelado");
            }
            var ListaEstadoCarrito = await gestorEstadoCarrito.DevolverEstadosCarrito();
            var IdEstadoCarrito = ListaEstadoCarrito.FirstOrDefault(obj => obj.Nombre == "Cancelado");
            edi.EstadoCarrito = IdEstadoCarrito;
            await repo.Actualizar(edi);
            return Result<Carrito>.EjecucionCorrecta();
        }
        public async Task<Result<Carrito>> ConfirmarCarrito(int id)
        {
            var resultado = await ExisteCarrito(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoCarrito.Nombre == "Pagado")
            {
                return Result<Carrito>.Fail("El carrito ya fue pagado");
            }
            if (edi.EstadoCarrito.Nombre == "Cancelado")
            {
                return Result<Carrito>.Fail("El carrito esta cancelado, active el carrito para poder confirmarlo");
            }
            if (edi.EstadoCarrito.Nombre == "Confirmado")
            {
                return Result<Carrito>.Fail("El carrito ya estaba confirmado");
            }
            var ListaEstadoCarrito = await gestorEstadoCarrito.DevolverEstadosCarrito();
            var IdEstadoCarrito = ListaEstadoCarrito.FirstOrDefault(obj => obj.Nombre == "Confirmado");
            edi.EstadoCarrito = IdEstadoCarrito;
            await repo.Actualizar(edi);
            return Result<Carrito>.EjecucionCorrecta();
        }
        public async Task<Result<Carrito>> ReactivarCarrito(int id)
        {
            var resultado = await ExisteCarrito(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoCarrito.Nombre == "Pagado")
            {
                return Result<Carrito>.Fail("El carrito ya fue pagado");
            }
            if (edi.EstadoCarrito.Nombre == "Activo")
            {
                return Result<Carrito>.Fail("El carrito ya estaba activo");
            }
            var ListaEstadoCarrito = await gestorEstadoCarrito.DevolverEstadosCarrito();
            var IdEstadoCarrito = ListaEstadoCarrito.FirstOrDefault(obj => obj.Nombre == "Activo");
            edi.EstadoCarrito = IdEstadoCarrito;
            await repo.Actualizar(edi);
            return Result<Carrito>.EjecucionCorrecta();
        }
        public async Task<Result<Carrito>> PagarCarrito(int id)
        {
            var resultado = await ExisteCarrito(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            if (edi.EstadoCarrito.Nombre == "Pagado")
            {
                return Result<Carrito>.Fail("El carrito ya fue pagado");
            }
            if (edi.EstadoCarrito.Nombre == "Activo")
            {
                return Result<Carrito>.Fail("Necisita confirmar el carrito para poder pagarlo");
            }
            if (edi.EstadoCarrito.Nombre == "Cancelado")
            {
                return Result<Carrito>.Fail("El carrito esta cancelado, active el carrito para poder confirmarlo");
            }
            var ListaEstadoCarrito = await gestorEstadoCarrito.DevolverEstadosCarrito();
            var IdEstadoCarrito = ListaEstadoCarrito.FirstOrDefault(obj => obj.Nombre == "Pagado");
            edi.EstadoCarrito = IdEstadoCarrito;
            await repo.Actualizar(edi);
            return Result<Carrito>.EjecucionCorrecta();
        }

        /*public async Task<Result<Carrito>> ActualizarTotal(int id)
        {
            var resultado = await ExisteCarrito(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            
        }*/
        public async Task<Result<Carrito>> ExisteCarrito(int id)
        {
            Carrito obj = await repo.CapturarCarrito(id);
            if (obj is null)
            {
                return Result<Carrito>.Fail("El Carrito ingresado no existe");
            }
            return Result<Carrito>.Ok(obj);
        }
        public async Task<bool> ValidarCarrito(int id)
        {
            return await repo.CapturarCarrito(id) != null;
        }
        public async Task<Result<Carrito>> ValidarCarritoActivo(int id)
        {
            Carrito obj = await repo.CapturarCarrito(id);
            if (obj is null)
            {
                return Result<Carrito>.Fail("El Carrito ingresado no existe");
            }
            if(obj.EstadoCarrito.Nombre!="Activo")
            {
                return Result<Carrito>.Fail("El Carrito no se encuentra activo");
            }
            return Result<Carrito>.Ok(obj);
        }
        public async Task<Result<Carrito>> ValidarCarritoPagado(int id)
        {
            Carrito obj = await repo.CapturarCarrito(id);
            if (obj is null)
            {
                return Result<Carrito>.Fail("El Carrito ingresado no existe");
            }
            if (obj.EstadoCarrito.Nombre != "Pagado")
            {
                return Result<Carrito>.Fail("El Carrito no se encuentra pagado");
            }
            return Result<Carrito>.Ok(obj);
        }

    }
}
