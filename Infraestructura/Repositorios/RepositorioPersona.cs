using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioPersona
    {
        private readonly mydbEntities context;
        public RepositorioPersona(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Persona>> ObtenerPersonaes()
        {
            var Resultado = await context.Personas.ToListAsync();
            return Resultado.Select(e => new Persona(e.IdPersona, e.Nombre)).ToList();
        }
        public async Task InsertarPersona(Persona aut)
        {
            EntityPersona Eaut = new EntityPersona(aut.GetIdPersona(), aut.GetNombre());
            context.Personas.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Persona> CapturarPersona(int id)
        {
            EntityPersona Eaut = await context.Personas.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Persona aut = new Persona(Eaut.IdPersona, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Persona obj)
        {
            var entity = await context.Personas.FindAsync(obj.GetIdPersona());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
