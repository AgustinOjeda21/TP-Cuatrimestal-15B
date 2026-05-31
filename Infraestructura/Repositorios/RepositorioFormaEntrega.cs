using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioFormaEntrega
    {
        private readonly mydbEntities context;
        public RepositorioFormaEntrega(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<FormaEntrega>> ObtenerFormaEntregaes()
        {
            var Resultado = await context.FormaEntregas.ToListAsync();
            return Resultado.Select(e => new FormaEntrega(e.IdFormaEntrega, e.Nombre)).ToList();
        }
        public async Task InsertarFormaEntrega(FormaEntrega aut)
        {
            EntityFormaEntrega Eaut = new EntityFormaEntrega(aut.GetIdFormaEntrega(), aut.GetNombre());
            context.FormaEntregas.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaEntrega> CapturarFormaEntrega(int id)
        {
            EntityFormaEntrega Eaut = await context.FormaEntregas.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaEntrega aut = new FormaEntrega(Eaut.IdFormaEntrega, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(FormaEntrega obj)
        {
            var entity = await context.FormaEntregas.FindAsync(obj.GetIdFormaEntrega());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
