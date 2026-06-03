using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Aplicacion.Interfaces.Repositorios;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class RepositorioEstadoPedido : IRepositorioEstadoPedido
    {
        private readonly mydbEntities context;
        public RepositorioEstadoPedido(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<EstadoPedido>> ObtenerEstadosPedido()
        {
            var Resultado = await context.EstadoPedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarEstadoPedido(EstadoPedido aut)
        {
            EntityEstadoPedido Eaut = aut.ToEntity();
            context.EstadoPedido.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<EstadoPedido> CapturarEstadoPedido(int id)
        {
            EntityEstadoPedido Eaut = await context.EstadoPedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            EstadoPedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(EstadoPedido obj)
        {
            var entity = await context.EstadoPedido.FindAsync(obj.IdEstadoPedido);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<EstadoPedido>> Buscar<Tprop>(Busqueda<EstadoPedido> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityEstadoPedido> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<EstadoPedido, EntityEstadoPedido>(filtro, mapper);
                Especificacion<EntityEstadoPedido> SpecActual = EspecificacionFactory<EntityEstadoPedido>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityEstadoPedido>(Spec, SpecActual);
            }
            var Resultado = await context.EstadoPedido.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<EstadoPedido, EntityEstadoPedido>()
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore());

                cfg.CreateMap<EntityEstadoPedido, EstadoPedido>();
            });
            return config.CreateMapper();
        }
    }
}

