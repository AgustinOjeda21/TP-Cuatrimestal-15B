using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorEstadoPedido
    {

        Task<Result<EstadoPedido>> CargarEstadoPedido(EstadoPedido edi);


        Task<EstadoPedido> CapturarEstadoPedido(int id);

        Task<List<EstadoPedido>> DevolverEstadosPedido();


        Task<Result<EstadoPedido>> ModificarNombre(string Nombre, int id);


        Task<Result<EstadoPedido>> ModificarDescripcion(string Descripcion, int id);

        Task<bool> ValidarEstadoPedido(int id);


        Task<Result<EstadoPedido>> ExisteEstadoPedido(int id);
        
    }
}

