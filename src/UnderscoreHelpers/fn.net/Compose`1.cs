using System;
using System.Linq;
using System.Linq.Expressions;

namespace fn.net
{
    public class Compose<T> : Compose
    {
        internal Compose(params Expression<Func<string, object>>[] exps)
        {
            data = exps.ToList().ToDictionary(x => x.Parameters.Single().Name, x => new Func<object>(() => x.Compile()(default)));
        }
    }



}
