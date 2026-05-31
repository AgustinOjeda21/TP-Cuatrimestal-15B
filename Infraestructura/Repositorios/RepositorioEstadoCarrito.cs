using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioEstadoCarrito
    {
        private readonly mydbEntities context;
        public RepositorioEstadoCarrito(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<EstadoCarrito>> ObtenerEstadoCarritoes()
        {
            var Resultado = await context.EstadoCarritos.ToListAsync();
            return Resultado.Select(e => new EstadoCarrito(e.IdEstadoCarrito, e.Nombre)).ToList();
        }
        public async Task InsertarEstadoCarrito(EstadoCarrito aut)
        {
            EntityEstadoCarrito Eaut = new EntityEstadoCarrito(aut.GetIdEstadoCarrito(), aut.GetNombre());
            context.EstadoCarritos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoCarrito> CapturarEstadoCarrito(int id)
        {
            EntityEstadoCarrito Eaut = await context.EstadoCarritos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoCarrito aut = new EstadoCarrito(Eaut.IdEstadoCarrito, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(EstadoCarrito obj)
        {
            var entity = await context.EstadoCarritos.FindAsync(obj.GetIdEstadoCarrito());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
