using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using Aplicacion.Interfaces.Repositorios;
using System.Text;
using Aplicacion.Busqueda;
using System.Threading.Tasks;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly mydbEntities1 context;
        public RepositorioProducto(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            var Resultado = await context.Producto.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProducto(Producto aut)
        {
            EntityProducto Eaut = aut.ToEntity();
            context.Producto.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Producto> CapturarProducto(int id)
        {
            EntityProducto Eaut = await context.Producto.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Producto aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Eliminar(int id)
        {
            var entity = await context.Producto.FindAsync(id);
            if (entity != null)
            {
                context.Producto.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task Actualizar(Producto obj)
        {
            var entity = await context.Producto.FindAsync(obj.IdProducto);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }

        public async Task ActualizarMarca(Producto obj)
        {
            var entity = await context.Producto.FindAsync(obj.IdProducto);
            if (entity == null) return;

            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            entity.Marca_idMarca = obj.Marca.IdMarca; 
            await context.SaveChangesAsync();
        }

        public async Task QuitarCategoria(int Producto, int IdCategoria)
        {
            var entity = await context.Producto
                              .Include("Categoria")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;

            var CategoriaEntity = entity.Categoria.FirstOrDefault(i => i.IdCategoria == IdCategoria);
            if (CategoriaEntity == null) return;

            entity.Categoria.Remove(CategoriaEntity);
            await context.SaveChangesAsync();
        }

        public async Task AgregarCategoria(int Producto, Categoria Categoria)
        {
            var entity = await context.Producto
                              .Include("Categoria")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;
            var categoriaEntity = await context.Categoria
                                       .FirstOrDefaultAsync(p => p.IdCategoria == Categoria.IdCategoria);
            if (categoriaEntity == null) return;
            entity.Categoria.Add(categoriaEntity);
            await context.SaveChangesAsync();
        }

        public async Task QuitarProveedor(int Producto, int IdProveedor)
        {
            var entity = await context.Producto
                              .Include("Proveedor")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;

            var ProveedorEntity = entity.Proveedor.FirstOrDefault(i => i.IdProveedor == IdProveedor);
            if (ProveedorEntity == null) return;

            entity.Proveedor.Remove(ProveedorEntity);
            await context.SaveChangesAsync();
        }

        public async Task AgregarProveedor(int Producto, Proveedor Proveedor)
        {
            var entity = await context.Producto
                              .Include("Proveedor")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;
            var proveedorEntity = await context.Proveedor
                                       .FirstOrDefaultAsync(p => p.IdProveedor == Proveedor.IdProveedor);
            if (proveedorEntity == null) return;

            entity.Proveedor.Add(proveedorEntity);
            await context.SaveChangesAsync();
        }

        public async Task QuitarImagen(int Producto, int IdImagen)
        {
            var entity = await context.Producto
                              .Include("Imagen")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;

            var ImagenEntity = entity.Imagen.FirstOrDefault(i => i.IdImagen == IdImagen);
            if (ImagenEntity == null) return;

            entity.Imagen.Remove(ImagenEntity);
            await context.SaveChangesAsync();
        }

        public async Task AgregarImagen(int Producto, Imagen Imagen)
        {
            var entity = await context.Producto
                              .Include("Imagen")
                              .FirstOrDefaultAsync(m => m.IdProducto == Producto);
            if (entity == null) return;
            entity.Imagen.Add(Imagen.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Producto>> Buscar<Tprop>(Busqueda<Producto> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityProducto> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Producto, EntityProducto>(filtro, mapper);
                Especificacion<EntityProducto> SpecActual = EspecificacionFactory<EntityProducto>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityProducto>(Spec, SpecActual);
            }
            var Resultado = await context.Producto.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Producto, EntityProducto>()
                   .ForMember(
                       dest => dest.Marca_idMarca,
                       opt => opt.MapFrom(src => src.Marca.IdMarca)
                   )
                   .ForMember(
                       dest => dest.Categoria,
                       opt => opt.MapFrom(src => src.Categorias.Select(obj => obj.ToEntity()).ToList())
                   )
                   .ForMember(
                       dest => dest.Imagen,
                       opt => opt.MapFrom(src => src.Imagenes.Select(obj => obj.ToEntity()).ToList())
                   )
                   .ForMember(
                       dest => dest.Proveedor,
                       opt => opt.MapFrom(src => src.Proveedores.Select(obj => obj.ToEntity()).ToList())
                   )
                   .ForMember(dest => dest.Marca, opt => opt.Ignore())
                   .ForMember(dest => dest.ProductoCarrito, opt => opt.Ignore());


                cfg.CreateMap<EntityProducto, Producto>()
                   .ForMember(
                       dest => dest.Marca,
                       opt => opt.MapFrom(src => src.Marca.ToDomain())
                   )
                    .ForMember(
                       dest => dest.Categorias,
                       opt => opt.MapFrom(src => src.Categoria.Select(obj => obj.ToDomain()).ToList())
                   )
                   .ForMember(
                       dest => dest.Imagenes,
                       opt => opt.MapFrom(src => src.Imagen.Select(obj => obj.ToDomain()).ToList())
                   )
                   .ForMember(
                       dest => dest.Proveedores,
                       opt => opt.MapFrom(src => src.Proveedor.Select(obj => obj.ToDomain()).ToList())
                   );
            });
            return config.CreateMapper();
        }
    }
}

