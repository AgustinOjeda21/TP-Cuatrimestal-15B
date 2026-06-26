using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioFormaPago
    {
        Task<List<FormaPago>> ObtenerFormasPago();

        Task InsertarFormaPago(FormaPago aut);

        Task<List<FormaPago>> Buscar(Busqueda<FormaPago> busqueda);
        Task<FormaPago> CapturarFormaPago(int id);

        Task Actualizar(FormaPago obj);
        
    }
}
