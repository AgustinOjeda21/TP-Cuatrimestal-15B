using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorUsuario
    {
        Task<Result<Usuario>> CargarUsuario(Usuario edi, Persona persona, List<Direccion> direcciones);

        Task<Usuario> CapturarUsuario(int id);


        Task<List<Usuario>> DevolverUsuarios();



        Task<Result<Usuario>> ModificarNombre(string Nombre, int id);


        Task<Result<Usuario>> ModificarContraseña(string Contraseña, int id);



        Task<bool> ValidarUsuario(int id);


        Task<Result<Usuario>> DarDeBajaAlta(int ID, bool Estado);



        Task<Result<Usuario>> ExisteUsuario(int id);
       
    }
}

