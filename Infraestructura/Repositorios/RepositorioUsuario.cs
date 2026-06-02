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
    class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly mydbEntities context;
        public RepositorioUsuario(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            var Resultado = await context.Usuario.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarUsuario(Usuario aut)
        {
            EntityUsuario Eaut = aut.ToEntity();
            context.Usuario.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Usuario> CapturarUsuario(int id)
        {
            EntityUsuario Eaut = await context.Usuario.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Usuario aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Usuario obj)
        {
            var entity = await context.Usuario.FindAsync(obj.IdUsuario);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
