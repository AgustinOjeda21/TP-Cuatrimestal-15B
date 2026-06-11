using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Infraestructura.Repositorios
{
    public class RepositorioDireccion : IRepositorioDireccion
    {
        private readonly mydbEntities1 context;
        public RepositorioDireccion(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Direccion>> ObtenerDirecciones()
        {
            var Resultado = await context.Direccion.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarDireccion(Direccion aut)
        {
            EntityDireccion Eaut = aut.ToEntity();
            context.Direccion.Add(Eaut);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errores = string.Join("\n", ex.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => e.PropertyName + ": " + e.ErrorMessage));

                throw new Exception(errores); // ← ahora el mensaje del error te dice exactamente qué campo falla
            }
        }

        public async Task<Direccion> CapturarDireccion(int id)
        {
            EntityDireccion Eaut = await context.Direccion.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Direccion aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Direccion obj)
        {
            var entity = await context.Direccion.FindAsync(obj.IdDireccion);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Direccion>> Buscar<Tprop>(Busqueda<Direccion> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityDireccion> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Direccion, EntityDireccion>(filtro, mapper);
                Especificacion<EntityDireccion> SpecActual = EspecificacionFactory<EntityDireccion>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityDireccion>(Spec, SpecActual);
            }
            var Resultado = await context.Direccion.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Direccion, EntityDireccion>()
                   .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
                   .ForMember(dest => dest.DetallePedido, opt => opt.Ignore())
                   .ForMember(dest => dest.Persona, opt => opt.Ignore());

                cfg.CreateMap<EntityDireccion, Direccion>();
            });
            return config.CreateMapper();
        }
    }
}

