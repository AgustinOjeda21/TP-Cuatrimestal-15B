using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorFormaPago
    {
        Task<Result<FormaPago>> CargarFormaPago(FormaPago edi);


        Task<FormaPago> CapturarFormaPago(int id);

        Task<List<FormaPago>> DevolverFormasPago();


        Task<Result<FormaPago>> ModificarNombre(string Nombre, int id);


        Task<Result<FormaPago>> ModificarDescripcion(string Descripcion, int id);

        Task<bool> ValidarFormaPago(int id);


       Task<Result<FormaPago>> ExisteFormaPago(int id);
        
    }
}

