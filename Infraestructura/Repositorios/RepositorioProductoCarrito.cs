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
    public class RepositorioProductoCarrito : IRepositorioProductoCarrito
    {
        private readonly mydbEntities1 context;
        public RepositorioProductoCarrito(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<ProductoCarrito>> ObtenerProductoCarritoes()
        {
            var Resultado = await context.ProductoCarrito.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProductoCarrito(ProductoCarrito aut)
        {
            EntityProductoCarrito Eaut = aut.ToEntity();
            context.ProductoCarrito.Add(Eaut);
            await context.SaveChangesAsync();
        }
        public async Task EliminarProductoCarrito(ProductoCarrito aut)
        {
            EntityProductoCarrito Eaut = aut.ToEntity();
            context.ProductoCarrito.Remove(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<ProductoCarrito> CapturarProductoCarrito(int idCarrito,int idProducto)
        {
            EntityProductoCarrito Eaut = await context.ProductoCarrito.FirstOrDefaultAsync(obj=>obj.Producto_idProducto==idProducto && obj.Carrito_idCarrito==idCarrito);
            if (Eaut == null)
            {
                return null;
            }
            ProductoCarrito aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(ProductoCarrito obj)
        {
            var entity = await context.ProductoCarrito.FindAsync(obj.Carrito.IdCarrito,obj.Producto.IdProducto);
            if (entity == null)
            {
                return;
            }
            entity = obj.ToEntity();
            await context.SaveChangesAsync();
        }
        public async Task<List<ProductoCarrito>> Buscar<Tprop>(Busqueda<ProductoCarrito> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityProductoCarrito> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<ProductoCarrito, EntityProductoCarrito>(filtro, mapper);
                Especificacion<EntityProductoCarrito> SpecActual = EspecificacionFactory<EntityProductoCarrito>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityProductoCarrito>(Spec, SpecActual);
            }
            var Resultado = await context.ProductoCarrito.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<ProductoCarrito, EntityProductoCarrito>()
                   .ForMember(
                       dest => dest.Producto_idProducto,
                       opt => opt.MapFrom(src => src.Producto.IdProducto)
                   )
                   .ForMember(
                       dest => dest.Carrito_idCarrito,
                       opt => opt.MapFrom(src => src.Carrito.IdCarrito)
                   )
                   .ForMember(dest => dest.Carrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Producto, opt => opt.Ignore());

                cfg.CreateMap<EntityProductoCarrito, ProductoCarrito>()
                   .ForMember(
                       dest => dest.Producto,
                       opt => opt.MapFrom(src => src.Producto.ToDomain())
                   )
                    .ForMember(
                       dest => dest.Producto,
                       opt => opt.MapFrom(src => src.Producto.ToDomain())
                   );
            });
            return config.CreateMapper();
        }
    }
}

