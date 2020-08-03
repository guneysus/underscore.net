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

    public class ArrayTests : IternetTestBase
    {
        public ArrayTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void compact_tests()
        {
            var numbers = new List<int?>(new int?[] { 1, 2, null });
            Assert.Equal(new int[] { 1, 2 }, Iter.compact(numbers));
        }
    }
}
