using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioProducto
    {
        private readonly mydbEntities context;
        public RepositorioProducto(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> ObtenerProductoes()
        {
            var Resultado = await context.Productos.ToListAsync();
            return Resultado.Select(e => new Producto(e.IdProducto, e.Nombre)).ToList();
        }
        public async Task InsertarProducto(Producto aut)
        {
            EntityProducto Eaut = new EntityProducto(aut.GetIdProducto(), aut.GetNombre());
            context.Productos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Producto> CapturarProducto(int id)
        {
            EntityProducto Eaut = await context.Productos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Producto aut = new Producto(Eaut.IdProducto, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Producto obj)
        {
            var entity = await context.Productos.FindAsync(obj.GetIdProducto());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
