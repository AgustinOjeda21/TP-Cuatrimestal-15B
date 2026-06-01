using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacion.Interfaces.Repositorios;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioRol : IRepositorioRol
    {
        private readonly mydbEntities context;
        public RepositorioRol(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> ObtenerRoles()
        {
            var Resultado = await context.Rol.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarRol(Rol aut)
        {
            EntityRol Eaut = aut.ToEntity();
            context.Rol.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Rol> CapturarRol(int id)
        {
            EntityRol Eaut = await context.Rol.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Rol aut = new Rol(Eaut.IdRol, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Rol obj)
        {
            var entity = await context.Rol.FindAsync(obj.IdRol);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
