using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioMarca
    {
        private readonly mydbEntities context;
        public RepositorioMarca(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Marca>> ObtenerMarcaes()
        {
            var Resultado = await context.Marcas.ToListAsync();
            return Resultado.Select(e => new Marca(e.IdMarca, e.Nombre)).ToList();
        }
        public async Task InsertarMarca(Marca aut)
        {
            EntityMarca Eaut = new EntityMarca(aut.GetIdMarca(), aut.GetNombre());
            context.Marcas.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Marca> CapturarMarca(int id)
        {
            EntityMarca Eaut = await context.Marcas.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Marca aut = new Marca(Eaut.IdMarca, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Marca obj)
        {
            var entity = await context.Marcas.FindAsync(obj.GetIdMarca());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
