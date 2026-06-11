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
    public class RepositorioImagen : IRepositorioImagen
    {
        private readonly mydbEntities1 context;
        public RepositorioImagen(mydbEntities1 context)
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
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Imagen>> Buscar<Tprop>(Busqueda<Imagen> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityImagen> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Imagen, EntityImagen>(filtro, mapper);
                Especificacion<EntityImagen> SpecActual = EspecificacionFactory<EntityImagen>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityImagen>(Spec, SpecActual);
            }
            var Resultado = await context.Imagen.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Imagen, EntityImagen>()
                   .ForMember(dest => dest.Marca, opt => opt.Ignore())
                   .ForMember(dest => dest.Producto, opt => opt.Ignore());

                cfg.CreateMap<EntityImagen, Imagen>();
            });
            return config.CreateMapper();
        }
    }
}

