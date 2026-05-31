using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioCategoria
    {
        private readonly mydbEntities context;
        public RepositorioCategoria(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> ObtenerCategoriaes()
        {
            var Resultado = await context.Categorias.ToListAsync();
            return Resultado.Select(e => new Categoria(e.IdCategoria, e.Nombre)).ToList();
        }
        public async Task InsertarCategoria(Categoria aut)
        {
            EntityCategoria Eaut = new EntityCategoria(aut.GetIdCategoria(), aut.GetNombre());
            context.Categorias.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Categoria> CapturarCategoria(int id)
        {
            EntityCategoria Eaut = await context.Categorias.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Categoria aut = new Categoria(Eaut.IdCategoria, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Categoria obj)
        {
            var entity = await context.Categorias.FindAsync(obj.GetIdCategoria());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
