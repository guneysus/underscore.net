using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iter.net
{
    public class DiffResult<TKey, TValue>
    {
        public readonly IEnumerable<KeyValuePair<TKey, TValue>> Added;
        public readonly IEnumerable<KeyValuePair<TKey, TValue>> Deleted;
        public readonly IEnumerable<KeyValuePair<TKey, TValue>> Updated;
        public readonly IEnumerable<KeyValuePair<TKey, TValue>> Same;

        protected DiffResult() { }

        public DiffResult(
            IEnumerable<KeyValuePair<TKey, TValue>> added,
            IEnumerable<KeyValuePair<TKey, TValue>> deleted,
            IEnumerable<KeyValuePair<TKey, TValue>> updated,
            IEnumerable<KeyValuePair<TKey, TValue>> same)
        {
            this.Added = added;
            this.Deleted = deleted;
            this.Updated = updated;
            this.Same = same;
        }
    }

    public class Iterator<T> : IReadOnlyList<T>
    {
        public T this[int index] => _generator(index);

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

    public class Iterator<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public TValue this[TKey index] => _values(index);

        public int Count => _keys().Count();

        private readonly Func<int> _counter;
        private readonly Func<TKey, TValue> _values;
        private readonly Func<IEnumerable<TKey>> _keys;

        IEnumerable<TKey> Keys { get => _keys(); }

        IEnumerable<TValue> Values => Keys.Select(_values);

        Iterator() { }

        internal Iterator(Func<IEnumerable<TKey>> keys, Func<TKey, TValue> values)
        {
            this._keys = keys;
            this._values = values;
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var key in Keys)
                yield return new KeyValuePair<TKey, TValue>(key, _values(key));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
