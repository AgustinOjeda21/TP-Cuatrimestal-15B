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
    class RepositorioProveedor : IRepositorioProveedor
    {
        private readonly mydbEntities context;
        public RepositorioProveedor(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            var Resultado = await context.Proveedor.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProveedor(Proveedor aut)
        {
            EntityProveedor Eaut = aut.ToEntity();
            context.Proveedor.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Proveedor> CapturarProveedor(int id)
        {
            EntityProveedor Eaut = await context.Proveedor.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Proveedor aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Proveedor obj)
        {
            var entity = await context.Proveedor.FindAsync(obj.IdProveedor);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
