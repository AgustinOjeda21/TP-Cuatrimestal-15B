using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infraestructura.Especificaciones
{
    public class NotEspecificacion<T> : Especificacion<T>
    {
        private readonly Especificacion<T> Expr;
        public NotEspecificacion(Especificacion<T> Expr)
        {
            this.Expr = Expr;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var expresion = Expr.ToExpression();
            var body = Expression.Not(expresion.Body);
            return Expression.Lambda<Func<T, bool>>(body, expresion.Parameters);
        }
    }
}
