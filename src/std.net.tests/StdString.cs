using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static std.net.Std;
using static fn.net.Fn;
using static refl.net.Refl;
using static iter.net.Iter;

namespace std.net.tests
{

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

        [Fact]
        public void mask_tests()
        {
            const string creditCard = "1234123412341234";
            const string expected = "1234-XXXX-XXXX-1234";

            string actual = mask(creditCard, @"(\d{4})(\d{4})(\d{4})(\d{4})", "$1-XXXX-XXXX-$4");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void String_Length()
        {
            Assert.Equal(0, len(string.Empty));
            Assert.Throws<NullReferenceException>(() => len(null));
            Assert.Equal(3, len("foo"));
        }

        [Fact]
        public void List_Lenght()
        {
            Assert.Equal(0, len(list<string>()));
            Assert.Equal(3, len(list(1, 3, 5)));
        }

        #region Bin

        [Fact]
        public void Bin_sbyte()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_byte()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_short()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_ushort()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_int()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_uint()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_long()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_ulong()
        {
            const string Expected = "1111111111111111111111111111111111111111111111111111111111111111";
            Assert.Equal(Expected, bin(-1L));
            Assert.Equal(Expected, bin(ulong.MaxValue));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_float()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_double()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        [Fact]
        public void Bin_decimal()
        {
            Assert.Equal("11111111111111111111111111111111", bin(-1));
            Assert.Equal("1111101000", bin(1000));
        }

        #endregion

        [Fact]
        public void lower_case_Tests()
        {
            const string Expected = "foo bar";

            Assert.Equal(Expected, lower("Foo Bar"));
            Assert.Equal(Expected, lower("fooBar"));
            Assert.Equal(Expected, lower("FOO BAR"));
        }
    }
}
