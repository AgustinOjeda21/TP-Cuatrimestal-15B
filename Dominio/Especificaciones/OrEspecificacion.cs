using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructura.Especificaciones
{
    class OrEspecificacion<T> : Especificacion<T>
    {
        private readonly Especificacion<T> Der;
        private readonly Especificacion<T> Izq;
        public OrEspecificacion(Especificacion<T> Der, Especificacion<T> Izq)
        {
            this.Der = Der;
            this.Izq = Izq;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return ExpressionCombiner.Or<T>(Der.ToExpression(), Izq.ToExpression());
        }
    }
}
