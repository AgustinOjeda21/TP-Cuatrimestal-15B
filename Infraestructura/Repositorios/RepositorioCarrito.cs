using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Data.Entity;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using Infraestructura.Mappers;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioCarrito : IRepositorioCarrito
    {
        private readonly mydbEntities context;
        public RepositorioCarrito (mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Carrito>> ObtenerCarritoes()
        {
            var Resultado = await context.Carrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarCarrito(Carrito aut)
        {
            EntityCarrito Eaut = aut.ToEntity();
            context.Carrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Carrito> CapturarCarrito(int id)
        {
            EntityCarrito Eaut = await context.Carrito.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Carrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Carrito obj)
        {
            var entity = await context.Carrito.FindAsync(obj.IdCarrito);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
