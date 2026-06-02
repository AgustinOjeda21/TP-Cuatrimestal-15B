using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorMarca
    {
        Task<Result<Marca>> CargarMarca(Marca edi);


        Task<Marca> CapturarMarca(int id);

        Task<List<Marca>> DevolverMarcas();


        Task<Result<Marca>> ModificarNombre(string Nombre, int id);

        Task<bool> ValidarMarca(int id);


        Task<Result<Marca>> ExisteMarca(int id);
       
    }
}

