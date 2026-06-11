using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Data.Entity;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using Infraestructura.Mappers;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioCarrito : IRepositorioCarrito
    {
        

        private readonly mydbEntities1 context;
        public RepositorioCarrito (mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Carrito>> ObtenerCarritos()
        {
            var Resultado = await context.Carrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarCarrito(Carrito aut)
        {
            EntityCarrito Eaut = aut.ToEntity();
            context.Carrito.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Carrito> CapturarCarrito(int id)
        {
            EntityCarrito Eaut = await context.Carrito.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Carrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Carrito obj)
        {
            var entity = await context.Carrito.FindAsync(obj.IdCarrito);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }

       public async Task<List<Carrito>> Buscar<Tprop>(Busqueda<Carrito> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityCarrito> Spec = null;
            foreach(var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Carrito,EntityCarrito>(filtro, mapper);
                Especificacion<EntityCarrito> SpecActual = EspecificacionFactory<EntityCarrito>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityCarrito>(Spec, SpecActual);
            }
            var Resultado = await context.Carrito.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Carrito, EntityCarrito>()
                   .ForMember(
                       dest => dest.EstadoCarrito_idEstadoCarrito,
                       opt => opt.MapFrom(src => src.EstadoCarrito.IdEstadoCarrito)
                   )
                   .ForMember(dest => dest.EstadoCarrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductoCarrito, opt => opt.Ignore());

                cfg.CreateMap<EntityCarrito, Carrito>()
                   .ForMember(
                       dest => dest.EstadoCarrito,
                       opt => opt.MapFrom(src => src.EstadoCarrito.ToDomain())
                   );
            });
            return config.CreateMapper();
        }
    }
}

