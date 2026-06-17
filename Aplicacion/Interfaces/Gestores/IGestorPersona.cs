using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorPersona
    {
        Task<Result<Persona>> CargarPersona(Persona edi, List<Direccion> direcciones);


        Task<Persona> CapturarPersona(int id);

        Task<List<Persona>> DevolverPersonas();


        Task<Result<Persona>> ModificarNombre(string Nombre, int id);


        Task<Result<Persona>> ModificarApellido(string Apellido, int id);

        Task<Result<Persona>> ModificarMail(string Mail, int id);

        Task<Result<Persona>> ModificarTelefono(string Telefono, int id);

        Task<bool> ValidarPersona(int id);


        Task<Result<Persona>> ExistePersona(int id);
        
    }
}


