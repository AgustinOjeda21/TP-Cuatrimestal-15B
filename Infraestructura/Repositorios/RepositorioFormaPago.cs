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
    class RepositorioFormaPago : IRepositorioFormaPago
    {
        private readonly mydbEntities context;
        public RepositorioFormaPago(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<FormaPago>> ObtenerFormaPagoes()
        {
            var Resultado = await context.FormaPago.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarFormaPago(FormaPago aut)
        {
            EntityFormaPago Eaut = aut.ToEntity();
            context.FormaPago.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaPago> CapturarFormaPago(int id)
        {
            EntityFormaPago Eaut = await context.FormaPago.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaPago aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(FormaPago obj)
        {
            var entity = await context.FormaPago.FindAsync(obj.IdFormaPago);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
