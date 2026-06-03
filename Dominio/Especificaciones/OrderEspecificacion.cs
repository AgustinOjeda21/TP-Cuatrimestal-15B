using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Especificaciones
{
    public class OrderEspecificacion<T, Tkey> : Especificacion<T>
    {
        private readonly Especificacion<T> Inner;

        public OrderEspecificacion(Especificacion<T> Inner, Expression<Func<T, Tkey>> Selector, bool Desc)
        {
            this.Inner = Inner;
            SelectorOrden = Selector;
            this.Desc = Desc;
        }
        public OrderEspecificacion(Expression<Func<T, Tkey>> Selector, bool Desc)
        {
            Inner = null;
            SelectorOrden = Selector;
            this.Desc = Desc;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return Inner?.ToExpression() ?? (x => true);
        }
    }
}
