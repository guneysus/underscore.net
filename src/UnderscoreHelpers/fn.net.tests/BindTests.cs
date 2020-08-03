using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using _ = fn.net.Fn;
using math.net;

namespace fn.net.tests
{

    public class BindTests : FnTestBase
    {
        public BindTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_Bind()
        {
            string num = " 1000.0  ";
            var trim = new Func<string, string>(s => s.Trim());
            Func<string, Decimal> toDecimal = decimal.Parse;

            Func<string, decimal> composed = _.bind(trim, toDecimal);
            var actual = composed(num);
            var expected = 1000.0m;

            Assert.Equal(expected, actual);
        }
    }
}
