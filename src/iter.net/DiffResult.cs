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
}
