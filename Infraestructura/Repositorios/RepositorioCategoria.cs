using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Text;
using Infraestructura.Mappers;
using System.Data.Entity;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;
using System.Threading.Tasks;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly mydbEntities1 context;
        public RepositorioCategoria(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> ObtenerCategorias()
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
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Categoria>> Buscar<Tprop>(Busqueda<Categoria> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityCategoria> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Categoria, EntityCategoria>(filtro, mapper);
                Especificacion<EntityCategoria> SpecActual = EspecificacionFactory<EntityCategoria>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityCategoria>(Spec, SpecActual);
            }
            var Resultado = await context.Categoria.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Categoria, EntityCategoria>()
                   .ForMember(dest => dest.Producto, opt => opt.Ignore());

                cfg.CreateMap<EntityCategoria, Categoria>();
            });
            return config.CreateMapper();
        }
    }
}

