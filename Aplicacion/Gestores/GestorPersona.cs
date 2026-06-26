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
    public class GestorPersona : IGestorPersona
    {
        IRepositorioPersona repo;
        IGestorDireccion GestorDireccion;

        public GestorPersona(IRepositorioPersona repo, IGestorDireccion GestorDireccion)
        {
            this.repo = repo;
            this.GestorDireccion = GestorDireccion;
        }

        public async Task<Result<Persona>> CargarPersona(Persona edi, List<Direccion> direcciones)
        {
            edi.Direcciones = direcciones;
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

        public async Task AgregarDireccion(int idPersona, Direccion direccion)
        {
            await repo.AgregarDireccion(idPersona, direccion);
        }
        public async Task QuitarDireccion(int idPersona, int idDireccion)
        {
            await repo.QuitarDireccion(idPersona, idDireccion);
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
        public async Task<List<Persona>> Buscar(Busqueda<Persona> busqueda)
        {
            return await repo.Buscar(busqueda);
        }
    }
}
