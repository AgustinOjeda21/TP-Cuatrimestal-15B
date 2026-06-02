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
    public class RepositorioDireccion : IRepositorioDireccion
    {
        private readonly mydbEntities context;
        public RepositorioDireccion(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Direccion>> ObtenerDirecciones()
        {
            var Resultado = await context.Direccion.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarDireccion(Direccion aut)
        {
            EntityDireccion Eaut = aut.ToEntity();
            context.Direccion.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Direccion> CapturarDireccion(int id)
        {
            EntityDireccion Eaut = await context.Direccion.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Direccion aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Direccion obj)
        {
            var entity = await context.Direccion.FindAsync(obj.IdDireccion);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}

