using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorPedido
    {
        Task<Result<Pedido>> CargarPedido(Pedido edi, DetallePedido det);
        Task<Pedido> CapturarPedido(int id);
        Task<List<Pedido>> DevolverPedidos();
        Task<Result<Pedido>> ModificarCarrito(Carrito carrito, int id);
        Task<Result<Pedido>> ModificarPersona(Persona persona, int id);
        Task<Result<Pedido>> EntregarPedido(int id);
        Task<Result<Pedido>> CancelarPedido(int id);
        Task<Result<Pedido>> PagarPedido(int id);
        Task<Result<Pedido>> ReestablecerPedido(int id);
        Task<bool> ValidarPedido(int id);
        Task<Result<Pedido>> ExistePedido(int id);
       
    }
}

