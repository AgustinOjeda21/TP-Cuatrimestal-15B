using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorFormaPago
    {
        IRepositorioFormaPago repo;

        public GestorFormaPago(IRepositorioFormaPago repo)
        {
            this.repo = repo;
        }

        public async Task<Result<FormaPago>> CargarFormaPago(FormaPago edi)
        {
            await repo.InsertarFormaPago(edi);
            return Result<FormaPago>.EjecucionCorrecta();
        }

        public async Task<FormaPago> CapturarFormaPago(int id)
        {
            var edi = await repo.CapturarFormaPago(id);
            return edi;
        }
        public async Task<List<FormaPago>> DevolverFormasPago()
        {
            return await repo.ObtenerFormasPago();
        }

        public async Task<Result<FormaPago>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteFormaPago(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<FormaPago>.EjecucionCorrecta();
        }

        public async Task<Result<FormaPago>> ModificarDescripcion(string Descripcion, int id)
        {
            var resultado = await ExisteFormaPago(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Descripcion = Descripcion;
            await repo.Actualizar(edi);
            return Result<FormaPago>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarFormaPago(int id)
        {
            return await repo.CapturarFormaPago(id) != null;
        }

        public async Task<Result<FormaPago>> ExisteFormaPago(int id)
        {
            FormaPago obj = await repo.CapturarFormaPago(id);
            if (obj is null)
            {
                return Result<FormaPago>.Fail("La Forma de Pago ingresada no existe");
            }
            return Result<FormaPago>.Ok(obj);
        }
    }
}
