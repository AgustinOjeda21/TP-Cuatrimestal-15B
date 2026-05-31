using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioPermiso
    {
        private readonly mydbEntities context;
        public RepositorioPermiso(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Permiso>> ObtenerPermisoes()
        {
            var Resultado = await context.Permisos.ToListAsync();
            return Resultado.Select(e => new Permiso(e.IdPermiso, e.Nombre)).ToList();
        }
        public async Task InsertarPermiso(Permiso aut)
        {
            EntityPermiso Eaut = new EntityPermiso(aut.GetIdPermiso(), aut.GetNombre());
            context.Permisos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Permiso> CapturarPermiso(int id)
        {
            EntityPermiso Eaut = await context.Permisos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Permiso aut = new Permiso(Eaut.IdPermiso, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Permiso obj)
        {
            var entity = await context.Permisos.FindAsync(obj.GetIdPermiso());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
