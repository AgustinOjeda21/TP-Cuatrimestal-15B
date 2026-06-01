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
    class RepositorioPedido : IRepositorioPedido
    {
        private readonly mydbEntities context;
        public RepositorioPedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> ObtenerPedidoes()
        {
            var Resultado = await context.Pedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarPedido(Pedido aut)
        {
            EntityPedido Eaut = aut.ToEntity();
            context.Pedido.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Pedido> CapturarPedido(int id)
        {
            EntityPedido Eaut = await context.Pedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Pedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Pedido obj)
        {
            var entity = await context.Pedido.FindAsync(obj.IdPedido);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
