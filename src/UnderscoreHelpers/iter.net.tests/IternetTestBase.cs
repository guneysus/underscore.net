using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static iter.net.Iter;
using _ = iter.net.Iter;
using static std.net.Std;
using std.net;

namespace iter.net.tests
{
    public abstract class IternetTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public IternetTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);
        public void WriteLine(object obj) => output.WriteLine(obj.ToString());

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
        protected void WriteLine<T>(IEnumerable<T> items) => output.WriteLine(string.Join(", ", items.Select(x => $"\"{x}\"")));
    }
}
