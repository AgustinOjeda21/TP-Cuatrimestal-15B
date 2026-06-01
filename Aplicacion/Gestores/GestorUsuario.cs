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
    class GestorUsuario
    {
        IRepositorioUsuario repo;
        IGestorRol gestorRol;
        IGestorPersona gestorPersona;

        public GestorUsuario(IRepositorioUsuario repo, IGestorRol gestorRol, IGestorPersona gestorPersona)
        {
            this.repo = repo;
            this.gestorRol = gestorRol;
            this.gestorPersona = gestorPersona;
        }

        public async Task<Result<Usuario>> CargarUsuario(Usuario edi,Persona persona)// Lo ideal seria crear un DTO donde vengan los datos que le correspondad al usuario y a la persona asociada a el que se valla a crear
        {
            var resultado = await gestorRol.ExisteRol(edi.Rol.IdRol);
            if (!resultado.Success)
            {
                return Result<Usuario>.Fail("El Rol ingresado no existe");
            }
            // Hashear Contraseña
            await gestorPersona.CargarPersona(persona);
            await repo.InsertarUsuario(edi);
            return Result<Usuario>.EjecucionCorrecta();
        }

        public async Task<Usuario> CapturarUsuario(int id)
        {
            var edi = await repo.CapturarUsuario(id);
            return edi;
        }
        public async Task<List<Usuario>> DevolverUsuarioes()
        {
            return await repo.ObtenerUsuarioes();
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
                return Result<Usuario>.Fail("La Usuario ingresada no existe");
            }
            return Result<Usuario>.Ok(obj);
        }
    }
}
