using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iter.net
{

    internal class GenericComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _comparer;

        public GenericComparer(Func<T, T, int> compare)
        {
            _comparer = compare;
        }

        int IComparer<T>.Compare(T x, T y)
        {
            return _comparer(x, y);
        }
    }
}
