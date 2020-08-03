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

    public class IndexableTests : IternetTestBase
    {
        public IndexableTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Indexable_Simple_Test()
        {
            var numbers = iterator(() => 10, index => index.ToString());
            var expected = list("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");

            Assert.True(same(expected, numbers));
            WriteLine(numbers);
        }

        [Fact]
        public void Indexable_KeyValue_Simple_Test()
        {
            var actual = iterator(() => list(1, 2, 3, 4), key => key.ToString());
            var expected = keyvalues(
                (1, "1")
                , (2, "2")
                , (3, "3")
                , (4, "4")
            );

            Assert.True(same(expected, actual));
            WriteLine(actual);
        }
    }
}
