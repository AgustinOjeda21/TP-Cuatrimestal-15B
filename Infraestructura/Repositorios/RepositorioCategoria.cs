using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using Infraestructura.Mappers;
using System.Data.Entity;
using Aplicacion.Interfaces.Repositorios;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly mydbEntities context;
        public RepositorioCategoria(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> ObtenerCategoriaes()
        {
            var Resultado = await context.Categoria.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarCategoria(Categoria aut)
        {
            EntityCategoria Eaut = aut.ToEntity();
            context.Categoria.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Categoria> CapturarCategoria(int id)
        {
            EntityCategoria Eaut = await context.Categoria.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Categoria aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Categoria obj)
        {
            var entity = await context.Categoria.FindAsync(obj.IdCategoria);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
