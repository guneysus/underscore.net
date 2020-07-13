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

        [Fact]
        public void trim_tests()
        {
            Assert.Equal("abc", trim("    abc "));
            Assert.Equal("abc", trim("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trim(null));
        }

        [Fact]
        public void trim_end()
        {
            Assert.Equal("    abc", trimright("    abc "));
            Assert.Equal("-_-abc", trimright("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trimright(null));
        }

        [Fact]
        public void trim_start()
        {
            Assert.Equal("abc ", trimleft("    abc "));
            Assert.Equal("abc-_-", trimleft("-_-abc-_-", "_-"));
            Assert.Throws<ArgumentNullException>(() => trimleft(null));
        }


        [Fact]
        public void truncate_tests()
        {
            Assert.Equal("hi-diddly-ho there, neighbori…", truncate("hi-diddly-ho there, neighborino", 30));
        }

        [Fact]
        public void matchor_tests()
        {
            var matcher = matchor(@"\w+"); // extracts words

            string[] expected = new string[] { "fred", "barney", "pebbles" };
            var actual = matcher("fred, barney, & pebbles");
            Assert.Equal(expected, actual);
        }
    }
}
