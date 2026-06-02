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
    class RepositorioMarca : IRepositorioMarca
    {
        private readonly mydbEntities context;
        public RepositorioMarca(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Marca>> ObtenerMarcas()
        {
            var Resultado = await context.Marca.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarMarca(Marca aut)
        {
            EntityMarca Eaut = aut.ToEntity();
            context.Marca.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Marca> CapturarMarca(int id)
        {
            EntityMarca Eaut = await context.Marca.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Marca aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Marca obj)
        {
            var entity = await context.Marca.FindAsync(obj.IdMarca);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
