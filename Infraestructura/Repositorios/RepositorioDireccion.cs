using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioDireccion
    {
        private readonly mydbEntities context;
        public RepositorioDireccion(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Direccion>> ObtenerDirecciones()
        {
            var Resultado = await context.Direccions.ToListAsync();
            return Resultado.Select(e => new Direccion(e.IdDireccion, e.Nombre)).ToList();
        }
        public async Task InsertarDireccion(Direccion aut)
        {
            EntityDireccion Eaut = new EntityDireccion(aut.GetIdDireccion(), aut.GetNombre());
            context.Direccions.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Direccion> CapturarDireccion(int id)
        {
            EntityDireccion Eaut = await context.Direccions.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Direccion aut = new Direccion(Eaut.IdDireccion, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Direccion obj)
        {
            var entity = await context.Direccions.FindAsync(obj.GetIdDireccion());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
