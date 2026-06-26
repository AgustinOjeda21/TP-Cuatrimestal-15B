using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Busqueda;

namespace Aplicacion.Gestores
{
    public class GestorCategoria : IGestorCategoria
    {
        IRepositorioCategoria repo;

        public GestorCategoria(IRepositorioCategoria repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Categoria>> CargarCategoria(Categoria edi)
        {
            await repo.InsertarCategoria(edi);
            return Result<Categoria>.EjecucionCorrecta();
        }

        public async Task<Categoria> CapturarCategoria(int id)
        {
            var edi = await repo.CapturarCategoria(id);
            return edi;
        }
        public async Task<List<Categoria>> DevolverCategorias()
        {
            return await repo.ObtenerCategorias();
        }

        public async Task<Result<Categoria>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteCategoria(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Categoria>.EjecucionCorrecta();
        }

        public async Task<Result<Categoria>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteCategoria(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<Categoria>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarCategoria(int id)
        {
            return await repo.CapturarCategoria(id) != null;
        }

        public async Task<Result<Categoria>> ExisteCategoria(int id)
        {
            Categoria obj = await repo.CapturarCategoria(id);
            if (obj is null)
            {
                return Result<Categoria>.Fail("La Categoria ingresada no existe");
            }
            return Result<Categoria>.Ok(obj);
        }
        public async Task EliminarCategoria(int id)
        {
            await repo.Eliminar(id);
        }
        public async Task<List<Categoria>> Buscar(Busqueda<Categoria> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
        
}
