using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;
using Aplicacion.Interfaces.Gestores;

namespace Aplicacion.Gestores
{
    public class GestorImagen : IGestorImagen
    {
        IRepositorioImagen repo;

        public GestorImagen(IRepositorioImagen repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Imagen>> CargarImagen(Imagen edi)
        {
            await repo.InsertarImagen(edi);
            return Result<Imagen>.EjecucionCorrecta();
        }

        public async Task<Imagen> CapturarImagen(int id)
        {
            var edi = await repo.CapturarImagen(id);
            return edi;
        }
        public async Task<List<Imagen>> DevolverImagenes()
        {
            return await repo.ObtenerImagenes();
        }

        public async Task<Result<Imagen>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteImagen(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Imagen>.EjecucionCorrecta();
        }

        public async Task<Result<Imagen>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteImagen(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<Imagen>.EjecucionCorrecta();
        }
        public async Task<Result<Imagen>> ModificarURL(string URL, int id)
        {
            var resultado = await ExisteImagen(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.URL = URL;
            await repo.Actualizar(edi);
            return Result<Imagen>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarImagen(int id)
        {
            return await repo.CapturarImagen(id) != null;
        }

        public async Task<Result<Imagen>> ExisteImagen(int id)
        {
            Imagen obj = await repo.CapturarImagen(id);
            if (obj is null)
            {
                return Result<Imagen>.Fail("La Imagen ingresada no existe");
            }
            return Result<Imagen>.Ok(obj);
        }
        public async Task<List<Imagen>> Buscar(Busqueda<Imagen> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
