using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorPermiso
    {
        Task<Result<Permiso>> CargarPermiso(Permiso edi);



        Task<Permiso> CapturarPermiso(int id);


        Task<List<Permiso>> DevolverPermisoes();



        Task<Result<Permiso>> ModificarNombre(string Nombre, int id);


        Task<bool> ValidarPermiso(int id);



        Task<Result<Permiso>> ExistePermiso(int id);
        
    }
}

