using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioCarrito
    {
        private readonly mydbEntities context;
        public RepositorioCarrito (mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Carrito>> ObtenerCarritoes()
        {
            var Resultado = await context.Carrito.ToListAsync();
            return Resultado.Select(e => new Carrito(e.IdCarrito, e.Nombre)).ToList();
        }
        public async Task InsertarCarrito(Carrito aut)
        {
            EntityCarrito Eaut = new EntityCarrito(aut.GetIdCarrito(), aut.GetNombre());
            context.Carrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Carrito> CapturarCarrito(int id)
        {
            EntityCarrito Eaut = await context.Carritos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Carrito aut = new Carrito(Eaut.IdCarrito, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Carrito obj)
        {
            var entity = await context.Carritos.FindAsync(obj.GetIdCarrito());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
