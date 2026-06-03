using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructura.Especificaciones
{
    public class MenorEspecificacion<T, Tprop> : Especificacion<T>
    {
        private readonly Expression<Func<T, Tprop>> Selector;
        private readonly Tprop Valor;
        public MenorEspecificacion(Expression<Func<T, Tprop>> Selector, Tprop Valor)
        {
            this.Selector = Selector;
            this.Valor = Valor;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var par = Selector.Parameters[0];
            var left = Selector.Body;
            var body = Expression.LessThanOrEqual(left, Expression.Constant(Valor, left.Type));
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
