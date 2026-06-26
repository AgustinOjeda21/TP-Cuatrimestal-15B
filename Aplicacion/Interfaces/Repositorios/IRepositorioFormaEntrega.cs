using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioFormaEntrega
    {
        Task<List<FormaEntrega>> ObtenerFormasEntrega();

        Task InsertarFormaEntrega(FormaEntrega aut);

        Task<List<FormaEntrega>> Buscar(Busqueda<FormaEntrega> busqueda);
        Task<FormaEntrega> CapturarFormaEntrega(int id);

        Task Actualizar(FormaEntrega obj);
        
    }
}
