using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorPersona
    {
        IRepositorioPersona repo;

        public GestorPersona(IRepositorioPersona repo)
        {
            this.repo = repo;
        }

        public async Task<Result<Persona>> CargarPersona(Persona edi)
        {
            await repo.InsertarPersona(edi);
            return Result<Persona>.EjecucionCorrecta();
        }

        public async Task<Persona> CapturarPersona(int id)
        {
            var edi = await repo.CapturarPersona(id);
            return edi;
        }
        public async Task<List<Persona>> DevolverPersonas()
        {
            return await repo.ObtenerPersonas();
        }

        public async Task<Result<Persona>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExistePersona(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Persona>.EjecucionCorrecta();
        }

        public async Task<Result<Persona>> ModificarApellido(string Apellido, int id)
        {
            var resultado = await ExistePersona(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Apellido = Apellido;
            await repo.Actualizar(edi);
            return Result<Persona>.EjecucionCorrecta();
        }
        public async Task<Result<Persona>> ModificarMail(string Mail, int id)
        {
            var resultado = await ExistePersona(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Mail = Mail;
            await repo.Actualizar(edi);
            return Result<Persona>.EjecucionCorrecta();
        }
        public async Task<Result<Persona>> ModificarTelefono(string Telefono, int id)
        {
            var resultado = await ExistePersona(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Telefono = Telefono;
            await repo.Actualizar(edi);
            return Result<Persona>.EjecucionCorrecta();
        }
        public async Task<bool> ValidarPersona(int id)
        {
            return await repo.CapturarPersona(id) != null;
        }

        public async Task<Result<Persona>> ExistePersona(int id)
        {
            Persona obj = await repo.CapturarPersona(id);
            if (obj is null)
            {
                return Result<Persona>.Fail("La Persona ingresada no existe");
            }
            return Result<Persona>.Ok(obj);
        }
    }
}
