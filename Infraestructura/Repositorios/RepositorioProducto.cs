using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using Aplicacion.Interfaces.Repositorios;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioProducto : IRepositorioProducto
    {
        private readonly mydbEntities context;
        public RepositorioProducto(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> ObtenerProductoes()
        {
            var Resultado = await context.Producto.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProducto(Producto aut)
        {
            EntityProducto Eaut = aut.ToEntity();
            context.Producto.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Producto> CapturarProducto(int id)
        {
            EntityProducto Eaut = await context.Producto.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Producto aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Producto obj)
        {
            var entity = await context.Producto.FindAsync(obj.IdProducto);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
