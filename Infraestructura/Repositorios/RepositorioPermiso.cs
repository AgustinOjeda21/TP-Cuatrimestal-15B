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
    class RepositorioPermiso : IRepositorioPermiso
    {
        private readonly mydbEntities context;
        public RepositorioPermiso(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Permiso>> ObtenerPermisos()
        {
            var Resultado = await context.Permiso.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarPermiso(Permiso aut)
        {
            EntityPermiso Eaut = aut.ToEntity();
            context.Permiso.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Permiso> CapturarPermiso(int id)
        {
            EntityPermiso Eaut = await context.Permiso.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Permiso aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Permiso obj)
        {
            var entity = await context.Permiso.FindAsync(obj.IdPermiso);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
