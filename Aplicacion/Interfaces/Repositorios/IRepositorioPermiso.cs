using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioPermiso
    {
        Task<List<Permiso>> ObtenerPermisoes();

        Task InsertarPermiso(Permiso aut);


        Task<Permiso> CapturarPermiso(int id);

        Task Actualizar(Permiso obj);
      
    }
}
