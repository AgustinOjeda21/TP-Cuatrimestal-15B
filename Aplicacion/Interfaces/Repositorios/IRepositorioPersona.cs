using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioPersona
    {
        Task<List<Persona>> ObtenerPersonas();

        Task InsertarPersona(Persona aut);
        Task QuitarDireccion(int persona, int IdDireccion);
        Task AgregarDireccion(int persona, Direccion Direccion);
        Task<Persona> CapturarPersona(int id);

        Task Actualizar(Persona obj);
       
    }
}
