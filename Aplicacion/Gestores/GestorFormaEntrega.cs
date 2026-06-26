using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Busqueda;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Interfaces.Gestores;

namespace Aplicacion.Gestores
{
    public class GestorFormaEntrega : IGestorFormaEntrega
    {
        IRepositorioFormaEntrega repo;

        public GestorFormaEntrega(IRepositorioFormaEntrega repo)
        {
            this.repo = repo;
        }

        public async Task<Result<FormaEntrega>> CargarFormaEntrega(FormaEntrega edi)
        {
            await repo.InsertarFormaEntrega(edi);
            return Result<FormaEntrega>.EjecucionCorrecta();
        }

        public async Task<FormaEntrega> CapturarFormaEntrega(int id)
        {
            var edi = await repo.CapturarFormaEntrega(id);
            return edi;
        }
        public async Task<List<FormaEntrega>> DevolverFormasEntrega()
        {
            return await repo.ObtenerFormasEntrega();
        }

        public async Task<Result<FormaEntrega>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteFormaEntrega(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<FormaEntrega>.EjecucionCorrecta();
        }

        public async Task<Result<FormaEntrega>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteFormaEntrega(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<FormaEntrega>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarFormaEntrega(int id)
        {
            return await repo.CapturarFormaEntrega(id) != null;
        }

        public async Task<Result<FormaEntrega>> ExisteFormaEntrega(int id)
        {
            FormaEntrega obj = await repo.CapturarFormaEntrega(id);
            if (obj is null)
            {
                return Result<FormaEntrega>.Fail("La Forma de Entrega ingresada no existe");
            }
            return Result<FormaEntrega>.Ok(obj);
        }
        public async Task<List<FormaEntrega>> Buscar(Busqueda<FormaEntrega> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
