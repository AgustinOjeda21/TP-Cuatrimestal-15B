using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using Infraestructura.Mappers;
using System.Data.Entity;
using System.Text;
using Aplicacion.Interfaces.Repositorios;
using System.Threading.Tasks;
using Aplicacion.Busqueda;
using Infraestructura.Especificaciones;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;

namespace Infraestructura.Repositorios
{
    public class RepositorioFormaEntrega : IRepositorioFormaEntrega
    {
        private readonly mydbEntities1 context;
        public RepositorioFormaEntrega(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<FormaEntrega>> ObtenerFormasEntrega()
        {
            var Resultado = await context.FormaEntrega.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarFormaEntrega(FormaEntrega aut)
        {
            EntityFormaEntrega Eaut = aut.ToEntity();
            context.FormaEntrega.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaEntrega> CapturarFormaEntrega(int id)
        {
            EntityFormaEntrega Eaut = await context.FormaEntrega.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaEntrega aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(FormaEntrega obj)
        {
            var entity = await context.FormaEntrega.FindAsync(obj.IdFormaEntrega);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<FormaEntrega>> Buscar<Tprop>(Busqueda<FormaEntrega> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityFormaEntrega> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<FormaEntrega, EntityFormaEntrega>(filtro, mapper);
                Especificacion<EntityFormaEntrega> SpecActual = EspecificacionFactory<EntityFormaEntrega>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityFormaEntrega>(Spec, SpecActual);
            }
            var Resultado = await context.FormaEntrega.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<FormaEntrega, EntityFormaEntrega>()
                   .ForMember(dest => dest.DetallePedido, opt => opt.Ignore());

                cfg.CreateMap<EntityFormaEntrega, FormaEntrega>();
            });
            return config.CreateMapper();
        }
    }
}

