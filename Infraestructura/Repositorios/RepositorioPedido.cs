using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using Aplicacion.Busqueda;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using System.Threading.Tasks;

using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly mydbEntities1 context;
        public RepositorioPedido(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> ObtenerPedidoes()
        {
            var Resultado = await context.Pedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task<int> InsertarPedido(Pedido aut)
        {
            EntityPedido Eaut = aut.ToEntity();
            context.Pedido.Add(Eaut);
            await context.SaveChangesAsync();
            return Eaut.IdPedido;
        }

        public async Task<Pedido> CapturarPedido(int id)
        {
            EntityPedido Eaut = await context.Pedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Pedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Pedido obj)
        {
            var entity = await context.Pedido.FindAsync(obj.IdPedido);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Pedido>> Buscar(Busqueda<Pedido> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityPedido> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Pedido, EntityPedido>(filtro, mapper);
                Especificacion<EntityPedido> SpecActual = EspecificacionFactory<EntityPedido>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityPedido>(Spec, SpecActual);
            }
            IQueryable<EntityPedido> query = context.Pedido
                                                    .Include("EstadoPedido")
                                                    .Include("Carrito")
                                                    .Include("DetallePedido")
                                                    .Include("Persona");

            if (Spec != null)
            {
                query = query.Where(Spec.ToExpression());
            }

            var resultado = await query.ToListAsync();
            return resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Pedido, EntityPedido>()
                   .ForMember(dest => dest.EstadoPedido_idEstadoPedido, opt => opt.MapFrom(src => src.EstadoPedido.IdEstadoPedido))
                   .ForMember(dest => dest.Carrito_idCarrito, opt => opt.MapFrom(src => src.Carrito.IdCarrito))
                   .ForMember(dest => dest.Persona_idPersona, opt => opt.MapFrom(src => src.Persona.IdPersona))
                   .ForMember(dest => dest.EstadoPedido, opt => opt.Ignore())
                   .ForMember(dest => dest.DetallePedido, opt => opt.Ignore())
                   .ForMember(dest => dest.Carrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Persona, opt => opt.Ignore());

                cfg.CreateMap<EntityPedido, Pedido>()
                   .ForMember(dest => dest.EstadoPedido, opt => opt.Ignore())
                   .ForMember(dest => dest.Carrito, opt => opt.Ignore())
                   .ForMember(dest => dest.DetallePedido, opt => opt.Ignore())
                   .ForMember(dest => dest.Persona, opt => opt.Ignore());

                cfg.CreateMap<Persona, EntityPersona>()
                   .ForMember(dest => dest.Usuario_idUsuario, opt => opt.MapFrom(src => src.Usuario.IdUsuario))
                   .ForMember(dest => dest.Usuario, opt => opt.Ignore());

                cfg.CreateMap<EntityPersona, Persona>()
                   .ForMember(dest => dest.Usuario, opt => opt.Ignore());

                cfg.CreateMap<EstadoPedido, EntityEstadoPedido>();
                cfg.CreateMap<EntityEstadoPedido, EstadoPedido>();

                cfg.CreateMap<Carrito, EntityCarrito>()
                   .ForMember(dest => dest.EstadoCarrito_idEstadoCarrito, opt => opt.MapFrom(src => src.EstadoCarrito.IdEstadoCarrito))
                   .ForMember(dest => dest.EstadoCarrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductoCarrito, opt => opt.Ignore());

                cfg.CreateMap<EntityCarrito, Carrito>()
                   .ForMember(dest => dest.EstadoCarrito, opt => opt.Ignore());

                cfg.CreateMap<EstadoCarrito, EntityEstadoCarrito>();
                cfg.CreateMap<EntityEstadoCarrito, EstadoCarrito>();
                cfg.CreateMap<Usuario, EntityUsuario>();
                cfg.CreateMap<EntityUsuario, Usuario>();
            });
            return config.CreateMapper();
        }
    }
}

