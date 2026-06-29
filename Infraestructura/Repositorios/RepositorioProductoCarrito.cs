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
        public async Task Eliminar(int idCarrito, int idProducto)
        {
            var entity = await context.ProductoCarrito
                .Include(c => c.Producto)
                .Include(c => c.Carrito)
                .FirstOrDefaultAsync(c => c.Producto_idProducto == idProducto && c.Carrito_idCarrito == idCarrito);
            if (entity != null)
            {
                context.ProductoCarrito.Remove(entity);
                await context.SaveChangesAsync();
            }
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
            var entity = await context.ProductoCarrito.FirstOrDefaultAsync(pro => pro.Producto_idProducto == obj.Producto.IdProducto && pro.Carrito_idCarrito == obj.Carrito.IdCarrito);
            if (entity == null)
            {
                return;
            }
            entity.Cantidad = obj.Cantidad;
            entity.Carrito_idCarrito = obj.Carrito.IdCarrito;
            entity.Producto_idProducto = obj.Producto.IdProducto;
            await context.SaveChangesAsync();
        }
        public async Task<List<ProductoCarrito>> Buscar(Busqueda<ProductoCarrito> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityProductoCarrito> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<ProductoCarrito, EntityProductoCarrito>(filtro, mapper);
                Especificacion<EntityProductoCarrito> SpecActual = EspecificacionFactory<EntityProductoCarrito>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityProductoCarrito>(Spec, SpecActual);
            }
            var Resultado = await context.ProductoCarrito
            .Where(Spec.ToExpression())
            .ToListAsync(); 
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                // Dominio -> Entidad
                cfg.CreateMap<ProductoCarrito, EntityProductoCarrito>()
                   .ForMember(dest => dest.Producto_idProducto, opt => opt.MapFrom(src => src.Producto.IdProducto))
                   .ForMember(dest => dest.Carrito_idCarrito, opt => opt.MapFrom(src => src.Carrito.IdCarrito))
                   .ForMember(dest => dest.Carrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Producto, opt => opt.Ignore());

                cfg.CreateMap<Carrito, EntityCarrito>()
                   .ForMember(dest => dest.EstadoCarrito_idEstadoCarrito, opt => opt.MapFrom(src => src.EstadoCarrito.IdEstadoCarrito))
                   .ForMember(dest => dest.EstadoCarrito, opt => opt.Ignore())
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductoCarrito, opt => opt.Ignore());

                cfg.CreateMap<Producto, EntityProducto>()
                   .ForMember(dest => dest.Marca_idMarca, opt => opt.MapFrom(src => src.Marca.IdMarca))
                   .ForMember(dest => dest.Marca, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductoCarrito, opt => opt.Ignore());

                cfg.CreateMap<Marca, EntityMarca>();
                cfg.CreateMap<Categoria, EntityCategoria>();
                cfg.CreateMap<Imagen, EntityImagen>();
                cfg.CreateMap<Proveedor, EntityProveedor>();
                cfg.CreateMap<Direccion, EntityDireccion>();

                // Entidad -> Dominio
                cfg.CreateMap<EntityProductoCarrito, ProductoCarrito>()
                   .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto))
                   .ForMember(dest => dest.Carrito, opt => opt.MapFrom(src => src.Carrito));

                cfg.CreateMap<EntityCarrito, Carrito>()
                   .ForMember(dest => dest.EstadoCarrito, opt => opt.MapFrom(src => src.EstadoCarrito));

                cfg.CreateMap<EntityEstadoCarrito, EstadoCarrito>();

                cfg.CreateMap<EntityProducto, Producto>()
                   .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca))
                   .ForMember(dest => dest.Categorias, opt => opt.MapFrom(src => src.Categoria))
                   .ForMember(dest => dest.Imagenes, opt => opt.MapFrom(src => src.Imagen))
                   .ForMember(dest => dest.Proveedores, opt => opt.MapFrom(src => src.Proveedor));

                cfg.CreateMap<EntityMarca, Marca>()
                   .ForMember(dest => dest.Imagenes, opt => opt.MapFrom(src => src.Imagen));

                cfg.CreateMap<EntityCategoria, Categoria>();
                cfg.CreateMap<EntityImagen, Imagen>();

                cfg.CreateMap<EntityProveedor, Proveedor>()
                   .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion));

                cfg.CreateMap<EntityDireccion, Direccion>();
            });

            return config.CreateMapper();
        }

    }
}

