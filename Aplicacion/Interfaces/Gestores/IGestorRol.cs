using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    interface IGestorRol
    {
        Task<Result<Rol>> CargarRol(Rol edi);



        Task<Rol> CapturarRol(int id);


        Task<List<Rol>> DevolverRoles();



        Task<Result<Rol>> ModificarNombre(string Nombre, int id);



        Task<bool> ValidarRol(int id);



        Task<Result<Rol>> ExisteRol(int id);
       
    }
}
