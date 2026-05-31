using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioRol
    {
        private readonly mydbEntities context;
        public RepositorioRol(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> ObtenerRoles()
        {
            var Resultado = await context.Rols.ToListAsync();
            return Resultado.Select(e => new Rol(e.IdRol, e.Nombre)).ToList();
        }
        public async Task InsertarRol(Rol aut)
        {
            EntityRol Eaut = new EntityRol(aut.GetIdRol(), aut.GetNombre());
            context.Rols.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Rol> CapturarRol(int id)
        {
            EntityRol Eaut = await context.Rols.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Rol aut = new Rol(Eaut.IdRol, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Rol obj)
        {
            var entity = await context.Rols.FindAsync(obj.GetIdRol());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
