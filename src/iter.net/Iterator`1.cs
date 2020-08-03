using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iter.net
{

    public class Iterator<T> : IReadOnlyList<T>
    {
        public T this[int index]
        {
            get
            {
                if (index > Count || index < 0) throw new ArgumentOutOfRangeException(nameof(index));
                return _generator(index);
            }
        }

        public int Count => _counter();

        private readonly Func<int> _counter;
        private readonly Func<int, T> _generator;

        internal Iterator(Func<int> counter, Func<int, T> generator)
        {
            this._counter = counter;
            this._generator = generator;
        }

        Iterator() { }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _generator(i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
