using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iter.net
{

    /// <summary>
    /// TODO move to functional.net
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparer;

        public GenericEqualityComparer(Func<T, T, bool> comparer)
        {
            _comparer = comparer;
        }


        public bool Equals(T x, T y)
        {
            return _comparer(x, y);
        }

        public int GetHashCode(T obj)
        {
            // TODO 
            /* 
             * this was obj.GetHashCode(). Since for the structs this always generates different
             * value and it does not enter (short-circuit) Equals(T x, T y) method.
             */
            return base.GetHashCode();
        }
    }
}
