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

    public class FunctionalTools : IternetTestBase
    {
        public FunctionalTools(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void converter_string_to_int()
        {
            Func<string, int> fn = (s) => int.Parse(s);

            Converter<string, int> converter = convertor(fn);

            Assert.Equal(1, converter("1"));
        }
    }
}
