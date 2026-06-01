using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;

namespace Infraestructura.Repositorios
{
    class RepositorioDetallePedido : IRepositorioDetallePedido
    {
        private readonly mydbEntities context;
        public RepositorioDetallePedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<DetallePedido>> ObtenerDetallePedidoes()
        {
            var Resultado = await context.DetallePedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarDetallePedido(DetallePedido aut)
        {
            EntityDetallePedido Eaut = aut.ToEntity();
            context.DetallePedido.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<DetallePedido> CapturarDetallePedido(int id)
        {
            EntityDetallePedido Eaut = await context.DetallePedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            DetallePedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(DetallePedido obj)
        {
            var entity = await context.DetallePedido.FindAsync(obj.Pedido.IdPedido);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
