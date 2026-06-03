using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infraestructura.Especificaciones
{
    public class EntreEspecificacion<T, Tprop> : Especificacion<T>
    {
        private readonly Expression<Func<T, Tprop>> Selector;
        private readonly Tprop Min;
        private readonly Tprop Max;
        public EntreEspecificacion(Expression<Func<T, Tprop>> Selector, Tprop Min, Tprop Max)
        {
            this.Selector = Selector;
            this.Min = Min;
            this.Max = Max;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var par = Selector.Parameters[0];
            var left = Selector.Body;
            var Mayor = Expression.GreaterThanOrEqual(left, Expression.Constant(Min, left.Type));
            var Menor = Expression.LessThanOrEqual(left, Expression.Constant(Max, left.Type));
            var body = Expression.AndAlso(Mayor, Menor);
            if (Nullable.GetUnderlyingType(left.Type) != null)
            {
                var NoNulo = Expression.NotEqual(left, Expression.Constant(null, left.Type));
                var final = Expression.AndAlso(NoNulo, body);
                return Expression.Lambda<Func<T, bool>>(final, par);
            }
            return Expression.Lambda<Func<T, bool>>(body, par);
        }
    }
}
