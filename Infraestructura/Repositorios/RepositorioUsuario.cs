using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioUsuario
    {
        private readonly mydbEntities context;
        public RepositorioUsuario(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Autor>> ObtenerAutores()
        {
            var Resultado = await context.Autors.ToListAsync();
            return Resultado.Select(e => new Autor(e.IdAutor, e.Nombre)).ToList();
        }
        public async Task InsertarAutor(Autor aut)
        {
            EntityAutor Eaut = new EntityAutor(aut.GetIdAutor(), aut.GetNombre());
            context.Autors.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Autor> CapturarAutor(int id)
        {
            EntityAutor Eaut = await context.Autors.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Autor aut = new Autor(Eaut.IdAutor, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Autor obj)
        {
            var entity = await context.Autors.FindAsync(obj.GetIdAutor());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
