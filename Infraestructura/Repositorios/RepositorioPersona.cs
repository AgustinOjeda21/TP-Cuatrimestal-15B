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
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly mydbEntities1 context;
        public RepositorioPersona(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Persona>> ObtenerPersonas()
        {
            var Resultado = await context.Persona.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarPersona(Persona aut)
        {
            EntityPersona Eaut = aut.ToEntity();
            context.Persona.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Persona> CapturarPersona(int id)
        {
            EntityPersona Eaut = await context.Persona.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Persona aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Persona obj)
        {
            var entity = await context.Persona.FindAsync(obj.IdPersona);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task QuitarDireccion(int persona, int IdDireccion)
        {
            var entity = await context.Persona
                              .Include("Direccion")
                              .FirstOrDefaultAsync(m => m.IdPersona == persona);
            if (entity == null) return;

            var DireccionEntity = entity.Direccion.FirstOrDefault(i => i.IdDireccion == IdDireccion);
            if (DireccionEntity == null) return;

            entity.Direccion.Remove(DireccionEntity);
            await context.SaveChangesAsync();
        }

        public async Task AgregarDireccion(int persona, Direccion Direccion)
        {
            var entity = await context.Persona
                              .Include("Direccion")
                              .FirstOrDefaultAsync(m => m.IdPersona == persona);
            if (entity == null) return;
            entity.Direccion.Add(Direccion.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Persona>> Buscar<Tprop>(Busqueda<Persona> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityPersona> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Persona, EntityPersona>(filtro, mapper);
                Especificacion<EntityPersona> SpecActual = EspecificacionFactory<EntityPersona>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityPersona>(Spec, SpecActual);
            }
            var Resultado = await context.Persona.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Persona, EntityPersona>()
                   .ForMember(
                       dest => dest.Usuario_idUsuario,
                       opt => opt.MapFrom(src => src.Usuario)
                   )
                   .ForMember(
                       dest => dest.Direccion,
                       opt => opt.MapFrom(src => src.Direcciones.Select(obj=>obj.ToEntity()).ToList())
                   )
                   .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                   .ForMember(dest => dest.Pedido, opt => opt.Ignore());

                cfg.CreateMap<EntityPersona, Persona>()
                   .ForMember(
                       dest => dest.Usuario,
                       opt => opt.MapFrom(src => src.Usuario.ToDomain())
                   )
                   .ForMember(
                       dest => dest.Direcciones,
                       opt => opt.MapFrom(src => src.Direccion.Select(obj => obj.ToDomain()).ToList())
                   );
            });
            return config.CreateMapper();
        }
    }
}

