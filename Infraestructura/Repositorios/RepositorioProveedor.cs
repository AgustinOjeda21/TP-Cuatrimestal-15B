using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class Class7
    {
        private readonly mydbEntities context;
        public RepositorioProveedor(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            var Resultado = await context.Proveedors.ToListAsync();
            return Resultado.Select(e => new Proveedor(e.IdProveedor, e.Nombre)).ToList();
        }
        public async Task InsertarProveedor(Proveedor aut)
        {
            EntityProveedor Eaut = new EntityProveedor(aut.GetIdProveedor(), aut.GetNombre());
            context.Proveedors.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Proveedor> CapturarProveedor(int id)
        {
            EntityProveedor Eaut = await context.Proveedors.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Proveedor aut = new Proveedor(Eaut.IdProveedor, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Proveedor obj)
        {
            var entity = await context.Proveedors.FindAsync(obj.GetIdProveedor());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
