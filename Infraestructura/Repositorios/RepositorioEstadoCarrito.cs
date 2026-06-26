using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using System.Data.Entity;
using Infraestructura.Mappers;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class RepositorioEstadoCarrito : IRepositorioEstadoCarrito
    {
        private readonly mydbEntities1 context;
        public RepositorioEstadoCarrito(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<EstadoCarrito>> ObtenerEstadosCarrito()
        {
            var Resultado = await context.EstadoCarrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarEstadoCarrito(EstadoCarrito aut)
        {
            EntityEstadoCarrito Eaut = aut.ToEntity();
            context.EstadoCarrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoCarrito> CapturarEstadoCarrito(int id)
        {
            EntityEstadoCarrito Eaut = await context.EstadoCarrito.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoCarrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(EstadoCarrito obj)
        {
            var entity = await context.EstadoCarrito.FindAsync(obj.IdEstadoCarrito);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<EstadoCarrito>> Buscar(Busqueda<EstadoCarrito> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityEstadoCarrito> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<EstadoCarrito, EntityEstadoCarrito>(filtro, mapper);
                Especificacion<EntityEstadoCarrito> SpecActual = EspecificacionFactory<EntityEstadoCarrito>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityEstadoCarrito>(Spec, SpecActual);
            }
            var Resultado = await context.EstadoCarrito.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<EstadoCarrito, EntityEstadoCarrito>()
                   .ForMember(dest => dest.Carrito, opt => opt.Ignore());

                cfg.CreateMap<EntityEstadoCarrito, EstadoCarrito>();

            });
            return config.CreateMapper();
        }
    }
}

