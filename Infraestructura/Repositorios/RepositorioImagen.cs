using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    class RepositorioImagen
    {
        private readonly mydbEntities context;
        public RepositorioImagen(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Imagen>> ObtenerImagenes()
        {
            var Resultado = await context.Imagens.ToListAsync();
            return Resultado.Select(e => new Imagen(e.IdImagen, e.Nombre)).ToList();
        }
        public async Task InsertarImagen(Imagen aut)
        {
            EntityImagen Eaut = new EntityImagen(aut.GetIdImagen(), aut.GetNombre());
            context.Imagens.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Imagen> CapturarImagen(int id)
        {
            EntityImagen Eaut = await context.Imagens.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Imagen aut = new Imagen(Eaut.IdImagen, Eaut.Nombre);
            return aut;
        }
        public async Task Actualizar(Imagen obj)
        {
            var entity = await context.Imagens.FindAsync(obj.GetIdImagen());
            if (entity == null)
            {
                return;
            }
            entity.Mapeo(obj);
            await context.SaveChangesAsync();
        }
    }
}
