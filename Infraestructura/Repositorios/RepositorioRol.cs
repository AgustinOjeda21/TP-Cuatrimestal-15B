using System;
using System.Collections.Generic;
using System.Linq;
using Aplicacion.Interfaces.Repositorios;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Busqueda;
using System.Threading.Tasks;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        private readonly mydbEntities context;
        public RepositorioRol(mydbEntities context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> ObtenerRoles()
        {
            var Resultado = await context.Rol.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }

        public async Task InsertarRol(Rol aut)
        {
            EntityRol Eaut = aut.ToEntity();
            context.Rol.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<Rol> CapturarRol(int id)
        {
            EntityRol Eaut = await context.Rol.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Rol aut = new Rol(Eaut.IdRol, Eaut.Nombre);
            return aut;
        }

        public async Task Actualizar(Rol obj)
        {
            var entity = await context.Rol.FindAsync(obj.IdRol);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Rol>> Buscar<Tprop>(Busqueda<Rol> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityRol> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Rol, EntityRol>(filtro, mapper);
                Especificacion<EntityRol> SpecActual = EspecificacionFactory<EntityRol>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityRol>(Spec, SpecActual);
            }
            var Resultado = await context.Rol.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Rol, EntityRol>()
                   .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                   .ForMember(dest => dest.Permiso, opt => opt.Ignore());

                cfg.CreateMap<EntityRol, Rol>();

            });
            return config.CreateMapper();
        }
    }
}
