using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructura.Especificaciones
{
    public static class ExpressionCombiner
    {
        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> Der, Expression<Func<T, bool>> Izq)
        {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(Replace(Izq.Body, Izq.Parameters[0], param), Replace(Der.Body, Der.Parameters[0], param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
        public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> Der, Expression<Func<T, bool>> Izq)
        {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(Replace(Izq.Body, Izq.Parameters[0], param), Replace(Der.Body, Der.Parameters[0], param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        private static Expression Replace(Expression nodo, ParameterExpression oldpar, ParameterExpression newpar)
        {
            return new ReplaceVisitor(oldpar, newpar).Visit(nodo);
        }

        private class ReplaceVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression newpar;
            private readonly ParameterExpression oldpar;

            public ReplaceVisitor(ParameterExpression oldpar, ParameterExpression newpar)
            {
                this.newpar = newpar;
                this.oldpar = oldpar;
            }

            protected override Expression VisitParameter(ParameterExpression nodo)
            {
                return nodo == oldpar ? newpar : base.VisitParameter(nodo);
            }

        }
    }
}
