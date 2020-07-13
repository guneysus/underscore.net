using System;
using Xunit;
using Xunit.Abstractions;
using static std.net.Std;

namespace std.net.tests
{
    public abstract class StdTestBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        public StdTestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class StdString : StdTestBase
    {
        public StdString(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void pad_tests()
        {
            const string expected = "  abc   ";
            string actual = pad("abc", 8);

            output.WriteLine(expected);
            output.WriteLine(actual);

            Assert.Equal(expected, actual);

            Assert.Equal("_-abc_-_", pad("abc", 8, "_-"));
            Assert.Equal("--abc---", pad("abc", 8, "-"));
            Assert.Equal("abc", pad("abc", 3));
        }

        [Fact]
        public void pad_right_tests()
        {
            Assert.Equal("abc   ", padright("abc", 6));
            Assert.Equal("abc_-_", padright("abc", 6, "_-"));
            Assert.Equal("abc", padright("abc", 3));
        }

        [Fact]
        public void pad_left_tests()
        {
            Assert.Equal("   abc", padleft("abc", 6));
            Assert.Equal("_-_abc", padleft("abc", 6, "_-"));
            Assert.Equal("abc", padleft("abc", 3));

            Assert.Throws<ArgumentOutOfRangeException>(() => padleft("30690168", 6, '0'));
            Assert.Equal("030690168", padleft("30690168", 9, '0'));
        }
    }
}
