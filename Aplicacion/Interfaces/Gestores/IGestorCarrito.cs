using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorCarrito
    {
        Task<Result<Carrito>> CargarCarrito(Carrito edi);
        Task<Carrito> CapturarCarrito(int id);
        Task<List<Carrito>> DevolverCarritos();
        Task<Result<Carrito>> CancelarCarrito(int id);
        Task<Result<Carrito>> ConfirmarCarrito(int id);
        Task<Result<Carrito>> ReactivarCarrito(int id);
        Task<Result<Carrito>> PagarCarrito(int id);
        Task<Result<Carrito>> ExisteCarrito(int id);
        Task<bool> ValidarCarrito(int id);
        Task<Result<Carrito>> ValidarCarritoConfirmado(int id);
        Task<Result<Carrito>> ValidarCarritoActivo(int id);


    }
}
