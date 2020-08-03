using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iter.net
{

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
