using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorEstadoCarrito
    {
        Task<Result<EstadoCarrito>> CargarEstadoCarrito(EstadoCarrito edi);
        Task<EstadoCarrito> CapturarEstadoCarrito(int id);
        Task<List<EstadoCarrito>> DevolverEstadosCarrito();
        Task<Result<EstadoCarrito>> ModificarNombre(string Nombre, int id);
        Task<bool> ValidarEstadoCarrito(int id);
        Task<Result<EstadoCarrito>> ExisteEstadoCarrito(int id);
        
    }
}

