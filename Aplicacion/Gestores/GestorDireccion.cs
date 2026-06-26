using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion.Interfaces.Gestores;
using Dominio.Entidades;
using Aplicacion.Busqueda;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorDireccion : IGestorDireccion
    {
        IRepositorioDireccion repo;

        public GestorDireccion(IRepositorioDireccion repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Direccion>> CargarDireccion(Direccion edi)
        {
            await repo.InsertarDireccion(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }

        public async Task<Direccion> CapturarDireccion(int id)
        {
            var edi = await repo.CapturarDireccion(id);
            return edi;
        }
        public async Task<List<Direccion>> DevolverDirecciones()
        {
            return await repo.ObtenerDirecciones();
        }

        public async Task<Result<Direccion>> ModificarCalle(string Calle, int id)
        {
            var resultado = await ExisteDireccion(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Calle = Calle;
            await repo.Actualizar(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }

        public async Task<Result<Direccion>> ModificarCodigoPostal(string CodigoPostal, int id)
        {
            var resultado = await ExisteDireccion(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.CodigoPostal = CodigoPostal;
            await repo.Actualizar(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }
        public async Task<Result<Direccion>> ModificarNumero(string Numero, int id)
        {
            var resultado = await ExisteDireccion(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Numero = Numero;
            await repo.Actualizar(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }
        public async Task<Result<Direccion>> ModificarLocalidad(string Localidad, int id)
        {
            var resultado = await ExisteDireccion(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Localidad = Localidad;
            await repo.Actualizar(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }
        public async Task<Result<Direccion>> ModificarObservaciones(string Observaciones, int id)
        {
            var resultado = await ExisteDireccion(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Observaciones= Observaciones;
            await repo.Actualizar(edi);
            return Result<Direccion>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarDireccion(int id)
        {
            return await repo.CapturarDireccion(id) != null;
        }

        public async Task<Result<Direccion>> ExisteDireccion(int id)
        {
            Direccion obj = await repo.CapturarDireccion(id);
            if (obj is null)
            {
                return Result<Direccion>.Fail("La Direccion ingresada no existe");
            }
            return Result<Direccion>.Ok(obj);
        }
        public async Task<List<Direccion>> Buscar(Busqueda<Direccion> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
