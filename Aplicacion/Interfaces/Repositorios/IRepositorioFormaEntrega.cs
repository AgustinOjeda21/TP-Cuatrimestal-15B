using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioFormaEntrega
    {
        Task<List<FormaEntrega>> ObtenerFormaEntregaes();

        Task InsertarFormaEntrega(FormaEntrega aut);


        Task<FormaEntrega> CapturarFormaEntrega(int id);

        Task Actualizar(FormaEntrega obj);
        
    }
}
