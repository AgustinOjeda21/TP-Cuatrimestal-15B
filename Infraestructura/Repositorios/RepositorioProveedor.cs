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
    public class RepositorioProveedor : IRepositorioProveedor
    {
        private readonly mydbEntities1 context;
        public RepositorioProveedor(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            var Resultado = await context.Proveedor.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarProveedor(Proveedor aut)
        {
            EntityProveedor Eaut = aut.ToEntity();
            context.Proveedor.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Proveedor> CapturarProveedor(int id)
        {
            EntityProveedor Eaut = await context.Proveedor.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Proveedor aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Proveedor obj)
        {
            var entity = await context.Proveedor.FindAsync(obj.IdProveedor);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Proveedor>> Buscar<Tprop>(Busqueda<Proveedor> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityProveedor> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Proveedor, EntityProveedor>(filtro, mapper);
                Especificacion<EntityProveedor> SpecActual = EspecificacionFactory<EntityProveedor>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityProveedor>(Spec, SpecActual);
            }
            var Resultado = await context.Proveedor.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Proveedor, EntityProveedor>()
                   .ForMember(
                       dest => dest.Direccion_idDireccion,
                       opt => opt.MapFrom(src => src.Direccion.IdDireccion)
                   )
                   .ForMember(dest => dest.Direccion, opt => opt.Ignore())
                   .ForMember(dest => dest.Producto, opt => opt.Ignore());

                cfg.CreateMap<EntityProveedor, Proveedor>()
                   .ForMember(
                       dest => dest.Direccion,
                       opt => opt.MapFrom(src => src.Direccion.ToDomain())
                   );
            });
            return config.CreateMapper();
        }
    }
}

