using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorUsuario : IGestorUsuario
    {
        IRepositorioUsuario repo;
        IGestorPersona gestorPersona;

        public GestorUsuario(IRepositorioUsuario repo, IGestorPersona gestorPersona)
        {
            this.repo = repo;
            this.gestorPersona = gestorPersona;
        }

        public async Task<Result<Usuario>> CargarUsuario(Usuario edi,Persona persona,Direccion direccion)
        {
            // Hashear Contraseña
            var idusuario = await repo.InsertarUsuario(edi);
            edi.IdUsuario = idusuario;
            persona.Usuario = edi;
            await gestorPersona.CargarPersona(persona, direccion);
            return Result<Usuario>.EjecucionCorrecta();
        }

        public async Task<Usuario> CapturarUsuario(int id)
        {
            var edi = await repo.CapturarUsuario(id);
            return edi;
        }
        public async Task<List<Usuario>> DevolverUsuarios()
        {
            return await repo.ObtenerUsuarios();
        }

        public async Task<Result<Usuario>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteUsuario(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.NombreUsuario = Nombre;
            await repo.Actualizar(edi);
            return Result<Usuario>.EjecucionCorrecta();
        }
        public async Task<Result<Usuario>> ModificarRol(Usuario.Roles rol, int id)
        {
            var resultado = await ExisteUsuario(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Rol = rol;
            await repo.Actualizar(edi);
            return Result<Usuario>.EjecucionCorrecta();
        }
        public async Task<Result<Usuario>> ModificarContraseña(string Contraseña, int id)
        {
            var resultado = await ExisteUsuario(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            // hashear contraseña
            edi.Contraseña = Contraseña;
            await repo.Actualizar(edi);
            return Result<Usuario>.EjecucionCorrecta();
        }

        public async Task<bool> ValidarUsuario(int id)
        {
            return await repo.CapturarUsuario(id) != null;
        }
        public async Task<Result<Usuario>> DarDeBajaAlta(int ID, bool Estado)
        {
            var resultado = await ExisteUsuario(ID);
            if (!resultado.Success)
            {
                return resultado;
            }
            var pro = resultado.Value;
            if (pro.Estado == Estado)
            {
                return Result<Usuario>.Fail("El Usuario ya se encuentra en ese estado");
            }
            pro.Estado = Estado;
            await repo.Actualizar(pro);
            return Result<Usuario>.EjecucionCorrecta();
        }

        public async Task<Result<Usuario>> ExisteUsuario(int id)
        {
            Usuario obj = await repo.CapturarUsuario(id);
            if (obj is null)
            {
                return Result<Usuario>.Fail("El Usuario ingresado no existe");
            }
            return Result<Usuario>.Ok(obj);
        }
    }
}
