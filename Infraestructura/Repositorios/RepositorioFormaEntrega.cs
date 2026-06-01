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
    class RepositorioFormaEntrega : IRepositorioFormaEntrega
    {
        private readonly mydbEntities context;
        public RepositorioFormaEntrega(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<FormaEntrega>> ObtenerFormaEntregaes()
        {
            var Resultado = await context.FormaEntrega.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarFormaEntrega(FormaEntrega aut)
        {
            EntityFormaEntrega Eaut = aut.ToEntity();
            context.FormaEntrega.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaEntrega> CapturarFormaEntrega(int id)
        {
            EntityFormaEntrega Eaut = await context.FormaEntrega.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaEntrega aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(FormaEntrega obj)
        {
            var entity = await context.FormaEntrega.FindAsync(obj.IdFormaEntrega);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
