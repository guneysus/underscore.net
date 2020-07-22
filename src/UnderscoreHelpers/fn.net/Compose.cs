using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace fn.net
{

    public class Compose
    {
        protected Dictionary<string, Func<object>> data;
        protected Compose() { }

        public TResult Get<TResult>(string name) => data.ContainsKey(name) ? (TResult)data[name]() : default;

        public TResult Get<TResult>(Expression<Func<Compose, TResult>> prop)
        {
            string name = prop.Parameters.Single().Name;
            return data.ContainsKey(name) ? (TResult)data[name]() : default;
        }
    }



}
