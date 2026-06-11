using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioDetallePedido : IRepositorioDetallePedido
    {
        private readonly mydbEntities1 context;
        public RepositorioDetallePedido(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<DetallePedido>> ObtenerDetallePedidoes()
        {
            var Resultado = await context.DetallePedido.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarDetallePedido(DetallePedido aut)
        {
            EntityDetallePedido Eaut = aut.ToEntity();
            context.DetallePedido.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<DetallePedido> CapturarDetallePedido(int id)
        {
            EntityDetallePedido Eaut = await context.DetallePedido.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            DetallePedido aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(DetallePedido obj)
        {
            var entity = await context.DetallePedido.FindAsync(obj.Pedido.IdPedido);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
        public async Task<List<DetallePedido>> Buscar<Tprop>(Busqueda<DetallePedido> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityDetallePedido> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<DetallePedido, EntityDetallePedido>(filtro, mapper);
                Especificacion<EntityDetallePedido> SpecActual = EspecificacionFactory<EntityDetallePedido>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityDetallePedido>(Spec, SpecActual);
            }
            var Resultado = await context.DetallePedido.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<DetallePedido, EntityDetallePedido>()
                   .ForMember(
                       dest => dest.Direccion_idDireccion,
                       opt => opt.MapFrom(src => src.Direccion.IdDireccion)
                   )
                   .ForMember(
                       dest => dest.FormaEntrega_idFormaEntrega,
                       opt => opt.MapFrom(src => src.FormaEntrega.IdFormaEntrega)
                   )
                   .ForMember(
                       dest => dest.FormaPago_idFormaPago,
                       opt => opt.MapFrom(src => src.FormaPago.IdFormaPago)
                   )
                   .ForMember(
                       dest => dest.Pedido_idPedido,
                       opt => opt.MapFrom(src => src.Pedido.IdPedido)
                   )
                   .ForMember(dest => dest.Direccion, opt => opt.Ignore())
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore())
                   .ForMember(dest => dest.FormaPago, opt => opt.Ignore())
                   .ForMember(dest => dest.FormaEntrega, opt => opt.Ignore());

                cfg.CreateMap<EntityDetallePedido, DetallePedido>()
                   .ForMember(
                       dest => dest.Direccion,
                       opt => opt.MapFrom(src => src.Direccion.ToDomain())
                   )
                    .ForMember(
                       dest => dest.Pedido,
                       opt => opt.MapFrom(src => src.Pedido.ToDomain())
                   )
                    .ForMember(
                       dest => dest.FormaEntrega,
                       opt => opt.MapFrom(src => src.FormaPago.ToDomain())
                   )
                    .ForMember(
                       dest => dest.FormaPago,
                       opt => opt.MapFrom(src => src.FormaEntrega.ToDomain())
                   );
            });
            return config.CreateMapper();
        }
    }
}

