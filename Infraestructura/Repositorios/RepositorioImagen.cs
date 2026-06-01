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
    class RepositorioImagen : IRepositorioImagen
    {
        private readonly mydbEntities context;
        public RepositorioImagen(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Imagen>> ObtenerImagenes()
        {
            var Resultado = await context.Imagen.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarImagen(Imagen aut)
        {
            EntityImagen Eaut = aut.ToEntity();
            context.Imagen.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Imagen> CapturarImagen(int id)
        {
            EntityImagen Eaut = await context.Imagen.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Imagen aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Imagen obj)
        {
            var entity = await context.Imagen.FindAsync(obj.IdImagen);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
    }
}
