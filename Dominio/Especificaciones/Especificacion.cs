using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructura.Especificaciones
{
    public abstract class Especificacion<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public virtual IQueryable<T> Aplicar(IQueryable<T> query) => query.Where(ToExpression());
        public Especificacion<T> And(Especificacion<T> otro)
        => new AndEspecificacion<T>(this, otro);
        public Especificacion<T> Or(Especificacion<T> otro)
        => new OrEspecificacion<T>(this, otro);
        public Especificacion<T> Not()
        => new NotEspecificacion<T>(this);
        public LambdaExpression SelectorOrden { get; protected set; }
        public bool Desc { get; protected set; }
    }
}
