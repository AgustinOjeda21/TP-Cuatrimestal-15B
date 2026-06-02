using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioPersona : IRepositorioPersona
    {
        private readonly mydbEntities context;
        public RepositorioPersona(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Persona>> ObtenerPersonas()
        {
            var Resultado = await context.Persona.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarPersona(Persona aut)
        {
            EntityPersona Eaut = aut.ToEntity();
            context.Persona.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Persona> CapturarPersona(int id)
        {
            EntityPersona Eaut = await context.Persona.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Persona aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Persona obj)
        {
            var entity = await context.Persona.FindAsync(obj.IdPersona);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
