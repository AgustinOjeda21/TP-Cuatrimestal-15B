using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Mappers
{
    public static class PersonaExtension
    {
        public static Persona ToDomain(this EntityPersona persona)
        {
            return new Persona(persona.IdPersona, persona.Nombre, persona.Apellido, persona.Mail, persona.Telefono, persona.Usuario.ToDomain(),persona.Direccion.Select(obj=>obj.ToDomain()).ToList());
        }
        public static EntityPersona ToEntity(this Persona persona)
        {
            return new EntityPersona(persona.IdPersona, persona.Nombre, persona.Apellido, persona.Mail, persona.Telefono, persona.Usuario.IdUsuario,persona.Direcciones.Select(obj=>obj.ToEntity()).ToList());
        }
    }
}
