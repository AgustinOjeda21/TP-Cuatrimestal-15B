using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioEstadoPedido : IRepositorioEstadoPedido
    {
        private readonly mydbEntities context;
        public RepositorioEstadoPedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<EstadoPedido>> ObtenerEstadoPedidoes()
        {
            var Resultado = await context.EstadoPedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarEstadoPedido(EstadoPedido aut)
        {
            EntityEstadoPedido Eaut = aut.ToEntity();
            context.EstadoPedido.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoPedido> CapturarEstadoPedido(int id)
        {
            EntityEstadoPedido Eaut = await context.EstadoPedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoPedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(EstadoPedido obj)
        {
            var entity = await context.EstadoPedido.FindAsync(obj.IdEstadoPedido);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
