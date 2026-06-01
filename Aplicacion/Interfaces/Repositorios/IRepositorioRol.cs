using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioRol
    {
        Task<List<Rol>> ObtenerRoles();

        Task InsertarRol(Rol aut);


        Task<Rol> CapturarRol(int id);

        Task Actualizar(Rol obj);
        
    }
}
