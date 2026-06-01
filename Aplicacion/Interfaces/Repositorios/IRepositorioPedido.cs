using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioPedido
    {
        Task<List<Pedido>> ObtenerPedidoes();


        Task InsertarPedido(Pedido aut);



        Task<Pedido> CapturarPedido(int id);


        Task Actualizar(Pedido obj);


     }
}
