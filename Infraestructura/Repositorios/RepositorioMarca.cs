using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Busqueda;
using Aplicacion.Interfaces.Repositorios;
using System.Threading.Tasks;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly mydbEntities1 context;
        public RepositorioMarca(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Marca>> ObtenerMarcas()
        {
            var Resultado = await context.Marca.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarMarca(Marca aut)
        {
            EntityMarca Eaut = aut.ToEntity();
            context.Marca.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Marca> CapturarMarca(int id)
        {
            EntityMarca Eaut = await context.Marca.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Marca aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Marca obj)
        {
            var entity = await context.Marca.FindAsync(obj.IdMarca);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }

        public async Task QuitarImagen(int marca, int IdImagen)
        {
            var entity = await context.Marca
                              .Include("Imagen")
                              .FirstOrDefaultAsync(m => m.IdMarca == marca);
            if (entity == null) return;

            var imagenEntity = entity.Imagen.FirstOrDefault(i => i.IdImagen == IdImagen);
            if (imagenEntity == null) return;

            entity.Imagen.Remove(imagenEntity);
            await context.SaveChangesAsync();
        }

        public async Task AgregarImagen(int marca,Imagen imagen)
        {
            var entity = await context.Marca
                              .Include("Imagen")
                              .FirstOrDefaultAsync(m => m.IdMarca == marca);
            if (entity == null) return;
            entity.Imagen.Add(imagen.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Marca>> Buscar<Tprop>(Busqueda<Marca> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityMarca> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Marca, EntityMarca>(filtro, mapper);
                Especificacion<EntityMarca> SpecActual = EspecificacionFactory<EntityMarca>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityMarca>(Spec, SpecActual);
            }
            var Resultado = await context.Marca.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Marca, EntityMarca>()
                   .ForMember(dest => dest.Producto, opt => opt.Ignore())
                   .ForMember(dest => dest.Imagen, opt => opt.Ignore());

                cfg.CreateMap<EntityMarca, Marca>();
            });
            return config.CreateMapper();
        }
    }
}

