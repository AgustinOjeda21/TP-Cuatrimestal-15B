using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infraestructura.Especificaciones
{
    public class BuscarStringEspecificacion<T, Tprop> : Especificacion<T>
    {
        private readonly Expression<Func<T, Tprop>> Selector;
        private readonly Tprop Valor;
        private readonly string MetodoNombre;
        public BuscarStringEspecificacion(Expression<Func<T, Tprop>> Selector, Tprop Valor, string MetodoNombre)
        {
            this.Selector = Selector;
            this.Valor = Valor;
            this.MetodoNombre = MetodoNombre;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var par = Selector.Parameters[0];
            var left = Selector.Body;
            var metodo = typeof(string).GetMethod(MetodoNombre, new[] { typeof(string) });
            var NoNulo = Expression.NotEqual(left, Expression.Constant(null, typeof(string)));
            var body = Expression.AndAlso(NoNulo, Expression.Call(left, metodo, Expression.Constant(Valor, typeof(string))));
            return Expression.Lambda<Func<T, bool>>(body, par);


        }
    }
}
