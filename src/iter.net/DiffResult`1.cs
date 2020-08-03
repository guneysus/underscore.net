using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iter.net
{

    public class DiffResult<T>
    {
        public readonly IEnumerable<T> Added;
        public readonly IEnumerable<T> Deleted;
        public readonly IEnumerable<T> Same;

        protected DiffResult() { }

        public DiffResult(IEnumerable<T> added, IEnumerable<T> deleted, IEnumerable<T> same)
        {
            this.Added = added;
            this.Deleted = deleted;
            this.Same = same;
        }
    }
}
