using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infraestructura.Especificaciones
{
    public class AndEspecificacion<T> : Especificacion<T>
    {
        private readonly Especificacion<T> Der;
        private readonly Especificacion<T> Izq;
        public AndEspecificacion(Especificacion<T> Der, Especificacion<T> Izq)
        {
            this.Der = Der;
            this.Izq = Izq;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return ExpressionCombiner.And<T>(Der.ToExpression(), Izq.ToExpression());
        }
    }
}
