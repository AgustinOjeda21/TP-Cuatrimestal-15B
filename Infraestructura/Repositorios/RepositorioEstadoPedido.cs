using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioEstadoPedido
    {
        private readonly mydbEntities context;
        public RepositorioEstadoPedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<EstadoPedido>> ObtenerEstadoPedidoes()
        {
            var Resultado = await context.EstadoPedidos.ToListAsync();
            return Resultado.Select(e => new EstadoPedido(e.IdEstadoPedido, e.Nombre)).ToList();
        }
        public async Task InsertarEstadoPedido(EstadoPedido aut)
        {
            EntityEstadoPedido Eaut = new EntityEstadoPedido(aut.GetIdEstadoPedido(), aut.GetNombre());
            context.EstadoPedidos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoPedido> CapturarEstadoPedido(int id)
        {
            EntityEstadoPedido Eaut = await context.EstadoPedidos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoPedido aut = new EstadoPedido(Eaut.IdEstadoPedido, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(EstadoPedido obj)
        {
            var entity = await context.EstadoPedidos.FindAsync(obj.GetIdEstadoPedido());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
