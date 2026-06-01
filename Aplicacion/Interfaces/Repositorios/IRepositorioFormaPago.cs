using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioFormaPago
    {
        Task<List<FormaPago>> ObtenerFormaPagoes();

        Task InsertarFormaPago(FormaPago aut);


        Task<FormaPago> CapturarFormaPago(int id);

        Task Actualizar(FormaPago obj);
        
    }
}
