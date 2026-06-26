using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioCarrito
    {
        Task<List<Carrito>> ObtenerCarritos();
        Task InsertarCarrito(Carrito aut);
        Task<Carrito> CapturarCarrito(int id);
        Task Actualizar(Carrito obj);
        Task<List<Carrito>> Buscar(Busqueda<Carrito> busqueda);


    }
}
