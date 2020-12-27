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

            Assert.True(_.same(expected, numbers));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var a = numbers[-1];
            });

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
