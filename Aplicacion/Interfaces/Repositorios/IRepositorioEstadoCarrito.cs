using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioEstadoCarrito
    {
        Task<List<EstadoCarrito>> ObtenerEstadoCarritoes();

        Task InsertarEstadoCarrito(EstadoCarrito aut);


        Task<EstadoCarrito> CapturarEstadoCarrito(int id);

        Task Actualizar(EstadoCarrito obj);
        
         
    }
}
