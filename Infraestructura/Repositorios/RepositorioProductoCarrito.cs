using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioProductoCarrito
    {
        private readonly mydbEntities context;
        public RepositorioProductoCarrito(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<ProductoCarrito>> ObtenerProductoCarritoes()
        {
            var Resultado = await context.ProductoCarritos.ToListAsync();
            return Resultado.Select(e => new ProductoCarrito(e.IdProductoCarrito, e.Nombre)).ToList();
        }
        public async Task InsertarProductoCarrito(ProductoCarrito aut)
        {
            EntityProductoCarrito Eaut = new EntityProductoCarrito(aut.GetIdProductoCarrito(), aut.GetNombre());
            context.ProductoCarritos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<ProductoCarrito> CapturarProductoCarrito(int id)
        {
            EntityProductoCarrito Eaut = await context.ProductoCarritos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            ProductoCarrito aut = new ProductoCarrito(Eaut.IdProductoCarrito, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(ProductoCarrito obj)
        {
            var entity = await context.ProductoCarritos.FindAsync(obj.GetIdProductoCarrito());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
