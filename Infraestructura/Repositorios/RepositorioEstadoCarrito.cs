using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using System.Data.Entity;
using Infraestructura.Mappers;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioEstadoCarrito : IRepositorioEstadoCarrito
    {
        private readonly mydbEntities context;
        public RepositorioEstadoCarrito(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<EstadoCarrito>> ObtenerEstadoCarritoes()
        {
            var Resultado = await context.EstadoCarrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarEstadoCarrito(EstadoCarrito aut)
        {
            EntityEstadoCarrito Eaut = aut.ToEntity();
            context.EstadoCarrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoCarrito> CapturarEstadoCarrito(int id)
        {
            EntityEstadoCarrito Eaut = await context.EstadoCarrito.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoCarrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(EstadoCarrito obj)
        {
            var entity = await context.EstadoCarrito.FindAsync(obj.IdEstadoCarrito);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
