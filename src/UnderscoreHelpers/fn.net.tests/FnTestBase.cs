using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static fn.net.FnX;

namespace fn.net.tests
{
    public abstract class FnTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public FnTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class ComposeTests : FnTestBase
    {
        public ComposeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_Compose()
        {
            string num = " 1000.0  ";
            var trim = new Func<string, string>(s => s.Trim());
            Func<string, Decimal> toDecimal = decimal.Parse;

            Func<string, decimal> composed = compose(trim, toDecimal);
            var actual = composed(num);
            var expected = 1000.0m;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Simple_pipe()
        {
            var msg = "   lorem ipsum di amet           ";

            Func<string, string> trimSpaces = new Func<string, string>(s => s.Trim());
            Func<string, string> trimLodashes = new Func<string, string>(s => s.Trim('_'));
            Func<string, string> padRight = s => s.PadRight(30, '_');
            Func<string, string> padLeft = s => s.PadLeft(45, '_');
            Func<string, string> upper = s => s.ToUpperInvariant();

            var pipeline = pipe(
                trimSpaces
                , padRight
                , padLeft
                , trimLodashes
                , upper
                );

            var actual = pipeline(msg);

            WriteLine(actual);
            Assert.Equal("LOREM IPSUM DI AMET", actual);
        }
    }
}
