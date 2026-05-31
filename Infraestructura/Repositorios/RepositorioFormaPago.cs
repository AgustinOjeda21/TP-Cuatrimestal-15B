using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioFormaPago
    {
        private readonly mydbEntities context;
        public RepositorioFormaPago(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<FormaPago>> ObtenerFormaPagoes()
        {
            var Resultado = await context.FormaPagos.ToListAsync();
            return Resultado.Select(e => new FormaPago(e.IdFormaPago, e.Nombre)).ToList();
        }
        public async Task InsertarFormaPago(FormaPago aut)
        {
            EntityFormaPago Eaut = new EntityFormaPago(aut.GetIdFormaPago(), aut.GetNombre());
            context.FormaPagos.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaPago> CapturarFormaPago(int id)
        {
            EntityFormaPago Eaut = await context.FormaPagos.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaPago aut = new FormaPago(Eaut.IdFormaPago, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(FormaPago obj)
        {
            var entity = await context.FormaPagos.FindAsync(obj.GetIdFormaPago());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
