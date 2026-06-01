using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    class GestorPermiso
    {
        IRepositorioPermiso repo;

        public GestorPermiso(IRepositorioPermiso repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Permiso>> CargarPermiso(Permiso edi)
        {
            await repo.InsertarPermiso(edi);
            return Result<Permiso>.EjecucionCorrecta();
        }

        public async Task<Permiso> CapturarPermiso(int id)
        {
            var edi = await repo.CapturarPermiso(id);
            return edi;
        }
        public async Task<List<Permiso>> DevolverPermisoes()
        {
            return await repo.ObtenerPermisoes();
        }

        public async Task<Result<Permiso>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExistePermiso(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Permiso>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarPermiso(int id)
        {
            return await repo.CapturarPermiso(id) != null;
        }

        public async Task<Result<Permiso>> ExistePermiso(int id)
        {
            Permiso obj = await repo.CapturarPermiso(id);
            if (obj is null)
            {
                return Result<Permiso>.Fail("La Permiso ingresada no existe");
            }
            return Result<Permiso>.Ok(obj);
        }
    }
}
