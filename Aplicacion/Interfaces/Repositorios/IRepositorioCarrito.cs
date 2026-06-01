using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioCarrito
    {
        Task<List<Carrito>> ObtenerCarritoes();
        Task InsertarCarrito(Carrito aut);
        Task<Carrito> CapturarCarrito(int id);
        Task Actualizar(Carrito obj);
        
    }
}
