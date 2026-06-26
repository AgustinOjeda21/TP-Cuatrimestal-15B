using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorFormaEntrega
    {
        Task<Result<FormaEntrega>> CargarFormaEntrega(FormaEntrega edi);


        Task<FormaEntrega> CapturarFormaEntrega(int id);

        Task<List<FormaEntrega>> DevolverFormasEntrega();


        Task<Result<FormaEntrega>> ModificarNombre(string Nombre, int id);


        Task<Result<FormaEntrega>> ModificarDescripcion(string Descripcion, int id);

        Task<bool> ValidarFormaEntrega(int id);


       Task<Result<FormaEntrega>> ExisteFormaEntrega(int id);
        
    }
}

