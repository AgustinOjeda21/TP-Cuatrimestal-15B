using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioDetallePedido
    {
        private readonly mydbEntities context;
        public RepositorioDetallePedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<DetallePedido>> ObtenerDetallePedidoes()
        {
            var Resultado = await context.DetallePedidos.ToListAsync();
            return Resultado.Select(e => new DetallePedido(e.IdDetallePedido, e.Nombre)).ToList();
        }
        public async Task InsertarDetallePedido(DetallePedido aut)
        {
            EntityDetallePedido Eaut = new EntityDetallePedido(aut.GetIdDetallePedido(), aut.GetNombre());
            context.DetallePedidos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<DetallePedido> CapturarDetallePedido(int id)
        {
            EntityDetallePedido Eaut = await context.DetallePedidos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            DetallePedido aut = new DetallePedido(Eaut.IdDetallePedido, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(DetallePedido obj)
        {
            var entity = await context.DetallePedidos.FindAsync(obj.GetIdDetallePedido());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
