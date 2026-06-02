using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorRol : Aplicacion.Interfaces.Gestores.IGestorRol
    {
        IRepositorioRol repo;

        public GestorRol(IRepositorioRol repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Rol>> CargarRol(Rol edi)
        {
            await repo.InsertarRol(edi);
            return Result<Rol>.EjecucionCorrecta();
        }

        public async Task<Rol> CapturarRol(int id)
        {
            var edi = await repo.CapturarRol(id);
            return edi;
        }
        public async Task<List<Rol>> DevolverRoles()
        {
            return await repo.ObtenerRoles();
        }

        public async Task<Result<Rol>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteRol(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Rol>.EjecucionCorrecta();
        }

        public async Task<bool> ValidarRol(int id)
        {
            return await repo.CapturarRol(id) != null;
        }

        public async Task<Result<Rol>> ExisteRol(int id)
        {
            Rol obj = await repo.CapturarRol(id);
            if (obj is null)
            {
                return Result<Rol>.Fail("El Rol ingresado no existe");
            }
            return Result<Rol>.Ok(obj);
        }
    }
}
