using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioPedido
    {
        private readonly mydbEntities context;
        public RepositorioPedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> ObtenerPedidoes()
        {
            var Resultado = await context.Pedidos.ToListAsync();
            return Resultado.Select(e => new Pedido(e.IdPedido, e.Nombre)).ToList();
        }
        public async Task InsertarPedido(Pedido aut)
        {
            EntityPedido Eaut = new EntityPedido(aut.GetIdPedido(), aut.GetNombre());
            context.Pedidos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Pedido> CapturarPedido(int id)
        {
            EntityPedido Eaut = await context.Pedidos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Pedido aut = new Pedido(Eaut.IdPedido, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Pedido obj)
        {
            var entity = await context.Pedidos.FindAsync(obj.GetIdPedido());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
