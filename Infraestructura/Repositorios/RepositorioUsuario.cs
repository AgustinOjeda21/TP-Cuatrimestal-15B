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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly mydbEntities1 context;
        public RepositorioUsuario(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            var Resultado = await context.Usuario.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task<int> InsertarUsuario(Usuario aut)
        {
            EntityUsuario Eaut = aut.ToEntity();
            context.Usuario.Add(Eaut);
            await context.SaveChangesAsync();
            return Eaut.IdUsuario;
        }

        public async Task<Usuario> CapturarUsuario(int id)
        {
            EntityUsuario Eaut = await context.Usuario.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            Usuario aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(Usuario obj)
        {
            var entity = await context.Usuario.FindAsync(obj.IdUsuario);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<Usuario>> Buscar<Tprop>(Busqueda<Usuario> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityUsuario> Spec = null;
            foreach(var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<Usuario,EntityUsuario>(filtro, mapper);
                Especificacion<EntityUsuario> SpecActual = EspecificacionFactory<EntityUsuario>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityUsuario>(Spec, SpecActual);
            }
            var Resultado = await context.Usuario.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<Usuario, EntityUsuario>()
                  
                   .ForMember(dest => dest.Persona, opt => opt.Ignore())
                   .ForMember(dest => dest.Rol, opt => opt.Ignore());

                cfg.CreateMap<EntityUsuario, Usuario>();
                   
            });
            return config.CreateMapper();
        }
    }
}

