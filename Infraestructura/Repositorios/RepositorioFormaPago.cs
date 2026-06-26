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
    public class RepositorioFormaPago : IRepositorioFormaPago
    {
        private readonly mydbEntities1 context;
        public RepositorioFormaPago(mydbEntities1 context)
        {
            this.context = context;
        }

        public async Task<List<FormaPago>> ObtenerFormasPago()
        {
            var Resultado = await context.FormaPago.ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        public async Task InsertarFormaPago(FormaPago aut)
        {
            EntityFormaPago Eaut = aut.ToEntity();
            context.FormaPago.Add(Eaut);
            await context.SaveChangesAsync();
        }

        public async Task<FormaPago> CapturarFormaPago(int id)
        {
            EntityFormaPago Eaut = await context.FormaPago.FindAsync(id);
            if (Eaut == null)
            {
                return null;
            }
            FormaPago aut = Eaut.ToDomain();
            return aut;
        }
        public async Task Actualizar(FormaPago obj)
        {
            var entity = await context.FormaPago.FindAsync(obj.IdFormaPago);
            if (entity == null)
            {
                return;
            }
            context.Entry(entity).CurrentValues.SetValues(obj.ToEntity());
            await context.SaveChangesAsync();
        }
        public async Task<List<FormaPago>> Buscar(Busqueda<FormaPago> busqueda)
        {
            IMapper mapper = config();
            Especificacion<EntityFormaPago> Spec = null;
            foreach (var filtro in busqueda.Filtros)
            {
                var filtroEntity = FiltroTraductor.Traducir<FormaPago, EntityFormaPago>(filtro, mapper);
                Especificacion<EntityFormaPago> SpecActual = EspecificacionFactory<EntityFormaPago>.CrearSpec(filtroEntity);
                Spec = Spec == null ? SpecActual : new AndEspecificacion<EntityFormaPago>(Spec, SpecActual);
            }
            var Resultado = await context.FormaPago.Where(Spec.ToExpression()).ToListAsync();
            return Resultado.Select(e => e.ToDomain()).ToList();
        }
        private IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();

                cfg.CreateMap<FormaPago, EntityFormaPago>()
                   .ForMember(dest => dest.DetallePedido, opt => opt.Ignore());


                cfg.CreateMap<EntityFormaPago, FormaPago>();
            });
            return config.CreateMapper();
        }
    }
}

