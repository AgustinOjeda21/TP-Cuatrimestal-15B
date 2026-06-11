using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;


namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioUsuario
    {
        Task<List<Usuario>> ObtenerUsuarios();
        Task<int> InsertarUsuario(Usuario aut);
        Task<Usuario> CapturarUsuario(int id);
        Task Actualizar(Usuario obj);
        
    }
}
