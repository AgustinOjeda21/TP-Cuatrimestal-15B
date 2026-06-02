using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorMarca
    {
        IRepositorioMarca repo;

        public GestorMarca(IRepositorioMarca repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Marca>> CargarMarca(Marca edi)
        {
            await repo.InsertarMarca(edi);
            return Result<Marca>.EjecucionCorrecta();
        }

        public async Task<Marca> CapturarMarca(int id)
        {
            var edi = await repo.CapturarMarca(id);
            return edi;
        }
        public async Task<List<Marca>> DevolverMarcas()
        {
            return await repo.ObtenerMarcas();
        }

        public async Task<Result<Marca>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteMarca(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Marca>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarMarca(int id)
        {
            return await repo.CapturarMarca(id) != null;
        }

        public async Task<Result<Marca>> ExisteMarca(int id)
        {
            Marca obj = await repo.CapturarMarca(id);
            if (obj is null)
            {
                return Result<Marca>.Fail("La Marca ingresada no existe");
            }
            return Result<Marca>.Ok(obj);
        }
    }
}
