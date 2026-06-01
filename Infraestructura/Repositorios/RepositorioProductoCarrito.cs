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
    class RepositorioProductoCarrito : IRepositorioProductoCarrito
    {
        private readonly mydbEntities context;
        public RepositorioProductoCarrito(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<ProductoCarrito>> ObtenerProductoCarritoes()
        {
            var Resultado = await context.ProductoCarrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProductoCarrito(ProductoCarrito aut)
        {
            EntityProductoCarrito Eaut = aut.ToEntity();
            context.ProductoCarrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<ProductoCarrito> CapturarProductoCarrito(int id)
        {
            EntityProductoCarrito Eaut = await context.ProductoCarrito.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            ProductoCarrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(ProductoCarrito obj)
        {
            var entity = await context.ProductoCarrito.FindAsync(obj.Carrito.IdCarrito,obj.Producto.IdProducto);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
